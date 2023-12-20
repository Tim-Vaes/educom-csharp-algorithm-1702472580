namespace BornToMove
{
    class Program
    {
        static void Main(string[] args)
        {
            BornToMoveApp App = new BornToMoveApp();

            App.RemindToMove();
            App.showOptionMenu();

            int userChoice;
            bool isValidChoice;

            do
            {
                Console.Write("Voer het nummer van de gewenste optie in: ");
                string userInput = Console.ReadLine();

                isValidChoice = int.TryParse(userInput, out userChoice) && (userChoice == 1 || userChoice == 2);

                if (!isValidChoice)
                {
                    Console.WriteLine("Ongeldige invoer. Voer 1 of 2 in.");
                }
            } while (!isValidChoice);

            Console.WriteLine();

            if (userChoice == 1)
            {
                Move randomMove = App.GetRandomSuggestedMove();
                Console.WriteLine("Hier is een move om te proberen:");
                Console.WriteLine();
                App.DisplayMoveDetails(randomMove);
                Console.WriteLine();
                App.RateMove(randomMove);
                Console.WriteLine();
            }
            else
            {
                List<Move> moveList = App.GetMoveListForUserChoice();
                App.DisplayMoveList(moveList);
                Console.WriteLine("0. Voeg zelf een nieuwe move toe aan de lijst");
                Console.WriteLine();

                bool validChoice = false;

                while (!validChoice)
                {
                    Console.Write("Kies een move (enter het bijbehorende nummer): ");

                    if (int.TryParse(Console.ReadLine(), out userChoice))
                    {
                        Console.WriteLine();

                        if (userChoice >= 1 && userChoice <= moveList.Count)
                        {
                            Move chosenMove = moveList[userChoice - 1];
                            App.DisplayMoveDetails(chosenMove);
                            Console.WriteLine();

                            App.RateMove(chosenMove);
                            Console.WriteLine();

                            validChoice = true;
                        }
                        else if (userChoice == 0)
                        {
                            App.AddNewMove();
                            validChoice = true;
                        }
                        else
                        {
                            Console.WriteLine("Ongeldige input. Kies de move door het bijbehorende nummer in te toetsen (0-" + moveList.Count + ").");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ongeldige input. Toets een geldig nummer in.");
                    }
                }
            }
        }
    }
}
