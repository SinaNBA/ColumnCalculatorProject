namespace ColumnCalculatorProject;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your file path:");
        bool validInput=false;
        string[]? tempArrayToKeepinputs;
        List<int>? resultValues=new List<int>();

        while (!validInput)
        {
            //D:\Projects\Peter's homeworks\8\Input1.csv

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
                    tempArrayToKeepinputs = line.Split(',');
                    resultValues.Add(tempArrayToKeepinputs.Sum(int.Parse));                   
                    
                }

                validInput= true;
            }
        }
        foreach(var element in resultValues)
        {
            Console.WriteLine(element);
        }
    }
}
