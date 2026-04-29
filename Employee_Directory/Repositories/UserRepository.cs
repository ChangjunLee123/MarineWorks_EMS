using Employee_Directory.DB;
using Employee_Directory.Models;
using Microsoft.Data.Sqlite;

namespace Employee_Directory.Repositories
{
    internal class UserRepository
    {
        // ID와 PW가 일치하는 계정의 role 반환, 없으면 null
        public NowUser? FindByCredentials(string userid, string userpw)
        {
            try
            {
                //DBservice 에서 sqlite 연결 객체 생성 
                using var conn = DBservice.GetConnection();
                conn.Open();

                string sql = "SELECT Id, UserId, Password, Role FROM Users WHERE UserId = @id AND Password = @pw";
                using var cmd = new SqliteCommand(sql, conn);

                // Parameters.AddWithValue -> SqliteCommand 안에 정의된 메서드 (쿼리 안의 변수를 실제 값으로 변경)
                cmd.Parameters.AddWithValue("@id", userid);
                cmd.Parameters.AddWithValue("@pw", userpw);

                // ExecuteReader() -> cmd 에 들어있는 쿼리 , db conn 정보로 데이터 읽어오는 실행 / 값은 앞의 reader 변수에
                // reader 변수는 단순객체아니라 DB 연결 객체  using var 사용
                using var reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return new NowUser
                    {
                        //Id = reader.GetInt32(0),
                        UserId = reader.GetString(1),
                        Password = reader.GetString(2),
                        
                        // DB 문자열 → Enum 변환 (없는 값이면 User로 기본값 처리)
                        Role = Enum.TryParse<UserRole>(reader.GetString(reader.GetOrdinal("Role")), out var role)
                            ? role : UserRole.User
                    };
                }

                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"로그인 중 오류 발생 : {ex.Message}");
            }
        }
    }
}
