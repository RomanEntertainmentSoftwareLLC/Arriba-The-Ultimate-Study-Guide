using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch2CountriesGame
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
            numberOfQuestions = 27;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            //Nacionalidades y Países (Nationalities) pg. 75
            question[0] = "Germany"; answer[0] = "alemania";
            question[1] = "Brazil"; answer[1] = "brasil";
            question[2] = "China"; answer[2] = "china";
            question[3] = "Korea"; answer[3] = "coreo";
            question[4] = "France"; answer[4] = "francia";
            question[5] = "England"; answer[5] = "inglaterra";
            question[6] = "Italy"; answer[6] = "italia";
            question[7] = "Japan"; answer[7] = "japón";
            question[8] = "Portugal"; answer[8] = "portugal";
            question[9] = "Russia"; answer[9] = "rusia";
            question[10] = "Canada"; answer[10] = "canadá";
            question[11] = "Argentina"; answer[11] = "argentina";
            question[12] = "Chile"; answer[12] = "chile";
            question[13] = "Colombia"; answer[13] = "colombia";
            question[14] = "Cuba"; answer[14] = "cuba";
            question[15] = "Dominican Republic"; answer[15] = "república dominicana";
            question[16] = "Ecuador"; answer[16] = "ecuador";
            question[17] = "Spain"; answer[17] = "españia";
            question[18] = "Mexico"; answer[18] = "méxico";
            question[19] = "North America"; answer[19] = "américa del norte";
            question[20] = "United States"; answer[20] = "estados unidos";
            question[21] = "Panama"; answer[21] = "panamá";
            question[22] = "Peru"; answer[22] = "perú";
            question[23] = "Puerto Rico"; answer[23] = "puerto rico";
            question[24] = "El Salvador"; answer[24] = "el salvador";
            question[25] = "Venezuela"; answer[25] = "venezuela";
            question[26] = "Guatemala"; answer[26] = "guatemala";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch2CountriesGame()
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
