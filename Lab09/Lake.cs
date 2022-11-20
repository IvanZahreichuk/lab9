using System.Collections;

namespace Lab09;

public class Lake : IEnumerable<int>
{
    private readonly IList<int> _stonesNumbers;

    public Lake(IList<int> stonesNumbers)
    {
        this._stonesNumbers = stonesNumbers;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this._stonesNumbers.Count; i += 2)
        {
            yield return this._stonesNumbers[i];
        }

        var reverseStartPoint = this._stonesNumbers.Count - 1;

        if (this._stonesNumbers.Count % 2 != 0)
        {
            reverseStartPoint = this._stonesNumbers.Count - 2;
        }

        for (int i = reverseStartPoint; i > 0; i -= 2)
        {
            yield return this._stonesNumbers[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}