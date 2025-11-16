using Restoran_console_appp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_console_appp.Models
{
    public class Employee
    {
        private static int _unicEmployeeId = 0;
        public int EmployeeId { get; set; }
        public string EmployeeUsername { get; set; }
        public string EmployeeSurname { get; set; }
        public int EmployeeAge { get; set; }
        public string EmployeePosition { get; set; }
        public MailAddress EmployeeMail {  get; set; }
        public string EmployeePhoneNumber { get; set; }
        public decimal EmployeeSalary { get; set; }
        public Employee(string employeeUsername, string employeeSurname, int employeeAge, string employeePosition, MailAddress employeeMailAddress, string employeePhoneNumber, decimal employeeSalary )
        {
            EmployeeId = ++_unicEmployeeId;
            EmployeeUsername = employeeUsername;
            EmployeeSurname = employeeSurname;
            EmployeeAge = employeeAge;
            EmployeePosition = employeePosition;
            EmployeeMail = employeeMailAddress;
            EmployeePhoneNumber = employeePhoneNumber;
            EmployeeSalary = employeeSalary;
        }

        public override string ToString()
        {
            return $"İşçinin adı: {EmployeeUsername}, Soyadı: {EmployeeSurname}, Yaşı: {EmployeeAge}, Öhdəliyi: {EmployeePosition}, Mail adresi: {EmployeeMail}, Telefon nömrəsi: {EmployeePhoneNumber}, Maaşı: {EmployeeSalary}, ID: {EmployeeId}";
        }

    }
}
