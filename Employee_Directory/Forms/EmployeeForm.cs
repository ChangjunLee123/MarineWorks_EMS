using Employee_Directory.Helpers;
using Employee_Directory.Models;


namespace Employee_Directory.Forms
{
    public partial class EmployeeForm : Form
    {
        public Employee Result { get; private set; } = new Employee();

        private string? _currentPhotoPath = null; // DB에 저장된 기존 경로
        private string? _pendingPhotoSrc  = null; // 사용자가 새로 선택한 파일 원본 경로

        private static readonly string PhotosDir     = Config.PhotosDir;
        private static readonly string NullImagePath = Config.NullImagePath;

        // 추가 모드
        public EmployeeForm()
        {
            InitializeComponent();
            Text = "직원 추가";
            LoadPhoto(null);
        }

        // 수정 모드
        public EmployeeForm(Employee emp, UserRole role)
        {
            InitializeComponent();
            Text = "직원 조회/수정";

            txtDepartment.Text = emp.Department;
            txtTeam.Text       = emp.Team;
            txtPart.Text       = emp.Part ?? "";
            txtPosition.Text   = emp.Position;
            txtName.Text       = emp.Name;
            txtExtension.Text  = emp.ExtensionNumber ?? "";
            txtPhone.Text      = emp.Phone;
            txtEmail.Text      = emp.Email;

            Result.Id         = emp.Id;
            _currentPhotoPath = emp.PhotoPath;
            LoadPhoto(emp.PhotoPath);

            // Admin이 아니면 수정 불가 — 읽기 전용 처리
            if (role != UserRole.Admin)
            {
                Text = "직원 조회";
                btnSave.Visible        = false;
                btnChangePhoto.Visible = false;
                picPhoto.Cursor        = Cursors.Default;
                picPhoto.Click        -= btnChangePhoto_Click;

                txtDepartment.ReadOnly = true;
                txtTeam.ReadOnly       = true;
                txtPart.ReadOnly       = true;
                txtPosition.ReadOnly   = true;
                txtName.ReadOnly       = true;
                txtExtension.ReadOnly  = true;
                txtPhone.ReadOnly      = true;
                txtEmail.ReadOnly      = true;
            }
        }

        // 사진 PictureBox에 표시 — 경로가 없거나 파일 없으면 NullImage
        private void LoadPhoto(string? relativePath)
        {
            string fullPath = relativePath != null
                ? Path.Combine(Config.Base, relativePath)
                : "";

            // 파일없으면 리소스에서 바로 꺼내기
            if (!File.Exists(fullPath))
            {
                picPhoto.Image = Properties.Resources.NullImage;
                return;
            }

           
            // Image.FromFile은 파일을 계속 잠금 — MemoryStream으로 읽어서 잠금 해제
            //using var ms = new MemoryStream(File.ReadAllBytes(fullPath));
            //picPhoto.Image = Image.FromStream(ms);

            // 오류 예외처리 추가
            try
            {
                using var ms = new MemoryStream(File.ReadAllBytes(fullPath));
                picPhoto.Image = Image.FromStream(ms);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logger.Error($"사진 로드 실패 : {ex.Message}");
                picPhoto.Image = Properties.Resources.NullImage;
            }

            
            
        }

        // 사진 변경 버튼 / PictureBox 클릭
        private void btnChangePhoto_Click(object? sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog();
            dlg.Title  = "사진 선택";
            dlg.Filter = "이미지 파일|*.jpg;*.jpeg;*.png;*.gif";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _pendingPhotoSrc = dlg.FileName;
                    using var ms = new MemoryStream(File.ReadAllBytes(_pendingPhotoSrc));
                    picPhoto.Image = Image.FromStream(ms);
                }
                catch (Exception ex)
                {
                    _pendingPhotoSrc = null;
                    Logger.Error($"사진 로드 실패 ({dlg.FileName}): {ex.Message}");
                    MessageBox.Show($"사진을 불러올 수 없습니다: {ex.Message}", "오류");
                }
                //picPhoto.Image   = Image.FromFile(dlg.FileName);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDepartment.Text) ||
                string.IsNullOrWhiteSpace(txtTeam.Text)       ||
                string.IsNullOrWhiteSpace(txtPosition.Text)   ||
                string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("부서, 팀/사업소, 직위/직책, 이름은 필수 입력입니다.", "입력 오류",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 수정사항 프로퍼티에 저장 
            Result.Department      = txtDepartment.Text.Trim();
            Result.Team            = txtTeam.Text.Trim();
            Result.Part            = string.IsNullOrWhiteSpace(txtPart.Text) ? null : txtPart.Text.Trim();
            Result.Position        = txtPosition.Text.Trim();
            Result.Name            = txtName.Text.Trim();
            Result.ExtensionNumber = string.IsNullOrWhiteSpace(txtExtension.Text) ? null : txtExtension.Text.Trim();
            Result.Phone           = txtPhone.Text.Trim();
            Result.Email           = txtEmail.Text.Trim();

            // 새 사진 선택한 경우 photos 폴더에 복사 후 상대경로 저장
            if (_pendingPhotoSrc != null)
            {
                // 기존 사진 파일 삭제 (NullImage는 공용 파일이라 제외)
                if (_currentPhotoPath != null)
                {
                    // DB에서 가져온 _currentPhotoPath -> 폴더명/파일명.확장자 
                    // 해당 실행중인 프로그램 해당경로 AppDomain.CurrentDomain.BaseDirectory 
                    // 이거 두개 Combine(합쳐서) 완전한 경로(절대경로) 추출
                    string oldFullPath = Path.Combine(Config.Base, _currentPhotoPath);

                    // 해당 파일이 실제 존재하는 지 && 파일경로가 공용 이미지(NUL전용이미지) 가 아닌지  삭제전에 체크 
                    // StringComparison.OrdinalIgnoreCase -> 공용이미지 경로와 같은지 체크할때 대소문자 구분하지않고 체크
                    if (File.Exists(oldFullPath) && !oldFullPath.Equals(NullImagePath, StringComparison.OrdinalIgnoreCase))
                    {
                        try { File.Delete(oldFullPath); }
                        catch { /* 삭제 실패해도 저장은 계속 진행 */ }
                    }
                }

                // 이미지 파일 저장할 디렉토리 생성 /지정한 디렉토리 이미존재한다면 아무 처리안함
                Directory.CreateDirectory(PhotosDir);

                // 해당 파일의 확장자 반환 (새로 변경할 이미지파일의 경로에서 )
                string ext      = Path.GetExtension(_pendingPhotoSrc);

                // 새로 변경할 이미지를 프로그램 형식의 이름으로 변경위해 파일 이름설정 
                // 해당 사람의 이름_변경년월일시분초.ext(방금 얻어온 확장자) 
                string fileName = $"{Result.Name}_{DateTime.Now:yyyyMMddHHmmss}{ext}";

                // 새롭게 복사할 이미지의 경로 생성 ( 이미지 파일이 복사되서 저장될 디렉토리 + 파일명)
                string destPath = Path.Combine(PhotosDir, fileName);

                // 실제 선택됬던 이미지 를 복사하는 명령어 File.Copy(원본이미지주소,새롭게복사할이미지경로,덮어쓰기ok)
                File.Copy(_pendingPhotoSrc, destPath, overwrite: true);

                // 새롭게 업로드한 이미지 복사처리 완료후 DB 에 경로 등록을위해 Result 객체에 PhotoPath 에 경로등록
                Result.PhotoPath = $"photos/{fileName}";
            }
            else
            {
                // 변경 없으면 기존 경로 유지
                Result.PhotoPath = _currentPhotoPath;
            }

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
