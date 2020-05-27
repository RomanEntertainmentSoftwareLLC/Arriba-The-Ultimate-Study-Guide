using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arriba_Ultimate_Study_Guide
{
    public class Ch1TranslationGame
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
            numberOfQuestions = 268;
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

            order = new int[numberOfQuestions];
            randomOrder = new int[numberOfQuestions];

            for (int i = 0; i < numberOfQuestions; i++)
            {
                order[i] = i;
                randomOrder[i] = i;
            }
        }

        public Ch1TranslationGame()
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
            if(index >= 0 && index < numberOfQuestions)
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
