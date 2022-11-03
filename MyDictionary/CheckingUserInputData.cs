namespace MyDictionary
{
    /// <summary>
    /// класс для проверки введённых данных пользователем
    /// </summary>
    public static class CheckingUserInputData
    {
        public static bool CheckingTheEnglishWord(string? CheckString)
        {
            if(String.IsNullOrEmpty(CheckString))
               return false;

            char[] engChars = {'a','b','c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            foreach (var ch in CheckString.ToLower())
            {
                if (engChars.Contains(ch)==false)
                    return false;
            }
             return true;
        }
        public static bool CheckingTheRussianWordsTranslate(string? CheckString)
        {
            if (String.IsNullOrEmpty(CheckString))
                return false;

            char[] engChars = { 'а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш','щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я', ',', ' ' };
            foreach (var ch in CheckString.ToLower())
            {
                if (engChars.Contains(ch) == false)
                    return false;
            }
            return true;
        }

    }
}
