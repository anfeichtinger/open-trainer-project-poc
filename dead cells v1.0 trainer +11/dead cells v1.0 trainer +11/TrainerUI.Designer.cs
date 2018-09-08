namespace dead_cells_v1._0_trainer__11
{
    partial class TrainerUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrainerUI));
            this.procCheckerAsync = new System.ComponentModel.BackgroundWorker();
            this.exitBtn = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.upperDiv = new System.Windows.Forms.PictureBox();
            this.lowerDiv = new System.Windows.Forms.PictureBox();
            this.copyright = new System.Windows.Forms.Label();
            this.gameStatus = new System.Windows.Forms.Label();
            this.midDiv = new System.Windows.Forms.PictureBox();
            this.hotkey = new System.Windows.Forms.Label();
            this.function = new System.Windows.Forms.Label();
            this.hotkey1 = new System.Windows.Forms.Label();
            this.hotkey3 = new System.Windows.Forms.Label();
            this.hotkey2 = new System.Windows.Forms.Label();
            this.function1 = new System.Windows.Forms.Label();
            this.function2 = new System.Windows.Forms.Label();
            this.function3 = new System.Windows.Forms.Label();
            this.hotkey4 = new System.Windows.Forms.Label();
            this.hotkey8 = new System.Windows.Forms.Label();
            this.hotkey10 = new System.Windows.Forms.Label();
            this.hotkey9 = new System.Windows.Forms.Label();
            this.hotkey6 = new System.Windows.Forms.Label();
            this.hotkey5 = new System.Windows.Forms.Label();
            this.function4 = new System.Windows.Forms.Label();
            this.function5 = new System.Windows.Forms.Label();
            this.function6 = new System.Windows.Forms.Label();
            this.function8 = new System.Windows.Forms.Label();
            this.function9 = new System.Windows.Forms.Label();
            this.function10 = new System.Windows.Forms.Label();
            this.otpLink = new System.Windows.Forms.LinkLabel();
            this.hotkey11 = new System.Windows.Forms.Label();
            this.function11 = new System.Windows.Forms.Label();
            this.hotkey7 = new System.Windows.Forms.Label();
            this.function7 = new System.Windows.Forms.Label();
            this.fn1Value = new System.Windows.Forms.NumericUpDown();
            this.fn2Value = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.upperDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.midDiv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fn1Value)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fn2Value)).BeginInit();
            this.SuspendLayout();
            // 
            // procCheckerAsync
            // 
            this.procCheckerAsync.DoWork += new System.ComponentModel.DoWorkEventHandler(this.CheckForProc);
            // 
            // exitBtn
            // 
            this.exitBtn.BackColor = System.Drawing.Color.Red;
            this.exitBtn.ForeColor = System.Drawing.SystemColors.Control;
            this.exitBtn.Location = new System.Drawing.Point(455, 0);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(45, 20);
            this.exitBtn.TabIndex = 1;
            this.exitBtn.Text = "X";
            this.exitBtn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            this.exitBtn.MouseLeave += new System.EventHandler(this.exitBtn_MouseLeave);
            this.exitBtn.MouseHover += new System.EventHandler(this.exitBtn_MouseHover);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.ForeColor = System.Drawing.SystemColors.Control;
            this.title.Location = new System.Drawing.Point(13, 6);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(132, 13);
            this.title.TabIndex = 2;
            this.title.Text = "dead cells v1.0 trainer +11";
            // 
            // upperDiv
            // 
            this.upperDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.upperDiv.Location = new System.Drawing.Point(38, 25);
            this.upperDiv.Name = "upperDiv";
            this.upperDiv.Size = new System.Drawing.Size(425, 2);
            this.upperDiv.TabIndex = 3;
            this.upperDiv.TabStop = false;
            // 
            // lowerDiv
            // 
            this.lowerDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.lowerDiv.Location = new System.Drawing.Point(38, 520);
            this.lowerDiv.Name = "lowerDiv";
            this.lowerDiv.Size = new System.Drawing.Size(425, 2);
            this.lowerDiv.TabIndex = 4;
            this.lowerDiv.TabStop = false;
            // 
            // copyright
            // 
            this.copyright.ForeColor = System.Drawing.SystemColors.Control;
            this.copyright.Location = new System.Drawing.Point(0, 545);
            this.copyright.Name = "copyright";
            this.copyright.Size = new System.Drawing.Size(500, 30);
            this.copyright.TabIndex = 5;
            this.copyright.Text = "made by pharrax\r\n© 2018";
            this.copyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gameStatus
            // 
            this.gameStatus.ForeColor = System.Drawing.SystemColors.Control;
            this.gameStatus.Location = new System.Drawing.Point(0, 27);
            this.gameStatus.Name = "gameStatus";
            this.gameStatus.Size = new System.Drawing.Size(500, 25);
            this.gameStatus.TabIndex = 6;
            this.gameStatus.Text = "GAME NOT RUNNING";
            this.gameStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // midDiv
            // 
            this.midDiv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.midDiv.Location = new System.Drawing.Point(38, 52);
            this.midDiv.Name = "midDiv";
            this.midDiv.Size = new System.Drawing.Size(425, 2);
            this.midDiv.TabIndex = 7;
            this.midDiv.TabStop = false;
            // 
            // hotkey
            // 
            this.hotkey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey.Location = new System.Drawing.Point(0, 57);
            this.hotkey.Name = "hotkey";
            this.hotkey.Size = new System.Drawing.Size(200, 20);
            this.hotkey.TabIndex = 8;
            this.hotkey.Text = "hotkey";
            this.hotkey.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function
            // 
            this.function.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function.Location = new System.Drawing.Point(200, 57);
            this.function.Name = "function";
            this.function.Size = new System.Drawing.Size(200, 20);
            this.function.TabIndex = 9;
            this.function.Text = "function";
            this.function.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hotkey1
            // 
            this.hotkey1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey1.Location = new System.Drawing.Point(0, 86);
            this.hotkey1.Name = "hotkey1";
            this.hotkey1.Size = new System.Drawing.Size(200, 20);
            this.hotkey1.TabIndex = 12;
            this.hotkey1.Text = "f1";
            this.hotkey1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hotkey3
            // 
            this.hotkey3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey3.Location = new System.Drawing.Point(0, 166);
            this.hotkey3.Name = "hotkey3";
            this.hotkey3.Size = new System.Drawing.Size(200, 20);
            this.hotkey3.TabIndex = 14;
            this.hotkey3.Text = "f3";
            this.hotkey3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hotkey2
            // 
            this.hotkey2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey2.Location = new System.Drawing.Point(0, 126);
            this.hotkey2.Name = "hotkey2";
            this.hotkey2.Size = new System.Drawing.Size(200, 20);
            this.hotkey2.TabIndex = 13;
            this.hotkey2.Text = "f2";
            this.hotkey2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function1
            // 
            this.function1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function1.Location = new System.Drawing.Point(200, 86);
            this.function1.Name = "function1";
            this.function1.Size = new System.Drawing.Size(200, 20);
            this.function1.TabIndex = 15;
            this.function1.Text = "set money to:";
            this.function1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function2
            // 
            this.function2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function2.Location = new System.Drawing.Point(200, 126);
            this.function2.Name = "function2";
            this.function2.Size = new System.Drawing.Size(200, 20);
            this.function2.TabIndex = 16;
            this.function2.Text = "set cells to:";
            this.function2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function3
            // 
            this.function3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function3.Location = new System.Drawing.Point(200, 166);
            this.function3.Name = "function3";
            this.function3.Size = new System.Drawing.Size(200, 20);
            this.function3.TabIndex = 17;
            this.function3.Text = "unlimited health";
            this.function3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hotkey4
            // 
            this.hotkey4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey4.Location = new System.Drawing.Point(0, 206);
            this.hotkey4.Name = "hotkey4";
            this.hotkey4.Size = new System.Drawing.Size(200, 20);
            this.hotkey4.TabIndex = 18;
            this.hotkey4.Text = "f4";
            this.hotkey4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hotkey8
            // 
            this.hotkey8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey8.Location = new System.Drawing.Point(0, 366);
            this.hotkey8.Name = "hotkey8";
            this.hotkey8.Size = new System.Drawing.Size(200, 20);
            this.hotkey8.TabIndex = 19;
            this.hotkey8.Text = "f8";
            this.hotkey8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hotkey10
            // 
            this.hotkey10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey10.Location = new System.Drawing.Point(0, 446);
            this.hotkey10.Name = "hotkey10";
            this.hotkey10.Size = new System.Drawing.Size(200, 20);
            this.hotkey10.TabIndex = 21;
            this.hotkey10.Text = "f10";
            this.hotkey10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hotkey9
            // 
            this.hotkey9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey9.Location = new System.Drawing.Point(0, 406);
            this.hotkey9.Name = "hotkey9";
            this.hotkey9.Size = new System.Drawing.Size(200, 20);
            this.hotkey9.TabIndex = 22;
            this.hotkey9.Text = "f9";
            this.hotkey9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hotkey6
            // 
            this.hotkey6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey6.Location = new System.Drawing.Point(0, 286);
            this.hotkey6.Name = "hotkey6";
            this.hotkey6.Size = new System.Drawing.Size(200, 20);
            this.hotkey6.TabIndex = 23;
            this.hotkey6.Text = "f6";
            this.hotkey6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hotkey5
            // 
            this.hotkey5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey5.Location = new System.Drawing.Point(0, 246);
            this.hotkey5.Name = "hotkey5";
            this.hotkey5.Size = new System.Drawing.Size(200, 20);
            this.hotkey5.TabIndex = 24;
            this.hotkey5.Text = "f5";
            this.hotkey5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function4
            // 
            this.function4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function4.Location = new System.Drawing.Point(200, 206);
            this.function4.Name = "function4";
            this.function4.Size = new System.Drawing.Size(200, 20);
            this.function4.TabIndex = 25;
            this.function4.Text = "freeze money";
            this.function4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function5
            // 
            this.function5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function5.Location = new System.Drawing.Point(200, 246);
            this.function5.Name = "function5";
            this.function5.Size = new System.Drawing.Size(200, 20);
            this.function5.TabIndex = 26;
            this.function5.Text = "freeze cells";
            this.function5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function6
            // 
            this.function6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function6.Location = new System.Drawing.Point(200, 286);
            this.function6.Name = "function6";
            this.function6.Size = new System.Drawing.Size(200, 20);
            this.function6.TabIndex = 27;
            this.function6.Text = "freeze timer";
            this.function6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function8
            // 
            this.function8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function8.Location = new System.Drawing.Point(200, 366);
            this.function8.Name = "function8";
            this.function8.Size = new System.Drawing.Size(200, 20);
            this.function8.TabIndex = 28;
            this.function8.Text = "infinite jumps";
            this.function8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function9
            // 
            this.function9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function9.Location = new System.Drawing.Point(200, 406);
            this.function9.Name = "function9";
            this.function9.Size = new System.Drawing.Size(200, 20);
            this.function9.TabIndex = 29;
            this.function9.Text = "infinite ammo";
            this.function9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function10
            // 
            this.function10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function10.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function10.Location = new System.Drawing.Point(200, 446);
            this.function10.Name = "function10";
            this.function10.Size = new System.Drawing.Size(200, 20);
            this.function10.TabIndex = 30;
            this.function10.Text = "no cooldown";
            this.function10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // otpLink
            // 
            this.otpLink.LinkColor = System.Drawing.Color.White;
            this.otpLink.Location = new System.Drawing.Point(0, 530);
            this.otpLink.Name = "otpLink";
            this.otpLink.Size = new System.Drawing.Size(500, 13);
            this.otpLink.TabIndex = 31;
            this.otpLink.TabStop = true;
            this.otpLink.Text = "OpenTrainerProject";
            this.otpLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.otpLink.Click += new System.EventHandler(this.otpLink_Click);
            // 
            // hotkey11
            // 
            this.hotkey11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey11.Location = new System.Drawing.Point(0, 486);
            this.hotkey11.Name = "hotkey11";
            this.hotkey11.Size = new System.Drawing.Size(200, 20);
            this.hotkey11.TabIndex = 32;
            this.hotkey11.Text = "f11";
            this.hotkey11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function11
            // 
            this.function11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function11.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function11.Location = new System.Drawing.Point(200, 486);
            this.function11.Name = "function11";
            this.function11.Size = new System.Drawing.Size(200, 20);
            this.function11.TabIndex = 33;
            this.function11.Text = "run faster";
            this.function11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hotkey7
            // 
            this.hotkey7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hotkey7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.hotkey7.Location = new System.Drawing.Point(0, 326);
            this.hotkey7.Name = "hotkey7";
            this.hotkey7.Size = new System.Drawing.Size(200, 20);
            this.hotkey7.TabIndex = 34;
            this.hotkey7.Text = "f7";
            this.hotkey7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // function7
            // 
            this.function7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.function7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.function7.Location = new System.Drawing.Point(200, 326);
            this.function7.Name = "function7";
            this.function7.Size = new System.Drawing.Size(200, 20);
            this.function7.TabIndex = 35;
            this.function7.Text = "invisibility";
            this.function7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fn1Value
            // 
            this.fn1Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.fn1Value.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fn1Value.Location = new System.Drawing.Point(406, 86);
            this.fn1Value.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.fn1Value.Name = "fn1Value";
            this.fn1Value.Size = new System.Drawing.Size(60, 20);
            this.fn1Value.TabIndex = 38;
            this.fn1Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fn1Value.Value = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            // 
            // fn2Value
            // 
            this.fn2Value.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.fn2Value.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.fn2Value.Location = new System.Drawing.Point(406, 126);
            this.fn2Value.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.fn2Value.Name = "fn2Value";
            this.fn2Value.Size = new System.Drawing.Size(60, 20);
            this.fn2Value.TabIndex = 39;
            this.fn2Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fn2Value.Value = new decimal(new int[] {
            999,
            0,
            0,
            0});
            // 
            // TrainerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(36)))), ((int)(((byte)(36)))));
            this.ClientSize = new System.Drawing.Size(500, 580);
            this.Controls.Add(this.fn2Value);
            this.Controls.Add(this.fn1Value);
            this.Controls.Add(this.function7);
            this.Controls.Add(this.hotkey7);
            this.Controls.Add(this.function11);
            this.Controls.Add(this.hotkey11);
            this.Controls.Add(this.otpLink);
            this.Controls.Add(this.function10);
            this.Controls.Add(this.function9);
            this.Controls.Add(this.function8);
            this.Controls.Add(this.function6);
            this.Controls.Add(this.function5);
            this.Controls.Add(this.function4);
            this.Controls.Add(this.hotkey5);
            this.Controls.Add(this.hotkey6);
            this.Controls.Add(this.hotkey9);
            this.Controls.Add(this.hotkey10);
            this.Controls.Add(this.hotkey8);
            this.Controls.Add(this.hotkey4);
            this.Controls.Add(this.function3);
            this.Controls.Add(this.function2);
            this.Controls.Add(this.function1);
            this.Controls.Add(this.hotkey3);
            this.Controls.Add(this.hotkey2);
            this.Controls.Add(this.hotkey1);
            this.Controls.Add(this.function);
            this.Controls.Add(this.hotkey);
            this.Controls.Add(this.midDiv);
            this.Controls.Add(this.gameStatus);
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.lowerDiv);
            this.Controls.Add(this.upperDiv);
            this.Controls.Add(this.title);
            this.Controls.Add(this.exitBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrainerUI";
            this.Text = "dead cells v1.0 trainer +11";
            this.Load += new System.EventHandler(this.TrainerUI_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TrainerUI_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.upperDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lowerDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.midDiv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fn1Value)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fn2Value)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker procCheckerAsync;
        private System.Windows.Forms.Label exitBtn;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.PictureBox upperDiv;
        private System.Windows.Forms.PictureBox lowerDiv;
        private System.Windows.Forms.Label copyright;
        private System.Windows.Forms.Label gameStatus;
        private System.Windows.Forms.PictureBox midDiv;
        private System.Windows.Forms.Label hotkey;
        private System.Windows.Forms.Label function;
        private System.Windows.Forms.Label hotkey1;
        private System.Windows.Forms.Label hotkey3;
        private System.Windows.Forms.Label hotkey2;
        private System.Windows.Forms.Label function1;
        private System.Windows.Forms.Label function2;
        private System.Windows.Forms.Label function3;
        private System.Windows.Forms.Label hotkey4;
        private System.Windows.Forms.Label hotkey8;
        private System.Windows.Forms.Label hotkey10;
        private System.Windows.Forms.Label hotkey9;
        private System.Windows.Forms.Label hotkey6;
        private System.Windows.Forms.Label hotkey5;
        private System.Windows.Forms.Label function4;
        private System.Windows.Forms.Label function5;
        private System.Windows.Forms.Label function6;
        private System.Windows.Forms.Label function8;
        private System.Windows.Forms.Label function9;
        private System.Windows.Forms.Label function10;
        private System.Windows.Forms.LinkLabel otpLink;
        private System.Windows.Forms.Label hotkey11;
        private System.Windows.Forms.Label function11;
        private System.Windows.Forms.Label hotkey7;
        private System.Windows.Forms.Label function7;
        private System.Windows.Forms.NumericUpDown fn1Value;
        private System.Windows.Forms.NumericUpDown fn2Value;
    }
}

