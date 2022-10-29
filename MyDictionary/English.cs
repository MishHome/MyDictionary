using System.Linq;

namespace MyDictionary
{
    public class English
    {
       

        public string Word { get; private set; }
        public List<string> ListTranslation { get; private set; }
        public string? Comment { get; private set; }

        public English(string word, List<string> translation, string? comment=null)
        {
            Word = word;
            ListTranslation = translation;
            Comment = comment;
        }

        public override bool Equals(object? obj)
        {
            if (obj is English eng)
            {
                if (eng.Word.Equals(this.Word))
                {
                    foreach (var trans in eng.ListTranslation)
                    {
                        if (this.ListTranslation.Where(x => 
                                    x.Equals(
                                        trans,StringComparison.InvariantCultureIgnoreCase))
                                            .FirstOrDefault() !=null)
                            return true;
                    }
                }
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Word, ListTranslation);
        }

    }
}
