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

        public void ChangeToNextSignal(Direction direction)
        {
            if (direction == Direction.NorthSouth)
            {
                NorthSouth = GetNextSignal(NorthSouth);
            }

            if (direction == Direction.EastWest)
            {
                EastWest = GetNextSignal(EastWest);
            }
        }

        private static Signal GetNextSignal(Signal signal)
        {
            return signal switch
            {
                Signal.Red => Signal.RedAmber,
                Signal.RedAmber => Signal.Green,
                Signal.Green => Signal.Amber,
                Signal.Amber => Signal.Red,
                _ => signal
            };
        }
    }
}
