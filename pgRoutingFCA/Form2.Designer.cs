﻿namespace pgRoutingFCA
{
    partial class Form2
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSupID = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboSupVol = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSupTbl = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSupSchm = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboDemTbl = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cboDemSchm = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboFCAOut = new System.Windows.Forms.ComboBox();
            this.cboDemID = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cboDemVol = new System.Windows.Forms.ComboBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbNone = new System.Windows.Forms.RadioButton();
            this.nud_Size = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Size)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSupID);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cboSupVol);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboSupTbl);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboSupSchm);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(18, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(654, 170);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Supply Details";
            // 
            // cboSupID
            // 
            this.cboSupID.Enabled = false;
            this.cboSupID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupID.FormattingEnabled = true;
            this.cboSupID.Location = new System.Drawing.Point(382, 72);
            this.cboSupID.Name = "cboSupID";
            this.cboSupID.Size = new System.Drawing.Size(261, 33);
            this.cboSupID.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(283, 77);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(91, 28);
            this.label11.TabIndex = 21;
            this.label11.Text = "Id field:";
            // 
            // cboSupVol
            // 
            this.cboSupVol.Enabled = false;
            this.cboSupVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupVol.FormattingEnabled = true;
            this.cboSupVol.Location = new System.Drawing.Point(382, 114);
            this.cboSupVol.Name = "cboSupVol";
            this.cboSupVol.Size = new System.Drawing.Size(261, 33);
            this.cboSupVol.TabIndex = 19;
            this.cboSupVol.SelectedIndexChanged += new System.EventHandler(this.cboSupVol_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(241, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 28);
            this.label3.TabIndex = 18;
            this.label3.Text = "Volume field:";
            // 
            // cboSupTbl
            // 
            this.cboSupTbl.Enabled = false;
            this.cboSupTbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupTbl.FormattingEnabled = true;
            this.cboSupTbl.Location = new System.Drawing.Point(382, 29);
            this.cboSupTbl.Name = "cboSupTbl";
            this.cboSupTbl.Size = new System.Drawing.Size(261, 33);
            this.cboSupTbl.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(306, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 28);
            this.label2.TabIndex = 16;
            this.label2.Text = "Table:";
            // 
            // cboSupSchm
            // 
            this.cboSupSchm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSupSchm.FormattingEnabled = true;
            this.cboSupSchm.Location = new System.Drawing.Point(114, 29);
            this.cboSupSchm.Name = "cboSupSchm";
            this.cboSupSchm.Size = new System.Drawing.Size(164, 33);
            this.cboSupSchm.TabIndex = 15;
            this.cboSupSchm.SelectedIndexChanged += new System.EventHandler(this.cboSupSchm_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(17, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 28);
            this.label1.TabIndex = 14;
            this.label1.Text = "Schema:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(241, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 28);
            this.label4.TabIndex = 18;
            this.label4.Text = "Volume field:";
            // 
            // cboDemTbl
            // 
            this.cboDemTbl.Enabled = false;
            this.cboDemTbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDemTbl.FormattingEnabled = true;
            this.cboDemTbl.Location = new System.Drawing.Point(382, 31);
            this.cboDemTbl.Name = "cboDemTbl";
            this.cboDemTbl.Size = new System.Drawing.Size(261, 33);
            this.cboDemTbl.TabIndex = 17;
            this.cboDemTbl.SelectedIndexChanged += new System.EventHandler(this.cboDemTbl_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(306, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 28);
            this.label5.TabIndex = 16;
            this.label5.Text = "Table:";
            // 
            // cboDemSchm
            // 
            this.cboDemSchm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDemSchm.FormattingEnabled = true;
            this.cboDemSchm.Location = new System.Drawing.Point(114, 31);
            this.cboDemSchm.Name = "cboDemSchm";
            this.cboDemSchm.Size = new System.Drawing.Size(164, 33);
            this.cboDemSchm.TabIndex = 15;
            this.cboDemSchm.SelectedIndexChanged += new System.EventHandler(this.cboDemSchm_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(17, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 28);
            this.label6.TabIndex = 14;
            this.label6.Text = "Schema:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cboFCAOut);
            this.groupBox2.Controls.Add(this.cboDemID);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.cboDemVol);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboDemTbl);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboDemSchm);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(18, 200);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(654, 221);
            this.groupBox2.TabIndex = 30;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Demand Details";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(231, 162);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(143, 28);
            this.label10.TabIndex = 27;
            this.label10.Text = "Storage field:";
            // 
            // cboFCAOut
            // 
            this.cboFCAOut.Enabled = false;
            this.cboFCAOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFCAOut.FormattingEnabled = true;
            this.cboFCAOut.Location = new System.Drawing.Point(382, 161);
            this.cboFCAOut.Name = "cboFCAOut";
            this.cboFCAOut.Size = new System.Drawing.Size(261, 33);
            this.cboFCAOut.TabIndex = 26;
            // 
            // cboDemID
            // 
            this.cboDemID.Enabled = false;
            this.cboDemID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDemID.FormattingEnabled = true;
            this.cboDemID.Location = new System.Drawing.Point(382, 75);
            this.cboDemID.Name = "cboDemID";
            this.cboDemID.Size = new System.Drawing.Size(261, 33);
            this.cboDemID.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(283, 80);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 28);
            this.label12.TabIndex = 23;
            this.label12.Text = "Id field:";
            // 
            // cboDemVol
            // 
            this.cboDemVol.Enabled = false;
            this.cboDemVol.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDemVol.FormattingEnabled = true;
            this.cboDemVol.Location = new System.Drawing.Point(382, 118);
            this.cboDemVol.Name = "cboDemVol";
            this.cboDemVol.Size = new System.Drawing.Size(261, 33);
            this.cboDemVol.TabIndex = 19;
            this.cboDemVol.SelectedIndexChanged += new System.EventHandler(this.cboDemVol_SelectedIndexChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.Color.DimGray;
            this.btnExecute.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.ForeColor = System.Drawing.Color.White;
            this.btnExecute.Location = new System.Drawing.Point(568, 593);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(104, 38);
            this.btnExecute.TabIndex = 32;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.rbNone);
            this.groupBox3.Controls.Add(this.nud_Size);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(18, 439);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(654, 135);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Model Details";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(17, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(156, 28);
            this.label7.TabIndex = 26;
            this.label7.Text = "Distance decay:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton1.ForeColor = System.Drawing.Color.White;
            this.radioButton1.Location = new System.Drawing.Point(311, 94);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(91, 32);
            this.radioButton1.TabIndex = 24;
            this.radioButton1.Text = "Linear";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbNone
            // 
            this.rbNone.AutoSize = true;
            this.rbNone.Checked = true;
            this.rbNone.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNone.ForeColor = System.Drawing.Color.White;
            this.rbNone.Location = new System.Drawing.Point(217, 94);
            this.rbNone.Name = "rbNone";
            this.rbNone.Size = new System.Drawing.Size(81, 32);
            this.rbNone.TabIndex = 23;
            this.rbNone.TabStop = true;
            this.rbNone.Text = "None";
            this.rbNone.UseVisualStyleBackColor = true;
            // 
            // nud_Size
            // 
            this.nud_Size.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nud_Size.Increment = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nud_Size.Location = new System.Drawing.Point(217, 41);
            this.nud_Size.Maximum = new decimal(new int[] {
            50000,
            0,
            0,
            0});
            this.nud_Size.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nud_Size.Name = "nud_Size";
            this.nud_Size.Size = new System.Drawing.Size(122, 30);
            this.nud_Size.TabIndex = 22;
            this.nud_Size.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(345, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 28);
            this.label8.TabIndex = 16;
            this.label8.Text = "metres";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(17, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 28);
            this.label9.TabIndex = 14;
            this.label9.Text = "Catchment Size:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 603);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(0, 17);
            this.label13.TabIndex = 33;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(690, 655);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.label13);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_Size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboSupID;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboSupVol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSupTbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSupSchm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboDemTbl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboDemSchm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboFCAOut;
        private System.Windows.Forms.ComboBox cboDemID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboDemVol;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbNone;
        private System.Windows.Forms.NumericUpDown nud_Size;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
    }
}