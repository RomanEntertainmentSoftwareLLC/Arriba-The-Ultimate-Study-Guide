using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch3WhereIsItGame
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
            numberOfQuestions = 17;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            question[0] = "Beside / Next to"; answer[0] = "al lado";
            question[1] = "To the right"; answer[1] = "a la derecha";
            question[2] = "To the left"; answer[2] = "a la izquierda";
            question[3] = "Nearby / Close to"; answer[3] = "cerca";
            question[4] = "In front"; answer[4] = "delante";
            question[5] = "Behind"; answer[5] = "detrás";
            question[6] = "Facing across"; answer[6] = "enfrente";
            question[7] = "Between"; answer[7] = "entre";
            question[8] = "Far"; answer[8] = "lejos";
            question[9] = "Beside / Next to (the)"; answer[9] = "al lado de";
            question[10] = "To the right (of)"; answer[10] = "a la derecha de";
            question[11] = "To the left (of)"; answer[11] = "a la izquierda de";
            question[12] = "Nearby / Close to (the)"; answer[12] = "cerca de";
            question[13] = "In front (of)"; answer[13] = "delante de";
            question[14] = "Behind (the)"; answer[14] = "detrás de";
            question[15] = "Facing across (from)"; answer[15] = "enfrente de";
            question[16] = "Far (from)"; answer[16] = "lejos de";


            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch3WhereIsItGame()
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
