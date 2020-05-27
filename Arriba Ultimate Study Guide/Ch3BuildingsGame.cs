using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch3BuildingsGame
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
            numberOfQuestions = 22;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            question[0] = "The auditorium"; answer[0] = "el auditorio";
            question[1] = "The library"; answer[1] = "la biblioteca";
            question[2] = "The cafeteria"; answer[2] = "la cafetería";
            question[3] = "The tennis court"; answer[3] = "la cancha de tenis";
            question[4] = "The student union"; answer[4] = "el centro estudiantil";
            question[5] = "The stadium"; answer[5] = "el estadio";
            question[6] = "The school of art"; answer[6] = "la facultad de arte";
            question[7] = "The school of science"; answer[7] = "la facultad de ciencias";
            question[8] = "The school of law"; answer[8] = "la facultad de derecho";
            question[9] = "The school of humanities"; answer[9] = "la facultad de filosofía y letras";
            question[10] = "The school of engineering"; answer[10] = "la facultad de ingeniería";
            question[11] = "The school of medicine"; answer[11] = "la facultad de medicina";
            question[12] = "The school of education"; answer[12] = "la facultad de pedagogía";
            question[13] = "The gymnasium"; answer[13] = "el gimnasio";
            question[14] = "The laboratory"; answer[14] = "el laboratorio";
            question[15] = "The language laboratory"; answer[15] = "el laboratorio de lenguas";
            question[16] = "The computer laboratory"; answer[16] = "el laboratorio de computadoras";
            question[17] = "The bookstore"; answer[17] = "la librería";
            question[18] = "The museum"; answer[18] = "el museo";
            question[19] = "The observatory"; answer[19] = "el observatorio";
            question[20] = "The president's office"; answer[20] = "la rectoría";
            question[21] = "The theater"; answer[21] = "el teatro";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch3BuildingsGame()
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
