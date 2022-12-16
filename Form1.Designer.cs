namespace ScraperTest_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.RetrieveButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.ViewDataBtn = new System.Windows.Forms.Button();
            this.DownLoadImagesBtn = new System.Windows.Forms.Button();
            this.SetCountBtn = new System.Windows.Forms.Button();
            this.TestBtn = new System.Windows.Forms.Button();
            this.AddBtn = new System.Windows.Forms.Button();
            this.IdentifiedBtn = new System.Windows.Forms.Button();
            this.FindInfoBtn = new System.Windows.Forms.Button();
            this.AddInfoToDbBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Main_progress = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ReadXlBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // RetrieveButton
            // 
            this.RetrieveButton.Location = new System.Drawing.Point(6, 95);
            this.RetrieveButton.Name = "RetrieveButton";
            this.RetrieveButton.Size = new System.Drawing.Size(108, 23);
            this.RetrieveButton.TabIndex = 2;
            this.RetrieveButton.Text = "RETRIEVE";
            this.RetrieveButton.UseVisualStyleBackColor = true;
            this.RetrieveButton.Click += new System.EventHandler(this.RetrieveButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(6, 66);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(108, 23);
            this.ClearButton.TabIndex = 17;
            this.ClearButton.Text = "CLEAR";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // ViewDataBtn
            // 
            this.ViewDataBtn.Location = new System.Drawing.Point(120, 95);
            this.ViewDataBtn.Name = "ViewDataBtn";
            this.ViewDataBtn.Size = new System.Drawing.Size(137, 23);
            this.ViewDataBtn.TabIndex = 18;
            this.ViewDataBtn.Text = "VIEW DATA";
            this.ViewDataBtn.UseVisualStyleBackColor = true;
            this.ViewDataBtn.Click += new System.EventHandler(this.ViewDataBtn_Click);
            // 
            // DownLoadImagesBtn
            // 
            this.DownLoadImagesBtn.Location = new System.Drawing.Point(120, 66);
            this.DownLoadImagesBtn.Name = "DownLoadImagesBtn";
            this.DownLoadImagesBtn.Size = new System.Drawing.Size(137, 23);
            this.DownLoadImagesBtn.TabIndex = 19;
            this.DownLoadImagesBtn.Text = "DOWNLOAD IMAGES";
            this.DownLoadImagesBtn.UseVisualStyleBackColor = true;
            this.DownLoadImagesBtn.Click += new System.EventHandler(this.DownLoadImagesBtn_Click);
            // 
            // SetCountBtn
            // 
            this.SetCountBtn.Location = new System.Drawing.Point(6, 37);
            this.SetCountBtn.Name = "SetCountBtn";
            this.SetCountBtn.Size = new System.Drawing.Size(108, 23);
            this.SetCountBtn.TabIndex = 21;
            this.SetCountBtn.Text = "SET URLS COUNT";
            this.SetCountBtn.UseVisualStyleBackColor = true;
            this.SetCountBtn.Click += new System.EventHandler(this.SetCountBtn_Click);
            // 
            // TestBtn
            // 
            this.TestBtn.Location = new System.Drawing.Point(263, 95);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(144, 23);
            this.TestBtn.TabIndex = 23;
            this.TestBtn.Text = "BUILD HAZARDS INFO";
            this.TestBtn.UseVisualStyleBackColor = true;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(263, 66);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(144, 23);
            this.AddBtn.TabIndex = 25;
            this.AddBtn.Text = "ADD HAZARDS TO DB";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // IdentifiedBtn
            // 
            this.IdentifiedBtn.Location = new System.Drawing.Point(6, 95);
            this.IdentifiedBtn.Name = "IdentifiedBtn";
            this.IdentifiedBtn.Size = new System.Drawing.Size(177, 23);
            this.IdentifiedBtn.TabIndex = 26;
            this.IdentifiedBtn.Text = "FIND SUB URLS";
            this.IdentifiedBtn.UseVisualStyleBackColor = true;
            this.IdentifiedBtn.Click += new System.EventHandler(this.IdentifiedBtn_Click);
            // 
            // FindInfoBtn
            // 
            this.FindInfoBtn.Location = new System.Drawing.Point(6, 66);
            this.FindInfoBtn.Name = "FindInfoBtn";
            this.FindInfoBtn.Size = new System.Drawing.Size(177, 23);
            this.FindInfoBtn.TabIndex = 27;
            this.FindInfoBtn.Text = "RETRIEVE SUB INFO";
            this.FindInfoBtn.UseVisualStyleBackColor = true;
            this.FindInfoBtn.Click += new System.EventHandler(this.FindInfoBtn_Click);
            // 
            // AddInfoToDbBtn
            // 
            this.AddInfoToDbBtn.Location = new System.Drawing.Point(6, 37);
            this.AddInfoToDbBtn.Name = "AddInfoToDbBtn";
            this.AddInfoToDbBtn.Size = new System.Drawing.Size(177, 23);
            this.AddInfoToDbBtn.TabIndex = 28;
            this.AddInfoToDbBtn.Text = "ADD INFO TO DB";
            this.AddInfoToDbBtn.UseVisualStyleBackColor = true;
            this.AddInfoToDbBtn.Click += new System.EventHandler(this.AddInfoToDbBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Main_progress);
            this.groupBox1.Controls.Add(this.AddBtn);
            this.groupBox1.Controls.Add(this.TestBtn);
            this.groupBox1.Controls.Add(this.SetCountBtn);
            this.groupBox1.Controls.Add(this.ClearButton);
            this.groupBox1.Controls.Add(this.RetrieveButton);
            this.groupBox1.Controls.Add(this.ViewDataBtn);
            this.groupBox1.Controls.Add(this.DownLoadImagesBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(418, 126);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "CL INVENTORY ( ALL )";
            // 
            // Main_progress
            // 
            this.Main_progress.Location = new System.Drawing.Point(120, 37);
            this.Main_progress.Name = "Main_progress";
            this.Main_progress.Size = new System.Drawing.Size(287, 23);
            this.Main_progress.TabIndex = 26;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.IdentifiedBtn);
            this.groupBox2.Controls.Add(this.FindInfoBtn);
            this.groupBox2.Controls.Add(this.AddInfoToDbBtn);
            this.groupBox2.Location = new System.Drawing.Point(436, 204);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(189, 126);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "REGISTERED INVENTORY";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ReadXlBtn);
            this.groupBox3.Location = new System.Drawing.Point(631, 204);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(157, 126);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "EXCEL INVENTORY";
            // 
            // ReadXlBtn
            // 
            this.ReadXlBtn.Location = new System.Drawing.Point(6, 95);
            this.ReadXlBtn.Name = "ReadXlBtn";
            this.ReadXlBtn.Size = new System.Drawing.Size(145, 23);
            this.ReadXlBtn.TabIndex = 0;
            this.ReadXlBtn.Text = "READ EXCEL DATA";
            this.ReadXlBtn.UseVisualStyleBackColor = true;
            this.ReadXlBtn.Click += new System.EventHandler(this.ReadXlBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 339);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Button RetrieveButton;
        private Button ClearButton;
        private Button ViewDataBtn;
        private Button DownLoadImagesBtn;
        private Button SetCountBtn;
        private Button TestBtn;
        private Button AddBtn;
        private Button IdentifiedBtn;
        private Button FindInfoBtn;
        private Button AddInfoToDbBtn;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private GroupBox groupBox3;
        private Button ReadXlBtn;
        private ProgressBar Main_progress;
    }
}