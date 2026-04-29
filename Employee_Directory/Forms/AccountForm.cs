using Employee_Directory.Helpers;
using Employee_Directory.Models;
using Employee_Directory.Services;

namespace Employee_Directory.Forms
{
    public partial class AccountForm : Form
    {
        private readonly AccountService _accountService = new AccountService();

        public AccountForm()
        {
            InitializeComponent();
            LoadAccounts();
        }

        // 계정 목록 불러오기
        private void LoadAccounts()
        {
            try
            {
                var accounts = _accountService.GetAll();
                dgvAccounts.DataSource = accounts;

                dgvAccounts.Columns["Id"].Visible        = false;
                dgvAccounts.Columns["Password"].Visible  = false;
                dgvAccounts.Columns["UserId"].HeaderText = "아이디";
                dgvAccounts.Columns["Role"].HeaderText   = "권한";
            }
            catch (Exception ex)
            {
                Logger.Error($"계정 목록 로드 중 오류: {ex.Message}");
                MessageBox.Show(ex.Message, "오류");
            }
        }

        // 계정 추가 — 항상 User 권한으로 생성
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtUserId.Text) ||
                    string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    MessageBox.Show("아이디와 비밀번호를 입력해주세요.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _accountService.Add(txtUserId.Text.Trim(), txtPassword.Text, UserRole.User);
                Logger.Info($"계정 추가: {txtUserId.Text.Trim()}");

                txtUserId.Clear();
                txtPassword.Clear();
                LoadAccounts();
            }
            catch (Exception ex)
            {
                Logger.Error($"계정 추가 중 오류: {ex.Message}");
                MessageBox.Show(ex.Message, "오류");
            }
        }

        // 계정 삭제 — Admin 계정은 삭제 불가
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAccounts.CurrentRow == null) return;

                var account = dgvAccounts.CurrentRow.DataBoundItem as NowUser;
                if (account == null) return;

                if (account.Role == UserRole.Admin)
                {
                    MessageBox.Show("Admin 계정은 삭제할 수 없습니다.", "삭제 불가",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var confirm = MessageBox.Show(
                    $"'{account.UserId}' 계정을 삭제하시겠습니까?", "삭제 확인",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    _accountService.Delete(account.Id);
                    Logger.Info($"계정 삭제: {account.UserId} (ID: {account.Id})");
                    LoadAccounts();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"계정 삭제 중 오류: {ex.Message}");
                MessageBox.Show(ex.Message, "오류");
            }
        }
    }
}
