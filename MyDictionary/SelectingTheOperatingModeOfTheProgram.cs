using System.Collections.Specialized;

namespace MyDictionary
{
    /// <summary>
    /// класс для выбора режима работы программы
    /// </summary>
    public static class SelectingTheOperatingModeOfTheProgram
    {

        public static int SelectModeOfTheProgram(string? UserInputCode)
        {

            if (String.IsNullOrEmpty(UserInputCode) || UserInputCode.Equals("1"))
            {
                Console.WriteLine("Вы выбрали изучение слов");
                return 1;
            }
            else if (UserInputCode.Equals("2"))
            {
                Console.WriteLine("Вы выбрали добавление слов в словарь");
                return 2;
            }
            else if (UserInputCode.Equals("3"))
            {
                Console.WriteLine("Вы выбрали редактирование словаря");
                return 3;
            }
            else if (UserInputCode.Equals("4"))
            {
                Console.WriteLine("Вы выбрали удаление слова");
                return 4;
            }
            else if (UserInputCode.Equals("5"))
            {
                Console.WriteLine("Вы выбрали поиск слова");
                return 5;
            }
            else
            {
                Console.WriteLine("Выход из программы");
                return 0;
            }
           
        }
    }
}
