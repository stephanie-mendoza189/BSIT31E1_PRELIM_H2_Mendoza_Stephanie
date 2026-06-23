using System;
using System.IO;

namespace ConsoleApp1;

/// <summary>
/// Reads and displays the contents of CSV (.csv) files.
/// </summary>
public class CsvFileReader : BaseFileReader
{
    /// <summary>
    /// Gets the supported format identifier for this reader.
    /// </summary>
    public override string SupportedFormat => "CSV";

    /// <summary>
    /// Reads the CSV file, counts rows and columns, and displays the first 100 characters.
    /// </summary>
    /// <param name="filePath">The full path to the .csv file.</param>
    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening CSV stream...");

        string[] lines = File.ReadAllLines(filePath);
        int rowCount = lines.Length;

        int columnCount = 0;
        if (rowCount > 0)
        {
            string[] columns = lines[0].Split(',');
            columnCount = columns.Length;
        }

        Console.WriteLine($" -> Detected {rowCount} rows and {columnCount} columns.");

        string fullText = File.ReadAllText(filePath);
        string displayContent = fullText.Length > 100
            ? fullText.Substring(0, 100) + "..."
            : fullText;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}
