using System;

public class Person
{
    private string name;
    private DateTime birthYear;

    public string Name
    {
        get { return name; }
    }

    public DateTime BirthYear
    {
        get { return birthYear; }
    }

    public Person()
    {
        name = "Unknown";
        birthYear = DateTime.Now;
    }

    public Person(string name, DateTime birthYear)
    {
        this.name = name;
        this.birthYear = birthYear;
    }

    public int Age()
    {
        return DateTime.Now.Year - birthYear.Year;
    }

    public void Input()
    {
        name = Console.ReadLine();
        int year = int.Parse(Console.ReadLine());
        birthYear = new DateTime(year, 1, 1);
    }

    public void ChangeName(string newName)
    {
        name = newName;
    }

    public override string ToString()
    {
        return $"Name: {name}, Year of Birth: {birthYear.Year}";
    }

    public void Output()
    {
        Console.WriteLine(ToString());
    }

    public static bool operator ==(Person p1, Person p2)
    {
        return p1.name == p2.name;
    }

    public static bool operator !=(Person p1, Person p2)
    {
        return !(p1 == p2);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        Person other = (Person)obj;
        return name == other.name;
    }

    public override int GetHashCode()
    {
        return name.GetHashCode();
    }
}

public class BehaviorCheck
{
    public static void StudentMain()
    {
        Person[] people = new Person[6];


        for (int i = 0; i < 6; i++)
        {
            people[i] = new Person();
            people[i].Input();
        }


        foreach (var person in people)
        {
            Console.WriteLine($"{person.Name} is {person.Age()} years old.");
        }


        foreach (var person in people)
        {
            if (person.Age() < 16)
            {
                person.ChangeName("Very Young");
            }
        }


        Console.WriteLine("\nInformation about all persons:");
        foreach (var person in people)
        {
            person.Output();
        }


        Console.WriteLine("\nPersons with the same names:");
        bool foundSameNames = false;
        for (int i = 0; i < people.Length; i++)
        {
            for (int j = i + 1; j < people.Length; j++)
            {
                if (people[i] == people[j])
                {
                    people[i].Output();
                    people[j].Output();
                    foundSameNames = true;
                }
            }
        }


        if (!foundSameNames)
        {
            Console.WriteLine("absent");
        }
    }

    public static void Main()
    {
        StudentMain();
        Console.ReadKey();
    }
}
