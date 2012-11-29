using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TaxBiller.WinForm
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            System.Uri uri = new Uri("http://demo.winkshotel.com.ar//people.xml?accommodation_id=144&current_guests=true");

             // encode the credentials in Base64
             byte[] authData = System.Text.UnicodeEncoding.UTF8.GetBytes("demowinkshotel@gmail.com:demowinkshotel");
                    
             // build the whole header
             string authHeader = "Authorization: Basic " + Convert.ToBase64String(authData) + System.Environment.NewLine;

             // open the page with the extra header
             webBrowser1.Navigate(uri, "", null, authHeader);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            string result = webBrowser1.DocumentText;
            result = result.Replace("&nbsp;", " ");
            
            DataSet ds = new DataSet();
    
            try
            {
                System.Xml.XmlReader reader = System.Xml.XmlReader.Create(new System.IO.StringReader(result));
                ds.ReadXml(reader);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}