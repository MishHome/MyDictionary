using MyDictionary;
using System.Collections.Specialized;
using System.Reflection;

class Program
{

    public static string? EXE_PATH => System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
    static List<English> listDictionary = new List<English>();

    static bool  InputWordInMyDictionary()
    {
        Console.WriteLine($"Введите английское слово");
        string? UserInputWord = Console.ReadLine();
        if (String.IsNullOrEmpty(UserInputWord))
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
            if (String.IsNullOrEmpty(UserInputTranslate))
                return false;
            else 
            {
                Console.WriteLine($"{UserInputWord}-{UserInputTranslate}");
                Console.WriteLine($"Ввести в словарь? да/нет");
                string? UserInputYN = Console.ReadLine();
                if (String.IsNullOrEmpty(UserInputYN) || UserInputYN.Equals("нет",StringComparison.InvariantCultureIgnoreCase))
                    return false;
                else if (UserInputYN.Equals("да",StringComparison.InvariantCultureIgnoreCase))
                {
                    //здесь формируем экземпляр и пытаемся ввести слово в словарь и сохранить его 
                    English NewWord = new English(UserInputWord, UserInputTranslate.Split(",").ToList());
                    listDictionary.Add(NewWord);
                    return true;
                }
                else
                    return false; 

            }


        }


       // var translateEng = new English(EngDictionary.Word, UserInputTranslationChecked.Split(',').ToList());

        return false; 
    }

    

    static void Main(string[] args)
    {
        string NameFileJson = new Uri(Path.Join(EXE_PATH, "Mydictionary.json")).AbsolutePath;
        int CountErrorTranslate = 0;
        listDictionary = MyJson.LoadJson(NameFileJson);
        var dicError = new Dictionary<string, string>();
        int MyDictionaryWordsCount = listDictionary.Count;

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
        var ls = new List<English>(listDictionary);
        ls.Shuffle();

        int CountWordsForStudy = 10;
        foreach (var EngDictionary in ls.Take(CountWordsForStudy))
        {
            int count_word_question = 0;
            while (true)
            {
                Console.Write($" {EngDictionary.Word} - ");
                string? UserInputTranslationChecked = Console.ReadLine();
                if (String.IsNullOrEmpty(UserInputTranslationChecked))
                    continue;
                else if (UserInputTranslationChecked.Equals("0"))
                    return;
                else
                {
                    var translateEng = new English(EngDictionary.Word, UserInputTranslationChecked.Split(',').ToList());

                    if (EngDictionary.Equals(translateEng))
                        break;                                   //    / 
                    else                                        //    /
                     {                                         //    / 
                        CountErrorTranslate++;               //     /|--------------|
                        dicError.Add(EngDictionary.Word, "");//     \|--------------| tyt
                        if (count_word_question >= 2)       //       \       
                            break;                          //        \   
                        count_word_question++;               //        \  
                        continue; 
                    }
                }
            }
        }
        Console.WriteLine($"Всего слов в словаре:{MyDictionaryWordsCount}\nВы ответили на {CountWordsForStudy}\nВы ошиблись {CountErrorTranslate} раз");
        foreach (var word in dicError)
        {
            Console.WriteLine($" {word.Key} - {word.Value} ");
        }
        Console.ReadLine();
    }







}
//https://stackoverflow.com/questions/273313/randomize-a-listt
public static class ThreadSafeRandom
{
    [ThreadStatic] private static Random Local;

    public static Random ThisThreadsRandom
    {
        get { return Local ?? (Local = new Random(unchecked(Environment.TickCount * 31 + Thread.CurrentThread.ManagedThreadId))); }
    }
}
/// <summary>
/// Рандомизировать список
/// </summary>
public static class MyExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = ThreadSafeRandom.ThisThreadsRandom.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}