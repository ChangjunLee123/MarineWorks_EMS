using System.Text.RegularExpressions;
using Employee_Directory.Models;
using Employee_Directory.Repositories;

namespace Employee_Directory.Services
{
    internal class AccountService
    {
        private readonly AccountRepository _accountRepository = new AccountRepository();

        // 딱 한줄짜리 로직일때  C# 에서 return 대신 '=>'사용해서 코드 한줄로도 작성할수있음 
        //public List<NowUser> GetAll() 
        //{
        //  return _accountRepository.GetAll();
        //}    이거랑 동일
        public List<NowUser> GetAll() => _accountRepository.GetAll();

        public void Add(string userId, string password, UserRole role)
        {
            // id 중복체크 
            if (_accountRepository.ExistsUserId(userId))
                throw new Exception("이미 존재하는 아이디입니다.");

            _accountRepository.Insert(userId, password, role);
        }

        public void Delete(int id) => _accountRepository.Delete(id);

        // 비밀번호 복잡도 검증: 7자 이상, 대문자, 소문자, 특수문자 각 1개 이상
        private static void ValidatePassword(string password)
        {
            if (password.Length < 7)
                throw new Exception("비밀번호는 7자 이상이어야 합니다.");
            if (!Regex.IsMatch(password, @"[A-Z]"))
                throw new Exception("비밀번호에 대문자를 1개 이상 포함해야 합니다.");
            if (!Regex.IsMatch(password, @"[a-z]"))
                throw new Exception("비밀번호에 소문자를 1개 이상 포함해야 합니다.");
            if (!Regex.IsMatch(password, @"[^A-Za-z0-9]"))
                throw new Exception("비밀번호에 특수문자를 1개 이상 포함해야 합니다.");
        }

        public void ChangePassword(string userId, string currentPassword, string newPassword)
        {
            // 현재 비밀번호 확인은 AuthService 대신 AccountRepository 직접 사용
            // (UserRepository의 FindByCredentials를 재사용)
            var userRepo = new Repositories.UserRepository();
            var user = userRepo.FindByCredentials(userId, currentPassword);
            if (user == null)
                throw new Exception("현재 비밀번호가 일치하지 않습니다.");


            // 여기서 조건체크해서 조건 안맞을시 PasswordChangeForm 으로 예외 throw 밑의 내용 진행 x 
            ValidatePassword(newPassword);

            _accountRepository.UpdatePassword(userId, newPassword);
        }
    }
}
