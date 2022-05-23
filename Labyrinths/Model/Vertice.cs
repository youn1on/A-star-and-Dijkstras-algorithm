namespace Labyrinths.Model;

public class Vertice
{
    public int X { get; }
    public int Y { get; }
    
    int minDist = Int32.MaxValue;
    bool passed = false;
    public List<Vertice> AdjacentVertices;

    public Vertice(int x, int y)
    {
        X = x;
        Y = y;
        AdjacentVertices = new List<Vertice>();
    }

}