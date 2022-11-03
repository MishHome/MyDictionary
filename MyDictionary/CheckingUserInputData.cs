﻿namespace MyDictionary
{
    public static class CheckingUserInputData
    {
        public static bool CheckingTheEnglishWord(string? CheckString, out string word)
        {
            word = "";
            if (CheckString == null)
                return false;

            if (CheckString.Equals(""))
                return false;


            char[] engChars = {'a','b','c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            foreach (var ch in CheckString.ToLower())
            {
                if (engChars.Contains(ch)==false)
                    return false;
            }
             return true;
        }
    }
}