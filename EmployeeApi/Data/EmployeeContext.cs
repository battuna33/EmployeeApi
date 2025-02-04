using EmployeeApi.Models;

namespace EmployeeApi.Data
{
    public class EmployeeContext
    {
        public List<Employee> Employees { get; set; }

        public EmployeeContext()
        {
            // Başlangıçta bazı örnek veriler
            Employees =
            [
                new Employee { Id = 1, FirstName = "Ahmet", LastName = "Yılmaz", Position = "Yazılım Mühendisi", Salary = 7000 },
                new Employee { Id = 2, FirstName = "Ayşe", LastName = "Demir", Position = "Proje Yöneticisi", Salary = 9000 }
            ];
        }
    }
}