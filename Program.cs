using Restoran_console_appp.DataContext;
using Restoran_console_appp.Exceptions;
using Restoran_console_appp.Interfaces;
using Restoran_console_appp.Models;
using Restoran_console_appp.Enum;
using System.Globalization;
using System.Text;

public class Program
{
    //Main Menu
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("      ===Restorant Sistemi=== ");
        Console.WriteLine("------------------------------------");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("1. Admin panel");
            Console.WriteLine("2. Manager panel");
            Console.WriteLine("3. User panel");
            Console.WriteLine("4. User Registration");
            Console.WriteLine("0. Sistemdən çıxış");
            Console.WriteLine();
            Console.Write("Seçim edin: ");
            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    AdminPanel();
                    break;
                case "2":
                    ManagerPanel();
                    break;
                case "3":
                    UserPanel();
                    break;
                case "4":
                    UserRegistration();
                    break;
                case "0":
                    Console.WriteLine("Restoran sisitemindən çıxış edilir....");
                    return;
                default:
                    Console.WriteLine("Düzgün seçim edilməmişdir!!!");
                    Console.WriteLine();
                    break;
            }
        }

    }
    //Admin Panel
    public static void AdminPanel()
    {
        Console.WriteLine("      ***Admin Panel***      ");
        Console.WriteLine("------------------------------------");
        Console.WriteLine();

        Admin admin = new Admin();

        try
        {
            Console.Write("Admin adını daxil edin: ");
            string adminName = Console.ReadLine();
            Console.Write("Admin şifrəsini daxil edin: ");
            string adminPassword = Console.ReadLine();

            admin.Login(adminName, adminPassword);
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("1. Manager əlavə etmək");
            Console.WriteLine("2. Manager silmək");
            Console.WriteLine("3. Manager'lərin siyahısı");
            Console.WriteLine("4. İşçi (Employee) əlavə etmək");
            Console.WriteLine("5. İşçini (Employee) sistemdən silmək");
            Console.WriteLine("6. İşçilərin siyahısı");
            Console.WriteLine("7. Adminin balansında olan məbləğ");
            Console.WriteLine("8. Masaların siyahısı");
            Console.WriteLine("9. Boş masaların siyahısı");
            Console.WriteLine("10. Adminin özü üçün rezervasiya etməsi");
            Console.WriteLine("11. Adminin rezervasiyasını ləvğ etməsi");
            Console.WriteLine("0. Admin paneldən çıxış");
            Console.WriteLine();
            Console.Write("Seçim edin: ");
            string choice = Console.ReadLine();
            Console.WriteLine();
            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.Write("Managerin adını daxil edin: ");
                        string managerName = Console.ReadLine();
                        Console.Write("Managerin paneldə istifadə edəcəyi şifrəsini daxil edin: ");
                        string managerPassword = Console.ReadLine();
                        admin.AddManager(new Manager(managerName, managerPassword));
                        Console.WriteLine();
                    }
                    catch (InvalidInputException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "2":
                    try
                    {
                        if (DataContext.Managers.Count == 0)
                            throw new InvalidInputException("Ümumiyyətlə sistemə manager əlavə edilməyib!!!");

                        Console.Write("Managerin adını daxil edin: ");
                        string _managerName = Console.ReadLine();
                        admin.RemoveManager(_managerName);
                        Console.WriteLine();
                    }
                    catch (InvalidInputException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;

                case "3":
                    try
                    {
                        admin.ShowAllManager();
                        Console.WriteLine();
                    }
                    catch (InvalidInputException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "4":
                    try
                    {
                        Console.Write("İşçinin adı: ");
                        string employeeName = Console.ReadLine();
                        Console.Write("Soyadı: ");
                        string employeeSurname = Console.ReadLine();
                        Console.Write("Yaşı: ");
                        int employeeAge = int.Parse(Console.ReadLine());
                        Console.Write("İşçinin peşəsi: ");
                        string employeePosition = Console.ReadLine();
                        Console.Write("Mail adresi: ");
                        string adress = Console.ReadLine();
                        Console.Write("Telefon nömrəsi: ");
                        string employeePhoneNumber = Console.ReadLine();
                        Console.Write("Maaşı: ");
                        decimal employeeSalary = decimal.Parse(Console.ReadLine());
                        admin.AddEmployee(new Employee(employeeName, employeeSurname, employeeAge, employeePosition, new System.Net.Mail.MailAddress(adress), employeePhoneNumber, employeeSalary));
                        Console.WriteLine();
                    }
                    catch (InvalidInputException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "5":
                    try
                    {
                        if (DataContext.Employees.Count == 0)
                        {
                            throw new InvalidInputException("Ümumiyyətlə sistemə işçi əlavə edilməyib!!!");
                        }


                        Console.Write("İşçinin adını daxil edin: ");
                        string _employeeName = Console.ReadLine();
                        admin.RemoveEmployee(_employeeName);
                        Console.WriteLine();
                    }
                    catch (InvalidInputException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "6":
                    try
                    {
                        admin.ShowAllEmployee();
                        Console.WriteLine();
                    }
                    catch (InvalidInputException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    break;
                case "7":
                    admin.ShowAdminBalance();
                    Console.WriteLine();
                    break;
                case "8":
                    try
                    {
                        if (DataContext.Tables.Count == 0)
                        {
                            throw new TableNotFoundException("Sistemə manager tərəfindən hələki masa əlavə edilməyib");
                        }
                        Console.WriteLine("Sistemdə olan bütün masalar:");
                        Console.WriteLine();
                        foreach (var item in admin.ListAllTables())
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                    }
                    catch (TableNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    break;
                case "9":
                    try
                    {
                        if (DataContext.Tables.Count == 0)
                        {
                            throw new TableNotFoundException("Sistemə manager tərəfindən hələki masa əlavə edilməyib");
                        }

                        Console.WriteLine("Sistemdə olan bütün boş masalar:");
                        Console.WriteLine();
                        foreach (var item in admin.ListAllEmptyTables())
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                    }
                    catch (TableNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    break;
                case "10":
                    try
                    {
                        if (DataContext.Tables.Count == 0)
                        {
                            throw new TableNotFoundException("Hal hazırda restoranda stol yoxdur. Stol Manager tərəfindən aktiv edildikdən sonra rezerv edə bilərsiniz!!!");
                        }


                        Console.Write("Masanın nömrəsi: ");
                        int tableNum = int.Parse(Console.ReadLine());
                        Table table = DataContext.Tables.FirstOrDefault(t => t.TableNumber == tableNum);
                        if (table == null)
                        {
                            throw new TableNotFoundException($"Masa {tableNum} mövcud deyil!");
                        }
                        Console.WriteLine("Rezervasiya tarixini daxil edin");
                        Console.Write("İl: "); int year = int.Parse(Console.ReadLine());
                        Console.Write("Ay: "); int month = int.Parse(Console.ReadLine());
                        Console.Write("Gün: "); int day = int.Parse(Console.ReadLine());
                        Console.Write("Saat: "); int hour = int.Parse(Console.ReadLine());
                        Console.Write("Dəqiqə: "); int minute = int.Parse(Console.ReadLine());
                        int second = 00;
                        DateTime date = new DateTime(year, month, day, hour, minute, second);

                        Console.WriteLine();
                        admin.ReservationForAdmin(new Reservation(table, date));
                        Console.WriteLine();
                    }
                    catch (InvalidInputException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (TableNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (ReservationException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    break;
                case "11":
                    try
                    {
                        Console.Write("Ləvğ ediləcək olan rezervasiyanın ID daxil edin: ");
                        int reservationID = int.Parse(Console.ReadLine());
                        admin.ReservationForAdminCancel(reservationID);
                        Console.WriteLine();
                    }
                    catch (ReservationException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    break;
                case "0":
                    Console.WriteLine("Admin Paneldən çıxış edildi....");
                    Console.WriteLine();
                    return;
                default:
                    Console.WriteLine("Düzgün seçim edilməmişdir!!!");
                    Console.WriteLine();
                    break;
            }
        }

    }
    //Manager Panel
    public static void ManagerPanel()
    {
        Console.WriteLine("      ~~~Manager Panel~~~      ");
        Console.WriteLine("------------------------------------");
        Console.WriteLine();

        Console.Write("Manager adını daxil edin: ");
        string managerName = Console.ReadLine();
        Console.Write("Manager şifrəsini daxil edin: ");
        string managerPassword = Console.ReadLine();

        Manager manager = new Manager(managerName, managerPassword);
        try
        {
            if (manager.Login(managerName, managerPassword) != null)
                Console.WriteLine("GİRİŞ UĞURLUDUR!");
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            return;
        }

        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("1. Masa açmaq");
            Console.WriteLine("2. Bütün masalara baxmaq");
            Console.WriteLine("3. Rezerv olmayan masalara baxmaq");
            Console.WriteLine("0. Manager paneldən çıxış");
            Console.WriteLine();
            Console.Write("Seçim edin: ");
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        Console.Write("Masanın nömrəsi: ");
                        int tableNum = int.Parse(Console.ReadLine());
                        Console.Write("Masanın tutumu: ");
                        int tableCapacity = int.Parse(Console.ReadLine());
                        manager.AddTable(new Table(tableNum, tableCapacity));
                        Console.WriteLine();
                    }
                    catch (TableNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    break;
                case "2":
                    try
                    {
                        if (DataContext.Tables.Count == 0)
                        {
                            throw new TableNotFoundException("Sistemə siz yaxud digər managerlər tərəfindən hələki masa əlavə edilməyib");
                        }
                        Console.WriteLine("Sistemdə olan bütün masalar:");
                        Console.WriteLine();
                        foreach (var item in manager.ListAllTables())
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                    }
                    catch (TableNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    break;
                case "3":
                    try
                    {
                        if (DataContext.Tables.Count == 0)
                        {
                            throw new TableNotFoundException("Sistemə siz yaxud digər managerlər tərəfindən hələki masa əlavə edilməyib");
                        }

                        Console.WriteLine("Sistemdə olan bütün boş masalar:");
                        Console.WriteLine();
                        foreach (var item in manager.ListAllEmptyTables())
                        {
                            Console.WriteLine(item.ToString());
                        }
                        Console.WriteLine();
                    }
                    catch (TableNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    break;
                case "0":
                    Console.WriteLine("Manager Paneldən çıxış edildi....");
                    Console.WriteLine();
                    return;
                default:
                    Console.WriteLine("Düzgün seçim edilməmişdir!!!");
                    break;
            }
        }
    }
    //User Panel
    public static void UserPanel()
    {
        Console.WriteLine("          User Panel      ");
        Console.WriteLine("------------------------------------");
        Console.WriteLine();
        User user;

        Console.Write("İstifadəçi adını daxil edin: ");
        string name = Console.ReadLine();
        Console.Write("İstifadəçi şifrəsini daxil edin: ");
        string pass = Console.ReadLine();

        try
        {
            user = new User(name, pass).Login(name, pass); 
            Console.WriteLine("GİRİŞ UĞURLUDUR!");
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();
            return;
        }

        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("1. Bütün masalara baxmaq");
            Console.WriteLine("2. Rezervasiya etmək");
            Console.WriteLine("3. Rezervasiyanı ləğv etmək");
            Console.WriteLine("0. Çıxış etmək");
            Console.Write("Seçim edin: ");
            Console.WriteLine();
            string choice = Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    try
                    {
                        if (DataContext.Tables.Count == 0)
                        {
                            throw new TableNotFoundException("Sistemə hələki masa əlavə edilməyib");
                        }
                        Console.WriteLine("Sistemdə olan bütün masalar:");
                        Console.WriteLine();
                        DataContext.SyncTableStatuses();
                        foreach (var table in DataContext.Tables)
                        {
                            Console.WriteLine(table);
                        }

                        Console.WriteLine();
                    }
                    catch (TableNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    break;
                case "2":
                    try
                    {
                        if (DataContext.Tables.Count == 0)
                        {
                            throw new TableNotFoundException("Hal hazırda restoranda stol yoxdur. Stollar Manager tərəfindən aktiv edildikdən sonra rezerv edə bilərsiniz!!!");
                        }

                        Console.WriteLine(@" Rezervasiya qiymətləri aşağıdakı kimidir:
                            ~2-4 nəfər => 50 manat, 
                            ~4-6 nəfər => 60 manat, 
                            ~6-8 nəfər => 70 manat, 
                            ~8-10 nəfər => 80 manat,  
                            ~10-12 nəfər => 90 manat,
                            ~12-14 nəfər => 100 manat,
                            ~14-16 nəfər => 110 manat,
                            ~16-18 nəfər => 120 manat,
                            ~18-20 nəfər => 130 manat, 
                            ~20-22 nəfər => 140 manat");
                        Console.WriteLine();
                        Console.Write("Masanın nömrəsi: ");
                        int tableNum = int.Parse(Console.ReadLine());

                        Table table = DataContext.Tables.FirstOrDefault(t => t.TableNumber == tableNum);

                        if (table == null)
                        {
                            throw new TableNotFoundException($"Masa {tableNum} mövcud deyil!");
                        }

                        Console.WriteLine("Rezervasiya tarixini daxil edin");
                        Console.Write("İl: "); int year = int.Parse(Console.ReadLine());
                        Console.Write("Ay: "); int month = int.Parse(Console.ReadLine());
                        Console.Write("Gün: "); int day = int.Parse(Console.ReadLine());
                        Console.Write("Saat: "); int hour = int.Parse(Console.ReadLine());
                        Console.Write("Dəqiqə: "); int minute = int.Parse(Console.ReadLine());
                        int second = 00;
                        DateTime date = new DateTime(year, month, day, hour, minute, second);
                        Console.WriteLine();
                        user.UserReservation(new Reservation(user, table, date));
                    }
                    catch (InvalidInputException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (TableNotFoundException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (ReservationException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    break;
                case "3":
                    try
                    {
                        Console.Write("Ləvğ ediləcək olan rezervasiyanın ID daxil edin: ");
                        int reservationID = int.Parse(Console.ReadLine());
                        user.UserReservationCancel(reservationID);
                        Console.WriteLine();
                    }
                    catch (ReservationException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.WriteLine();
                    }
                    break;
                case "0":
                    Console.WriteLine("User Paneldən çıxış edildi....");
                    Console.WriteLine();
                    return;
                default:
                    Console.WriteLine("Düzgün seçim edilməmişdir!!!");
                    break;
            }
        }
    }
    //User Registration
    public static void UserRegistration()
    {
        Console.WriteLine("          User Registration      ");
        Console.WriteLine("------------------------------------");
        Console.WriteLine("Aşağıdakı məlumatlar hissəsini doldurun");
        Console.WriteLine();
        try
        {
            Console.Write("AD: "); string name = Console.ReadLine();
            Console.Write("SOYAD: "); string surname = Console.ReadLine();
            Console.Write("ŞİFRƏ: "); string password = Console.ReadLine();
            Console.Write("YAŞ: "); int age = int.Parse(Console.ReadLine());
            Console.Write("MAİL ADRESİ: "); string address = Console.ReadLine();
            Console.Write("TELEFON NÖMRƏSİ: "); string phoneNumber = Console.ReadLine();
            Console.Write("BANK KARTI NÖMRƏSİ: "); string cardNumber = Console.ReadLine();
            Console.Write("BALANS: "); decimal userBalance = Convert.ToDecimal(Console.ReadLine());

            User user = new User(name, surname, password, age, new System.Net.Mail.MailAddress(address), phoneNumber, cardNumber, userBalance);

            if (DataContext.Users.Any(u => u.UserPassword == user.UserPassword && u.PhoneNumber == user.PhoneNumber && u.Email == user.Email && u.CardNumber == user.CardNumber))
            {
                throw new UserNotFoundException($"Daxil etdiyiniz məlumatlar (şifrə, telefon nömrəsi, email, bank kartı və s) sistemə başqa istifadəçi tərəfindən daha əvvəl qeydiyyatı aparılmışdır!!!");
            }

            DataContext.Users.Add(user);
            Console.WriteLine("Qeydiyyatdan uğurla keçdiniz...");
            Console.WriteLine();
        }
        catch (UserNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();
        }
    }
}