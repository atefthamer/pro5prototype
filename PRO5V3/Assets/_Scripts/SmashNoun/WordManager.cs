using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Threading.Tasks;

//using System;

namespace SmashNoun
{
    public class WordManager : MonoBehaviour
    {
        //[SerializeField]
        //List<string> wordsList = new List<string>();
        // How many rounds per game?
        public const int MAX_ROUNDS = 3;
        private const int ANSWER_COUNT = 3;
        public GameObject barrel;
        [SerializeField]
        List<Vector3> tseries = new List<Vector3>();
        Stack<Question> stq = new Stack<Question>();

        // If you want to use the inspector
        [SerializeField]
        Question ko = new Question();

        void Start()
        {
            // Register event callback functions here
            EventSystem.Current.RegisterListener<UnitDeathEventInfo>(UnitDied);

            insertAlotOfQuestions();

            questionAnswer.Shuffle();

            for (int i = 0; i < MAX_ROUNDS; i++)
            {
                stq.Push(questionAnswer.ElementAt(i));
            }
            Debug.Log("1 STACK SIZE " + stq.Count);
            DoYourThang();

        }

        List<GameObject> spwnd = new List<GameObject>();
        private void DoYourThang()
        {
            int index = 0;
            var what = stq.Pop();//.answer.ElementAt(index);

            foreach (var item in tseries)
            {
                GameObject obj = SpawnUnit(item);
                spwnd.Add(obj);
                // var what = questionAnswer.ElementAt(0).answer.ElementAt(index);             
                var ans = what.answer.ElementAt(index);
                if (ans.IsCorrect == true)
                {
                    obj.gameObject.GetComponent<BarrelInformation>().isCorrect = true;
                    obj.gameObject.GetComponent<BarrelInformation>().Answer = ans.AnswerData;
                }
                else
                {
                    obj.gameObject.GetComponent<BarrelInformation>().isCorrect = false;
                    obj.gameObject.GetComponent<BarrelInformation>().Answer = ans.AnswerData;
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

        bool isCoroutineExecuting = false;

        IEnumerator ExecuteAfterTime(float time, GameObject go)
        {
            if (isCoroutineExecuting)
                yield break;

            isCoroutineExecuting = true;
            yield return new WaitForSeconds(time);
            // Code to execute after the delay
            Destroy(go);

            isCoroutineExecuting = false;
            if (stq.Count != 0)
            {
                StartCoroutine(RespawnAfterTime(5));
            }
        }

        IEnumerator RespawnAfterTime(float time)
        {
            if (isCoroutineExecuting)
                yield break;

            isCoroutineExecuting = true;
            yield return new WaitForSeconds(time);
            // Code to execute after the delay
            DoYourThang();
            isCoroutineExecuting = false;


        }
        void UnitDied(UnitDeathEventInfo unitDeathInfo)
        {
            var go = unitDeathInfo.UnitGO;
            var target = go.gameObject.GetComponent<BarrelInformation>().isCorrect;
            if (target)
            {

                StartCoroutine(ExecuteAfterTime(5, go));

                spwnd.Remove(go);

                for (int i = 0; i < spwnd.Count; i++)
                {
                    Destroy(spwnd[i]);
                }

                spwnd.Clear();
            }

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

            public Question()
            {
                answer = new List<Answer>();
            }
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