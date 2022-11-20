namespace Lab09;

public class AgeComparer : IComparer<PersonProblem6>
{
    public int Compare(PersonProblem6 x, PersonProblem6 y)
    {
        return x.Age.CompareTo(y.Age);
    }
}