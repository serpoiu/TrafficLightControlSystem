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

        public Signal North => NorthSouth;
        public Signal South => NorthSouth;

        public Signal East => EastWest;
        public Signal West => EastWest;

        private TimeSpan _timeSpentInCurrentSignal = TimeSpan.Zero;

        private bool _opposingTrafficWaiting;

        private bool _pedestrianRequestPending;

        private bool _isPedestrianCrossingActive;

        public bool IsPedestrianCrossingActive => _isPedestrianCrossingActive;

        public void ChangeToNextSignal(Direction direction)
        {
            if (direction == Direction.NorthSouth)
            {
                if (IsActive(EastWest))
                {
                    return;
                }

                NorthSouth = GetNextSignal(NorthSouth);
                _timeSpentInCurrentSignal = TimeSpan.Zero;
            }

            if (direction == Direction.EastWest)
            {
                if (IsActive(NorthSouth))
                {
                    return;
                }

                EastWest = GetNextSignal(EastWest);
                _timeSpentInCurrentSignal = TimeSpan.Zero;
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

        private static bool IsActive(Signal signal)
        { 
            return signal == Signal.RedAmber ||
                signal == Signal.Green ||
                signal == Signal.Amber;
        }

        public void Tick(TimeSpan timeSpent)
        { 
            _timeSpentInCurrentSignal += timeSpent;

            if (ShouldAdvance(NorthSouth))
            {
                ChangeToNextSignal(Direction.NorthSouth);
                return;
            }

            if (ShouldAdvance(EastWest))
            {
                ChangeToNextSignal(Direction.EastWest);
                return;
            }

            if (NorthSouth == Signal.Red &&
                EastWest == Signal.Red &&
                _pedestrianRequestPending)
            { 
                _isPedestrianCrossingActive = true;
                _pedestrianRequestPending = false;
            }
        }

        public void SetOpposingTraffic(bool isWaiting)
        {
            _opposingTrafficWaiting = isWaiting;
        }

        private bool ShouldAdvance(Signal signal)
        {
            if (signal == Signal.RedAmber || signal == Signal.Amber)
            { 
                return _timeSpentInCurrentSignal >= TimeSpan.FromSeconds(1.5);
            }

            if (signal == Signal.Green)
            {
                return (_opposingTrafficWaiting || _pedestrianRequestPending) &&
                       _timeSpentInCurrentSignal >= TimeSpan.FromSeconds(30);
            }

            return false;
        }

        public void RequestPedestrianCrossing()
        {
            _pedestrianRequestPending = true;
        }

        public bool HasPendingPedestrianRequest => _pedestrianRequestPending;
    }
}
