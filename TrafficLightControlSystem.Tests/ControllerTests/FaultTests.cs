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

        [Fact]
        public void FaultState_ShouldNotRecoverAutomatecally()
        {
            var controller = new TrafficLightController();

            controller.TriggerSignalProgressionFailure();
            controller.Tick(TimeSpan.FromSeconds(60));
            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.Tick(TimeSpan.FromSeconds(60));
            controller.ChangeToNextSignal(Direction.EastWest);

            Assert.Equal(Signal.Off, controller.NorthSouth);
            Assert.Equal(Signal.Off, controller.EastWest);
            Assert.True(controller.HasFault);
        }
    }
}
