using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch1MonthsOfTheYearGame
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
            numberOfQuestions = 12;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            //Los meses del año (The months of the year) pg. 13
            question[0] = "January"; answer[0] = "enero";
            question[1] = "February"; answer[1] = "febrero";
            question[2] = "March"; answer[2] = "marzo";
            question[3] = "April"; answer[3] = "abril";
            question[4] = "May"; answer[4] = "mayo";
            question[5] = "June"; answer[5] = "junio";
            question[6] = "July"; answer[6] = "julio";
            question[7] = "August"; answer[7] = "agosto";
            question[8] = "September"; answer[8] = "septiembre";
            question[9] = "October"; answer[9] = "octubre";
            question[10] = "November"; answer[10] = "noviembre";
            question[11] = "December"; answer[11] = "diciembre";
            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch1MonthsOfTheYearGame()
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
