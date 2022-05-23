namespace Labyrinths.Model;

public class Node
{
    public Vertice Value { get; }
    public Node? Next { get; set; }
    public int Criteria { get; }


    public Node(Vertice value, int criteria = 0)
    {
        Value = value;
        Next = null;
        Criteria = criteria;
    }
}