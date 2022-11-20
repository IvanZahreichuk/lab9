namespace Lab09;

public class PersonProblem5 : IComparable<PersonProblem5>
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Town { get; set; }

    public PersonProblem5(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }

    public int CompareTo(PersonProblem5 other)
    {
        var resultFromCompare = this.Name.CompareTo(other.Name);
        if (resultFromCompare == 0)
        {
            resultFromCompare = this.Age.CompareTo(other.Age);
        }

        if (resultFromCompare == 0)
        {
            resultFromCompare = this.Town.CompareTo(other.Town);
        }

        return resultFromCompare;
    }
}