using Restoran_console_appp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_console_appp.Interfaces
{
    //Masalar program ise dusduyunde olmasin , Manager masa daxil etmelidir.
    //Bos masalari gore bilmelidir. Butun masalari gore bilmelidir
    public interface IManager
    {
        public Manager Login(string username, string password);
        public void AddTable(Table table);
        public List<Table> ListAllEmptyTables();
        public List<Table> ListAllTables();
    }
}
