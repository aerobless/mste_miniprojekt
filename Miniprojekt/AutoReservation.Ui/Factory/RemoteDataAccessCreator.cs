using AutoReservation.Common.Interfaces;
using AutoReservation.Service.Wcf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace AutoReservation.Ui.Factory
{
    public class RemoteDataAccessCreator : Creator
    {
        public override IAutoReservationService CreateInstance()
        {
            return new ChannelFactory<IAutoReservationService>("AutoReservationService").CreateChannel();
        }
    }
}
