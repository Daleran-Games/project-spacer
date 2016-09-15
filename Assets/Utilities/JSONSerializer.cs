using UnityEngine;

namespace ProjectSpacer
{
    public static class JSONSerializer
    {
        public static void SaveToFile (string fileName, IJSONObject gameObject)
        {

        }

        public static T GetFromFile<T> (string fileName) where T : IJSONObject, new()
        {


            string sampleJSON = "This is a sample";
            
            return (new T()).FromJSON<T>(sampleJSON);
        }
    }
}
