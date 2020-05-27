using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    class Ch4FinalGame
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
            numberOfQuestions = 1367;
            question = new string[numberOfQuestions];
            answer = new string[numberOfQuestions];
            mastered = new bool[numberOfQuestions];

            //Saludos (Greetings) pg. 39
            question[0] = "Good morning"; answer[0] = "buenos días";
            question[1] = "Good evening"; answer[1] = "buenas noches";
            question[2] = "Good afternoon"; answer[2] = "buenas tardes";
            question[3] = "How are you? (Formal)"; answer[3] = "¿cómo está usted?";
            question[4] = "How are you? (Informal)"; answer[4] = "¿cómo estás?";
            question[5] = "Hello"; answer[5] = "hola";
            question[6] = "What's Happening?"; answer[6] = "¿qué pasa?";
            question[7] = "What's up? (Informal)"; answer[7] = "¿qué tal?";

            //Presentaciones (Introductions) pg. 39
            question[8] = "What's your name? (Formal)"; answer[8] = "¿cómo se llama usted?";
            question[9] = "What's your name? (Informal)"; answer[9] = "¿cómo te llamas?";
            question[10] = "I call myself (my name is)"; answer[10] = "me llamo";
            question[11] = "My name is"; answer[11] = "mi nombre es";
            question[12] = "I am"; answer[12] = "soy";

            //Respuestas (Responses) pg. 39
            question[13] = "You're Welcome"; answer[13] = "de nada";
            question[14] = "Really?"; answer[14] = "¿de verdad?";
            question[15] = "Nice to meet you (male)"; answer[15] = "encantado";
            question[16] = "Nice to meet you (female)"; answer[16] = "encantada";
            question[17] = "Thank you"; answer[17] = "gracias";
            question[18] = "Likewise"; answer[18] = "igualmente";
            question[19] = "I'm sorry"; answer[19] = "lo siento";
            question[20] = "So-so (more or less)"; answer[20] = "más o menos";
            question[21] = "Please to meet you"; answer[21] = "mucho gusto";
            question[22] = "Very good"; answer[22] = "muy bien";
            question[23] = "Very bad"; answer[23] = "muy mal";
            question[24] = "All's well"; answer[24] = "todo bien";

            //Despedidas (Farewells) pg. 39
            question[25] = "Good bye"; answer[25] = "adiós";
            question[26] = "See you later"; answer[26] = "hasta luego";
            question[27] = "See you tomorrow"; answer[27] = "hasta mañana";
            question[28] = "See you soon"; answer[28] = "hasta pronto";
            question[29] = "See you"; answer[29] = "nos vemos";

            //Titulos (Titles) pg. 39
            question[30] = "Mr."; answer[30] = "señor";
            question[31] = "Mrs."; answer[31] = "señora";
            question[32] = "Ms."; answer[32] = "señorita";

            //Sustantivos (Nouns) pg. 39
            question[33] = "The class"; answer[33] = "la clase";
            question[34] = "The student (male)"; answer[34] = "el estudiante";
            question[35] = "The student (female)"; answer[35] = "la estudiante";
            question[36] = "The professor (male)"; answer[36] = "el profesor";
            question[37] = "The professor (female)"; answer[37] = "la profesora";
            question[38] = "The homework"; answer[38] = "la tarea";
            question[39] = "The university"; answer[39] = "la universidad";

            //Otras palabras y expresiones (Other words and expressions) pg. 39
            question[40] = "How do you spell?"; answer[40] = "¿cómo se escribe?";
            question[41] = "With"; answer[41] = "con";
            question[42] = "My"; answer[42] = "mi";
            question[43] = "My (plural)"; answer[43] = "mis";
            question[44] = "Or"; answer[44] = "o";
            question[45] = "Your"; answer[45] = "tu";
            question[46] = "Your (plural)"; answer[46] = "tus";
            question[47] = "And"; answer[47] = "y";

            //En la clase (In the classroom) pg. 39
            question[48] = "The pen"; answer[48] = "el bolígrafo";
            question[49] = "The calculator"; answer[49] = "la calculadora";
            question[50] = "The computer"; answer[50] = "la computadora";
            question[51] = "The laptop"; answer[51] = "la computadora portátil";
            question[52] = "The notebook"; answer[52] = "el cuaderno";
            question[53] = "The dictionary"; answer[53] = "el diccionario";
            question[54] = "The pencil"; answer[54] = "el lápiz";
            question[55] = "The book"; answer[55] = "el libro";
            question[56] = "The map"; answer[56] = "el mapa";
            question[57] = "The marker"; answer[57] = "el marcador";
            question[58] = "The table"; answer[58] = "la mesa";
            question[59] = "The backpack"; answer[59] = "la mochila";
            question[60] = "The paper"; answer[60] = "el papel";
            question[61] = "The chalkboard"; answer[61] = "la pizarra";
            question[62] = "The whiteboard"; answer[62] = "la pizarra blanca";
            question[63] = "The door"; answer[63] = "la puerta";
            question[64] = "The clock / watch"; answer[64] = "el reloj";
            question[65] = "The chair"; answer[65] = "la silla";
            question[66] = "The cellphone"; answer[66] = "el teléfono celular";
            question[67] = "The mobile phone"; answer[67] = "el teléfono móvil";
            question[68] = "The chalk"; answer[68] = "la tiza";

            //Otros sustantivos (Other nouns) pg. 39
            question[69] = "The man"; answer[69] = "el hombre";
            question[70] = "The woman"; answer[70] = "la mujer";

            //Adjetivos (Adjetives) pg. 39
            question[71] = "Cheap (male)"; answer[71] = "barato";
            question[72] = "Cheap (female)"; answer[72] = "barata";
            question[73] = "Expensive (male)"; answer[73] = "caro";
            question[74] = "Expensive (female)"; answer[74] = "cara";
            question[75] = "Light (male)"; answer[75] = "claro";
            question[76] = "Light (female)"; answer[76] = "clara";
            question[77] = "Big"; answer[77] = "grande";
            question[78] = "Dark (male)"; answer[78] = "oscuro";
            question[79] = "Dark (female)"; answer[79] = "oscura";
            question[80] = "Small (male)"; answer[80] = "pequeño";
            question[81] = "Small (female)"; answer[81] = "pequeña";

            //Los colores (Colors) pg. 39
            question[82] = "Yellow (male)"; answer[82] = "amarillo";
            question[83] = "Yellow (female)"; answer[83] = "amarilla";
            question[84] = "Orange (male)"; answer[84] = "anaranjado";
            question[85] = "Orange (female)"; answer[85] = "anaranjada";
            question[86] = "Blue"; answer[86] = "azul";
            question[87] = "White (male)"; answer[87] = "blanco";
            question[88] = "White (female)"; answer[88] = "blanca";
            question[89] = "Brown"; answer[89] = "color café";
            question[90] = "Gray"; answer[90] = "gris";
            question[91] = "Purple (male)"; answer[91] = "morado";
            question[92] = "Purple (female)"; answer[92] = "morada";
            question[93] = "Black (male)"; answer[93] = "negro";
            question[94] = "Black (female)"; answer[94] = "negra";
            question[95] = "Red (male)"; answer[95] = "rojo";
            question[96] = "Red (female)"; answer[96] = "roja";
            question[97] = "Pink (male)"; answer[97] = "rosado";
            question[98] = "Pink (female)"; answer[98] = "rosada";
            question[99] = "Green"; answer[99] = "verde";

            //Adverbio (Adverb) pg. 39
            question[100] = "Here"; answer[100] = "aquí";

            //Verbos (Verbs) pg. 39
            question[101] = "There is/are"; answer[101] = "hay";

            question[102] = "To need"; answer[102] = "necesitar";
            question[103] = "I need"; answer[103] = "necesito";
            question[104] = "You need (Informal)"; answer[104] = "necesitas";
            question[105] = "You need (Formal)"; answer[105] = "necesita";
            question[106] = "He needs"; answer[106] = "necesita";
            question[107] = "She needs"; answer[107] = "necesita";
            question[108] = "We need"; answer[108] = "necesitamos";
            question[109] = "You need (Inf., Plural, Spain)"; answer[109] = "necesitáis";
            question[110] = "You need (Formal, Plural)"; answer[110] = "necesitan";
            question[111] = "They need"; answer[111] = "necesitan";

            question[112] = "To be (Permanent)"; answer[112] = "ser";
            question[113] = "I am (Permanent)"; answer[113] = "soy";
            question[114] = "You are (Informal, Permanent)"; answer[114] = "eres";
            question[115] = "You are (Formal, Permanent)"; answer[115] = "es";
            question[116] = "He is (Permanent)"; answer[116] = "es";
            question[117] = "She is (Permanent)"; answer[117] = "es";
            question[118] = "We are (Permanent)"; answer[118] = "somos";
            question[119] = "You are (Inf., Plural, Spain, Permanent)"; answer[119] = "soís";
            question[120] = "You are (Formal, Plural, Permanent)"; answer[120] = "son";
            question[121] = "They are (Permanent)"; answer[121] = "son";

            question[122] = "To have"; answer[122] = "tener";
            question[123] = "I have"; answer[123] = "tengo";
            question[124] = "You have (Informal)"; answer[124] = "tienes";
            question[125] = "You have (Formal)"; answer[125] = "tiene";
            question[126] = "He has"; answer[126] = "tiene";
            question[127] = "She has"; answer[127] = "tiene";
            question[128] = "We have"; answer[128] = "tenemos";
            question[129] = "You have (Inf., Plural, Spain)"; answer[129] = "tenéis";
            question[130] = "You have (Formal, Plural)"; answer[130] = "tienen";
            question[131] = "They have"; answer[131] = "tienen";

            //Otras Expresiones (Other Expressions) pg. 39
            question[132] = "What nonsense!"; answer[132] = "¡Qué barbaridad!";
            question[133] = "What students!"; answer[133] = "¡Qué estudiantes!";

            //Numeros (Numbers) pg. 10
            question[134] = "Zero"; answer[134] = "cero";

            question[135] = "One"; answer[135] = "uno";
            question[136] = "Two"; answer[136] = "dos";
            question[137] = "Three"; answer[137] = "tres";
            question[138] = "Four"; answer[138] = "cuatro";
            question[139] = "Five"; answer[139] = "cinco";
            question[140] = "Six"; answer[140] = "seis";
            question[141] = "Seven"; answer[141] = "siete";
            question[142] = "Eight"; answer[142] = "ocho";
            question[143] = "Nine"; answer[143] = "nueve";
            question[144] = "Ten"; answer[144] = "diez";

            question[145] = "Eleven"; answer[145] = "once";
            question[146] = "Twelve"; answer[146] = "doce";
            question[147] = "Thirteen"; answer[147] = "trece";
            question[148] = "Fourteen"; answer[148] = "catorce";
            question[149] = "Fifteen"; answer[149] = "quince";
            question[150] = "Sixteen"; answer[150] = "dieciséis";
            question[151] = "Seventeen"; answer[151] = "diecisiete";
            question[152] = "Eighteen"; answer[152] = "dieciocho";
            question[153] = "Nineteen"; answer[153] = "diecinueve";
            question[154] = "Twenty"; answer[154] = "veinte";

            question[155] = "Twenty One"; answer[155] = "veintiuno";
            question[156] = "Twenty Two"; answer[156] = "veintidós";
            question[157] = "Twenty Three"; answer[157] = "veintitrés";
            question[158] = "Twenty Four"; answer[158] = "veinticuatro";
            question[159] = "Twenty Five"; answer[159] = "veinticinco";
            question[160] = "Twenty Six"; answer[160] = "veintiséis";
            question[161] = "Twenty Seven"; answer[161] = "veintisiete";
            question[162] = "Twenty Eight"; answer[162] = "veintiocho";
            question[163] = "Twenty Nine"; answer[163] = "veintinueve";
            question[164] = "Thirty"; answer[164] = "treinta";

            question[165] = "Fourty"; answer[165] = "cuarenta";
            question[166] = "Fifty"; answer[166] = "cincuenta";
            question[167] = "Sixty"; answer[167] = "sesenta";
            question[168] = "Seventy"; answer[168] = "setenta";
            question[169] = "Eighty"; answer[169] = "ochenta";
            question[170] = "Ninety"; answer[170] = "noventa";
            question[171] = "One Hundred"; answer[171] = "cien";

            //Los días de la semana (The days of the week) pg. 13
            question[172] = "Monday"; answer[172] = "lunes";
            question[173] = "Tuesday"; answer[173] = "martes";
            question[174] = "Wednesday"; answer[174] = "miércoles";
            question[175] = "Thursday"; answer[175] = "jueves";
            question[176] = "Friday"; answer[176] = "viernes";
            question[177] = "Saturday"; answer[177] = "sábado";
            question[178] = "Sunday"; answer[178] = "domingo";

            //Los meses del año (The months of the year) pg. 13
            question[179] = "January"; answer[179] = "enero";
            question[180] = "February"; answer[180] = "febrero";
            question[181] = "March"; answer[181] = "marzo";
            question[182] = "April"; answer[182] = "abril";
            question[183] = "May"; answer[183] = "mayo";
            question[184] = "June"; answer[184] = "junio";
            question[185] = "July"; answer[185] = "julio";
            question[186] = "August"; answer[186] = "agosto";
            question[187] = "September"; answer[187] = "septiembre";
            question[188] = "October"; answer[188] = "octubre";
            question[189] = "November"; answer[189] = "noviembre";
            question[190] = "December"; answer[190] = "diciembre";

            //Las estaciones del año (The seasons of the year) pg. 14
            question[191] = "The winter"; answer[191] = "el invierno";
            question[192] = "The spring"; answer[192] = "la primavera";
            question[193] = "The summer"; answer[193] = "el verano";
            question[194] = "The fall"; answer[194] = "el otoño";

            //Pronombres (Pronouns) pg. 24
            question[195] = "I"; answer[195] = "yo";
            question[196] = "You (Informal)"; answer[196] = "tú";
            question[197] = "You (Formal)"; answer[197] = "usted";
            question[198] = "He"; answer[198] = "él";
            question[199] = "She"; answer[199] = "ella";
            question[200] = "We (male)"; answer[200] = "nosotros";
            question[201] = "We (female)"; answer[201] = "nosotras";
            question[202] = "You (Inf., (male), Plural, Spain)"; answer[202] = "vosotros";
            question[203] = "You (Inf., (female), Plural, Spain)"; answer[203] = "vosotras";
            question[204] = "You (Formal, Plural)"; answer[204] = "ustedes";
            question[205] = "They (male)"; answer[205] = "ellos";
            question[206] = "They (female)"; answer[206] = "ellas";

            //Adjetivos (Adjetives) pg. 30
            question[207] = "Boring (male)"; answer[207] = "aburrido";
            question[208] = "Boring (female)"; answer[208] = "aburrida";
            question[209] = "Good (male)"; answer[209] = "bueno";
            question[210] = "Good (female)"; answer[210] = "buena";
            question[211] = "Bad (male)"; answer[211] = "malo";
            question[212] = "Bad (female)"; answer[212] = "mala";
            question[213] = "Lazy (male)"; answer[213] = "perezoso";
            question[214] = "Lazy (female)"; answer[214] = "perezosa";
            question[215] = "Nice (male)"; answer[215] = "simpático";
            question[216] = "Nice (female)"; answer[216] = "simpática";
            question[217] = "Hardworking (male)"; answer[217] = "trabajador";
            question[218] = "Hardworking (female)"; answer[218] = "trabajadora";
            question[219] = "Exotic (male)"; answer[219] = "exótico";
            question[220] = "Exotic (female)"; answer[220] = "exótica";
            question[221] = "Outgoing (male)"; answer[221] = "extrovertido";
            question[222] = "Outgoing (female)"; answer[222] = "extrovertida";
            question[223] = "Facinating"; answer[223] = "fascinante";
            question[224] = "Ideal"; answer[224] = "ideal";
            question[225] = "Idealistic"; answer[225] = "idealista";
            question[226] = "Impatient"; answer[226] = "impaciente";
            question[227] = "Intelligent"; answer[227] = "inteligente";
            question[228] = "Interesting"; answer[228] = "intersante";
            question[229] = "Introvert (male)"; answer[229] = "introvertido";
            question[230] = "Introvert (female)"; answer[230] = "introvertida";
            question[231] = "Mysterious (male)"; answer[231] = "misterioso";
            question[232] = "Mysterious (female)"; answer[232] = "misteriosa";
            question[233] = "Optimistic"; answer[233] = "optimista";
            question[234] = "Patient"; answer[234] = "paciente";
            question[235] = "Pessimistic"; answer[235] = "pesimista";
            question[236] = "Realistic"; answer[236] = "realista";
            question[237] = "Romantic (male)"; answer[237] = "romántico";
            question[238] = "Romantic (female)"; answer[238] = "romántica";
            question[239] = "Shy (male)"; answer[239] = "tímido";
            question[240] = "Shy (female)"; answer[240] = "tímida";

            //Bonus words
            question[241] = "The boy"; answer[241] = "el muchacho";
            question[242] = "The girl"; answer[242] = "la muchacha";
            question[243] = "The music"; answer[243] = "la música";
            question[244] = "Which"; answer[244] = "cuál";
            question[245] = "The (male)"; answer[245] = "el";
            question[246] = "The (female)"; answer[246] = "la";
            question[247] = "The ((male) Plural)"; answer[247] = "los";
            question[248] = "The ((female) Plural)"; answer[248] = "las";
            question[249] = "Greetings"; answer[249] = "saludos";
            question[250] = "Introduction"; answer[250] = "presentacion";
            question[251] = "Response / Answer"; answer[251] = "respuesta";
            question[252] = "Farewell"; answer[252] = "despedida";
            question[253] = "Title"; answer[253] = "título";
            question[254] = "Noun"; answer[254] = "sustantivo";
            question[255] = "Other (male)"; answer[255] = "otro";
            question[256] = "Other (female)"; answer[256] = "otra";
            question[257] = "Word"; answer[257] = "palabra";
            question[258] = "Expression"; answer[258] = "expresión";
            question[259] = "Color"; answer[259] = "color";
            question[260] = "Adverb"; answer[260] = "adverbio";
            question[261] = "Adjetive"; answer[261] = "adjetivo";
            question[262] = "Application"; answer[262] = "aplicación";
            question[263] = "Model"; answer[263] = "modelo";
            question[264] = "Understand?"; answer[264] = "¿comprendes?";
            question[265] = "Birthday"; answer[265] = "cumpleaños";
            question[266] = "Experience"; answer[266] = "experiencia";
            question[267] = "Phenomenal!"; answer[267] = "¡fenomenal!";

            //Adjetivos Descriptivos (Descriptive Adjectives) pg. 75
            question[268] = "Active (male)"; answer[268] = "activo";
            question[269] = "Active (female)"; answer[269] = "activa";
            question[270] = "Tall (male)"; answer[270] = "alto";
            question[271] = "Tall (female)"; answer[271] = "alta";
            question[272] = "Short (male)"; answer[272] = "bajo";
            question[273] = "Short (female)"; answer[273] = "baja";
            question[274] = "Pretty / Cute (male)"; answer[274] = "bonito";
            question[275] = "Pretty / Cute (female)"; answer[275] = "bonita";
            question[276] = "Slender (male)"; answer[276] = "delgado";
            question[277] = "Slender (female)"; answer[277] = "delgada";
            question[278] = "Enthusiastic"; answer[278] = "etusiasta";
            question[279] = "Ugly (male)"; answer[279] = "feo";
            question[280] = "Ugly (female)"; answer[280] = "fea";
            question[281] = "Skinny (male)"; answer[281] = "flaco";
            question[282] = "Skinny (female)"; answer[282] = "flaca";
            question[283] = "Fat (male)"; answer[283] = "gordo";
            question[284] = "Fat (female)"; answer[284] = "gorda";
            question[285] = "Good-looking (male)"; answer[285] = "guapo";
            question[286] = "Good-looking (female)"; answer[286] = "guapa";
            question[287] = "Young"; answer[287] = "joven";
            question[288] = "Dark skin / hair (male)"; answer[288] = "moreno";
            question[289] = "Dark skin / hair (female)"; answer[289] = "morena";
            question[290] = "New (male)"; answer[290] = "nuevo";
            question[291] = "New (female)"; answer[291] = "nueva";
            question[292] = "Poor"; answer[292] = "pobre";
            question[293] = "Rich (male)"; answer[293] = "rico";
            question[294] = "Rich (female)"; answer[294] = "rica";
            question[295] = "Blonde (male)"; answer[295] = "rubio";
            question[296] = "Blonde (female)"; answer[296] = "rubia";
            question[297] = "Old (male)"; answer[297] = "viejo";
            question[298] = "Old (female)"; answer[298] = "vieja";

            //Nacionalidades y Países (Nationalities) pg. 75
            question[299] = "Germany"; answer[299] = "alemania";
            question[300] = "German man"; answer[300] = "alemán";
            question[301] = "German woman"; answer[301] = "alemana";

            question[302] = "Brazil"; answer[302] = "brasil";
            question[303] = "Brazilian man"; answer[303] = "brasileño";
            question[304] = "Brazilian woman"; answer[304] = "brasileña";

            question[305] = "China"; answer[305] = "china";
            question[306] = "Chinese man"; answer[306] = "chino";
            question[307] = "Chinese woman"; answer[307] = "china";

            question[308] = "Korea"; answer[308] = "coreo";
            question[309] = "Korean man"; answer[309] = "coreano";
            question[310] = "Korean woman"; answer[310] = "coreana";

            question[311] = "France"; answer[311] = "francia";
            question[312] = "French man"; answer[312] = "francés";
            question[313] = "French woman"; answer[313] = "francesa";

            question[314] = "England"; answer[314] = "inglaterra";
            question[315] = "English man"; answer[315] = "inglés";
            question[316] = "English woman"; answer[316] = "inglesa";

            question[317] = "Italy"; answer[317] = "italia";
            question[318] = "Italian man"; answer[318] = "italiano";
            question[319] = "Italian woman"; answer[319] = "italiana";

            question[320] = "Japan"; answer[320] = "japón";
            question[321] = "Japanese man"; answer[321] = "japonés";
            question[322] = "Japanese woman"; answer[322] = "japonesa";

            question[323] = "Portugal"; answer[323] = "portugal";
            question[324] = "Portuguese man"; answer[324] = "portugués";
            question[325] = "Portuguese woman"; answer[325] = "portuguesa";

            question[326] = "Russia"; answer[326] = "rusia";
            question[327] = "Russian man"; answer[327] = "ruso";
            question[328] = "Russian woman"; answer[328] = "rusa";

            question[329] = "Canada"; answer[329] = "canadá";
            question[330] = "Canadian"; answer[330] = "canadiense";

            question[331] = "Argentina"; answer[331] = "argentina";
            question[332] = "Argentine man"; answer[332] = "argentino";
            question[333] = "Argentine woman"; answer[333] = "argentina";

            question[334] = "Chile"; answer[334] = "chile";
            question[335] = "Chilian man"; answer[335] = "chileno";
            question[336] = "Chilian woman"; answer[336] = "chilena";

            question[337] = "Colombia"; answer[337] = "colombia";
            question[338] = "Colombian man"; answer[338] = "colombiano";
            question[339] = "Colombian woman"; answer[339] = "colombiana";

            question[340] = "Cuba"; answer[340] = "cuba";
            question[341] = "Cuban man"; answer[341] = "cubano";
            question[342] = "Cuban woman"; answer[342] = "cubana";

            question[343] = "Dominican Republic"; answer[343] = "república dominicana";
            question[344] = "Dominican man"; answer[344] = "dominicano";
            question[345] = "Dominican woman"; answer[345] = "dominicana";

            question[346] = "Ecuador"; answer[346] = "ecuador";
            question[347] = "Ecuadorian man"; answer[347] = "ecuatoriano";
            question[348] = "Ecuadorian woman"; answer[348] = "ecuatoriana";

            question[349] = "Spain"; answer[349] = "españia";
            question[350] = "Spanish man"; answer[350] = "español";
            question[351] = "Spanish woman"; answer[351] = "española";

            question[352] = "Mexico"; answer[352] = "méxico";
            question[353] = "Mexican man"; answer[353] = "mexicano";
            question[354] = "Mexican woman"; answer[354] = "mexicana";

            question[355] = "North America"; answer[355] = "américa del norte";
            question[356] = "United States"; answer[356] = "estados unidos";
            question[357] = "U.S. Citizen"; answer[357] = "estadounidense";
            question[358] = "North American man"; answer[358] = "norteamericano";
            question[359] = "North American woman"; answer[359] = "norteamericana";

            question[360] = "Panama"; answer[360] = "panamá";
            question[361] = "Panamanian man"; answer[361] = "panameño";
            question[362] = "Panamanian woman"; answer[362] = "panameña";

            question[363] = "Peru"; answer[363] = "perú";
            question[364] = "Peruvian man"; answer[364] = "peruano";
            question[365] = "Peruvian woman"; answer[365] = "peruana";

            question[366] = "Puerto Rico"; answer[366] = "puerto rico";
            question[367] = "Puerto Rican man"; answer[367] = "puertorriqueño";
            question[368] = "Puerto Rican woman"; answer[368] = "puertorriqueña";

            question[369] = "El Salvador"; answer[369] = "el salvador";
            question[370] = "Salvadoran man"; answer[370] = "salvadoreño";
            question[371] = "Salvadoran woman"; answer[371] = "salvadoreña";

            question[372] = "Venezuela"; answer[372] = "venezuela";
            question[373] = "Venezuelan man"; answer[373] = "venezolano";
            question[374] = "Venezuelan woman"; answer[374] = "venezolana";

            question[375] = "Guatemala"; answer[375] = "guatemala";
            question[376] = "Guatemalan man"; answer[376] = "guatemalteco";
            question[377] = "Guatemalan woman"; answer[377] = "guatemalteca";

            //Lugares (Places) pg. 75
            question[378] = "The capital city"; answer[378] = "la capital";
            question[379] = "The city"; answer[379] = "la ciudad";
            question[380] = "The country"; answer[380] = "el país";

            //Las personas (People) pg. 75
            question[381] = "The friend (male)"; answer[381] = "el amigo";
            question[382] = "The friend (female)"; answer[382] = "la amiga";
            question[383] = "The boy"; answer[383] = "el muchacho";
            question[384] = "The girl"; answer[384] = "la muchacha";
            question[385] = "The parent"; answer[385] = "el padre";
            question[386] = "The parents"; answer[386] = "los padres";

            //Adverbios (Adverbs) pg.75
            question[387] = "Now"; answer[387] = "ahora";
            question[388] = "Also"; answer[388] = "también";
            question[389] = "Late"; answer[389] = "tarde";
            question[390] = "Early"; answer[390] = "temprano";

            //Conjunciones (Conjunctions) pg. 75
            question[391] = "But"; answer[391] = "pero";
            question[392] = "Because"; answer[392] = "porque";

            //Verbos (Verbs) pg 75.
            question[393] = "To open"; answer[393] = "abrir";
            question[394] = "I open"; answer[394] = "abro";
            question[395] = "You open (Informal)"; answer[395] = "abres";
            question[396] = "You open (Formal)"; answer[396] = "abre";
            question[397] = "He opens"; answer[397] = "abre";
            question[398] = "She opens"; answer[398] = "abre";
            question[399] = "We open"; answer[399] = "abrimos";
            question[400] = "You open (Inf., Plural, Spain)"; answer[400] = "abrís";
            question[401] = "You open (Formal, Plural)"; answer[401] = "abren";
            question[402] = "They open (male / female)"; answer[402] = "abren";

            question[403] = "To attend"; answer[403] = "asistir";
            question[404] = "I attend"; answer[404] = "asisto";
            question[405] = "You attend (Informal)"; answer[405] = "asistes";
            question[406] = "You attend (Formal)"; answer[406] = "asiste";
            question[407] = "He attends"; answer[407] = "asiste";
            question[408] = "She attends"; answer[408] = "asiste";
            question[409] = "We attend"; answer[409] = "asistimos";
            question[410] = "You attend (Inf., Plural, Spain)"; answer[410] = "asistís";
            question[411] = "You attend (Formal, Plural)"; answer[411] = "asisten";
            question[412] = "They attend (male / female)"; answer[412] = "asisten";

            question[413] = "To learn"; answer[413] = "aprender";
            question[414] = "I learn"; answer[414] = "aprendo";
            question[415] = "You learn (Informal)"; answer[415] = "aprendes";
            question[416] = "You learn (Formal)"; answer[416] = "aprende";
            question[417] = "He learns"; answer[417] = "aprende";
            question[418] = "She learns"; answer[418] = "aprende";
            question[419] = "We learn"; answer[419] = "aprendemos";
            question[420] = "You learn (Inf., Plural, Spain)"; answer[420] = "aprendéis";
            question[421] = "You learn (Formal, Plural)"; answer[421] = "aprenden";
            question[422] = "They learn (male / female)"; answer[422] = "aprenden";

            question[423] = "To help"; answer[423] = "ayudar";
            question[424] = "I help"; answer[424] = "ayudo";
            question[425] = "You help (Informal)"; answer[425] = "ayudas";
            question[426] = "You help (Formal)"; answer[426] = "ayuda";
            question[427] = "He helps"; answer[427] = "ayuda";
            question[428] = "She helps"; answer[428] = "ayuda";
            question[429] = "We help"; answer[429] = "ayudamos";
            question[430] = "You help (Inf., Plural, Spain)"; answer[430] = "ayudáis";
            question[431] = "You help (Formal, Plural)"; answer[431] = "ayudan";
            question[432] = "They help (male / female)"; answer[432] = "ayudan";

            question[433] = "To dance"; answer[433] = "bailar";
            question[434] = "I dance"; answer[434] = "bailo";
            question[435] = "You dance (Informal)"; answer[435] = "bailas";
            question[436] = "You dance (Formal)"; answer[436] = "baila";
            question[437] = "He dances"; answer[437] = "baila";
            question[438] = "She dances"; answer[438] = "baila";
            question[439] = "We dance"; answer[439] = "bailamos";
            question[440] = "You dance (Inf., Plural, Spain)"; answer[440] = "bailáis";
            question[441] = "You dance (Formal, Plural)"; answer[441] = "bailan";
            question[442] = "They dance (male / female)"; answer[442] = "bailan";

            question[443] = "To drink"; answer[443] = "beber";
            question[444] = "I drink"; answer[444] = "bebo";
            question[445] = "You drink (Informal)"; answer[445] = "bebes";
            question[446] = "You drink (Formal)"; answer[446] = "bebe";
            question[447] = "He drinks"; answer[447] = "bebe";
            question[448] = "She drinks"; answer[448] = "bebe";
            question[449] = "We drink"; answer[449] = "bebemos";
            question[450] = "You drink (Inf., Plural, Spain)"; answer[450] = "bebéis";
            question[451] = "You drink (Formal, Plural)"; answer[451] = "beben";
            question[452] = "They drink (male / female)"; answer[452] = "beben";

            question[453] = "To search"; answer[453] = "buscar";
            question[454] = "I search"; answer[454] = "busco";
            question[455] = "You search (Informal)"; answer[455] = "buscas";
            question[456] = "You search (Formal)"; answer[456] = "busca";
            question[457] = "He searches"; answer[457] = "busca";
            question[458] = "She searches"; answer[458] = "busca";
            question[459] = "We search"; answer[459] = "buscamos";
            question[460] = "You search (Inf., Plural, Spain)"; answer[460] = "buscáis";
            question[461] = "You search (Formal, Plural)"; answer[461] = "buscan";
            question[462] = "They search (male / female)"; answer[462] = "buscan";

            question[463] = "To eat"; answer[463] = "comer";
            question[464] = "I eat"; answer[464] = "como";
            question[465] = "You eat (Informal)"; answer[465] = "comes";
            question[466] = "You eat (Formal)"; answer[466] = "come";
            question[467] = "He eats"; answer[467] = "come";
            question[468] = "She eats"; answer[468] = "come";
            question[469] = "We eat"; answer[469] = "comemos";
            question[470] = "You eat (Inf., Plural, Spain)"; answer[470] = "coméis";
            question[471] = "You eat (Formal, Plural)"; answer[471] = "comen";
            question[472] = "They eat (male / female)"; answer[472] = "comen";

            question[473] = "To buy"; answer[473] = "comprar";
            question[474] = "I buy"; answer[474] = "compro";
            question[475] = "You buy (Informal)"; answer[475] = "compras";
            question[476] = "You buy (Formal)"; answer[476] = "compra";
            question[477] = "He buys"; answer[477] = "compra";
            question[478] = "She buys"; answer[478] = "compra";
            question[479] = "We buy"; answer[479] = "compramos";
            question[480] = "You buy (Inf., Plural, Spain)"; answer[480] = "compráis";
            question[481] = "You buy (Formal, Plural)"; answer[481] = "compran";
            question[482] = "They buy (male / female)"; answer[482] = "compran";

            question[483] = "To comprehend"; answer[483] = "comprender";
            question[484] = "I comprehend"; answer[484] = "comprendo";
            question[485] = "You comprehend (Informal)"; answer[485] = "comprendes";
            question[486] = "You comprehend (Formal)"; answer[486] = "comprende";
            question[487] = "He comprehends"; answer[487] = "comprende";
            question[488] = "She comprehends"; answer[488] = "comprende";
            question[489] = "We comprehend"; answer[489] = "comprendemos";
            question[490] = "You comprehend (Inf., Plural, Spain)"; answer[490] = "comprendéis";
            question[491] = "You comprehend (Formal, Plural)"; answer[491] = "comprenden";
            question[492] = "They comprehend (male / female)"; answer[492] = "comprenden";

            question[493] = "To believe"; answer[493] = "creer";
            question[494] = "I believe"; answer[494] = "creo";
            question[495] = "You believe (Informal)"; answer[495] = "crees";
            question[496] = "You believe (Formal)"; answer[496] = "cree";
            question[497] = "He believes"; answer[497] = "cree";
            question[498] = "She believes"; answer[498] = "cree";
            question[499] = "We believe"; answer[499] = "creemos";
            question[500] = "You believe (Inf., Plural, Spain)"; answer[500] = "creéis";
            question[501] = "You believe (Formal, Plural)"; answer[501] = "creen";
            question[502] = "They believe (male / female)"; answer[502] = "creen";

            question[503] = "To owe"; answer[503] = "deber";
            question[504] = "I owe"; answer[504] = "debo";
            question[505] = "You owe (Informal)"; answer[505] = "debes";
            question[506] = "You owe (Formal)"; answer[506] = "debe";
            question[507] = "He owes"; answer[507] = "debe";
            question[508] = "She owes"; answer[508] = "debe";
            question[509] = "We owe"; answer[509] = "debemos";
            question[510] = "You owe (Inf., Plural, Spain)"; answer[510] = "debéis";
            question[511] = "You owe (Formal, Plural)"; answer[511] = "deben";
            question[512] = "They owe (male / female)"; answer[512] = "deben";

            question[513] = "To decide"; answer[513] = "decidir";
            question[514] = "I decide"; answer[514] = "decido";
            question[515] = "You decide (Informal)"; answer[515] = "decides";
            question[516] = "You decide (Formal)"; answer[516] = "decide";
            question[517] = "He decides"; answer[517] = "decide";
            question[518] = "She decides"; answer[518] = "decide";
            question[519] = "We decide"; answer[519] = "decidimos";
            question[520] = "You decide (Inf., Plural, Spain)"; answer[520] = "decidís";
            question[521] = "You decide (Formal, Plural)"; answer[521] = "deciden";
            question[522] = "They decide (male / female)"; answer[522] = "deciden";

            question[523] = "To wish"; answer[523] = "desear";
            question[524] = "I wish"; answer[524] = "deseo";
            question[525] = "You wish (Informal)"; answer[525] = "deseas";
            question[526] = "You wish (Formal)"; answer[526] = "desea";
            question[527] = "He wishes"; answer[527] = "desea";
            question[528] = "She wishes"; answer[528] = "desea";
            question[529] = "We wish"; answer[529] = "deseamos";
            question[530] = "You wish (Inf., Plural, Spain)"; answer[530] = "deseáis";
            question[531] = "You wish (Formal, Plural)"; answer[531] = "desean";
            question[532] = "They wish (male / female)"; answer[532] = "desean";

            question[533] = "To teach"; answer[533] = "enseñar";
            question[534] = "I teach"; answer[534] = "enseño";
            question[535] = "You teach (Informal)"; answer[535] = "enseñas";
            question[536] = "You teach (Formal)"; answer[536] = "enseña";
            question[537] = "He teaches"; answer[537] = "enseña";
            question[538] = "She teaches"; answer[538] = "enseña";
            question[539] = "We teach"; answer[539] = "enseñamos";
            question[540] = "You teach (Inf., Plural, Spain)"; answer[540] = "enseñáis";
            question[541] = "You teach (Formal, Plural)"; answer[541] = "enseñan";
            question[542] = "They teach (male / female)"; answer[542] = "enseñan";

            question[543] = "To write"; answer[543] = "escribir";
            question[544] = "I write"; answer[544] = "escribo";
            question[545] = "You write (Informal)"; answer[545] = "escribes";
            question[546] = "You write (Formal)"; answer[546] = "escribe";
            question[547] = "He writes"; answer[547] = "escribe";
            question[548] = "She writes"; answer[548] = "escribe";
            question[549] = "We write"; answer[549] = "escribimos";
            question[550] = "You write (Inf., Plural, Spain)"; answer[550] = "escribís";
            question[551] = "You write (Formal, Plural)"; answer[551] = "escriben";
            question[552] = "They write (male / female)"; answer[552] = "escriben";

            question[553] = "To listen"; answer[553] = "escuchar";
            question[554] = "I listen"; answer[554] = "escucho";
            question[555] = "You listen (Informal)"; answer[555] = "escuchas";
            question[556] = "You listen (Formal)"; answer[556] = "escucha";
            question[557] = "He listens"; answer[557] = "escucha";
            question[558] = "She listens"; answer[558] = "escucha";
            question[559] = "We listen"; answer[559] = "escuchamos";
            question[560] = "You listen (Inf., Plural, Spain)"; answer[560] = "escucháis";
            question[561] = "You listen (Formal, Plural)"; answer[561] = "escuchan";
            question[562] = "They listen (male / female)"; answer[562] = "escuchan";

            question[563] = "To travel"; answer[563] = "viajar";
            question[564] = "I travel"; answer[564] = "viajo";
            question[565] = "You travel (Informal)"; answer[565] = "viajas";
            question[566] = "You travel (Formal)"; answer[566] = "viaja";
            question[567] = "He travels"; answer[567] = "viaja";
            question[568] = "She travels"; answer[568] = "viaja";
            question[569] = "We travel"; answer[569] = "viajamos";
            question[570] = "You travel (Inf., Plural, Spain)"; answer[570] = "viajáis";
            question[571] = "You travel (Formal, Plural)"; answer[571] = "viajan";
            question[572] = "They travel (male / female)"; answer[572] = "viajan";

            question[573] = "To study"; answer[573] = "estudiar";
            question[574] = "I study"; answer[574] = "estudio";
            question[575] = "You study (Informal)"; answer[575] = "estudias";
            question[576] = "You study (Formal)"; answer[576] = "estudia";
            question[577] = "He studies"; answer[577] = "estudia";
            question[578] = "She studies"; answer[578] = "estudia";
            question[579] = "We study"; answer[579] = "estudiamos";
            question[580] = "You study (Inf., Plural, Spain)"; answer[580] = "estudiáis";
            question[581] = "You study (Formal, Plural)"; answer[581] = "estudian";
            question[582] = "They study (male / female)"; answer[582] = "estudian";

            question[583] = "To speak"; answer[583] = "hablar";
            question[584] = "I speak"; answer[584] = "hablo";
            question[585] = "You speak (Informal)"; answer[585] = "hablas";
            question[586] = "You speak (Formal)"; answer[586] = "habla";
            question[587] = "He speaks"; answer[587] = "habla";
            question[588] = "She speaks"; answer[588] = "habla";
            question[589] = "We speak"; answer[589] = "hablamos";
            question[590] = "You speak (Inf., Plural, Spain)"; answer[590] = "habláis";
            question[591] = "You speak (Formal, Plural)"; answer[591] = "hablan";
            question[592] = "They speak (male / female)"; answer[592] = "hablan";

            question[593] = "To read"; answer[593] = "leer";
            question[594] = "I read"; answer[594] = "leo";
            question[595] = "You read (Informal)"; answer[595] = "lees";
            question[596] = "You read (Formal)"; answer[596] = "lee";
            question[597] = "He reads"; answer[597] = "lee";
            question[598] = "She reads"; answer[598] = "lee";
            question[599] = "We read"; answer[599] = "leemos";
            question[600] = "You read (Inf., Plural, Spain)"; answer[600] = "leéis";
            question[601] = "You read (Formal, Plural)"; answer[601] = "leen";
            question[602] = "They read (male / female)"; answer[602] = "leen";

            question[603] = "To arrive"; answer[603] = "llegar";
            question[604] = "I arrive"; answer[604] = "llego";
            question[605] = "You arrive (Informal)"; answer[605] = "llegas";
            question[606] = "You arrive (Formal)"; answer[606] = "llega";
            question[607] = "He arrives"; answer[607] = "llega";
            question[608] = "She arrives"; answer[608] = "llega";
            question[609] = "We arrive"; answer[609] = "llegamos";
            question[610] = "You arrive (Inf., Plural, Spain)"; answer[610] = "llegáis";
            question[611] = "You arrive (Formal, Plural)"; answer[611] = "llegan";
            question[612] = "They arrive (male / female)"; answer[612] = "llegan";

            question[613] = "To look"; answer[613] = "mirar";
            question[614] = "I look"; answer[614] = "miro";
            question[615] = "You look (Informal)"; answer[615] = "miras";
            question[616] = "You look (Formal)"; answer[616] = "mira";
            question[617] = "He looks"; answer[617] = "mira";
            question[618] = "She looks"; answer[618] = "mira";
            question[619] = "We look"; answer[619] = "miramos";
            question[620] = "You look (Inf., Plural, Spain)"; answer[620] = "miráis";
            question[621] = "You look (Formal, Plural)"; answer[621] = "miran";
            question[622] = "They look (male / female)"; answer[622] = "miran";

            question[623] = "To practice"; answer[623] = "practicar";
            question[624] = "I practice"; answer[624] = "practico";
            question[625] = "You practice (Informal)"; answer[625] = "practicas";
            question[626] = "You practice (Formal)"; answer[626] = "practica";
            question[627] = "He practices"; answer[627] = "practica";
            question[628] = "She practices"; answer[628] = "practica";
            question[629] = "We practice"; answer[629] = "practicamos";
            question[630] = "You practice (Inf., Plural, Spain)"; answer[630] = "practicáis";
            question[631] = "You practice (Formal, Plural)"; answer[631] = "practican";
            question[632] = "They practice (male / female)"; answer[632] = "practican";

            question[633] = "To prepare"; answer[633] = "preparar";
            question[634] = "I prepare"; answer[634] = "preparo";
            question[635] = "You prepare (Informal)"; answer[635] = "preparas";
            question[636] = "You prepare (Formal)"; answer[636] = "prepara";
            question[637] = "He prepares"; answer[637] = "prepara";
            question[638] = "She prepares"; answer[638] = "prepara";
            question[639] = "We prepare"; answer[639] = "preparamos";
            question[640] = "You prepare (Inf., Plural, Spain)"; answer[640] = "preparáis";
            question[641] = "You prepare (Formal, Plural)"; answer[641] = "preparan";
            question[642] = "They prepare (male / female)"; answer[642] = "preparan";

            question[643] = "To receive"; answer[643] = "recibir";
            question[644] = "I receive"; answer[644] = "recibo";
            question[645] = "You receive (Informal)"; answer[645] = "recibes";
            question[646] = "You receive (Formal)"; answer[646] = "recibe";
            question[647] = "He receives"; answer[647] = "recibe";
            question[648] = "She receives"; answer[648] = "recibe";
            question[649] = "We receive"; answer[649] = "recibimos";
            question[650] = "You receive (Inf., Plural, Spain)"; answer[650] = "recibís";
            question[651] = "You receive (Formal, Plural)"; answer[651] = "reciben";
            question[652] = "They receive (male / female)"; answer[652] = "reciben";

            question[653] = "To have"; answer[653] = "tener";
            question[654] = "I have"; answer[654] = "tengo";
            question[655] = "You have (Informal)"; answer[655] = "tienes";
            question[656] = "You have (Formal)"; answer[656] = "tiene";
            question[657] = "He has"; answer[657] = "tiene";
            question[658] = "She has"; answer[658] = "tiene";
            question[659] = "We have"; answer[659] = "tenemos";
            question[660] = "You have (Inf., Plural, Spain)"; answer[660] = "tenéis";
            question[661] = "You have (Formal, Plural)"; answer[661] = "tienen";
            question[662] = "They have (male / female)"; answer[662] = "tienen";

            question[663] = "To take"; answer[663] = "tomar";
            question[664] = "I take"; answer[664] = "tomo";
            question[665] = "You take (Informal)"; answer[665] = "tomas";
            question[666] = "You take (Formal)"; answer[666] = "toma";
            question[667] = "He takes"; answer[667] = "toma";
            question[668] = "She takes"; answer[668] = "toma";
            question[669] = "We take"; answer[669] = "tomamos";
            question[670] = "You take (Inf., Plural, Spain)"; answer[670] = "tomáis";
            question[671] = "You take (Formal, Plural)"; answer[671] = "toman";
            question[672] = "They take (male / female)"; answer[672] = "toman";

            question[673] = "To work"; answer[673] = "trabajar";
            question[674] = "I work"; answer[674] = "trabajo";
            question[675] = "You work (Informal)"; answer[675] = "trabajas";
            question[676] = "You work (Formal)"; answer[676] = "trabaja";
            question[677] = "He works"; answer[677] = "trabaja";
            question[678] = "She works"; answer[678] = "trabaja";
            question[679] = "We work"; answer[679] = "trabajamos";
            question[680] = "You work (Inf., Plural, Spain)"; answer[680] = "trabajáis";
            question[681] = "You work (Formal, Plural)"; answer[681] = "trabajan";
            question[682] = "They work (male / female)"; answer[682] = "trabajan";

            question[683] = "To live"; answer[683] = "vivir";
            question[684] = "I live"; answer[684] = "vivo";
            question[685] = "You live (Informal)"; answer[685] = "vives";
            question[686] = "You live (Formal)"; answer[686] = "vive";
            question[687] = "He lives"; answer[687] = "vive";
            question[688] = "She lives"; answer[688] = "vive";
            question[689] = "We live"; answer[689] = "vivimos";
            question[690] = "You live (Inf., Plural, Spain)"; answer[690] = "vivís";
            question[691] = "You live (Formal, Plural)"; answer[691] = "viven";
            question[692] = "They live (male / female)"; answer[692] = "viven";

            question[693] = "To sell"; answer[693] = "vender";
            question[694] = "I sell"; answer[694] = "vendo";
            question[695] = "You sell (Informal)"; answer[695] = "vendes";
            question[696] = "You sell (Formal)"; answer[696] = "vende";
            question[697] = "He sells"; answer[697] = "vende";
            question[698] = "She sells"; answer[698] = "vende";
            question[699] = "We sell"; answer[699] = "vendemos";
            question[700] = "You sell (Inf., Plural, Spain)"; answer[700] = "vendéis";
            question[701] = "You sell (Formal, Plural)"; answer[701] = "venden";
            question[702] = "They sell (male / female)"; answer[702] = "venden";

            question[703] = "To watch"; answer[703] = "ver";
            question[704] = "I watch"; answer[704] = "veo";
            question[705] = "You watch (Informal)"; answer[705] = "ves";
            question[706] = "You watch (Formal)"; answer[706] = "ve";
            question[707] = "He watches"; answer[707] = "ve";
            question[708] = "She watches"; answer[708] = "ve";
            question[709] = "We watch"; answer[709] = "vemos";
            question[710] = "You watch (Inf., Plural, Spain)"; answer[710] = "veis";
            question[711] = "You watch (Formal, Plural)"; answer[711] = "ven";
            question[712] = "They watch (male / female)"; answer[712] = "ven";

            //Adjetivos (Adjectives) pg. 75
            question[713] = "Difficult"; answer[713] = "difícil";
            question[714] = "Easy"; answer[714] = "fácil";

            //Otras palabras y expressiones (Other words and expressions) pg. 75
            question[715] = "The language"; answer[715] = "la lengua";
            question[716] = "The languages"; answer[716] = "las lenguas";
            question[717] = "What do you like to do?"; answer[717] = "¿qué te gusta hacer?";
            question[718] = "I like"; answer[718] = "Me gusta";
            question[719] = "You like"; answer[719] = "Te gusta";
            question[720] = "How lucky!"; answer[720] = "¡qué suerte!";

            //Horas (Time) pg. 46
            question[721] = "What time is it?"; answer[721] = "¿qué hora es?";
            question[722] = "The noon"; answer[722] = "el mediodía";
            question[723] = "The midnight"; answer[723] = "la medianoche";
            question[724] = "It's noon"; answer[724] = "es mediodía";
            question[725] = "It's midnight"; answer[725] = "es medianoche";
            question[726] = "Until (an hour)"; answer[726] = "menos";
            question[727] = "Half (past an hour)"; answer[727] = "media";
            question[728] = "(Hour) on the dot / sharp"; answer[728] = "en punto";
            question[729] = "(Hour) in the morning"; answer[729] = "de la mañana";
            question[730] = "(Hour) in the afternoon"; answer[730] = "de la tarde";
            question[731] = "(Hour) in the evening"; answer[731] = "de la noche";
            question[732] = "(Situation) in the morning"; answer[732] = "por la mañana";
            question[733] = "(Situation) in the afternoon"; answer[733] = "por la tarde";
            question[734] = "(Situation) in the evening"; answer[734] = "por la noche";
            question[735] = "What time (does event take place)?"; answer[735] = "¿a qué hora?";
            question[736] = "It's one o clock"; answer[736] = "es la una";
            question[737] = "It's (hour) o clock"; answer[737] = "son las";

            //Palabras Interrogativas (Interrogative Words) pg. 52
            question[738] = "How"; answer[738] = "cómo";
            question[739] = "Which one"; answer[739] = "cuál";
            question[740] = "Which ones"; answer[740] = "cuáles";
            question[741] = "When"; answer[741] = "cuándo";
            question[742] = "How many (male, singular)"; answer[742] = "cuánto";
            question[743] = "How many (female, singular)"; answer[743] = "cuánta";
            question[744] = "How many (male, plural)"; answer[744] = "cuántos";
            question[745] = "How many (female, plural)"; answer[745] = "cuántas";
            question[746] = "Where"; answer[746] = "dónde";
            question[747] = "From where"; answer[747] = "de dónde";
            question[748] = "To where"; answer[748] = "adónde";
            question[749] = "Why"; answer[749] = "por qué";
            question[750] = "What"; answer[750] = "qué";
            question[751] = "Who (singular)"; answer[751] = "quién";
            question[752] = "Who (plural)"; answer[752] = "quiénes";
            question[753] = "Whose (singular)"; answer[753] = "de quién";
            question[754] = "Whose (plural)"; answer[754] = "de quiénes";

            //Bonus words
            question[755] = "Right now"; answer[755] = "ahora mismo";

            question[756] = "The business administration"; answer[756] = "la administración de empresas";
            question[757] = "The architecture"; answer[757] = "la arquitectura";
            question[758] = "The art"; answer[758] = "el arte";
            question[759] = "The biology"; answer[759] = "la biología";
            question[760] = "The calculus"; answer[760] = "el cálculo";
            question[761] = "The political science"; answer[761] = "las ciencias políticas";
            question[762] = "The social science"; answer[762] = "las ciencias sociales";
            question[763] = "The communications"; answer[763] = "las comunicaciones";
            question[764] = "The accounting"; answer[764] = "la contabilidad";
            question[765] = "The law"; answer[765] = "el derecho";
            question[766] = "The design"; answer[766] = "el diseño";
            question[767] = "The physical education"; answer[767] = "la educación física";
            question[768] = "The economics"; answer[768] = "la economía";
            question[769] = "The statistics"; answer[769] = "la estadística";
            question[770] = "The philosophy"; answer[770] = "la filosofía";
            question[771] = "The finance"; answer[771] = "las finanzas";
            question[772] = "The physics"; answer[772] = "la física";
            question[773] = "The geography"; answer[773] = "la geografía";
            question[774] = "The geology"; answer[774] = "la geología";
            question[775] = "The history"; answer[775] = "la historia";
            question[776] = "The computer science"; answer[776] = "la informática";
            question[777] = "The engineering"; answer[777] = "la ingeniería";
            question[778] = "The electrical engineering"; answer[778] = "la ingeniería eléctrica";
            question[779] = "The mathematics"; answer[779] = "las matemáticas";
            question[780] = "The medicine"; answer[780] = "la medicina";
            question[781] = "The teaching"; answer[781] = "la pedagogía";
            question[782] = "The chemistry"; answer[782] = "la química";
            question[783] = "The veterinary science"; answer[783] = "la veterinaria";

            question[784] = "The career"; answer[784] = "la carrera";
            question[785] = "The boy (chick)"; answer[785] = "el chico";
            question[786] = "The girl (chick)"; answer[786] = "la chica";
            question[787] = "The email"; answer[787] = "el correo electrónico";
            question[788] = "The money"; answer[788] = "el dinero";
            question[789] = "The schedule"; answer[789] = "el horario";
            question[790] = "The class schedule"; answer[790] = "el horario de clases";
            question[791] = "The semester"; answer[791] = "el semestre";
            question[792] = "The trimester"; answer[792] = "el trimestre";
            question[793] = "The video game"; answer[793] = "el videojuego";

            question[794] = "Complicated (male)"; answer[794] = "complicado";
            question[795] = "Complicated (female)"; answer[795] = "complicada";
            question[796] = "Challenging"; answer[796] = "exigente";
            question[797] = "Obligatory (male)"; answer[797] = "obligatorio";
            question[798] = "Obligatory (female)"; answer[798] = "obligatoria";

            question[799] = "Before"; answer[799] = "antes";
            question[800] = "Quite"; answer[800] = "bastante";
            question[801] = "After"; answer[801] = "después";
            question[802] = "Only (Long Version)"; answer[802] = "solamente";

            question[803] = "To be (have) __ years old"; answer[803] = "tener años";
            question[804] = "To be (have) warm"; answer[804] = "tener calor";
            question[805] = "To be (have) careful"; answer[805] = "tener cuidado";
            question[806] = "To be (have) cold"; answer[806] = "tener frío";
            question[807] = "To feel (have) like"; answer[807] = "tener ganas";
            question[808] = "To be (have) hungry"; answer[808] = "tener hambre";
            question[809] = "To be (have) afraid"; answer[809] = "tener miedo";
            question[810] = "To be (have) in a hurry"; answer[810] = "tener prisa";
            question[811] = "To be (have) right"; answer[811] = "tener razón";
            question[812] = "To be (have) thirsty"; answer[812] = "tener sed";
            question[813] = "To be (have) sleepy"; answer[813] = "tener sueño";

            question[814] = "The auditorium"; answer[814] = "el auditorio";
            question[815] = "The library"; answer[815] = "la biblioteca";
            question[816] = "The cafeteria"; answer[816] = "la cafetería";
            question[817] = "The tennis court"; answer[817] = "la cancha de tenis";
            question[818] = "The student union"; answer[818] = "el centro estudiantil";
            question[819] = "The stadium"; answer[819] = "el estadio";
            question[820] = "The school of art"; answer[820] = "la facultad de arte";
            question[821] = "The school of science"; answer[821] = "la facultad de ciencias";
            question[822] = "The school of law"; answer[822] = "la facultad de derecho";
            question[823] = "The school of humanities"; answer[823] = "la facultad de filosofía y letras";
            question[824] = "The school of engineering"; answer[824] = "la facultad de ingeniería";
            question[825] = "The school of medicine"; answer[825] = "la facultad de medicina";
            question[826] = "The school of education"; answer[826] = "la facultad de pedagogía";
            question[827] = "The gymnasium"; answer[827] = "el gimnasio";
            question[828] = "The laboratory"; answer[828] = "el laboratorio";
            question[829] = "The language laboratory"; answer[829] = "el laboratorio de lenguas";
            question[830] = "The computer laboratory"; answer[830] = "el laboratorio de computadoras";
            question[831] = "The bookstore"; answer[831] = "la librería";
            question[832] = "The museum"; answer[832] = "el museo";
            question[833] = "The observatory"; answer[833] = "el observatorio";
            question[834] = "The president's office"; answer[834] = "la rectoría";
            question[835] = "The theater"; answer[835] = "el teatro";

            question[836] = "Almost"; answer[836] = "casi";
            question[837] = "Always"; answer[837] = "siempre";
            question[838] = "Only (Short Version)"; answer[838] = "sólo";

            question[839] = "Look"; answer[839] = "mira";
            question[840] = "Well"; answer[840] = "pues";
            question[841] = "I'll go with you"; answer[841] = "te acompaño";
            question[842] = "Let's go"; answer[842] = "vamos";

            question[843] = "To be (Temporary)"; answer[843] = "estar";
            question[844] = "I am (Temporary)"; answer[844] = "estoy";
            question[845] = "You are (Informal, Temporary)"; answer[845] = "estás";
            question[846] = "You are (Formal, Temporary)"; answer[846] = "está";
            question[847] = "He is (Temporary)"; answer[847] = "está";
            question[848] = "She is (Temporary)"; answer[848] = "está";
            question[849] = "We are (Temporary)"; answer[849] = "estamos";
            question[850] = "You are (Inf., Plural, Spain, Temporary)"; answer[850] = "estáis";
            question[851] = "You are (Formal, Plural, Temporary)"; answer[851] = "están";
            question[852] = "They are (male / female, Temporary)"; answer[852] = "están";

            question[853] = "To do"; answer[853] = "hacer";
            question[854] = "I do"; answer[854] = "hago";
            question[855] = "You do (Informal)"; answer[855] = "haces";
            question[856] = "You do (Formal)"; answer[856] = "hace";
            question[857] = "He does"; answer[857] = "hace";
            question[858] = "She does"; answer[858] = "hace";
            question[859] = "We do"; answer[859] = "hacemos";
            question[860] = "You do (Inf., Plural, Spain)"; answer[860] = "hacéis";
            question[861] = "You do (Formal, Plural)"; answer[861] = "hacen";
            question[862] = "They do (male / female)"; answer[862] = "hacen";

            question[863] = "To go"; answer[863] = "ir";
            question[864] = "I go"; answer[864] = "voy";
            question[865] = "You go (Informal)"; answer[865] = "vas";
            question[866] = "You go (Formal)"; answer[866] = "va";
            question[867] = "He goes"; answer[867] = "va";
            question[868] = "She goes"; answer[868] = "va";
            question[869] = "We go"; answer[869] = "vamos";
            question[870] = "You go (Inf., Plural, Spain)"; answer[870] = "vais";
            question[871] = "You go (Formal, Plural)"; answer[871] = "van";
            question[872] = "They go (male / female)"; answer[872] = "van";

            question[873] = "All (male, singular)"; answer[873] = "todo";
            question[874] = "All (female, singular)"; answer[874] = "toda";
            question[875] = "All (male, plural)"; answer[875] = "todos";
            question[876] = "All (female, plural)"; answer[876] = "todas";

            question[877] = "Hundred (1-9)"; answer[877] = "ciento";
            question[878] = "Two hundred (male)"; answer[878] = "doscientos";
            question[879] = "Two hundred (female)"; answer[879] = "doscientas";
            question[880] = "Three hundred (male)"; answer[880] = "trescientos";
            question[881] = "Three hundred (female)"; answer[881] = "trescientas";
            question[882] = "Four hundred (male)"; answer[882] = "cuatrocientos";
            question[883] = "Four hundred (female)"; answer[883] = "cuatrocientas";
            question[884] = "Five hundred (male)"; answer[884] = "quinientos";
            question[885] = "Five hundred (female)"; answer[885] = "quinientas";
            question[886] = "Six hundred (male)"; answer[886] = "seiscientos";
            question[887] = "Six hundred (female)"; answer[887] = "seiscientas";
            question[888] = "Seven hundred (male)"; answer[888] = "setecientos";
            question[889] = "Seven hundred (female)"; answer[889] = "setecientas";
            question[890] = "Eight hundred (male)"; answer[890] = "ochocientos";
            question[891] = "Eight hundred (female)"; answer[891] = "ochocientas";
            question[892] = "Nine hundred (male)"; answer[892] = "novecientos";
            question[893] = "Nine hundred (female)"; answer[893] = "novecientas";
            question[894] = "Thousand"; answer[894] = "mil";
            question[895] = "Ten thousand"; answer[895] = "diez mil";
            question[896] = "Hundred thousand"; answer[896] = "cien mil";
            question[897] = "One million"; answer[897] = "un millón";

            question[898] = "My (+ singular)"; answer[898] = "mi";
            question[899] = "My (+ plural)"; answer[899] = "mis";
            question[900] = "Your (Inf., + singular)"; answer[900] = "tu";
            question[901] = "Your (Inf., + plural)"; answer[901] = "tus";
            question[902] = "Your (Formal, + singular)"; answer[902] = "su";
            question[903] = "Your (Formal, + plural)"; answer[903] = "sus";
            question[904] = "His / Her (Formal, + singular)"; answer[904] = "su";
            question[905] = "His / Her (Formal, + plural)"; answer[905] = "sus";
            question[906] = "Our (+ singular, male)"; answer[906] = "nuestro";
            question[907] = "Our (+ singular, female)"; answer[907] = "nuestra";
            question[908] = "Our (+ plural, male)"; answer[908] = "nuestros";
            question[909] = "Our (+ plural, female)"; answer[909] = "nuestras";
            question[910] = "Your (Inf., + singular, Spain, male)"; answer[910] = "vuestro";
            question[911] = "Your (Inf., + singular, Spain, female)"; answer[911] = "vuestra";
            question[912] = "Your (Inf., + plural, Spain, male)"; answer[912] = "vuestros";
            question[913] = "Your (Inf., + plural, Spain, female)"; answer[913] = "vuestras";
            question[914] = "Their (+ singular)"; answer[914] = "su";
            question[915] = "Their (+ plural)"; answer[915] = "sus";

            question[916] = "Beside / Next to"; answer[916] = "al lado";
            question[917] = "To the right"; answer[917] = "a la derecha";
            question[918] = "To the left"; answer[918] = "a la izquierda";
            question[919] = "Nearby / Close to"; answer[919] = "cerca";
            question[920] = "In front"; answer[920] = "delante";
            question[921] = "Behind"; answer[921] = "detrás";
            question[922] = "Facing across"; answer[922] = "enfrente";
            question[923] = "Between"; answer[923] = "entre";
            question[924] = "Far"; answer[924] = "lejos";

            question[925] = "Bored (male)"; answer[925] = "aburrido";
            question[926] = "Bored (female)"; answer[926] = "aburrida";
            question[927] = "Tired (male)"; answer[927] = "cansado";
            question[928] = "Tired (female)"; answer[928] = "cansada";
            question[929] = "Married to (male)"; answer[929] = "casado";
            question[930] = "Married to (female)"; answer[930] = "casada";
            question[931] = "Happy (male)"; answer[931] = "contento";
            question[932] = "Happy (female)"; answer[932] = "contenta";
            question[933] = "In love with (male)"; answer[933] = "enamorado";
            question[934] = "In love with (female)"; answer[934] = "enamorada";
            question[935] = "Sick (male)"; answer[935] = "enfermo";
            question[936] = "Sick (female)"; answer[936] = "enferma";
            question[937] = "Angry (male)"; answer[937] = "enojado";
            question[938] = "Angry (female)"; answer[938] = "enojada";
            question[939] = "Nervous (male)"; answer[939] = "nervioso";
            question[940] = "Nervous (female)"; answer[940] = "nerviosa";
            question[941] = "Busy (male)"; answer[941] = "ocupado";
            question[942] = "Busy (female)"; answer[942] = "ocupada";
            question[943] = "Worried (male)"; answer[943] = "preocupado";
            question[944] = "Worried (female)"; answer[944] = "preocupada";
            question[945] = "Sad"; answer[945] = "triste";

            question[946] = "To be boring (male)"; answer[946] = "ser aburrido";
            question[947] = "To be boring (female)"; answer[947] = "ser aburrida";
            question[948] = "To be pretty (male)"; answer[948] = "ser bonito";
            question[949] = "To be pretty (female)"; answer[949] = "ser bonita";
            question[950] = "To be ugly (male)"; answer[950] = "ser feo";
            question[951] = "To be ugly (female)"; answer[951] = "ser fea";
            question[952] = "To be goodlooking (male)"; answer[952] = "ser guapo";
            question[953] = "To be goodlooking (female)"; answer[953] = "ser guapa";
            question[954] = "To be clever (male)"; answer[954] = "ser listo";
            question[955] = "To be clever (female)"; answer[955] = "ser lista";
            question[956] = "To be bad / evil (male)"; answer[956] = "ser malo";
            question[957] = "To be bad / evil (female)"; answer[957] = "ser mala";
            question[958] = "To be rich (male)"; answer[958] = "ser rico";
            question[959] = "To be rich (female)"; answer[959] = "ser rica";
            question[960] = "To be green"; answer[960] = "ser verde";
            question[961] = "To be smart (male)"; answer[961] = "ser vivo";
            question[962] = "To be smart (female)"; answer[962] = "ser viva";
            question[963] = "To be bored (male)"; answer[963] = "estar aburrido";
            question[964] = "To be bored (female)"; answer[964] = "estar aburrida";
            question[965] = "To look pretty (male)"; answer[965] = "estar bonito";
            question[966] = "To look pretty (female)"; answer[966] = "estar bonita";
            question[967] = "To look ugly (male)"; answer[967] = "estar feo";
            question[968] = "To look ugly (female)"; answer[968] = "estar fea";
            question[969] = "To look good (male)"; answer[969] = "estar guapo";
            question[970] = "To look good (female)"; answer[970] = "estar guapa";
            question[971] = "To be ready (male)"; answer[971] = "estar listo";
            question[972] = "To be ready (female)"; answer[972] = "estar lista";
            question[973] = "To be ill (male)"; answer[973] = "estar malo";
            question[974] = "To be ill (female)"; answer[974] = "estar mala";
            question[975] = "To taste good (male)"; answer[975] = "estar rico";
            question[976] = "To taste good (female)"; answer[976] = "estar rica";
            question[977] = "To look green"; answer[977] = "estar verde";
            question[978] = "To be alive (male)"; answer[978] = "estar vivo";
            question[979] = "To be alive (female)"; answer[979] = "estar viva";

            question[980] = "The grandfather"; answer[980] = "el abuelo";
            question[981] = "The grandmother"; answer[981] = "la abuela";
            question[982] = "The brother-in-law"; answer[982] = "el cuñado";
            question[983] = "The sister-in-law"; answer[983] = "la cuñada";
            question[984] = "The husband"; answer[984] = "el esposo";
            question[985] = "The wife"; answer[985] = "la esposa";
            question[986] = "The stepbrother"; answer[986] = "el hermanastro";
            question[987] = "The stepsister"; answer[987] = "la hermanastra";
            question[988] = "The brother"; answer[988] = "el hermano";
            question[989] = "The sister"; answer[989] = "la hermana";
            question[990] = "The son"; answer[990] = "el hijo";
            question[991] = "The daughter"; answer[991] = "la hija";
            question[992] = "The stepmother"; answer[992] = "la madrastra";
            question[993] = "The mother"; answer[993] = "la madre";
            question[994] = "The grandson"; answer[994] = "el nieto";
            question[995] = "The granddaughter"; answer[995] = "la nieta";
            question[996] = "The boyfriend"; answer[996] = "el novio";
            question[997] = "The girlfriend"; answer[997] = "la novia";
            question[998] = "The daughter-in-law"; answer[998] = "la nuera";
            question[999] = "The stepfather"; answer[999] = "el padrastro";
            question[1000] = "The father"; answer[1000] = "el padre";
            question[1001] = "The dog (male)"; answer[1001] = "el perro";
            question[1002] = "The dog (female)"; answer[1002] = "la perra";
            question[1003] = "The cousin (male)"; answer[1003] = "el primo";
            question[1004] = "The cousin (female)"; answer[1004] = "la prima";
            question[1005] = "The nephew"; answer[1005] = "el sobrino";
            question[1006] = "The niece"; answer[1006] = "la sobrina";
            question[1007] = "The father-in-law"; answer[1007] = "el suegro";
            question[1008] = "The mother-in-law"; answer[1008] = "la suegra";
            question[1009] = "The uncle"; answer[1009] = "el tío";
            question[1010] = "The aunt"; answer[1010] = "la tía";
            question[1011] = "The son-in-law"; answer[1011] = "el yerno";

            question[1012] = "To have lunch"; answer[1012] = "almorzar";
            question[1013] = "I have lunch"; answer[1013] = "almuerzo";
            question[1014] = "You have lunch (Informal)"; answer[1014] = "almuerzas";
            question[1015] = "You have lunch (Formal)"; answer[1015] = "almuerza";
            question[1016] = "He has lunch"; answer[1016] = "almuerza";
            question[1017] = "She has lunch"; answer[1017] = "almuerza";
            question[1018] = "We have lunch"; answer[1018] = "almorzamos";
            question[1019] = "You have lunch (Inf., Plural, Spain)"; answer[1019] = "almorzáis";
            question[1020] = "You have lunch (Formal, Plural)"; answer[1020] = "almuerzan";
            question[1021] = "They have lunch"; answer[1021] = "almuerzan";

            question[1022] = "To cost"; answer[1022] = "costar";
            question[1023] = "I cost"; answer[1023] = "cuesto";
            question[1024] = "You cost (Informal)"; answer[1024] = "cuestas";
            question[1025] = "You cost (Formal)"; answer[1025] = "cuesta";
            question[1026] = "He costs"; answer[1026] = "cuesta";
            question[1027] = "She costs"; answer[1027] = "cuesta";
            question[1028] = "We cost"; answer[1028] = "costamos";
            question[1029] = "You cost (Inf., Plural, Spain)"; answer[1029] = "costáis";
            question[1030] = "You cost (Formal, Plural)"; answer[1030] = "cuestan";
            question[1031] = "They cost"; answer[1031] = "cuestan";

            question[1032] = "To sleep"; answer[1032] = "dormir";
            question[1033] = "I sleep"; answer[1033] = "duermo";
            question[1034] = "You sleep (Informal)"; answer[1034] = "duermes";
            question[1035] = "You sleep (Formal)"; answer[1035] = "duerme";
            question[1036] = "He sleeps"; answer[1036] = "duerme";
            question[1037] = "She sleeps"; answer[1037] = "duerme";
            question[1038] = "We sleep"; answer[1038] = "dormimos";
            question[1039] = "You sleep (Inf., Plural, Spain)"; answer[1039] = "dormís";
            question[1040] = "You sleep (Formal, Plural)"; answer[1040] = "duermen";
            question[1041] = "They sleep"; answer[1041] = "duermen";

            question[1042] = "To begin"; answer[1042] = "empezar";
            question[1043] = "I begin"; answer[1043] = "empiezo";
            question[1044] = "You begin (Informal)"; answer[1044] = "empiezas";
            question[1045] = "You begin (Formal)"; answer[1045] = "empieza";
            question[1046] = "He begins"; answer[1046] = "empieza";
            question[1047] = "She begins"; answer[1047] = "empieza";
            question[1048] = "We begin"; answer[1048] = "empezamos";
            question[1049] = "You begin (Inf., Plural, Spain)"; answer[1049] = "empezáis";
            question[1050] = "You begin (Formal, Plural)"; answer[1050] = "empiezan";
            question[1051] = "They begin"; answer[1051] = "empiezan";

            question[1052] = "To find"; answer[1052] = "encontrar";
            question[1053] = "I find"; answer[1053] = "encuentro";
            question[1054] = "You find (Informal)"; answer[1054] = "encuentras";
            question[1055] = "You find (Formal)"; answer[1055] = "encuentra";
            question[1056] = "He finds"; answer[1056] = "encuentra";
            question[1057] = "She finds"; answer[1057] = "encuentra";
            question[1058] = "We find"; answer[1058] = "encontramos";
            question[1059] = "You find (Inf., Plural, Spain)"; answer[1059] = "encontráis";
            question[1060] = "You find (Formal, Plural)"; answer[1060] = "encuentran";
            question[1061] = "They find"; answer[1061] = "encuentran";

            question[1062] = "To understand"; answer[1062] = "entender";
            question[1063] = "I understand"; answer[1063] = "entiendo";
            question[1064] = "You understand (Informal)"; answer[1064] = "entiendes";
            question[1065] = "You understand (Formal)"; answer[1065] = "entiende";
            question[1066] = "He understands"; answer[1066] = "entiende";
            question[1067] = "She understands"; answer[1067] = "entiende";
            question[1068] = "We understand"; answer[1068] = "entendemos";
            question[1069] = "You understand (Inf., Plural, Spain)"; answer[1069] = "entendéis";
            question[1070] = "You understand (Formal, Plural)"; answer[1070] = "entienden";
            question[1071] = "They understand"; answer[1071] = "entienden";

            question[1072] = "To earn / win"; answer[1072] = "ganar";
            question[1073] = "I earn / win"; answer[1073] = "gano";
            question[1074] = "You earn / win (Informal)"; answer[1074] = "ganas";
            question[1075] = "You earn / win (Formal)"; answer[1075] = "gana";
            question[1076] = "He earns / wins"; answer[1076] = "gana";
            question[1077] = "She earns / wins"; answer[1077] = "gana";
            question[1078] = "We earn / win"; answer[1078] = "ganamos";
            question[1079] = "You earn / win (Inf., Plural, Spain)"; answer[1079] = "ganáis";
            question[1080] = "You earn / win (Formal, Plural)"; answer[1080] = "ganan";
            question[1081] = "They earn / win"; answer[1081] = "ganan";

            question[1082] = "To play"; answer[1082] = "jugar";
            question[1083] = "I play"; answer[1083] = "juego";
            question[1084] = "You play (Informal)"; answer[1084] = "juegas";
            question[1085] = "You play (Formal)"; answer[1085] = "juega";
            question[1086] = "He plays"; answer[1086] = "juega";
            question[1087] = "She plays"; answer[1087] = "juega";
            question[1088] = "We play"; answer[1088] = "jugamos";
            question[1089] = "You play (Inf., Plural, Spain)"; answer[1089] = "jugáis";
            question[1090] = "You play (Formal, Plural)"; answer[1090] = "juegan";
            question[1091] = "They play"; answer[1091] = "juegan";

            question[1092] = "To spend time"; answer[1092] = "pasar";
            question[1093] = "I spend time"; answer[1093] = "paso";
            question[1094] = "You spend time (Informal)"; answer[1094] = "pasas";
            question[1095] = "You spend time (Formal)"; answer[1095] = "pasa";
            question[1096] = "He spends time"; answer[1096] = "pasa";
            question[1097] = "She spends time"; answer[1097] = "pasa";
            question[1098] = "We spend time"; answer[1098] = "pasamos";
            question[1099] = "You spend time (Inf., Plural, Spain)"; answer[1099] = "pasáis";
            question[1100] = "You spend time (Formal, Plural)"; answer[1100] = "pasan";
            question[1101] = "They spend time"; answer[1101] = "pasan";

            question[1102] = "To think about"; answer[1102] = "pensar";
            question[1103] = "I think about"; answer[1103] = "pienso";
            question[1104] = "You think about (Informal)"; answer[1104] = "piensas";
            question[1105] = "You think about (Formal)"; answer[1105] = "piensa";
            question[1106] = "He thinks about"; answer[1106] = "piensa";
            question[1107] = "She thinks about"; answer[1107] = "piensa";
            question[1108] = "We think about"; answer[1108] = "pensamos";
            question[1109] = "You think about (Inf., Plural, Spain)"; answer[1109] = "pensáis";
            question[1110] = "You think about (Formal, Plural)"; answer[1110] = "piensan";
            question[1111] = "They think about"; answer[1111] = "piensan";

            question[1112] = "To request"; answer[1112] = "pedir";
            question[1113] = "I request"; answer[1113] = "pido";
            question[1114] = "You request (Informal)"; answer[1114] = "pides";
            question[1115] = "You request (Formal)"; answer[1115] = "pide";
            question[1116] = "He requests"; answer[1116] = "pide";
            question[1117] = "She requests"; answer[1117] = "pide";
            question[1118] = "We request"; answer[1118] = "pedimos";
            question[1119] = "You request (Inf., Plural, Spain)"; answer[1119] = "pedís";
            question[1120] = "You request (Formal, Plural)"; answer[1120] = "piden";
            question[1121] = "They request"; answer[1121] = "piden";

            question[1122] = "To lose"; answer[1122] = "perder";
            question[1123] = "I lose"; answer[1123] = "pierdo";
            question[1124] = "You lose (Informal)"; answer[1124] = "pierdes";
            question[1125] = "You lose (Formal)"; answer[1125] = "pierde";
            question[1126] = "He loses"; answer[1126] = "pierde";
            question[1127] = "She loses"; answer[1127] = "pierde";
            question[1128] = "We lose"; answer[1128] = "perdemos";
            question[1129] = "You lose (Inf., Plural, Spain)"; answer[1129] = "perdéis";
            question[1130] = "You lose (Formal, Plural)"; answer[1130] = "pierden";
            question[1131] = "They lose"; answer[1131] = "pierden";

            question[1132] = "To can"; answer[1132] = "poder";
            question[1133] = "I can"; answer[1133] = "puedo";
            question[1134] = "You can (Informal)"; answer[1134] = "puedes";
            question[1135] = "You can (Formal)"; answer[1135] = "puede";
            question[1136] = "He can"; answer[1136] = "puede";
            question[1137] = "She can"; answer[1137] = "puede";
            question[1138] = "We can"; answer[1138] = "podemos";
            question[1139] = "You can (Inf., Plural, Spain)"; answer[1139] = "podéis";
            question[1140] = "You can (Formal, Plural)"; answer[1140] = "pueden";
            question[1141] = "They can"; answer[1141] = "pueden";

            question[1142] = "To prefer"; answer[1142] = "preferir";
            question[1143] = "I prefer"; answer[1143] = "prefiero";
            question[1144] = "You prefer (Informal)"; answer[1144] = "prefieres";
            question[1145] = "You prefer (Formal)"; answer[1145] = "prefiere";
            question[1146] = "He prefers"; answer[1146] = "prefiere";
            question[1147] = "She prefers"; answer[1147] = "prefiere";
            question[1148] = "We prefer"; answer[1148] = "preferimos";
            question[1149] = "You prefer (Inf., Plural, Spain)"; answer[1149] = "preferís";
            question[1150] = "You prefer (Formal, Plural)"; answer[1150] = "prefieren";
            question[1151] = "They prefer"; answer[1151] = "prefieren";

            question[1152] = "To want"; answer[1152] = "querer";
            question[1153] = "I want"; answer[1153] = "quiero";
            question[1154] = "You want (Informal)"; answer[1154] = "quieres";
            question[1155] = "You want (Formal)"; answer[1155] = "quiere";
            question[1156] = "He wants"; answer[1156] = "quiere";
            question[1157] = "She wants"; answer[1157] = "quiere";
            question[1158] = "We want"; answer[1158] = "queremos";
            question[1159] = "You want (Inf., Plural, Spain)"; answer[1159] = "queréis";
            question[1160] = "You want (Formal, Plural)"; answer[1160] = "quieren";
            question[1161] = "They want"; answer[1161] = "quieren";

            question[1162] = "To remember"; answer[1162] = "recordar";
            question[1163] = "I remember"; answer[1163] = "recuerdo";
            question[1164] = "You remember (Informal)"; answer[1164] = "recuerdas";
            question[1165] = "You remember (Formal)"; answer[1165] = "recuerda";
            question[1166] = "He remembers"; answer[1166] = "recuerda";
            question[1167] = "She remembers"; answer[1167] = "recuerda";
            question[1168] = "We remember"; answer[1168] = "recordamos";
            question[1169] = "You remember (Inf., Plural, Spain)"; answer[1169] = "recordáis";
            question[1170] = "You remember (Formal, Plural)"; answer[1170] = "recuerdan";
            question[1171] = "They remember"; answer[1171] = "recuerdan";

            question[1172] = "To repeat"; answer[1172] = "repetir";
            question[1173] = "I repeat"; answer[1173] = "repito";
            question[1174] = "You repeat (Informal)"; answer[1174] = "repites";
            question[1175] = "You repeat (Formal)"; answer[1175] = "repite";
            question[1176] = "He repeats"; answer[1176] = "repite";
            question[1177] = "She repeats"; answer[1177] = "repite";
            question[1178] = "We repeat"; answer[1178] = "repetimos";
            question[1179] = "You repeat (Inf., Plural, Spain)"; answer[1179] = "repetís";
            question[1180] = "You repeat (Formal, Plural)"; answer[1180] = "repiten";
            question[1181] = "They repeat"; answer[1181] = "repiten";

            question[1182] = "To serve"; answer[1182] = "servir";
            question[1183] = "I serve"; answer[1183] = "sirvo";
            question[1184] = "You serve (Informal)"; answer[1184] = "sirves";
            question[1185] = "You serve (Formal)"; answer[1185] = "sirve";
            question[1186] = "He serves"; answer[1186] = "sirve";
            question[1187] = "She serves"; answer[1187] = "sirve";
            question[1188] = "We serve"; answer[1188] = "servimos";
            question[1189] = "You serve (Inf., Plural, Spain)"; answer[1189] = "servís";
            question[1190] = "You serve (Formal, Plural)"; answer[1190] = "sirven";
            question[1191] = "They serve"; answer[1191] = "sirven";

            question[1192] = "To dream about"; answer[1192] = "soñar";
            question[1193] = "I dream about"; answer[1193] = "sueño";
            question[1194] = "You dream about (Informal)"; answer[1194] = "sueñas";
            question[1195] = "You dream about (Formal)"; answer[1195] = "sueña";
            question[1196] = "He dreams about"; answer[1196] = "sueña";
            question[1197] = "She dreams about"; answer[1197] = "sueña";
            question[1198] = "We dream about"; answer[1198] = "soñamos";
            question[1199] = "You dream about (Inf., Plural, Spain)"; answer[1199] = "soñáis";
            question[1200] = "You dream about (Formal, Plural)"; answer[1200] = "sueñan";
            question[1201] = "They dream about"; answer[1201] = "sueñan";

            question[1202] = "To come"; answer[1202] = "venir";
            question[1203] = "I come"; answer[1203] = "vengo";
            question[1204] = "You come (Informal)"; answer[1204] = "vienes";
            question[1205] = "You come (Formal)"; answer[1205] = "viene";
            question[1206] = "He comes"; answer[1206] = "viene";
            question[1207] = "She comes"; answer[1207] = "viene";
            question[1208] = "We come"; answer[1208] = "venimos";
            question[1209] = "You come (Inf., Plural, Spain)"; answer[1209] = "venís";
            question[1210] = "You come (Formal, Plural)"; answer[1210] = "vienen";
            question[1211] = "They come"; answer[1211] = "vienen";

            question[1212] = "To return"; answer[1212] = "volver";
            question[1213] = "I return"; answer[1213] = "vuelvo";
            question[1214] = "You return (Informal)"; answer[1214] = "vuelves";
            question[1215] = "You return (Formal)"; answer[1215] = "vuelve";
            question[1216] = "He returns"; answer[1216] = "vuelve";
            question[1217] = "She returns"; answer[1217] = "vuelve";
            question[1218] = "We return"; answer[1218] = "volvemos";
            question[1219] = "You return (Inf., Plural, Spain)"; answer[1219] = "volvéis";
            question[1220] = "You return (Formal, Plural)"; answer[1220] = "vuelven";
            question[1221] = "They return"; answer[1221] = "vuelven";

            question[1222] = "To know (Someone)"; answer[1222] = "conocer";
            question[1223] = "I know (Someone)"; answer[1223] = "conozco";
            question[1224] = "You know (Informal, Someone)"; answer[1224] = "conoces";
            question[1225] = "You know (Formal, Someone)"; answer[1225] = "conoce";
            question[1226] = "He knows (Someone)"; answer[1226] = "conoce";
            question[1227] = "She knows (Someone)"; answer[1227] = "conoce";
            question[1228] = "We know (Someone)"; answer[1228] = "conocemos";
            question[1229] = "You know (Inf., Plural, Spain, Someone)"; answer[1229] = "conocéis";
            question[1230] = "You know (Formal, Plural, Someone)"; answer[1230] = "conocen";
            question[1231] = "They know (Someone)"; answer[1231] = "conocen";

            question[1232] = "To invite"; answer[1232] = "invitar";
            question[1233] = "I invite"; answer[1233] = "invito";
            question[1234] = "You invite (Informal)"; answer[1234] = "invitas";
            question[1235] = "You invite (Formal)"; answer[1235] = "invita";
            question[1236] = "He invites"; answer[1236] = "invita";
            question[1237] = "She invites"; answer[1237] = "invita";
            question[1238] = "We invite"; answer[1238] = "invitamos";
            question[1239] = "You invite (Inf., Plural, Spain)"; answer[1239] = "invitáis";
            question[1240] = "You invite (Formal, Plural)"; answer[1240] = "invitan";
            question[1241] = "They invite"; answer[1241] = "invitan";

            question[1242] = "To take a walk"; answer[1242] = "pasear";
            question[1243] = "I take a walk"; answer[1243] = "paseo";
            question[1244] = "You take a walk (Informal)"; answer[1244] = "paseas";
            question[1245] = "You take a walk (Formal)"; answer[1245] = "pasea";
            question[1246] = "He takes a walk"; answer[1246] = "pasea";
            question[1247] = "She takes a walk"; answer[1247] = "pasea";
            question[1248] = "We take a walk"; answer[1248] = "paseamos";
            question[1249] = "You take a walk (Inf., Plural, Spain)"; answer[1249] = "paseáis";
            question[1250] = "You take a walk (Formal, Plural)"; answer[1250] = "pasean";
            question[1251] = "They take a walk"; answer[1251] = "pasean";

            question[1252] = "To put"; answer[1252] = "poner";
            question[1253] = "I put"; answer[1253] = "pongo";
            question[1254] = "You put (Informal)"; answer[1254] = "pones";
            question[1255] = "You put (Formal)"; answer[1255] = "pone";
            question[1256] = "He puts"; answer[1256] = "pone";
            question[1257] = "She puts"; answer[1257] = "pone";
            question[1258] = "We put"; answer[1258] = "ponemos";
            question[1259] = "You put (Inf., Plural, Spain)"; answer[1259] = "ponéis";
            question[1260] = "You put (Formal, Plural)"; answer[1260] = "ponen";
            question[1261] = "They put"; answer[1261] = "ponen";

            question[1262] = "To know (Something)"; answer[1262] = "saber";
            question[1263] = "I know (Something)"; answer[1263] = "sé";
            question[1264] = "You know (Informal, Something)"; answer[1264] = "sabes";
            question[1265] = "You know (Formal, Something)"; answer[1265] = "sabe";
            question[1266] = "He knows (Something)"; answer[1266] = "sabe";
            question[1267] = "She knows (Something)"; answer[1267] = "sabe";
            question[1268] = "We know (Something)"; answer[1268] = "sabemos";
            question[1269] = "You know (Inf., Plural, Spain, Something)"; answer[1269] = "sabéis";
            question[1270] = "You know (Formal, Plural, Something)"; answer[1270] = "saben";
            question[1271] = "They know (Something)"; answer[1271] = "saben";

            question[1272] = "To leave"; answer[1272] = "salir";
            question[1273] = "I leave"; answer[1273] = "salgo";
            question[1274] = "You leave (Informal)"; answer[1274] = "sales";
            question[1275] = "You leave (Formal)"; answer[1275] = "sale";
            question[1276] = "He leaves"; answer[1276] = "sale";
            question[1277] = "She leaves"; answer[1277] = "sale";
            question[1278] = "We leave"; answer[1278] = "salimos";
            question[1279] = "You leave (Inf., Plural, Spain)"; answer[1279] = "salís";
            question[1280] = "You leave (Formal, Plural)"; answer[1280] = "salen";
            question[1281] = "They leave"; answer[1281] = "salen";

            question[1282] = "To play an instrument"; answer[1282] = "tocar";
            question[1283] = "I play an instrument"; answer[1283] = "toco";
            question[1284] = "You play an instrument (Informal)"; answer[1284] = "tocas";
            question[1285] = "You play an instrument (Formal)"; answer[1285] = "toca";
            question[1286] = "He plays an instrument"; answer[1286] = "toca";
            question[1287] = "She plays an instrument"; answer[1287] = "toca";
            question[1288] = "We play an instrument"; answer[1288] = "tocamos";
            question[1289] = "You play an instrument (Inf., Plural, Spain)"; answer[1289] = "tocáis";
            question[1290] = "You play an instrument (Formal, Plural)"; answer[1290] = "tocan";
            question[1291] = "They play an instrument"; answer[1291] = "tocan";

            question[1292] = "To bring"; answer[1292] = "traer";
            question[1293] = "I bring"; answer[1293] = "traigo";
            question[1294] = "You bring (Informal)"; answer[1294] = "traes";
            question[1295] = "You bring (Formal)"; answer[1295] = "trae";
            question[1296] = "He brings"; answer[1296] = "trae";
            question[1297] = "She brings"; answer[1297] = "trae";
            question[1298] = "We bring"; answer[1298] = "traemos";
            question[1299] = "You bring (Inf., Plural, Spain)"; answer[1299] = "traéis";
            question[1300] = "You bring (Formal, Plural)"; answer[1300] = "traen";
            question[1301] = "They bring"; answer[1301] = "traen";

            question[1302] = "Married (male)"; answer[1302] = "casado";
            question[1303] = "Married (female)"; answer[1303] = "casada";
            question[1304] = "Divorced (male)"; answer[1304] = "divorciado";
            question[1305] = "Divorced (female)"; answer[1305] = "divorciada";
            question[1306] = "Older"; answer[1306] = "mayor";
            question[1307] = "Younger"; answer[1307] = "menor";
            question[1308] = "Single (male)"; answer[1308] = "soltero";
            question[1309] = "Single (female)"; answer[1309] = "soltera";
            question[1310] = "Close (male)"; answer[1310] = "unido";
            question[1311] = "Close (female)"; answer[1311] = "unida";

            question[1312] = "Someday"; answer[1312] = "algún día";
            question[1313] = "The food"; answer[1313] = "la comida";
            question[1314] = "With me"; answer[1314] = "conmigo";
            question[1315] = "With you"; answer[1315] = "contigo";
            question[1316] = "The soft drink"; answer[1316] = "el refresco";

            question[1317] = "The cafe"; answer[1317] = "el café";
            question[1318] = "The outdoor cafe"; answer[1318] = "el café al aire libre";
            question[1319] = "The downtown"; answer[1319] = "el centro";
            question[1320] = "The movie theater"; answer[1320] = "el cine";
            question[1321] = "The concert"; answer[1321] = "el concierto";
            question[1322] = "The admission ticket"; answer[1322] = "la entrada";
            question[1323] = "The show"; answer[1323] = "la función";
            question[1324] = "The orchestra"; answer[1324] = "la orquesta";
            question[1325] = "The park"; answer[1325] = "el parque";
            question[1326] = "The game"; answer[1326] = "el partido";
            question[1327] = "The movie"; answer[1327] = "la película";

            question[1328] = "How about...?"; answer[1328] = "¿qué tal si...?";
            question[1329] = "Do you want to go to...?"; answer[1329] = "¿quieres ir a...?";
            question[1330] = "Would you like...?"; answer[1330] = "¿te gustaría...?";
            question[1331] = "Should we go...?"; answer[1331] = "¿vamos a...?";

            question[1332] = "Fine with me"; answer[1332] = "de acuerdo";
            question[1333] = "I would love to"; answer[1333] = "me encantaría";
            question[1334] = "I'll pick you up"; answer[1334] = "paso por ti";
            question[1335] = "Yes, of course"; answer[1335] = "sí, claro";

            question[1336] = "I'm very busy (male)"; answer[1336] = "estoy muy ocupado";
            question[1337] = "I'm very busy (female)"; answer[1337] = "estoy muy ocupada";
            question[1338] = "Thanks, but I can't"; answer[1338] = "gracias, pero no puedo";
            question[1339] = "I'm sorry, I have to..."; answer[1339] = "lo siento, tengo que...";

            question[1340] = "Me (direct object pronoun)"; answer[1340] = "me";
            question[1341] = "You (Inf., direct object pronoun)"; answer[1341] = "te";
            question[1342] = "You (Formal, male, direct object pronoun)"; answer[1342] = "lo";
            question[1343] = "You (Formal, female, direct object pronoun)"; answer[1343] = "la";
            question[1344] = "Him (direct object pronoun)"; answer[1344] = "lo";
            question[1345] = "Her (direct object pronoun)"; answer[1345] = "la";
            question[1346] = "Us (direct object pronoun)"; answer[1346] = "nos";
            question[1347] = "You (Inf., Plural, Spain, direct object pronoun)"; answer[1347] = "os";
            question[1348] = "You (Formal, male, Plural, direct object pronoun)"; answer[1348] = "los";
            question[1349] = "You (Formal, female, Plural, direct object pronoun)"; answer[1349] = "las";
            question[1350] = "Them (male, direct object pronoun)"; answer[1350] = "los";
            question[1351] = "Them (male, direct object pronoun)"; answer[1351] = "las";

            question[1352] = "this (male)"; answer[1352] = "este";
            question[1353] = "this (female)"; answer[1353] = "esta";
            question[1354] = "that (close to, male)"; answer[1354] = "ese";
            question[1355] = "that (close to, female)"; answer[1355] = "esa";
            question[1356] = "that (over there, male)"; answer[1356] = "aquel";
            question[1357] = "that (over there, female)"; answer[1357] = "aquella";
            question[1358] = "these (male)"; answer[1358] = "estos";
            question[1359] = "these (female)"; answer[1359] = "estas";
            question[1360] = "those (close to, male)"; answer[1360] = "esos";
            question[1361] = "those (close to, female)"; answer[1361] = "esas";
            question[1362] = "those (over there, male)"; answer[1362] = "aquellos";
            question[1363] = "those (over there, female)"; answer[1363] = "aquellas";
            question[1364] = "here"; answer[1364] = "aquí";
            question[1365] = "there"; answer[1365] = "allí";
            question[1366] = "over there"; answer[1366] = "allá";

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch4FinalGame()
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
