using System;
using Helper._27_card_trick;

namespace _27_card_trick
{
    class Program
    {
        static void Main(string[] args)
        {
            Display();
        }


        private static void Display()
        {
            _27cardTrick _27card = new _27cardTrick();
            // int[] sequence = _27card.GenerateSequence();
            // _27card.DisplayCard(sequence);
            int answer = _27card.GetAnswer();
            Console.WriteLine($"Your card is {answer}");
            // _27card.RearranceDeck();

        }
    }
}
