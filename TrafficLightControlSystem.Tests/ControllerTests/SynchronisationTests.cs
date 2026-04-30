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
        public void NorthSouthPair_ShouldShowTheSameSignalForNorthAndSouth()
        { 
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);

            Assert.Equal(controller.North, controller.South);
        }

        [Fact]
        public void EastWestPair_ShouldShowTheSameSignalForEastAndWest()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.EastWest);

            Assert.Equal(controller.East, controller.West);
        }
    }
}
