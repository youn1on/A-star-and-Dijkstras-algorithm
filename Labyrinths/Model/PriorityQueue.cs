namespace Labyrinths.Model;

public class PriorityQueue : Queue
{
    public PriorityQueue() : base()
    {
        
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
    
    
}