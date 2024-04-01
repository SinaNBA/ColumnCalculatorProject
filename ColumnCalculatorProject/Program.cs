namespace ColumnCalculatorProject;

public class Program
{
    static void Main(string[] args)
    {
        bool continueProgram = true;
        while (continueProgram)
        {
            try
            {
                Console.WriteLine("Please enter the file path(relative or absolute path) and the desired operator, separated by a space. The format should be 'FileName Operator(+ - * / r (meaning round) and e (meaning exponent))'.");
                var filePathWithOperatorInput = Console.ReadLine();

                CalculateColumns(filePathWithOperatorInput);

                Console.WriteLine("Press 'c' to continue or any other key to quit");
                continueProgram = Console.ReadLine().ToLower() == "c";
            }
            catch (ArgumentOutOfRangeException argOrEx)
            {
                Console.WriteLine($"[ERROR] {argOrEx.Message}");
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine($"[ERROR] {argEx.Message}");
            }
            catch (InvalidOperationException InvOpEx)
            {
                Console.WriteLine($"[ERROR] {InvOpEx.Message}");
            }

        }

    }

    public static List<double> CalculateColumns(string? filePathWithOperatorInput)
    {
        if (!string.IsNullOrEmpty(filePathWithOperatorInput))
        {
            string filePath, operatorInput;
            operatorInput = filePathWithOperatorInput.Substring(filePathWithOperatorInput.Length - 1, 1);
            filePath = filePathWithOperatorInput.Substring(0, filePathWithOperatorInput.Length - 2);

            if (IsValidExtension(filePath))
            {
                if (IsValidOperator(operatorInput))
                {
                    if (File.Exists(filePath))
                    {
                        StreamReader reader = new StreamReader(filePath);
                        string? line;
                        var pairs = new List<Tuple<int, int>>();

                        while ((line = reader.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                            string[] values = line.Split(',');
                            if (int.TryParse(values[0], out int num1) && int.TryParse(values[1], out int num2))
                            {
                                pairs.Add(Tuple.Create(num1, num2));
                            }

                        }

                        var results = new List<double>();
                        switch (operatorInput)
                        {
                            case "+":
                                foreach (var pair in pairs)
                                {
                                    results.Add(pair.Item1 + pair.Item2);
                                }
                                break;
                            case "-":
                                foreach (var pair in pairs)
                                {
                                    results.Add(pair.Item1 - pair.Item2);
                                }
                                break;
                            case "*":
                                foreach (var pair in pairs)
                                {
                                    results.Add(pair.Item1 * pair.Item2);
                                }
                                break;
                            case "/":
                                foreach (var pair in pairs)
                                {
                                    results.Add(pair.Item1 / pair.Item2);
                                }
                                break;
                            case "r":
                                foreach (var pair in pairs)
                                {
                                    results.Add(Math.Round((double)pair.Item1 + pair.Item2));
                                }
                                break;
                            case "e":
                                foreach (var pair in pairs)
                                {
                                    results.Add(Math.Pow(pair.Item1, pair.Item2));
                                }
                                break;

                        }

                        PrintAndWriteOutputDataToFile(results, filePath);

                        return results;
                    }
                    else
                    {
                        throw new ArgumentException("The file path does not exist.");
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("The operator is not valid!");
                }


            }
            else
            {
                throw new InvalidOperationException("The file path extension is not valid!");
            }
        }
        else
        {
            throw new ArgumentException("The file path is empty!");
        }
    }

    public static bool IsValidExtension(string filePathExtension)
    {
        string[] validExtentions = [".txt", ".csv"];
        if (!string.IsNullOrEmpty(filePathExtension))
        {
            string extension = Path.GetExtension(filePathExtension).ToLower().Trim();
            foreach (string ext in validExtentions)
            {
                if (extension.Equals(ext)) { return true; }
            }
        }
        return false;
    }

    public static bool IsValidOperator(string operatorInput)
    {
        string[] validOperators = ["+", "-", "*", "/", "r", "e"];
        if (!string.IsNullOrEmpty(operatorInput))
        {
            foreach (string opt in validOperators)
            {
                if (operatorInput.ToLower().Equals(opt)) { return true; }
            }
        }
        return false;
    }

    public static void PrintAndWriteOutputDataToFile(List<double> results, string filePath)
    {
        string outputFilePath = Directory.GetParent(filePath).ToString() + @"\TestOutput.txt";
        string resultsString = "";

        foreach (var item in results)
        {
            Console.WriteLine(item);
            resultsString += item.ToString() + Environment.NewLine;
        }

        File.WriteAllText(outputFilePath, resultsString);
    }
}
