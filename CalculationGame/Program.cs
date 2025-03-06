namespace CalculationGame
{
    internal class Program
    {
        private static ManualResetEvent mre = new ManualResetEvent(false);
        private static Random rnd = new Random();

        static void Main(string[] args)
        { 
            int pocetPrikladu = 5;
            int score = 0;
          
            Console.WriteLine("stiskni cokoliv pro start:");
            Console.ReadLine();

            for (int i = 0; i < pocetPrikladu; i++)
            {
                mre.Reset();

                Priklad priklad = new Priklad(rnd.Next(0, 20) - 10, rnd.Next(0, 20) - 10);
                bool corect = false;

                Thread thread = new Thread(() => 
                {
                    string y = priklad.Y > 0 ? priklad.Y.ToString() : $"({priklad.Y})";
                    Console.WriteLine($"{priklad.X} + {y}");
                    string? answer = Console.ReadLine();

                    if(int.TryParse(answer,out int parsedAnswer))
                    {
                        if (priklad.Vysledek == parsedAnswer)
                        {
                           corect = true;
                        }
                    }

                    mre.Set();
                });

                thread.Start();

                if (!mre.WaitOne(5000))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"čas vypršel ({priklad.Vysledek})");
                }
                else
                {
                    if (corect)
                    {
                        score++;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("spravně!");
                    }
                    else
                    {    
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"špatná odpověď ({priklad.Vysledek})");
                    }
                }
                Console.ResetColor();
            }
            Console.WriteLine("skóre: "+score+"/"+pocetPrikladu);
            Environment.Exit(0); //pokud posledni answer je timeout, thread by cekal na ReadLine()
        }
    }
}
