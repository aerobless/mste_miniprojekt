using AutoReservation.Common.Interfaces;
using System;
using System.Diagnostics;
using AutoReservation.Common.DataTransferObjects;
using System.Collections.Generic;
using AutoReservation.BusinessLayer;
using AutoReservation.Service.Wcf;
using System.ServiceModel;
using AutoReservation.Dal;

namespace AutoReservation.Service.Wcf
{
    public class AutoReservationService : IAutoReservationService
    {

        private AutoReservationBusinessComponent businessLayer = new AutoReservationBusinessComponent();

        private static void WriteActualMethod()
        {
            Console.WriteLine("Calling: " + new StackTrace().GetFrame(1).GetMethod().Name);
        }

        List<KundeDto> IAutoReservationService.Kunden
        {
            get
            {
                WriteActualMethod();
                return DtoConverter.ConvertToDtos(businessLayer.Kunden());
            }
        }

        List<AutoDto> IAutoReservationService.Autos
        {
            get
            {
                WriteActualMethod();
                return DtoConverter.ConvertToDtos(businessLayer.Autos());
            }
        }

        List<ReservationDto> IAutoReservationService.Reservationen
        {
            get
            {
                WriteActualMethod();
                return DtoConverter.ConvertToDtos(businessLayer.Reservationen());
            }
        }

        public KundeDto GetKundeById(int kundeId)
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDto(businessLayer.GetKundeById(kundeId));
        }

        public AutoDto GetAutoById(int autoId)
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDto(businessLayer.GetAutoById(autoId));
        }

        public ReservationDto GetReservationById(int reservationId)
        {
            WriteActualMethod();
            return DtoConverter.ConvertToDto(businessLayer.GetReservationById(reservationId));
        }

        public void InsertKunde(KundeDto kunde)
        {
            WriteActualMethod();
            DtoConverter.ConvertToEntity(kunde);

        }

        public void InsertAuto(AutoDto auto)
        {
            WriteActualMethod();
            DtoConverter.ConvertToEntity(auto);
        }

        public void InsertReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            DtoConverter.ConvertToEntity(reservation);
        }

        public void UpdateKunde(KundeDto modified, KundeDto original)
        {
            WriteActualMethod();
            try
            {
                businessLayer.UpdateKunde(DtoConverter.ConvertToEntity(modified), DtoConverter.ConvertToEntity(original));
            }
            catch (LocalOptimisticConcurrencyException<Kunde> e)
            {
                throw new FaultException<KundeDto>(e.MergedEntity.ConvertToDto(), "kundeAuto failed");
            }
        }

        public void UpdateAuto(AutoDto modified, AutoDto original)
        {
            WriteActualMethod();
            try
            {
                businessLayer.UpdateAuto(DtoConverter.ConvertToEntity(modified), DtoConverter.ConvertToEntity(original));
            }
            catch (LocalOptimisticConcurrencyException<Auto> e)
            {
                throw new FaultException<AutoDto>(e.MergedEntity.ConvertToDto(), "updateAuto failed");
            }

        }

        public void UpdateReservation(ReservationDto modified, ReservationDto original)
        {
            WriteActualMethod();
            try
            {
                businessLayer.UpdateReservation(DtoConverter.ConvertToEntity(modified), DtoConverter.ConvertToEntity(original));
            }
            catch (LocalOptimisticConcurrencyException<Reservation> e)
            {
                throw new FaultException<ReservationDto>(e.MergedEntity.ConvertToDto(), "updateReservation failed");
            }
        }

        public void DeleteKunde(KundeDto kunde)
        {
            WriteActualMethod();
            businessLayer.DeleteKunde(DtoConverter.ConvertToEntity(kunde));
        }

        public void DeleteAuto(AutoDto auto)
        {
            WriteActualMethod();
            businessLayer.DeleteAuto(DtoConverter.ConvertToEntity(auto));
        }

        public void DeleteReservation(ReservationDto reservation)
        {
            WriteActualMethod();
            businessLayer.DeleteReservation(DtoConverter.ConvertToEntity(reservation));
        }

    }
}