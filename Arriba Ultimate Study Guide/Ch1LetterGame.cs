using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch1LetterGame
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

            //Letras (Letters) pg. 8
            question[0] = "a"; answer[0] = "a";
            question[1] = "b"; answer[1] = "be";
            question[2] = "c"; answer[2] = "ce";
            question[3] = "d"; answer[3] = "de";
            question[4] = "e"; answer[4] = "e";
            question[5] = "f"; answer[5] = "efe";
            question[6] = "g"; answer[6] = "ge";
            question[7] = "h"; answer[7] = "hache";
            question[8] = "i"; answer[8] = "i";
            question[9] = "j"; answer[9] = "jota";
            question[10] = "k"; answer[10] = "ka";
            question[11] = "l"; answer[11] = "ele";
            question[12] = "m"; answer[12] = "eme";
            question[13] = "n"; answer[13] = "ene";
            question[14] = "ñ"; answer[14] = "eñe";
            question[15] = "o"; answer[15] = "o";
            question[16] = "p"; answer[16] = "pe";
            question[17] = "q"; answer[17] = "cu";
            question[18] = "r"; answer[18] = "ere";
            question[19] = "s"; answer[19] = "ese";
            question[20] = "t"; answer[20] = "te";
            question[21] = "u"; answer[21] = "u";
            question[22] = "v"; answer[22] = "uve";
            question[23] = "w"; answer[23] = "uve doble";
            question[24] = "x"; answer[24] = "equis";
            question[25] = "y"; answer[25] = "ye";
            question[26] = "z"; answer[26] = "zeta";


            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch1LetterGame()
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
