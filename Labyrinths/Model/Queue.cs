namespace Labyrinths.Model;

public class Queue
{
   
    public int Count { get; protected set; }
    public Node? Head { get; set; }

    public Queue()
    {
        Count = 0;
        Head = null;
    }

    public void Push(Vertice value)
    {
        Node newNode = new Node(value);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node last = Head;
            while (last.Next != null) last = last.Next;
            last.Next = newNode;
        }
        Count++;
    }
    
    public Vertice? Pop()
    {
        if (Head == null) return null;
        Node headNode = Head;
        Head = Head.Next;
        Count--;
        return headNode.Value;
    }
}
