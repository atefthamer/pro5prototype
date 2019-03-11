using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

    [SerializeField]
    GameObject objectCenterPoint = null;

    void Start()
    {
        string targetdirectory = "./Assets/_Models/Letters";

        //foreach (GameObject obj in letters)
        //{
        //    dict.Add(obj.name, obj);
        //}

        //GameObject ob = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Models/Letters/A.fbx", typeof(GameObject));
        //Debug.Log("OB >> " + ob.name);
        //Instantiate(ob);
        //ob.transform.localScale += new Vector3(500.0f, 500.0f, 500.0f);

        /*
        Object prefabLetter = Resources.Load("Resources/Prefabs/Letters/A.fbx"); // Assets/Resources/Prefabs/prefab1.FBX
        GameObject t = (GameObject)Instantiate(prefabLetter, new Vector3(0, 0, 0), Quaternion.identity);
        */

        //GameObject t = Instantiate(dict["A"]);
        //t.transform.localScale += new Vector3(50.0f, 50.0f, 50.0f);

        string[] files = Directory.GetFiles(targetdirectory, "*.fbx").Select(file => Path.GetFileName(file)).ToArray();
        //string[] filesPath = Directory.GetFiles(targetdirectory, "*.fbx").Select(file => Path.GetFullPath(file)).ToArray();
        string[] filesPath = Directory.GetFiles(targetdirectory, "*.fbx").ToArray();

        for(int i = 0; i < files.Length; i++)
        {
            Debug.Log("FILE NAME FOR NOW ++++---->>>> " + files[i].Replace(".fbx", ""));
            //Debug.Log("SUBSTRING DEMO --> " + filesPath[i].Substring(1));
            dict.Add(files[i].Replace(".fbx", ""), (GameObject)AssetDatabase.LoadAssetAtPath(filesPath[i].Substring(2).Replace("\\", "/"), typeof(GameObject)));
        }

        string[] alphabet = { "A", "B", "C", "D", "E", "F", "G" };

        //var gmObjCenterPoint = GameObject.Find("GameObject");

        for (int i = 0; i < 7; i++)
        {
            var obi = Instantiate(dict[alphabet[i]]);
            obi.AddComponent<Orbit>();
            obi.AddComponent<Rigidbody>();
            obi.GetComponent<Rigidbody>().useGravity = false;
            obi.AddComponent<RotatePill>();
            obi.AddComponent<SphereCollider>();
            obi.GetComponent<SphereCollider>().isTrigger = true;
            //obi.GetComponent<Orbit>().centerPoint.gameObject.name = "GameObject";
            obi.GetComponent<Orbit>().centerPoint = (GameObject)objectCenterPoint;
            obi.transform.localScale += new Vector3(50.0f, 50.0f, 50.0f);

            //dict[alphabet[i]].AddComponent<Orbit>();
            //dict[alphabet[i]].AddComponent<Rigidbody>();
            //dict[alphabet[i]].GetComponent<Rigidbody>().useGravity = false;


            //AddComponent<Orbit>();
            //Debug.Log("GAME OBJECT --> " + dict[alphabet[i]]);
        }

        //for (int i = 0; i < filesPath.Length; i++)
        //{
        //    Debug.Log("FILE PATH FOR NOW ++++---->>>> " + filesPath[i]);
        //}

        //DirectoryInfo dir = new DirectoryInfo(targetdirectory);
        //FileInfo[] info = dir.GetFiles("*.fbx");
        //List<string> FileNames = new List<string>();

        //foreach (FileInfo f in info)
        //{
        //    Debug.Log("PATHS --> " + f);
        //    FileNames.Add(f.Name.Replace(".fbx", ""));
        //}

        //FileNames.ForEach(x => Debug.Log(x));
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
}
