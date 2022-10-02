namespace MyDictionary
{
    public static class MyDictionary
    {
        public static Dictionary<string, string> My_english_words { get; } = new Dictionary<string, string>()
        {
            {"cat","кот, кошка"},
            {"dog","собака"},
            {"beaver","бобр, бобер, бобёр"},
            {"mother","мама,мать"},
            {"father","папа,отец"},
            {"brother","брат"},
            {"sister","сестра"}

        };


        public static bool WordVerification(string WordValue, string WordCheck)
        {
            if (WordValue.Equals(WordCheck, StringComparison.InvariantCultureIgnoreCase))
                return true;
            else if (WordValue.Contains(WordCheck, StringComparison.InvariantCultureIgnoreCase))
                return true;
            else
                return false;
        }




    }
}
