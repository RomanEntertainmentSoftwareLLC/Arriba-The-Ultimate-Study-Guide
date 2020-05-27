using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch3PronounsGame
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

            question[0] = "My (+ singular)"; answer[0] = "mi";
            question[1] = "My (+ plural)"; answer[1] = "mis";
            question[2] = "Your (Inf., + singular)"; answer[2] = "tu";
            question[3] = "Your (Inf., + plural)"; answer[3] = "tus";
            question[4] = "Your (Formal, + singular)"; answer[4] = "su";
            question[5] = "Your (Formal, + plural)"; answer[5] = "sus";
            question[6] = "His / Her (Formal, + singular)"; answer[6] = "su";
            question[7] = "His / Her (Formal, + plural)"; answer[7] = "sus";
            question[8] = "Our (+ singular, male)"; answer[8] = "nuestro";
            question[9] = "Our (+ singular, female)"; answer[9] = "nuestra";
            question[10] = "Our (+ plural, male)"; answer[10] = "nuestros";
            question[11] = "Our (+ plural, female)"; answer[11] = "nuestras";
            question[12] = "Your (Inf., + singular, Spain, male)"; answer[12] = "vuestro";
            question[13] = "Your (Inf., + singular, Spain, female)"; answer[13] = "vuestra";
            question[14] = "Your (Inf., + plural, Spain, male)"; answer[14] = "vuestros";
            question[15] = "Your (Inf., + plural, Spain, female)"; answer[15] = "vuestras";
            question[16] = "Their (+ singular)"; answer[16] = "su";
            question[17] = "Their (+ plural)"; answer[17] = "sus";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch3PronounsGame()
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
