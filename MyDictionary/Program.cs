class Program
{
    static void Main(string[] args)
    {
        int error = 0;
        var mydic = MyDictionary.MyDictionary.My_english_words;
        var dicError= new Dictionary<string, string>();
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
                    
                    //dicError.Add(word.Key, word.Value);
                    error++;
                    continue;
                }
            }
        }
        Console.WriteLine($"Всего слов {my_english_words_count}, вы ошиблись {error} раз");
        foreach(var word in dicError)
        {
            Console.WriteLine($" {word.Key} - {word.Value} ");
        }
        Console.ReadLine();
    }

}