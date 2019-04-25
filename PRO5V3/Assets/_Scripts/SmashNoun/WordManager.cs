using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System;

namespace SmashNoun
{
    public class WordManager : MonoBehaviour
    {
        //[SerializeField]
        //List<string> wordsList = new List<string>();
        // How many rounds per game?
        public const int MAX_ROUNDS = 3;
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

        string[] objectKey = { "first", "second", "third" };

        class objectInformation
        {
            GameObject prefab;
            int index;

            public objectInformation(GameObject prefab, int index)
            {
                this.prefab = prefab;
                this.index = index;
            }

        }
        private Dictionary<string, objectInformation> initOjectData = new Dictionary<string, objectInformation>();
        void Start()
        {

            EventSystem.Current.RegisterListener<UnitDeathEventInfo>(UnitDied);
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

            //SpawnTheSpawn(3);

            for (int i = 0; i < 3; i++)
            {
                GameObject spwn = SpawnUnitV2(tseries[i]);

                initOjectData.Add(objectKey[i], new objectInformation(spwn, i));
            }

            insertAlotOfQuestionsTest();

            foreach (var item in questionAnswer)
            {
                Debug.Log("Questions: " + item.questionData);
                item.answer.ForEach(
                    (x) =>
                    {
                        if (x.IsCorrect == true)
                        {
                            Debug.Log("YES YES YES YES YES YES YES YES");
                        }
                    }
                );
            }

            List<int> indexes = new List<int>();
            int max = questionAnswer.Count;

            // Unique index set
            HashSet<int> indexSet = new HashSet<int>();

            while (indexSet.Count != max)
            {
                indexSet.Add((int)Random.Range(0.0f, (float)max));

            }

            foreach (var item in indexSet)
            {
                Debug.Log("HashSet -> " + item);
            }



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

        GameObject SpawnUnitV2(Vector3 dreamLocation)
        {
            float x = Random.Range(5f, 17f);
            float z = Random.Range(-44f, -55f);
            float y = Random.Range(5f, 9f);
            GameObject go = Instantiate(barrel, dreamLocation, Quaternion.Euler(new Vector3(-90, 0, 0)));
            return go;
        }

        void SpawnTheSpawn(int times)
        {
            for (int i = 0; i < times; i++)
            {
                SpawnUnitV2(tseries[i]);
            }

        }

        void UnitDied(UnitDeathEventInfo unitDeathInfo)
        {
            //unitDeathInfo.
        }

        [System.Serializable]
        public class Answer
        {
            public string AnswerData;
            public bool IsCorrect;

            public Answer(string AnswerData, bool IsCorrect)
            {
                this.AnswerData = AnswerData;
                this.IsCorrect = IsCorrect;
            }
        }


        [System.Serializable]
        public class Question
        {
            public string questionData;
            public List<Answer> answer;

            public Question(string questionData)
            {
                this.questionData = questionData;
                answer = new List<Answer>();
            }
        }


        //public Dictionary<int, Question> questionAnswer = new Dictionary<int, Question>();
        public List<Question> questionAnswer = new List<Question>();

        private void insertQuestions()
        {
            Question qs = new Question("Hello");
            qs.answer.Add(new Answer("Hey", false));
            qs.answer.Add(new Answer("Hello", true));
            qs.answer.Add(new Answer("Hola", false));

            // questionAnswer.Add(0, qs);
            questionAnswer.Add(qs);
        }

        private Question getQuestion(string question)
        {
            Question qs = new Question(question);
            return qs;
        }

        private void insertAlotOfQuestionsTest()
        {
            Question qq = getQuestion("Hello");

            qq.answer.Add(new Answer("Hola", false));
            qq.answer.Add(new Answer("Hello", true));
            qq.answer.Add(new Answer("Hoi", false));

            // questionAnswer.Add(0, qq);
            questionAnswer.Add(qq);

            qq = null;

            qq = getQuestion("Pink");
            qq.answer.Add(new Answer("Black", false));
            qq.answer.Add(new Answer("White", false));
            qq.answer.Add(new Answer("Pink", true));

            // questionAnswer.Add(1, qq);
            questionAnswer.Add(qq);

            qq = null;

            qq = getQuestion("Square");
            qq.answer.Add(new Answer("Square", true));
            qq.answer.Add(new Answer("Triangle", false));
            qq.answer.Add(new Answer("Trapazoid", false));

            // questionAnswer.Add(1, qq);
            questionAnswer.Add(qq);

            qq = null;

            qq = getQuestion("Mercedes-Benz");
            qq.answer.Add(new Answer("BMW", false));
            qq.answer.Add(new Answer("Volkswagen", false));
            qq.answer.Add(new Answer("Mercedes-Benz", true));

            // questionAnswer.Add(1, qq);
            questionAnswer.Add(qq);
        }

        // static Random _random = new Random();

        // /// <summary>
        // /// Shuffle the array.
        // /// </summary>
        // /// <typeparam name="T">Array element type.</typeparam>
        // /// <param name="array">Array to shuffle.</param>
        // static void Shuffle<T>(T[] array)
        // {
        //     int n = array.Length;
        //     for (int i = 0; i < n; i++)
        //     {
        //         // Use Next on random instance with an argument.
        //         // ... The argument is an exclusive bound.
        //         //     So we will not go past the end of the array.
        //         int r = i + _random.Next(n - i);
        //         T t = array[r];
        //         array[r] = array[i];
        //         array[i] = t;
        //     }
        // }

        void Shuffle(int[] a)
        {
            // Loops through array
            for (int i = a.Length - 1; i > 0; i--)
            {
                // Randomize a number between 0 and i (so that the range decreases each time)
                int rnd = Random.Range(0, i);
                // Save the value of the current i, otherwise it'll overright when we swap the values
                int temp = a[i];
                // Swap the new and old values
                a[i] = a[rnd];
                a[rnd] = temp;
            }
        }

        void Shuffle(List<int> t)
        {
            for (int i = t.Count - 1; i > 0; i--)
            {
                int randomIndex = Random.Range(0, i);
                int temp = t[i];
                t[i] = t[randomIndex];
                t[randomIndex] = temp;
            }
        }
    }
}