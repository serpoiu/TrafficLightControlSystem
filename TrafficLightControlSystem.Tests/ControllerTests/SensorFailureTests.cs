using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightControlSystem.Core;

namespace TrafficLightControlSystem.Tests.ControllerTests
{
    public class SensorFailureTests
    {
        [Fact]
        public void SensorFailure_ShouldLimitGreenToThirtySeconds()
        { 
            var controller = new TrafficLightController();

            controller.TriggerSensorFailure();

            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);

            controller.Tick(TimeSpan.FromSeconds(30));

            Assert.Equal(Signal.Amber, controller.NorthSouth);
        }

        [Fact]
        public void SensorFailure_ShouldRaiseSensorFaultAlert()
        {
            var controller = new TrafficLightController();

            controller.TriggerSensorFailure();

            Assert.True(controller.SensorFaultAlert);
        }

        [Fact]
        public void SensorFailure_ShouldOverrideNoTrafficCondition()
        {
            var controller = new TrafficLightController();

            controller.SetOpposingTraffic(false);
            controller.TriggerSensorFailure();

            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);

            controller.Tick(TimeSpan.FromSeconds(30));

            Assert.Equal(Signal.Amber, controller.NorthSouth);
        }
    }
}
