using System;

namespace NumberGenerator.Logic
{
    public interface IObservable
    {
        delegate void NextNumberHandler(int newNumber);

        NextNumberHandler NextNumber { get; set; }
    }
}