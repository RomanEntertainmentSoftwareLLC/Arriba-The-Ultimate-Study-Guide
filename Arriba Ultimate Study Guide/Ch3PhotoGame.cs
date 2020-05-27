using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch3PhotoGame
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
            numberOfQuestions = 224;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            question[0] = "The business administration"; answer[0] = "la administración de emprasas";
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
            question[23] = "The mathematics"; answer[23] = "la matemáticas";
            question[24] = "The medicine"; answer[24] = "la medicina";
            question[25] = "The teaching"; answer[25] = "la pedagogía";
            question[26] = "The chemistry"; answer[26] = "la química";
            question[27] = "The veterinary science"; answer[27] = "la veterinaria";

            question[28] = "The career"; answer[28] = "la carrera";
            question[29] = "The boy (chick)"; answer[29] = "el chico";
            question[30] = "The girl (chick)"; answer[30] = "la chica";
            question[31] = "The email"; answer[31] = "el correo electrónico";
            question[32] = "The money"; answer[32] = "el dinero";
            question[33] = "The schedule"; answer[33] = "el horario";
            question[34] = "The class schedule"; answer[34] = "el horario de clases";
            question[35] = "The semester"; answer[35] = "el semestre";
            question[36] = "The trimester"; answer[36] = "el trimestre";
            question[37] = "The video game"; answer[37] = "el videojuego";

            question[38] = "Complicated (male)"; answer[38] = "complicado";
            question[39] = "Complicated (female)"; answer[39] = "complicada";
            question[40] = "Challenging"; answer[40] = "exigente";
            question[41] = "Obligatory (male)"; answer[41] = "obligatorio";
            question[42] = "Obligatory (female)"; answer[42] = "obligatoria";

            question[43] = "Before"; answer[43] = "antes";
            question[44] = "Quite"; answer[44] = "bastante";
            question[45] = "After"; answer[45] = "después";
            question[46] = "Only"; answer[46] = "solamente";

            question[47] = "To be __ years old"; answer[47] = "tener años";
            question[48] = "To be warm"; answer[48] = "tener calor";
            question[49] = "To be careful"; answer[49] = "tener cuidado";
            question[50] = "To be cold"; answer[50] = "tener frío";
            question[51] = "To feel like"; answer[51] = "tener ganas";
            question[52] = "To be hungry"; answer[52] = "tener hambre";
            question[53] = "To be afraid"; answer[53] = "tener miedo";
            question[54] = "To be in a hurry"; answer[54] = "tener prisa";
            question[55] = "To be right"; answer[55] = "tener razón";
            question[56] = "To be thirsty"; answer[56] = "tener sed";
            question[57] = "To be sleepy"; answer[57] = "tener sueño";

            question[58] = "The auditorium"; answer[58] = "el auditorio";
            question[59] = "The library"; answer[59] = "la biblioteca";
            question[60] = "The cafeteria"; answer[60] = "la cafetería";
            question[61] = "The tennis court"; answer[61] = "la cancha de tenis";
            question[62] = "The student union"; answer[62] = "el centro estudiantil";
            question[63] = "The stadium"; answer[63] = "el estadio";
            question[64] = "The school of art"; answer[64] = "la facultad de arte";
            question[65] = "The school of science"; answer[65] = "la facultad de ciencias";
            question[66] = "The school of law"; answer[66] = "la facultad de derecho";
            question[67] = "The school of humanities"; answer[67] = "la facultad de filosofía y letras";
            question[68] = "The school of engineering"; answer[68] = "la facultad de ingeniería";
            question[69] = "The school of medicine"; answer[69] = "la facultad de medicina";
            question[70] = "The school of education"; answer[70] = "la facultad de pedagogía";
            question[71] = "The gymnasium"; answer[71] = "el gimnasio";
            question[72] = "The laboratory"; answer[72] = "el laboratorio";
            question[73] = "The language laboratory"; answer[73] = "el laboratorio de lenguas";
            question[74] = "The computer laboratory"; answer[74] = "el laboratorio de computadores";
            question[75] = "The bookstore"; answer[75] = "la librería";
            question[76] = "The museum"; answer[76] = "el museo";
            question[77] = "The observatory"; answer[77] = "el observatorio";
            question[78] = "The president's office"; answer[78] = "la rectoría";
            question[79] = "The theater"; answer[79] = "el teatro";

            question[80] = "Almost"; answer[80] = "casi";
            question[81] = "Always"; answer[81] = "siempre";
            question[82] = "Only"; answer[82] = "solo";

            question[83] = "Look"; answer[83] = "mira";
            question[84] = "Well"; answer[84] = "pues";
            question[85] = "I'll go with you"; answer[85] = "te acompaño";
            question[86] = "Let's go"; answer[86] = "vamos";

            question[87] = "To be"; answer[87] = "estar";
            question[88] = "I am"; answer[88] = "estoy";
            question[89] = "You are (Informal)"; answer[89] = "estás";
            question[90] = "You are (Formal)"; answer[90] = "está";
            question[91] = "He is"; answer[91] = "está";
            question[92] = "She is"; answer[92] = "está";
            question[93] = "We are"; answer[93] = "estamos";
            question[94] = "You are (Inf., Plural, Spain)"; answer[94] = "estáis";
            question[95] = "You are (Formal, Plural)"; answer[95] = "están";
            question[96] = "They are (male / female)"; answer[96] = "están";

            question[97] = "To do"; answer[97] = "hacer";
            question[98] = "I do"; answer[98] = "hago";
            question[99] = "You do (Informal)"; answer[99] = "haces";
            question[100] = "You do (Formal)"; answer[100] = "hace";
            question[101] = "He does"; answer[101] = "hace";
            question[102] = "She does"; answer[102] = "hace";
            question[103] = "We do"; answer[103] = "hacemos";
            question[104] = "You do (Inf., Plural, Spain)"; answer[104] = "hacéis";
            question[105] = "You do (Formal, Plural)"; answer[105] = "hacen";
            question[106] = "They do (male / female)"; answer[106] = "hacen";

            question[107] = "To go"; answer[107] = "ir";
            question[108] = "I go"; answer[108] = "voy";
            question[109] = "You go (Informal)"; answer[109] = "vas";
            question[110] = "You go (Formal)"; answer[110] = "va";
            question[111] = "He goes"; answer[111] = "va";
            question[112] = "She goes"; answer[112] = "va";
            question[113] = "We go"; answer[113] = "vamos";
            question[114] = "You go (Inf., Plural, Spain)"; answer[114] = "vais";
            question[115] = "You go (Formal, Plural)"; answer[115] = "van";
            question[116] = "They go (male / female)"; answer[116] = "van";

            question[117] = "All (male, singular)"; answer[117] = "todo";
            question[118] = "All (female, singular)"; answer[118] = "toda";
            question[119] = "All (male, plural)"; answer[119] = "todos";
            question[120] = "All (female, plural)"; answer[120] = "todas";

            question[121] = "Hundred (1-9)"; answer[121] = "ciento";
            question[122] = "Two hundred (male)"; answer[122] = "doscientos";
            question[123] = "Two hundred (female)"; answer[123] = "doscientas";
            question[124] = "Three hundred (male)"; answer[124] = "trescientos";
            question[125] = "Three hundred (female)"; answer[125] = "trescientas";
            question[126] = "Four hundred (male)"; answer[126] = "cuatrocientos";
            question[127] = "Four hundred (female)"; answer[127] = "cuatrocientas";
            question[128] = "Five hundred (male)"; answer[128] = "quinientos";
            question[129] = "Five hundred (female)"; answer[129] = "quinientas";
            question[130] = "Six hundred (male)"; answer[130] = "seiscientos";
            question[131] = "Six hundred (female)"; answer[131] = "seiscientas";
            question[132] = "Seven hundred (male)"; answer[132] = "setecientos";
            question[133] = "Seven hundred (female)"; answer[133] = "setecientas";
            question[134] = "Eight hundred (male)"; answer[134] = "ochocientos";
            question[135] = "Eight hundred (female)"; answer[135] = "ochocientas";
            question[136] = "Nine hundred (male)"; answer[136] = "novecientos";
            question[137] = "Nine hundred (female)"; answer[137] = "novecientas";
            question[138] = "Thousand"; answer[138] = "mil";
            question[139] = "Ten thousand"; answer[139] = "diez mil";
            question[140] = "Hundred thousand"; answer[140] = "cien mil";
            question[141] = "One million"; answer[141] = "un millón";

            question[142] = "My (+ singular)"; answer[142] = "mi";
            question[143] = "My (+ plural)"; answer[143] = "mis";
            question[144] = "Your (Inf., + singular)"; answer[144] = "tu";
            question[145] = "Your (Inf., + plural)"; answer[145] = "tus";
            question[146] = "Your (Formal, + singular)"; answer[146] = "su";
            question[147] = "Your (Formal, + plural)"; answer[147] = "sus";
            question[148] = "His / Her (Formal, + singular)"; answer[148] = "su";
            question[149] = "His / Her (Formal, + plural)"; answer[149] = "sus";
            question[150] = "Our (+ singular, male)"; answer[150] = "nuestro";
            question[151] = "Our (+ singular, female)"; answer[151] = "nuestra";
            question[152] = "Our (+ plural, male)"; answer[152] = "nuestros";
            question[153] = "Our (+ plural, female)"; answer[153] = "nuestras";
            question[154] = "Your (Inf., + singular, Spain, male)"; answer[154] = "vuestro";
            question[155] = "Your (Inf., + singular, Spain, female)"; answer[155] = "vuestra";
            question[156] = "Your (Inf., + plural, Spain, male)"; answer[156] = "vuestros";
            question[157] = "Your (Inf., + plural, Spain, female)"; answer[157] = "vuestras";
            question[158] = "Their (+ singular)"; answer[158] = "su";
            question[159] = "Their (+ plural)"; answer[159] = "sus";

            question[160] = "Beside / Next to"; answer[160] = "al lado";
            question[161] = "To the right of"; answer[161] = "a la derecha";
            question[162] = "To the left of"; answer[162] = "a la izquierda";
            question[163] = "Nearby / Close to"; answer[163] = "cerca";
            question[164] = "In front of"; answer[164] = "delante";
            question[165] = "Behind"; answer[165] = "detrás";
            question[166] = "Facing across from"; answer[166] = "enfrente";
            question[167] = "Between"; answer[167] = "entre";
            question[168] = "Far from"; answer[168] = "lejos";

            question[169] = "Bored (male)"; answer[169] = "aburrido";
            question[170] = "Bored (female)"; answer[170] = "aburrida";
            question[171] = "Tired (male)"; answer[171] = "cansado";
            question[172] = "Tired (female)"; answer[172] = "cansada";
            question[173] = "Married to (male)"; answer[173] = "casado";
            question[174] = "Married to (female)"; answer[174] = "casada";
            question[175] = "Happy (male)"; answer[175] = "contento";
            question[176] = "Happy (female)"; answer[176] = "contenta";
            question[177] = "In love with (male)"; answer[177] = "enamorado";
            question[178] = "In love with (female)"; answer[178] = "enamorada";
            question[179] = "Sick (male)"; answer[179] = "enfermo";
            question[180] = "Sick (female)"; answer[180] = "enferma";
            question[181] = "Angry (male)"; answer[181] = "enojado";
            question[182] = "Angry (female)"; answer[182] = "enojada";
            question[183] = "Nervous (male)"; answer[183] = "nervioso";
            question[184] = "Nervous (female)"; answer[184] = "nerviosa";
            question[185] = "Busy (male)"; answer[185] = "ocupado";
            question[186] = "Busy (female)"; answer[186] = "ocupada";
            question[187] = "Worried (male)"; answer[187] = "preocupado";
            question[188] = "Worried (female)"; answer[188] = "preocupada";
            question[189] = "Sad"; answer[189] = "triste";

            question[190] = "To be boring (male)"; answer[190] = "ser aburrido";
            question[191] = "To be boring (female)"; answer[191] = "ser aburrida";
            question[192] = "To be pretty (male)"; answer[192] = "ser bonito";
            question[193] = "To be pretty (female)"; answer[193] = "ser bonita";
            question[194] = "To be ugly (male)"; answer[194] = "ser feo";
            question[195] = "To be ugly (female)"; answer[195] = "ser fea";
            question[196] = "To be goodlooking (male)"; answer[196] = "ser guapo";
            question[197] = "To be goodlooking (female)"; answer[197] = "ser guapa";
            question[198] = "To be clever (male)"; answer[198] = "ser listo";
            question[199] = "To be clever (female)"; answer[199] = "ser lista";
            question[200] = "To be bad / evil (male)"; answer[200] = "ser malo";
            question[201] = "To be bad / evil (female)"; answer[201] = "ser mala";
            question[202] = "To be rich (male)"; answer[202] = "ser rico";
            question[203] = "To be rich (female)"; answer[203] = "ser rica";
            question[204] = "To be green"; answer[204] = "ser verde";
            question[205] = "To be smart (male)"; answer[205] = "ser vivo";
            question[206] = "To be smart (female)"; answer[206] = "ser viva";
            question[207] = "To be bored (male)"; answer[207] = "estar aburrido";
            question[208] = "To be bored (female)"; answer[208] = "estar aburrida";
            question[209] = "To look pretty (male)"; answer[209] = "estar bonito";
            question[210] = "To look pretty (female)"; answer[210] = "estar bonita";
            question[211] = "To look ugly (male)"; answer[211] = "estar feo";
            question[212] = "To look ugly (female)"; answer[212] = "estar fea";
            question[213] = "To look good (male)"; answer[213] = "estar guapo";
            question[214] = "To look good (female)"; answer[214] = "estar guapa";
            question[215] = "To be ready (male)"; answer[215] = "estar listo";
            question[216] = "To be ready (female)"; answer[216] = "estar lista";
            question[217] = "To be ill (male)"; answer[217] = "estar malo";
            question[218] = "To be ill (female)"; answer[218] = "estar mala";
            question[219] = "To taste good (male)"; answer[219] = "estar rico";
            question[220] = "To taste good (female)"; answer[220] = "estar rica";
            question[221] = "To look green"; answer[221] = "estar verde";
            question[222] = "To be alive (male)"; answer[222] = "estar vivo";
            question[223] = "To be alive (female)"; answer[223] = "estar viva";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch3PhotoGame()
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
