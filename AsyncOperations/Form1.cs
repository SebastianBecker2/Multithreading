using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsyncOperations
{
    public partial class Form1 : Form
    {
        WebServer WebServer = new WebServer();

        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        private void UpdateProgressSync(object sender, DownloadProgressChangedEventArgs args)
        {
            PgbDownloadProgress.Value = args.Progress;
        }

        private void UpdateProgressAsync(object sender, DownloadProgressChangedEventArgs args)
        {
            PgbDownloadProgress.InvokeIfRequired(() => PgbDownloadProgress.Value = args.Progress);
        }

        private void BtnDownloadPageSync_Click(object sender, EventArgs e)
        {
            TxtWebPage.Text = "";

            WebServer.Url = TxtUrl.Text;
            WebServer.DownloadProgressChanged += UpdateProgressSync;

            var PageContent = WebServer.DownloadPage();

            TxtWebPage.Text = PageContent;
            WebServer.DownloadProgressChanged -= UpdateProgressSync;
        }

        private void BtnDownloadPageAsync_Click(object sender, EventArgs e)
        {
            TxtWebPage.Text = "";

            WebServer.Url = TxtUrl.Text;
            WebServer.DownloadProgressChanged += UpdateProgressAsync;

            Task.Factory.StartNew(() =>
            {
                return WebServer.DownloadPage();
            }).ContinueWith(t =>
            {
                TxtWebPage.InvokeIfRequired(() => TxtWebPage.Text = t.Result);
                WebServer.DownloadProgressChanged -= UpdateProgressAsync;
            });
        }

        private void BtnCancelDownload_Click(object sender, EventArgs e)
        {
            WebServer.CancelDownload();
        }
    }
}
