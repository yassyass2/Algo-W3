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
        if (Head == default) return false;


        SingleNode<T>? prev = null;
        SingleNode<T>? current = Head;

        while (current != null && current.Value.CompareTo(value) != 0)
        {
            prev = current;
            current = current.Next;
        }


        if (current == null) return false;

        prev.Next = current.Next;

        return true;
    }

    public SingleNode<T>? Search(T value)
    {
        if (Head == null){
            return default;
        }
        var current = Head;
        while (current != null && current.Value != value){
            current = current.Next;
        }
        return current;
    }

    public bool Contains(T value) => Search(value) != null;

    public void AddSorted(T value)
    {
        if (Head == null || Head.Value.CompareTo(value) > 0){
            AddFirst(value);
            return;
        }

        var current = Head;
        while (current.Next != null && current.Next.Value.CompareTo(value) <= 0){
            current = current.Next;
        }
        current.Next = new SingleNode<T>(value, current.Next);
    }

    public void Clear()
    {
        count = 0;
        Head = null;
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