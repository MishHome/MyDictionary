using MyDictionary;
using System.Reflection;

class Program
{

    public static string? EXE_PATH => System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
    static List<English> listDictionary = new List<English>();

    static bool  InputWordInMyDictionary()
    {
        
        return false; 
    }



    static void Main(string[] args)
    {
        string NameFileJson = new Uri(Path.Join(EXE_PATH, "Mydictionary.json")).AbsolutePath;
        // int error = 0;

        // var dicError = new Dictionary<string, string>();
        //int my_english_words_count = mydic.Count;

        Console.Write($"Работать со словарём нажмите: 1\nВвести слово в словарь нажмите: 2\nДля выхода нажмите: 0\n");
        string? UserInputCode = Console.ReadLine();
        if (UserInputCode == null)
            return;
        else if (UserInputCode.Equals("0"))
            return;
        else if (UserInputCode.Equals("2"))
        {
            if (InputWordInMyDictionary())
            {
                MyJson.SaveJson(NameFileJson, listDictionary);
            }
            return;
        }
        else if (UserInputCode.Equals("1"))
            Console.WriteLine("Вы выбрали работу со словарём");
        else
            return;



        // return;
        listDictionary = MyJson.LoadJson(NameFileJson); 
        foreach (var EngDictionary in listDictionary)
        {
            int count_word_question = 0;
            while (true)
            {
                Console.Write($" {EngDictionary.Word} - ");
                string? UserInputTranslationChecked = Console.ReadLine();
                if (UserInputTranslationChecked == null)
                    continue;

                var translateEng = new English(EngDictionary.Word, UserInputTranslationChecked.Split(',').ToList());

                if (EngDictionary.Equals(translateEng))
                    break;
                else
                {

                    if (count_word_question >= 2)
                        break;
                    count_word_question++;
                    //error++;
                    continue;
                }
            }
        }
        //Console.WriteLine($"Всего слов {my_english_words_count}, вы ошиблись {error} раз");
        //foreach(var word in dicError)
        //{
        //    Console.WriteLine($" {word.Key} - {word.Value} ");
        //}
        Console.ReadLine();
    }







}