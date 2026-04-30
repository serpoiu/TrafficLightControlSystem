using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightControlSystem.Core;

namespace TrafficLightControlSystem.Tests.ControllerTests
{
    public class TimingTests
    {
        [Fact]
        public void RedAmber_ShouldNotChangeBeforeOnePointSeconds()
        { 
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.Tick(TimeSpan.FromSeconds(1));

            Assert.Equal(Signal.RedAmber, controller.NorthSouth);
        }

        [Fact]
        public void RedAmber_ShouldChangeAfterOnePointSeconds()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.Tick(TimeSpan.FromSeconds(1.5));

            Assert.Equal(Signal.Green, controller.NorthSouth);
        }
    }
}
