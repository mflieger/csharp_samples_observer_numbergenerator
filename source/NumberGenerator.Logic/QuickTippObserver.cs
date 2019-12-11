﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace NumberGenerator.Logic
{
    /// <summary>
    /// Beobachter, welcher auf einen vollständigen Quick-Tipp wartet: 6 unterschiedliche Zahlen zw. 1 und 45.
    /// </summary>
    public class QuickTippObserver : IObserver
    {
        #region Fields

        private IObservable _numberGenerator;

        #endregion

        #region Properties

        public List<int> QuickTippNumbers { get; private set; }
        public int CountOfNumbersReceived { get; private set; } 

        #endregion

        #region Constructor

        public QuickTippObserver(IObservable numberGenerator)
        {
            if(numberGenerator == null)
            {
                throw new ArgumentNullException(nameof(numberGenerator));
            }
            CountOfNumbersReceived = 0;
            QuickTippNumbers = new List<int>();
            numberGenerator.Attach(this);
            _numberGenerator = numberGenerator;
        }

        #endregion

        #region Methods

        public void OnNextNumber(int number)
        {
            CountOfNumbersReceived++;

            if(number > 0 && number <= 45 && !QuickTippNumbers.Contains(number))
            {
                QuickTippNumbers.Add(number);

                if(QuickTippNumbers.Count >= 6)
                {
                    QuickTippNumbers.Sort();
                    DetachFromNumberGenerator();
                }
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} = Quicktipp: | {QuickTippNumbers[0]} | {QuickTippNumbers[1]} | {QuickTippNumbers[2]} | {QuickTippNumbers[3]} | {QuickTippNumbers[4]} | {QuickTippNumbers[5]}";
        }

        private void DetachFromNumberGenerator()
        {
            _numberGenerator.Detach(this);
        }

        #endregion
    }
}
