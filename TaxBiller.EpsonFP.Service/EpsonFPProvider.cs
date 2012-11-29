using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using EpsonFPHostControlX;
using TaxBiller.Common;
using TaxBiller.Contract;
using TaxBiller.EpsonFP.Service.Resources;

namespace TaxBiller.EpsonFP.Service
{
    internal class EpsonFPProvider
    {
        private IEpsonFPHostControl EpsonFPHostControl 
        {
            get
            {
                if (_epsonFPHostControl == null)
                {
                    _epsonFPHostControl = new EpsonFPHostControlClass();
                }

                return _epsonFPHostControl;
            }
        }

        private IEpsonFPHostControl _epsonFPHostControl;
        
        internal EpsonFPInfo Info
        {
            get
            {
                return new EpsonFPInfo(EpsonFPHostControl.ReturnCode, EpsonFPHostControl.PrinterStatus, EpsonFPHostControl.FiscalStatus);
            }
        }

        internal EpsonFPProvider()
        {
        }

        internal EpsonFPInfo SendData(params object[] data)
        {
            return this.SendData(data);
        }

        internal EpsonFPInfo SendData(EpsonFPCommand command, bool reconnect = true)
        {
            return this.SendData(new[] { command }, reconnect);
        }

        internal EpsonFPInfo SendData(IEnumerable<object> data, bool reconnect = true)
        {
            try
            {
                if (reconnect)
                {
                    this.Connect();
                }

                foreach (var field in data)
                {
                    if (field is EpsonFPCommand)
                    {
                        var command = field as EpsonFPCommand;
                        this.AddDataField(command.Cmd);
                        this.AddDataField(command.CmdExt);
                    }
                    else
                    {
                        this.AddDataField(field.ToString());
                    }
                }

                this.Send();
            }
            catch (Exception ex)
            {
                throw new PrinterException(Error.CouldNotSendData, ex, this.Info);
            }

            if (this.Info.ReturnCode != 0)
            {
                throw new PrinterException(Error.CouldNotSendData, this.Info);
            }

            return this.Info;
        }

        internal string GetExtraField(int fieldNumber)
        {
            return EpsonFPHostControl.GetExtraField(fieldNumber);
        }

        private void Initialize()
        {
            EpsonFPHostControl.CommPort = (TxCommPort)Configuration.Comm;
            EpsonFPHostControl.BaudRate = (TxBaudRate)Configuration.BaudRate;
            EpsonFPHostControl.ProtocolType = TxProtocolType.protocol_Extended;
        }

        private void Connect()
        {
            EpsonFPHostControl.ClosePort();
            
            this.WaitForProcess();
            this.Initialize();

            if (EpsonFPHostControl.OpenPort())
            {
                this.WaitForProcess();
            }
            else
            {
                throw new InvalidOperationException(Error.CouldNotConnect);
            }
        }

        private void AddDataField(string value)
        {
            if (!EpsonFPHostControl.AddDataField(value))
            {
                throw new InvalidOperationException(string.Format(Error.CouldNotAddField, value));
            }
        }

        private void Send()
        {
            if (!EpsonFPHostControl.SendCommand())
            {
                throw new InvalidOperationException(Error.CouldNotSendCommand);
            }

            this.WaitForProcess();
        }

        private void WaitForProcess()
        {
            while (EpsonFPHostControl.State == TxFiscalState.EFP_S_Busy)
            {
                Thread.Sleep(100);
            }
        }
    }
}
