namespace MrGunnChartData.Utilities
{
    public class JsonUtility : IJsonUtility
    {
        public string ReturnJson(string jsonFileName)
        {
            var result = "";


            string currentdirectory = Directory.GetParent(System.Environment.CurrentDirectory).FullName;

            var filepath = currentdirectory + "/Resources/" + jsonFileName + ".json";


            using (StreamReader r = new StreamReader(filepath))
            {
                result = r.ReadToEnd();
            }

            return result;
        }
    }
}