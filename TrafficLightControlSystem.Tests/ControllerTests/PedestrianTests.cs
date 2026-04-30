using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrafficLightControlSystem.Core;

namespace TrafficLightControlSystem.Tests.ControllerTests
{
    public class PedestrianTests
    {
        [Fact]
        public void PedestrianRequest_ShouldBeQueued()
        {
            var controller = new TrafficLightController();

            controller.RequestPedestrianCrossing();

            Assert.True(controller.HasPendingPedestrianRequest);
        }


        [Fact]
        public void PedestrianCrossing_ShouldActivateAtNextAllRed()
        {
            var controller = new TrafficLightController();

            controller.RequestPedestrianCrossing();

            controller.ChangeToNextSignal(Direction.NorthSouth); 
            controller.ChangeToNextSignal(Direction.NorthSouth); 
            controller.ChangeToNextSignal(Direction.NorthSouth); 
            controller.ChangeToNextSignal(Direction.NorthSouth); 

            // At this point both directions red

            controller.Tick(TimeSpan.Zero);

            Assert.True(controller.IsPedestrianCrossingActive);
        }

        [Fact]
        public void PedestrianCrossing_ShouldKeepBothDirectionsRed()
        {
            var controller = new TrafficLightController();

            controller.RequestPedestrianCrossing();
            controller.Tick(TimeSpan.Zero);

            Assert.True(controller.IsPedestrianCrossingActive);
            Assert.Equal(Signal.Red, controller.NorthSouth);
            Assert.Equal(Signal.Red, controller.EastWest);
        }

        [Fact]
        public void PedestrianCrossing_ShouldActivateAlertAndLight()
        {
            var controller = new TrafficLightController();

            controller.RequestPedestrianCrossing();
            controller.Tick(TimeSpan.Zero);

            Assert.True(controller.PedestrianAlert);
            Assert.True(controller.PedestrianLight);
        }

        [Fact]
        public void PedestrianCrossing_ShouldEndAfterFifteenSeconds()
        {
            var controller = new TrafficLightController();

            controller.RequestPedestrianCrossing();
            controller.Tick(TimeSpan.Zero);

            controller.Tick(TimeSpan.FromSeconds(15));

            Assert.False(controller.IsPedestrianCrossingActive);
        }
    }
}
