using System;
using System.IO;
using System.Linq;

string dir = @"Challenge\FileCollection";
string resultsFile = "results.txt";

if (!Directory.Exists(dir))
{
    Directory.CreateDirectory(dir);
}

int xlsxCount = 0,
    docxCount = 0,
    pptxCount = 0;
long xlsxSize = 0,
    docxSize = 0,
    pptxSize = 0;

DirectoryInfo dirInfo = new DirectoryInfo(dir);

foreach (var file in dirInfo.GetFiles())
{
    Console.WriteLine($"Found file: {file.Name} with extension: {file.Extension}");

    if (IsOfficeFile(file.Extension))
    {
        switch (file.Extension.ToLower())
        {
            case ".xlsx":
                xlsxCount++;
                xlsxSize += file.Length;
                break;
            case ".docx":
                docxCount++;
                docxSize += file.Length;
                break;
            case ".pptx":
                pptxCount++;
                pptxSize += file.Length;
                break;
        }
    }
}

using (StreamWriter writer = new StreamWriter(resultsFile))
{
    writer.WriteLine("Summary of Office Files:");
    writer.WriteLine($"Excel files (.xlsx): Count = {xlsxCount}, Total Size = {xlsxSize} bytes");
    writer.WriteLine($"Word files (.docx): Count = {docxCount}, Total Size = {docxSize} bytes");
    writer.WriteLine(
        $"PowerPoint files (.pptx): Count = {pptxCount}, Total Size = {pptxSize} bytes"
    );
    writer.WriteLine(
        $"Total Office files: Count = {xlsxCount + docxCount + pptxCount}, Total Size = {xlsxSize + docxSize + pptxSize} bytes"
    );
}

Console.WriteLine("Summary written to results.txt");

static bool IsOfficeFile(string extension)
{
    string[] officeExtensions = { ".xlsx", ".docx", ".pptx" };
    return officeExtensions.Contains(extension.ToLower());
}