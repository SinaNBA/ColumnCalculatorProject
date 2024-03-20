namespace ColumnCalculatorProject;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter the file path and the desired operator, separated by a space. The format should be 'FileName Operator(+ - * / r (meaning round) and e (meaning exponent))'.");

        //D:\Projects\Peter's homeworks\8\Input1.csv
        var filePathAndOperatorInput = Console.ReadLine();

        bool validInput = false;
        while (!validInput)
        {
            try
            {
                if (!string.IsNullOrEmpty(filePathAndOperatorInput))
                {
                    string filePath, operatorInput;
                    operatorInput = filePathAndOperatorInput.Substring(filePathAndOperatorInput.Length - 1, 1);
                    filePath = filePathAndOperatorInput.Substring(0, filePathAndOperatorInput.Length - 2);

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

                                var results = new List<int>();
                                switch (operatorInput)
                                {//"+", "-", "*", "/", "r", "e"
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
                                            results.Add((int)Math.Round((double)pair.Item1 + pair.Item2));
                                        }
                                        break;
                                    case "e":
                                        foreach (var pair in pairs)
                                        {
                                            results.Add((int)Math.Pow(pair.Item1, pair.Item2));
                                        }
                                        break;

                                }

                                foreach (var item in results)
                                {
                                    Console.WriteLine(item);
                                }


                                validInput = true;
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
        string[] validExtentions = ["+", "-", "*", "/", "r", "e"];
        if (!string.IsNullOrEmpty(operatorInput))
        {
            foreach (string opt in validExtentions)
            {
                if (operatorInput.ToLower().Equals(opt)) { return true; }
            }
        }
        return false;
    }

    public static List<List<int>> FilterOutNonNumericValues(List<List<int>> values)
    {
        throw new NotImplementedException();
    }
}
