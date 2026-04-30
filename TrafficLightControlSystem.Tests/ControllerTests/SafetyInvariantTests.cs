using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightControlSystem.Core;

namespace TrafficLightControlSystem.Tests.ControllerTests
{
    public class SafetyInvariantTests
    {
        [Fact]
        public void ChangeToNextSignal_WhenNorthSouthBecomesActive_EastWestRemainsRed()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);

            bool northSouthActive =
                controller.NorthSouth == Signal.RedAmber ||
                controller.NorthSouth == Signal.Green ||
                controller.NorthSouth == Signal.Amber;

            if (northSouthActive)
            {
                Assert.Equal(Signal.Red, controller.EastWest);
            }
        }

        [Fact]
        public void ChangeToNextSignal_WhenEastWestBecomesActive_NorthSouthRemainsRed()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.EastWest);

            bool eastWestActive =
                controller.EastWest == Signal.RedAmber ||
                controller.EastWest == Signal.Green ||
                controller.EastWest == Signal.Amber;

            if (eastWestActive)
            {
                Assert.Equal(Signal.Red, controller.NorthSouth);
            }
        }

        [Fact]
        public void ChangeToNextSignal_WhenOpposingDirectionIsActive_DoesNotAllowConflictingFlow()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);

            controller.ChangeToNextSignal(Direction.EastWest);

            Assert.Equal(Signal.RedAmber, controller.NorthSouth);
            Assert.Equal(Signal.Red, controller.EastWest);
        }
    }
}

