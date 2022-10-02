class Program
{
    static void Main(string[] args)
    {
        int error = 0;
        var mydic = MyDictionary.MyDictionary.My_english_words;
        int my_english_words_count = mydic.Count;
        foreach (var word in mydic)
        {
            while (true)
            {
                Console.Write($" {word.Key} - ");
                string? russianWord = Console.ReadLine();
                if (russianWord == null)
                    continue;
                else if (russianWord == word.Value)
                    break;
                else
                {
                    error++;
                    continue;
                }
            }
        }
        Console.WriteLine($"Всего слов {my_english_words_count}, вы ошиблись {error} раз");
        Console.ReadLine();
    }

}