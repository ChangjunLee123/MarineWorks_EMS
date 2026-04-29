using Employee_Directory.Helpers;
using Employee_Directory.Models;
using Employee_Directory.Services;
using System;
using System.Windows.Forms;

namespace Employee_Directory.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        //Services/Authservice
        private Authservice authservice = new Authservice();

        // 메서드명(object sender, EventArgs e ) -> .NET 이벤트 핸들러의 약속된 서명, 무조건 이형태로
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void IDtextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PWtextbox_TextChanged(object sender, EventArgs e)
        {

        }



        private void login_button_Click(object sender, EventArgs e)
        {
            try
            {
                string userid = IDtextbox.Text;
                string userpw = PWtextbox.Text;

                UserRole? role = authservice.Login(userid, userpw);

                if (role != null)
                {
                    Logger.CurrentUser = userid;
                    Logger.Info($"로그인 성공 (권한: {role})");
                    MainForm mainForm = new MainForm(role.Value, userid, this);
                    mainForm.Show();
                    IDtextbox.Clear();
                    PWtextbox.Clear();
                    this.Hide();
                }
                else
                {
                    Logger.Info($"로그인 실패 - 아이디: {userid}");
                    MessageBox.Show("아이디 또는 비밀번호가 틀렸습니다.", "로그인 실패");
                    IDtextbox.Clear();
                    PWtextbox.Clear();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"로그인 중 오류: {ex.Message}");
                MessageBox.Show(ex.Message, "오류");
            }


        }

        private void Pnllow_Paint(object sender, PaintEventArgs e)
        {

        }

       
    }
}
