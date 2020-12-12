namespace AsyncOperations
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnDownloadPageSync = new System.Windows.Forms.Button();
            this.BtnCancelDownload = new System.Windows.Forms.Button();
            this.TxtWebPage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PgbDownloadProgress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnDownloadPageAsync = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnDownloadPageSync
            // 
            this.BtnDownloadPageSync.Location = new System.Drawing.Point(12, 320);
            this.BtnDownloadPageSync.Name = "BtnDownloadPageSync";
            this.BtnDownloadPageSync.Size = new System.Drawing.Size(190, 23);
            this.BtnDownloadPageSync.TabIndex = 1;
            this.BtnDownloadPageSync.Text = "Download Page Synchronously";
            this.BtnDownloadPageSync.UseVisualStyleBackColor = true;
            this.BtnDownloadPageSync.Click += new System.EventHandler(this.BtnDownloadPageSync_Click);
            // 
            // BtnCancelDownload
            // 
            this.BtnCancelDownload.Location = new System.Drawing.Point(597, 320);
            this.BtnCancelDownload.Name = "BtnCancelDownload";
            this.BtnCancelDownload.Size = new System.Drawing.Size(100, 23);
            this.BtnCancelDownload.TabIndex = 2;
            this.BtnCancelDownload.Text = "Cancel Download";
            this.BtnCancelDownload.UseVisualStyleBackColor = true;
            this.BtnCancelDownload.Click += new System.EventHandler(this.BtnCancelDownload_Click);
            // 
            // TxtWebPage
            // 
            this.TxtWebPage.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.TxtWebPage.Location = new System.Drawing.Point(12, 51);
            this.TxtWebPage.Multiline = true;
            this.TxtWebPage.Name = "TxtWebPage";
            this.TxtWebPage.ReadOnly = true;
            this.TxtWebPage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TxtWebPage.Size = new System.Drawing.Size(685, 221);
            this.TxtWebPage.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Web Page:";
            // 
            // TxtUrl
            // 
            this.TxtUrl.Location = new System.Drawing.Point(43, 12);
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Size = new System.Drawing.Size(654, 20);
            this.TxtUrl.TabIndex = 6;
            this.TxtUrl.Text = "https://en.cppreference.com/w/cpp/atomic/atomic";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "URL:";
            // 
            // PgbDownloadProgress
            // 
            this.PgbDownloadProgress.Location = new System.Drawing.Point(12, 291);
            this.PgbDownloadProgress.Name = "PgbDownloadProgress";
            this.PgbDownloadProgress.Size = new System.Drawing.Size(684, 23);
            this.PgbDownloadProgress.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 275);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Web Page:";
            // 
            // BtnDownloadPageAsync
            // 
            this.BtnDownloadPageAsync.Location = new System.Drawing.Point(208, 322);
            this.BtnDownloadPageAsync.Name = "BtnDownloadPageAsync";
            this.BtnDownloadPageAsync.Size = new System.Drawing.Size(190, 23);
            this.BtnDownloadPageAsync.TabIndex = 10;
            this.BtnDownloadPageAsync.Text = "Download Page Asynchronously";
            this.BtnDownloadPageAsync.UseVisualStyleBackColor = true;
            this.BtnDownloadPageAsync.Click += new System.EventHandler(this.BtnDownloadPageAsync_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 357);
            this.Controls.Add(this.BtnDownloadPageAsync);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PgbDownloadProgress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TxtUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtWebPage);
            this.Controls.Add(this.BtnCancelDownload);
            this.Controls.Add(this.BtnDownloadPageSync);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button BtnDownloadPageSync;
        private System.Windows.Forms.Button BtnCancelDownload;
        private System.Windows.Forms.TextBox TxtWebPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtUrl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ProgressBar PgbDownloadProgress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnDownloadPageAsync;
    }
}

