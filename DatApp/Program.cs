using System;

class Program
{
    static void Main(string[] args)
    {

        // Corrected initialization of the DatApp instance
        DatApp.DatApp app = new DatApp.DatApp("language.dat");

        // Run the application
        app.Run();
    }
}
