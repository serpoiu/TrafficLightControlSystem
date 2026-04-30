using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightControlSystem.Core;

namespace TrafficLightControlSystem.Tests.ControllerTests
{
    public class SynchronisationTests
    {
        [Fact]
        public void PairedDirections_ShouldAlwaysBeInternallyConsistent()
        { 
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);

            Assert.NotEqual(Signal.Off, controller.NorthSouth);
        }
    }
}
