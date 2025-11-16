using Restoran_console_appp.Exceptions;
using Restoran_console_appp.Interfaces;
using Restoran_console_appp.DataContext;
using Restoran_console_appp.Enum;

namespace Restoran_console_appp.Models
{
    public class Admin : IAdmin
    {
        List<Manager> Managers => DataContext.DataContext.Managers;
        List<Employee> Employees => DataContext.DataContext.Employees;
        List<Reservation> Reservations => DataContext.DataContext.Reservations;
        List<Table> Tables => DataContext.DataContext.Tables;
        public int AdminId { get; } = 1;
        public string AdminUsername { get; } = "admin";
        public string AdminPassword { get; } = "1234";

        public void Login(string username, string password)
        {
            if (AdminUsername == username && AdminPassword == password)
            {
                Console.WriteLine("GİRİŞ UĞURLUDUR!");
            }
            else
            {
                throw new InvalidInputException("Daxil edilən istifadəçi adı və ya şifrəsi yanlışdır");
            }
        }
        public void ShowAdminBalance()
        {
            Console.WriteLine($"Adminin Balansı: {DataContext.DataContext.AdminBalance}");
        }

        public void AddManager(Manager manager)
        {
            if (Managers.Any(m => m.ManagerUsername == manager.ManagerUsername))
            {
                throw new InvalidInputException($"{manager.ManagerUsername} adlı manager daha əvvəl sistemə əlavə edilib!!!");
            }

            Managers.Add(manager);
            Console.WriteLine(manager.ToString());
            Console.WriteLine("Manager sistemə əlavə edildi");
        }


        public void RemoveManager(string managerName)
        {

            Manager manager = Managers.FirstOrDefault(m => m.ManagerUsername == managerName);

            if (manager == null)
                throw new InvalidInputException($"{managerName} adlı manager tapılmadı!!!");

            Managers.Remove(manager);
            Console.WriteLine(manager.ToString());
            Console.WriteLine($"Manager sistemdən uğurla silindi!");
        }

        public void ShowAllManager()
        {
            if (Managers.Count != 0)
            {
                Console.WriteLine("Managerlərin siyahısı:");
                foreach (Manager m in Managers)
                {
                    Console.WriteLine(m.ToString());
                }
            }
            else
            {
                throw new InvalidInputException("Sistemdə hal hazırda manager yoxdur!!!!");
            }
        }

        public void AddEmployee(Employee employee)
        {
            if (Employees.Any(e => e.EmployeeMail.Equals(employee.EmployeeMail) || e.EmployeePhoneNumber == employee.EmployeePhoneNumber))
            {
                throw new InvalidInputException($"Daxil edilən {employee.EmployeeUsername} adlı şəxsin sistemdə hal hazırda mövcud olan başqa bir işçi ilə əlaqə nömrəsinin yaxud mail adresinin eyni olduğu aşkarlandı!!!!");
            }


            Employees.Add(employee);
            Console.WriteLine(employee.ToString());
            Console.WriteLine("İşçi sistemə əlavə edildi");
        }

        public void RemoveEmployee(string employeeName)
        {
            Employee employee = Employees.FirstOrDefault(e => e.EmployeeUsername == employeeName);

            if (employee == null)
                throw new InvalidInputException($"{employee.EmployeeUsername} adlı işçi tapılmadı!!!");

            Employees.Remove(employee);
            Console.WriteLine(employee.ToString());
            Console.WriteLine($"İşçi sistemdən uğurla silindi!");
        }

        public void ShowAllEmployee()
        {
            Console.WriteLine("İşçilərin siyahısı:");
            if (Employees.Count != 0)
            {
                foreach (Employee e in Employees)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            else
            {
                throw new InvalidInputException("Sistemdə hal hazırda işçi yoxdur!!!!");
            }
        }

        public void ReservationForAdmin(Reservation reservation)
        {
            if (Reservations.Any(r => r.ReservedTable.TableNumber == reservation.ReservedTable.TableNumber
               && r.ReservationDate == reservation.ReservationDate
               && r.Status == ReservationStatus.Confirmed))
            {
                throw new ReservationException($"{reservation.ReservedTable.TableNumber} nömrəli masa {reservation.Customer.UserName} adlı şəxs tərəfindən {reservation.ReservationDate} tarix üçün rezerv edilib!!!");
            }
            else
            {
                Reservations.Add(reservation);
                reservation.Status = ReservationStatus.Confirmed;
                reservation.ReservedTable.TableStatus = TableStatus.Reserved;
                Console.WriteLine($"Hörmətli admin: {reservation.ReservationDate} tarix üçün rezerviniz {reservation.ReservationId} ID sistemə qeyd edildi, masa haqqında ümumi məlumat aşağıdakı kimidir:");
                Console.WriteLine();
                Console.WriteLine(reservation.ReservedTable.ToString());
                Console.WriteLine();
            }
        }

        public void ReservationForAdminCancel(int? reservationID)
        {
            var reservation = Reservations.FirstOrDefault(r => r.ReservationId == reservationID);
            if (reservation == null)
                throw new ReservationException($"Belə {reservationID} ID-li rezervasiya tapılmadı!");


            reservation.Status = ReservationStatus.Cancelled;
            reservation.ReservedTable.TableStatus = TableStatus.Available; // Masa boşalır
            Reservations.Remove(reservation);
            Console.WriteLine($"Rezervasiya ID {reservationID} uğurla ləğv edildi.");
        }

        public List<Table> ListAllEmptyTables()
        {
            return Tables
               .Where(t => t.TableStatus == TableStatus.Available)
               .ToList();
        }

        public List<Table> ListAllTables()
        {
            return Tables.ToList();
        }
    }
}
