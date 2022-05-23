using Labyrinths.Model.Structures;

namespace Labyrinths.Model
{
    public class DijkstrasAlgorithm
    {
        protected readonly List<Vertice> Vertices;
        protected readonly int[][] DistanceMatrix;

        public DijkstrasAlgorithm(List<Vertice> vertices, int[][] distanceMatrix)
        {
            Vertices = vertices;
            DistanceMatrix = distanceMatrix;
        }
        public bool FindRoute(int startPointIndex, int endPointIndex)
        {
            PriorityQueue<int> queue = new();
            Vertices[startPointIndex].MinDistance = 0;
            queue.Push(startPointIndex, 0);


            while (queue.Count > 0)
            {
                int currentVertice = queue.Pop();
                if (currentVertice == endPointIndex) return true;
                foreach (int adjacent in Vertices[currentVertice].AdjacentVertices)
                {
                    if (Vertices[adjacent].MinDistance >
                        Vertices[currentVertice].MinDistance + DistanceMatrix[currentVertice][adjacent])
                    {
                        Vertices[adjacent].MinDistance =
                            Vertices[currentVertice].MinDistance + DistanceMatrix[currentVertice][adjacent];
                        Vertices[adjacent].Previous = currentVertice;
                    }

                    if (!Vertices[adjacent].Passed)
                    {
                        queue.Push(adjacent, GetCriteria(Vertices[adjacent], Vertices[endPointIndex]));
                    }
                }

                Vertices[currentVertice].Passed = true;
            }

            return false;
        }

        protected virtual double GetCriteria(Vertice current, Vertice finish)
        {
            return current.MinDistance;
        }

        public Structures.Stack<int> TraceRoute(int finishIndex)
        {
            Structures.Stack<int> route = new();
            int current = finishIndex;
            while (current > -1)
            {
                route.Push(current);
                current = Vertices[current].Previous;
            }

            return route;
        }
    }
}