using Employee_Directory.DB;
using Employee_Directory.Models;
using Microsoft.Data.Sqlite;

namespace Employee_Directory.Repositories
{
    internal class EmployeeRepository
    {
        private static readonly string _selectCols =
            "Id, Department, Team, Part, Position, Name, ExtensionNumber, Phone, Email, PhotoPath";

        // reader → Employee 변환 (중복 제거)
        private static Employee ReadEmployee(SqliteDataReader r) => new Employee
        // => 람다식  ( 람다식 없에고 그냥 return new Employee 하는거랑 동일 )
        {
            Id              = r.GetInt32(0),
            Department      = r.GetString(1),
            Team            = r.GetString(2),
            // DB 에서 읽어온 Null 값을 바로 넣으면 오류생김 C# 형식으로 Null 로 처리해줘야함
            Part            = r.IsDBNull(3)  ? null : r.GetString(3),
            Position        = r.GetString(4),
            Name            = r.GetString(5),
            ExtensionNumber = r.IsDBNull(6)  ? null : r.GetString(6),
            Phone           = r.GetString(7),
            Email           = r.GetString(8),
            PhotoPath       = r.IsDBNull(9)  ? null : r.GetString(9),
        };

        // 전체 직원 목록 조회
        public List<Employee> GetAll()
        {
            try
            {
                var list = new List<Employee>();
                using var conn = DBservice.GetConnection();
                conn.Open();

                using var cmd = new SqliteCommand($"SELECT {_selectCols} FROM Employees", conn);
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(ReadEmployee(reader));
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"직원 목록 조회 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        // columnName 에 따라 검색 대상 컬럼 분기
        public List<Employee> Search(string keyword, string columnName)
        {
            try
            {
                var list = new List<Employee>();
                using var conn = DBservice.GetConnection();
                conn.Open();

                string where = columnName switch
                {
                    "Department"      => "Department LIKE @kw",
                    "Team"            => "Team LIKE @kw",
                    "Part"            => "Part LIKE @kw",
                    "Position"        => "Position LIKE @kw",
                    "Name"            => "Name LIKE @kw",
                    "ExtensionNumber" => "ExtensionNumber LIKE @kw",
                    "Phone"           => "Phone LIKE @kw",
                    "Email"           => "Email LIKE @kw",
                    _                 => "Department LIKE @kw OR Team LIKE @kw OR Name LIKE @kw OR Phone LIKE @kw OR Email LIKE @kw"
                };

                using var cmd = new SqliteCommand($"SELECT {_selectCols} FROM Employees WHERE {where}", conn);
                cmd.Parameters.AddWithValue("@kw", $"%{keyword}%");
                using var reader = cmd.ExecuteReader();
                while (reader.Read()) list.Add(ReadEmployee(reader));
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception($"직원 검색 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        // 직원 추가
        public void Insert(Employee emp)
        {
            try
            {
                using var conn = DBservice.GetConnection();
                conn.Open();

                string sql = @"INSERT INTO Employees (Department, Team, Part, Position, Name, ExtensionNumber, Phone, Email, PhotoPath)
                               VALUES (@dept, @team, @part, @pos, @name, @ext, @phone, @email, @photo)";
                using var cmd = new SqliteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dept",  emp.Department);
                cmd.Parameters.AddWithValue("@team",  emp.Team);
                cmd.Parameters.AddWithValue("@part",  (object?)emp.Part ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pos",   emp.Position);
                cmd.Parameters.AddWithValue("@name",  emp.Name);
                cmd.Parameters.AddWithValue("@ext",   (object?)emp.ExtensionNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@phone", emp.Phone);
                cmd.Parameters.AddWithValue("@email", emp.Email);
                cmd.Parameters.AddWithValue("@photo", (object?)emp.PhotoPath ?? DBNull.Value);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"직원 추가 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        // 직원 수정
        public void Update(Employee emp)
        {
            try
            {
                using var conn = DBservice.GetConnection();
                conn.Open();

                string sql = @"UPDATE Employees SET
                               Department = @dept, Team = @team, Part = @part, Position = @pos,
                               Name = @name, ExtensionNumber = @ext, Phone = @phone, Email = @email, PhotoPath = @photo
                               WHERE Id = @id";
                using var cmd = new SqliteCommand(sql, conn);
                cmd.Parameters.AddWithValue("@dept",  emp.Department);
                cmd.Parameters.AddWithValue("@team",  emp.Team);
                cmd.Parameters.AddWithValue("@part",  (object?)emp.Part ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@pos",   emp.Position);
                cmd.Parameters.AddWithValue("@name",  emp.Name);
                cmd.Parameters.AddWithValue("@ext",   (object?)emp.ExtensionNumber ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@phone", emp.Phone);
                cmd.Parameters.AddWithValue("@email", emp.Email);
                cmd.Parameters.AddWithValue("@photo", (object?)emp.PhotoPath ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id",    emp.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"직원 수정 중 오류가 발생했습니다: {ex.Message}");
            }
        }

        // 직원 삭제
        public void Delete(int id)
        {
            try
            {
                using var conn = DBservice.GetConnection();
                conn.Open();

                using var cmd = new SqliteCommand("DELETE FROM Employees WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception($"직원 삭제 중 오류가 발생했습니다: {ex.Message}");
            }
        }
    }
}
