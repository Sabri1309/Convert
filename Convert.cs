using System;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: dotnet run <value> <unit>");
            return;
        }

        double inches;
        if (!double.TryParse(args[0], out inches))
        {
            Console.WriteLine("Invalid input. Please provide a valid number for inches.");
            return;
        }

        string unit = args[1].ToLower();
        double result;

        switch (unit)
        {
            case "-mm":
                result = ConvertToMillimeters(inches);
                Console.WriteLine($"{result} mm");
                break;
            case "-cm":
                result = ConvertToCentimeters(inches);
                Console.WriteLine($"{result} cm");
                break;
            case "-m":
                result = ConvertToMeters(inches);
                Console.WriteLine($"{result} m");
                break;
            default:
                Console.WriteLine("Invalid unit. Please use -mm, -cm, or -m.");
                break;
        }
    }

    // Conversion methods
    static double ConvertToMillimeters(double inches)
    {
        return inches * 25.4;
    }

    static double ConvertToCentimeters(double inches)
    {
        return inches * 2.54;
    }

    static double ConvertToMeters(double inches)
    {
        return inches * 0.0254;
    }

    // Tests
    static void RunTests()
    {
        double input = 3;

        // Test case 1
        double expected = 76.2; // 3 inches = 76.2 mm
        double actual = ConvertToMillimeters(input);

        PrintTestResult(expected, actual);

        // Test case 2
        expected = 7.62; // 3 inches = 7.62 cm
        actual = ConvertToCentimeters(input);

        PrintTestResult(expected, actual);

        // Test case 3
        expected = 0.0762; // 3 inches = 0.0762 m
        actual = ConvertToMeters(input);

        PrintTestResult(expected, actual);
    }

    static void PrintTestResult(double expected, double actual)
    {
        if (Math.Abs(expected - actual) < 0.001)
        {
            Console.WriteLine("🟢 Test passed");
        }
        else
        {
            Console.WriteLine("🔴 Test failed");
        }
    }
}
