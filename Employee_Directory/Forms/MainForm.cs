using Employee_Directory.Helpers;
using Employee_Directory.Models;
using Employee_Directory.Services;
using System.Windows.Forms;

namespace Employee_Directory.Forms
{
    public partial class MainForm : Form
    {

        // readonly 읽기전용 변수 선언
        private readonly UserRole _role;
        private readonly string _userId;
        private readonly LoginForm _loginForm;
        private bool _isLogout = false;
        // 메인폼 백그라운드 로직을 위해 인스턴스 생성
        private readonly EmployeeService _employeeService = new EmployeeService();

        // 로그인 폼에서 Role, userId, LoginForm 인스턴스를 받아 저장
        public MainForm(UserRole role, string userId, LoginForm loginForm)
        {
            InitializeComponent();
            _role = role;
            _userId = userId;
            _loginForm = loginForm;
            dgvEmployees.CellDoubleClick += dgvEmployees_CellDoubleClick;
            this.FormClosed += MainForm_FormClosed;
        }

        private void MainForm_FormClosed(object? sender, FormClosedEventArgs e)
        {
            if (!_isLogout)
            {
                Logger.Info("프로그램 종료");
                Application.Exit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 상단에 로그인한 계정 권한 표시
            lblUserInfo.Text = $"권한: {_role}";

            // 관리자가 아니면 추가/삭제/계정관리 버튼 숨김
            if (_role != UserRole.Admin)
            {
                btnAdd.Visible     = false;
                btnDelete.Visible  = false;
                btnAccount.Visible = false;
            }

            // 직원 목록 불러오기
            LoadEmployees();
        }

        // 직원 목록데이터 바인딩 DataGridView에 표시
        private void LoadEmployees()
        {
            try
            {
                // Model/Employee.cs  모델로 리스트 객체생성
                // EmployeeService.cs 의 GetAll 사용하여 전체 리스트 가져옴
                List<Employee> employees = _employeeService.GetAll();

                // 데이터 표UI 바인딩
                // 각 행마다 Employee 객체대로 묶여서 저장됨 원본 객체를 내부에 행마다 보관중
                dgvEmployees.DataSource = employees;

                // 컬럼 헤더 한글로 변경
                dgvEmployees.Columns["Id"].Visible = false;
                dgvEmployees.Columns["PhotoPath"].Visible = false;
                dgvEmployees.Columns["Department"].HeaderText = "부서";
                dgvEmployees.Columns["Team"].HeaderText = "팀/사업소";
                dgvEmployees.Columns["Part"].HeaderText = "파트";
                dgvEmployees.Columns["Position"].HeaderText = "직위/직책";
                dgvEmployees.Columns["Name"].HeaderText = "이름";
                dgvEmployees.Columns["ExtensionNumber"].HeaderText = "내선번호";
                dgvEmployees.Columns["Phone"].HeaderText = "휴대번호";
                dgvEmployees.Columns["Email"].HeaderText = "이메일";

                // 콤보박스 설정 — DataGridView 보이는 컬럼 헤더로 동적 구성
                SearchComboBox.Items.Clear();
                foreach (DataGridViewColumn col in dgvEmployees.Columns)
                {
                    if (col.Visible)
                        SearchComboBox.Items.Add(col.HeaderText);
                }
                SearchComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Logger.Error($"직원 목록 로드 중 오류: {ex.Message}");
                MessageBox.Show(ex.Message, "오류");
            }
        }

        // 검색 버튼 클릭로직
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
            //입력어 정제 Trim() : 맨앞쪽 뒷쪽 공백,줄바꿈 제거
            string keyword = txtSearch.Text.Trim();

            // 콤보박스 선택값 읽기
            string headerText = SearchComboBox.SelectedItem?.ToString() ?? "";

            //string headerText;
            //if (SearchComboBox.SelectedItem != null)
            //{
            //    headerText = SearchComboBox.SelectedItem.ToString();
            //}
            //else
            //{
            //    headerText = "";
            //}

            // 한글 헤더 → 실제 컬럼명 역추적 (DataGridView 기준)
            // (dgvEmployees.Columns)DGV의 컬럼리스트에서. Cast<DataGridViewColumn>() 형변환해줘 
            //  .FirstOrDefault(c => c.HeaderText == headerText) -> FirstOrDeFault 조건에 맞는 녀석을 앞에서 부터 순서대로 찾는다
            // 찾으면 그컬럼 객체 전체 반환 , 못찾으면 Null 반환 ->여기서 조건은 람다식) c => c.HeaderText == headerText
            // 사실상 반복문과 동일 c 는  foreach 문의 var c 와 동일한 역활
            string columnName = dgvEmployees.Columns
                    .Cast<DataGridViewColumn>()
                    .FirstOrDefault(c => c.HeaderText == headerText)?.Name ?? "";

            // 검색어 없으면 전체 리스트 불러오기, 있으면 선택한 컬럼 기준 검색
            // 삼항 연산자 사용
            List<Employee> result = string.IsNullOrEmpty(keyword)
                ? _employeeService.GetAll()                      // ? -> 참일 때 실행할 코드
                : _employeeService.Search(keyword, columnName);  // : -> 거짓일 때 실행할 코드
            

            //삼항 연산자 안쓰고 if-else 문 사용시
            //List<Employee> result ;

            //if (string.IsNullOrEmpty(keyword))
            //{
            //    result = _employeeService.GetAll();
            //}
            //else
            //{
            //    result = _employeeService.Search(keyword);
            //}


            // 검색 결과 데이터 표에 연결
            dgvEmployees.DataSource = result;

            dgvEmployees.Columns["Id"].Visible = false;
            dgvEmployees.Columns["PhotoPath"].Visible = false;
            dgvEmployees.Columns["Department"].HeaderText = "부서";
            dgvEmployees.Columns["Team"].HeaderText = "팀/사업소";
            dgvEmployees.Columns["Part"].HeaderText = "파트";
            dgvEmployees.Columns["Position"].HeaderText = "직위/직책";
            dgvEmployees.Columns["Name"].HeaderText = "이름";
            dgvEmployees.Columns["ExtensionNumber"].HeaderText = "내선번호";
            dgvEmployees.Columns["Phone"].HeaderText = "휴대번호";
            dgvEmployees.Columns["Email"].HeaderText = "이메일";
            }
            catch (Exception ex)
            {
                Logger.Error($"직원 검색 중 오류: {ex.Message}");
                MessageBox.Show(ex.Message, "오류");
            }
        }

