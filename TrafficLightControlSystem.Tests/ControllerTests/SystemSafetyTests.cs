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

        [Fact]
        public void System_ShouldBlockTransition_WhenItWouldCreateUnsafeState()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth);

            var before = controller.EastWest;

            controller.ChangeToNextSignal(Direction.EastWest);

            Assert.Equal(before, controller.EastWest);
        }

        [Fact]
        public void Tick_ShouldBeDeterministic_ForSameInput()
        {
            var controller1 = new TrafficLightController();
            var controller2 = new TrafficLightController();

            controller1.ChangeToNextSignal(Direction.NorthSouth);
            controller2.ChangeToNextSignal(Direction.NorthSouth);

            controller1.Tick(TimeSpan.FromSeconds(1.5));
            controller2.Tick(TimeSpan.FromSeconds(1.5));

            Assert.Equal(controller1.NorthSouth, controller2.NorthSouth);
        }

        [Fact]
        public void System_ShouldMaintainInvariant_AfterMultipleTransitions()
        {
            var controller = new TrafficLightController();

            for (int i = 0; i < 10; i++)
            {
                controller.ChangeToNextSignal(Direction.NorthSouth);
                controller.ChangeToNextSignal(Direction.EastWest);

                bool nsActive =
                    controller.NorthSouth == Signal.Green ||
                    controller.NorthSouth == Signal.RedAmber ||
                    controller.NorthSouth == Signal.Amber;

                bool ewActive =
                    controller.EastWest == Signal.Green ||
                    controller.EastWest == Signal.RedAmber ||
                    controller.EastWest == Signal.Amber;

                if (nsActive)
                {
                    Assert.Equal(Signal.Red, controller.EastWest);
                }

                if (ewActive)
                {
                    Assert.Equal(Signal.Red, controller.NorthSouth);
                }
            }
        }
    }
}
