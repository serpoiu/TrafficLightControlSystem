using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightControlSystem.Core;

namespace TrafficLightControlSystem.Tests.ControllerTests
{
    public class IntialStateTests
    {
        [Fact]
        public void NewController_StartsWithBothDirectionsRed()
        {
            var controller = new TrafficLightController();

            Assert.Equal(Signal.Red, controller.NorthSouth);
            Assert.Equal(Signal.Red, controller.EastWest);
        }
    }
}
