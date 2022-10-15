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
