namespace Labyrinths.Model;

public class LabyrinthProcessor
{
    public List<Vertice> GetVerticeList(string[] fileContent, int startPointX, int startPointY, int endPointX, int endPointY)
    {
        List<Vertice> verticeList = new List<Vertice>();
        for (int i = 1; i < fileContent.Length - 1; i++)
        {
            for (int j = 1; j < fileContent[i].Length - 1; j++)
            {
                if (fileContent[i][j] == ' ' && (!IsTunnel(fileContent, i, j) ||
                      i == fileContent.Length - startPointX - 1 && j == startPointY ||
                      i == fileContent.Length - endPointX - 1 && j == endPointY))
                {
                    verticeList.Add(new Vertice(fileContent.Length - i - 1, j));
                }
            }
        }
        
        return verticeList;
    }

    private static bool IsTunnel(string[] labyrinth, int i, int j)
    {
        return labyrinth[i][j - 1] == labyrinth[i][j + 1] && labyrinth[i - 1][j] == labyrinth[i + 1][j] && 
               (labyrinth[i][j + 1] != labyrinth[i - 1][j] || labyrinth[i][j + 1] == 'X' && labyrinth[i - 1][j] == 'X');
    }
}