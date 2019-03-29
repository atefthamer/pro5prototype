using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Linq;



public class LoadLetters : MonoBehaviour
{
    public SFXTriggers sfx;

    Dictionary<string, GameObject> dict = new Dictionary<string, GameObject>();
    Dictionary<int, Node> toShoot = new Dictionary<int, Node>();
    Dictionary<int, string> wordsDict = new Dictionary<int, string>();


    Dictionary<int, ArrayListWords> jsonWordsDict = new Dictionary<int, ArrayListWords>();



    [SerializeField]
    GameObject objectCenterPoint = null;

  
    public int wordsCount = 0;

    string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    private bool checkForUpdate = false;
    private int indexKey = 0;

    private int correctLetters = 0;
    private int incorrectLetters = 0;
    private int wordLength;

    private string pathLetters;
    private string fileExtension;
    public int score = 0;

    public Vector3 pos;


    // Inner class to save various information about the dynamic gameobjects
    class Node 
    {
        public GameObject initObject; 
        public string letter;
        public bool target;
        public bool isShot;
        public Node(GameObject initObject, string letter, bool target, bool isShot)
        {
            this.initObject = initObject;
            this.letter = letter;
            this.target = target;
            this.isShot = isShot;
        }
    }

    void Start()
    {
        // Path to the Neon letters
        pathLetters = "./Assets/_Prefabs/PrefabLetters";
        // File extension we want
        fileExtension = "*.prefab";

        //AddLettersToDictionary();

        // Add letters to dictionary
        NeonLetters(pathLetters, fileExtension, ".prefab");

        // Fill the dictionary with the words from the txt file
        //if (FillDictionaryWithWords())
        //{
        //    Debug.Log("Done with file reader");
        //}

        // Spwan letters
        //SpawnLetters();

        
        FillJSONDic();
        SpawnLettersV2();
    }

    private void AddLettersToDictionary()
    {
        string targetdirectory = "./Assets/_Prefabs/Letters";
        string[] files = Directory.GetFiles(targetdirectory, "*.fbx").Select(file => Path.GetFileName(file)).ToArray();
        string[] filesPath = Directory.GetFiles(targetdirectory, "*.fbx").ToArray();

        for (int i = 0; i < files.Length; i++)
        {
            dict.Add(files[i].Replace(".fbx", ""), 
                (GameObject)AssetDatabase.LoadAssetAtPath(filesPath[i].Substring(2).Replace("\\", "/"), 
                typeof(GameObject))
                );
        }
    }

    private void NeonLetters(string path, string fileToGet, string extension)
    {
        string[] files = Directory.GetFiles(path, fileToGet).Select(file => Path.GetFileName(file)).ToArray();
        string[] filesPath = Directory.GetFiles(path, fileToGet).ToArray();

        for (int i = 0; i < files.Length; i++)
        {
                 dict.Add(files[i].Replace(extension, ""), 
                     (GameObject)AssetDatabase.LoadAssetAtPath(filesPath[i].Substring(2).Replace("\\", "/"), 
                     typeof(GameObject))
                     );
        }
    }

    private void SpawnLetters()
    {
        var randomIndex = (int)UnityEngine.Random.Range(0.0f, wordsCount);
        string wordToShoot = wordsDict[randomIndex].ToUpper();

        Debug.Log("This is the word with index 2 " + wordsDict[randomIndex].ToUpper());
        Debug.Log("This is the word with index 2 with length " + wordsDict[randomIndex].Length);
        wordLength = wordsDict[randomIndex].Length;

        for (int i = 0; i < wordsDict[randomIndex].Length; i++)
        {
            string letter = wordsDict[randomIndex].ToUpper()[i].ToString();
            var iniObject = instantiateLetters(GetWordLetterAtIndex(randomIndex, i));
            Node n = new Node(iniObject, letter, true, false);
            toShoot.Add(indexKey, n);
            indexKey++;
        }
       
        int index = 0;
        
        while (index != 5)
        {
            var randomLetterIndex = (int)UnityEngine.Random.Range(0.0f, 25.0f);
            string randomChar = alphabet[randomLetterIndex];
           
            if (!wordToShoot.Contains(randomChar))
            {
                var iniObject = instantiateLetters(GetRandomLetter(randomLetterIndex));
                Node n = new Node(iniObject, alphabet[randomLetterIndex], false, false);
                toShoot.Add(indexKey, n);
                indexKey++;
                index++;
            }
        }
        checkForUpdate = true;
    }

