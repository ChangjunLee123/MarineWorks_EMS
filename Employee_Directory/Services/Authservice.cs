using Employee_Directory.Models;
using Employee_Directory.Repositories;

namespace Employee_Directory.Services
{
    internal class Authservice
    {
        private readonly UserRepository _userRepository = new UserRepository();

        // 판단만 담당 - 쿼리는 UserRepository가 처리
        public UserRole? Login(string userid, string userpw)
        {
            NowUser? user = _userRepository.FindByCredentials(userid, userpw);

            if (user == null)
                return null;

            return user.Role;
        }
    }
}
