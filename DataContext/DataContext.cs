using Restoran_console_appp.Enum;
using Restoran_console_appp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_console_appp.DataContext
{
    public static class DataContext
    {
        public static List<User> Users = new List<User>();
        public static List<Manager> Managers = new List<Manager>();
        public static List<Employee> Employees = new List<Employee>();
        public static List<Table> Tables = new List<Table>();
        public static List<Reservation> Reservations = new List<Reservation>();
        public static decimal? AdminBalance = 1000;
        public static void SyncTableStatuses()
        {
            foreach (var table in Tables)
            {
                if (Reservations.Any(r => r.ReservedTable.TableNumber == table.TableNumber
                                          && r.Status == ReservationStatus.Confirmed))
                {
                    table.TableStatus = TableStatus.Reserved;
                }
                else
                {
                    table.TableStatus = TableStatus.Available;
                }
            }
        }

    }
}
