using System.Collections.Generic;
using System.IO;
using HelloWorld.Tests;

public class TestHelper
{
    public void PopulateCSVWithInitialState(string filePath)
    {
        var content = new List<string> {"Name", "Kathleen"};
        File.WriteAllLines(filePath, content);
    }
}