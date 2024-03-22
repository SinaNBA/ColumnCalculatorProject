using ColumnCalculatorProject;

namespace ColumnCalculatorTest;

public class Tests
{
    [TestCase("")]
    public void FilePath_ThrowsException_GivenEmptyString(string filePath)
    {
        Assert.That(() => Program.CalculateColumns(filePath), Throws.TypeOf<ArgumentException>().With.Message.Contain("The file path is empty!"));
    }

    [TestCase("D:\\Projects\\Peter's homeworks\\8\\Input1.exe +")]
    public void FilePath_ThrowsException_GivenInvalidExtension(string filePath)
    {
        Assert.That(() => Program.CalculateColumns(filePath), Throws.TypeOf<InvalidOperationException>().With.Message.Contain("The file path extension is not valid!"));
    }

    [TestCase("D:\\Projects\\Peter's homeworks\\8\\Input1.csv ^")]
    public void FilePath_ThrowsException_GivenInvalidOperator(string filePath)
    {
        Assert.That(() => Program.CalculateColumns(filePath), Throws.TypeOf<ArgumentOutOfRangeException>().With.Message.Contain("The operator is not valid!"));
    }

    [TestCase("D:\\Projects\\Peter's homeworks\\8\\Input4.csv +")]
    public void FilePath_ThrowsException_GivenInvalidFilePath(string filePath)
    {
        Assert.That(() => Program.CalculateColumns(filePath), Throws.TypeOf<ArgumentException>().With.Message.Contain("The file path does not exist."));
    }

    [TestCase("D:\\Projects\\Peter's homeworks\\8\\TestInput.csv +")]
    [TestCase("D:\\Projects\\Peter's homeworks\\8\\TestInput.csv -")]
    [TestCase("D:\\Projects\\Peter's homeworks\\8\\TestInput.csv *")]
    [TestCase("D:\\Projects\\Peter's homeworks\\8\\TestInput.csv /")]
    [TestCase("D:\\Projects\\Peter's homeworks\\8\\TestInput.csv r")]
    [TestCase("D:\\Projects\\Peter's homeworks\\8\\TestInput.csv e")]
    public void CalculateColumns_ReturnsResultsList_GivenValidFilePathWithValidOperators(string filePath)
    {
        string operatorInput = filePath.Substring(filePath.Length - 1, 1);
        List<double> testResults = [];

        switch (operatorInput)
        {
            case "+":
                testResults.AddRange([204, 603, 802]);
                break;
            case "-":
                testResults.AddRange([196, 597, 798]);
                break;
            case "*":
                testResults.AddRange([800, 1800, 1600]);
                break;
            case "/":
                testResults.AddRange([50, 200, 400]);
                break;
            case "r":
                testResults.AddRange([204, 603, 802]);
                break;
            case "e":
                testResults.AddRange([1600000000, 216000000, 640000]);
                break;
        }

        Assert.That(() => Program.CalculateColumns(filePath), Is.EqualTo(testResults));
    }

    [TestCase("D:\\Projects\\Peter's homeworks\\8\\TestInput.csv +")]
    public void CalculateColumns_SkipsHeaderComputeTheRest_GivenFilePathWithHeader(string filePath)
    {
        List<double> testResults = [204, 603, 802];
        Assert.That(() => Program.CalculateColumns(filePath), Is.EqualTo(testResults));
    }
}