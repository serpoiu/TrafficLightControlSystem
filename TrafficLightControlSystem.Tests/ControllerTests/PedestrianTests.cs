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
    }
}
