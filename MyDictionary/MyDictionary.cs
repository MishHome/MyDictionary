using System.Diagnostics;
using System.Reflection.Metadata;

namespace MyDictionary
{
    public static class MyDictionary
    {
        public static Dictionary<string, string> My_english_words { get; } = new Dictionary<string, string>()
        {
            {"cat","кот,кошка"},
            {"dog","собака"},
            {"beaver","бобр,бобер,бобёр"},
            {"mother","мама,мать"},
            {"father","папа,отец"},
            {"brother","брат"},
            {"sister","сестра"},
            {"husband","муж"},
            {"aunt","тетя"},
            {"uncle","дядя"},
            {"wife","жена"},
            {"baker","пекарь"},
            {"butcher","мясник"},
            {"grocer","бакалейщик"},
            {"greengrocer","зеленщик"},
            {"nurse","медсестра"},
            {"salesman","продавец"},
            {"secretsry","секретарь"},
            {"typist","машинистка"},
            {"occopation","занятость"},
            {"job","работа"},
            {"arrival","прибытие"},
            {"departure","отправление"},
            {"customs","таможня"},
            {"to book","бронировать"},
            {"booking office","билетная касса"},
            {"customs officer","таможеной чиновник"},
            {"fast train","скорый поезд"},
            {"slow train","медленный поезд"},
            {"traveller","путешественник"},
            {"camera","камера"},
            {"passport control","паспортный контроль"},
            {"fact","факт"},
            {"role","роль"},
            {"legend","легенда"},
            {"rocket","ракета"},
            {"traditional","традиции"},
            {"plantator","плантатор"},
            //{"Danya milokhin","Даня милохин"},
            {"caviar","икра"},
            {"custom","обычай"},
            {"honey","мёд"},
            {"hope","надежда"},
            {"pancake","блин"},
            {"soure cream","сметана"},
            {"science","наука"},
            {"scienetist","учёный"},
            {"scienetific","научный"},
            {"space","космос"},
            {"spaceship","космический корабль"},
            {"Virgina","Вирджиния"}
        };


        public static bool WordVerification(string WordValue, string WordCheck)
        {
            string[] ArrayWordsValue = WordValue.Split(',');  
            if (WordValue.Equals(WordCheck, StringComparison.InvariantCultureIgnoreCase))
                return true;
            else if (ArrayWordsValue.Any(word=> WordCheck.Equals(word, StringComparison.InvariantCultureIgnoreCase)))
                return true;
            else
                return false;
        }




    }
}
