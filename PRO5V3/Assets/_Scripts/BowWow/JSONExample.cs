using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONExample : MonoBehaviour
{
    public WordsList wordlist = new WordsList();
    // Start is called before the first frame update

    string text = "";


    void Start()
    {
        text = LoadJson("./Assets/_Scripts/BowWow/words-copy.json");
        wordlist = JsonUtility.FromJson<WordsList>(text);
        //foreach (var item in wordlist.Words)
        //{
        //    Debug.Log("word: " + item.word);
        //    Debug.Log("level: " + item.level);
        //    Debug.Log("img source: " + item.img_src);
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
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

    public List<Words> GetWordsFromJson(string path)
    {
        //text = LoadJson("./Assets/_Scripts/BowWow/words-copy.json");
        // Usage: path = "./Assets/_Scripts/BowWow/words-copy.json";
        text = LoadJson(path);
        wordlist = JsonUtility.FromJson<WordsList>(text);
        return wordlist.Words;
    }
}
