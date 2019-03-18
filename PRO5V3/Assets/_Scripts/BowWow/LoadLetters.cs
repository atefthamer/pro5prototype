using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEditor;
using System.Linq;



public class LoadLetters : MonoBehaviour
{
    //HITandSave hit;

    bool checkForUpdate = false;

    //GameObject obi;
    Orbit orbit;
    //public GameObject placeholder;
    // Start is called before the first frame update
    [SerializeField]
    List<GameObject> letters = new List<GameObject>();

    Dictionary<string, GameObject> dict = new Dictionary<string, GameObject>();
    Dictionary<string, GameObject> TESTdict = new Dictionary<string, GameObject>();
    //Dictionary<char, GameObject> dict = new Dictionary<string, GameObject>();

    [SerializeField]
    GameObject objectCenterPoint = null;

    Dictionary<int, string> wordsDict = new Dictionary<int, string>();
    public int wordsCount = 0;


    public List<int> destroyed = new List<int>();


    string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    //Dictionary<string, bool> toShoot = new Dictionary<string, bool>();
    Dictionary<int ,Node> toShoot = new Dictionary<int, Node>();

    private int indexKey = 0;

    //public List<int> destroyed = new List<int>();
    public List<GameObject> initObjects = new List<GameObject>();
    //public List<int> initObjects = new List<int>();

    private int correctLetters = 0;
    private int incorrectLetters = 0;
    private int wordLength;

    public List<int> GetList()
    {
        return destroyed;
    }

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
        //hit = new HITandSave();
        AddLettersToDictionary();

        TestNeonLetters();

