﻿namespace Web.Areas.Employee.Models
{
    public class EmployeeViewModel
    {
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? MiddleLastName { get; set; }
        public string? Picture { get; set; }
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string City { get; set; } = null!;
        public string District { get; set; } = null!;
        public string FullAddress { get; set; } = null!;
        public string OccupationName { get; set; }
        public string DepartmentName { get; set; }
    }
}
