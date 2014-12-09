using AutoReservation.TestEnvironment;
using AutoReservation.Ui.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Input;

namespace AutoReservation.Ui.Testing
{
    [TestClass]
    public class ViewModelTest
    {
        [TestInitialize]
        public void InitializeTestData()
        {
            TestEnvironmentHelper.InitializeTestData();
        }

        [TestMethod]
        public void AutosLoadTest()
        {
            AutoViewModel autoViewModel = new AutoViewModel();
            var loadCMD = autoViewModel.LoadCommand;
            var cars = autoViewModel.Autos;
            Assert.IsTrue(loadCMD.CanExecute(null));
            Assert.IsTrue(cars.Count == 3);
        }

        [TestMethod]
        public void KundenLoadTest()
        {
            KundeViewModel kundenViewModel = new KundeViewModel();
            var loadCMD = kundenViewModel.LoadCommand;
            var customers = kundenViewModel.Kunden;
            Assert.IsTrue(loadCMD.CanExecute(null));
            Assert.IsTrue(customers.Count == 4);
        }

        [TestMethod]
        public void ReservationenLoadTest()
        {
            ReservationViewModel reservationViewModel = new ReservationViewModel();
            var loadCMD = reservationViewModel.LoadCommand;
            var reservations = reservationViewModel.Reservationen;
            Assert.IsTrue(loadCMD.CanExecute(null));
            Assert.IsTrue(reservations.Count == 3);
        }
    }
}