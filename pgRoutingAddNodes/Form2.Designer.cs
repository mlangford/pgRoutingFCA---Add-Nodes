namespace pgRoutingFCA
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
            this.lb1 = new System.Windows.Forms.Label();
            this.lb2 = new System.Windows.Forms.Label();
            this.btnExecute = new System.Windows.Forms.Button();
            this.pb1 = new System.Windows.Forms.PictureBox();
            this.pb2 = new System.Windows.Forms.PictureBox();
            this.pb3 = new System.Windows.Forms.PictureBox();
            this.lb3 = new System.Windows.Forms.Label();
            this.pb4 = new System.Windows.Forms.PictureBox();
            this.lb4 = new System.Windows.Forms.Label();
            this.btnQuit = new System.Windows.Forms.Button();
            this.chkRun = new System.Windows.Forms.CheckBox();
            this.chkShow = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).BeginInit();
            this.SuspendLayout();
            // 
            // lb1
            // 
            this.lb1.AutoSize = true;
            this.lb1.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.ForeColor = System.Drawing.Color.DimGray;
            this.lb1.Location = new System.Drawing.Point(36, 43);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(405, 33);
            this.lb1.TabIndex = 64;
            this.lb1.Text = "Preparing tables for node insertion";
            // 
            // lb2
            // 
            this.lb2.AutoSize = true;
            this.lb2.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb2.ForeColor = System.Drawing.Color.DimGray;
            this.lb2.Location = new System.Drawing.Point(36, 118);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(449, 33);
            this.lb2.TabIndex = 67;
            this.lb2.Text = "Computing snap locations and distances";
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.Color.DimGray;
            this.btnExecute.Enabled = false;
            this.btnExecute.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExecute.ForeColor = System.Drawing.Color.White;
            this.btnExecute.Location = new System.Drawing.Point(553, 378);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(116, 38);
            this.btnExecute.TabIndex = 68;
            this.btnExecute.Text = "Wait...";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // pb1
            // 
            this.pb1.Image = global::pgRoutingFCA.Properties.Resources.tick;
            this.pb1.Location = new System.Drawing.Point(637, 43);
            this.pb1.Name = "pb1";
            this.pb1.Size = new System.Drawing.Size(32, 32);
            this.pb1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb1.TabIndex = 69;
            this.pb1.TabStop = false;
            this.pb1.Visible = false;
            // 
            // pb2
            // 
            this.pb2.Image = global::pgRoutingFCA.Properties.Resources.tick;
            this.pb2.Location = new System.Drawing.Point(637, 118);
            this.pb2.Name = "pb2";
            this.pb2.Size = new System.Drawing.Size(32, 32);
            this.pb2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb2.TabIndex = 70;
            this.pb2.TabStop = false;
            this.pb2.Visible = false;
            // 
            // pb3
            // 
            this.pb3.Image = global::pgRoutingFCA.Properties.Resources.tick;
            this.pb3.Location = new System.Drawing.Point(637, 193);
            this.pb3.Name = "pb3";
            this.pb3.Size = new System.Drawing.Size(32, 32);
            this.pb3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb3.TabIndex = 72;
            this.pb3.TabStop = false;
            this.pb3.Visible = false;
            // 
            // lb3
            // 
            this.lb3.AutoSize = true;
            this.lb3.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb3.ForeColor = System.Drawing.Color.DimGray;
            this.lb3.Location = new System.Drawing.Point(36, 193);
            this.lb3.Name = "lb3";
            this.lb3.Size = new System.Drawing.Size(449, 33);
            this.lb3.TabIndex = 71;
            this.lb3.Text = "Creating blades and splitting road links";
            // 
            // pb4
            // 
            this.pb4.Image = global::pgRoutingFCA.Properties.Resources.tick;
            this.pb4.Location = new System.Drawing.Point(637, 267);
            this.pb4.Name = "pb4";
            this.pb4.Size = new System.Drawing.Size(32, 32);
            this.pb4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb4.TabIndex = 74;
            this.pb4.TabStop = false;
            this.pb4.Visible = false;
            // 
            // lb4
            // 
            this.lb4.AutoSize = true;
            this.lb4.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb4.ForeColor = System.Drawing.Color.DimGray;
            this.lb4.Location = new System.Drawing.Point(36, 267);
            this.lb4.Name = "lb4";
            this.lb4.Size = new System.Drawing.Size(454, 33);
            this.lb4.TabIndex = 73;
            this.lb4.Text = "Swapping in split links to network table";
            // 
            // btnQuit
            // 
            this.btnQuit.BackColor = System.Drawing.Color.DimGray;
            this.btnQuit.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQuit.ForeColor = System.Drawing.Color.White;
            this.btnQuit.Location = new System.Drawing.Point(415, 378);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(116, 38);
            this.btnQuit.TabIndex = 75;
            this.btnQuit.Text = "Quit";
            this.btnQuit.UseVisualStyleBackColor = false;
            this.btnQuit.Visible = false;
            this.btnQuit.Click += new System.EventHandler(this.btnQuit_Click);
            // 
            // chkRun
            // 
            this.chkRun.AutoSize = true;
            this.chkRun.Checked = true;
            this.chkRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRun.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRun.ForeColor = System.Drawing.Color.DimGray;
            this.chkRun.Location = new System.Drawing.Point(42, 354);
            this.chkRun.Name = "chkRun";
            this.chkRun.Size = new System.Drawing.Size(195, 28);
            this.chkRun.TabIndex = 80;
            this.chkRun.Text = "Execute SQL Script";
            this.chkRun.UseVisualStyleBackColor = true;
            // 
            // chkShow
            // 
            this.chkShow.AutoSize = true;
            this.chkShow.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShow.ForeColor = System.Drawing.Color.DimGray;
            this.chkShow.Location = new System.Drawing.Point(42, 388);
            this.chkShow.Name = "chkShow";
            this.chkShow.Size = new System.Drawing.Size(184, 28);
            this.chkShow.TabIndex = 79;
            this.chkShow.Text = "Display SQL Script";
            this.chkShow.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(723, 467);
            this.ControlBox = false;
            this.Controls.Add(this.chkRun);
            this.Controls.Add(this.chkShow);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.pb4);
            this.Controls.Add(this.lb4);
            this.Controls.Add(this.pb3);
            this.Controls.Add(this.lb3);
            this.Controls.Add(this.pb2);
            this.Controls.Add(this.pb1);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.lb2);
            this.Controls.Add(this.lb1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "pgUSWFCA : : Add Nodes to Network Tool";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lb1;
        private System.Windows.Forms.Label lb2;
        private System.Windows.Forms.Button btnExecute;
        private System.Windows.Forms.PictureBox pb1;
        private System.Windows.Forms.PictureBox pb2;
        private System.Windows.Forms.PictureBox pb3;
        private System.Windows.Forms.Label lb3;
        private System.Windows.Forms.PictureBox pb4;
        private System.Windows.Forms.Label lb4;
        private System.Windows.Forms.Button btnQuit;
        private System.Windows.Forms.CheckBox chkRun;
        private System.Windows.Forms.CheckBox chkShow;
    }
}