using System;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}

public class FootballPlayer : Person
{
    public int Number { get; set; }
    public double Height { get; set; }

    public FootballPlayer(string name, int age, int number, double height)
        : base(name, age)
    {
        Number = number;
        Height = height;
    }
}

public class Goalkeeper : FootballPlayer
{
    public Goalkeeper(string name, int age, int number, double height)
        : base(name, age, number, height)
    {
    }
}

public class Defender : FootballPlayer
{
    public Defender(string name, int age, int number, double height)
        : base(name, age, number, height)
    {
    }
}

public class Midfielder : FootballPlayer
{
    public Midfielder(string name, int age, int number, double height)
        : base(name, age, number, height)
    {
    }
}

public class Striker : FootballPlayer
{
    public Striker(string name, int age, int number, double height)
        : base(name, age, number, height)
    {
    }
}

public class Coach : Person
{
    public Coach(string name, int age)
        : base(name, age)
    {
    }
}

public class Referee : Person
{
    public Referee(string name, int age)
        : base(name, age)
    {
    }
}

public class Team
{
    public Coach Coach { get; set; }
    public FootballPlayer[] Players { get; set; }

    public double AveragePlayerAge
    {
        get
        {
            int totalAge = 0;
            foreach (var player in Players)
            {
                totalAge += player.Age;
            }
            return (double)totalAge / Players.Length;
        }
    }

    public Team(Coach coach, FootballPlayer[] players)
    {
        Coach = coach;
        Players = players;
    }
}
public class Game
{
    public Team Team1 { get; set; }
    public Team Team2 { get; set; }
    public Referee Referee { get; set; }
    public string[] Goals { get; set; }
    public string Result { get; private set; }
    public Team Winner { get; private set; }

    public Game(Team team1, Team team2, Referee referee)
    {
        Team1 = team1;
        Team2 = team2;
        Referee = referee;
        Goals = new string[0];
        Result = "";
        Winner = null;
    }

    public void AddGoal(string minute, string player)
    {
        string goal = $"{minute} - {player}";
        string[] updatedGoals = new string[Goals.Length + 1];
        Array.Copy(Goals, updatedGoals, Goals.Length);
        updatedGoals[Goals.Length] = goal;
        Goals = updatedGoals;
    }

    public void SetResult(string result, Team winner)
    {
        Result = result;
        Winner = winner;
    }
}

class Program
{
    static void Main()
    {
        Goalkeeper goalkeeper1 = new Goalkeeper("Стефан Илиев", 38, 4, 185);
        Defender defender1 = new Defender("Петър Иванов", 27, 5, 180);
        Midfielder midfielder1 = new Midfielder("Давид Давидов", 23, 8, 175);
        Striker striker1 = new Striker("Андрей Колев", 29, 10, 180);

        Coach coach1 = new Coach("Радо Попов", 45);

        FootballPlayer[] team1Players = { goalkeeper1, defender1, midfielder1, striker1 };
        Team team1 = new Team(coach1, team1Players);

        Defender defender2 = new Defender("Георги Кондев", 26, 4, 182);
        Midfielder midfielder2 = new Midfielder("Мартин Кръстев", 24, 7, 177);
        Striker striker2 = new Striker("Благослав Петров", 28, 9, 183);
        FootballPlayer[] team2Players = { goalkeeper1, defender2, midfielder2, striker2 };
        Team team2 = new Team(coach1, team2Players);

        Referee referee1 = new Referee("Светльо Христов", 40);

        Game game1 = new Game(team1, team2, referee1);

        game1.AddGoal("35'", "Андрей Колев");
        game1.AddGoal("65'", "Благослав Петров");
        game1.SetResult("2-1", team1);

        Console.WriteLine("Game Result:");
        Console.WriteLine("Team 1: {0}", game1.Team1.Coach.Name);
        Console.WriteLine("Team 2: {0}", game1.Team2.Coach.Name);
        Console.WriteLine("Goals:");
        foreach (string goal in game1.Goals)
        {
            Console.WriteLine(goal);
        }
        Console.WriteLine("Result: {0}", game1.Result);
        Console.WriteLine("Winner: {0}", game1.Winner.Coach.Name);
    }
}

