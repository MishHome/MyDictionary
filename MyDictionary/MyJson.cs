using Newtonsoft.Json;

namespace MyDictionary
{
    public static class MyJson
    {
        public static bool SaveJson(string NameFileJson, List<English> Listdata)
        {
            try
            {
                var jsonString = JsonConvert.SerializeObject(Listdata, Formatting.Indented);
                File.WriteAllText(NameFileJson, jsonString);
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex.InnerException ?? ex;
            }

        }

        public static List<English> LoadJson(string NameFileJson)
        {
            try
            {

                string jsonString = File.ReadAllText(NameFileJson);
                List<English> ListJson = JsonConvert.DeserializeObject<List<English>>(jsonString);
                return ListJson;


            }

            catch (Exception ex)
            {
                throw ex.InnerException ?? ex;
            }


        }
    }
}
