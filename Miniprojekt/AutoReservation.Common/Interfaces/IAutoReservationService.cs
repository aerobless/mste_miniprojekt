using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.DataTransferObjects;

namespace AutoReservation.Common.Interfaces
{
    [ServiceContract]
    public interface IAutoReservationService
    {
        List<KundeDto> Kunden
        {
            [OperationContract]
            get;
        }
        List<AutoDto> Autos
        {
            [OperationContract]
            get;
        }
        List<ReservationDto> Reservationen
        {
            [OperationContract]
            get;
        }

        [OperationContract]
        KundeDto GetKundeById(int kundeId);
        [OperationContract]
        AutoDto GetAutoById(int autoId);
        [OperationContract]
        ReservationDto GetReservationById(int reservationId);

        [OperationContract]
        void InsertKunde(KundeDto kunde);
        [OperationContract]
        void InsertAuto(AutoDto auto);
        [OperationContract]
        void InsertReservation(ReservationDto reservation);

        [OperationContract]
        [FaultContract(typeof(KundeDto))]
        void UpdateKunde(KundeDto modified, KundeDto original);
        [OperationContract]
        [FaultContract(typeof(AutoDto))]
        void UpdateAuto(AutoDto modified, AutoDto original);
        [OperationContract]
        [FaultContract(typeof(ReservationDto))]
        void UpdateReservation(ReservationDto modified, ReservationDto original);

        [OperationContract]
        void DeleteKunde(KundeDto kunde);
        [OperationContract]
        void DeleteAuto(AutoDto auto);
        [OperationContract]
        void DeleteReservation(ReservationDto reservation);
    }
}
