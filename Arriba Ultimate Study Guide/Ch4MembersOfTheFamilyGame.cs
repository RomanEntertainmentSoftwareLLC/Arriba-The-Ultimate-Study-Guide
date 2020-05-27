using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch4MembersOfTheFamilyGame
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
            numberOfQuestions = 32;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            question[0] = "The grandfather"; answer[0] = "el abuelo";
            question[1] = "The grandmother"; answer[1] = "la abuela";
            question[2] = "The brother-in-law"; answer[2] = "el cuñado";
            question[3] = "The sister-in-law"; answer[3] = "la cuñada";
            question[4] = "The husband"; answer[4] = "el esposo";
            question[5] = "The wife"; answer[5] = "la esposa";
            question[6] = "The stepbrother"; answer[6] = "el hermanastro";
            question[7] = "The stepsister"; answer[7] = "la hermanastra";
            question[8] = "The brother"; answer[8] = "el hermano";
            question[9] = "The sister"; answer[9] = "la hermana";
            question[10] = "The son"; answer[10] = "el hijo";
            question[11] = "The daughter"; answer[11] = "la hija";
            question[12] = "The stepmother"; answer[12] = "la madrastra";
            question[13] = "The mother"; answer[13] = "la madre";
            question[14] = "The grandson"; answer[14] = "el nieto";
            question[15] = "The granddaughter"; answer[15] = "la nieta";
            question[16] = "The boyfriend"; answer[16] = "el novio";
            question[17] = "The girlfriend"; answer[17] = "la novia";
            question[18] = "The daughter-in-law"; answer[18] = "la nuera";
            question[19] = "The stepfather"; answer[19] = "el padrastro";
            question[20] = "The father"; answer[20] = "el padre";
            question[21] = "The dog (male)"; answer[21] = "el perro";
            question[22] = "The dog (female)"; answer[22] = "la perra";
            question[23] = "The cousin (male)"; answer[23] = "el primo";
            question[24] = "The cousin (female)"; answer[24] = "la prima";
            question[25] = "The nephew"; answer[25] = "el sobrino";
            question[26] = "The niece"; answer[26] = "la sobrina";
            question[27] = "The father-in-law"; answer[27] = "el suegro";
            question[28] = "The mother-in-law"; answer[28] = "la suegra";
            question[29] = "The uncle"; answer[29] = "el tío";
            question[30] = "The aunt"; answer[30] = "la tía";
            question[31] = "The son-in-law"; answer[31] = "el yerno";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch4MembersOfTheFamilyGame()
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
