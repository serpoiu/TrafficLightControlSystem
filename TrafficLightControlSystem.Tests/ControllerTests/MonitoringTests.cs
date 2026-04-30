using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightControlSystem.Core;

namespace TrafficLightControlSystem.Tests.ControllerTests
{
    public class MonitoringTests
    {
        [Fact]
        public void Controller_ShouldExposeCurrentSignalStates()
        { 
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);

            Assert.Equal(Signal.RedAmber, controller.NorthSouth);
            Assert.Equal(Signal.Red, controller.EastWest);
        }

        [Fact]
        public void Controller_ShouldExposeSensorFailureStatus()
        {
            var controller = new TrafficLightController();

            controller.TriggerSensorFailure();

            Assert.True(controller.SensorFaultAlert);
        }

        [Fact]
        public void Controller_ShouldExposePedestrianRequestStatus()
        {
            var controller = new TrafficLightController();

            controller.RequestPedestrianCrossing();
            
            Assert.True(controller.HasPendingPedestrianRequest);
        }
    }
}
