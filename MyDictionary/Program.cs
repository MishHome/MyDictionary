using MyDictionary;

class Program
{
    static void Main(string[] args)
    {
         int error = 0;
         var mydic = MyDictionary.MyDictionary.My_english_words;
        // var dicError= new Dictionary<string, string>();
        // int my_english_words_count = mydic.Count;

        List<English> listDictionary= new List<English>();
        foreach (var dic in mydic)
        {
            listDictionary.Add(new English(dic.Key, dic.Value.Split(',').ToList()));
        }

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
                    error++;
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