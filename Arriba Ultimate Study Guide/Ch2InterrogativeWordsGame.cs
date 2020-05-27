using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch2InterrogativeWordsGame
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

            //Palabras Interrogativas (Interrogative Words) pg. 52
            question[0] = "How"; answer[0] = "cómo";
            question[1] = "Which one"; answer[1] = "cuál";
            question[2] = "Which ones"; answer[2] = "cuáles";
            question[3] = "When"; answer[3] = "cuándo";
            question[4] = "How many (male, singular)"; answer[4] = "cuánto";
            question[5] = "How many (female, singular)"; answer[5] = "cuánta";
            question[6] = "How many (male, plural)"; answer[6] = "cuántos";
            question[7] = "How many (female, plural)"; answer[7] = "cuántas";
            question[8] = "Where"; answer[8] = "dónde";
            question[9] = "From where"; answer[9] = "de dónde";
            question[10] = "To where"; answer[10] = "adónde";
            question[11] = "Why"; answer[11] = "por qué";
            question[12] = "What"; answer[12] = "qué";
            question[13] = "Who (singular)"; answer[13] = "quién";
            question[14] = "Who (plural)"; answer[14] = "quiénes";
            question[15] = "Whose (singular)"; answer[15] = "de quién";
            question[16] = "Whose (plural)"; answer[16] = "de quiénes";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch2InterrogativeWordsGame()
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
