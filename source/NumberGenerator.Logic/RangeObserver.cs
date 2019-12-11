﻿using System;
using System.Collections.Generic;
using System.Text;

namespace NumberGenerator.Logic
{
    /// <summary>
    /// Beobachter, welcher die Anzahl der generierten Zahlen in einem bestimmten Bereich zählt. 
    /// </summary>
    public class RangeObserver : BaseObserver
    {
        #region Properties

        /// <summary>
        /// Enthält die untere Schranke (inkl.)
        /// </summary>
        public int LowerRange { get; private set; }
        
        /// <summary>
        /// Enthält die obere Schranke (inkl.)
        /// </summary>
        public int UpperRange { get; private set; }

        /// <summary>
        /// Enthält die Anzahl der Zahlen, welche sich im Bereich befinden.
        /// </summary>
        public int NumbersInRange { get; private set; } = 0;

        /// <summary>
        /// Enthält die Anzahl der gesuchten Zahlen im Bereich.
        /// </summary>
        public int NumbersOfHitsToWaitFor { get; private set; }

        #endregion

        #region Constructors

        public RangeObserver(IObservable numberGenerator, int numberOfHitsToWaitFor, int lowerRange, int upperRange) : base(numberGenerator, int.MaxValue)
        {
            NumbersOfHitsToWaitFor = numberOfHitsToWaitFor;
            LowerRange = lowerRange;
            UpperRange = upperRange;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            throw new NotImplementedException();
        }

        public override void OnNextNumber(int number)
        {
            if(NumbersOfHitsToWaitFor > CountOfNumbersReceived)
            {
                DetachFromNumberGenerator();
            }
            else if(number >= LowerRange && number <= UpperRange)
            {
                NumbersInRange++;
            }
        }

        #endregion
    }
}
