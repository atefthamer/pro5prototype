using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    //[SerializeField]
    //List<string> wordsList = new List<string>();
    public GameObject barrel;

    [SerializeField]
    Dictionary<int, string[]> wordsMap = new Dictionary<int, string[]>();

    [SerializeField]
    string[,] array2Db = new string[3, 3] {
        { "one", "two", "three" },
        { "four", "five", "six" },
        { "seven", "eight", "nine" }
    };
    [SerializeField]
    List<List<string>> wordsList = new List<List<string>>();
    // Start is called before the first frame update

    [SerializeField]
    List<Vector3> tseries = new List<Vector3>();
    int firstIndexLength = 0;
    int secondIndexLength = 0;
    void Start()
    {
        firstIndexLength = array2Db.GetLength(0);
        secondIndexLength = array2Db.GetLength(1);
        for (int i = 0; i < firstIndexLength; i++)
        {
            for (int j = 0; j < secondIndexLength; j++)
            {
                Debug.Log("This is the array output " + array2Db[i, j]);
            }
        }

        int firstIndexSelector = (int)Random.Range(0, firstIndexLength);
        int secondIndexSelector = (int)Random.Range(0, secondIndexLength);

        Debug.Log("Selected Word is " + array2Db[firstIndexSelector, 0]);
        string correctWord = array2Db[firstIndexSelector, 0];

        SpawnTheSpawn(3);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnUnit()
    {
        float x = Random.Range(5f, 17f);
        float z = Random.Range(-44f, -55f);
        float y = Random.Range(5f, 9f);
        GameObject go = Instantiate(barrel, new Vector3(x, y, z), Quaternion.Euler(new Vector3(-90, 0, 0)));
    }

    void SpawnUnitV2(Vector3 dreamLocation)
    {
        float x = Random.Range(5f, 17f);
        float z = Random.Range(-44f, -55f);
        float y = Random.Range(5f, 9f);
        GameObject go = Instantiate(barrel, dreamLocation, Quaternion.Euler(new Vector3(-90, 0, 0)));
    }

    void SpawnTheSpawn(int times)
    {
        for (int i = 0; i < times; i++)
        {
            SpawnUnitV2(tseries[i]);
        }

    }
}
