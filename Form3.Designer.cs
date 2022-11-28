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
            ((System.ComponentModel.ISupportInitialize)(this.ExcelGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ExcelGridView
            // 
            this.ExcelGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ExcelGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExcelGridView.Location = new System.Drawing.Point(12, 53);
            this.ExcelGridView.Name = "ExcelGridView";
            this.ExcelGridView.ReadOnly = true;
            this.ExcelGridView.RowHeadersVisible = false;
            this.ExcelGridView.RowTemplate.Height = 25;
            this.ExcelGridView.Size = new System.Drawing.Size(1060, 576);
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
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 641);
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
    }
}