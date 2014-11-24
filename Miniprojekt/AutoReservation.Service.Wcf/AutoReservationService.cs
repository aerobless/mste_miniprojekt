using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {
        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        public List<KundeDto> Kunden()
        {
            throw new NotImplementedException();
        }

        public List<AutoDto> Autos()
        {
            throw new NotImplementedException();
        }

        public List<ReservationDto> Reservationen()
        {
            throw new NotImplementedException();
        }

        public List<KundeDto> GetKunde(int kundeId)
        {
            throw new NotImplementedException();
        }

        public List<AutoDto> GetAuto(int autoId)
        {
            throw new NotImplementedException();
        }

        public List<ReservationDto> GetReservation(int reservationId)
        {
            throw new NotImplementedException();
        }

        public KundeDto InsertKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public AutoDto InsertAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public ReservationDto InsertReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }

        public KundeDto UpdateKunde(KundeDto modified, KundeDto original)
        {
            throw new NotImplementedException();
        }

        public AutoDto UpdateAuto(AutoDto modified, AutoDto original)
        {
            throw new NotImplementedException();
        }

        public ReservationDto UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            throw new NotImplementedException();
        }

        public KundeDto DeleteKunde(KundeDto kunde)
        {
            throw new NotImplementedException();
        }

        public AutoDto DeleteAuto(AutoDto auto)
        {
            throw new NotImplementedException();
        }

        public ReservationDto DeleteReservation(ReservationDto reservation)
        {
            throw new NotImplementedException();
        }
    }
}