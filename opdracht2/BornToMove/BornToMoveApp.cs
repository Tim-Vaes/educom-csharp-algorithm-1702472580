namespace BornToMove
{
    public class BornToMoveApp
    {
        private Database db;

        public BornToMoveApp()
        {
            this.db = new Database();
        }

        public void RemindToMove()
        {
            Console.WriteLine("Het is tijd om te bewegen!");
            Console.WriteLine();
        }

        public Move GetRandomSuggestedMove()
        {
            return db.GetRandomMove();
        }

        public List<Move> GetMoveListForUserChoice()
        {
            return db.GetMoveList();
        }

        public void DisplayMoveDetails(Move move)
        {
            Console.WriteLine(move.ToString());
        }

        public void DisplayMoveList(List<Move> moves)
        {
            Console.WriteLine("Moves List:");
            for (int i = 0; i < moves.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {moves[i].Name} (Sweat Rate: {moves[i].SweatRate})");
            }
        }

        public void RateMove(Move move)
        {
            int rating, intensity;
            Console.WriteLine("Hopelijk heb je een mooie workout achter de rug, we horen graag je persoonlijke ervaring!");
            Console.WriteLine("Wat vond je van deze move?");
            do
            {
                Console.Write("Geef een beoordeling (1-5): ");
                if (!int.TryParse(Console.ReadLine(), out rating) || rating < 1 || rating > 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ongeldige invoer. Voer een getal tussen 1 en 5 in. Probeer opnieuw.");
                }
            } while (rating < 1 || rating > 5);
            Console.WriteLine();
            Console.WriteLine("Hoe intense vond je deze move?");
            do
            {
                Console.Write("Beoordeel de intensiteit (1-5): ");
                if (!int.TryParse(Console.ReadLine(), out intensity) || intensity < 1 || intensity > 5)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ongeldige invoer. Voer een getal tussen 1 en 5 in. Probeer opnieuw.");
                }
            } while (intensity < 1 || intensity > 5);
            Console.WriteLine();
            Console.Write("Bedankt voor je feedback!");

        }

        public void AddNewMove()
        {
            string name;

            do
            {
                Console.Write("Voer de naam van de nieuwe beweging in: ");
                name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine();
                    Console.WriteLine("Het veld was nog leeg. Probeer opnieuw.");
                }
                else if (db.DoesMoveExist(name))
                {
                    Console.WriteLine();
                    Console.WriteLine("Deze move bestaat al. Probeer een andere move.");
                }
                else
                {
                    break; 
                }
            } while (true);
            Console.Write("Geef een beschrijving van de move: ");
            string description;
            do
            {
                description = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Het veld was nog leeg. Probeer opnieuw.");
                }
                else
                {
                    break;
                }
            } while (true);
            int sweatRate;
            do
            {
                Console.Write("Hoe erg zweet je tijdens deze move? (1-5): ");

                if (!int.TryParse(Console.ReadLine(), out sweatRate) || sweatRate < 1 || sweatRate > 5)
                {
                    Console.WriteLine("Ongeldige invoer. Voer een getal tussen 1 en 5 in.");
                }
                else
                {
                    break;
                }
            } while (true);
            db.AddMove(new Move { Name = name, Description = description, SweatRate = sweatRate });
            Console.WriteLine();
            Console.WriteLine("Bedankt! De move is toegevoegd aan de lijst.");
        }
        public void showOptionMenu()
        {   
            Console.WriteLine("Kies een optie:");
            Console.WriteLine("1. Toon een willekeurige beweging om te proberen");
            Console.WriteLine("2. Kies zelf een beweging uit de lijst");
            Console.WriteLine();
        }
    }
}
