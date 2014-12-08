using AutoReservation.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace AutoReservation.BusinessLayer
{
    public class AutoReservationBusinessComponent
    {

        private static void HandleDbConcurrencyException<T>(AutoReservationEntities context, T original) where T : class
        {
            var databaseValue = context.Entry(original).GetDatabaseValues();
            context.Entry(original).CurrentValues.SetValues(databaseValue);

            throw new LocalOptimisticConcurrencyException<T>(string.Format("Update {0}: Concurrency-Fehler", typeof(T).Name), original);
        }


        public List<Kunde> Kunden()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                return context.Kunden.ToList();
            }
        }

        public List<Auto> Autos()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                return context.Autos.ToList();
            }
        }

        public List<Reservation> Reservationen()
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                return context.Reservationen.Include(r => r.Auto).Include(r => r.Kunde).ToList();
            }
        }

        public Kunde GetKundeById(int kundeId)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                Kunde kunde = context.Kunden.SingleOrDefault(r => r.Id == kundeId);
                return kunde;
            }
        }

        public Auto GetAutoById(int autoId)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                Auto auto = context.Autos.SingleOrDefault(r => r.Id == autoId);
                return auto;
            }
        }

        public Reservation GetReservationById(int reservationId)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                Reservation reservation = context.Reservationen.Include(r => r.Auto).Include(r => r.Kunde).SingleOrDefault(r => r.ReservationNr == reservationId);
                return reservation;
            }
        }

        public void InsertKunde(Kunde kunde)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Kunden.Add(kunde);
            }
        }

        public void InsertAuto(Auto auto)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Autos.Add(auto);
            }
        }

        public void InsertReservation(Reservation reservation)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Reservationen.Add(reservation);
            }
        }

        public void UpdateKunde(Kunde modified, Kunde original)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                try
                {
                    context.Kunden.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }

        public void UpdateAuto(Auto modified, Auto original)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                try
                {
                    context.Autos.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }

        public void UpdateReservation(Reservation modified, Reservation original)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                try
                {
                    context.Reservationen.Attach(original);
                    context.Entry(original).CurrentValues.SetValues(modified);
                    context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    HandleDbConcurrencyException(context, original);
                }
            }
        }

        public void DeleteKunde(Kunde kunde)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Kunden.Attach(kunde);
                context.Kunden.Remove(kunde);
                context.SaveChanges();
            }
        }

        public void DeleteAuto(Auto auto)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Autos.Attach(auto);
                context.Autos.Remove(auto);
                context.SaveChanges();
            }
        }

        public void DeleteReservation(Reservation reservation)
        {
            using (AutoReservationEntities context = new AutoReservationEntities())
            {
                context.Reservationen.Attach(reservation);
                context.Reservationen.Remove(reservation);
                context.SaveChanges();
            }
        }

    }
}