using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    public interface IAutoReservationService
    {
        List<KundeDto> Kunden();
        List<AutoDto> Autos();
        List<ReservationDto> Reservationen();

        KundeDto GetKundeById(int kundeId);
        AutoDto GetAutoById(int autoId);
        ReservationDto GetReservationById(int reservationId);

        void InsertKunde(KundeDto kunde);
        void InsertAuto(AutoDto auto);
        void InsertReservation(ReservationDto reservation);

        void UpdateKunde(KundeDto modified, KundeDto original);
        void UpdateAuto(AutoDto modified, AutoDto original);
        void UpdateReservation(ReservationDto modified, ReservationDto original);

        void DeleteKunde(KundeDto kunde);
        void DeleteAuto(AutoDto auto);
        void DeleteReservation(ReservationDto reservation);
    }
}
