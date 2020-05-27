using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch4TranslationGame
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
            numberOfQuestions = 387;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            question[0] = "The grandfather"; answer[0] = "el abuelo";
            question[1] = "The grandmother"; answer[1] = "la abuela";
            question[2] = "The brother-in-law"; answer[2] = "el cuñado";
            question[3] = "The sister-in-law"; answer[3] = "la cuñada";
            question[4] = "The husband"; answer[4] = "el esposo";
            question[5] = "The wife"; answer[5] = "la esposa";
            question[6] = "The stepbrother"; answer[6] = "el hermanastro";
            question[7] = "The stepsister"; answer[7] = "la hermanastra";
            question[8] = "The brother"; answer[8] = "el hermano";
            question[9] = "The sister"; answer[9] = "la hermana";
            question[10] = "The son"; answer[10] = "el hijo";
            question[11] = "The daughter"; answer[11] = "la hija";
            question[12] = "The stepmother"; answer[12] = "la madrastra";
            question[13] = "The mother"; answer[13] = "la madre";
            question[14] = "The grandson"; answer[14] = "el nieto";
            question[15] = "The granddaughter"; answer[15] = "la nieta";
            question[16] = "The boyfriend"; answer[16] = "el novio";
            question[17] = "The girlfriend"; answer[17] = "la novia";
            question[18] = "The daughter-in-law"; answer[18] = "la nuera";
            question[19] = "The stepfather"; answer[19] = "el padrastro";
            question[20] = "The father"; answer[20] = "el padre";
            question[21] = "The dog (male)"; answer[21] = "el perro";
            question[22] = "The dog (female)"; answer[22] = "la perra";
            question[23] = "The cousin (male)"; answer[23] = "el primo";
            question[24] = "The cousin (female)"; answer[24] = "la prima";
            question[25] = "The nephew"; answer[25] = "el sobrino";
            question[26] = "The niece"; answer[26] = "la sobrina";
            question[27] = "The father-in-law"; answer[27] = "el suegro";
            question[28] = "The mother-in-law"; answer[28] = "la suegra";
            question[29] = "The uncle"; answer[29] = "el tío";
            question[30] = "The aunt"; answer[30] = "la tía";
            question[31] = "The son-in-law"; answer[31] = "el yerno";

            question[32] = "To have lunch"; answer[32] = "almorzar";
            question[33] = "I have lunch"; answer[33] = "almuerzo";
            question[34] = "You have lunch (Informal)"; answer[34] = "almuerzas";
            question[35] = "You have lunch (Formal)"; answer[35] = "almuerza";
            question[36] = "He has lunch"; answer[36] = "almuerza";
            question[37] = "She has lunch"; answer[37] = "almuerza";
            question[38] = "We have lunch"; answer[38] = "almorzamos";
            question[39] = "You have lunch (Inf., Plural, Spain)"; answer[39] = "almorzáis";
            question[40] = "You have lunch (Formal, Plural)"; answer[40] = "almuerzan";
            question[41] = "They have lunch"; answer[41] = "almuerzan";

            question[42] = "To cost"; answer[42] = "costar";
            question[43] = "I cost"; answer[43] = "cuesto";
            question[44] = "You cost (Informal)"; answer[44] = "cuestas";
            question[45] = "You cost (Formal)"; answer[45] = "cuesta";
            question[46] = "He costs"; answer[46] = "cuesta";
            question[47] = "She costs"; answer[47] = "cuesta";
            question[48] = "We cost"; answer[48] = "costamos";
            question[49] = "You cost (Inf., Plural, Spain)"; answer[49] = "costáis";
            question[50] = "You cost (Formal, Plural)"; answer[50] = "cuestan";
            question[51] = "They cost"; answer[51] = "cuestan";

            question[52] = "To sleep"; answer[52] = "dormir";
            question[53] = "I sleep"; answer[53] = "duermo";
            question[54] = "You sleep (Informal)"; answer[54] = "duermes";
            question[55] = "You sleep (Formal)"; answer[55] = "duerme";
            question[56] = "He sleeps"; answer[56] = "duerme";
            question[57] = "She sleeps"; answer[57] = "duerme";
            question[58] = "We sleep"; answer[58] = "dormimos";
            question[59] = "You sleep (Inf., Plural, Spain)"; answer[59] = "dormís";
            question[60] = "You sleep (Formal, Plural)"; answer[60] = "duermen";
            question[61] = "They sleep"; answer[61] = "duermen";

            question[62] = "To begin"; answer[62] = "empezar";
            question[63] = "I begin"; answer[63] = "empiezo";
            question[64] = "You begin (Informal)"; answer[64] = "empiezas";
            question[65] = "You begin (Formal)"; answer[65] = "empieza";
            question[66] = "He begins"; answer[66] = "empieza";
            question[67] = "She begins"; answer[67] = "empieza";
            question[68] = "We begin"; answer[68] = "empezamos";
            question[69] = "You begin (Inf., Plural, Spain)"; answer[69] = "empezáis";
            question[70] = "You begin (Formal, Plural)"; answer[70] = "empiezan";
            question[71] = "They begin"; answer[71] = "empiezan";

            question[72] = "To find"; answer[72] = "encontrar";
            question[73] = "I find"; answer[73] = "encuentro";
            question[74] = "You find (Informal)"; answer[74] = "encuentras";
            question[75] = "You find (Formal)"; answer[75] = "encuentra";
            question[76] = "He finds"; answer[76] = "encuentra";
            question[77] = "She finds"; answer[77] = "encuentra";
            question[78] = "We find"; answer[78] = "encontramos";
            question[79] = "You find (Inf., Plural, Spain)"; answer[79] = "encontráis";
            question[80] = "You find (Formal, Plural)"; answer[80] = "encuentran";
            question[81] = "They find"; answer[81] = "encuentran";

            question[82] = "To understand"; answer[82] = "entender";
            question[83] = "I understand"; answer[83] = "entiendo";
            question[84] = "You understand (Informal)"; answer[84] = "entiendes";
            question[85] = "You understand (Formal)"; answer[85] = "entiende";
            question[86] = "He understands"; answer[86] = "entiende";
            question[87] = "She understands"; answer[87] = "entiende";
            question[88] = "We understand"; answer[88] = "entendemos";
            question[89] = "You understand (Inf., Plural, Spain)"; answer[89] = "entendéis";
            question[90] = "You understand (Formal, Plural)"; answer[90] = "entienden";
            question[91] = "They understand"; answer[91] = "entienden";

            question[92] = "To earn / win"; answer[92] = "ganar";
            question[93] = "I earn / win"; answer[93] = "gano";
            question[94] = "You earn / win (Informal)"; answer[94] = "ganas";
            question[95] = "You earn / win (Formal)"; answer[95] = "gana";
            question[96] = "He earns / wins"; answer[96] = "gana";
            question[97] = "She earns / wins"; answer[97] = "gana";
            question[98] = "We earn / win"; answer[98] = "ganamos";
            question[99] = "You earn / win (Inf., Plural, Spain)"; answer[99] = "ganáis";
            question[100] = "You earn / win (Formal, Plural)"; answer[100] = "ganan";
            question[101] = "They earn / win"; answer[101] = "ganan";

            question[102] = "To play"; answer[102] = "jugar";
            question[103] = "I play"; answer[103] = "juego";
            question[104] = "You play (Informal)"; answer[104] = "juegas";
            question[105] = "You play (Formal)"; answer[105] = "juega";
            question[106] = "He plays"; answer[106] = "juega";
            question[107] = "She plays"; answer[107] = "juega";
            question[108] = "We play"; answer[108] = "jugamos";
            question[109] = "You play (Inf., Plural, Spain)"; answer[109] = "jugáis";
            question[110] = "You play (Formal, Plural)"; answer[110] = "juegan";
            question[111] = "They play"; answer[111] = "juegan";

            question[112] = "To spend time"; answer[112] = "pasar";
            question[113] = "I spend time"; answer[113] = "paso";
            question[114] = "You spend time (Informal)"; answer[114] = "pasas";
            question[115] = "You spend time (Formal)"; answer[115] = "pasa";
            question[116] = "He spends time"; answer[116] = "pasa";
            question[117] = "She spends time"; answer[117] = "pasa";
            question[118] = "We spend time"; answer[118] = "pasamos";
            question[119] = "You spend time (Inf., Plural, Spain)"; answer[119] = "pasáis";
            question[120] = "You spend time (Formal, Plural)"; answer[120] = "pasan";
            question[121] = "They spend time"; answer[121] = "pasan";

            question[122] = "To think about"; answer[122] = "pensar";
            question[123] = "I think about"; answer[123] = "pienso";
            question[124] = "You think about (Informal)"; answer[124] = "piensas";
            question[125] = "You think about (Formal)"; answer[125] = "piensa";
            question[126] = "He thinks about"; answer[126] = "piensa";
            question[127] = "She thinks about"; answer[127] = "piensa";
            question[128] = "We think about"; answer[128] = "pensamos";
            question[129] = "You think about (Inf., Plural, Spain)"; answer[129] = "pensáis";
            question[130] = "You think about (Formal, Plural)"; answer[130] = "piensan";
            question[131] = "They think about"; answer[131] = "piensan";

            question[132] = "To request"; answer[132] = "pedir";
            question[133] = "I request"; answer[133] = "pido";
            question[134] = "You request (Informal)"; answer[134] = "pides";
            question[135] = "You request (Formal)"; answer[135] = "pide";
            question[136] = "He requests"; answer[136] = "pide";
            question[137] = "She requests"; answer[137] = "pide";
            question[138] = "We request"; answer[138] = "pedimos";
            question[139] = "You request (Inf., Plural, Spain)"; answer[139] = "pedís";
            question[140] = "You request (Formal, Plural)"; answer[140] = "piden";
            question[141] = "They request"; answer[141] = "piden";

            question[142] = "To lose"; answer[142] = "perder";
            question[143] = "I lose"; answer[143] = "pierdo";
            question[144] = "You lose (Informal)"; answer[144] = "pierdes";
            question[145] = "You lose (Formal)"; answer[145] = "pierde";
            question[146] = "He loses"; answer[146] = "pierde";
            question[147] = "She loses"; answer[147] = "pierde";
            question[148] = "We lose"; answer[148] = "perdemos";
            question[149] = "You lose (Inf., Plural, Spain)"; answer[149] = "perdéis";
            question[150] = "You lose (Formal, Plural)"; answer[150] = "pierden";
            question[151] = "They lose"; answer[151] = "pierden";

            question[152] = "To can"; answer[152] = "poder";
            question[153] = "I can"; answer[153] = "puedo";
            question[154] = "You can (Informal)"; answer[154] = "puedes";
            question[155] = "You can (Formal)"; answer[155] = "puede";
            question[156] = "He can"; answer[156] = "puede";
            question[157] = "She can"; answer[157] = "puede";
            question[158] = "We can"; answer[158] = "podemos";
            question[159] = "You can (Inf., Plural, Spain)"; answer[159] = "podéis";
            question[160] = "You can (Formal, Plural)"; answer[160] = "pueden";
            question[161] = "They can"; answer[161] = "pueden";

            question[162] = "To prefer"; answer[162] = "preferir";
            question[163] = "I prefer"; answer[163] = "prefiero";
            question[164] = "You prefer (Informal)"; answer[164] = "prefieres";
            question[165] = "You prefer (Formal)"; answer[165] = "prefiere";
            question[166] = "He prefers"; answer[166] = "prefiere";
            question[167] = "She prefers"; answer[167] = "prefiere";
            question[168] = "We prefer"; answer[168] = "preferimos";
            question[169] = "You prefer (Inf., Plural, Spain)"; answer[169] = "preferís";
            question[170] = "You prefer (Formal, Plural)"; answer[170] = "prefieren";
            question[171] = "They prefer"; answer[171] = "prefieren";

            question[172] = "To want"; answer[172] = "querer";
            question[173] = "I want"; answer[173] = "quiero";
            question[174] = "You want (Informal)"; answer[174] = "quieres";
            question[175] = "You want (Formal)"; answer[175] = "quiere";
            question[176] = "He wants"; answer[176] = "quiere";
            question[177] = "She wants"; answer[177] = "quiere";
            question[178] = "We want"; answer[178] = "queremos";
            question[179] = "You want (Inf., Plural, Spain)"; answer[179] = "queréis";
            question[180] = "You want (Formal, Plural)"; answer[180] = "quieren";
            question[181] = "They want"; answer[181] = "quieren";

            question[182] = "To remember"; answer[182] = "recordar";
            question[183] = "I remember"; answer[183] = "recuerdo";
            question[184] = "You remember (Informal)"; answer[184] = "recuerdas";
            question[185] = "You remember (Formal)"; answer[185] = "recuerda";
            question[186] = "He remembers"; answer[186] = "recuerda";
            question[187] = "She remembers"; answer[187] = "recuerda";
            question[188] = "We remember"; answer[188] = "recordamos";
            question[189] = "You remember (Inf., Plural, Spain)"; answer[189] = "recordáis";
            question[190] = "You remember (Formal, Plural)"; answer[190] = "recuerdan";
            question[191] = "They remember"; answer[191] = "recuerdan";

            question[192] = "To repeat"; answer[192] = "repetir";
            question[193] = "I repeat"; answer[193] = "repito";
            question[194] = "You repeat (Informal)"; answer[194] = "repites";
            question[195] = "You repeat (Formal)"; answer[195] = "repite";
            question[196] = "He repeats"; answer[196] = "repite";
            question[197] = "She repeats"; answer[197] = "repite";
            question[198] = "We repeat"; answer[198] = "repetimos";
            question[199] = "You repeat (Inf., Plural, Spain)"; answer[199] = "repetís";
            question[200] = "You repeat (Formal, Plural)"; answer[200] = "repiten";
            question[201] = "They repeat"; answer[201] = "repiten";

            question[202] = "To serve"; answer[202] = "servir";
            question[203] = "I serve"; answer[203] = "sirvo";
            question[204] = "You serve (Informal)"; answer[204] = "sirves";
            question[205] = "You serve (Formal)"; answer[205] = "sirve";
            question[206] = "He serves"; answer[206] = "sirve";
            question[207] = "She serves"; answer[207] = "sirve";
            question[208] = "We serve"; answer[208] = "servimos";
            question[209] = "You serve (Inf., Plural, Spain)"; answer[209] = "servís";
            question[210] = "You serve (Formal, Plural)"; answer[210] = "sirven";
            question[211] = "They serve"; answer[211] = "sirven";

            question[212] = "To dream about"; answer[212] = "soñar";
            question[213] = "I dream about"; answer[213] = "sueño";
            question[214] = "You dream about (Informal)"; answer[214] = "sueñas";
            question[215] = "You dream about (Formal)"; answer[215] = "sueña";
            question[216] = "He dreams about"; answer[216] = "sueña";
            question[217] = "She dreams about"; answer[217] = "sueña";
            question[218] = "We dream about"; answer[218] = "soñamos";
            question[219] = "You dream about (Inf., Plural, Spain)"; answer[219] = "soñáis";
            question[220] = "You dream about (Formal, Plural)"; answer[220] = "sueñan";
            question[221] = "They dream about"; answer[221] = "sueñan";

            question[222] = "To come"; answer[222] = "venir";
            question[223] = "I come"; answer[223] = "vengo";
            question[224] = "You come (Informal)"; answer[224] = "vienes";
            question[225] = "You come (Formal)"; answer[225] = "viene";
            question[226] = "He comes"; answer[226] = "viene";
            question[227] = "She comes"; answer[227] = "viene";
            question[228] = "We come"; answer[228] = "venimos";
            question[229] = "You come (Inf., Plural, Spain)"; answer[229] = "venís";
            question[230] = "You come (Formal, Plural)"; answer[230] = "vienen";
            question[231] = "They come"; answer[231] = "vienen";

            question[232] = "To return"; answer[232] = "volver";
            question[233] = "I return"; answer[233] = "vuelvo";
            question[234] = "You return (Informal)"; answer[234] = "vuelves";
            question[235] = "You return (Formal)"; answer[235] = "vuelve";
            question[236] = "He returns"; answer[236] = "vuelve";
            question[237] = "She returns"; answer[237] = "vuelve";
            question[238] = "We return"; answer[238] = "volvemos";
            question[239] = "You return (Inf., Plural, Spain)"; answer[239] = "volvéis";
            question[240] = "You return (Formal, Plural)"; answer[240] = "vuelven";
            question[241] = "They return"; answer[241] = "vuelven";

            question[242] = "To know (Someone)"; answer[242] = "conocer";
            question[243] = "I know (Someone)"; answer[243] = "conozco";
            question[244] = "You know (Informal, Someone)"; answer[244] = "conoces";
            question[245] = "You know (Formal, Someone)"; answer[245] = "conoce";
            question[246] = "He knows (Someone)"; answer[246] = "conoce";
            question[247] = "She knows (Someone)"; answer[247] = "conoce";
            question[248] = "We know (Someone)"; answer[248] = "conocemos";
            question[249] = "You know (Inf., Plural, Spain, Someone)"; answer[249] = "conocéis";
            question[250] = "You know (Formal, Plural, Someone)"; answer[250] = "conocen";
            question[251] = "They know (Someone)"; answer[251] = "conocen";

            question[252] = "To invite"; answer[252] = "invitar";
            question[253] = "I invite"; answer[253] = "invito";
            question[254] = "You invite (Informal)"; answer[254] = "invitas";
            question[255] = "You invite (Formal)"; answer[255] = "invita";
            question[256] = "He invites"; answer[256] = "invita";
            question[257] = "She invites"; answer[257] = "invita";
            question[258] = "We invite"; answer[258] = "invitamos";
            question[259] = "You invite (Inf., Plural, Spain)"; answer[259] = "invitáis";
            question[260] = "You invite (Formal, Plural)"; answer[260] = "invitan";
            question[261] = "They invite"; answer[261] = "invitan";

            question[262] = "To take a walk"; answer[262] = "pasear";
            question[263] = "I take a walk"; answer[263] = "paseo";
            question[264] = "You take a walk (Informal)"; answer[264] = "paseas";
            question[265] = "You take a walk (Formal)"; answer[265] = "pasea";
            question[266] = "He takes a walk"; answer[266] = "pasea";
            question[267] = "She takes a walk"; answer[267] = "pasea";
            question[268] = "We take a walk"; answer[268] = "paseamos";
            question[269] = "You take a walk (Inf., Plural, Spain)"; answer[269] = "paseáis";
            question[270] = "You take a walk (Formal, Plural)"; answer[270] = "pasean";
            question[271] = "They take a walk"; answer[271] = "pasean";

            question[272] = "To put"; answer[272] = "poner";
            question[273] = "I put"; answer[273] = "pongo";
            question[274] = "You put (Informal)"; answer[274] = "pones";
            question[275] = "You put (Formal)"; answer[275] = "pone";
            question[276] = "He puts"; answer[276] = "pone";
            question[277] = "She puts"; answer[277] = "pone";
            question[278] = "We put"; answer[278] = "ponemos";
            question[279] = "You put (Inf., Plural, Spain)"; answer[279] = "ponéis";
            question[280] = "You put (Formal, Plural)"; answer[280] = "ponen";
            question[281] = "They put"; answer[281] = "ponen";

            question[282] = "To know (Something)"; answer[282] = "saber";
            question[283] = "I know (Something)"; answer[283] = "sé";
            question[284] = "You know (Informal, Something)"; answer[284] = "sabes";
            question[285] = "You know (Formal, Something)"; answer[285] = "sabe";
            question[286] = "He knows (Something)"; answer[286] = "sabe";
            question[287] = "She knows (Something)"; answer[287] = "sabe";
            question[288] = "We know (Something)"; answer[288] = "sabemos";
            question[289] = "You know (Inf., Plural, Spain, Something)"; answer[289] = "sabéis";
            question[290] = "You know (Formal, Plural, Something)"; answer[290] = "saben";
            question[291] = "They know (Something)"; answer[291] = "saben";

            question[292] = "To leave"; answer[292] = "salir";
            question[293] = "I leave"; answer[293] = "salgo";
            question[294] = "You leave (Informal)"; answer[294] = "sales";
            question[295] = "You leave (Formal)"; answer[295] = "sale";
            question[296] = "He leaves"; answer[296] = "sale";
            question[297] = "She leaves"; answer[297] = "sale";
            question[298] = "We leave"; answer[298] = "salimos";
            question[299] = "You leave (Inf., Plural, Spain)"; answer[299] = "salís";
            question[300] = "You leave (Formal, Plural)"; answer[300] = "salen";
            question[301] = "They leave"; answer[301] = "salen";

            question[302] = "To play an instrument"; answer[302] = "tocar";
            question[303] = "I play an instrument"; answer[303] = "toco";
            question[304] = "You play an instrument (Informal)"; answer[304] = "tocas";
            question[305] = "You play an instrument (Formal)"; answer[305] = "toca";
            question[306] = "He plays an instrument"; answer[306] = "toca";
            question[307] = "She plays an instrument"; answer[307] = "toca";
            question[308] = "We play an instrument"; answer[308] = "tocamos";
            question[309] = "You play an instrument (Inf., Plural, Spain)"; answer[309] = "tocáis";
            question[310] = "You play an instrument (Formal, Plural)"; answer[310] = "tocan";
            question[311] = "They play an instrument"; answer[311] = "tocan";

            question[312] = "To bring"; answer[312] = "traer";
            question[313] = "I bring"; answer[313] = "traigo";
            question[314] = "You bring (Informal)"; answer[314] = "traes";
            question[315] = "You bring (Formal)"; answer[315] = "trae";
            question[316] = "He brings"; answer[316] = "trae";
            question[317] = "She brings"; answer[317] = "trae";
            question[318] = "We bring"; answer[318] = "traemos";
            question[319] = "You bring (Inf., Plural, Spain)"; answer[319] = "traéis";
            question[320] = "You bring (Formal, Plural)"; answer[320] = "traen";
            question[321] = "They bring"; answer[321] = "traen";

            question[322] = "Married (male)"; answer[322] = "casado";
            question[323] = "Married (female)"; answer[323] = "casada";
            question[324] = "Divorced (male)"; answer[324] = "divorciado";
            question[325] = "Divorced (female)"; answer[325] = "divorciada";
            question[326] = "Older"; answer[326] = "mayor";
            question[327] = "Younger"; answer[327] = "menor";
            question[328] = "Single (male)"; answer[328] = "soltero";
            question[329] = "Single (female)"; answer[329] = "soltera";
            question[330] = "Close (male)"; answer[330] = "unido";
            question[331] = "Close (female)"; answer[331] = "unida";

            question[332] = "Someday"; answer[332] = "algún día";
            question[333] = "The food"; answer[333] = "la comida";
            question[334] = "With me"; answer[334] = "conmigo";
            question[335] = "With you"; answer[335] = "contigo";
            question[336] = "The soft drink"; answer[336] = "el refresco";

            question[337] = "The cafe"; answer[337] = "el café";
            question[338] = "The outdoor cafe"; answer[338] = "el café al aire libre";
            question[339] = "The downtown"; answer[339] = "el centro";
            question[340] = "The movie theater"; answer[340] = "el cine";
            question[341] = "The concert"; answer[341] = "el concierto";
            question[342] = "The admission ticket"; answer[342] = "la entrada";
            question[343] = "The show"; answer[343] = "la función";
            question[344] = "The orchestra"; answer[344] = "la orquesta";
            question[345] = "The park"; answer[345] = "el parque";
            question[346] = "The game"; answer[346] = "el partido";
            question[347] = "The movie"; answer[347] = "la película";

            question[348] = "How about...?"; answer[348] = "¿qué tal si...?";
            question[349] = "Do you want to go to...?"; answer[349] = "¿quieres ir a...?";
            question[350] = "Would you like...?"; answer[350] = "¿te gustaría...?";
            question[351] = "Should we go...?"; answer[351] = "¿vamos a...?";

            question[352] = "Fine with me"; answer[352] = "de acuerdo";
            question[353] = "I would love to"; answer[353] = "me encantaría";
            question[354] = "I'll pick you up"; answer[354] = "paso por ti";
            question[355] = "Yes, of course"; answer[355] = "sí, claro";

            question[356] = "I'm very busy (male)"; answer[356] = "estoy muy ocupado";
            question[357] = "I'm very busy (female)"; answer[357] = "estoy muy ocupada";
            question[358] = "Thanks, but I can't"; answer[358] = "gracias, pero no puedo";
            question[359] = "I'm sorry, I have to..."; answer[359] = "lo siento, tengo que...";

            question[360] = "Me (direct object pronoun)"; answer[360] = "me";
            question[361] = "You (Inf., direct object pronoun)"; answer[361] = "te";
            question[362] = "You (Formal, male, direct object pronoun)"; answer[362] = "lo";
            question[363] = "You (Formal, female, direct object pronoun)"; answer[363] = "la";
            question[364] = "Him (direct object pronoun)"; answer[364] = "lo";
            question[365] = "Her (direct object pronoun)"; answer[365] = "la";
            question[366] = "Us (direct object pronoun)"; answer[366] = "nos";
            question[367] = "You (Inf., Plural, Spain, direct object pronoun)"; answer[367] = "os";
            question[368] = "You (Formal, male, Plural, direct object pronoun)"; answer[368] = "los";
            question[369] = "You (Formal, female, Plural, direct object pronoun)"; answer[369] = "las";
            question[370] = "Them (male, direct object pronoun)"; answer[370] = "los";
            question[371] = "Them (male, direct object pronoun)"; answer[371] = "las";

            question[372] = "this (male)"; answer[372] = "este";
            question[373] = "this (female)"; answer[373] = "esta";
            question[374] = "that (close to, male)"; answer[374] = "ese";
            question[375] = "that (close to, female)"; answer[375] = "esa";
            question[376] = "that (over there, male)"; answer[376] = "aquel";
            question[377] = "that (over there, female)"; answer[377] = "aquella";
            question[378] = "these (male)"; answer[378] = "estos";
            question[379] = "these (female)"; answer[379] = "estas";
            question[380] = "those (close to, male)"; answer[380] = "esos";
            question[381] = "those (close to, female)"; answer[381] = "esas";
            question[382] = "those (over there, male)"; answer[382] = "aquellos";
            question[383] = "those (over there, female)"; answer[383] = "aquellas";
            question[384] = "here"; answer[384] = "aquí";
            question[385] = "there"; answer[385] = "allí";
            question[386] = "over there"; answer[386] = "allá";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch4TranslationGame()
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
