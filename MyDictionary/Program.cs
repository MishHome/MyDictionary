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
                string? UserInputWordtranslation = Console.ReadLine();
                if (UserInputWordtranslation == null)
                    continue;
                else if (MyDictionary.MyDictionary.WordVerification(word.Value, UserInputWordtranslation))
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