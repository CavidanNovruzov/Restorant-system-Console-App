using Restoran_console_appp.Exceptions;
using Restoran_console_appp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran_console_appp.Enum;

namespace Restoran_console_appp.Models
{
    public class Manager : IManager
    {
        List<Table> Tables => DataContext.DataContext.Tables;
        List<Manager> Managers => DataContext.DataContext.Managers;

        private static int _unicManagerId = 0;
        public int ManagerId { get; set; }
        public string ManagerUsername { get; init; }
        public string ManagerPassword { get; init; }
        public Manager(string managerUsername, string managerPassword)
        {
            ManagerId = ++_unicManagerId;
            ManagerUsername = managerUsername;
            ManagerPassword = managerPassword;
        }
        public Manager Login(string username, string password)
        {
            var manager = Managers.FirstOrDefault(m => m.ManagerUsername == username && m.ManagerPassword == password);
            if (manager is null)
                throw new InvalidInputException("Daxil edilən istifadəçi adı və ya şifrə yanlışdır!");
            return manager;
        }

        public override string ToString()
        {
            return $"ID: {ManagerId}, Managerin adı: {ManagerUsername}";
        }

        public void AddTable(Table table)
        {
            if (Tables.Any(t => t.TableNumber == table.TableNumber))
            {
                throw new TableNotFoundException($"{table.TableNumber} nömrəli masa sistemdə mövcuddur!!!");
            }
            else
            {
                Tables.Add(table);
                Console.WriteLine(table.ToString());
                Console.WriteLine("Masa sistemə əlavə edildi!");
            }
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
