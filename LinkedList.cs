using System.Collections;

namespace Solution;

public class SinglyLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    public SingleNode<T>? Head;
    private int count;

    public SinglyLinkedList()
    {
        Head = null;
        count = 0;
    }

    public int Count => count;

    public void AddFirst(T value)
    {
        SingleNode<T> newNode = new SingleNode<T>(value, Head);

        Head = newNode;

        count++;
    }

    public void AddLast(T value)
    {
        SingleNode<T> newNode = new SingleNode<T>(value);
        if (Head == null){
            Head = newNode;
        }
        else{
            SingleNode<T> current = Head;
            while (current.Next != null){
                current = current.Next;
            }

            current.Next = newNode;
        }

        count++;
    }

    public bool Remove(T value)
    {
        throw new NotImplementedException();
    }

    public SingleNode<T>? Search(T value)
    {
        throw new NotImplementedException();
    }

    public bool Contains(T value) => throw new NotImplementedException();

    public void AddSorted(T value)
    {
        if (Head == null || Head.Value.CompareTo(value) > 0){
            Head = new SingleNode<T>(value, Head);
        }

        var current = Head;
        while (current.Next != null && current.Next.Value.CompareTo(value) > 0){
            current = current.Next;
        }
        current.Next = new SingleNode<T>(value, current.Next);
    }

    public void Clear()
    {
        throw new NotImplementedException();
    }

    public IEnumerator<T> GetEnumerator()
    {
        SingleNode<T>? current = Head;
        while (current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

}