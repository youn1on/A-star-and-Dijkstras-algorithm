namespace Labyrinths.Model;

public class Node
{
    public Vertice Value { get; }
    public Node? Next { get; set; }

    public Node (Vertice value)
    {
        Value = value;
        Next = null;
    }
}