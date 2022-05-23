namespace Labyrinths.Model
{
    public class LabyrinthProcessor
    {
        public List<Vertice> GetVerticeList(int[][] labyrinth, int startPointX, int startPointY, int endPointX,
            int endPointY)
        {
            List<Vertice> verticeList = new List<Vertice>();
            for (int i = 1; i < labyrinth.Length - 1; i++)
            {
                for (int j = 1; j < labyrinth[i].Length - 1; j++)
                {
                    if (labyrinth[i][j] == 0 && (!IsTunnel(labyrinth, i, j) ||
                                                 i == startPointX && j == startPointY ||
                                                 i == endPointX && j == endPointY))
                    {
                        verticeList.Add(new Vertice(i, j));
                        labyrinth[i][j] = 2;
                    }
                }
            }

            return verticeList;
        }

        private static bool IsTunnel(int[][] labyrinth, int i, int j)
        {
            return labyrinth[i][j - 1] == labyrinth[i][j + 1] && labyrinth[i - 1][j] == labyrinth[i + 1][j] &&
                   (labyrinth[i][j + 1] != labyrinth[i - 1][j] || labyrinth[i][j + 1] == 1 && labyrinth[i - 1][j] == 1);
        }

        public static void SetAdjacent(List<Vertice> vertices, int[][] labyrinth)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = i + 1; j < vertices.Count; j++)
                {
                    if (IsAdjacent(vertices[i], vertices[j], labyrinth))
                    {
                        vertices[i].AdjacentVertices.Add(j);
                        vertices[j].AdjacentVertices.Add(i);
                    }
                }
            }
        }

        private static bool IsAdjacent(Vertice vertice1, Vertice vertice2, int[][] labyrinth)
        {
            if (vertice1.X != vertice2.X && vertice1.Y != vertice2.Y)
            {
                return false;
            }

            for (int j = Math.Min(vertice1.Y, vertice2.Y) + 1; j < Math.Max(vertice1.Y, vertice2.Y); j++)
            {
                if (labyrinth[vertice1.X][j] > 0) return false;
            }

            for (int i = Math.Min(vertice1.X, vertice2.X) + 1; i < Math.Max(vertice1.X, vertice2.X); i++)
            {
                if (labyrinth[i][vertice1.Y] > 0) return false;
            }

            return true;
        }

        public static int[][] GetDistanceMatrix(List<Vertice> vertices)
        {
            int[][] distanceMatrix = new int[vertices.Count][];
            for (int i = 0; i < vertices.Count; i++)
            {
                distanceMatrix[i] = new int[vertices.Count];
                foreach (int adjacent in vertices[i].AdjacentVertices)
                {
                    if (adjacent < i) continue;
                    distanceMatrix[i][adjacent] =
                        distanceMatrix[adjacent][i] = GetDistance(vertices[i], vertices[adjacent]);
                }
            }

            return distanceMatrix;
        }

        private static int GetDistance(Vertice vertice1, Vertice vertice2)
        {
            return (int) Math.Sqrt(Math.Pow(vertice1.X - vertice2.X, 2) + Math.Pow(vertice1.Y - vertice2.Y, 2));
        }
    }
}