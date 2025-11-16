using Restoran_console_appp.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_console_appp.Models
{
    public class Table
    {
        private static int _unicTableID = 0;
        public int TableID { get; set; }
        public int TableNumber { get; set; }
        public int TableCapacity { get; set; }
        public TableStatus TableStatus { get; set; }
        /// <summary>
        /// Manager üçün stol yaratma ctoru
        /// </summary>
        /// <param name="tableNum"></param>
        /// <param name="tableCapacity"></param>
        public Table(int tableNum, int tableCapacity)
        {
            TableID = ++_unicTableID;
            TableStatus = TableStatus.Available;
            TableCapacity = tableCapacity;
            TableNumber = tableNum;
        }
        /// <summary>
        /// İstifadəçi üçün stol seçmə ctoru
        /// </summary>
        /// <param name="tableNum"></param>
        public Table(int tableNum)
        {
            TableID = ++_unicTableID;
            TableStatus = TableStatus.Available;
            TableNumber = tableNum;
        }
        public override string ToString()
        {
            string rezervasiyaStatus = TableStatus == TableStatus.Reserved ? "Rezerv" : "Boş";
            return $"Masanın ID: {TableID}, Nömrəsi: {TableNumber}, Tutumu: {TableCapacity}, Rezervasiya statusu: {rezervasiyaStatus}";
        }
    }
}
