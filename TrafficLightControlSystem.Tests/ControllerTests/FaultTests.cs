using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightControlSystem.Core;

namespace TrafficLightControlSystem.Tests.ControllerTests
{
    public class FaultTests
    {
        [Fact]
        public void SignalProgressionFailure_ShouldEnterFaultOffState()
        { 
            var controller = new TrafficLightController();

            controller.TriggerSignalProgressionFailure();

            Assert.Equal(Signal.Off, controller.NorthSouth);
            Assert.Equal(Signal.Off, controller.EastWest);
            Assert.True(controller.HasFault);
        }

        [Fact]
        public void LightIlluminationFailure_ShouldEnterFaultOffState()
        {
            var controller = new TrafficLightController();

            controller.TriggerLightIlluminationFailure();

            Assert.Equal(Signal.Off, controller.NorthSouth);
            Assert.Equal(Signal.Off, controller.EastWest);
            Assert.True(controller.HasFault);
        }

        [Fact]
        public void LightDeIlluminationFailure_ShouldEnterFaultOffState()
        {
            var controller = new TrafficLightController();

            controller.TriggerLightDeIlluminationFailure();

            Assert.Equal(Signal.Off, controller.NorthSouth);
            Assert.Equal(Signal.Off, controller.EastWest);
            Assert.True(controller.HasFault);
        }
    }
}
