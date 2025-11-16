using Restoran_console_appp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restoran_console_appp.Interfaces
{
    public interface IUser
    {
        public User Login(string username, string password);
        public void UserReservation(Reservation reservation);
        public void UserReservationCancel(int? reservationID);
        public List<Table> ListAllTables();
    }
}
