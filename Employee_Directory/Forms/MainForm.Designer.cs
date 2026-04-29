namespace Employee_Directory.Forms
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            pnlTop = new Panel();
            lblTitle = new Label();
            lblUserInfo = new Label();
            btnMyInfo = new Button();
            btnLogout = new Button();
            pnlSearch = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            dgvEmployees = new DataGridView();
            pnlBottom = new Panel();
            btnAdd     = new Button();
            btnDelete  = new Button();
            btnAccount = new Button();
            SearchComboBox = new ComboBox();
            pnlTop.SuspendLayout();
            pnlSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
            pnlBottom.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = Color.FromArgb(38, 74, 124);
            pnlTop.Controls.Add(lblTitle);
            pnlTop.Controls.Add(lblUserInfo);
            pnlTop.Controls.Add(btnMyInfo);
            pnlTop.Controls.Add(btnLogout);
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Name = "pnlTop";
            pnlTop.Size = new Size(900, 55);
            pnlTop.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("맑은 고딕", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 13);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(133, 25);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "직원 디렉토리";
            // 
            // lblUserInfo
            // 
            lblUserInfo.AutoSize = true;
            lblUserInfo.Font = new Font("맑은 고딕", 9F);
            lblUserInfo.ForeColor = Color.LightGray;
            lblUserInfo.Location = new Point(200, 20);
            lblUserInfo.Name = "lblUserInfo";
            lblUserInfo.Size = new Size(0, 15);
            lblUserInfo.TabIndex = 1;
            // 
            // btnMyInfo
            //
            btnMyInfo.ForeColor = SystemColors.ControlLightLight;
            btnMyInfo.Location = new Point(688, 11);
            btnMyInfo.Name = "btnMyInfo";
            btnMyInfo.Size = new Size(85, 33);
            btnMyInfo.TabIndex = 3;
            btnMyInfo.Text = "PW 변경";
            btnMyInfo.Click += btnMyInfo_Click;
            //
            // btnLogout
            //
            btnLogout.ForeColor = SystemColors.ControlLightLight;
            btnLogout.Location = new Point(785, 11);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(97, 33);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "로그아웃";
            btnLogout.Click += btnLogout_Click;
            // 
            // pnlSearch
            // 
            pnlSearch.BackColor = Color.WhiteSmoke;
            pnlSearch.Controls.Add(SearchComboBox);
            pnlSearch.Controls.Add(lblSearch);
            pnlSearch.Controls.Add(txtSearch);
            pnlSearch.Controls.Add(btnSearch);
            pnlSearch.Dock = DockStyle.Top;
            pnlSearch.Location = new Point(0, 55);
            pnlSearch.Name = "pnlSearch";
            pnlSearch.Size = new Size(900, 45);
            pnlSearch.TabIndex = 1;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(15, 14);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(31, 15);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "검색";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(226, 9);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(250, 23);
            txtSearch.TabIndex = 1;
            txtSearch.KeyDown += txtSearch_KeyDown;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(486, 8);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(60, 25);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "검색";
            btnSearch.Click += btnSearch_Click;
            // 
            // dgvEmployees
            // 
            dgvEmployees.AllowUserToAddRows = false;
            dgvEmployees.AllowUserToDeleteRows = false;
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = Color.White;
            dgvEmployees.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployees.Dock = DockStyle.Fill;
            dgvEmployees.Location = new Point(0, 100);
            dgvEmployees.MultiSelect = false;
            dgvEmployees.Name = "dgvEmployees";
            dgvEmployees.ReadOnly = true;
            dgvEmployees.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployees.Size = new Size(900, 450);
            dgvEmployees.TabIndex = 0;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = Color.WhiteSmoke;
            pnlBottom.Controls.Add(btnAdd);
            pnlBottom.Controls.Add(btnDelete);
            pnlBottom.Controls.Add(btnAccount);
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 550);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Size = new Size(900, 50);
            pnlBottom.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(15, 10);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 30);
            btnAdd.TabIndex = 0;
            btnAdd.Text = "추가";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(105, 10);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 30);
            btnDelete.TabIndex = 1;
            btnDelete.Text = "삭제";
            btnDelete.Click += btnDelete_Click;
            //
            // btnAccount
            //
            btnAccount.Location = new Point(195, 10);
            btnAccount.Name = "btnAccount";
            btnAccount.Size = new Size(90, 30);
            btnAccount.TabIndex = 2;
            btnAccount.Text = "계정 관리";
            btnAccount.Click += btnAccount_Click;
            // 
            // SearchComboBox
            // 
            SearchComboBox.FormattingEnabled = true;
            SearchComboBox.Location = new Point(78, 9);
            SearchComboBox.Name = "SearchComboBox";
            SearchComboBox.Size = new Size(133, 23);
            SearchComboBox.TabIndex = 3;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 600);
            StartPosition = FormStartPosition.CenterScreen;
            Controls.Add(dgvEmployees);
            Controls.Add(pnlSearch);
            Controls.Add(pnlTop);
            Controls.Add(pnlBottom);
            Name = "MainForm";
            Text = "직원 디렉토리";
            Load += MainForm_Load;
            pnlTop.ResumeLayout(false);
            pnlTop.PerformLayout();
            pnlSearch.ResumeLayout(false);
            pnlSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
            pnlBottom.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTop;
        private Label lblTitle;
        private Label lblUserInfo;
        private Button btnLogout;
        private Button btnMyInfo;
        private Panel pnlSearch;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private DataGridView dgvEmployees;
        private Panel pnlBottom;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnAccount;
        private ComboBox SearchComboBox;
    }
}