using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch1ColorGame
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
            numberOfQuestions = 18;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            //Los colores (Colors) pg. 39
            question[0] = "Yellow (male)"; answer[0] = "amarillo";
            question[1] = "Yellow (female)"; answer[1] = "amarilla";
            question[2] = "Orange (male)"; answer[2] = "anaranjado";
            question[3] = "Orange (female)"; answer[3] = "anaranjada";
            question[4] = "Blue"; answer[4] = "azul";
            question[5] = "White (male)"; answer[5] = "blanco";
            question[6] = "White (female)"; answer[6] = "blanca";
            question[7] = "Brown"; answer[7] = "color café";
            question[8] = "Gray"; answer[8] = "gris";
            question[9] = "Purple (male)"; answer[9] = "morado";
            question[10] = "Purple (female)"; answer[10] = "morada";
            question[11] = "Black (male)"; answer[11] = "negro";
            question[12] = "Black (female)"; answer[12] = "negra";
            question[13] = "Red (male)"; answer[13] = "rojo";
            question[14] = "Red (female)"; answer[14] = "roja";
            question[15] = "Pink (male)"; answer[15] = "rosado";
            question[16] = "Pink (female)"; answer[16] = "rosada";
            question[17] = "Green"; answer[17] = "verde";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch1ColorGame()
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
