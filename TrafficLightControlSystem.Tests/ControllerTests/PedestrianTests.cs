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
    }
}
