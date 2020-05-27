using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch2WhatTimeIsItGame
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

            //Horas (Time) pg. 46
            question[0] = "What time is it?"; answer[0] = "¿qué hora es?";
            question[1] = "The noon"; answer[1] = "el mediodía";
            question[2] = "The midnight"; answer[2] = "la medianoche";
            question[3] = "It's noon"; answer[3] = "es mediodía";
            question[4] = "It's midnight"; answer[4] = "es medianoche";
            question[5] = "Until (an hour)"; answer[5] = "menos";
            question[6] = "Half (past an hour)"; answer[6] = "media";
            question[7] = "(Hour) on the dot / sharp"; answer[7] = "en punto";
            question[8] = "(Hour) in the morning"; answer[8] = "de la mañana";
            question[9] = "(Hour) in the afternoon"; answer[9] = "de la tarde";
            question[10] = "(Hour) in the evening"; answer[10] = "de la noche";
            question[11] = "(Situation) in the morning"; answer[11] = "por la mañana";
            question[12] = "(Situation) in the afternoon"; answer[12] = "por la tarde";
            question[13] = "(Situation) in the evening"; answer[13] = "por la noche";
            question[14] = "What time (does event take place)?"; answer[14] = "¿a qué hora?";
            question[15] = "It's one o clock"; answer[15] = "es la una";
            question[16] = "It's (hour) o clock"; answer[16] = "son las";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch2WhatTimeIsItGame()
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
