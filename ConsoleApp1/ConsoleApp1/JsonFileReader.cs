using System;
using System.IO;
using System.Text.Json;

namespace ConsoleApp1;

/// <summary>
/// Reads and displays the contents of JSON (.json) files.
/// </summary>
public class JsonFileReader : BaseFileReader
{
    /// <summary>
    /// Gets the supported format identifier for this reader.
    /// </summary>
    public override string SupportedFormat => "JSON";

    /// <summary>
    /// Reads the JSON file, parses its root properties, and displays the first 100 characters.
    /// </summary>
    /// <param name="filePath">The full path to the .json file.</param>
    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening JSON stream...");

        string fullText = File.ReadAllText(filePath);

        using (JsonDocument doc = JsonDocument.Parse(fullText))
        {
            int propertyCount = 0;

            if (doc.RootElement.ValueKind == JsonValueKind.Object)
            {
                foreach (var property in doc.RootElement.EnumerateObject())
                {
                    propertyCount++;
                }
            }
            else if (doc.RootElement.ValueKind == JsonValueKind.Array)
            {
                propertyCount = doc.RootElement.GetArrayLength();
            }

            Console.WriteLine($" -> Parsed {propertyCount} root properties.");
        }

        string displayContent = fullText.Length > 100
            ? fullText.Substring(0, 100) + "..."
            : fullText;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}