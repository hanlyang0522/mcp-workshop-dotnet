
using MyMonkeyApp;

class Program
{
	static readonly string[] AsciiArts = new[]
	{
		"  (o\\_/o)",
		" (='.'=)",
		" (\")_(\")",
		"  (o.o)",
		"  ( : )",
		"  (^_^)",
		"  (>'-')>"
	};

	static void ShowRandomAsciiArt()
	{
		var rand = new Random();
		int idx = rand.Next(AsciiArts.Length);
		Console.WriteLine(AsciiArts[idx]);
	}

	static void Main()
	{
		while (true)
		{
			Console.Clear();
			ShowRandomAsciiArt();
			Console.WriteLine("============================");
			Console.WriteLine(" Monkey Console Application ");
			Console.WriteLine("============================");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.Write("Select an option: ");
			var input = Console.ReadLine();
			Console.WriteLine();

			switch (input)
			{
				case "1":
					ListAllMonkeys();
					break;
				case "2":
					GetMonkeyByName();
					break;
				case "3":
					GetRandomMonkey();
					break;
				case "4":
					Console.WriteLine("Goodbye!");
					return;
				default:
					Console.WriteLine("Invalid option. Try again.");
					break;
			}
			Console.WriteLine("\nPress any key to continue...");
			Console.ReadKey();
		}
	}

	static void ListAllMonkeys()
	{
		var monkeys = MonkeyHelper.GetAllMonkeys();
		Console.WriteLine("\nAvailable Monkeys:");
		foreach (var m in monkeys)
		{
			Console.WriteLine($"- {m.Name} ({m.Location})");
		}
	}

	static void GetMonkeyByName()
	{
		Console.Write("Enter monkey name: ");
		var name = Console.ReadLine();
		var monkey = MonkeyHelper.FindMonkeyByName(name);
		if (monkey != null)
		{
			Console.WriteLine($"\nName: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}");
		}
		else
		{
			Console.WriteLine("Monkey not found.");
		}
	}

	static void GetRandomMonkey()
	{
		var monkey = MonkeyHelper.GetRandomMonkey();
		Console.WriteLine($"\nRandom Monkey: {monkey.Name}\nLocation: {monkey.Location}\nPopulation: {monkey.Population}\nDetails: {monkey.Details}");
		Console.WriteLine($"(Random pick count: {MonkeyHelper.GetRandomPickCount()})");
		ShowRandomAsciiArt();
	}
}
