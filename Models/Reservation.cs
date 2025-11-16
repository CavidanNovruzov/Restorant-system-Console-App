using Restoran_console_appp.Exceptions;
using Restoran_console_appp.Interfaces;
using Restoran_console_appp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restoran_console_appp.Enum;

namespace Restoran_console_appp.Models
{
    public class Reservation
    {
        private static int _uniqueReservationId = 0;
        public int ReservationId { get; }
        public User? Customer { get; set; }
        public Table ReservedTable { get; set; }
        public decimal? Price { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; }
        /// <summary>
        /// Müştəri üçün rezervasiya konstrokturu
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="table"></param>
        /// <param name="price"></param>
        /// <param name="date"></param>
        public Reservation(User customer, Table table, DateTime date)
        {
            ReservationId = ++_uniqueReservationId;
            Customer = customer;
            ReservedTable = table;
            ReservationDate = date;
            Status = ReservationStatus.Pending;
            table.TableStatus = TableStatus.Pending;

            Price = PriceSet(table.TableNumber);
        }
        /// <summary>
        /// Admin üçün rezervasiya konstrokturu
        /// </summary>
        /// <param name="table"></param>
        /// <param name="date"></param>
        public Reservation(Table table, DateTime date)
        {
            ReservationId = ++_uniqueReservationId;
            ReservedTable = table;
            ReservationDate = date;
            Status = ReservationStatus.Pending;
            table.TableStatus = TableStatus.Pending;
            Price = null;
        }
        public override string ToString()
        {
            string customerName = Customer != null ? Customer.UserName : "Admin tərəfindən əlavə olunub";
            return $"Rezervasiya ID: {ReservationId}, Müştəri: {customerName}, Masa: {ReservedTable.TableNumber}, Qiymət: {Price}, Tarix: {ReservationDate}, Status: {Status}";
        }

        decimal PriceSet(int tableNumber)
        {
            decimal price = tableNumber switch
            {
                1 or 2 or 3 => 50,
                4 or 5 => 60,
                6 or 7 => 70,
                8 or 9 => 80,
                10 or 11 => 90,
                12 or 13 => 100,
                14 or 15 => 110,
                16 or 17 => 120,
                18 or 19 => 130,
                20 or 21 or 22 => 140,
                _ => throw new ArgumentOutOfRangeException(nameof(tableNumber), "Yalnız 1–22 arası masa ola bilər.")
            };

            return price;
        }
    }
}