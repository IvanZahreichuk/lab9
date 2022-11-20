using System.Text;
using Lab09;

var loopBreak = true;
while (loopBreak)
{
    Console.WriteLine("Select the problem(1-10) or exit(0):");

    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            Problem1_2();
            break;
        case 2:
            Problem1_2();
            break;
        case 3:
            Problem3();
            break;
        case 4:
            Problem4();
            break;
        case 5:
            Problem5();
            break;
        case 6:
            Problem6();
            break;
        case 7:
            Problem7();
            break;
        case 8:
            Problem8();
            break;
        default:
            Console.WriteLine("Exiting the Lab 9...");
            loopBreak = false;
            break;
    }

    if (!loopBreak) break;
}

// Problem 1 & 2
void Problem1_2()
{
    Console.WriteLine("Problem 1 & 2");

    var collection = new ListyIterator<string>();
    Console.WriteLine("Input your commands: (END to exit)");
    var inputCommand = Console.ReadLine();
    while (!inputCommand.Equals("END"))
    {
        var lineArgs = inputCommand.Split();
        try
        {
            switch (lineArgs[0])
            {
                case "Create":
                    collection.Create(lineArgs.Skip(1).ToList());
                    break;
                case "Move":
                    Console.WriteLine(collection.Move());
                    break;
                case "Print":
                    collection.Print();
                    break;
                case "HasNext":
                    Console.WriteLine(collection.HasNext());
                    break;
                case "PrintAll":
                    Console.WriteLine(collection.PrintAll());
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        inputCommand = Console.ReadLine();
    }
}

// Problem 3
void Problem3()
{
    Console.WriteLine("Problem 3");
    var stack = new StackProblem3<int>();

    Console.WriteLine("Input your commands: (END to exit): ");
    var command = Console.ReadLine();
    while (!command.Equals("END"))
    {
        var commandArgs = command.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);

        if (commandArgs[0].Equals("Push"))
        {
            var numbers = commandArgs.Skip(1).ToList().Select(int.Parse).ToList();
            foreach (var number in numbers)
            {
                stack.Push(number);
            }
        }
        else
        {
            try
            {
                stack.Pop();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        command = Console.ReadLine();
    }

    var result = GetStringResult(stack);
    if (result != string.Empty)
    {
        Console.WriteLine($"{result}{Environment.NewLine}{result}");
    }
}

// Problem 4
void Problem4()
{
    Console.WriteLine("Problem 4");
    Console.WriteLine("Input stones for froggy: ");

    var numbers = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

    var stones = new Lake(numbers.ToList());

    Console.WriteLine(string.Join(", ", stones));
}

// Problem 5
void Problem5()
{
    Console.WriteLine("Problem 5");
    Console.WriteLine("Input people lines: (END to exit)");

    var people = new List<PersonProblem5>();
    var inputLine = Console.ReadLine();

    while (!inputLine.Equals("END"))
    {
        var personArgs = inputLine.Split();
        people.Add(new PersonProblem5(personArgs[0], int.Parse(personArgs[1]), personArgs[2]));
        inputLine = Console.ReadLine();
    }

    var personIndex = int.Parse(Console.ReadLine());

    var equalsPeopleCount = GetEqualsPeople(people[personIndex - 1], people);
    var notEqualsPeopleCount = GetNotEqualsPeople(people[personIndex - 1], people);

    if (equalsPeopleCount == 0 || equalsPeopleCount == 1)
    {
        Console.WriteLine("No matches");
        return;
    }

    Console.WriteLine($"{equalsPeopleCount} {notEqualsPeopleCount} {people.Count}");
}

// Problem 6
void Problem6()
{
    Console.WriteLine("Problem 6");
    Console.WriteLine("People count");
    var nameSorted = new SortedSet<PersonProblem6>(new NameComparer());
    var ageSorted = new SortedSet<PersonProblem6>(new AgeComparer());

    var counter = int.Parse(Console.ReadLine());
    for (int i = 0; i < counter; i++)
    {
        Console.WriteLine("Name / Age");
        var personArgs = Console.ReadLine().Split();
        var person = new PersonProblem6(personArgs[0], int.Parse(personArgs[1]));

        nameSorted.Add(person);
        ageSorted.Add(person);
    }

    Console.WriteLine(string.Join(Environment.NewLine, nameSorted));
    Console.WriteLine(string.Join(Environment.NewLine, ageSorted));
}

// Problem 7
void Problem7()
{
    Console.WriteLine("Problem 7");
    Console.WriteLine("People count: ");

    var hashSet = new HashSet<PersonProblem7>();
    var sortedSet = new SortedSet<PersonProblem7>();

    var counter = int.Parse(Console.ReadLine());
    for (int i = 0; i < counter; i++)
    {
        Console.WriteLine("Name / Age");

        var personArgs = Console.ReadLine().Split();
        var person = new PersonProblem7(personArgs[0], int.Parse(personArgs[1]));

        hashSet.Add(person);
        sortedSet.Add(person);
    }

    Console.WriteLine(hashSet.Count);
    Console.WriteLine(sortedSet.Count);
}

// Problem 8
void Problem8()
{
    Console.WriteLine("Problem 8");
    Console.WriteLine("Commands count: ");
    var pets = new List<Pet>();
    var clinics = new List<Clinic>();
    var commandsCount = int.Parse(Console.ReadLine());

    for (int i = 0; i < commandsCount; i++)
    {
        Console.WriteLine($"Waiting for your command({commandsCount - i - 1} is left): ");
        
        var args = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var command = args[0];

        switch (command)
        {
            case "Create":
                Create(args, ref pets, ref clinics);
                break;

            case "Add":
                // Add {pet's name} {clinic's name}
                Pet currentPet = pets.FirstOrDefault(p => p.Name.Equals(args[1]));
                Console.WriteLine(clinics.FirstOrDefault(c => c.Name.Equals(args[2])).AddPet(currentPet));
                break;

            case "Release":
                // Release {clinic's name}
                Console.WriteLine(clinics.FirstOrDefault(c => c.Name.Equals(args[1])).Release());
                break;

            case "HasEmptyRooms":
                // HasEmptyRooms {clinic’s name}
                Console.WriteLine(clinics.FirstOrDefault(c => c.Name.Equals(args[1])).HasEmptyRooms());
                break;

            case "Print":
                Print(args, ref clinics);
                break;
        }
    }
}

#region Problem 03 Helper methods

string GetStringResult(StackProblem3<int> stack)
{
    var sb = new StringBuilder();
    while (stack.Count() != 0)
    {
        sb.AppendLine($"{stack.Pop()}");
    }

    return sb.ToString().Trim();
}

#endregion

#region Problem 5 Helper methods

int GetNotEqualsPeople(PersonProblem5 person, List<PersonProblem5> people)
{
    var counter = 0;
    foreach (var currentPerson in people)
    {
        if (person.CompareTo(currentPerson) != 0)
        {
            counter++;
        }
    }

    return counter;
}

int GetEqualsPeople(PersonProblem5 person, List<PersonProblem5> people)
{
    var counter = 0;
    foreach (var currentPerson in people)
    {
        if (person.CompareTo(currentPerson) == 0)
        {
            counter++;
        }
    }

    return counter;
}

#endregion

#region Problem 8 Helper method

void Print(string[] args, ref List<Clinic> clinics)
{
    string clinicName = args[1];

    // Print {clinic's name}
    if (args.Length == 2)
    {
        Clinic currentClinic = clinics.FirstOrDefault(c => c.Name.Equals(clinicName));

        foreach (Pet pet in currentClinic)
        {
            if (pet != null)
            {
                Console.WriteLine(pet);
            }
            else
            {
                Console.WriteLine("Room empty");
            }
        }
    }

    // Print {clinic's name} {room}
    else if (args.Length == 3)
    {
        int room = int.Parse(args[2]);
        Clinic currentClinic = clinics.FirstOrDefault(c => c.Name.Equals(clinicName));
        Console.WriteLine(currentClinic.Print(room));
    }
}

void Create(string[] args, ref List<Pet> pets, ref List<Clinic> clinics)
{
    switch (args[1])
    {
        // Create Pet {name} {age} {kind}
        case "Pet":
        {
            string petName = args[2];
            int petAge = int.Parse(args[3]);
            string kind = args[4];

            pets.Add(new Pet(petName, petAge, kind));
            break;
        }
        // Create Clinic {name} {rooms}
        case "Clinic":
        {
            string clinicName = args[2];
            int roomsCount = int.Parse(args[3]);

            try
            {
                clinics.Add(new Clinic(clinicName, roomsCount));
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }

            break;
        }
    }
}

#endregion