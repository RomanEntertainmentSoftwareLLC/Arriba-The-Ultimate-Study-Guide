using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch3BigNumbersGame
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
            numberOfQuestions = 21;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            question[0] = "Hundred (1-9)"; answer[0] = "ciento";
            question[1] = "Two hundred (male)"; answer[1] = "doscientos";
            question[2] = "Two hundred (female)"; answer[2] = "doscientas";
            question[3] = "Three hundred (male)"; answer[3] = "trescientos";
            question[4] = "Three hundred (female)"; answer[4] = "trescientas";
            question[5] = "Four hundred (male)"; answer[5] = "cuatrocientos";
            question[6] = "Four hundred (female)"; answer[6] = "cuatrocientas";
            question[7] = "Five hundred (male)"; answer[7] = "quinientos";
            question[8] = "Five hundred (female)"; answer[8] = "quinientas";
            question[9] = "Six hundred (male)"; answer[9] = "seiscientos";
            question[10] = "Six hundred (female)"; answer[10] = "seiscientas";
            question[11] = "Seven hundred (male)"; answer[11] = "setecientos";
            question[12] = "Seven hundred (female)"; answer[12] = "setecientas";
            question[13] = "Eight hundred (male)"; answer[13] = "ochocientos";
            question[14] = "Eight hundred (female)"; answer[14] = "ochocientas";
            question[15] = "Nine hundred (male)"; answer[15] = "novecientos";
            question[16] = "Nine hundred (female)"; answer[16] = "novecientas";
            question[17] = "Thousand"; answer[17] = "mil";
            question[18] = "Ten thousand"; answer[18] = "diez mil";
            question[19] = "Hundred thousand"; answer[19] = "cien mil";
            question[20] = "One million"; answer[20] = "un millón";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch3BigNumbersGame()
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
