namespace Labyrinths.Model;

public class FileContentProcessor
{
    public static string[] RemoveRedundantWhitespaces(string[] fileContent)
    {
        string[] modifiedContent = new string[fileContent.Length];
        for (int i = 0; i < fileContent.Length; i++)
        {
            modifiedContent[i] = "";
            for (int j = 0; j < fileContent[i].Length; j += 2)
            {
                modifiedContent[i] += fileContent[i][j];
            }
        }

        return modifiedContent;
    }
    
    
}