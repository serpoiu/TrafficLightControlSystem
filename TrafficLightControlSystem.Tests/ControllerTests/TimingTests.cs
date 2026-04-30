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

        [Fact]
        public void Amber_ShouldNotChangeBeforeOnePointFiveSeconds()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth); 
            controller.ChangeToNextSignal(Direction.NorthSouth); 
            controller.ChangeToNextSignal(Direction.NorthSouth); 

            controller.Tick(TimeSpan.FromSeconds(1));

            Assert.Equal(Signal.Amber, controller.NorthSouth);
        }

        [Fact]
        public void Amber_ShouldChangeAfterOnePointFiveSeconds()
        {
            var controller = new TrafficLightController();

            controller.ChangeToNextSignal(Direction.NorthSouth); 
            controller.ChangeToNextSignal(Direction.NorthSouth); 
            controller.ChangeToNextSignal(Direction.NorthSouth); 

            controller.Tick(TimeSpan.FromSeconds(1.5));

            Assert.Equal(Signal.Red, controller.NorthSouth);
        }

        [Fact]
        public void Green_ShouldNotChangeBeforeThirtySeconds_WhenOpposingTrafficPresent()
        {
            var controller = new TrafficLightController();

            controller.SetOpposingTraffic(true);

            controller.ChangeToNextSignal(Direction.NorthSouth);
            controller.ChangeToNextSignal(Direction.NorthSouth); 

            controller.Tick(TimeSpan.FromSeconds(29));

            Assert.Equal(Signal.Green, controller.NorthSouth);
        }

        [Fact]
        public void Green_ShouldChangeAfterThirtySeconds_WhenOpposingTrafficPresent()
        {
            var controller = new TrafficLightController();

            controller.SetOpposingTraffic(true);

            controller.ChangeToNextSignal(Direction.NorthSouth); 
            controller.ChangeToNextSignal(Direction.NorthSouth); 

            controller.Tick(TimeSpan.FromSeconds(30));

            Assert.Equal(Signal.Amber, controller.NorthSouth);
        }

        [Fact]
        public void Green_ShouldRemainIndefinitely_WhenNoOpposingTrafficAndNoPedestrianRequest()
        {
            var controller = new TrafficLightController();

            controller.SetOpposingTraffic(false);

            controller.ChangeToNextSignal(Direction.NorthSouth); 
            controller.ChangeToNextSignal(Direction.NorthSouth);

            controller.Tick(TimeSpan.FromSeconds(60));

            Assert.Equal(Signal.Green, controller.NorthSouth);
        }

        [Fact]
        public void EastWest_GreenTiming_ShouldMatchNorthSouthBehaviour()
        {
            var controller = new TrafficLightController();

            controller.SetOpposingTraffic(true);

            controller.ChangeToNextSignal(Direction.EastWest); 
            controller.ChangeToNextSignal(Direction.EastWest); 

            controller.Tick(TimeSpan.FromSeconds(30));

            Assert.Equal(Signal.Amber, controller.EastWest);
        }
    }
}
