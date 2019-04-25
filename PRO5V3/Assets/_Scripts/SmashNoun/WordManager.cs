using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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
        List<Vector3> tseries = new List<Vector3>();

        void Start()
        {
            // Register event callback functions here
            EventSystem.Current.RegisterListener<UnitDeathEventInfo>(UnitDied);

            insertAlotOfQuestions();

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

            foreach (var item in questionAnswer)
            {
                Debug.Log("Questions: " + item.questionData);
                item.answer.ForEach(
                    (x) =>
                    {
                        Debug.Log("Answers: " + x.AnswerData);
                    }
                );
            }

            questionAnswer.Shuffle();

            foreach (var item in questionAnswer)
            {
                Debug.Log("Questions: " + item.questionData);
                item.answer.ForEach(
                    (x) =>
                    {
                        Debug.Log("Answers: " + x.AnswerData);
                    }
                );
            }

            // List<GameObject> barrelsInTheWorld = new List<GameObject>();
            // foreach (var item in tseries)
            // {
            //     GameObject obj = SpawnUnit(item);
            //     barrelsInTheWorld.Add(obj);
            // }
            // Give barrels information
            // foreach (var barrel in barrelsInTheWorld)
            // {
            //     foreach (var item in questionAnswer)
            //     {
            //         // Debug.Log("Questions: " + item.questionData);
            //         item.answer.ForEach(
            //             (x) =>
            //             {
            //                 
            //             }
            //        if (x.IsCorrect == true)
            //                 {
            //                     barrel.gameObject.GetComponent<BarrelInformation>().isCorrect = true;
            //                     barrel.gameObject.GetComponent<BarrelInformation>().Answer = x.AnswerData;
            //                 }
            //                 else
            //                 {
            //                     barrel.gameObject.GetComponent<BarrelInformation>().isCorrect = false;
            //                     barrel.gameObject.GetComponent<BarrelInformation>().Answer = x.AnswerData;
            //                 } );
            //     }
            // }
            int index = 0;
            foreach (var item in tseries)
            {
                GameObject obj = SpawnUnit(item);


                var what = questionAnswer.ElementAt(0).answer.ElementAt(index);
                if (what.IsCorrect == true)
                {
                    obj.gameObject.GetComponent<BarrelInformation>().isCorrect = true;
                    obj.gameObject.GetComponent<BarrelInformation>().Answer = what.AnswerData;
                }
                else
                {
                    obj.gameObject.GetComponent<BarrelInformation>().isCorrect = false;
                    obj.gameObject.GetComponent<BarrelInformation>().Answer = what.AnswerData;
                }
                index++;
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

        GameObject SpawnUnit(Vector3 dreamLocation)
        {
            return Instantiate(barrel, dreamLocation, Quaternion.Euler(new Vector3(-90, 0, 0)));
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
            return new Question(question);
        }

        private void insertAlotOfQuestions()
        {
            Question qq = getQuestion("Hello");

            qq.answer.Add(new Answer("Hola", false));
            qq.answer.Add(new Answer("Hello", true));
            qq.answer.Add(new Answer("Hoi", false));

            // questionAnswer.Add(0, qq);
            questionAnswer.Add(qq);
            // Clean reference
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
    }

    // https://stackoverflow.com/questions/273313/randomize-a-listt
    static class Extension
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                //int rnd = Random.Range(0, n);
                int k = Random.Range(0, n);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }

}