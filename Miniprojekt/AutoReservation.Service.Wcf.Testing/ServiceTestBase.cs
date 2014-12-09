using AutoReservation.Common.DataTransferObjects;
using AutoReservation.Common.Interfaces;
using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using AutoReservation.Common.Interfaces;
using AutoReservation.Dal;
using AutoReservation.BusinessLayer;
using AutoReservation.Common.Interfaces;
using AutoReservation.BusinessLayer.Testing;

namespace AutoReservation.Service.Wcf.Testing
{
    [TestClass]
    public abstract class ServiceTestBase
    {
        protected abstract IAutoReservationService Target { get; }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void AutosTest()
        {
            List<AutoDto> autos = Target.Autos;
            Assert.IsTrue(autos.Count == 3);
            Assert.AreEqual("VW Golf", autos[1].Marke);
        }

        [TestMethod]
        public void KundenTest()
        {
            List<KundeDto> kunden = Target.Kunden;
            Assert.IsTrue(kunden.Count == 4);
            Assert.AreEqual("Beil", kunden[1].Nachname);
        }

        [TestMethod]
        public void ReservationenTest()
        {
            List<ReservationDto> reservationen = Target.Reservationen;
            Assert.IsTrue(reservationen.Count == 3);
        }

        [TestMethod]
        public void GetAutoByIdTest()
        {
            AutoDto vw = Target.GetAutoById(2);
            Assert.AreEqual("VW Golf", vw.Marke);
            Assert.AreEqual(2, vw.Id);
        }

        [TestMethod]
        public void GetKundeByIdTest()
        {
            KundeDto dude = Target.GetKundeById(2);
            Assert.AreEqual("Beil", dude.Nachname);
            Assert.AreEqual("Timo", dude.Vorname);
        }

        [TestMethod]
        public void GetReservationByNrTest()
        {
            ReservationDto reservation = Target.GetReservationById(1);
            AutoDto car = reservation.Auto;
            Assert.AreEqual("Fiat Punto", car.Marke);
        }

        [TestMethod]
        public void GetReservationByIllegalNr()
        {
            ReservationDto reservation = Target.GetReservationById(666);
            Assert.IsNull(reservation);
        }

        [TestMethod]
        public void InsertAutoTest()
        {
            string brand = "Google Car";
            int cost = 99;
            AutoDto car = new AutoDto();
            car.Marke = brand;
            car.Tagestarif = cost;
            car.AutoKlasse = AutoKlasse.Mittelklasse;
            Target.InsertAuto(car);

            AutoDto checkAuto = Target.GetAutoById(4);
            Console.WriteLine(checkAuto.Marke);
            Assert.AreEqual(brand, checkAuto.Marke);
            Assert.AreEqual(cost, checkAuto.Tagestarif);
            Assert.AreEqual(AutoKlasse.Mittelklasse, checkAuto.AutoKlasse);
        }

        [TestMethod]
        public void InsertKundeTest()
        {
            string super = "Super";
            string mario = "Mario";
            DateTime birthday = DateTime.Now;
            KundeDto customer = new KundeDto();
            customer.Vorname = super;
            customer.Nachname = mario;
            customer.Geburtsdatum = birthday;
            Target.InsertKunde(customer);

            KundeDto checkCustomer = Target.GetKundeById(5);
            Assert.AreEqual(super, checkCustomer.Vorname);
            Assert.AreEqual(mario, checkCustomer.Nachname);
            Assert.AreEqual(birthday.ToShortDateString(), checkCustomer.Geburtsdatum.ToShortDateString());
        }

        [TestMethod]
        public void InsertReservationTest()
        {
            DateTime from = DateTime.Today;
            DateTime to = DateTime.Today;
            ReservationDto reservation = new ReservationDto();
            AutoDto fiat = Target.GetAutoById(1);
            KundeDto dude = Target.GetKundeById(1);
            reservation.Auto = fiat;
            reservation.Kunde = dude;
            reservation.Von = from;
            reservation.Bis = to;
            Target.InsertReservation(reservation);

            ReservationDto checkReservation = Target.GetReservationById(4);
            Assert.AreEqual(fiat.Marke, checkReservation.Auto.Marke);
            Assert.AreEqual(dude.Vorname, checkReservation.Kunde.Vorname);
            Assert.AreEqual(from, checkReservation.Von);
            Assert.AreEqual(to, checkReservation.Bis);
        }

        [TestMethod]
        public void UpdateAutoTest()
        {
            string brand = "Volvo";
            AutoDto car = Target.GetAutoById(1);
            car.Marke = brand;
            AutoDto original = Target.GetAutoById(1);
            Target.UpdateAuto(car, original);
            AutoDto checkCar = Target.GetAutoById(1);
            Assert.AreEqual(brand, checkCar.Marke);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            string donald = "Donald Duck";
            KundeDto customer = Target.GetKundeById(1);
            customer.Vorname = donald;
            KundeDto original = Target.GetKundeById(1);
            Target.UpdateKunde(customer, original);
            KundeDto checkCustomer = Target.GetKundeById(1);
            Assert.AreEqual(donald, checkCustomer.Vorname);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            AutoDto car = Target.GetAutoById(3);
            ReservationDto reservation = Target.GetReservationById(1);
            reservation.Auto = car;
            ReservationDto original = Target.GetReservationById(1);
            Target.UpdateReservation(reservation, original);
            ReservationDto checkReservation = Target.GetReservationById(1);
            Assert.AreEqual(car.Marke, checkReservation.Auto.Marke);
        }

        [TestMethod]
        public void UpdateAutoTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateKundeTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void UpdateReservationTestWithOptimisticConcurrency()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void DeleteKundeTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void DeleteAutoTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }

        [TestMethod]
        public void DeleteReservationTest()
        {
            Assert.Inconclusive("Test wurde noch nicht implementiert!");
        }
    }
}
