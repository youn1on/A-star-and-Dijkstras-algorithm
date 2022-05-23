namespace Labyrinths.Model;

public class PriorityQueue : Queue
{
    public PriorityQueue() : base()
    {
        
    }

    public void Push(Vertice value, int criteria)
    {
        Node newNode = new Node(value, criteria);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node last = Head;
            while (last.Next != null || last.Next.Criteria<=newNode.Criteria) last = last.Next;
            newNode.Next = last.Next;
            last.Next = newNode;
        }
        Count++;
    }
    
    
}