namespace Employee_Directory.Forms
{
    partial class AccountForm
    {
        private System.ComponentModel.IContainer components = null;

        private DataGridView    dgvAccounts;
        private Label           lblUserId, lblPassword;
        private TextBox         txtUserId, txtPassword;
        private Button          btnAdd, btnDelete, btnClose;
        private Panel           pnlInput;
        private FlowLayoutPanel pnlButtons;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            dgvAccounts = new DataGridView();
            lblUserId = new Label();
            lblPassword = new Label();
            txtUserId = new TextBox();
            txtPassword = new TextBox();
            btnAdd = new Button();
            btnDelete = new Button();
            btnClose = new Button();
            pnlInput = new Panel();
            pnlButtons = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            pnlInput.SuspendLayout();
            pnlButtons.SuspendLayout();
            SuspendLayout();
            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvAccounts.Location = new Point(10, 10);
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.Size = new Size(462, 200);
            dgvAccounts.TabIndex = 0;
            // 
            // lblUserId
            // 
            lblUserId.Location = new Point(10, 12);
            lblUserId.Name = "lblUserId";
            lblUserId.Size = new Size(60, 23);
            lblUserId.TabIndex = 0;
            lblUserId.Text = "아이디";
            lblUserId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            lblPassword.Location = new Point(10, 44);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(60, 23);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "비밀번호";
            lblPassword.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtUserId
            // 
            txtUserId.Location = new Point(75, 10);
            txtUserId.Name = "txtUserId";
            txtUserId.Size = new Size(150, 23);
            txtUserId.TabIndex = 1;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(75, 42);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(150, 23);
            txtPassword.TabIndex = 3;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(370, 25);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(75, 28);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "추가";
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(372, 0);
            btnDelete.Margin = new Padding(6, 0, 0, 0);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(90, 28);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "선택 삭제";
            btnDelete.Click += btnDelete_Click;
            // 
            // btnClose
            // 
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.Location = new Point(288, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 28);
            btnClose.TabIndex = 1;
            btnClose.Text = "닫기";
            // 
            // pnlInput
            // 
            pnlInput.BorderStyle = BorderStyle.FixedSingle;
            pnlInput.Controls.Add(lblUserId);
            pnlInput.Controls.Add(txtUserId);
            pnlInput.Controls.Add(lblPassword);
            pnlInput.Controls.Add(txtPassword);
            pnlInput.Controls.Add(btnAdd);
            pnlInput.Location = new Point(10, 220);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new Size(462, 80);
            pnlInput.TabIndex = 1;
            // 
            // pnlButtons
            // 
            pnlButtons.Controls.Add(btnDelete);
            pnlButtons.Controls.Add(btnClose);
            pnlButtons.FlowDirection = FlowDirection.RightToLeft;
            pnlButtons.Location = new Point(10, 315);
            pnlButtons.Name = "pnlButtons";
            pnlButtons.Size = new Size(462, 40);
            pnlButtons.TabIndex = 2;
            // 
            // AccountForm
            // 
            CancelButton = btnClose;
            ClientSize = new Size(484, 361);
            Controls.Add(dgvAccounts);
            Controls.Add(pnlInput);
            Controls.Add(pnlButtons);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AccountForm";
            Padding = new Padding(10);
            StartPosition = FormStartPosition.CenterParent;
            Text = "계정 관리";
            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            pnlButtons.ResumeLayout(false);
            ResumeLayout(false);
        }
    }
}
