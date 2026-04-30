using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using TrafficLightControlSystem.Core;

namespace TrafficLightControlSystem.Tests
{
    public sealed class TrafficLightControllerTests
    {
        [Fact]
        public void NewController_StartsWithBothDirectionsRed()
        {
            var controller = new TrafficLightController();

            Assert.Equal(Signal.Red, controller.NorthSouth);
            Assert.Equal(Signal.Red, controller.EastWest);
        }

        [Fact]
        public void ChangeToNextSignal_WhenNorthSouthIsRed_ChangesToRedAmber()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);

            Assert.Equal(Signal.RedAmber, controller.NorthSouth);
            Assert.Equal(Signal.Red, controller.EastWest);
        }

        [Fact]
        public void ChangeToNextSignal_WhenNorthSouthIsRedAmber_ChangesToGreen()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);

            Assert.Equal(Signal.Green, controller.NorthSouth);
            Assert.Equal(Signal.Red, controller.EastWest);
        }

        [Fact]
        public void ChangeToNextSignal_WhenNorthSouthIsGreen_ChangesToAmber()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);

            Assert.Equal(Signal.Amber, controller.NorthSouth);
            Assert.Equal(Signal.Red, controller.EastWest);
        }
    }
}
