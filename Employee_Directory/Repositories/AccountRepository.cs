using Employee_Directory.DB;
using Employee_Directory.Models;
using Microsoft.Data.Sqlite;

namespace Employee_Directory.Repositories
{
    internal class AccountRepository
    {
        // 전체 계정 조회
        public List<NowUser> GetAll()
        {
            try
            {
                var list = new List<NowUser>();
                using var conn = DBservice.GetConnection();
                conn.Open();

                using var cmd = new SqliteCommand("SELECT Id, UserId, Role FROM Users", conn);
                using var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new NowUser
                    {
                        Id     = reader.GetInt32(0),
                        UserId = reader.GetString(1),
                        Role   = Enum.TryParse<UserRole>(reader.GetString(2), out var role)
                                 ? role : UserRole.User
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"계정 목록 조회 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        // 계정 추가
        public void Insert(string userId, string password, UserRole role)
        {
            try
            {
                using var conn = DBservice.GetConnection();
                conn.Open();

                using var cmd = new SqliteCommand(
                    "INSERT INTO Users (UserId, Password, Role) VALUES (@id, @pw, @role)", conn);
                cmd.Parameters.AddWithValue("@id",   userId);
                cmd.Parameters.AddWithValue("@pw",   password);
                cmd.Parameters.AddWithValue("@role", role.ToString());
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"계정 추가 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        // 계정 삭제
        public void Delete(int id)
        {
            try
            {
                using var conn = DBservice.GetConnection();
                conn.Open();

                using var cmd = new SqliteCommand("DELETE FROM Users WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"계정 삭제 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        // 비밀번호 변경
        public void UpdatePassword(string userId, string newPassword)
        {
            try
            {
                using var conn = DBservice.GetConnection();
                conn.Open();

                using var cmd = new SqliteCommand(
                    "UPDATE Users SET Password = @pw WHERE UserId = @id", conn);
                cmd.Parameters.AddWithValue("@pw", newPassword);
                cmd.Parameters.AddWithValue("@id", userId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"비밀번호 변경 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        // 아이디 중복 체크
        public bool ExistsUserId(string userId)
        {
            try
            {
                using var conn = DBservice.GetConnection();
                conn.Open();

                using var cmd = new SqliteCommand(
                    "SELECT COUNT(*) FROM Users WHERE UserId = @id", conn);
                cmd.Parameters.AddWithValue("@id", userId);
                return (long)cmd.ExecuteScalar() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"계정 중복 확인 중 오류가 발생했습니다: {ex.Message}");
            }
        }
    }
}
