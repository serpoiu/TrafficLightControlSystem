using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightControlSystem.Core;

namespace TrafficLightControlSystem.Tests.ControllerTests
{
    public class SystemSafetyTests
    {
        [Fact]
        public void System_ShouldNeveAllowBothDirectionsGreen()
        { 
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);

            controller.ChangeToNextSignal(Direction.EastWest);
            controller.ChangeToNextSignal(Direction.EastWest);

            Assert.Equal(Signal.Green, controller.NorthSouth);
            Assert.True(controller.EastWest == Signal.Red);
        }

        [Fact]
        public void System_ShouldNeveAllowBothDirectionsRedAmber()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);
            

            controller.ChangeToNextSignal(Direction.EastWest);
            

            Assert.Equal(Signal.RedAmber, controller.NorthSouth);
            Assert.True(controller.EastWest == Signal.Red);
        }

        [Fact]
        public void System_ShouldNeveAllowBothDirectionsAmber()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);

            controller.ChangeToNextSignal(Direction.EastWest);
            controller.ChangeToNextSignal(Direction.EastWest);
            controller.ChangeToNextSignal(Direction.EastWest);

            Assert.Equal(Signal.Amber, controller.NorthSouth);
            Assert.True(controller.EastWest == Signal.Red);
        }

        [Fact]
        public void System_ShouldNotAllowTrafficDuringPedestrianCrossing()
        {
            var controller = new TrafficLightController();

            controller.RequestPedestrianCrossing();
            controller.Tick(TimeSpan.Zero);

            Assert.Equal(Signal.Red, controller.NorthSouth);
            Assert.Equal(Signal.Red, controller.EastWest);
        }

        [Fact]
        public void System_ShouldNotAllowTransitionFromOffState()
        {
            var controller = new TrafficLightController();

            controller.TriggerSignalProgressionFailure();

            controller.ChangeToNextSignal(Direction.NorthSouth);

            Assert.Equal(Signal.Off, controller.NorthSouth);
            Assert.Equal(Signal.Off, controller.EastWest);
        }

        [Fact]
        public void System_ShouldBlockEastWestProgression_WhenNorthSouthIsActive()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth);

            controller.ChangeToNextSignal(Direction.EastWest);
            controller.ChangeToNextSignal(Direction.EastWest);

            Assert.Equal(Signal.Green, controller.NorthSouth);
            Assert.Equal(Signal.Red, controller.EastWest);
        }
    }
}
