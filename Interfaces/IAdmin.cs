using Restoran_console_appp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_console_appp.Interfaces
{
    //Admin yeni Manager elave ede bilsin, Sile bilsin.Hesabina baxa bilmelidir hansiki istifadeciler terefinden elave olunan meblegi gormek ucun.
    //Isci elave ede biler iscilerin sayin gorsun, Iscilerin melumatlarina baxa biler.
    //Managerlerin sayin gorsun, Managerlerin melumatlarina baxa biler.
    public interface IAdmin
    {
        public void Login(string username, string password);
        public void ShowAdminBalance();
        public void AddManager(Manager manager);
        public void RemoveManager(string managerName);
        public void ShowAllManager();
        public void AddEmployee(Employee employee);
        public void RemoveEmployee(string employeeName);
        public void ShowAllEmployee();
        public void ReservationForAdmin(Reservation reservation);
        public void ReservationForAdminCancel(int? reservationID);
        public List<Table> ListAllEmptyTables();
        public List<Table> ListAllTables();
    }
}
