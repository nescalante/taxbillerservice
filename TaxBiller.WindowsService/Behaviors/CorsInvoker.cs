using System;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;

namespace TaxBiller.WindowsService
{
    public class CorsInvoker : IOperationInvoker
    {
        public bool IsSynchronous
        {
            get { return true; }
        }
        
        private readonly IOperationInvoker _originalInvoker;
        
        public CorsInvoker(IOperationInvoker invoker)
        {
            if (!invoker.IsSynchronous)
            {
                throw new NotSupportedException("This implementation only supports syncronous invokers.");
            }
            _originalInvoker = invoker;
        }
        
        public object[] AllocateInputs()
        {
            return _originalInvoker.AllocateInputs();
        }
        
        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            if (OperationContext.Current.IncomingMessageProperties.ContainsKey(CorsDispatchMessageInspector.CrossOriginResourceSharingPropertyName))
            {
                var state = OperationContext.Current.IncomingMessageProperties[CorsDispatchMessageInspector.CrossOriginResourceSharingPropertyName] as CorsState;
                if (state != null && state.Message != null)
                {
                    outputs = null;
                    return null;
                }
            }
            return _originalInvoker.Invoke(instance, inputs, out outputs);
        }
        
        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            throw new NotSupportedException();
        }
        
        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            throw new NotSupportedException();
        }
    }
}