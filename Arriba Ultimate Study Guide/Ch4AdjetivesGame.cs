using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch4AdjetivesGame
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
            numberOfQuestions = 15;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            question[0] = "this (male)"; answer[0] = "este";
            question[1] = "this (female)"; answer[1] = "esta";
            question[2] = "that (close to, male)"; answer[2] = "ese";
            question[3] = "that (close to, female)"; answer[3] = "esa";
            question[4] = "that (over there, male)"; answer[4] = "aquel";
            question[5] = "that (over there, female)"; answer[5] = "aquella";
            question[6] = "these (male)"; answer[6] = "estos";
            question[7] = "these (female)"; answer[7] = "estas";
            question[8] = "those (close to, male)"; answer[8] = "esos";
            question[9] = "those (close to, female)"; answer[9] = "esas";
            question[10] = "those (over there, male)"; answer[10] = "aquellos";
            question[11] = "those (over there, female)"; answer[11] = "aquellas";
            question[12] = "here"; answer[12] = "aquí";
            question[13] = "there"; answer[13] = "allí";
            question[14] = "over there"; answer[14] = "allá";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch4AdjetivesGame()
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
