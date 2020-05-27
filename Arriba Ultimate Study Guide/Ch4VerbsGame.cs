using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch4VerbsGame
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
            numberOfQuestions = 290;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            question[0] = "To have lunch"; answer[0] = "almorzar";
            question[1] = "I have lunch"; answer[1] = "almuerzo";
            question[2] = "You have lunch (Informal)"; answer[2] = "almuerzas";
            question[3] = "You have lunch (Formal)"; answer[3] = "almuerza";
            question[4] = "He has lunch"; answer[4] = "almuerza";
            question[5] = "She has lunch"; answer[5] = "almuerza";
            question[6] = "We have lunch"; answer[6] = "almorzamos";
            question[7] = "You have lunch (Inf., Plural, Spain)"; answer[7] = "almorzáis";
            question[8] = "You have lunch (Formal, Plural)"; answer[8] = "almuerzan";
            question[9] = "They have lunch"; answer[9] = "almuerzan";

            question[10] = "To cost"; answer[10] = "costar";
            question[11] = "I cost"; answer[11] = "cuesto";
            question[12] = "You cost (Informal)"; answer[12] = "cuestas";
            question[13] = "You cost (Formal)"; answer[13] = "cuesta";
            question[14] = "He costs"; answer[14] = "cuesta";
            question[15] = "She costs"; answer[15] = "cuesta";
            question[16] = "We cost"; answer[16] = "costamos";
            question[17] = "You cost (Inf., Plural, Spain)"; answer[17] = "costáis";
            question[18] = "You cost (Formal, Plural)"; answer[18] = "cuestan";
            question[19] = "They cost"; answer[19] = "cuestan";

            question[20] = "To sleep"; answer[20] = "dormir";
            question[21] = "I sleep"; answer[21] = "duermo";
            question[22] = "You sleep (Informal)"; answer[22] = "duermes";
            question[23] = "You sleep (Formal)"; answer[23] = "duerme";
            question[24] = "He sleeps"; answer[24] = "duerme";
            question[25] = "She sleeps"; answer[25] = "duerme";
            question[26] = "We sleep"; answer[26] = "dormimos";
            question[27] = "You sleep (Inf., Plural, Spain)"; answer[27] = "dormís";
            question[28] = "You sleep (Formal, Plural)"; answer[28] = "duermen";
            question[29] = "They sleep"; answer[29] = "duermen";

            question[30] = "To begin"; answer[30] = "empezar";
            question[31] = "I begin"; answer[31] = "empiezo";
            question[32] = "You begin (Informal)"; answer[32] = "empiezas";
            question[33] = "You begin (Formal)"; answer[33] = "empieza";
            question[34] = "He begins"; answer[34] = "empieza";
            question[35] = "She begins"; answer[35] = "empieza";
            question[36] = "We begin"; answer[36] = "empezamos";
            question[37] = "You begin (Inf., Plural, Spain)"; answer[37] = "empezáis";
            question[38] = "You begin (Formal, Plural)"; answer[38] = "empiezan";
            question[39] = "They begin"; answer[39] = "empiezan";

            question[40] = "To find"; answer[40] = "encontrar";
            question[41] = "I find"; answer[41] = "encuentro";
            question[42] = "You find (Informal)"; answer[42] = "encuentras";
            question[43] = "You find (Formal)"; answer[43] = "encuentra";
            question[44] = "He finds"; answer[44] = "encuentra";
            question[45] = "She finds"; answer[45] = "encuentra";
            question[46] = "We find"; answer[46] = "encontramos";
            question[47] = "You find (Inf., Plural, Spain)"; answer[47] = "encontráis";
            question[48] = "You find (Formal, Plural)"; answer[48] = "encuentran";
            question[49] = "They find"; answer[49] = "encuentran";

            question[50] = "To understand"; answer[50] = "entender";
            question[51] = "I understand"; answer[51] = "entiendo";
            question[52] = "You understand (Informal)"; answer[52] = "entiendes";
            question[53] = "You understand (Formal)"; answer[53] = "entiende";
            question[54] = "He understands"; answer[54] = "entiende";
            question[55] = "She understands"; answer[55] = "entiende";
            question[56] = "We understand"; answer[56] = "entendemos";
            question[57] = "You understand (Inf., Plural, Spain)"; answer[57] = "entendéis";
            question[58] = "You understand (Formal, Plural)"; answer[58] = "entienden";
            question[59] = "They understand"; answer[59] = "entienden";

            question[60] = "To earn / win"; answer[60] = "ganar";
            question[61] = "I earn / win"; answer[61] = "gano";
            question[62] = "You earn / win (Informal)"; answer[62] = "ganas";
            question[63] = "You earn / win (Formal)"; answer[63] = "gana";
            question[64] = "He earns / wins"; answer[64] = "gana";
            question[65] = "She earns / wins"; answer[65] = "gana";
            question[66] = "We earn / win"; answer[66] = "ganamos";
            question[67] = "You earn / win (Inf., Plural, Spain)"; answer[67] = "ganáis";
            question[68] = "You earn / win (Formal, Plural)"; answer[68] = "ganan";
            question[69] = "They earn / win"; answer[69] = "ganan";

            question[70] = "To play"; answer[70] = "jugar";
            question[71] = "I play"; answer[71] = "juego";
            question[72] = "You play (Informal)"; answer[72] = "juegas";
            question[73] = "You play (Formal)"; answer[73] = "juega";
            question[74] = "He plays"; answer[74] = "juega";
            question[75] = "She plays"; answer[75] = "juega";
            question[76] = "We play"; answer[76] = "jugamos";
            question[77] = "You play (Inf., Plural, Spain)"; answer[77] = "jugáis";
            question[78] = "You play (Formal, Plural)"; answer[78] = "juegan";
            question[79] = "They play"; answer[79] = "juegan";

            question[80] = "To spend time"; answer[80] = "pasar";
            question[81] = "I spend time"; answer[81] = "paso";
            question[82] = "You spend time (Informal)"; answer[82] = "pasas";
            question[83] = "You spend time (Formal)"; answer[83] = "pasa";
            question[84] = "He spends time"; answer[84] = "pasa";
            question[85] = "She spends time"; answer[85] = "pasa";
            question[86] = "We spend time"; answer[86] = "pasamos";
            question[87] = "You spend time (Inf., Plural, Spain)"; answer[87] = "pasáis";
            question[88] = "You spend time (Formal, Plural)"; answer[88] = "pasan";
            question[89] = "They spend time"; answer[89] = "pasan";

            question[90] = "To think about"; answer[90] = "pensar";
            question[91] = "I think about"; answer[91] = "pienso";
            question[92] = "You think about (Informal)"; answer[92] = "piensas";
            question[93] = "You think about (Formal)"; answer[93] = "piensa";
            question[94] = "He thinks about"; answer[94] = "piensa";
            question[95] = "She thinks about"; answer[95] = "piensa";
            question[96] = "We think about"; answer[96] = "pensamos";
            question[97] = "You think about (Inf., Plural, Spain)"; answer[97] = "pensáis";
            question[98] = "You think about (Formal, Plural)"; answer[98] = "piensan";
            question[99] = "They think about"; answer[99] = "piensan";

            question[100] = "To request"; answer[100] = "pedir";
            question[101] = "I request"; answer[101] = "pido";
            question[102] = "You request (Informal)"; answer[102] = "pides";
            question[103] = "You request (Formal)"; answer[103] = "pide";
            question[104] = "He requests"; answer[104] = "pide";
            question[105] = "She requests"; answer[105] = "pide";
            question[106] = "We request"; answer[106] = "pedimos";
            question[107] = "You request (Inf., Plural, Spain)"; answer[107] = "pedís";
            question[108] = "You request (Formal, Plural)"; answer[108] = "piden";
            question[109] = "They request"; answer[109] = "piden";

            question[110] = "To lose"; answer[110] = "perder";
            question[111] = "I lose"; answer[111] = "pierdo";
            question[112] = "You lose (Informal)"; answer[112] = "pierdes";
            question[113] = "You lose (Formal)"; answer[113] = "pierde";
            question[114] = "He loses"; answer[114] = "pierde";
            question[115] = "She loses"; answer[115] = "pierde";
            question[116] = "We lose"; answer[116] = "perdemos";
            question[117] = "You lose (Inf., Plural, Spain)"; answer[117] = "perdéis";
            question[118] = "You lose (Formal, Plural)"; answer[118] = "pierden";
            question[119] = "They lose"; answer[119] = "pierden";

            question[120] = "To can"; answer[120] = "poder";
            question[121] = "I can"; answer[121] = "puedo";
            question[122] = "You can (Informal)"; answer[122] = "puedes";
            question[123] = "You can (Formal)"; answer[123] = "puede";
            question[124] = "He can"; answer[124] = "puede";
            question[125] = "She can"; answer[125] = "puede";
            question[126] = "We can"; answer[126] = "podemos";
            question[127] = "You can (Inf., Plural, Spain)"; answer[127] = "podéis";
            question[128] = "You can (Formal, Plural)"; answer[128] = "pueden";
            question[129] = "They can"; answer[129] = "pueden";

            question[130] = "To prefer"; answer[130] = "preferir";
            question[131] = "I prefer"; answer[131] = "prefiero";
            question[132] = "You prefer (Informal)"; answer[132] = "prefieres";
            question[133] = "You prefer (Formal)"; answer[133] = "prefiere";
            question[134] = "He prefers"; answer[134] = "prefiere";
            question[135] = "She prefers"; answer[135] = "prefiere";
            question[136] = "We prefer"; answer[136] = "preferimos";
            question[137] = "You prefer (Inf., Plural, Spain)"; answer[137] = "preferís";
            question[138] = "You prefer (Formal, Plural)"; answer[138] = "prefieren";
            question[139] = "They prefer"; answer[139] = "prefieren";

            question[140] = "To want"; answer[140] = "querer";
            question[141] = "I want"; answer[141] = "quiero";
            question[142] = "You want (Informal)"; answer[142] = "quieres";
            question[143] = "You want (Formal)"; answer[143] = "quiere";
            question[144] = "He wants"; answer[144] = "quiere";
            question[145] = "She wants"; answer[145] = "quiere";
            question[146] = "We want"; answer[146] = "queremos";
            question[147] = "You want (Inf., Plural, Spain)"; answer[147] = "queréis";
            question[148] = "You want (Formal, Plural)"; answer[148] = "quieren";
            question[149] = "They want"; answer[149] = "quieren";

            question[150] = "To remember"; answer[150] = "recordar";
            question[151] = "I remember"; answer[151] = "recuerdo";
            question[152] = "You remember (Informal)"; answer[152] = "recuerdas";
            question[153] = "You remember (Formal)"; answer[153] = "recuerda";
            question[154] = "He remembers"; answer[154] = "recuerda";
            question[155] = "She remembers"; answer[155] = "recuerda";
            question[156] = "We remember"; answer[156] = "recordamos";
            question[157] = "You remember (Inf., Plural, Spain)"; answer[157] = "recordáis";
            question[158] = "You remember (Formal, Plural)"; answer[158] = "recuerdan";
            question[159] = "They remember"; answer[159] = "recuerdan";

            question[160] = "To repeat"; answer[160] = "repetir";
            question[161] = "I repeat"; answer[161] = "repito";
            question[162] = "You repeat (Informal)"; answer[162] = "repites";
            question[163] = "You repeat (Formal)"; answer[163] = "repite";
            question[164] = "He repeats"; answer[164] = "repite";
            question[165] = "She repeats"; answer[165] = "repite";
            question[166] = "We repeat"; answer[166] = "repetimos";
            question[167] = "You repeat (Inf., Plural, Spain)"; answer[167] = "repetís";
            question[168] = "You repeat (Formal, Plural)"; answer[168] = "repiten";
            question[169] = "They repeat"; answer[169] = "repiten";

            question[170] = "To serve"; answer[170] = "servir";
            question[171] = "I serve"; answer[171] = "sirvo";
            question[172] = "You serve (Informal)"; answer[172] = "sirves";
            question[173] = "You serve (Formal)"; answer[173] = "sirve";
            question[174] = "He serves"; answer[174] = "sirve";
            question[175] = "She serves"; answer[175] = "sirve";
            question[176] = "We serve"; answer[176] = "servimos";
            question[177] = "You serve (Inf., Plural, Spain)"; answer[177] = "servís";
            question[178] = "You serve (Formal, Plural)"; answer[178] = "sirven";
            question[179] = "They serve"; answer[179] = "sirven";

            question[180] = "To dream about"; answer[180] = "soñar";
            question[181] = "I dream about"; answer[181] = "sueño";
            question[182] = "You dream about (Informal)"; answer[182] = "sueñas";
            question[183] = "You dream about (Formal)"; answer[183] = "sueña";
            question[184] = "He dreams about"; answer[184] = "sueña";
            question[185] = "She dreams about"; answer[185] = "sueña";
            question[186] = "We dream about"; answer[186] = "soñamos";
            question[187] = "You dream about (Inf., Plural, Spain)"; answer[187] = "soñáis";
            question[188] = "You dream about (Formal, Plural)"; answer[188] = "sueñan";
            question[189] = "They dream about"; answer[189] = "sueñan";

            question[190] = "To come"; answer[190] = "venir";
            question[191] = "I come"; answer[191] = "vengo";
            question[192] = "You come (Informal)"; answer[192] = "vienes";
            question[193] = "You come (Formal)"; answer[193] = "viene";
            question[194] = "He comes"; answer[194] = "viene";
            question[195] = "She comes"; answer[195] = "viene";
            question[196] = "We come"; answer[196] = "venimos";
            question[197] = "You come (Inf., Plural, Spain)"; answer[197] = "venís";
            question[198] = "You come (Formal, Plural)"; answer[198] = "vienen";
            question[199] = "They come"; answer[199] = "vienen";

            question[200] = "To return"; answer[200] = "volver";
            question[201] = "I return"; answer[201] = "vuelvo";
            question[202] = "You return (Informal)"; answer[202] = "vuelves";
            question[203] = "You return (Formal)"; answer[203] = "vuelve";
            question[204] = "He returns"; answer[204] = "vuelve";
            question[205] = "She returns"; answer[205] = "vuelve";
            question[206] = "We return"; answer[206] = "volvemos";
            question[207] = "You return (Inf., Plural, Spain)"; answer[207] = "volvéis";
            question[208] = "You return (Formal, Plural)"; answer[208] = "vuelven";
            question[209] = "They return"; answer[209] = "vuelven";

            question[210] = "To know someone"; answer[210] = "conocer";
            question[211] = "I know someone"; answer[211] = "conozco";
            question[212] = "You know someone (Informal)"; answer[212] = "conoces";
            question[213] = "You know someone (Formal)"; answer[213] = "conoce";
            question[214] = "He knows someone"; answer[214] = "conoce";
            question[215] = "She knows someone"; answer[215] = "conoce";
            question[216] = "We know someone"; answer[216] = "conocemos";
            question[217] = "You know someone (Inf., Plural, Spain)"; answer[217] = "conocéis";
            question[218] = "You know someone (Formal, Plural)"; answer[218] = "conocen";
            question[219] = "They know someone"; answer[219] = "conocen";

            question[220] = "To invite"; answer[220] = "invitar";
            question[221] = "I invite"; answer[221] = "invito";
            question[222] = "You invite (Informal)"; answer[222] = "invitas";
            question[223] = "You invite (Formal)"; answer[223] = "invita";
            question[224] = "He invites"; answer[224] = "invita";
            question[225] = "She invites"; answer[225] = "invita";
            question[226] = "We invite"; answer[226] = "invitamos";
            question[227] = "You invite (Inf., Plural, Spain)"; answer[227] = "invitáis";
            question[228] = "You invite (Formal, Plural)"; answer[228] = "invitan";
            question[229] = "They invite"; answer[229] = "invitan";

            question[230] = "To take a walk"; answer[230] = "pasear";
            question[231] = "I take a walk"; answer[231] = "paseo";
            question[232] = "You take a walk (Informal)"; answer[232] = "paseas";
            question[233] = "You take a walk (Formal)"; answer[233] = "pasea";
            question[234] = "He takes a walk"; answer[234] = "pasea";
            question[235] = "She takes a walk"; answer[235] = "pasea";
            question[236] = "We take a walk"; answer[236] = "paseamos";
            question[237] = "You take a walk (Inf., Plural, Spain)"; answer[237] = "paseáis";
            question[238] = "You take a walk (Formal, Plural)"; answer[238] = "pasean";
            question[239] = "They take a walk"; answer[239] = "pasean";

            question[240] = "To put"; answer[240] = "poner";
            question[241] = "I put"; answer[241] = "pongo";
            question[242] = "You put (Informal)"; answer[242] = "pones";
            question[243] = "You put (Formal)"; answer[243] = "pone";
            question[244] = "He puts"; answer[244] = "pone";
            question[245] = "She puts"; answer[245] = "pone";
            question[246] = "We put"; answer[246] = "ponemos";
            question[247] = "You put (Inf., Plural, Spain)"; answer[247] = "ponéis";
            question[248] = "You put (Formal, Plural)"; answer[248] = "ponen";
            question[249] = "They put"; answer[249] = "ponen";

            question[250] = "To know something"; answer[250] = "saber";
            question[251] = "I know something"; answer[251] = "sé";
            question[252] = "You know something (Informal)"; answer[252] = "sabes";
            question[253] = "You know something (Formal)"; answer[253] = "sabe";
            question[254] = "He knows something"; answer[254] = "sabe";
            question[255] = "She knows something"; answer[255] = "sabe";
            question[256] = "We know something"; answer[256] = "sabemos";
            question[257] = "You know something (Inf., Plural, Spain)"; answer[257] = "sabéis";
            question[258] = "You know something (Formal, Plural)"; answer[258] = "saben";
            question[259] = "They know something"; answer[259] = "saben";

            question[260] = "To leave"; answer[260] = "salir";
            question[261] = "I leave"; answer[261] = "salgo";
            question[262] = "You leave (Informal)"; answer[262] = "sales";
            question[263] = "You leave (Formal)"; answer[263] = "sale";
            question[264] = "He leaves"; answer[264] = "sale";
            question[265] = "She leaves"; answer[265] = "sale";
            question[266] = "We leave"; answer[266] = "salimos";
            question[267] = "You leave (Inf., Plural, Spain)"; answer[267] = "salís";
            question[268] = "You leave (Formal, Plural)"; answer[268] = "salen";
            question[269] = "They leave"; answer[269] = "salen";

            question[270] = "To play an instrument"; answer[270] = "tocar";
            question[271] = "I play an instrument"; answer[271] = "toco";
            question[272] = "You play an instrument (Informal)"; answer[272] = "tocas";
            question[273] = "You play an instrument (Formal)"; answer[273] = "toca";
            question[274] = "He plays an instrument"; answer[274] = "toca";
            question[275] = "She plays an instrument"; answer[275] = "toca";
            question[276] = "We play an instrument"; answer[276] = "tocamos";
            question[277] = "You play an instrument (Inf., Plural, Spain)"; answer[277] = "tocáis";
            question[278] = "You play an instrument (Formal, Plural)"; answer[278] = "tocan";
            question[279] = "They play an instrument"; answer[279] = "tocan";

            question[280] = "To bring"; answer[280] = "traer";
            question[281] = "I bring"; answer[281] = "traigo";
            question[282] = "You bring (Informal)"; answer[282] = "traes";
            question[283] = "You bring (Formal)"; answer[283] = "trae";
            question[284] = "He brings"; answer[284] = "trae";
            question[285] = "She brings"; answer[285] = "trae";
            question[286] = "We bring"; answer[286] = "traemos";
            question[287] = "You bring (Inf., Plural, Spain)"; answer[287] = "traéis";
            question[288] = "You bring (Formal, Plural)"; answer[288] = "traen";
            question[289] = "They bring"; answer[289] = "traen";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch4VerbsGame()
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
