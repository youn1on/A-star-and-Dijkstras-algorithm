namespace Labyrinths.Model;

public class Vertice
{
    public int X { get; }
    public int Y { get; }
    
    public int MinDist = Int32.MaxValue;
    public bool Passed = false;
    public List<int> AdjacentVertices;
    public int Last;

    public Vertice(int x, int y)
    {
        X = x;
        Y = y;
        AdjacentVertices = new List<int>();
        Last = -1;
    }

}