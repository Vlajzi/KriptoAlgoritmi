namespace Klijent
{
    partial class MainForm
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_FileSelect = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lab_FileSelect = new System.Windows.Forms.Label();
            this.btn_Upload = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numb_XXTEA_1 = new System.Windows.Forms.NumericUpDown();
            this.numb_XXTEA_2 = new System.Windows.Forms.NumericUpDown();
            this.numb_XXTEA_3 = new System.Windows.Forms.NumericUpDown();
            this.numb_XXTEA_4 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_PCPInitial = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numb_XXTEA_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numb_XXTEA_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numb_XXTEA_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numb_XXTEA_4)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(495, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(293, 420);
            this.listBox1.TabIndex = 2;
            this.listBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBox1_MouseDoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btn_FileSelect
            // 
            this.btn_FileSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_FileSelect.Location = new System.Drawing.Point(13, 408);
            this.btn_FileSelect.Name = "btn_FileSelect";
            this.btn_FileSelect.Size = new System.Drawing.Size(106, 23);
            this.btn_FileSelect.TabIndex = 3;
            this.btn_FileSelect.Text = "Odaberi fajl";
            this.btn_FileSelect.UseVisualStyleBackColor = true;
            this.btn_FileSelect.Click += new System.EventHandler(this.btn_FileSelect_Click);
            // 
            // lab_FileSelect
            // 
            this.lab_FileSelect.AutoSize = true;
            this.lab_FileSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_FileSelect.Location = new System.Drawing.Point(12, 376);
            this.lab_FileSelect.Name = "lab_FileSelect";
            this.lab_FileSelect.Size = new System.Drawing.Size(16, 17);
            this.lab_FileSelect.TabIndex = 4;
            this.lab_FileSelect.Text = "\\\\";
            // 
            // btn_Upload
            // 
            this.btn_Upload.Location = new System.Drawing.Point(147, 408);
            this.btn_Upload.Name = "btn_Upload";
            this.btn_Upload.Size = new System.Drawing.Size(111, 23);
            this.btn_Upload.TabIndex = 5;
            this.btn_Upload.Text = "Upload";
            this.btn_Upload.UseVisualStyleBackColor = true;
            this.btn_Upload.Click += new System.EventHandler(this.btn_Upload_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "XXTEA",
            "PCPC - XXTEA",
            "Knapsak",
            "SimpleSub"});
            this.comboBox1.Location = new System.Drawing.Point(22, 40);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 293);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "KriptoAlgoritam";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Kjucevi:";
            // 
            // numb_XXTEA_1
            // 
            this.numb_XXTEA_1.Location = new System.Drawing.Point(18, 129);
            this.numb_XXTEA_1.Name = "numb_XXTEA_1";
            this.numb_XXTEA_1.Size = new System.Drawing.Size(74, 20);
            this.numb_XXTEA_1.TabIndex = 11;
            // 
            // numb_XXTEA_2
            // 
            this.numb_XXTEA_2.Location = new System.Drawing.Point(98, 129);
            this.numb_XXTEA_2.Name = "numb_XXTEA_2";
            this.numb_XXTEA_2.Size = new System.Drawing.Size(74, 20);
            this.numb_XXTEA_2.TabIndex = 12;
            // 
            // numb_XXTEA_3
            // 
            this.numb_XXTEA_3.Location = new System.Drawing.Point(178, 130);
            this.numb_XXTEA_3.Name = "numb_XXTEA_3";
            this.numb_XXTEA_3.Size = new System.Drawing.Size(74, 20);
            this.numb_XXTEA_3.TabIndex = 13;
            // 
            // numb_XXTEA_4
            // 
            this.numb_XXTEA_4.Location = new System.Drawing.Point(258, 130);
            this.numb_XXTEA_4.Name = "numb_XXTEA_4";
            this.numb_XXTEA_4.Size = new System.Drawing.Size(74, 20);
            this.numb_XXTEA_4.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "XXTEA key";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "PCBC Initial";
            // 
            // txt_PCPInitial
            // 
            this.txt_PCPInitial.Location = new System.Drawing.Point(22, 189);
            this.txt_PCPInitial.Name = "txt_PCPInitial";
            this.txt_PCPInitial.ReadOnly = true;
            this.txt_PCPInitial.Size = new System.Drawing.Size(310, 20);
            this.txt_PCPInitial.TabIndex = 18;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txt_PCPInitial);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numb_XXTEA_4);
            this.Controls.Add(this.numb_XXTEA_3);
            this.Controls.Add(this.numb_XXTEA_2);
            this.Controls.Add(this.numb_XXTEA_1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btn_Upload);
            this.Controls.Add(this.lab_FileSelect);
            this.Controls.Add(this.btn_FileSelect);
            this.Controls.Add(this.listBox1);
            this.Name = "MainForm";
            this.Text = "Klijent";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numb_XXTEA_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numb_XXTEA_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numb_XXTEA_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numb_XXTEA_4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btn_FileSelect;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lab_FileSelect;
        private System.Windows.Forms.Button btn_Upload;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numb_XXTEA_1;
        private System.Windows.Forms.NumericUpDown numb_XXTEA_2;
        private System.Windows.Forms.NumericUpDown numb_XXTEA_3;
        private System.Windows.Forms.NumericUpDown numb_XXTEA_4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_PCPInitial;
    }
}

