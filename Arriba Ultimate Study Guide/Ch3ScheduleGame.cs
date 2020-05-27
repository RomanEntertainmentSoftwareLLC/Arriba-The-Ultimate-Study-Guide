using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch3ScheduleGame
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
            numberOfQuestions = 28;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            question[0] = "The business administration"; answer[0] = "la administración de empresas";
            question[1] = "The architecture"; answer[1] = "la arquitectura";
            question[2] = "The art"; answer[2] = "el arte";
            question[3] = "The biology"; answer[3] = "la biología";
            question[4] = "The calculus"; answer[4] = "el cálculo";
            question[5] = "The political science"; answer[5] = "las ciencias políticas";
            question[6] = "The social science"; answer[6] = "las ciencias sociales";
            question[7] = "The communications"; answer[7] = "las comunicaciones";
            question[8] = "The accounting"; answer[8] = "la contabilidad";
            question[9] = "The law"; answer[9] = "el derecho";
            question[10] = "The design"; answer[10] = "el diseño";
            question[11] = "The physical education"; answer[11] = "la educación física";
            question[12] = "The economics"; answer[12] = "la economía";
            question[13] = "The statistics"; answer[13] = "la estadística";
            question[14] = "The philosophy"; answer[14] = "la filosofía";
            question[15] = "The finance"; answer[15] = "las finanzas";
            question[16] = "The physics"; answer[16] = "la física";
            question[17] = "The geography"; answer[17] = "la geografía";
            question[18] = "The geology"; answer[18] = "la geología";
            question[19] = "The history"; answer[19] = "la historia";
            question[20] = "The computer science"; answer[20] = "la informática";
            question[21] = "The engineering"; answer[21] = "la ingeniería";
            question[22] = "The electrical engineering"; answer[22] = "la ingeniería eléctrica";
            question[23] = "The mathematics"; answer[23] = "las matemáticas";
            question[24] = "The medicine"; answer[24] = "la medicina";
            question[25] = "The teaching"; answer[25] = "la pedagogía";
            question[26] = "The chemistry"; answer[26] = "la química";
            question[27] = "The veterinary science"; answer[27] = "la veterinaria";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch3ScheduleGame()
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
