using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace _1_4_gissa_det_hemliga_talet.Model
{
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Correct,
        NoMoreGuesses,
        PreviousGuess
    }
    public class SecretNumber
    {
        private int _number;
        private List<int> _previousGuess;
        private const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess
        { 
            get
            {
                return Count < MaxNumberOfGuesses && Outcome != Outcome.Correct;
            }
        }

        public int Count { get { return _previousGuess.Count;} }

        public int? Number {
            get
            {
                if (CanMakeGuess)
                {
                    return null;
                }
                return _number;
            }
        }

        public Outcome Outcome { get; set; }

        public IEnumerable<int> PreviosGuesses { get { return new ReadOnlyCollection<int>(_previousGuess);} }

        public void Initialize()
        {
            Outcome = Outcome.Indefinite;
            _previousGuess.Clear();
            Random random = new Random();
            _number = random.Next(1, 101);
        }

        public Outcome MakeGuess(int guess)
        {
            if (CanMakeGuess)
            {
                if (guess < 1 || guess > 100)
                {
                    throw new ArgumentOutOfRangeException("Gissningen måste vara inom 1-100");
                }
                if (PreviosGuesses.Contains(guess))
                {
                    Outcome = Outcome.PreviousGuess;
                }
                else
                {
                    _previousGuess.Add(guess);

                    if (guess < _number)
                    {
                        Outcome = Outcome.Low;
                    }
                    else if (guess > _number)
                    {
                        Outcome = Outcome.High;
                    }
                    else
                    {
                        Outcome = Outcome.Correct;
                    }
                }
            }
            else
            {
                Outcome = Outcome.NoMoreGuesses;
            }

            return Outcome; 
        }

        public SecretNumber()
        {
            _previousGuess = new List<int>(MaxNumberOfGuesses);
            Initialize();
        }
    }
}