namespace Employee_Directory.Forms
{
    partial class LoginForm
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
            login_button = new Button();
            splitter1 = new Splitter();
            PWtextbox = new TextBox();
            IDtextbox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            Pnllow = new Panel();
            PnllowLogo = new Panel();
            PnlBackground = new Panel();
            Pnllow.SuspendLayout();
            SuspendLayout();
            // 
            // login_button
            // 
            login_button.Font = new Font("맑은 고딕", 12F);
            login_button.Location = new Point(678, 44);
            login_button.Name = "login_button";
            login_button.Size = new Size(123, 53);
            login_button.TabIndex = 0;
            login_button.Text = "로그인";
            login_button.UseVisualStyleBackColor = true;
            login_button.Click += login_button_Click;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 600);
            splitter1.TabIndex = 2;
            splitter1.TabStop = false;
            // 
            // PWtextbox
            // 
            PWtextbox.Location = new Point(384, 74);
            PWtextbox.Name = "PWtextbox";
            PWtextbox.PasswordChar = '*';
            PWtextbox.Size = new Size(221, 23);
            PWtextbox.TabIndex = 3;
            PWtextbox.TextChanged += PWtextbox_TextChanged;
            // 
            // IDtextbox
            // 
            IDtextbox.Location = new Point(384, 44);
            IDtextbox.Name = "IDtextbox";
            IDtextbox.Size = new Size(221, 23);
            IDtextbox.TabIndex = 4;
            IDtextbox.TextChanged += IDtextbox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("맑은 고딕", 12F);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(344, 47);
            label2.Name = "label2";
            label2.Size = new Size(25, 21);
            label2.TabIndex = 5;
            label2.Text = "ID";
            label2.UseWaitCursor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("맑은 고딕", 12F);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(344, 76);
            label3.Name = "label3";
            label3.Size = new Size(34, 21);
            label3.TabIndex = 6;
            label3.Text = "PW";
            // 
            // Pnllow
            // 
            Pnllow.BackColor = Color.FromArgb(38, 74, 124);
            Pnllow.Controls.Add(IDtextbox);
            Pnllow.Controls.Add(label3);
            Pnllow.Controls.Add(login_button);
            Pnllow.Controls.Add(label2);
            Pnllow.Controls.Add(PWtextbox);
            Pnllow.Location = new Point(0, 457);
            Pnllow.Name = "Pnllow";
            Pnllow.Size = new Size(900, 143);
            Pnllow.TabIndex = 7;
            // 
            // PnllowLogo
            // 
            PnllowLogo.BackColor = Color.FromArgb(38, 74, 124);
            PnllowLogo.BackgroundImage = Properties.Resources.Marineelectronics_marineworks_white;
            PnllowLogo.BackgroundImageLayout = ImageLayout.Zoom;
            PnllowLogo.Location = new Point(0, 457);
            PnllowLogo.Name = "PnllowLogo";
            PnllowLogo.Size = new Size(299, 143);
            PnllowLogo.TabIndex = 8;
            // 
            // PnlBackground
            // 
            PnlBackground.BackgroundImage = Properties.Resources.login_back_logo;
            PnlBackground.BackgroundImageLayout = ImageLayout.Zoom;
            PnlBackground.Location = new Point(0, 0);
            PnlBackground.Name = "PnlBackground";
            PnlBackground.Size = new Size(900, 511);
            PnlBackground.TabIndex = 9;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(900, 600);
            Controls.Add(PnllowLogo);
            Controls.Add(Pnllow);
            Controls.Add(PnlBackground);
            Controls.Add(splitter1);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Load += Form1_Load;
            Pnllow.ResumeLayout(false);
            Pnllow.PerformLayout();
            ResumeLayout(false);
        }

        #endregion


        private Button login_button;
        private Splitter splitter1;
        private TextBox PWtextbox;
        private TextBox IDtextbox;
        private Label label2;
        private Label label3;
        private Panel Pnllow;
        private Panel PnllowLogo;
        private Panel PnlBackground;
    }
}