        // 엔터키로도 검색 가능
        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
        }

        // 추가 버튼 클릭
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var form = new EmployeeForm();
                // EmployeeForm 이 ok 로 닫혔는지 취소 혹은 x 버튼으로 닫혔는지 확인 
                // DialogResult 가  ok 이면 추가로직으로 닫혀서 다시 직원명단 로드
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _employeeService.Add(form.Result);
                    Logger.Info($"직원 추가: {form.Result.Name}");
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"직원 추가 중 오류: {ex.Message}");
                MessageBox.Show(ex.Message, "오류");
            }
        }

        // 삭제 버튼 클릭 — 선택된 행 삭제
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvEmployees.CurrentRow == null) return;

                // as Employee -> DataBoundItem 이 Employee 객체가 아닐경우 null 반환 
                var emp = dgvEmployees.CurrentRow.DataBoundItem as Employee;
                if (emp == null) return;
                //메세지 박스는 시스템 수준에서 제공하는 미니모달폼  DialogResult 존재 Yes or No
                var confirm = MessageBox.Show($"'{emp.Name}' 을(를) 삭제하시겠습니까?", "삭제 확인",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    _employeeService.Delete(emp.Id);
                    Logger.Info($"직원 삭제: {emp.Name} (ID: {emp.Id})");
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"직원 삭제 중 오류: {ex.Message}");
                MessageBox.Show(ex.Message, "오류");
            }
        }

        // 행 더블클릭 — 수정 모드로 EmployeeForm 열기 
        // 생성자 부분에 더블클릭 액션 지정
        
        private void dgvEmployees_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            // 만약 헤더 행을 클릭했을시 인덱스값 -1 이라서  index < 0 조건으로 필터링
            if (e.RowIndex < 0) return;

            // dgvEmployees. 의 Rows행 [ e 번째 인덱스의] . DataBoundItem -> 그행에 바인딩된 원본 객체데이터 꺼냄
            // 처음 dgv 에 데이터 넣을때 Employee 객체의 형태로 행대로 들어가있어서 그대로 꺼냄
            var emp = dgvEmployees.Rows[e.RowIndex].DataBoundItem as Employee;
            if (emp == null) return;

            // EmployeeForm 을 모달 창으로 열기
            // 모달 -> 해당 창 닫힐때 까지 MainForm 조작 불가
            // , 창이 닫힐 때 결과 값 (DialogResult) 반환 form.showdialog() 로 값 확인가능
            try
            {
                var form = new EmployeeForm(emp, _role);

                // form.ShowDialog() -> 창이 닫힐때 주는 반환값
                // DialogResult.OK 확인버튼 종료 /
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // 서비스 모듈에서 업데이트 로직수행
                    _employeeService.Update(form.Result);
                    Logger.Info($"직원 수정: {form.Result.Name} (ID: {form.Result.Id})");
                    LoadEmployees();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"직원 수정 중 오류: {ex.Message}");
                MessageBox.Show(ex.Message, "오류");
            }
        }

        // 내 정보 버튼 클릭 — 모든 권한: 본인 비밀번호 변경
        private void btnMyInfo_Click(object sender, EventArgs e)
        {
            new PasswordChangeForm(_userId).ShowDialog();
        }

        // 계정 관리 버튼 클릭 (Admin 하단 버튼)
        private void btnAccount_Click(object sender, EventArgs e)
        {
            new AccountForm().ShowDialog();
        }

        // 로그아웃 버튼 클릭
        private void btnLogout_Click(object sender, EventArgs e)
        {
            Logger.Info("로그아웃");
            Logger.CurrentUser = "unknown";
            _isLogout = true;
            _loginForm.Show();
            this.Close();
        }
    }
}
