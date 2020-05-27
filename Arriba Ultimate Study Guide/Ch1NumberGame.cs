using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch1NumberGame
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
            numberOfQuestions = 38;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            //Numeros (Numbers) pg. 10
            question[0] = "Zero"; answer[0] = "cero";

            question[1] = "One"; answer[1] = "uno";
            question[2] = "Two"; answer[2] = "dos";
            question[3] = "Three"; answer[3] = "tres";
            question[4] = "Four"; answer[4] = "cuatro";
            question[5] = "Five"; answer[5] = "cinco";
            question[6] = "Six"; answer[6] = "seis";
            question[7] = "Seven"; answer[7] = "siete";
            question[8] = "Eight"; answer[8] = "ocho";
            question[9] = "Nine"; answer[9] = "nueve";
            question[10] = "Ten"; answer[10] = "diez";

            question[11] = "Eleven"; answer[11] = "once";
            question[12] = "Twelve"; answer[12] = "doce";
            question[13] = "Thirteen"; answer[13] = "trece";
            question[14] = "Fourteen"; answer[14] = "catorce";
            question[15] = "Fifteen"; answer[15] = "quince";
            question[16] = "Sixteen"; answer[16] = "dieciséis";
            question[17] = "Seventeen"; answer[17] = "diecisiete";
            question[18] = "Eighteen"; answer[18] = "dieciocho";
            question[19] = "Nineteen"; answer[19] = "diecinueve";
            question[20] = "Twenty"; answer[20] = "veinte";

            question[21] = "Twenty One"; answer[21] = "veintiuno";
            question[22] = "Twenty Two"; answer[22] = "veintidós";
            question[23] = "Twenty Three"; answer[23] = "veintitrés";
            question[24] = "Twenty Four"; answer[24] = "veinticuatro";
            question[25] = "Twenty Five"; answer[25] = "veinticinco";
            question[26] = "Twenty Six"; answer[26] = "veintiséis";
            question[27] = "Twenty Seven"; answer[27] = "veintisiete";
            question[28] = "Twenty Eight"; answer[28] = "veintiocho";
            question[29] = "Twenty Nine"; answer[29] = "veintinueve";
            question[30] = "Thirty"; answer[30] = "treinta";

            question[31] = "Fourty"; answer[31] = "cuarenta";
            question[32] = "Fifty"; answer[32] = "cincuenta";
            question[33] = "Sixty"; answer[33] = "sesenta";
            question[34] = "Seventy"; answer[34] = "setenta";
            question[35] = "Eighty"; answer[35] = "ochenta";
            question[36] = "Ninety"; answer[36] = "noventa";
            question[37] = "One Hundred"; answer[37] = "cien";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch1NumberGame()
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
