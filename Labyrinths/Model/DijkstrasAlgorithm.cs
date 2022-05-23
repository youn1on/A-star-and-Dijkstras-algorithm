namespace Labyrinths.Model;

public class DijkstrasAlgorithm
{
    public static bool FindRoute(List<Vertice> vertices, int[][] distanceMatrix, int startPointIndex, Vertice endPointIndex )
    {
        PriorityQueue queue = new();
        vertices[startPointIndex].MinDist = 0;
        vertices[startPointIndex].Passed = true;
        
        return false;
    }
}