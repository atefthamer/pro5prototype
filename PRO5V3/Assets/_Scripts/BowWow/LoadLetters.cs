using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine;
using UnityEditor;
using System.Linq;



public class LoadLetters : MonoBehaviour
{ 

    Orbit orbit;
    //public GameObject placeholder;
    // Start is called before the first frame update
    [SerializeField]
    List<GameObject> letters = new List<GameObject>();

    Dictionary<string, GameObject> dict = new Dictionary<string, GameObject>();
    //Dictionary<char, GameObject> dict = new Dictionary<string, GameObject>();


    [SerializeField]
    GameObject objectCenterPoint = null;

    Dictionary<int, string> wordsDict = new Dictionary<int, string>();
    public int wordsCount = 0;

    string[] alphabet = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };

    Dictionary<string, bool> toShoot = new Dictionary<string, bool>();
 

    void Start()
    {
        string targetdirectory = "./Assets/_Prefabs/Letters";


        string[] files = Directory.GetFiles(targetdirectory, "*.fbx").Select(file => Path.GetFileName(file)).ToArray();
   
        string[] filesPath = Directory.GetFiles(targetdirectory, "*.fbx").ToArray();

        for(int i = 0; i < files.Length; i++)
        {
            Debug.Log("FILE NAME FOR NOW ++++---->>>> " + files[i].Replace(".fbx", ""));
            dict.Add(files[i].Replace(".fbx", ""), (GameObject)AssetDatabase.LoadAssetAtPath(filesPath[i].Substring(2).Replace("\\", "/"), typeof(GameObject)));
        } 

        if (FillDictionaryWithWords())
        {
            Debug.Log("Done with file reader");
        }

        var randomIndex = (int)UnityEngine.Random.Range(0.0f, wordsCount);

        Debug.Log("This is the word with index 2 " + wordsDict[randomIndex].ToUpper());
        Debug.Log("This is the word with index 2 with length " + wordsDict[randomIndex].Length);

        for(int i = 0; i < wordsDict[randomIndex].Length; i++)
        {
            instantiateLetters(GetWordLetterAtIndex(randomIndex, i));
            toShoot.Add(wordsDict[randomIndex].ToUpper()[i].ToString(), false);
        }

        for(int j = 0; j < 10; j++)
        {
            var randomLetterIndex = (int)UnityEngine.Random.Range(0.0f, 25.0f);
            instantiateLetters(GetRandomLetter(randomLetterIndex));
        }

    }

    private GameObject GetWordLetterAtIndex(int wordIndex, int letterIndex)
    {
        Debug.Log("INSTA LETTER >> " + wordsDict[wordIndex].ToUpper()[letterIndex].ToString());
        return dict[wordsDict[wordIndex].ToUpper()[letterIndex].ToString()];
    }

    private GameObject GetRandomLetter(int index)
    {
        return dict[alphabet[index]];
    }

    private void instantiateLetters(GameObject prefab)
    {
        float randomRadius = UnityEngine.Random.Range(50.0f, 1000.0f);

        Vector3 center = transform.position;

        Debug.Log("THIS IS CENTER --> " + center);

        
        Vector3 pos = RandomCircle(center, randomRadius);

        Debug.Log("POS --> " + pos);
        //Vector3 pos = randomPos(center, randomRadius);
        //Quaternion rot = Quaternion.FromToRotation(Vector3.forward, center - pos);

        //var obi = Instantiate(dict[alphabet[i]], pos, rot);
       
        var obi = Instantiate(prefab, pos, Quaternion.identity);
       
        
        obi.AddComponent<Orbit>();
        //obi.AddComponent<SpawnArea>();
        obi.AddComponent<Rigidbody>();
        obi.GetComponent<Rigidbody>().useGravity = false;
        //obi.AddComponent<RotatePill>();
        obi.AddComponent<SphereCollider>();
        obi.GetComponent<SphereCollider>().isTrigger = true;
        //obi.GetComponent<Orbit>().centerPoint.gameObject.name = "GameObject";
        obi.GetComponent<Orbit>().centerPoint = (GameObject)objectCenterPoint;
        obi.transform.localScale += new Vector3(50.0f, 50.0f, 50.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string GetGameObjectPath(GameObject obj)
    {
        string path = "/" + obj.name;
        while (obj.transform.parent != null)
        {
            obj = obj.transform.parent.gameObject;
            path = "/" + obj.name + path;
        }
        return path;
    }

    Vector3 RandomCircle(Vector3 center, float radius)
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

    Vector3 randomPos(Vector3 center, float radius)
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
