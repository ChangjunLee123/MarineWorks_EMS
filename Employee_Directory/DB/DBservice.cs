using Employee_Directory.Helpers;
using Microsoft.Data.Sqlite;

namespace Employee_Directory.DB
{
    // DB 접근하기 위한 모든곳에서 동일하게 사용하는 유틸리티성 객체라서  static class 으로설정
    // 변경될이유없고 자주사용
    // 추가 +)  class 가 아니라 메서드앞의 static 은  새로운객체 new  선언가능
    // [객체의 상태(변수)가 필요없고 자주쓰는 함수  굳이 무겁게 객체선언해서 쓰지말고 클래스.함수명 이렇게편하게쓰라고]
    internal static class DBservice
    {
        public static SqliteConnection GetConnection()
        {
            return new SqliteConnection(Config.ConnStr);
        }

        public static void Initialize()
        {
            try
            {
                using var conn = GetConnection();
                conn.Open();

                string createUsers = @"
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        UserId TEXT NOT NULL,
                        Password TEXT NOT NULL,
                        Role TEXT NOT NULL
                    );";

                string createEmployees = @"
                    CREATE TABLE IF NOT EXISTS Employees (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Department TEXT NOT NULL,
                        Team TEXT NOT NULL,
                        Part TEXT,
                        Position TEXT NOT NULL,
                        Name TEXT NOT NULL,
                        ExtensionNumber TEXT,
                        Phone TEXT NOT NULL,
                        Email TEXT NOT NULL,
                        PhotoPath TEXT
                    );";

                new SqliteCommand(createUsers, conn).ExecuteNonQuery();
                new SqliteCommand(createEmployees, conn).ExecuteNonQuery();

                // Users 테이블이 비어있으면 테스트 계정 삽입
                string checkUsers = "SELECT COUNT(*) FROM Users";
                long count = (long)new SqliteCommand(checkUsers, conn).ExecuteScalar();

                if (count == 0)
                {
                    string insertUsers = @"
                        INSERT INTO Users (UserId, Password, Role) VALUES ('admin', 'admin', 'Admin');
                        INSERT INTO Users (UserId, Password, Role) VALUES ('testid', 'testpw', 'User');";

                    new SqliteCommand(insertUsers, conn).ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"DB 초기화 실패: {ex.Message}");
                MessageBox.Show("DB 초기화 오류 프로그램 재실행 해주세요", ex.Message);
                Application.Exit();
            }
        }

        
    }
}
