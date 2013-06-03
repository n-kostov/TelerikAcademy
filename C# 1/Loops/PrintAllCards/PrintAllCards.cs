using System;

class PrintAllCards
{
    static void Main()
    {

        for (int j = 1; j <= 4; j++)
        {
            string colorOfCard = "";
            switch (j)
            {
                case 1:
                    colorOfCard = "of Diamonds";
                    break;
                case 2:
                    colorOfCard = "of Hearts";
                    break;
                case 3:
                    colorOfCard = "of Spades";
                    break;
                case 4:
                    colorOfCard = "of Clubs";
                    break;
            }
            for (int i = 2; i <= 14; i++)
            {
                string numberOnCard = "";
                switch (i)
                {
                    case 2:
                        numberOnCard = "2 ";
                        break;
                    case 3:
                        numberOnCard = "3 ";
                        break;
                    case 4:
                        numberOnCard = "4 ";
                        break;
                    case 5:
                        numberOnCard = "5 ";
                        break;
                    case 6:
                        numberOnCard = "6 ";
                        break;
                    case 7:
                        numberOnCard = "7 ";
                        break;
                    case 8:
                        numberOnCard = "8 ";
                        break;
                    case 9:
                        numberOnCard = "9 ";
                        break;
                    case 10:
                        numberOnCard = "10 ";
                        break;
                    case 11:
                        numberOnCard = "J ";
                        break;
                    case 12:
                        numberOnCard = "Q ";
                        break;
                    case 13:
                        numberOnCard = "K ";
                        break;
                    case 14:
                        numberOnCard = "A ";
                        break;
                }
                Console.WriteLine("{0}{1}", numberOnCard, colorOfCard);
            }
        }
    }
}


