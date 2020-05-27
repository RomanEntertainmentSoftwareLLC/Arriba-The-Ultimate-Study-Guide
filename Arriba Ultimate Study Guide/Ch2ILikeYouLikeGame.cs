using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch2ILikeYouLikeGame
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
            numberOfQuestions = 64;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            question[0] = "I like to open"; answer[0] = "me gusta abrir";
            question[1] = "I like to attend"; answer[1] = "me gusta asistir";
            question[2] = "I like to learn"; answer[2] = "me gusta aprender";
            question[3] = "I like to help"; answer[3] = "me gusta ayudar";
            question[4] = "I like to dance"; answer[4] = "me gusta bailar";
            question[5] = "I like to drink"; answer[5] = "me gusta beber";
            question[6] = "I like to search"; answer[6] = "me gusta buscar";
            question[7] = "I like to eat"; answer[7] = "me gusta comer";
            question[8] = "I like to buy"; answer[8] = "me gusta comprar";
            question[9] = "I like to understand"; answer[9] = "me gusta comprender";
            question[10] = "I like to believe"; answer[10] = "me gusta creer";
            question[11] = "I like to owe"; answer[11] = "me gusta deber";
            question[12] = "I like to decide"; answer[12] = "me gusta decidir";
            question[13] = "I like to wish"; answer[13] = "me gusta desear";
            question[14] = "I like to teach"; answer[14] = "me gusta enseñar";
            question[15] = "I like to write"; answer[15] = "me gusta escribir";
            question[16] = "I like to listen"; answer[16] = "me gusta escuchar";
            question[17] = "I like to travel"; answer[17] = "me gusta viajar";
            question[18] = "I like to study"; answer[18] = "me gusta estudiar";
            question[19] = "I like to speak"; answer[19] = "me gusta hablar";
            question[20] = "I like to read"; answer[20] = "me gusta leer";
            question[21] = "I like to arrive"; answer[21] = "me gusta llegar";
            question[22] = "I like to look"; answer[22] = "me gusta mirar";
            question[23] = "I like to practice"; answer[23] = "me gusta practicar";
            question[24] = "I like to prepare"; answer[24] = "me gusta preparar";
            question[25] = "I like to receive"; answer[25] = "me gusta recibir";
            question[26] = "I like to have"; answer[26] = "me gusta tener";
            question[27] = "I like to take"; answer[27] = "me gusta tomar";
            question[28] = "I like to work"; answer[28] = "me gusta trabajar";
            question[29] = "I like to live"; answer[29] = "me gusta vivir";
            question[30] = "I like to sell"; answer[30] = "me gusta vender";
            question[31] = "I like to watch"; answer[31] = "me gusta ver";

            question[32] = "You like to open"; answer[32] = "te gusta abrir";
            question[33] = "You like to attend"; answer[33] = "te gusta asistir";
            question[34] = "You like to learn"; answer[34] = "te gusta aprender";
            question[35] = "You like to help"; answer[35] = "te gusta ayudar";
            question[36] = "You like to dance"; answer[36] = "te gusta bailar";
            question[37] = "You like to drink"; answer[37] = "te gusta beber";
            question[38] = "You like to search"; answer[38] = "te gusta buscar";
            question[39] = "You like to eat"; answer[39] = "te gusta comer";
            question[40] = "You like to buy"; answer[40] = "te gusta comprar";
            question[41] = "You like to understand"; answer[41] = "te gusta comprender";
            question[42] = "You like to believe"; answer[42] = "te gusta creer";
            question[43] = "You like to owe"; answer[43] = "te gusta deber";
            question[44] = "You like to decide"; answer[44] = "te gusta decidir";
            question[45] = "You like to wish"; answer[45] = "te gusta desear";
            question[46] = "You like to teach"; answer[46] = "te gusta enseñar";
            question[47] = "You like to write"; answer[47] = "te gusta escribir";
            question[48] = "You like to listen"; answer[48] = "te gusta escuchar";
            question[49] = "You like to travel"; answer[49] = "te gusta viajar";
            question[50] = "You like to study"; answer[50] = "te gusta estudiar";
            question[51] = "You like to speak"; answer[51] = "te gusta hablar";
            question[52] = "You like to read"; answer[52] = "te gusta leer";
            question[53] = "You like to arrive"; answer[53] = "te gusta llegar";
            question[54] = "You like to look"; answer[54] = "te gusta mirar";
            question[55] = "You like to practice"; answer[55] = "te gusta practicar";
            question[56] = "You like to prepare"; answer[56] = "te gusta preparar";
            question[57] = "You like to receive"; answer[57] = "te gusta recibir";
            question[58] = "You like to have"; answer[58] = "te gusta tener";
            question[59] = "You like to take"; answer[59] = "te gusta tomar";
            question[60] = "You like to work"; answer[60] = "te gusta trabajar";
            question[61] = "You like to live"; answer[61] = "te gusta vivir";
            question[62] = "You like to sell"; answer[62] = "te gusta vender";
            question[63] = "You like to watch"; answer[63] = "te gusta ver";


            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch2ILikeYouLikeGame()
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
