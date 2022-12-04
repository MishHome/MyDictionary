using MyDictionary;
using System.Reflection;

class Program
{

    public static string? EXE_PATH => System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase);
    /// <summary>
    /// список слов из словаря
    /// </summary>
   
    static string NameFileJson => new Uri(Path.Join(EXE_PATH, "Mydictionary.json")).AbsolutePath;
    static List<English> listDictionary { get; set; }= new List<English>();



    /// <summary>
    /// ТОЧКА ВХОДА В ПРОГРАММУ
    /// </summary>
    /// <param name="args"></param>
    static void Main(string[] args)
    {
     
        int CountErrorTranslate = 0;
        
        var dicError = new Dictionary<string, string>();
        int MyDictionaryWordsCount;

        while (true)
        {
            Console.WriteLine();  
            MyDictionaryWordsCount = listDictionary.Count;
            listDictionary = MyJson.LoadJson(NameFileJson);

            Console.Write(
                $"Работать со словарём введите: 1 или ввод\n" +
                $"Ввести слово в словарь введите: 2\n" +
                $"Редактировать словарь введите: 3\n" +
                $"Удалить слово из словаря: 4\n" +
                $"Найти слово из словаря: 5\n" +
                $"Для выхода введите: 0\n");
            string? UserInputCode = Console.ReadLine();

            int modeProgramm = SelectingTheOperatingModeOfTheProgram.SelectModeOfTheProgram(UserInputCode);

            if (modeProgramm == 0)
                return;
            else if (modeProgramm == 2)
            {

                if (AddWordMyDictionary.InputWordInMyDictionary(listDictionary, out English? newWord))
                {
                    if (newWord != null)
                    {
                        listDictionary.Add(newWord);
                        if (MyJson.SaveJson(NameFileJson, listDictionary))
                        {
                            Console.WriteLine($"слово {newWord.Word} добавлено в словарь!");
                            Console.ReadLine();
                        }
                    }
                }
                continue;
            }
            else if (modeProgramm == 3)
            {
                //метод нереализован
                Console.WriteLine("метод пока нереализован");
                continue;
            }
            else if (modeProgramm == 4)
            {
                //метод нереализован
                Console.WriteLine("метод пока нереализован");
                continue;
            }
            else if (modeProgramm == 5)
            {
                //метод нереализован
                Console.WriteLine("метод пока нереализован");
                continue;
            }
            else if (modeProgramm == 1)
                break;
            else
                return; 

        }


        // return;
        var ls = new List<English>(listDictionary);
        ls.Shuffle();

        int CountWordsForStudy = 20;
        foreach (var EngDictionary in ls.Take(CountWordsForStudy))
        {
            int count_word_question = 0;
            while (true)
            {
                Console.Write($" {EngDictionary.Word} - ");
                
                
                string? UserInputTranslationChecked = Console.ReadLine();
                if (String.IsNullOrEmpty(UserInputTranslationChecked))
                {
                    Console.WriteLine("Вы ничего не ввели");
                    continue;
                }
                if (UserInputTranslationChecked.Equals("0"))
                    return;
                else if (CheckingUserInputData.CheckingTheRussianWordsTranslate(UserInputTranslationChecked) == false)
                {
                    Console.WriteLine("Введен недопустимый символ");  
                    continue;
                }

                else
                {
                    var translateEng = new English(EngDictionary.Word, UserInputTranslationChecked.Split(',').ToList());

                    if (EngDictionary.Equals(translateEng))
                        break;
                    else
                    {
                        CountErrorTranslate++;
                        if (dicError.ContainsKey(EngDictionary.Word) == false)
                            dicError.Add(EngDictionary.Word, "");

                        if (count_word_question >= 2)
                            break;
                        count_word_question++;
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