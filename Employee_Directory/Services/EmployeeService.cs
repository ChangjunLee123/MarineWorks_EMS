using Employee_Directory.Models;
using Employee_Directory.Repositories;

namespace Employee_Directory.Services
{
    internal class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository = new EmployeeRepository();

        // 판단만 담당 - 쿼리는 EmployeeRepository가 처리
        public List<Employee> GetAll()
        {

            // MainForm.cs 의 LoadEmployees() 에서 온 요청 -> EmployeeRepository.cs 의 GetAll(); 함수로 요청
            return _employeeRepository.GetAll();
        }


        // MainForm 에서 keyword + columnName 검색시 호출함수
        public List<Employee> Search(string keyword, string columnName)
        {
            return _employeeRepository.Search(keyword, columnName);
        }

        public void Add(Employee emp)
        {
            _employeeRepository.Insert(emp);
        }

        public void Update(Employee emp)
        {
            _employeeRepository.Update(emp);
        }

        public void Delete(int id)
        {
            _employeeRepository.Delete(id);
        }
    }
}
