namespace DataProcessing
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
            this.DgvFilenames = new System.Windows.Forms.DataGridView();
            this.DgcFilename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BtnProcessFilesSingleThreaded = new System.Windows.Forms.Button();
            this.BtnProcessFilesMultiThreaded = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TrbThreadCount = new System.Windows.Forms.TrackBar();
            this.LblThreadCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DgvFilenames)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbThreadCount)).BeginInit();
            this.SuspendLayout();
            // 
            // DgvFilenames
            // 
            this.DgvFilenames.AllowUserToAddRows = false;
            this.DgvFilenames.AllowUserToDeleteRows = false;
            this.DgvFilenames.AllowUserToResizeColumns = false;
            this.DgvFilenames.AllowUserToResizeRows = false;
            this.DgvFilenames.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DgvFilenames.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvFilenames.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DgcFilename});
            this.DgvFilenames.Location = new System.Drawing.Point(13, 13);
            this.DgvFilenames.Name = "DgvFilenames";
            this.DgvFilenames.RowHeadersVisible = false;
            this.DgvFilenames.ShowEditingIcon = false;
            this.DgvFilenames.ShowRowErrors = false;
            this.DgvFilenames.Size = new System.Drawing.Size(645, 425);
            this.DgvFilenames.TabIndex = 0;
            // 
            // DgcFilename
            // 
            this.DgcFilename.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DgcFilename.HeaderText = "Filename";
            this.DgcFilename.Name = "DgcFilename";
            this.DgcFilename.ReadOnly = true;
            // 
            // BtnProcessFilesSingleThreaded
            // 
            this.BtnProcessFilesSingleThreaded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnProcessFilesSingleThreaded.Location = new System.Drawing.Point(664, 236);
            this.BtnProcessFilesSingleThreaded.Name = "BtnProcessFilesSingleThreaded";
            this.BtnProcessFilesSingleThreaded.Size = new System.Drawing.Size(124, 42);
            this.BtnProcessFilesSingleThreaded.TabIndex = 1;
            this.BtnProcessFilesSingleThreaded.Text = "Process Files Single Threaded";
            this.BtnProcessFilesSingleThreaded.UseVisualStyleBackColor = true;
            this.BtnProcessFilesSingleThreaded.Click += new System.EventHandler(this.BtnProcessFilesSingleThreaded_Click);
            // 
            // BtnProcessFilesMultiThreaded
            // 
            this.BtnProcessFilesMultiThreaded.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnProcessFilesMultiThreaded.Location = new System.Drawing.Point(664, 348);
            this.BtnProcessFilesMultiThreaded.Name = "BtnProcessFilesMultiThreaded";
            this.BtnProcessFilesMultiThreaded.Size = new System.Drawing.Size(124, 42);
            this.BtnProcessFilesMultiThreaded.TabIndex = 2;
            this.BtnProcessFilesMultiThreaded.Text = "Process Files MultiThreaded";
            this.BtnProcessFilesMultiThreaded.UseVisualStyleBackColor = true;
            this.BtnProcessFilesMultiThreaded.Click += new System.EventHandler(this.BtnProcessFilesMultiThreaded_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.Location = new System.Drawing.Point(664, 396);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(124, 42);
            this.BtnCancel.TabIndex = 3;
            this.BtnCancel.Text = "Cancel Processing";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TrbThreadCount
            // 
            this.TrbThreadCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TrbThreadCount.Location = new System.Drawing.Point(664, 297);
            this.TrbThreadCount.Minimum = 1;
            this.TrbThreadCount.Name = "TrbThreadCount";
            this.TrbThreadCount.Size = new System.Drawing.Size(124, 45);
            this.TrbThreadCount.TabIndex = 4;
            this.TrbThreadCount.Value = 1;
            this.TrbThreadCount.Scroll += new System.EventHandler(this.TrbThreadCount_Scroll);
            // 
            // LblThreadCount
            // 
            this.LblThreadCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblThreadCount.AutoSize = true;
            this.LblThreadCount.Location = new System.Drawing.Point(664, 281);
            this.LblThreadCount.Name = "LblThreadCount";
            this.LblThreadCount.Size = new System.Drawing.Size(101, 13);
            this.LblThreadCount.TabIndex = 5;
            this.LblThreadCount.Text = "Number of Threads:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.LblThreadCount);
            this.Controls.Add(this.TrbThreadCount);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnProcessFilesMultiThreaded);
            this.Controls.Add(this.BtnProcessFilesSingleThreaded);
            this.Controls.Add(this.DgvFilenames);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DgvFilenames)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TrbThreadCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvFilenames;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcFilename;
        private System.Windows.Forms.Button BtnProcessFilesSingleThreaded;
        private System.Windows.Forms.Button BtnProcessFilesMultiThreaded;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.TrackBar TrbThreadCount;
        private System.Windows.Forms.Label LblThreadCount;
    }
}

