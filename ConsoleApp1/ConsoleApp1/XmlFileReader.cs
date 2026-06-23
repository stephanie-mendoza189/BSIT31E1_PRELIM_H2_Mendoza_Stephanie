using System;
using System.IO;
using System.Xml.Linq;

namespace ConsoleApp1;

/// <summary>
/// Reads and displays the contents of XML (.xml) files.
/// </summary>
public class XmlFileReader : BaseFileReader
{
    /// <summary>
    /// Gets the supported format identifier for this reader.
    /// </summary>
    public override string SupportedFormat => "XML";

    /// <summary>
    /// Reads the XML file, counts descendant nodes, and displays the first 100 characters.
    /// </summary>
    /// <param name="filePath">The full path to the .xml file.</param>
    protected override void ParseContent(string filePath)
    {
        Console.WriteLine(" -> Opening XML stream...");

        string fullText = File.ReadAllText(filePath);
        XDocument doc = XDocument.Load(filePath);

        string rootName = doc.Root?.Name.LocalName ?? "unknown";
        int descendantCount = 0;

        foreach (var node in doc.Descendants())
        {
            descendantCount++;
        }

        Console.WriteLine($" -> Root element: <{rootName}> with {descendantCount} descendant nodes.");

        string displayContent = fullText.Length > 100
            ? fullText.Substring(0, 100) + "..."
            : fullText;

        Console.WriteLine("\n--- First 100 Characters ---");
        Console.WriteLine(displayContent);
        Console.WriteLine("----------------------------\n");
    }
}