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

        [Fact]
        public void ChangeToNextSignal_WhenNorthSouthIsAmber_ChangesToRed()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);

            Assert.Equal(Signal.Red, controller.NorthSouth);
            Assert.Equal(Signal.Red, controller.EastWest);
        }

        [Fact]
        public void ChangeToNextSignal_WhenEastWestIsRed_ChangesToRedAmber()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.EastWest);

            Assert.Equal(Signal.Red, controller.NorthSouth);
            Assert.Equal(Signal.RedAmber, controller.EastWest);
        }

        [Fact]
        public void ChangeToNextSignal_WhenEastWestIsRedAmber_ChangesToGreen()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.EastWest);
            controller.ChangeToNextSignal(Direction.EastWest);

            Assert.Equal(Signal.Red, controller.NorthSouth);
            Assert.Equal(Signal.Green, controller.EastWest);
        }

        [Fact]
        public void ChangeToNextSignal_WhenEastWestIsGreen_ChangesToAmber()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.EastWest);
            controller.ChangeToNextSignal(Direction.EastWest);
            controller.ChangeToNextSignal(Direction.EastWest);

            Assert.Equal(Signal.Red, controller.NorthSouth);
            Assert.Equal(Signal.Amber, controller.EastWest);
        }
    }
}
