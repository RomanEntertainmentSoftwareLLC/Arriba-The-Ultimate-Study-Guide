using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch3VerbsGame
    {
        public int questionsInGame;
        private int numberOfQuestions;
        public int minutes;
        public int seconds;
        private string[] question;
        public string[] answer;
        public bool[] mastered;
        private int[] order;
        public int[] randomOrder;
        public int score;
        public int antiScore;
        public int index;
        public int questionNumber;
        public string text;
        public string yourAnswer;

        private void Setup_Questions()
        {
            numberOfQuestions = 30;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            question[0] = "To be (Temporary)"; answer[0] = "estar";
            question[1] = "I am (Temporary)"; answer[1] = "estoy";
            question[2] = "You are (Informal, Temporary)"; answer[2] = "estás";
            question[3] = "You are (Formal, Temporary)"; answer[3] = "está";
            question[4] = "He is (Temporary)"; answer[4] = "está";
            question[5] = "She is (Temporary)"; answer[5] = "está";
            question[6] = "We are (Temporary)"; answer[6] = "estamos";
            question[7] = "You are (Inf., Plural, Spain, Temporary)"; answer[7] = "estáis";
            question[8] = "You are (Formal, Plural, Temporary)"; answer[8] = "están";
            question[9] = "They are (male / female, Temporary)"; answer[9] = "están";

            question[10] = "To do"; answer[10] = "hacer";
            question[11] = "I do"; answer[11] = "hago";
            question[12] = "You do (Informal)"; answer[12] = "haces";
            question[13] = "You do (Formal)"; answer[13] = "hace";
            question[14] = "He does"; answer[14] = "hace";
            question[15] = "She does"; answer[15] = "hace";
            question[16] = "We do"; answer[16] = "hacemos";
            question[17] = "You do (Inf., Plural, Spain)"; answer[17] = "hacéis";
            question[18] = "You do (Formal, Plural)"; answer[18] = "hacen";
            question[19] = "They do (male / female)"; answer[19] = "hacen";

            question[20] = "To go"; answer[20] = "ir";
            question[21] = "I go"; answer[21] = "voy";
            question[22] = "You go (Informal)"; answer[22] = "vas";
            question[23] = "You go (Formal)"; answer[23] = "va";
            question[24] = "He goes"; answer[24] = "va";
            question[25] = "She goes"; answer[25] = "va";
            question[26] = "We go"; answer[26] = "vamos";
            question[27] = "You go (Inf., Plural, Spain)"; answer[27] = "vais";
            question[28] = "You go (Formal, Plural)"; answer[28] = "van";
            question[29] = "They go (male / female)"; answer[29] = "van";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch3VerbsGame()
        {
            //Constructor
            Setup_Questions();
        }

        public void Randomize_Questions()
        {
            Random rnd = new Random();
            randomOrder = order.OrderBy(x => rnd.Next()).ToArray();
        }

        public string Get_Question(int index)
        {
            if (index >= 0 && index < numberOfQuestions)
            {
                return question[index];
            }

            return string.Empty;
        }

        public string Get_Answer(int index)
        {
            if (index >= 0 && index < numberOfQuestions)
            {
                return answer[index];
            }

            return string.Empty;
        }

        public int Get_Number_Of_Questions()
        {
            return numberOfQuestions;
        }

        public int Get_Minutes()
        {
            return minutes;
        }

        public int Get_Seconds()
        {
            return seconds;
        }
    }
}
