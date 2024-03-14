namespace ColumnCalculatorProject;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your file path:");
        bool validInput=false;

        while (!validInput)
        {
            string? filePath = Console.ReadLine();

            if (filePath == null || !File.Exists(filePath))
            {
                Console.WriteLine("The file path is empty or does not exist.");
            }
            else
            {
                var reader = new StreamReader(filePath);
                string? line;
                while ((line = reader.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                }

                validInput= true;
            }
        }
    }
}
