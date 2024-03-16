namespace ColumnCalculatorProject;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the file path and the desired operator, separated by a space. The format should be 'FileName Operator(+ - * / r (meaning round) and e (meaning exponent))'.");
        bool validInput = false;
        List<int> tempArrayToKeepinputs;
        List<List<int>>? numberPairsList = new List<List<int>>();

        while (!validInput)
        {
            //D:\Projects\Peter's homeworks\8\Input1.csv

            string? filePathAndOperator;
            filePathAndOperator = Console.ReadLine();
            string filePath;
            string operatorInput;

            if (!string.IsNullOrEmpty(filePathAndOperator))
            {
                operatorInput = filePathAndOperator.Substring(filePathAndOperator.Length-1,1);
                filePath=filePathAndOperator.Substring(0,filePathAndOperator.Length-1);

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("The file path does not exist.");
                }
                else
                {
                    var reader = new StreamReader(filePath);
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                        tempArrayToKeepinputs = line.Split(',').Select(int.Parse).ToList();
                        numberPairsList.Add(new List<int>(tempArrayToKeepinputs));

                    }

                    validInput = true;
                }
            }
            else
            {
                Console.WriteLine("The file path is empty!");
            }

            
        }
        foreach (var element in numberPairsList)
        {
            Console.WriteLine(element);
        }
    }
}