        if (FillDictionaryWithWords())
        {
            Debug.Log("Done with file reader");
        }
        SpawnLetters();
    }

    private void AddLettersToDictionary()
    {
        string targetdirectory = "./Assets/_Prefabs/Letters";
        string[] files = Directory.GetFiles(targetdirectory, "*.fbx").Select(file => Path.GetFileName(file)).ToArray();
        string[] filesPath = Directory.GetFiles(targetdirectory, "*.fbx").ToArray();

        for (int i = 0; i < files.Length; i++)
        {
            //Debug.Log("FILE NAME FOR NOW ++++---->>>> " + files[i].Replace(".fbx", ""));
            dict.Add(files[i].Replace(".fbx", ""), (GameObject)AssetDatabase.LoadAssetAtPath(filesPath[i].Substring(2).Replace("\\", "/"), typeof(GameObject)));
        }
    }

    private void TestNeonLetters()
    {
        string targetdirectory = "./Assets/_Prefabs/PrefabLetters";
        string[] files = Directory.GetFiles(targetdirectory, "*.prefab").Select(file => Path.GetFileName(file)).ToArray();
        string[] filesPath = Directory.GetFiles(targetdirectory, "*.prefab").ToArray();

        for (int i = 0; i < files.Length; i++)
        {
            //Debug.Log("FILE NAME FOR NOW ++++---->>>> " + files[i].Replace(".prefab", ""));
            TESTdict.Add(files[i].Replace(".prefab", ""), (GameObject)AssetDatabase.LoadAssetAtPath(filesPath[i].Substring(2).Replace("\\", "/"), typeof(GameObject)));
        }

        foreach(var elem in TESTdict)
        {
            Debug.Log("TESTDICTIONARY CONTENT " + elem.Key);
            instantiateLetters(elem.Value);
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
            var iniObject = instantiateLetters(GetWordLetterAtIndex(randomIndex, i));
            //Node n = new Node(iniObject, GetWordLetterAtIndex(randomIndex, i), wordsDict[randomIndex].ToUpper()[i].ToString(), true, false);
            Node n = new Node(iniObject, wordsDict[randomIndex].ToUpper()[i].ToString(), true, false);
            //instantiateLetters(GetWordLetterAtIndex(randomIndex, i));
            toShoot.Add(indexKey, n);
            indexKey++;
            //toShoot.Add(wordsDict[randomIndex].ToUpper()[i].ToString(), false);
        }

        //for (int j = 0; j < 10; j++)
        //{
        //    var randomLetterIndex = (int)UnityEngine.Random.Range(0.0f, 25.0f);

        //    var iniObject = instantiateLetters(GetRandomLetter(randomLetterIndex));
        //    //instantiateLetters(GetRandomLetter(randomLetterIndex));
        //    //Node n = new Node(iniObject, GetRandomLetter(randomLetterIndex), alphabet[randomLetterIndex], false, false);
        //    Node n = new Node(iniObject, alphabet[randomLetterIndex], false, false);
        //    toShoot.Add(indexKey, n);
        //    indexKey++;
        //}
      
        int index = 0;
        
        while (index != 10)
        {
            var randomLetterIndex = (int)UnityEngine.Random.Range(0.0f, 25.0f);
            string randomChar = alphabet[randomLetterIndex];
           
            if (!wordToShoot.Contains(randomChar))
            {
                Debug.Log("WORD " + wordToShoot + " DOES NOT CONTAIN" + randomChar);
                var iniObject = instantiateLetters(GetRandomLetter(randomLetterIndex));
                Node n = new Node(iniObject, alphabet[randomLetterIndex], false, false);
                toShoot.Add(indexKey, n);
                indexKey++;
                index++;
            }
        }
        checkForUpdate = true;
    }

    private GameObject GetWordLetterAtIndex(int wordIndex, int letterIndex)
    {
        return dict[wordsDict[wordIndex].ToUpper()[letterIndex].ToString()];
    }

    private GameObject GetRandomLetter(int index)
    {
        return dict[alphabet[index]];
    }

    private GameObject instantiateLetters(GameObject prefab)
    {
        float randomRadius = UnityEngine.Random.Range(50.0f, 1000.0f);

        Vector3 center = transform.position;

        //Debug.Log("THIS IS CENTER --> " + center);

        
        Vector3 pos = RandomCircle(center, randomRadius);

        //Debug.Log("POS --> " + pos);
        //Vector3 pos = randomPos(center, randomRadius);
        //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);

        //var obi = Instantiate(dict[alphabet[i]], pos, rot);
       
        var obi = Instantiate(prefab, pos, Quaternion.identity);
        
        
        obi.AddComponent<Orbit>();
        //obi.AddComponent<SpawnArea>();
        obi.AddComponent<Rigidbody>();

        

        obi.AddComponent<HITandSave>();
        obi.GetComponent<Rigidbody>().useGravity = false;
        //obi.AddComponent<RotatePill>();
        obi.AddComponent<SphereCollider>();
        obi.AddComponent<RotatePill>();
        obi.GetComponent<SphereCollider>().isTrigger = true;
       
        //obi.GetComponent<Orbit>().centerPoint.gameObject.name = "GameObject";
        obi.GetComponent<Orbit>().centerPoint = (GameObject)objectCenterPoint;
        obi.transform.localScale += new Vector3(50.0f, 50.0f, 50.0f);

        return obi;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(correctLetters == wordLength)
        {
            foreach(var obj in toShoot)
            {
                Destroy(obj.Value.initObject);
            }
            toShoot.Clear();
            indexKey = 0;
            correctLetters = 0;
            incorrectLetters = 0;
            SpawnLetters();
        }
        if (checkForUpdate)
        {
            CheckForDestroyedLetter();
        }

    }

    public void CheckForDestroyedLetter()
    {
        foreach (var item in toShoot.ToList())
        {
            bool isHit = item.Value.initObject.gameObject.GetComponent<HITandSave>().hit;
            int letterId = item.Value.initObject.gameObject.GetComponent<HITandSave>().objectId;
            GameObject arrow = item.Value.initObject.gameObject.GetComponent<HITandSave>().arrow;

            if (isHit)
            {
                if (item.Value.target)
                {
                    correctLetters++;
                }
                else
                {
                    incorrectLetters++;
                }
                Destroy(arrow);
                Destroy(item.Value.initObject);
                toShoot.Remove(item.Key);
                indexKey--;
            }
        }
    }

    public void AddDestroyedObject()
    {
        destroyed.Add(this.gameObject.GetInstanceID());
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

    private Vector3 RandomCircle(Vector3 center, float radius)
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
}
