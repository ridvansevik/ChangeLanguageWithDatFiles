using System;

namespace DatApp
{
    class DatApp
    {
        private readonly LanguageManager _languageManager;

        public DatApp(string languageFilePath)
        {
            _languageManager = new LanguageManager(languageFilePath);
        }

        // Main application loop
        public void Run()
        {
            bool exit = false;
            while (!exit)
            {
                ShowMenu();
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine(_languageManager.GetTranslation("Entered"));
                            break;
                        case 2:
                            _languageManager.ChangeLanguage();
                            break;
                        case 3:
                            Console.WriteLine(_languageManager.GetTranslation("Goodbye"));
                            exit = true;
                            break;
                        default:
                            Console.WriteLine(_languageManager.GetTranslation("InvalidSelection"));
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(_languageManager.GetTranslation("InvalidInput"));
                }

                if (!exit)
                {
                    Console.WriteLine(_languageManager.GetTranslation("PressEnterToContinue"));
                    Console.ReadLine();
                }
            }
        }

        private void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(_languageManager.GetTranslation("Welcome"));
            Console.WriteLine("1. " + _languageManager.GetTranslation("Enter"));
            Console.WriteLine("2. " + _languageManager.GetTranslation("ChangeLanguage"));
            Console.WriteLine("3. " + _languageManager.GetTranslation("Exit"));
        }
    }
}
