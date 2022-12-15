namespace ScraperTest_2
{
    partial class Form3
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
            this.ExcelGridView = new System.Windows.Forms.DataGridView();
            this.AddGridToDbBtn = new System.Windows.Forms.Button();
            this.IdStBtn = new System.Windows.Forms.Button();
            this.IdImgBtn = new System.Windows.Forms.Button();
            this.IdClasBtn = new System.Windows.Forms.Button();
            this.IdLimitsBtn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ExcelGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ExcelGridView
            // 
            this.ExcelGridView.AllowUserToAddRows = false;
            this.ExcelGridView.AllowUserToDeleteRows = false;
            this.ExcelGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ExcelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExcelGridView.Location = new System.Drawing.Point(12, 53);
            this.ExcelGridView.Name = "ExcelGridView";
            this.ExcelGridView.RowHeadersVisible = false;
            this.ExcelGridView.RowTemplate.Height = 25;
            this.ExcelGridView.Size = new System.Drawing.Size(1217, 576);
            this.ExcelGridView.TabIndex = 1;
            // 
            // AddGridToDbBtn
            // 
            this.AddGridToDbBtn.Location = new System.Drawing.Point(12, 24);
            this.AddGridToDbBtn.Name = "AddGridToDbBtn";
            this.AddGridToDbBtn.Size = new System.Drawing.Size(184, 23);
            this.AddGridToDbBtn.TabIndex = 2;
            this.AddGridToDbBtn.Text = "ADD TO TABLE";
            this.AddGridToDbBtn.UseVisualStyleBackColor = true;
            this.AddGridToDbBtn.Click += new System.EventHandler(this.AddGridToDbBtn_Click);
            // 
            // IdStBtn
            // 
            this.IdStBtn.Location = new System.Drawing.Point(202, 24);
            this.IdStBtn.Name = "IdStBtn";
            this.IdStBtn.Size = new System.Drawing.Size(178, 23);
            this.IdStBtn.TabIndex = 3;
            this.IdStBtn.Text = "BUILD ID-STATEMENT TABLE";
            this.IdStBtn.UseVisualStyleBackColor = true;
            this.IdStBtn.Click += new System.EventHandler(this.IdStBtn_Click);
            // 
            // IdImgBtn
            // 
            this.IdImgBtn.Location = new System.Drawing.Point(386, 24);
            this.IdImgBtn.Name = "IdImgBtn";
            this.IdImgBtn.Size = new System.Drawing.Size(178, 23);
            this.IdImgBtn.TabIndex = 4;
            this.IdImgBtn.Text = "BUILD ID-IMAGE TABLE";
            this.IdImgBtn.UseVisualStyleBackColor = true;
            this.IdImgBtn.Click += new System.EventHandler(this.IdImgBtn_Click);
            // 
            // IdClasBtn
            // 
            this.IdClasBtn.Location = new System.Drawing.Point(570, 24);
            this.IdClasBtn.Name = "IdClasBtn";
            this.IdClasBtn.Size = new System.Drawing.Size(178, 23);
            this.IdClasBtn.TabIndex = 5;
            this.IdClasBtn.Text = "BUILD ID-CLASS TABLE";
            this.IdClasBtn.UseVisualStyleBackColor = true;
            this.IdClasBtn.Click += new System.EventHandler(this.IdClasBtn_Click);
            // 
            // IdLimitsBtn
            // 
            this.IdLimitsBtn.Location = new System.Drawing.Point(754, 24);
            this.IdLimitsBtn.Name = "IdLimitsBtn";
            this.IdLimitsBtn.Size = new System.Drawing.Size(178, 23);
            this.IdLimitsBtn.TabIndex = 6;
            this.IdLimitsBtn.Text = "BUILD ID-LIMITS TABLE";
            this.IdLimitsBtn.UseVisualStyleBackColor = true;
            this.IdLimitsBtn.Click += new System.EventHandler(this.IdLimitsBtn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(938, 24);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "BUILD PHRASES TABLE";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 641);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.IdLimitsBtn);
            this.Controls.Add(this.IdClasBtn);
            this.Controls.Add(this.IdImgBtn);
            this.Controls.Add(this.IdStBtn);
            this.Controls.Add(this.AddGridToDbBtn);
            this.Controls.Add(this.ExcelGridView);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.ExcelGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView ExcelGridView;
        private Button AddGridToDbBtn;
        private Button IdStBtn;
        private Button IdImgBtn;
        private Button IdClasBtn;
        private Button IdLimitsBtn;
        private Button button1;
    }
}