    private void SpawnLettersV2()
    {
        var randomIndex = (int)UnityEngine.Random.Range(0.0f, wordsCount);
        string wordToShoot = jsonWordsDict[randomIndex].word.ToUpper();

        Debug.Log("This is the word with index 2 " + jsonWordsDict[randomIndex].word.ToUpper());
        Debug.Log("This is the word with index 2 with length " + jsonWordsDict[randomIndex].word.Length);
        wordLength = jsonWordsDict[randomIndex].word.Length;

        for (int i = 0; i < wordLength; i++)
        {
            string letter = jsonWordsDict[randomIndex].word.ToUpper()[i].ToString();
            var iniObject = instantiateLetters(GetWordLetterAtIndex(randomIndex, i));
            Node n = new Node(iniObject, letter, true, false);
            toShoot.Add(indexKey, n);
            indexKey++;
        }
       
        int index = 0;
        
        while (index != 5)
        {
            var randomLetterIndex = (int)UnityEngine.Random.Range(0.0f, 25.0f);
            string randomChar = alphabet[randomLetterIndex];
           
            if (!wordToShoot.Contains(randomChar))
            {
                var iniObject = instantiateLetters(GetRandomLetter(randomLetterIndex));
                Node n = new Node(iniObject, alphabet[randomLetterIndex], false, false);
                toShoot.Add(indexKey, n);
                indexKey++;
                index++;
            }
        }
        checkForUpdate = true;
    }

    // Return Letter object from the word at index x
    private GameObject GetWordLetterAtIndex(int wordIndex, int letterIndex)
    {
        return dict[jsonWordsDict[wordIndex].word.ToUpper()[letterIndex].ToString()];
    }

    //private GameObject GetWordLetterAtIndex(int wordIndex, int letterIndex)
    //{
    //    return dict[wordsDict[wordIndex].ToUpper()[letterIndex].ToString()];
    //}

    // Return letter from alphabet array at index x
    private GameObject GetRandomLetter(int index)
    {
        return dict[alphabet[index]];
    }

    // instantiate letter object and return the object
    private GameObject instantiateLetters(GameObject prefab)
    {
        float randomRadius = UnityEngine.Random.Range(50.0f, 1000.0f);
        Vector3 center = transform.position;
        pos = RandomCircle(center, randomRadius);
        var obi = Instantiate(prefab, pos, Quaternion.identity);

        obi.AddComponent<HITandSave>();

        obi.AddComponent<Rigidbody>();
        
        obi.GetComponent<Rigidbody>().useGravity = false;
        obi.GetComponent<Rigidbody>().isKinematic = true;
        
        // Experimental 
        //obi.AddComponent<SphereCollider>();
        //obi.GetComponent<SphereCollider>().isTrigger = true;

        //obi.AddComponent<MeshCollider>();
        //obi.GetComponent<MeshCollider>().convex = true;
        //obi.GetComponent<MeshCollider>().isTrigger = true;

        //obi.AddComponent<BoxCollider>();
        //obi.GetComponent<BoxCollider>().isTrigger = true;

        obi.AddComponent<RotatePill>();

        obi.AddComponent<Orbit>();
        obi.GetComponent<Orbit>().centerPoint = (GameObject)objectCenterPoint;

        // Make letter bigger
        obi.transform.localScale += new Vector3(50.0f, 50.0f, 50.0f);

        return obi;
    }

    // Update is called once per frame
    void Update()
    {
        // If correct letters are all shot, reset
        if(correctLetters == wordLength)
        {
            // Delete remaining objects to start new spawn round
            foreach(var obj in toShoot)
            {
                Destroy(obj.Value.initObject);
            }
            // Clear the dictionary
            toShoot.Clear();
            // Start at index 0 again
            indexKey = 0;
            correctLetters = 0;
            incorrectLetters = 0;
            score++;
            // Spawn letters
            //SpawnLetters();
            SpawnLettersV2();
        }
        if (checkForUpdate)
        {
            // Poll for the status of the letter objects
            // Put more object properties in HITandSave.cs file 
            CheckForDestroyedLetter();
        }
    }

