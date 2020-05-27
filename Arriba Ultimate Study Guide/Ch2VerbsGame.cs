using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch2VerbsGame
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
            numberOfQuestions = 320;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            //Verbos (Verbs) pg 75.
            question[0] = "To open"; answer[0] = "abrir";
            question[1] = "I open"; answer[1] = "abro";
            question[2] = "You open (Informal)"; answer[2] = "abres";
            question[3] = "You open (Formal)"; answer[3] = "abre";
            question[4] = "He opens"; answer[4] = "abre";
            question[5] = "She opens"; answer[5] = "abre";
            question[6] = "We open"; answer[6] = "abrimos";
            question[7] = "You open (Inf., Plural, Spain)"; answer[7] = "abrís";
            question[8] = "You open (Formal, Plural)"; answer[8] = "abren";
            question[9] = "They open (male / female)"; answer[9] = "abren";

            question[10] = "To attend"; answer[10] = "asistir";
            question[11] = "I attend"; answer[11] = "asisto";
            question[12] = "You attend (Informal)"; answer[12] = "asistes";
            question[13] = "You attend (Formal)"; answer[13] = "asiste";
            question[14] = "He attends"; answer[14] = "asiste";
            question[15] = "She attends"; answer[15] = "asiste";
            question[16] = "We attend"; answer[16] = "asistimos";
            question[17] = "You attend (Inf., Plural, Spain)"; answer[17] = "asistís";
            question[18] = "You attend (Formal, Plural)"; answer[18] = "asisten";
            question[19] = "They attend (male / female)"; answer[19] = "asisten";

            question[20] = "To learn"; answer[20] = "aprender";
            question[21] = "I learn"; answer[21] = "aprendo";
            question[22] = "You learn (Informal)"; answer[22] = "aprendes";
            question[23] = "You learn (Formal)"; answer[23] = "aprende";
            question[24] = "He learns"; answer[24] = "aprende";
            question[25] = "She learns"; answer[25] = "aprende";
            question[26] = "We learn"; answer[26] = "aprendemos";
            question[27] = "You learn (Inf., Plural, Spain)"; answer[27] = "aprendéis";
            question[28] = "You learn (Formal, Plural)"; answer[28] = "aprenden";
            question[29] = "They learn (male / female)"; answer[29] = "aprenden";

            question[30] = "To help"; answer[30] = "ayudar";
            question[31] = "I help"; answer[31] = "ayudo";
            question[32] = "You help (Informal)"; answer[32] = "ayudas";
            question[33] = "You help (Formal)"; answer[33] = "ayuda";
            question[34] = "He helps"; answer[34] = "ayuda";
            question[35] = "She helps"; answer[35] = "ayuda";
            question[36] = "We help"; answer[36] = "ayudamos";
            question[37] = "You help (Inf., Plural, Spain)"; answer[37] = "ayudáis";
            question[38] = "You help (Formal, Plural)"; answer[38] = "ayudan";
            question[39] = "They help (male / female)"; answer[39] = "ayudan";

            question[40] = "To dance"; answer[40] = "bailar";
            question[41] = "I dance"; answer[41] = "bailo";
            question[42] = "You dance (Informal)"; answer[42] = "bailas";
            question[43] = "You dance (Formal)"; answer[43] = "baila";
            question[44] = "He dances"; answer[44] = "baila";
            question[45] = "She dances"; answer[45] = "baila";
            question[46] = "We dance"; answer[46] = "bailamos";
            question[47] = "You dance (Inf., Plural, Spain)"; answer[47] = "bailáis";
            question[48] = "You dance (Formal, Plural)"; answer[48] = "bailan";
            question[49] = "They dance (male / female)"; answer[49] = "bailan";

            question[50] = "To drink"; answer[50] = "beber";
            question[51] = "I drink"; answer[51] = "bebo";
            question[52] = "You drink (Informal)"; answer[52] = "bebes";
            question[53] = "You drink (Formal)"; answer[53] = "bebe";
            question[54] = "He drinks"; answer[54] = "bebe";
            question[55] = "She drinks"; answer[55] = "bebe";
            question[56] = "We drink"; answer[56] = "bebemos";
            question[57] = "You drink (Inf., Plural, Spain)"; answer[57] = "bebéis";
            question[58] = "You drink (Formal, Plural)"; answer[58] = "beben";
            question[59] = "They drink (male / female)"; answer[59] = "beben";

            question[60] = "To search"; answer[60] = "buscar";
            question[61] = "I search"; answer[61] = "busco";
            question[62] = "You search (Informal)"; answer[62] = "buscas";
            question[63] = "You search (Formal)"; answer[63] = "busca";
            question[64] = "He searches"; answer[64] = "busca";
            question[65] = "She searches"; answer[65] = "busca";
            question[66] = "We search"; answer[66] = "buscamos";
            question[67] = "You search (Inf., Plural, Spain)"; answer[67] = "buscáis";
            question[68] = "You search (Formal, Plural)"; answer[68] = "buscan";
            question[69] = "They search (male / female)"; answer[69] = "buscan";

            question[70] = "To eat"; answer[70] = "comer";
            question[71] = "I eat"; answer[71] = "como";
            question[72] = "You eat (Informal)"; answer[72] = "comes";
            question[73] = "You eat (Formal)"; answer[73] = "come";
            question[74] = "He eats"; answer[74] = "come";
            question[75] = "She eats"; answer[75] = "come";
            question[76] = "We eat"; answer[76] = "comemos";
            question[77] = "You eat (Inf., Plural, Spain)"; answer[77] = "coméis";
            question[78] = "You eat (Formal, Plural)"; answer[78] = "comen";
            question[79] = "They eat (male / female)"; answer[79] = "comen";

            question[80] = "To buy"; answer[80] = "comprar";
            question[81] = "I buy"; answer[81] = "compro";
            question[82] = "You buy (Informal)"; answer[82] = "compras";
            question[83] = "You buy (Formal)"; answer[83] = "compra";
            question[84] = "He buys"; answer[84] = "compra";
            question[85] = "She buys"; answer[85] = "compra";
            question[86] = "We buy"; answer[86] = "compramos";
            question[87] = "You buy (Inf., Plural, Spain)"; answer[87] = "compráis";
            question[88] = "You buy (Formal, Plural)"; answer[88] = "compran";
            question[89] = "They buy (male / female)"; answer[89] = "compran";

            question[90] = "To comprehend"; answer[90] = "comprender";
            question[91] = "I comprehend"; answer[91] = "comprendo";
            question[92] = "You comprehend (Informal)"; answer[92] = "comprendes";
            question[93] = "You comprehend (Formal)"; answer[93] = "comprende";
            question[94] = "He comprehends"; answer[94] = "comprende";
            question[95] = "She comprehends"; answer[95] = "comprende";
            question[96] = "We comprehend"; answer[96] = "comprendemos";
            question[97] = "You comprehend (Inf., Plural, Spain)"; answer[97] = "comprendéis";
            question[98] = "You comprehend (Formal, Plural)"; answer[98] = "comprenden";
            question[99] = "They comprehend (male / female)"; answer[99] = "comprenden";

            question[100] = "To believe"; answer[100] = "creer";
            question[101] = "I believe"; answer[101] = "creo";
            question[102] = "You believe (Informal)"; answer[102] = "crees";
            question[103] = "You believe (Formal)"; answer[103] = "cree";
            question[104] = "He believes"; answer[104] = "cree";
            question[105] = "She believes"; answer[105] = "cree";
            question[106] = "We believe"; answer[106] = "creemos";
            question[107] = "You believe (Inf., Plural, Spain)"; answer[107] = "creéis";
            question[108] = "You believe (Formal, Plural)"; answer[108] = "creen";
            question[109] = "They believe (male / female)"; answer[109] = "creen";

            question[110] = "To owe"; answer[110] = "deber";
            question[111] = "I owe"; answer[111] = "debo";
            question[112] = "You owe (Informal)"; answer[112] = "debes";
            question[113] = "You owe (Formal)"; answer[113] = "debe";
            question[114] = "He owes"; answer[114] = "debe";
            question[115] = "She owes"; answer[115] = "debe";
            question[116] = "We owe"; answer[116] = "debemos";
            question[117] = "You owe (Inf., Plural, Spain)"; answer[117] = "debéis";
            question[118] = "You owe (Formal, Plural)"; answer[118] = "deben";
            question[119] = "They owe (male / female)"; answer[119] = "deben";

            question[120] = "To decide"; answer[120] = "decidir";
            question[121] = "I decide"; answer[121] = "decido";
            question[122] = "You decide (Informal)"; answer[122] = "decides";
            question[123] = "You decide (Formal)"; answer[123] = "decide";
            question[124] = "He decides"; answer[124] = "decide";
            question[125] = "She decides"; answer[125] = "decide";
            question[126] = "We decide"; answer[126] = "decidimos";
            question[127] = "You decide (Inf., Plural, Spain)"; answer[127] = "decidís";
            question[128] = "You decide (Formal, Plural)"; answer[128] = "deciden";
            question[129] = "They decide (male / female)"; answer[129] = "deciden";

            question[130] = "To wish"; answer[130] = "desear";
            question[131] = "I wish"; answer[131] = "deseo";
            question[132] = "You wish (Informal)"; answer[132] = "deseas";
            question[133] = "You wish (Formal)"; answer[133] = "desea";
            question[134] = "He wishes"; answer[134] = "desea";
            question[135] = "She wishes"; answer[135] = "desea";
            question[136] = "We wish"; answer[136] = "deseamos";
            question[137] = "You wish (Inf., Plural, Spain)"; answer[137] = "deseáis";
            question[138] = "You wish (Formal, Plural)"; answer[138] = "desean";
            question[139] = "They wish (male / female)"; answer[139] = "desean";

            question[140] = "To teach"; answer[140] = "enseñar";
            question[141] = "I teach"; answer[141] = "enseño";
            question[142] = "You teach (Informal)"; answer[142] = "enseñas";
            question[143] = "You teach (Formal)"; answer[143] = "enseña";
            question[144] = "He teaches"; answer[144] = "enseña";
            question[145] = "She teaches"; answer[145] = "enseña";
            question[146] = "We teach"; answer[146] = "enseñamos";
            question[147] = "You teach (Inf., Plural, Spain)"; answer[147] = "enseñáis";
            question[148] = "You teach (Formal, Plural)"; answer[148] = "enseñan";
            question[149] = "They teach (male / female)"; answer[149] = "enseñan";

            question[150] = "To write"; answer[150] = "escribir";
            question[151] = "I write"; answer[151] = "escribo";
            question[152] = "You write (Informal)"; answer[152] = "escribes";
            question[153] = "You write (Formal)"; answer[153] = "escribe";
            question[154] = "He writes"; answer[154] = "escribe";
            question[155] = "She writes"; answer[155] = "escribe";
            question[156] = "We write"; answer[156] = "escribimos";
            question[157] = "You write (Inf., Plural, Spain)"; answer[157] = "escribís";
            question[158] = "You write (Formal, Plural)"; answer[158] = "escriben";
            question[159] = "They write (male / female)"; answer[159] = "escriben";

            question[160] = "To listen"; answer[160] = "escuchar";
            question[161] = "I listen"; answer[161] = "escucho";
            question[162] = "You listen (Informal)"; answer[162] = "escuchas";
            question[163] = "You listen (Formal)"; answer[163] = "escucha";
            question[164] = "He listens"; answer[164] = "escucha";
            question[165] = "She listens"; answer[165] = "escucha";
            question[166] = "We listen"; answer[166] = "escuchamos";
            question[167] = "You listen (Inf., Plural, Spain)"; answer[167] = "escucháis";
            question[168] = "You listen (Formal, Plural)"; answer[168] = "escuchan";
            question[169] = "They listen (male / female)"; answer[169] = "escuchan";

            question[170] = "To travel"; answer[170] = "viajar";
            question[171] = "I travel"; answer[171] = "viajo";
            question[172] = "You travel (Informal)"; answer[172] = "viajas";
            question[173] = "You travel (Formal)"; answer[173] = "viaja";
            question[174] = "He travels"; answer[174] = "viaja";
            question[175] = "She travels"; answer[175] = "viaja";
            question[176] = "We travel"; answer[176] = "viajamos";
            question[177] = "You travel (Inf., Plural, Spain)"; answer[177] = "viajáis";
            question[178] = "You travel (Formal, Plural)"; answer[178] = "viajan";
            question[179] = "They travel (male / female)"; answer[179] = "viajan";

            question[180] = "To study"; answer[180] = "estudiar";
            question[181] = "I study"; answer[181] = "estudio";
            question[182] = "You study (Informal)"; answer[182] = "estudias";
            question[183] = "You study (Formal)"; answer[183] = "estudia";
            question[184] = "He studies"; answer[184] = "estudia";
            question[185] = "She studies"; answer[185] = "estudia";
            question[186] = "We study"; answer[186] = "estudiamos";
            question[187] = "You study (Inf., Plural, Spain)"; answer[187] = "estudiáis";
            question[188] = "You study (Formal, Plural)"; answer[188] = "estudian";
            question[189] = "They study (male / female)"; answer[189] = "estudian";

            question[190] = "To speak"; answer[190] = "hablar";
            question[191] = "I speak"; answer[191] = "hablo";
            question[192] = "You speak (Informal)"; answer[192] = "hablas";
            question[193] = "You speak (Formal)"; answer[193] = "habla";
            question[194] = "He speaks"; answer[194] = "habla";
            question[195] = "She speaks"; answer[195] = "habla";
            question[196] = "We speak"; answer[196] = "hablamos";
            question[197] = "You speak (Inf., Plural, Spain)"; answer[197] = "habláis";
            question[198] = "You speak (Formal, Plural)"; answer[198] = "hablan";
            question[199] = "They speak (male / female)"; answer[199] = "hablan";

            question[200] = "To read"; answer[200] = "leer";
            question[201] = "I read"; answer[201] = "leo";
            question[202] = "You read (Informal)"; answer[202] = "lees";
            question[203] = "You read (Formal)"; answer[203] = "lee";
            question[204] = "He reads"; answer[204] = "lee";
            question[205] = "She reads"; answer[205] = "lee";
            question[206] = "We read"; answer[206] = "leemos";
            question[207] = "You read (Inf., Plural, Spain)"; answer[207] = "leéis";
            question[208] = "You read (Formal, Plural)"; answer[208] = "leen";
            question[209] = "They read (male / female)"; answer[209] = "leen";

            question[210] = "To arrive"; answer[210] = "llegar";
            question[211] = "I arrive"; answer[211] = "llego";
            question[212] = "You arrive (Informal)"; answer[212] = "llegas";
            question[213] = "You arrive (Formal)"; answer[213] = "llega";
            question[214] = "He arrives"; answer[214] = "llega";
            question[215] = "She arrives"; answer[215] = "llega";
            question[216] = "We arrive"; answer[216] = "llegamos";
            question[217] = "You arrive (Inf., Plural, Spain)"; answer[217] = "llegáis";
            question[218] = "You arrive (Formal, Plural)"; answer[218] = "llegan";
            question[219] = "They arrive (male / female)"; answer[219] = "llegan";

            question[220] = "To look"; answer[220] = "mirar";
            question[221] = "I look"; answer[221] = "miro";
            question[222] = "You look (Informal)"; answer[222] = "miras";
            question[223] = "You look (Formal)"; answer[223] = "mira";
            question[224] = "He looks"; answer[224] = "mira";
            question[225] = "She looks"; answer[225] = "mira";
            question[226] = "We look"; answer[226] = "miramos";
            question[227] = "You look (Inf., Plural, Spain)"; answer[227] = "miráis";
            question[228] = "You look (Formal, Plural)"; answer[228] = "miran";
            question[229] = "They look (male / female)"; answer[229] = "miran";

            question[230] = "To practice"; answer[230] = "practicar";
            question[231] = "I practice"; answer[231] = "practico";
            question[232] = "You practice (Informal)"; answer[232] = "practicas";
            question[233] = "You practice (Formal)"; answer[233] = "practica";
            question[234] = "He practices"; answer[234] = "practica";
            question[235] = "She practices"; answer[235] = "practica";
            question[236] = "We practice"; answer[236] = "practicamos";
            question[237] = "You practice (Inf., Plural, Spain)"; answer[237] = "practicáis";
            question[238] = "You practice (Formal, Plural)"; answer[238] = "practican";
            question[239] = "They practice (male / female)"; answer[239] = "practican";

            question[240] = "To prepare"; answer[240] = "preparar";
            question[241] = "I prepare"; answer[241] = "preparo";
            question[242] = "You prepare (Informal)"; answer[242] = "preparas";
            question[243] = "You prepare (Formal)"; answer[243] = "prepara";
            question[244] = "He prepares"; answer[244] = "prepara";
            question[245] = "She prepares"; answer[245] = "prepara";
            question[246] = "We prepare"; answer[246] = "preparamos";
            question[247] = "You prepare (Inf., Plural, Spain)"; answer[247] = "preparáis";
            question[248] = "You prepare (Formal, Plural)"; answer[248] = "preparan";
            question[249] = "They prepare (male / female)"; answer[249] = "preparan";

            question[250] = "To receive"; answer[250] = "recibir";
            question[251] = "I receive"; answer[251] = "recibo";
            question[252] = "You receive (Informal)"; answer[252] = "recibes";
            question[253] = "You receive (Formal)"; answer[253] = "recibe";
            question[254] = "He receives"; answer[254] = "recibe";
            question[255] = "She receives"; answer[255] = "recibe";
            question[256] = "We receive"; answer[256] = "recibimos";
            question[257] = "You receive (Inf., Plural, Spain)"; answer[257] = "recibís";
            question[258] = "You receive (Formal, Plural)"; answer[258] = "reciben";
            question[259] = "They receive (male / female)"; answer[259] = "reciben";

            question[260] = "To have"; answer[260] = "tener";
            question[261] = "I have"; answer[261] = "tengo";
            question[262] = "You have (Informal)"; answer[262] = "tienes";
            question[263] = "You have (Formal)"; answer[263] = "tiene";
            question[264] = "He has"; answer[264] = "tiene";
            question[265] = "She has"; answer[265] = "tiene";
            question[266] = "We have"; answer[266] = "tenemos";
            question[267] = "You have (Inf., Plural, Spain)"; answer[267] = "tenéis";
            question[268] = "You have (Formal, Plural)"; answer[268] = "tienen";
            question[269] = "They have (male / female)"; answer[269] = "tienen";

            question[270] = "To take"; answer[270] = "tomar";
            question[271] = "I take"; answer[271] = "tomo";
            question[272] = "You take (Informal)"; answer[272] = "tomas";
            question[273] = "You take (Formal)"; answer[273] = "toma";
            question[274] = "He takes"; answer[274] = "toma";
            question[275] = "She takes"; answer[275] = "toma";
            question[276] = "We take"; answer[276] = "tomamos";
            question[277] = "You take (Inf., Plural, Spain)"; answer[277] = "tomáis";
            question[278] = "You take (Formal, Plural)"; answer[278] = "toman";
            question[279] = "They take (male / female)"; answer[279] = "toman";

            question[280] = "To work"; answer[280] = "trabajar";
            question[281] = "I work"; answer[281] = "trabajo";
            question[282] = "You work (Informal)"; answer[282] = "trabajas";
            question[283] = "You work (Formal)"; answer[283] = "trabaja";
            question[284] = "He works"; answer[284] = "trabaja";
            question[285] = "She works"; answer[285] = "trabaja";
            question[286] = "We work"; answer[286] = "trabajamos";
            question[287] = "You work (Inf., Plural, Spain)"; answer[287] = "trabajáis";
            question[288] = "You work (Formal, Plural)"; answer[288] = "trabajan";
            question[289] = "They work (male / female)"; answer[289] = "trabajan";

            question[290] = "To live"; answer[290] = "vivir";
            question[291] = "I live"; answer[291] = "vivo";
            question[292] = "You live (Informal)"; answer[292] = "vives";
            question[293] = "You live (Formal)"; answer[293] = "vive";
            question[294] = "He lives"; answer[294] = "vive";
            question[295] = "She lives"; answer[295] = "vive";
            question[296] = "We live"; answer[296] = "vivimos";
            question[297] = "You live (Inf., Plural, Spain)"; answer[297] = "vivís";
            question[298] = "You live (Formal, Plural)"; answer[298] = "viven";
            question[299] = "They live (male / female)"; answer[299] = "viven";

            question[300] = "To sell"; answer[300] = "vender";
            question[301] = "I sell"; answer[301] = "vendo";
            question[302] = "You sell (Informal)"; answer[302] = "vendes";
            question[303] = "You sell (Formal)"; answer[303] = "vende";
            question[304] = "He sells"; answer[304] = "vende";
            question[305] = "She sells"; answer[305] = "vende";
            question[306] = "We sell"; answer[306] = "vendemos";
            question[307] = "You sell (Inf., Plural, Spain)"; answer[307] = "vendéis";
            question[308] = "You sell (Formal, Plural)"; answer[308] = "venden";
            question[309] = "They sell (male / female)"; answer[309] = "venden";

            question[310] = "To watch"; answer[310] = "ver";
            question[311] = "I watch"; answer[311] = "veo";
            question[312] = "You watch (Informal)"; answer[312] = "ves";
            question[313] = "You watch (Formal)"; answer[313] = "ve";
            question[314] = "He watches"; answer[314] = "ve";
            question[315] = "She watches"; answer[315] = "ve";
            question[316] = "We watch"; answer[316] = "vemos";
            question[317] = "You watch (Inf., Plural, Spain)"; answer[317] = "veis";
            question[318] = "You watch (Formal, Plural)"; answer[318] = "ven";
            question[319] = "They watch (male / female)"; answer[319] = "ven";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch2VerbsGame()
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
