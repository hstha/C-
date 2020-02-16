using System;
using System.Collections;
using System.Linq;

namespace Helper._27_card_trick
{
    ///<summary>
    ///This is a class that generates 27 random card, takes the number where you want the card to be on and gives your 
    ///choosen card 
    ///</summary>
    class _27cardTrick
    {
        private int _min = 1, _max = 52, _getCardPlacement;
        private int[] _getSequence = new int[3];
        private static int _n = 27;
        private static int _nList = 3;
        private Random _random = new Random();

        private int[] _listOfCard = new int[_n];
        private int[][] _cardList = new int[3][] { new int[9], new int[9], new int[9] };
        public _27cardTrick()
        {
            _listOfCard = GenerateRandomCard();
            DisplayCard(_listOfCard);
            _getSequence = GenerateSequence();
            // DisplayCard(_getSequence);
        }

        private int[] GenerateSequence()
        {
            int[] sequence = new int[3];
            int _temp;
            // Console.WriteLine(_getCardPlacement);
            do
            {
                try
                {
                    Console.Write("Choose where you want your card to be? ");
                    string getValue = Console.ReadLine();
                    // Console.WriteLine($"{getValue} is where your card will be at final position");
                    _getCardPlacement = (Int32.Parse(getValue));
                    _temp = _getCardPlacement - 1;
                    if (_temp < 27)
                    {
                        for (int i = 3, remainder, quotient; i > 0; i--)
                        {
                            quotient = (_temp) / (int)Math.Pow(3, (i - 1));
                            remainder = _temp % (int)Math.Pow(3, (i - 1));
                            sequence[i - 1] = quotient;
                            // Console.WriteLine($"When {_temp} is divided by {Math.Pow(3, (i - 1))}, we get {quotient} as quotient and {remainder} as remainder");
                            _temp = remainder;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Number should be less than or equal to 27. Please Try Again!!!");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Please enter Number and Try Again");
                    _temp = 30;
                }
            } while (_temp > 26);
            return sequence;
        }

        private int[] GenerateRandomCard()
        {
            int temp;
            int[] tempListOfCard = new int[_n];
            for (int i = 0; i < _n;)
            {
                temp = _random.Next(_min, _max + 1);
                if (!tempListOfCard.Contains(temp))
                {
                    tempListOfCard[i] = temp;
                    i++;
                }
            }
            // Console.WriteLine(tempListOfCard);
            return tempListOfCard;
        }

        private void DisplayCard(int[] cardArray)
        {
            Console.Write("[ ");
            foreach (int i in cardArray)
            {
                Console.Write($"{i} ");
            }
            Console.Write("]");
            Console.WriteLine(" ");
        }

        ///<summary>
        /// GetAnswer() is the main function that takes the user input and gives the user's selected card
        ///in the desired place.
        ///</summary>
        public int GetAnswer()
        {
            int answer = 1;
            int k = 0, deckNumber;
            while (k < 3)
            {
                RearranceDeck();
                for (int i = 0; i < 3; i++)
                {
                    DisplayCard(_cardList[i]);
                }
                Console.Write("In Which deck do you see your Card?[0|1|2] ");
                deckNumber = Int32.Parse(Console.ReadLine());
                switch (deckNumber)
                {
                    case 0:
                        // top = 0
                        if (_getSequence[k] == 0)
                        {
                            _listOfCard = _cardList[0].Concat(_cardList[2]).Concat(_cardList[1]).ToArray();
                        }
                        // top = 1
                        else if (_getSequence[k] == 1)
                        {
                            _listOfCard = _cardList[1].Concat(_cardList[0]).Concat(_cardList[2]).ToArray();
                        }
                        // top = 2
                        else
                        {
                            _listOfCard = _cardList[2].Concat(_cardList[1]).Concat(_cardList[0]).ToArray();
                        }
                        break;

                    case 1:
                        if (_getSequence[k] == 0)
                        {
                            _listOfCard = _cardList[1].Concat(_cardList[0]).Concat(_cardList[2]).ToArray();
                        }
                        else if (_getSequence[k] == 1)
                        {
                            _listOfCard = _cardList[2].Concat(_cardList[1]).Concat(_cardList[0]).ToArray();
                        }
                        else
                        {
                            _listOfCard = _cardList[0].Concat(_cardList[2]).Concat(_cardList[1]).ToArray();
                        }
                        break;

                    case 2:
                        if (_getSequence[k] == 0)
                        {
                            _listOfCard = _cardList[2].Concat(_cardList[1]).Concat(_cardList[0]).ToArray();
                        }
                        else if (_getSequence[k] == 1)
                        {
                            _listOfCard = _cardList[0].Concat(_cardList[2]).Concat(_cardList[1]).ToArray();
                        }
                        else
                        {
                            _listOfCard = _cardList[1].Concat(_cardList[0]).Concat(_cardList[2]).ToArray();
                        }
                        break;

                    default:
                        break;
                }
                k++;
            };

            // RearranceDeck();
            Console.WriteLine("This is the final array");
            DisplayCard(_listOfCard);

            for (int i = 0; i < _listOfCard.Length; i++)
            {
                if (i == _getCardPlacement - 1)
                {
                    answer = _listOfCard[i];
                }
            }
            return answer;
        }

        private void RearranceDeck()
        {
            for (int i = 0, k = 0; i < _listOfCard.Length / 3; i++)
            {
                for (int j = 0; j < _cardList.Length; j++, k++)
                {
                    _cardList[j][i] = _listOfCard[k];
                }
            }
        }
    }
}