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
