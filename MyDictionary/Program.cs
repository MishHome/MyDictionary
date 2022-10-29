using MyDictionary;
using Newtonsoft.Json;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        string NameFileJson = @"C:\Users\Teams\Desktop\MyCode\MyDictionary\MyDictionary\bin\Debug\net6.0\Mydictionary.json";
        int error = 0;
        var mydic = MyDictionary.MyDictionary.My_english_words;
        var dicError = new Dictionary<string, string>();
        int my_english_words_count = mydic.Count;

       // List<English> listDictionary= new List<English>();


        List<English> listDictionary = new Program().LoadJson(NameFileJson);


        //foreach (var dic in mydic)
        //{
        //    listDictionary.Add(new English(dic.Key, dic.Value.Split(',').ToList()));
        //}
        //SaveJson(NameFileJson, listDictionary);

        return;
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
    public static bool SaveJson(string NameFileJson, List<English> Listdata)
    {
        try
        {
            using (StreamWriter sw = File.CreateText(NameFileJson))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                serializer.Serialize(sw, Listdata);


            }


            return true;
        }
        catch (Exception ex)
        {
            return false;
            throw ex.InnerException ?? ex;
        }

    }

    public  List<English> LoadJson(string NameFileJson)
    {
        try
        {
         
            using (StreamReader file = File.OpenText(NameFileJson))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                List<English> Json = (List<English>)serializer.Deserialize(file, typeof(List<English>));
                return Json;
            }

           
        }

        catch (Exception ex)
        {
            throw ex.InnerException ?? ex;
        }


    }



}