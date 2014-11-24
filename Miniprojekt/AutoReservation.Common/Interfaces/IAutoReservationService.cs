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

        List<KundeDto> GetKunde(int kundeId);
        List<AutoDto> GetAuto(int autoId);
        List<ReservationDto> GetReservation(int reservationId);

        KundeDto InsertKunde(KundeDto kunde);
        AutoDto InsertAuto(AutoDto auto);
        ReservationDto InsertReservation(ReservationDto reservation);

        KundeDto UpdateKunde(KundeDto modified, KundeDto original);
        AutoDto UpdateAuto(AutoDto modified, AutoDto original);
        ReservationDto UpdateReservation(ReservationDto modified, ReservationDto original);

        KundeDto DeleteKunde(KundeDto kunde);
        AutoDto DeleteAuto(AutoDto auto);
        ReservationDto DeleteReservation(ReservationDto reservation);
    }
}
