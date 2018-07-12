namespace pgRoutingFCA
{
    partial class Form0b
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
            this.components = new System.ComponentModel.Container();
            this.lbFeedback = new System.Windows.Forms.Label();
            this.btTest = new System.Windows.Forms.Button();
            this.btGo = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbDatabase = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbHost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPwd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lbFeedback
            // 
            this.lbFeedback.AutoSize = true;
            this.lbFeedback.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFeedback.ForeColor = System.Drawing.Color.MistyRose;
            this.lbFeedback.Location = new System.Drawing.Point(33, 279);
            this.lbFeedback.Name = "lbFeedback";
            this.lbFeedback.Size = new System.Drawing.Size(114, 25);
            this.lbFeedback.TabIndex = 62;
            this.lbFeedback.Text = "lbFeedback";
            this.lbFeedback.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbFeedback.Visible = false;
            // 
            // btTest
            // 
            this.btTest.BackColor = System.Drawing.Color.DimGray;
            this.btTest.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTest.ForeColor = System.Drawing.SystemColors.Window;
            this.btTest.Location = new System.Drawing.Point(32, 240);
            this.btTest.Name = "btTest";
            this.btTest.Size = new System.Drawing.Size(441, 36);
            this.btTest.TabIndex = 61;
            this.btTest.Text = "test connection";
            this.btTest.UseVisualStyleBackColor = false;
            this.btTest.Click += new System.EventHandler(this.btTest_Click);
            // 
            // btGo
            // 
            this.btGo.BackColor = System.Drawing.Color.DimGray;
            this.btGo.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGo.ForeColor = System.Drawing.SystemColors.Window;
            this.btGo.Location = new System.Drawing.Point(32, 240);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(441, 36);
            this.btGo.TabIndex = 51;
            this.btGo.Text = "* CONTINUE *";
            this.btGo.UseVisualStyleBackColor = false;
            this.btGo.Visible = false;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(27, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 28);
            this.label4.TabIndex = 60;
            this.label4.Text = "Database:";
            // 
            // tbDatabase
            // 
            this.tbDatabase.BackColor = System.Drawing.Color.DimGray;
            this.tbDatabase.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbDatabase.ForeColor = System.Drawing.SystemColors.Window;
            this.tbDatabase.Location = new System.Drawing.Point(200, 186);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Size = new System.Drawing.Size(273, 35);
            this.tbDatabase.TabIndex = 56;
            this.tbDatabase.Text = "your_database";
            this.tbDatabase.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // tbPort
            // 
            this.tbPort.BackColor = System.Drawing.Color.DimGray;
            this.tbPort.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPort.ForeColor = System.Drawing.SystemColors.Window;
            this.tbPort.Location = new System.Drawing.Point(385, 132);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(88, 35);
            this.tbPort.TabIndex = 55;
            this.tbPort.Text = "5432";
            this.tbPort.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Window;
            this.label3.Location = new System.Drawing.Point(27, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 28);
            this.label3.TabIndex = 59;
            this.label3.Text = "Server/Port:";
            // 
            // tbHost
            // 
            this.tbHost.BackColor = System.Drawing.Color.DimGray;
            this.tbHost.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbHost.ForeColor = System.Drawing.SystemColors.Window;
            this.tbHost.Location = new System.Drawing.Point(200, 132);
            this.tbHost.Name = "tbHost";
            this.tbHost.Size = new System.Drawing.Size(179, 35);
            this.tbHost.TabIndex = 54;
            this.tbHost.Text = "localhost";
            this.tbHost.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(27, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 28);
            this.label2.TabIndex = 58;
            this.label2.Text = "Password:";
            // 
            // tbPwd
            // 
            this.tbPwd.BackColor = System.Drawing.Color.DimGray;
            this.tbPwd.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPwd.ForeColor = System.Drawing.SystemColors.Window;
            this.tbPwd.Location = new System.Drawing.Point(200, 82);
            this.tbPwd.Name = "tbPwd";
            this.tbPwd.PasswordChar = '~';
            this.tbPwd.Size = new System.Drawing.Size(273, 35);
            this.tbPwd.TabIndex = 53;
            this.tbPwd.Text = "????";
            this.tbPwd.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(27, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 28);
            this.label1.TabIndex = 57;
            this.label1.Text = "Username:";
            // 
            // tbUser
            // 
            this.tbUser.BackColor = System.Drawing.Color.DimGray;
            this.tbUser.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbUser.ForeColor = System.Drawing.SystemColors.Window;
            this.tbUser.Location = new System.Drawing.Point(200, 32);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(273, 35);
            this.tbUser.TabIndex = 52;
            this.tbUser.Text = "enter_username";
            this.tbUser.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(500, 389);
            this.Controls.Add(this.lbFeedback);
            this.Controls.Add(this.btTest);
            this.Controls.Add(this.btGo);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbDatabase);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbHost);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPwd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbUser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "pgUSW-FCA : : PostGIS database connection";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbFeedback;
        private System.Windows.Forms.Button btTest;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPwd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.TextBox tbDatabase;
    }
}