    public void CheckForDestroyedLetter()
    {
        // Note: ToList() is used to copy the existing dictionary
        // Because otherwise the list can't be modified in the loop
        // TODO: if the list is long, it can be costly, find better solution.
        foreach (var item in toShoot.ToList())
        {
            bool isHit = item.Value.initObject.gameObject.GetComponent<HITandSave>().hit;
            int letterId = item.Value.initObject.gameObject.GetComponent<HITandSave>().objectId;
            GameObject arrow = item.Value.initObject.gameObject.GetComponent<HITandSave>().arrow;

            // Is the letter hit?
            if (isHit)
            {
                // Play sfx sound
                sfx.PlaySound();
                // Destroy the arrow fired from the bow
                Destroy(arrow); 
                // Destroy the letter object
                Destroy(item.Value.initObject);
                // Keep track of the score
                if (item.Value.target)
                {
                    correctLetters++;
                }
                else
                {
                    incorrectLetters++;
                }
                // Remove from the dictinary
                toShoot.Remove(item.Key);
                // Decrement the index
                indexKey--;
            }
        }
    }

    private static string GetGameObjectPath(GameObject obj)
    {
        string path = "/" + obj.name;
        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            path = "/" + obj.name + path;
        }
        return path;
    }

    public Vector3 RandomCircle(Vector3 center, float radius)
    {
        //float ang = UnityEngine.Random.Range(-90.0f, 90.0f) * 360;
        float ang = UnityEngine.Random.value * 360;
        //prefab.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        //Debug.Log("The Angle: " + ang);
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin(ang * Mathf.Deg2Rad);
        pos.y = center.y + radius * Mathf.Cos(ang * Mathf.Deg2Rad);
        //pos.z = center.z + UnityEngine.Random.Range(-5.0f, 60.0f);
        pos.z = center.z * UnityEngine.Random.Range(5.0f, 50.0f);
        return pos;
    }

    private Vector3 randomPos(Vector3 center, float radius)
    {        
        // get the angle for this step (in radians, not degrees)
        var angle = 0.9f * Mathf.PI * 2;
        // the X &amp; Y position for this angle are calculated using Sin &amp; Cos
        var x = Mathf.Sin(angle) * radius;
        var y = Mathf.Cos(angle) * radius;
        var pos = new Vector3(x, y, 0) + center.normalized;

        return pos;
    }

    public bool FillDictionaryWithWords()
    {
        string line;
        
        // Read the file and display it line by line.  
        System.IO.StreamReader file = new System.IO.StreamReader("Assets/_Scripts/BowWow/words.txt");

        while ((line = file.ReadLine()) != null)
        {
            Debug.Log("Words read: " + line);

            wordsDict.Add(wordsCount, line);
            wordsCount++;
        }
        
        if(wordsCount == 0)
        {
            file.Close();
            return false;
        }

        file.Close();
        return true;
    }

    public WordsList wordlist = new WordsList();
    string text = "";

    public string LoadJson(string filePath)
    {
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            return dataAsJson;
        }
        return "";
    }

    //public List<Words> GetWordsFromJson(string path)
    //{
    //    //text = LoadJson("./Assets/_Scripts/BowWow/words-copy.json");
    //    // Usage: path = "./Assets/_Scripts/BowWow/words-copy.json";
    //    text = LoadJson(path);
    //    wordlist = JsonUtility.FromJson<WordsList>(text);
    //    return wordlist.Words;
    //    //return wordlist.Words;
    //}

    public List<Words> GetWordsFromJson(string path)
    {
        //text = LoadJson("./Assets/_Scripts/BowWow/words-copy.json");
        // Usage: path = "./Assets/_Scripts/BowWow/words-copy.json";
        text = LoadJson(path);
        return JsonUtility.FromJson<WordsList>(text).Words;
    }

    class ArrayListWords
    {
        public string word;
        public int level;
        public string imageSource;

        public ArrayListWords(string word, int level, string imageSource)
        {
            this.word = word;
            this.level = level;
            this.imageSource = imageSource;
        }
    }

    public void FillJSONDic()
    {
        int index = 0;
        List<Words> wordlist = GetWordsFromJson("./Assets/_Scripts/BowWow/words-copy.json");

        for(int i = 0; i < wordlist.Count; i++)
        {
            string word = wordlist[i].word;
            int level = wordlist[i].level;
            string imageSource = wordlist[i].img_src;

            jsonWordsDict.Add(index, new ArrayListWords(word, level, imageSource));
            index++;
            wordsCount++;
            Debug.Log("WORDLIST YEAH >> " + jsonWordsDict[i].word);
            Debug.Log("WORDLIST YEAH >> " + jsonWordsDict[i].level);
            Debug.Log("WORDLIST YEAH >> " + jsonWordsDict[i].imageSource);
        }
    }
}
