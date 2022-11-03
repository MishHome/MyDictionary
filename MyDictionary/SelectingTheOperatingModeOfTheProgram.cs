using System.Collections.Specialized;

namespace MyDictionary
{
    public static class SelectingTheOperatingModeOfTheProgram
    {
        public static int SelectModeOfTheProgram(string? UserInputCode)
        {
            if (UserInputCode.Equals("0"))
                return;
            else if (UserInputCode.Equals("2"))
            {
                if (AddWordMyDictionary.InputWordInMyDictionary(listDictionary))
                {
                    MyJson.SaveJson(NameFileJson, listDictionary);
                }
                return;
            }
            else if (String.IsNullOrEmpty(UserInputCode) || UserInputCode.Equals("1"))
                Console.WriteLine("Вы выбрали работу со словарём");
            else
                return;

            return 0;
        }
    }
}
