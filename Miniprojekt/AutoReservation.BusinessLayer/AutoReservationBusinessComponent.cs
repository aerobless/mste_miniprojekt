using AutoReservation.Dal;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
//using AutoReservation.Dal;

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
            throw new NotImplementedException();
        }

        public List<Auto> Autos()
        {
            throw new NotImplementedException();
        }

        public List<Reservation> Reservationen()
        {
            throw new NotImplementedException();
        }

        public List<Kunde> GetKunde(int kundeId)
        {
            throw new NotImplementedException();
        }

        public List<Auto> GetAuto(int autoId)
        {
            throw new NotImplementedException();
        }

        public List<Reservation> GetReservation(int reservationId)
        {
            throw new NotImplementedException();
        }

        public Kunde InsertKunde(Kunde kunde)
        {
            throw new NotImplementedException();
        }

        public Auto InsertAuto(Auto auto)
        {
            throw new NotImplementedException();
        }

        public Reservation InsertReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public Kunde UpdateKunde(Kunde modified, Kunde original)
        {
            throw new NotImplementedException();
        }

        public Auto UpdateAuto(Auto modified, Auto original)
        {
            throw new NotImplementedException();
        }

        public Reservation UpdateReservation(Reservation modified, Reservation original)
        {
            throw new NotImplementedException();
        }

        public Kunde DeleteKunde(Kunde kunde)
        {
            throw new NotImplementedException();
        }

        public Auto DeleteAuto(Auto auto)
        {
            throw new NotImplementedException();
        }

        public Reservation DeleteReservation(Reservation reservation)
        {
            throw new NotImplementedException();
        }

    }
}