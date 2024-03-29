﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;


namespace TaxBiller.WindowsService
{
    [RunInstaller(true)]
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();

            this.AfterInstall += new InstallEventHandler(Initialize);
        }

        void Initialize(object sender, InstallEventArgs e)
        {
            ServiceController sc = new ServiceController("BillingService");
            sc.Start();
        }
    }
}
