using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrafficLightControlSystem.Core
{
    public class TrafficLightController
    {
        public Signal NorthSouth { get; private set; } = Signal.Red;

        public Signal EastWest { get; private set; } = Signal.Red;
    }
}
