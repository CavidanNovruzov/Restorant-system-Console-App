using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Restoran_console_appp.DataContext;
using Restoran_console_appp.Enum;
using Restoran_console_appp.Exceptions;
using Restoran_console_appp.Interfaces;
using Restoran_console_appp.Models;

namespace Restoran_console_appp.Models
{
    public class User : IUser
    {
        List<Table> Tables => DataContext.DataContext.Tables;
        List<Reservation> Reservations => DataContext.DataContext.Reservations;
        List<User> Users => DataContext.DataContext.Users;
        private static int _unicId = 0;
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserPassword { get; set; }
        public int Age { get; set; }
        public MailAddress Email { get; set; }
        public string PhoneNumber { get; set; }
        public string CardNumber { get; set; }
        public decimal? UserBalance { get; set; }
        public User(string name, string surname, string password, int age, MailAddress email, string phoneNumber, string cardNumber, decimal userBalance)
        {
            UserId = ++_unicId;
            UserName = name;
            UserSurname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            CardNumber = cardNumber;
            UserBalance = userBalance;
            UserPassword = password;
        }
        public User(string username, string password)
        {
            UserName = username;
            UserPassword = password;
        }
        public User Login(string username, string password)
        {
            var user = Users.FirstOrDefault(u => u.UserName == username && u.UserPassword == password);
            if (user is null)
                throw new InvalidInputException("Daxil edilən istifadəçi adı və ya şifrə yanlışdır!");
            return user;
        }

        public override string ToString()
        {
            return $"Adı: {UserName}, Soyadı: {UserSurname}, Yaşı: {Age}, Email adresi: {Email}, Əlaqə nömrəsi: {PhoneNumber}";
        }


        public void UserReservation(Reservation reservation)
        {
            if (Reservations.Any(r => r.ReservedTable.TableNumber == reservation.ReservedTable.TableNumber
                                                && r.ReservationDate == reservation.ReservationDate
                                                 && r.Status == ReservationStatus.Confirmed))
            {
                throw new ReservationException($"{reservation.ReservedTable.TableNumber} nömrəli masa başqa şəxs tərəfindən {reservation.ReservationDate} tarix üçün rezerv edilib!!!");
            }

            if (reservation.Price is null)
                throw new ReservationException("Bu rezervasiyanın qiyməti təyin olunmayıb.");

            if (reservation.Customer.UserBalance is null)
                throw new ReservationException("İstifadəçinin balansı məlum deyil.");

            if (reservation.Customer.UserBalance >= reservation.Price)
            {
                reservation.Customer.UserBalance -= reservation.Price;
                DataContext.DataContext.AdminBalance += reservation.Price;
                Reservations.Add(reservation);
                reservation.Status = ReservationStatus.Confirmed;
                reservation.ReservedTable.TableStatus = TableStatus.Reserved;

                Console.WriteLine($"Hörmətli {reservation.Customer.UserName}: {reservation.ReservationDate} tarix üçün rezerviniz sistemə qeyd edildi!");
                Console.WriteLine();
                Console.WriteLine("Masa haqqında məlumat:");
                Console.WriteLine(reservation.ReservedTable.ToString());
                Console.WriteLine();
                Console.WriteLine("Rezerv məlumatı:");
                Console.WriteLine(reservation.ToString());
                Console.WriteLine();
                Console.WriteLine($"Qalan balans: {reservation.Customer.UserBalance} AZN");

                return;
            }
            else
            {
                decimal? lazimOlan = reservation.Price - reservation.Customer.UserBalance;
                throw new MoneyHasNotException(
                    $"Dəyərli {reservation.Customer.UserName}, rezerv etmək üçün balansınızda əlavə olaraq {lazimOlan} AZN çatmır!");
            }
        }
        public void UserReservationCancel(int? reservationID)
        {
            var reservation = Reservations.FirstOrDefault(r => r.ReservationId == reservationID);
            if (reservation == null)
                throw new ReservationException($"Belə {reservationID} ID-li rezervasiya tapılmadı!");

            reservation.Customer.UserBalance += reservation.Price;
            DataContext.DataContext.AdminBalance -= reservation.Price;
            reservation.Status = ReservationStatus.Cancelled;
            reservation.ReservedTable.TableStatus = TableStatus.Available;
            Reservations.Remove(reservation);
            Console.WriteLine($"Rezervasiya ID {reservationID} uğurla ləğv edildi.");
        }

        public List<Table> ListAllTables()
        {
            return Tables.ToList();
        }
    }
}
