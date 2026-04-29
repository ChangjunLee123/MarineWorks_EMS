namespace Employee_Directory.Forms
{
    partial class PasswordChangeForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label   lblAccountId;
        private Label   lblCurrent, lblNew, lblConfirm;
        private TextBox txtCurrent, txtNew, txtConfirm;
        private Button  btnConfirm, btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblAccountId = new Label();
            lblCurrent   = new Label();
            lblNew       = new Label();
            lblConfirm   = new Label();
            txtCurrent   = new TextBox();
            txtNew       = new TextBox();
            txtConfirm   = new TextBox();
            btnConfirm   = new Button();
            btnCancel    = new Button();

            // ── Form ─────────────────────────────────────────────
            Text            = "내 정보 — 비밀번호 변경";
            Size            = new Size(340, 240);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox     = false;
            MinimizeBox     = false;
            StartPosition   = FormStartPosition.CenterParent;
            Padding         = new Padding(10);

            // ── 계정 표시 ─────────────────────────────────────────
            lblAccountId.Location  = new Point(20, 15);
            lblAccountId.Size      = new Size(280, 20);
            lblAccountId.Font      = new Font("맑은 고딕", 9F, FontStyle.Bold);

            // ── 현재 비밀번호 ─────────────────────────────────────
            lblCurrent.Text      = "현재 비밀번호";
            lblCurrent.Location  = new Point(20, 45);
            lblCurrent.Size      = new Size(90, 23);
            lblCurrent.TextAlign = ContentAlignment.MiddleLeft;

            txtCurrent.Location     = new Point(120, 43);
            txtCurrent.Size         = new Size(175, 23);
            txtCurrent.PasswordChar = '*';

            // ── 새 비밀번호 ───────────────────────────────────────
            lblNew.Text      = "새 비밀번호";
            lblNew.Location  = new Point(20, 78);
            lblNew.Size      = new Size(90, 23);
            lblNew.TextAlign = ContentAlignment.MiddleLeft;

            txtNew.Location     = new Point(120, 76);
            txtNew.Size         = new Size(175, 23);
            txtNew.PasswordChar = '*';

            // ── 비밀번호 확인 ─────────────────────────────────────
            lblConfirm.Text      = "비밀번호 확인";
            lblConfirm.Location  = new Point(20, 111);
            lblConfirm.Size      = new Size(90, 23);
            lblConfirm.TextAlign = ContentAlignment.MiddleLeft;

            txtConfirm.Location     = new Point(120, 109);
            txtConfirm.Size         = new Size(175, 23);
            txtConfirm.PasswordChar = '*';

            // ── 버튼 ─────────────────────────────────────────────
            btnConfirm.Text     = "변경";
            btnConfirm.Location = new Point(120, 150);
            btnConfirm.Size     = new Size(80, 28);
            btnConfirm.Click   += btnConfirm_Click;

            btnCancel.Text         = "취소";
            btnCancel.Location     = new Point(215, 150);
            btnCancel.Size         = new Size(80, 28);
            btnCancel.DialogResult = DialogResult.Cancel;

            Controls.AddRange(new Control[]
            {
                lblAccountId,
                lblCurrent, txtCurrent,
                lblNew,     txtNew,
                lblConfirm, txtConfirm,
                btnConfirm, btnCancel
            });

            CancelButton = btnCancel;
        }
    }
}
