namespace Lab09;

public class PersonProblem7 : IEqualityComparer<PersonProblem7>, IComparable<PersonProblem7>
{
    public string Name { get; protected set; }
    public int Age { get; protected set; }

    public PersonProblem7(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override bool Equals(object obj)
    {
        var objAsPerson = obj as PersonProblem7;
        return this.Name == objAsPerson.Name && this.Age == objAsPerson.Age;
    }

    public override int GetHashCode()
    {
        return this.Name.GetHashCode() + this.Age.GetHashCode();
    }

    public int CompareTo(PersonProblem7 other)
    {
        var result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Age.CompareTo(other.Age);
        }

        return result;
    }

    public bool Equals(PersonProblem7 x, PersonProblem7 y)
    {
        return base.Equals(y);
    }

    public int GetHashCode(PersonProblem7 obj)
    {
        return base.GetHashCode();
    }
}