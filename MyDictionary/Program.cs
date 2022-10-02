using System;

class Program
{
    static void Main(string[] args)
    {
        int error = 0;
        var my_english_words = new Dictionary<string, string>()
        {
            {"cat","кот"},
            {"dog","собака"},
            {"beaver","бобр"},
            {"mother","мама"},
            {"father","папа"},
            {"brother","брат"},
            {"sister","сестра"}

        };
        int my_english_words_count = my_english_words.Count;
        foreach(var word in my_english_words)
        {
            while(true)
            {
                Console.Write($" {word.Key} - ");
                string? russianWord = Console.ReadLine();
                if (russianWord == null)
                    continue;
                else if  (russianWord == word.Value)
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