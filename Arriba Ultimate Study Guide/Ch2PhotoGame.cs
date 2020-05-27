using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch2PhotoGame
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
            numberOfQuestions = 484;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            //Adjetivos Descriptivos (Descriptive Adjectives) pg. 75
            question[0] = "Active (male)"; answer[0] = "activo";
            question[1] = "Active (female)"; answer[1] = "activa";
            question[2] = "Tall (male)"; answer[2] = "alto";
            question[3] = "Tall (female)"; answer[3] = "alta";
            question[4] = "Short (male)"; answer[4] = "bajo";
            question[5] = "Short (female)"; answer[5] = "baja";
            question[6] = "Pretty / Cute (male)"; answer[6] = "bonito";
            question[7] = "Pretty / Cute (female)"; answer[7] = "bonita";
            question[8] = "Slender (male)"; answer[8] = "delgado";
            question[9] = "Slender (female)"; answer[9] = "delgada";
            question[10] = "Enthusiastic"; answer[10] = "etusiasta";
            question[11] = "Ugly (male)"; answer[11] = "feo";
            question[12] = "Ugly (female)"; answer[12] = "fea";
            question[13] = "Skinny (male)"; answer[13] = "flaco";
            question[14] = "Skinny (female)"; answer[14] = "flaca";
            question[15] = "Fat (male)"; answer[15] = "gordo";
            question[16] = "Fat (female)"; answer[16] = "gorda";
            question[17] = "Good-looking (male)"; answer[17] = "guapo";
            question[18] = "Good-looking (female)"; answer[18] = "guapa";
            question[19] = "Young"; answer[19] = "joven";
            question[20] = "Dark skin / hair (male)"; answer[20] = "moreno";
            question[21] = "Dark skin / hair (female)"; answer[21] = "morena";
            question[22] = "New (male)"; answer[22] = "nuevo";
            question[23] = "New (female)"; answer[23] = "nueva";
            question[24] = "Poor"; answer[24] = "pobre";
            question[25] = "Rich (male)"; answer[25] = "rico";
            question[26] = "Rich (female)"; answer[26] = "rica";
            question[27] = "Blonde (male)"; answer[27] = "rubio";
            question[28] = "Blonde (female)"; answer[28] = "rubia";
            question[29] = "Old (male)"; answer[29] = "viejo";
            question[30] = "Old (female)"; answer[30] = "vieja";

            //Nacionalidades y Países (Nationalities) pg. 75
            question[31] = "Germany"; answer[31] = "alemania";
            question[32] = "German man"; answer[32] = "alemán";
            question[33] = "German woman"; answer[33] = "alemana";

            question[34] = "Brazil"; answer[34] = "brasil";
            question[35] = "Brazilian man"; answer[35] = "brasileño";
            question[36] = "Brazilian woman"; answer[36] = "brasileña";

            question[37] = "China"; answer[37] = "china";
            question[38] = "Chinese man"; answer[38] = "chino";
            question[39] = "Chinese woman"; answer[39] = "china";

            question[40] = "Korea"; answer[40] = "coreo";
            question[41] = "Korean man"; answer[41] = "coreano";
            question[42] = "Korean woman"; answer[42] = "coreana";

            question[43] = "France"; answer[43] = "francia";
            question[44] = "French man"; answer[44] = "francés";
            question[45] = "French woman"; answer[45] = "francesa";

            question[46] = "England"; answer[46] = "inglaterra";
            question[47] = "English man"; answer[47] = "inglés";
            question[48] = "English woman"; answer[48] = "inglesa";

            question[49] = "Italy"; answer[49] = "italia";
            question[50] = "Italian man"; answer[50] = "italiano";
            question[51] = "Italian woman"; answer[51] = "italiana";

            question[52] = "Japan"; answer[52] = "japón";
            question[53] = "Japanese man"; answer[53] = "japonés";
            question[54] = "Japanese woman"; answer[54] = "japonesa";

            question[55] = "Portugal"; answer[55] = "portugal";
            question[56] = "Portuguese man"; answer[56] = "portugués";
            question[57] = "Portuguese woman"; answer[57] = "portuguesa";

            question[58] = "Russia"; answer[58] = "rusia";
            question[59] = "Russian man"; answer[59] = "ruso";
            question[60] = "Russian woman"; answer[60] = "rusa";

            question[61] = "Canada"; answer[61] = "canadá";
            question[62] = "Canadian"; answer[62] = "canadiense";

            question[63] = "Argentina"; answer[63] = "argentina";
            question[64] = "Argentine man"; answer[64] = "argentino";
            question[65] = "Argentine woman"; answer[65] = "argentina";

            question[66] = "Chile"; answer[66] = "chile";
            question[67] = "Chilian man"; answer[67] = "chileno";
            question[68] = "Chilian woman"; answer[68] = "chilena";

            question[69] = "Colombia"; answer[69] = "colombia";
            question[70] = "Colombian man"; answer[70] = "colombiano";
            question[71] = "Colombian woman"; answer[71] = "colombiana";

            question[72] = "Cuba"; answer[72] = "cuba";
            question[73] = "Cuban man"; answer[73] = "cubano";
            question[74] = "Cuban woman"; answer[74] = "cubana";

            question[75] = "Dominican Republic"; answer[75] = "república dominicana";
            question[76] = "Dominican man"; answer[76] = "dominicano";
            question[77] = "Dominican woman"; answer[77] = "dominicana";

            question[78] = "Ecuador"; answer[78] = "ecuador";
            question[79] = "Ecuadorian man"; answer[79] = "ecuatoriano";
            question[80] = "Ecuadorian woman"; answer[80] = "ecuatoriana";

            question[81] = "Spain"; answer[81] = "españia";
            question[82] = "Spanish man"; answer[82] = "español";
            question[83] = "Spanish woman"; answer[83] = "española";

            question[84] = "Mexico"; answer[84] = "méxico";
            question[85] = "Mexican man"; answer[85] = "mexicano";
            question[86] = "Mexican woman"; answer[86] = "mexicana";

            question[87] = "North America"; answer[87] = "américa del norte";
            question[88] = "United States"; answer[88] = "estados unidos";
            question[89] = "U.S. Citizen"; answer[89] = "estadounidense";
            question[90] = "North American man"; answer[90] = "norteamericano";
            question[91] = "North American woman"; answer[91] = "norteamericana";

            question[92] = "Panama"; answer[92] = "panamá";
            question[93] = "Panamanian man"; answer[93] = "panameño";
            question[94] = "Panamanian woman"; answer[94] = "panameña";

            question[95] = "Peru"; answer[95] = "perú";
            question[96] = "Peruvian man"; answer[96] = "peruano";
            question[97] = "Peruvian woman"; answer[97] = "peruana";

            question[98] = "Puerto Rico"; answer[98] = "puerto rico";
            question[99] = "Puerto Rican man"; answer[99] = "puertorriqueño";
            question[100] = "Puerto Rican woman"; answer[100] = "puertorriqueña";

            question[101] = "El Salvador"; answer[101] = "el salvador";
            question[102] = "Salvadoran man"; answer[102] = "salvadoreño";
            question[103] = "Salvadoran woman"; answer[103] = "salvadoreña";

            question[104] = "Venezuela"; answer[104] = "venezuela";
            question[105] = "Venezuelan man"; answer[105] = "venezolano";
            question[106] = "Venezuelan woman"; answer[106] = "venezolana";

            question[107] = "Guatemala"; answer[107] = "guatemala";
            question[108] = "Guatemalan man"; answer[108] = "guatemalteco";
            question[109] = "Guatemalan woman"; answer[109] = "gualtemalteca";

            //Lugares (Places) pg. 75
            question[110] = "The capital city"; answer[110] = "la capital";
            question[111] = "The city"; answer[111] = "la ciudad";
            question[112] = "The country"; answer[112] = "el país";

            //Las personas (People) pg. 75
            question[113] = "The friend (male)"; answer[113] = "el amigo";
            question[114] = "The friend (female)"; answer[114] = "la amiga";
            question[115] = "The boy"; answer[115] = "el muchacho";
            question[116] = "The girl"; answer[116] = "la muchacha";
            question[117] = "The parent"; answer[117] = "el padre";
            question[118] = "The parents"; answer[118] = "los padres";

            //Adverbios (Adverbs) pg.75
            question[119] = "Now"; answer[119] = "ahora";
            question[120] = "Also"; answer[120] = "también";
            question[121] = "Late"; answer[121] = "tarde";
            question[122] = "Early"; answer[122] = "temprano";

            //Conjunciones (Conjunctions) pg. 75
            question[123] = "But"; answer[123] = "pero";
            question[124] = "Because"; answer[124] = "porque";

            //Verbos (Verbs) pg 75.
            question[125] = "To open"; answer[125] = "abrir";
            question[126] = "I open"; answer[126] = "abro";
            question[127] = "You open (Informal)"; answer[127] = "abres";
            question[128] = "You open (Formal)"; answer[128] = "abre";
            question[129] = "He opens"; answer[129] = "abre";
            question[130] = "She opens"; answer[130] = "abre";
            question[131] = "We open"; answer[131] = "abrimos";
            question[132] = "You open (Inf., Plural, Spain)"; answer[132] = "abrís";
            question[133] = "You open (Formal, Plural)"; answer[133] = "abren";
            question[134] = "They open (male / female)"; answer[134] = "abren";

            question[135] = "To attend"; answer[135] = "asistir";
            question[136] = "I attend"; answer[136] = "asisto";
            question[137] = "You attend (Informal)"; answer[137] = "asistes";
            question[138] = "You attend (Formal)"; answer[138] = "asiste";
            question[139] = "He attends"; answer[139] = "asiste";
            question[140] = "She attends"; answer[140] = "asiste";
            question[141] = "We attend"; answer[141] = "asistimos";
            question[142] = "You attend (Inf., Plural, Spain)"; answer[142] = "asistís";
            question[143] = "You attend (Formal, Plural)"; answer[143] = "asisten";
            question[144] = "They attend (male / female)"; answer[144] = "asisten";

            question[145] = "To learn"; answer[145] = "aprender";
            question[146] = "I learn"; answer[146] = "aprendo";
            question[147] = "You learn (Informal)"; answer[147] = "aprendes";
            question[148] = "You learn (Formal)"; answer[148] = "aprende";
            question[149] = "He learns"; answer[149] = "aprende";
            question[150] = "She learns"; answer[150] = "aprende";
            question[151] = "We learn"; answer[151] = "aprendemos";
            question[152] = "You learn (Inf., Plural, Spain)"; answer[152] = "aprendéis";
            question[153] = "You learn (Formal, Plural)"; answer[153] = "aprenden";
            question[154] = "They learn (male / female)"; answer[154] = "aprenden";

            question[155] = "To help"; answer[155] = "ayudar";
            question[156] = "I help"; answer[156] = "ayudo";
            question[157] = "You help (Informal)"; answer[157] = "ayudas";
            question[158] = "You help (Formal)"; answer[158] = "ayuda";
            question[159] = "He helps"; answer[159] = "ayuda";
            question[160] = "She helps"; answer[160] = "ayuda";
            question[161] = "We help"; answer[161] = "ayudamos";
            question[162] = "You help (Inf., Plural, Spain)"; answer[162] = "ayudáis";
            question[163] = "You help (Formal, Plural)"; answer[163] = "ayudan";
            question[164] = "They help (male / female)"; answer[164] = "ayudan";

            question[165] = "To dance"; answer[165] = "bailar";
            question[166] = "I dance"; answer[166] = "bailo";
            question[167] = "You dance (Informal)"; answer[167] = "bailas";
            question[168] = "You dance (Formal)"; answer[168] = "baila";
            question[169] = "He dances"; answer[169] = "baila";
            question[170] = "She dances"; answer[170] = "baila";
            question[171] = "We dance"; answer[171] = "bailamos";
            question[172] = "You dance (Inf., Plural, Spain)"; answer[172] = "bailáis";
            question[173] = "You dance (Formal, Plural)"; answer[173] = "bailan";
            question[174] = "They dance (male / female)"; answer[174] = "bailan";

            question[175] = "To drink"; answer[175] = "beber";
            question[176] = "I drink"; answer[176] = "bebo";
            question[177] = "You drink (Informal)"; answer[177] = "bebes";
            question[178] = "You drink (Formal)"; answer[178] = "bebe";
            question[179] = "He drinks"; answer[179] = "bebe";
            question[180] = "She drinks"; answer[180] = "bebe";
            question[181] = "We drink"; answer[181] = "bebemos";
            question[182] = "You drink (Inf., Plural, Spain)"; answer[182] = "bebéis";
            question[183] = "You drink (Formal, Plural)"; answer[183] = "beben";
            question[184] = "They drink (male / female)"; answer[184] = "beben";

            question[185] = "To search"; answer[185] = "buscar";
            question[186] = "I search"; answer[186] = "busco";
            question[187] = "You search (Informal)"; answer[187] = "buscas";
            question[188] = "You search (Formal)"; answer[188] = "busca";
            question[189] = "He searches"; answer[189] = "busca";
            question[190] = "She searches"; answer[190] = "busca";
            question[191] = "We search"; answer[191] = "buscamos";
            question[192] = "You search (Inf., Plural, Spain)"; answer[192] = "buscáis";
            question[193] = "You search (Formal, Plural)"; answer[193] = "buscan";
            question[194] = "They search (male / female)"; answer[194] = "buscan";

            question[195] = "To eat"; answer[195] = "comer";
            question[196] = "I eat"; answer[196] = "como";
            question[197] = "You eat (Informal)"; answer[197] = "comes";
            question[198] = "You eat (Formal)"; answer[198] = "come";
            question[199] = "He eats"; answer[199] = "come";
            question[200] = "She eats"; answer[200] = "come";
            question[201] = "We eat"; answer[201] = "comemos";
            question[202] = "You eat (Inf., Plural, Spain)"; answer[202] = "coméis";
            question[203] = "You eat (Formal, Plural)"; answer[203] = "comen";
            question[204] = "They eat (male / female)"; answer[204] = "comen";

            question[205] = "To buy"; answer[205] = "comprar";
            question[206] = "I buy"; answer[206] = "compro";
            question[207] = "You buy (Informal)"; answer[207] = "compras";
            question[208] = "You buy (Formal)"; answer[208] = "compra";
            question[209] = "He buys"; answer[209] = "compra";
            question[210] = "She buys"; answer[210] = "compra";
            question[211] = "We buy"; answer[211] = "compramos";
            question[212] = "You buy (Inf., Plural, Spain)"; answer[212] = "compráis";
            question[213] = "You buy (Formal, Plural)"; answer[213] = "compran";
            question[214] = "They buy (male / female)"; answer[214] = "compran";

            question[215] = "To understand"; answer[215] = "comprender";
            question[216] = "I understand"; answer[216] = "comprendo";
            question[217] = "You understand (Informal)"; answer[217] = "comprendes";
            question[218] = "You understand (Formal)"; answer[218] = "comprende";
            question[219] = "He understands"; answer[219] = "comprende";
            question[220] = "She understands"; answer[220] = "comprende";
            question[221] = "We understand"; answer[221] = "comprendemos";
            question[222] = "You understand (Inf., Plural, Spain)"; answer[222] = "comprendéis";
            question[223] = "You understand (Formal, Plural)"; answer[223] = "comprenden";
            question[224] = "They understand (male / female)"; answer[224] = "comprenden";

            question[225] = "To believe"; answer[225] = "creer";
            question[226] = "I believe"; answer[226] = "creo";
            question[227] = "You believe (Informal)"; answer[227] = "crees";
            question[228] = "You believe (Formal)"; answer[228] = "cree";
            question[229] = "He believes"; answer[229] = "cree";
            question[230] = "She believes"; answer[230] = "cree";
            question[231] = "We believe"; answer[231] = "creemos";
            question[232] = "You believe (Inf., Plural, Spain)"; answer[232] = "creéis";
            question[233] = "You believe (Formal, Plural)"; answer[233] = "creen";
            question[234] = "They believe (male / female)"; answer[234] = "creen";

            question[235] = "To owe"; answer[235] = "deber";
            question[236] = "I owe"; answer[236] = "debo";
            question[237] = "You owe (Informal)"; answer[237] = "debes";
            question[238] = "You owe (Formal)"; answer[238] = "debe";
            question[239] = "He owes"; answer[239] = "debe";
            question[240] = "She owes"; answer[240] = "debe";
            question[241] = "We owe"; answer[241] = "debemos";
            question[242] = "You owe (Inf., Plural, Spain)"; answer[242] = "debéis";
            question[243] = "You owe (Formal, Plural)"; answer[243] = "deben";
            question[244] = "They owe (male / female)"; answer[244] = "deben";

            question[245] = "To decide"; answer[245] = "decidir";
            question[246] = "I decide"; answer[246] = "decido";
            question[247] = "You decide (Informal)"; answer[247] = "decides";
            question[248] = "You decide (Formal)"; answer[248] = "decide";
            question[249] = "He decides"; answer[249] = "decide";
            question[250] = "She decides"; answer[250] = "decide";
            question[251] = "We decide"; answer[251] = "decidimos";
            question[252] = "You decide (Inf., Plural, Spain)"; answer[252] = "decidís";
            question[253] = "You decide (Formal, Plural)"; answer[253] = "deciden";
            question[254] = "They decide (male / female)"; answer[254] = "deciden";

            question[255] = "To wish"; answer[255] = "desear";
            question[256] = "I wish"; answer[256] = "deseo";
            question[257] = "You wish (Informal)"; answer[257] = "deseas";
            question[258] = "You wish (Formal)"; answer[258] = "desea";
            question[259] = "He wishes"; answer[259] = "desea";
            question[260] = "She wishes"; answer[260] = "desea";
            question[261] = "We wish"; answer[261] = "deseamos";
            question[262] = "You wish (Inf., Plural, Spain)"; answer[262] = "deseáis";
            question[263] = "You wish (Formal, Plural)"; answer[263] = "desean";
            question[264] = "They wish (male / female)"; answer[264] = "desean";

            question[265] = "To teach"; answer[265] = "enseñar";
            question[266] = "I teach"; answer[266] = "enseño";
            question[267] = "You teach (Informal)"; answer[267] = "enseñas";
            question[268] = "You teach (Formal)"; answer[268] = "enseña";
            question[269] = "He teaches"; answer[269] = "enseña";
            question[270] = "She teaches"; answer[270] = "enseña";
            question[271] = "We teach"; answer[271] = "enseñamos";
            question[272] = "You teach (Inf., Plural, Spain)"; answer[272] = "enseñáis";
            question[273] = "You teach (Formal, Plural)"; answer[273] = "enseñan";
            question[274] = "They teach (male / female)"; answer[274] = "enseñan";

            question[275] = "To write"; answer[275] = "escribir";
            question[276] = "I write"; answer[276] = "escribo";
            question[277] = "You write (Informal)"; answer[277] = "escribes";
            question[278] = "You write (Formal)"; answer[278] = "escribe";
            question[279] = "He writes"; answer[279] = "escribe";
            question[280] = "She writes"; answer[280] = "escribe";
            question[281] = "We write"; answer[281] = "escribimos";
            question[282] = "You write (Inf., Plural, Spain)"; answer[282] = "escribís";
            question[283] = "You write (Formal, Plural)"; answer[283] = "escriben";
            question[284] = "They write (male / female)"; answer[284] = "escriben";

            question[285] = "To listen"; answer[285] = "escuchar";
            question[286] = "I listen"; answer[286] = "escucho";
            question[287] = "You listen (Informal)"; answer[287] = "escuchas";
            question[288] = "You listen (Formal)"; answer[288] = "escucha";
            question[289] = "He listens"; answer[289] = "escucha";
            question[290] = "She listens"; answer[290] = "escucha";
            question[291] = "We listen"; answer[291] = "escuchamos";
            question[292] = "You listen (Inf., Plural, Spain)"; answer[292] = "escucháis";
            question[293] = "You listen (Formal, Plural)"; answer[293] = "escuchan";
            question[294] = "They listen (male / female)"; answer[294] = "escuchan";

            question[295] = "To travel"; answer[295] = "viajar";
            question[296] = "I travel"; answer[296] = "viajo";
            question[297] = "You travel (Informal)"; answer[297] = "viajas";
            question[298] = "You travel (Formal)"; answer[298] = "viaja";
            question[299] = "He travels"; answer[299] = "viaja";
            question[300] = "She travels"; answer[300] = "viaja";
            question[301] = "We travel"; answer[301] = "viajamos";
            question[302] = "You travel (Inf., Plural, Spain)"; answer[302] = "viajáis";
            question[303] = "You travel (Formal, Plural)"; answer[303] = "viajan";
            question[304] = "They travel (male / female)"; answer[304] = "viajan";

            question[305] = "To study"; answer[305] = "estudiar";
            question[306] = "I study"; answer[306] = "estudio";
            question[307] = "You study (Informal)"; answer[307] = "estudias";
            question[308] = "You study (Formal)"; answer[308] = "estudia";
            question[309] = "He studies"; answer[309] = "estudia";
            question[310] = "She studies"; answer[310] = "estudia";
            question[311] = "We study"; answer[311] = "estudiamos";
            question[312] = "You study (Inf., Plural, Spain)"; answer[312] = "estudiáis";
            question[313] = "You study (Formal, Plural)"; answer[313] = "estudian";
            question[314] = "They study (male / female)"; answer[314] = "estudian";

            question[315] = "To speak"; answer[315] = "hablar";
            question[316] = "I speak"; answer[316] = "hablo";
            question[317] = "You speak (Informal)"; answer[317] = "hablas";
            question[318] = "You speak (Formal)"; answer[318] = "habla";
            question[319] = "He speaks"; answer[319] = "habla";
            question[320] = "She speaks"; answer[320] = "habla";
            question[321] = "We speak"; answer[321] = "hablamos";
            question[322] = "You speak (Inf., Plural, Spain)"; answer[322] = "habláis";
            question[323] = "You speak (Formal, Plural)"; answer[323] = "hablan";
            question[324] = "They speak (male / female)"; answer[324] = "hablan";

            question[325] = "To read"; answer[325] = "leer";
            question[326] = "I read"; answer[326] = "leo";
            question[327] = "You read (Informal)"; answer[327] = "lees";
            question[328] = "You read (Formal)"; answer[328] = "lee";
            question[329] = "He reads"; answer[329] = "lee";
            question[330] = "She reads"; answer[330] = "lee";
            question[331] = "We read"; answer[331] = "leemos";
            question[332] = "You read (Inf., Plural, Spain)"; answer[332] = "leéis";
            question[333] = "You read (Formal, Plural)"; answer[333] = "leen";
            question[334] = "They read (male / female)"; answer[334] = "leen";

            question[335] = "To arrive"; answer[335] = "llegar";
            question[336] = "I arrive"; answer[336] = "llego";
            question[337] = "You arrive (Informal)"; answer[337] = "llegas";
            question[338] = "You arrive (Formal)"; answer[338] = "llega";
            question[339] = "He arrives"; answer[339] = "llega";
            question[340] = "She arrives"; answer[340] = "llega";
            question[341] = "We arrive"; answer[341] = "llegamos";
            question[342] = "You arrive (Inf., Plural, Spain)"; answer[342] = "llegáis";
            question[343] = "You arrive (Formal, Plural)"; answer[343] = "llegan";
            question[344] = "They arrive (male / female)"; answer[344] = "llegan";

            question[345] = "To look"; answer[345] = "mirar";
            question[346] = "I look"; answer[346] = "miro";
            question[347] = "You look (Informal)"; answer[347] = "miras";
            question[348] = "You look (Formal)"; answer[348] = "mira";
            question[349] = "He looks"; answer[349] = "mira";
            question[350] = "She looks"; answer[350] = "mira";
            question[351] = "We look"; answer[351] = "miramos";
            question[352] = "You look (Inf., Plural, Spain)"; answer[352] = "miráis";
            question[353] = "You look (Formal, Plural)"; answer[353] = "miran";
            question[354] = "They look (male / female)"; answer[354] = "miran";

            question[355] = "To practice"; answer[355] = "practicar";
            question[356] = "I practice"; answer[356] = "practico";
            question[357] = "You practice (Informal)"; answer[357] = "practicas";
            question[358] = "You practice (Formal)"; answer[358] = "practica";
            question[359] = "He practices"; answer[359] = "practica";
            question[360] = "She practices"; answer[360] = "practica";
            question[361] = "We practice"; answer[361] = "practicamos";
            question[362] = "You practice (Inf., Plural, Spain)"; answer[362] = "practicáis";
            question[363] = "You practice (Formal, Plural)"; answer[363] = "practican";
            question[364] = "They practice (male / female)"; answer[364] = "practican";

            question[365] = "To prepare"; answer[365] = "preparar";
            question[366] = "I prepare"; answer[366] = "preparo";
            question[367] = "You prepare (Informal)"; answer[367] = "preparas";
            question[368] = "You prepare (Formal)"; answer[368] = "prepara";
            question[369] = "He prepares"; answer[369] = "prepara";
            question[370] = "She prepares"; answer[370] = "prepara";
            question[371] = "We prepare"; answer[371] = "preparamos";
            question[372] = "You prepare (Inf., Plural, Spain)"; answer[372] = "preparáis";
            question[373] = "You prepare (Formal, Plural)"; answer[373] = "preparan";
            question[374] = "They prepare (male / female)"; answer[374] = "preparan";

            question[375] = "To receive"; answer[375] = "recibir";
            question[376] = "I receive"; answer[376] = "recibo";
            question[377] = "You receive (Informal)"; answer[377] = "recibes";
            question[378] = "You receive (Formal)"; answer[378] = "recibe";
            question[379] = "He receives"; answer[379] = "recibe";
            question[380] = "She receives"; answer[380] = "recibe";
            question[381] = "We receive"; answer[381] = "recibimos";
            question[382] = "You receive (Inf., Plural, Spain)"; answer[382] = "recibís";
            question[383] = "You receive (Formal, Plural)"; answer[383] = "reciben";
            question[384] = "They receive (male / female)"; answer[384] = "reciben";

            question[385] = "To have"; answer[385] = "tener";
            question[386] = "I have"; answer[386] = "tengo";
            question[387] = "You have (Informal)"; answer[387] = "tienes";
            question[388] = "You have (Formal)"; answer[388] = "tiene";
            question[389] = "He has"; answer[389] = "tiene";
            question[390] = "She has"; answer[390] = "tiene";
            question[391] = "We have"; answer[391] = "tenemos";
            question[392] = "You have (Inf., Plural, Spain)"; answer[392] = "tenéis";
            question[393] = "You have (Formal, Plural)"; answer[393] = "tienen";
            question[394] = "They have (male / female)"; answer[394] = "tienen";

            question[395] = "To take"; answer[395] = "tomar";
            question[396] = "I take"; answer[396] = "tomo";
            question[397] = "You take (Informal)"; answer[397] = "tomas";
            question[398] = "You take (Formal)"; answer[398] = "toma";
            question[399] = "He takes"; answer[399] = "toma";
            question[400] = "She takes"; answer[400] = "toma";
            question[401] = "We take"; answer[401] = "tomamos";
            question[402] = "You take (Inf., Plural, Spain)"; answer[402] = "tomáis";
            question[403] = "You take (Formal, Plural)"; answer[403] = "toman";
            question[404] = "They take (male / female)"; answer[404] = "toman";

            question[405] = "To work"; answer[405] = "trabajar";
            question[406] = "I work"; answer[406] = "trabajo";
            question[407] = "You work (Informal)"; answer[407] = "trabajas";
            question[408] = "You work (Formal)"; answer[408] = "trabaja";
            question[409] = "He works"; answer[409] = "trabaja";
            question[410] = "She works"; answer[410] = "trabaja";
            question[411] = "We work"; answer[411] = "trabajamos";
            question[412] = "You work (Inf., Plural, Spain)"; answer[412] = "trabajáis";
            question[413] = "You work (Formal, Plural)"; answer[413] = "trabajan";
            question[414] = "They work (male / female)"; answer[414] = "trabajan";

            question[415] = "To live"; answer[415] = "vivir";
            question[416] = "I live"; answer[416] = "vivo";
            question[417] = "You live (Informal)"; answer[417] = "vives";
            question[418] = "You live (Formal)"; answer[418] = "vive";
            question[419] = "He lives"; answer[419] = "vive";
            question[420] = "She lives"; answer[420] = "vive";
            question[421] = "We live"; answer[421] = "vivimos";
            question[422] = "You live (Inf., Plural, Spain)"; answer[422] = "vivís";
            question[423] = "You live (Formal, Plural)"; answer[423] = "viven";
            question[424] = "They live (male / female)"; answer[424] = "viven";

            question[425] = "To sell"; answer[425] = "vender";
            question[426] = "I sell"; answer[426] = "vendo";
            question[427] = "You sell (Informal)"; answer[427] = "vendes";
            question[428] = "You sell (Formal)"; answer[428] = "vende";
            question[429] = "He sells"; answer[429] = "vende";
            question[430] = "She sells"; answer[430] = "vende";
            question[431] = "We sell"; answer[431] = "vendemos";
            question[432] = "You sell (Inf., Plural, Spain)"; answer[432] = "vendéis";
            question[433] = "You sell (Formal, Plural)"; answer[433] = "venden";
            question[434] = "They sell (male / female)"; answer[434] = "venden";

            question[435] = "To watch"; answer[435] = "ver";
            question[436] = "I watch"; answer[436] = "veo";
            question[437] = "You watch (Informal)"; answer[437] = "ves";
            question[438] = "You watch (Formal)"; answer[438] = "ve";
            question[439] = "He watches"; answer[439] = "ve";
            question[440] = "She watches"; answer[440] = "ve";
            question[441] = "We watch"; answer[441] = "vemos";
            question[442] = "You watch (Inf., Plural, Spain)"; answer[442] = "veis";
            question[443] = "You watch (Formal, Plural)"; answer[443] = "ven";
            question[444] = "They watch (male / female)"; answer[444] = "ven";

            //Adjetivos (Adjectives) pg. 75
            question[445] = "Difficult"; answer[445] = "difícil";
            question[446] = "Easy"; answer[446] = "fácil";

            //Otras palabras y expressiones (Other words and expressions) pg. 75
            question[447] = "The language"; answer[447] = "la lengua";
            question[448] = "The languages"; answer[448] = "las lenguas";
            question[449] = "What do you like to do?"; answer[449] = "¿qué te gusta hacer?";
            question[450] = "I like"; answer[450] = "Me gusta";
            question[451] = "You like"; answer[451] = "Te gusta";
            question[452] = "How lucky!"; answer[452] = "¡qué suerte!";

            //Horas (Time) pg. 46
            question[453] = "What time is it?"; answer[453] = "¿qué hora es?";
            question[454] = "The noon"; answer[454] = "el mediodía";
            question[455] = "The midnight"; answer[455] = "la medianoche";
            question[456] = "It's noon"; answer[456] = "es mediodía";
            question[457] = "It's midnight"; answer[457] = "es medianoche";
            question[458] = "Until (an hour)"; answer[458] = "menos";
            question[459] = "Half (past an hour)"; answer[459] = "media";
            question[460] = "(Hour) on the dot / sharp"; answer[460] = "en punto";
            question[460] = "(Hour) in the morning"; answer[460] = "de la mañana";
            question[461] = "(Hour) in the afternoon"; answer[461] = "de la tarde";
            question[462] = "(Hour) in the evening"; answer[462] = "de la noche";
            question[460] = "(Situation) in the morning"; answer[460] = "por la mañana";
            question[461] = "(Situation) in the afternoon"; answer[461] = "por la tarde";
            question[462] = "(Situation) in the evening"; answer[462] = "por la noche";
            question[463] = "What time (does event take place)?"; answer[463] = "¿a qué hora?";
            question[464] = "It's one o clock"; answer[464] = "es la una";
            question[465] = "It's (hour) o clock"; answer[465] = "son las";

            //Palabras Interrogativas (Interrogative Words) pg. 52
            question[466] = "How"; answer[466] = "cómo";
            question[467] = "Which one"; answer[467] = "cuál";
            question[468] = "Which ones"; answer[468] = "cuáles";
            question[469] = "When"; answer[469] = "cuándo";
            question[470] = "How many (male, singular)"; answer[470] = "cuánto";
            question[471] = "How many (female, singular)"; answer[471] = "cuánta";
            question[472] = "How many (male, plural)"; answer[472] = "cuántos";
            question[473] = "How many (female, plural)"; answer[473] = "cuántas";
            question[474] = "Where"; answer[474] = "dónde";
            question[475] = "From where"; answer[475] = "de dónde";
            question[476] = "To where"; answer[476] = "adónde";
            question[477] = "Why"; answer[477] = "por qué";
            question[478] = "What"; answer[478] = "qué";
            question[479] = "Who (singular)"; answer[479] = "quién";
            question[480] = "Who (plural)"; answer[480] = "quiénes";
            question[481] = "Whose (singular)"; answer[481] = "de quién";
            question[482] = "Whose (plural)"; answer[482] = "de quiénes";

            //Bonus words
            question[483] = "Right now"; answer[483] = "ahora mismo";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch2PhotoGame()
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
