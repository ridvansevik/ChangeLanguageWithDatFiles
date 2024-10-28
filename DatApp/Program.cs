using System;

class Program
{
    static void Main(string[] args)
    {
        // Use a relative path to the language.dat file
        string languageFilePath = "../../../../language.dat"; // Go one level up to the parent directory

        // Check if the file exists
        if (!System.IO.File.Exists(languageFilePath))
        {
            Console.WriteLine("The language file does not exist. Please check the path.");
            return;
        }

        // Initialize the DatApp instance with the relative file path
        DatApp.DatApp app = new DatApp.DatApp(languageFilePath);

        // Run the application
        app.Run();
    }
}
