using AutoReservation.TestEnvironment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AutoReservation.Dal;
using AutoReservation.BusinessLayer;

namespace AutoReservation.BusinessLayer.Testing
{
    [TestClass]
    public class BusinessLayerTest
    {
        private AutoReservationBusinessComponent target;
        private AutoReservationBusinessComponent Target
        {
            get
            {
                if (target == null)
                {
                    target = new AutoReservationBusinessComponent();
                }
                return target;
            }
        }

        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }
        
        [TestMethod]
        public void UpdateAutoTest()
        {
            string googleCar = "Google Car";
            Auto someCar = Target.GetAutoById(1);
            someCar.Marke = googleCar;

            Auto originalCar = Target.GetAutoById(1);
            Target.UpdateAuto(someCar, originalCar);

            Auto updatedCar = Target.GetAutoById(1);
            Assert.AreEqual(googleCar, updatedCar.Marke);
        }

        [TestMethod]
        public void UpdateKundeTest()
        {
            string marco = "Marco";
            string syfrig = "Syfrig";

            Kunde notMarcoSyfrig = Target.GetKundeById(1);

            notMarcoSyfrig.Vorname = marco;
            notMarcoSyfrig.Nachname = syfrig;

            Kunde original = Target.GetKundeById(1);
            Target.UpdateKunde(notMarcoSyfrig, original);

            Kunde marcoSyfrig = Target.GetKundeById(1);
            Assert.AreEqual(marcoSyfrig.Vorname, marco);
            Assert.AreEqual(marcoSyfrig.Nachname, syfrig);
        }

        [TestMethod]
        public void UpdateReservationTest()
        {
            DateTime dateTo = DateTime.Now;
            Reservation reservation = Target.GetReservationById(1);
            reservation.Bis = dateTo;

            Reservation original = Target.GetReservationById(1);
            Target.UpdateReservation(reservation, original);

            Reservation result = Target.GetReservationById(1);
            Assert.AreEqual(dateTo.ToShortDateString(), result.Bis.ToShortDateString());
        }

    }
}
