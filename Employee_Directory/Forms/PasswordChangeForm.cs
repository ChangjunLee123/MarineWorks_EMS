using Employee_Directory.Helpers;
using Employee_Directory.Services;

namespace Employee_Directory.Forms
{
    public partial class PasswordChangeForm : Form
    {
        private readonly string _userId;
        private readonly AccountService _accountService = new AccountService();

        public PasswordChangeForm(string userId)
        {
            InitializeComponent();
            _userId = userId;
            lblAccountId.Text = $"계정: {userId}";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string current    = txtCurrent.Text;
                string newPw      = txtNew.Text;
                string confirmPw  = txtConfirm.Text;

                if (string.IsNullOrWhiteSpace(current) ||
                    string.IsNullOrWhiteSpace(newPw)   ||
                    string.IsNullOrWhiteSpace(confirmPw))
                {
                    MessageBox.Show("모든 항목을 입력해주세요.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (newPw != confirmPw)
                {
                    MessageBox.Show("새 비밀번호와 확인 비밀번호가 일치하지 않습니다.", "입력 오류",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }



                _accountService.ChangePassword(_userId, current, newPw);
                Logger.Info($"비밀번호 변경: {_userId}");

                MessageBox.Show("비밀번호가 변경되었습니다.", "완료",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                Logger.Error($"비밀번호 변경 중 오류: {ex.Message}");
                MessageBox.Show(ex.Message, "오류");
            }
        }
    }
}
