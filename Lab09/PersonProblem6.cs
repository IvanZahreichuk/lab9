namespace Lab09;

public class PersonProblem6
{
    public string Name { get; set; }
    public int Age { get; set; }

    public PersonProblem6(string name, int age)
    {
        this.Name = name;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Age}";
    }
}