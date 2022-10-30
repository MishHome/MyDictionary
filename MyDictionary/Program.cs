using MyDictionary;
using System.Reflection;

class Program
{

    public static string? EXE_PATH => System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
    static List<English> listDictionary = new List<English>();

    static void Main(string[] args)
    {
        string NameFileJson = new Uri(Path.Join(EXE_PATH, "Mydictionary.json")).AbsolutePath;
        // int error = 0;

        // var dicError = new Dictionary<string, string>();
        //int my_english_words_count = mydic.Count;

        //foreach (var dic in mydic)
        //{
        //    listDictionary.Add(new English(dic.Key, dic.Value.Split(',').ToList()));
        //}
        //MyJson.SaveJson(NameFileJson, listDictionary);

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
                    //if(dicError.ContainsKey(word.Key) == false)
                    //     dicError.Add(word.Key, word.Value);
                    // if (count_word_question >= 2)
                    //     break;
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