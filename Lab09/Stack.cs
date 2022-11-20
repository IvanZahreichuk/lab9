using System.Collections;

namespace Lab09;

public class StackProblem3<T> : IEnumerable<T>
{
    private IList<T> customStack;

    public StackProblem3()
    {
        this.customStack = new List<T>();
    }

    public void Push(T item)
    {
        this.customStack.Insert(0, item);
    }

    public T Pop()
    {
        if (!this.customStack.Any())
        {
            throw new ArgumentException("No elements");
        }

        var popedItem = customStack.First();
        customStack.RemoveAt(0);
        return popedItem;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.customStack.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}