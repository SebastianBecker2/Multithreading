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
            ((System.ComponentModel.ISupportInitialize)(this.DgvFilenames)).BeginInit();
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
            this.BtnProcessFilesSingleThreaded.Location = new System.Drawing.Point(664, 300);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnProcessFilesMultiThreaded);
            this.Controls.Add(this.BtnProcessFilesSingleThreaded);
            this.Controls.Add(this.DgvFilenames);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DgvFilenames)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DgvFilenames;
        private System.Windows.Forms.DataGridViewTextBoxColumn DgcFilename;
        private System.Windows.Forms.Button BtnProcessFilesSingleThreaded;
        private System.Windows.Forms.Button BtnProcessFilesMultiThreaded;
        private System.Windows.Forms.Button BtnCancel;
    }
}

