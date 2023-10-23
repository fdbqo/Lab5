using System;

namespace Lab5Q1
{
    class Program
    {
        static void Main(string[] args)
        {
            Game g1 = new Game("Monopoly", 19.99m, new DateTime(1970, 01, 31));
            Game g2 = new Game() { Price = 10.99m, ReleaseDate = new DateTime(2000, 6, 15) };

            ComputerGame g3 = new ComputerGame("Test", 49.99m, new DateTime(2010, 12, 25), "18");
            ComputerGame g4 = new ComputerGame();

            //Console.WriteLine(g2.ToString());

            g2.UpdatePrice(1m);
            g3.UpdatePrice(100m);

            DisplayGame(g3);
        }

        public static void DisplayGame(Game game)
        {
            Console.WriteLine(game);
        }
    }

    class Game
    {
        public string Name { get; set; }
        public decimal Price { get; set; } // protected does not work in main due to protection level
        public DateTime ReleaseDate { get; set; }

        public Game(string name, decimal price, DateTime releaseDate)
        {
            Name = name;
            Price = price;
            ReleaseDate = releaseDate;
        }

        public Game() : this("", 0)
        {

        }
        public Game(string name, decimal price) : this(name, price, DateTime.Now)
        {

        }

        public override string ToString()
        {
            return $"Name  : {Name}\nPrice : {Price}\nDate  : {ReleaseDate.ToShortDateString()}";
        }

        public virtual void UpdatePrice(decimal percentageIncrease)
        {
            Price *= (1 + percentageIncrease);
        }


    }

    class ComputerGame : Game
    {
        public string PEGIRating { get; set; }

        public ComputerGame(string name, decimal price, DateTime releaseDate, string pegiRating) : base(name, price, releaseDate)
        {
            PEGIRating = pegiRating;
        }

        public ComputerGame() : this("", 0, DateTime.Now, "")
        {

        }

        public override string ToString()
        {
            return $"Name  : {Name}\nPrice : {Price}\nDate  : {ReleaseDate.ToShortDateString()}\nPEGI  : {PEGIRating}";
        }

        public decimal GetDiscountPrice()
        {
            return Price * 0.9m;
        }

        public override void UpdatePrice(decimal percentageIncrease)  // needs to be virtual in main class to override
        {
            Price *= (1 + percentageIncrease);
            Console.WriteLine("Price updated in ComputerGame class");
        }

    }


}
