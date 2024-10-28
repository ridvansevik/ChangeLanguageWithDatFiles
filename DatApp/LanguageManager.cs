using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatApp
{

    class LanguageManager
    {
        private readonly Dictionary<string, Dictionary<string, string>> _translations = new();
        private string _currentLanguage = "EN";

        public LanguageManager(string filePath)
        {
            LoadLanguageFile(filePath);
        }

        // Loads translations from the specified file
        private void LoadLanguageFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"The file {filePath} was not found.");
            }

            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(':');
                if (parts.Length != 3)
                {
                    Console.WriteLine($"Invalid line format in language file: {line}");
                    continue;
                }

                string languageCode = parts[0].Trim();
                string translationKey = parts[1].Trim();
                string translationValue = parts[2].Trim();

                if (!_translations.ContainsKey(languageCode))
                {
                    _translations[languageCode] = new Dictionary<string, string>();
                }

                _translations[languageCode][translationKey] = translationValue;
            }
        }

        // Retrieves the translation for the specified key in the current language
        public string GetTranslation(string key)
        {
            return _translations.TryGetValue(_currentLanguage, out var langDictionary) &&
                   langDictionary.TryGetValue(key, out var value)
                ? value
                : key;
        }

        // Prompts the user to change the language and sets the current language accordingly
        public void ChangeLanguage()
        {
            Console.Clear();
            Console.WriteLine(GetTranslation("SelectLanguage"));

            // Display available languages
            var languageCodes = new List<string>(_translations.Keys);
            for (int i = 0; i < languageCodes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {languageCodes[i]}");
            }

            // Read user choice and set the current language
            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= languageCodes.Count)
            {
                _currentLanguage = languageCodes[choice - 1];
                Console.WriteLine($"{GetTranslation("LanguageChanged")} {_currentLanguage}");
            }
            else
            {
                Console.WriteLine(GetTranslation("InvalidSelection"));
            }
        }
    }

}
