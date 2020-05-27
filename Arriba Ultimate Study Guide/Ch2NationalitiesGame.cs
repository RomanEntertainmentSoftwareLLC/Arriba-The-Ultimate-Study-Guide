using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch2NationalitiesGame
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
            numberOfQuestions = 52;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            //Nacionalidades (Nationalities) pg. 75
            question[0] = "German man"; answer[0] = "alemán";
            question[1] = "German woman"; answer[1] = "alemana";
            question[2] = "Brazilian man"; answer[2] = "brasileño";
            question[3] = "Brazilian woman"; answer[3] = "brasileña";
            question[4] = "Chinese man"; answer[4] = "chino";
            question[5] = "Chinese woman"; answer[5] = "china";
            question[6] = "Korean man"; answer[6] = "coreano";
            question[7] = "Korean woman"; answer[7] = "coreana";
            question[8] = "French man"; answer[8] = "francés";
            question[9] = "French woman"; answer[9] = "francesa";
            question[10] = "English man"; answer[10] = "inglés";
            question[11] = "English woman"; answer[11] = "inglesa";
            question[12] = "Italian man"; answer[12] = "italiano";
            question[13] = "Italian woman"; answer[13] = "italiana";
            question[14] = "Japanese man"; answer[14] = "japonés";
            question[15] = "Japanese woman"; answer[15] = "japonesa";
            question[16] = "Portuguese man"; answer[16] = "portugués";
            question[17] = "Portuguese woman"; answer[17] = "portuguesa";
            question[18] = "Russian man"; answer[18] = "ruso";
            question[19] = "Russian woman"; answer[19] = "rusa";
            question[20] = "Canadian"; answer[20] = "canadiense";
            question[21] = "Argentine man"; answer[21] = "argentino";
            question[22] = "Argentine woman"; answer[22] = "argentina";
            question[23] = "Chilian man"; answer[23] = "chileno";
            question[24] = "Chilian woman"; answer[24] = "chilena";
            question[25] = "Colombian man"; answer[25] = "colombiano";
            question[26] = "Colombian woman"; answer[26] = "colombiana";
            question[27] = "Cuban man"; answer[27] = "cubano";
            question[28] = "Cuban woman"; answer[28] = "cubana";
            question[29] = "Dominican man"; answer[29] = "dominicano";
            question[30] = "Dominican woman"; answer[30] = "dominicana";
            question[31] = "Ecuadorian man"; answer[31] = "ecuatoriano";
            question[32] = "Ecuadorian woman"; answer[32] = "ecuatoriana";
            question[33] = "Spanish man"; answer[33] = "español";
            question[34] = "Spanish woman"; answer[34] = "española";
            question[35] = "Mexican man"; answer[35] = "mexicano";
            question[36] = "Mexican woman"; answer[36] = "mexicana";
            question[37] = "U.S. Citizen"; answer[37] = "estadounidense";
            question[38] = "North American man"; answer[38] = "norteamericano";
            question[39] = "North American woman"; answer[39] = "norteamericana";
            question[40] = "Panamanian man"; answer[40] = "panameño";
            question[41] = "Panamanian woman"; answer[41] = "panameña";
            question[42] = "Peruvian man"; answer[42] = "peruano";
            question[43] = "Peruvian woman"; answer[43] = "peruana";
            question[44] = "Puerto Rican man"; answer[44] = "puertorriqueño";
            question[45] = "Puerto Rican woman"; answer[45] = "puertorriqueña";
            question[46] = "Salvadoran man"; answer[46] = "salvadoreño";
            question[47] = "Salvadoran woman"; answer[47] = "salvadoreña";
            question[48] = "Venezuelan man"; answer[48] = "venezolano";
            question[49] = "Venezuelan woman"; answer[49] = "venezolana";
            question[50] = "Guatemalan man"; answer[50] = "guatemalteco";
            question[51] = "Guatemalan woman"; answer[51] = "guatemalteca";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch2NationalitiesGame()
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
