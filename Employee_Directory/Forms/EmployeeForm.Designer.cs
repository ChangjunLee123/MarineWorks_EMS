namespace Employee_Directory.Forms
{
    partial class EmployeeForm
    {
        private System.ComponentModel.IContainer components = null;

        private Panel        pnlPhoto;
        private PictureBox   picPhoto;
        private Button       btnChangePhoto;
        private TableLayoutPanel tableLayout;
        private Label   lblDepartment, lblTeam, lblPart, lblPosition, lblName, lblExtension, lblPhone, lblEmail;
        private TextBox txtDepartment, txtTeam, txtPart, txtPosition, txtName, txtExtension, txtPhone, txtEmail;
        private FlowLayoutPanel pnlButtons;
        private Button btnSave, btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlPhoto       = new Panel();
            picPhoto       = new PictureBox();
            btnChangePhoto = new Button();
            tableLayout    = new TableLayoutPanel();
            pnlButtons     = new FlowLayoutPanel();
            lblDepartment  = new Label();
            lblTeam        = new Label();
            lblPart        = new Label();
            lblPosition    = new Label();
            lblName        = new Label();
            lblExtension   = new Label();
            lblPhone       = new Label();
            lblEmail       = new Label();
            txtDepartment  = new TextBox();
            txtTeam        = new TextBox();
            txtPart        = new TextBox();
            txtPosition    = new TextBox();
            txtName        = new TextBox();
            txtExtension   = new TextBox();
            txtPhone       = new TextBox();
            txtEmail       = new TextBox();
            btnSave        = new Button();
            btnCancel      = new Button();

            // ── Form ─────────────────────────────────────────────
            Text            = "직원 정보";
            Size            = new Size(560, 430);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            StartPosition   = FormStartPosition.CenterParent;
            Padding         = new Padding(10);

            // ── PictureBox ────────────────────────────────────────
            picPhoto.Size        = new Size(120, 150);
            picPhoto.Location    = new Point(15, 15);
            picPhoto.BorderStyle = BorderStyle.FixedSingle;
            picPhoto.SizeMode    = PictureBoxSizeMode.Zoom;
            picPhoto.Cursor      = Cursors.Hand;
            picPhoto.Click      += btnChangePhoto_Click;

            // ── 사진 변경 버튼 ─────────────────────────────────────
            btnChangePhoto.Text     = "사진 변경";
            btnChangePhoto.Size     = new Size(120, 28);
            btnChangePhoto.Location = new Point(15, 172);
            btnChangePhoto.Click   += btnChangePhoto_Click;

            // ── 사진 패널 ─────────────────────────────────────────
            pnlPhoto.Dock  = DockStyle.Left;
            pnlPhoto.Width = 150;
            pnlPhoto.Controls.Add(picPhoto);
            pnlPhoto.Controls.Add(btnChangePhoto);

            // ── Labels ────────────────────────────────────────────
            lblDepartment.Text      = "부서";
            lblDepartment.Anchor    = AnchorStyles.Left | AnchorStyles.Right;
            lblDepartment.TextAlign = ContentAlignment.MiddleLeft;

            lblTeam.Text      = "팀/사업소";
            lblTeam.Anchor    = AnchorStyles.Left | AnchorStyles.Right;
            lblTeam.TextAlign = ContentAlignment.MiddleLeft;

            lblPart.Text      = "파트";
            lblPart.Anchor    = AnchorStyles.Left | AnchorStyles.Right;
            lblPart.TextAlign = ContentAlignment.MiddleLeft;

            lblPosition.Text      = "직위/직책";
            lblPosition.Anchor    = AnchorStyles.Left | AnchorStyles.Right;
            lblPosition.TextAlign = ContentAlignment.MiddleLeft;

            lblName.Text      = "이름";
            lblName.Anchor    = AnchorStyles.Left | AnchorStyles.Right;
            lblName.TextAlign = ContentAlignment.MiddleLeft;

            lblExtension.Text      = "내선번호";
            lblExtension.Anchor    = AnchorStyles.Left | AnchorStyles.Right;
            lblExtension.TextAlign = ContentAlignment.MiddleLeft;

            lblPhone.Text      = "휴대번호";
            lblPhone.Anchor    = AnchorStyles.Left | AnchorStyles.Right;
            lblPhone.TextAlign = ContentAlignment.MiddleLeft;

            lblEmail.Text      = "이메일";
            lblEmail.Anchor    = AnchorStyles.Left | AnchorStyles.Right;
            lblEmail.TextAlign = ContentAlignment.MiddleLeft;

            // ── TextBoxes ─────────────────────────────────────────
            txtDepartment.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtDepartment.Margin = new Padding(0, 5, 4, 0);

            txtTeam.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtTeam.Margin = new Padding(0, 5, 4, 0);

            txtPart.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPart.Margin = new Padding(0, 5, 4, 0);

            txtPosition.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPosition.Margin = new Padding(0, 5, 4, 0);

            txtName.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtName.Margin = new Padding(0, 5, 4, 0);

            txtExtension.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtExtension.Margin = new Padding(0, 5, 4, 0);

            txtPhone.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtPhone.Margin = new Padding(0, 5, 4, 0);

            txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Margin = new Padding(0, 5, 4, 0);

            // ── 버튼 ──────────────────────────────────────────────
            btnSave.Text           = "저장";
            btnSave.Size           = new Size(80, 28);
            btnSave.Margin         = new Padding(6, 8, 0, 0);
            btnSave.Click         += btnSave_Click;

            btnCancel.Text         = "취소";
            btnCancel.Size         = new Size(80, 28);
            btnCancel.Margin       = new Padding(0, 8, 0, 0);
            btnCancel.DialogResult = DialogResult.Cancel;

            pnlButtons.Dock          = DockStyle.Fill;
            pnlButtons.FlowDirection = FlowDirection.RightToLeft;
            pnlButtons.Controls.Add(btnSave);
            pnlButtons.Controls.Add(btnCancel);

            // ── TableLayoutPanel ──────────────────────────────────
            tableLayout.Dock        = DockStyle.Fill;
            tableLayout.ColumnCount = 2;
            tableLayout.RowCount    = 9;
            tableLayout.Padding     = new Padding(6, 4, 6, 0);

            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 80));
            tableLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 36));
            tableLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 44));

            tableLayout.Controls.Add(lblDepartment, 0, 0);
            tableLayout.Controls.Add(txtDepartment, 1, 0);
            tableLayout.Controls.Add(lblTeam,       0, 1);
            tableLayout.Controls.Add(txtTeam,       1, 1);
            tableLayout.Controls.Add(lblPart,       0, 2);
            tableLayout.Controls.Add(txtPart,       1, 2);
            tableLayout.Controls.Add(lblPosition,   0, 3);
            tableLayout.Controls.Add(txtPosition,   1, 3);
            tableLayout.Controls.Add(lblName,       0, 4);
            tableLayout.Controls.Add(txtName,       1, 4);
            tableLayout.Controls.Add(lblExtension,  0, 5);
            tableLayout.Controls.Add(txtExtension,  1, 5);
            tableLayout.Controls.Add(lblPhone,      0, 6);
            tableLayout.Controls.Add(txtPhone,      1, 6);
            tableLayout.Controls.Add(lblEmail,      0, 7);
            tableLayout.Controls.Add(txtEmail,      1, 7);
            tableLayout.Controls.Add(pnlButtons,    1, 8);

            // ── Form에 추가 (순서 중요: Fill → Left 순) ─────────────
            Controls.Add(tableLayout);
            Controls.Add(pnlPhoto);

            AcceptButton = btnSave;
            CancelButton = btnCancel;
        }
    }
}
