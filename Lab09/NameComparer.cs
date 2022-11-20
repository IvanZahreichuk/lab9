namespace Lab09;

public class NameComparer : IComparer<PersonProblem6>
{
    public int Compare(PersonProblem6 x, PersonProblem6 y)
    {
        var result = x.Name.Length.CompareTo(y.Name.Length);
        if (result == 0)
        {
            result = char.ToLower(x.Name[0]).CompareTo(char.ToLower(y.Name[0]));
        }

        return result;
    }
}