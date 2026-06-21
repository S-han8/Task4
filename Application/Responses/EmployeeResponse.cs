using System;
using System.Collections.Generic;
using System.Text;


namespace Application.Responses
{
    public class EmployeeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Salary { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
    }
}
