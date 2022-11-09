using System.Collections.Specialized;

namespace MyDictionary
{
    /// <summary>
    /// класс для добавления слов в словарь
    /// </summary>
    public static class AddWordMyDictionary
    {
        public static bool InputWordInMyDictionary(List<English> listDictionary, out English? newWord)
        {
            newWord = null;
            Console.WriteLine($"Введите английское слово");
            string? UserInputWord = Console.ReadLine();
            if (CheckingUserInputData.CheckingTheEnglishWord(UserInputWord) == false)
                return false;
            else if (listDictionary.Where(x => x.Word.Equals(UserInputWord)).FirstOrDefault() != null)
            {
                Console.WriteLine($"Такое слово уже есть в словаре");
                return false;
            }
            else
            {
                Console.WriteLine($"Введите перевод одно или несколько слов через запятую");
                string? UserInputTranslate = Console.ReadLine();
                if (CheckingUserInputData.CheckingTheRussianWordsTranslate(UserInputTranslate) == false)
                    return false;
                else
                {
                    Console.WriteLine($"{UserInputWord}-{UserInputTranslate}");
                    Console.WriteLine($"Ввести в словарь? да/нет");
                    string? UserInputYN = Console.ReadLine();
                    if (String.IsNullOrEmpty(UserInputYN) || UserInputYN.Equals("нет", StringComparison.InvariantCultureIgnoreCase))
                        return false;
                    else if (UserInputYN.Equals("да", StringComparison.InvariantCultureIgnoreCase))
                    {
                        //здесь формируем экземпляр и пытаемся ввести слово в словарь и сохранить его 
                         newWord = new English(UserInputWord, UserInputTranslate.Split(",").ToList());
                        //listDictionary.Add(NewWord);

                        return true;
                    }
                    else
                        return false;

                }


            }


            // var translateEng = new English(EngDictionary.Word, UserInputTranslationChecked.Split(',').ToList());

            return false;
        }
    }
}
