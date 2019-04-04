using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class ReadJson : MonoBehaviour
{
    // Start is called before the first frame update


    public string path;
    public string jsonString;

    void Start()
    {
        string text = LoadJson("./Assets/_Scripts/BowWow/words.json");
        Items it = CreateFromJSON(text);
        
    }

    public class Items
    {
        public string word;
        public int level;
        public string img_src;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Items CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<Items>(jsonString);
    }

    public string LoadJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            return dataAsJson;
        }
        return "";
    }
}
