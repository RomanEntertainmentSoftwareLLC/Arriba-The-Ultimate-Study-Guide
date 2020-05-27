using Arriba_Ultimate_Study_Guide.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using SharpDX.XAudio2;
using SharpDX.Multimedia;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace Arriba_Ultimate_Study_Guide
{
    public partial class frmMain : Form
    {
        private bool soundEnabled = true;
        private bool enterKeyPressed = false;
        private bool insideOkButton = false;
        private bool insideExitButton = false;
        private bool insideMinimizeButton = false;
        private bool insideSoundButton = false;
        private bool insideResultsButton = false;
        private bool insideForwardButton = false;
        private bool insideBackButton = false;
        private bool chapter1Enabled = false;
        private bool chapter2Enabled = false;
        private bool chapter3Enabled = false;
        private bool chapter4Enabled = false;

        private bool ch1TranslationGameEnabled = false;
        private bool ch1PhotoGameEnabled = false;
        private bool ch1LetterGameEnabled = false;
        private bool ch1NumberGameEnabled = false;
        private bool ch1ColorGameEnabled = false;
        private bool ch1DaysOfTheWeekGameEnabled = false;
        private bool ch1MonthsOfTheYearGameEnabled = false;
        private bool ch1SeasonsOfTheYearGameEnabled = false;

        private bool ch2TranslationGameEnabled = false;
        private bool ch2PhotoGameEnabled = false;
        private bool ch2NationalitiesGameEnabled = false;
        private bool ch2WhatTimeIsItGameEnabled = false;
        private bool ch2VerbsGameEnabled = false;
        private bool ch2InterrogativeWordsGameEnabled = false;
        private bool ch2CountriesGameEnabled = false;
        private bool ch2ILikeYouLikeGameEnabled = false;

        private bool ch3TranslationGameEnabled = false;
        private bool ch3PhotoGameEnabled = false;
        private bool ch3ScheduleGameEnabled = false;
        private bool ch3BigNumbersGameEnabled = false;
        private bool ch3BuildingsGameEnabled = false;
        private bool ch3PronounsGameEnabled = false;
        private bool ch3WhereIsItGameEnabled = false;
        private bool ch3VerbsGameEnabled = false;

        private bool ch4TranslationGameEnabled = false;
        private bool ch4PhotoGameEnabled = false;
        private bool ch4MembersOfTheFamilyGameEnabled = false;
        private bool ch4VerbsGameEnabled = false;
        private bool ch4AdjetivesGameEnabled = false;
        private bool ch4PlacesToGoGameEnabled = false;
        private bool ch4FinalGameEnabled = false;

        private int ch1Score;
        private int ch2Score;
        private int ch3Score;
        private int ch4Score;

        private int ch1TotalScore;
        private int ch2TotalScore;
        private int ch3TotalScore;
        private int ch4TotalScore;

        private int score;
        private int totalScore;

        private XAudio2 xaudio;
        private Assembly assembly;

        private AudioBuffer beep2_buffer;
        private SoundStream beep2_soundstream;
        private SourceVoice beep2_voice;
        private WaveFormat beep2_waveFormat;

        private AudioBuffer nanoblade_buffer;
        private SoundStream nanoblade_soundstream;
        private SourceVoice nanoblade_voice;
        private WaveFormat nanoblade_waveFormat;

        private AudioBuffer applause_buffer;
        private SoundStream applause_soundstream;
        private SourceVoice applause_voice;
        private WaveFormat applause_waveFormat;

        private AudioBuffer wrong_buffer;
        private SoundStream wrong_soundstream;
        private SourceVoice wrong_voice;
        private WaveFormat wrong_waveFormat;

        private Ch1TranslationGame ch1TranslationGame;
        private Ch1PhotoGame ch1PhotoGame;
        private Ch1LetterGame ch1LetterGame;
        private Ch1NumberGame ch1NumberGame;
        private Ch1ColorGame ch1ColorGame;
        private Ch1DaysOfTheWeekGame ch1DaysOfTheWeekGame;
        private Ch1MonthsOfTheYearGame ch1MonthsOfTheYearGame;
        private Ch1SeasonsOfTheYearGame ch1SeasonsOfTheYearGame;

        private Ch2TranslationGame ch2TranslationGame;
        private Ch2PhotoGame ch2PhotoGame;
        private Ch2NationalitiesGame ch2NationalitiesGame;
        private Ch2WhatTimeIsItGame ch2WhatTimeIsItGame;
        private Ch2VerbsGame ch2VerbsGame;
        private Ch2InterrogativeWordsGame ch2InterrogativeWordsGame;
        private Ch2CountriesGame ch2CountriesGame;
        private Ch2ILikeYouLikeGame ch2ILikeYouLikeGame;

        private Ch3TranslationGame ch3TranslationGame;
        private Ch3PhotoGame ch3PhotoGame;
        private Ch3ScheduleGame ch3ScheduleGame;
        private Ch3BigNumbersGame ch3BigNumbersGame;
        private Ch3BuildingsGame ch3BuildingsGame;
        private Ch3PronounsGame ch3PronounsGame;
        private Ch3WhereIsItGame ch3WhereIsItGame;
        private Ch3VerbsGame ch3VerbsGame;

        private Ch4TranslationGame ch4TranslationGame;
        private Ch4PhotoGame ch4PhotoGame;
        private Ch4MembersOfTheFamilyGame ch4MembersOfTheFamilyGame;
        private Ch4VerbsGame ch4VerbsGame;
        private Ch4AdjetivesGame ch4AdjetivesGame;
        private Ch4PlacesToGoGame ch4PlacesToGoGame;
        private Ch4FinalGame ch4FinalGame;

        readonly PrivateFontCollection pfcLight = new PrivateFontCollection();
        readonly PrivateFontCollection pfcLightItalic = new PrivateFontCollection();

        public frmMain()
        {
            InitializeComponent();
        }

        private void EndProgram()
        {
            Application.Exit();
        }
        
        public void WriteToBinaryFile(string filePath)
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Create))
            {
                using (BinaryWriter w = new BinaryWriter(fs))
                {
                    try
                    {
                        for (int i = 0; i < ch1TranslationGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch1TranslationGame.mastered[i] == true)
                            {
                                w.Write("true");
                            }
                            else
                            {
                                w.Write("false");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Cannot write ch1TranslationGame to file");
                    }

                    try
                    {
                        for (int i = 0; i < ch1PhotoGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch1PhotoGame.mastered[i] == true)
                            {
                                w.Write("true");
                            }
                            else
                            {
                                w.Write("false");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Cannot write ch1PhotoGame to file");
                    }


                    for (int i = 0; i < ch1LetterGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch1LetterGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch1NumberGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch1NumberGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch1ColorGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch1ColorGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch1DaysOfTheWeekGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch1DaysOfTheWeekGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch1MonthsOfTheYearGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch1MonthsOfTheYearGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    try
                    {
                        for (int i = 0; i < ch1SeasonsOfTheYearGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch1SeasonsOfTheYearGame.mastered[i] == true)
                            {
                                w.Write("true");
                            }
                            else
                            {
                                w.Write("false");
                            }
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Cannot write ch1SeasonsOfTheYearGame to file");
                    }


                    /////////////////////////////////////////////////////////////////////////
                    
                    for (int i = 0; i < ch2TranslationGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch2TranslationGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch2PhotoGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch2PhotoGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch2NationalitiesGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch2NationalitiesGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch2WhatTimeIsItGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch2WhatTimeIsItGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch2VerbsGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch2VerbsGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch2InterrogativeWordsGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch2InterrogativeWordsGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch2CountriesGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch2CountriesGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch2ILikeYouLikeGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch2ILikeYouLikeGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    /////////////////////////////////////////////////////////////////////////
                    
                    for (int i = 0; i < ch3TranslationGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch3TranslationGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch3PhotoGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch3PhotoGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch3ScheduleGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch3ScheduleGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch3BigNumbersGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch3BigNumbersGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch3BuildingsGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch3BuildingsGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch3PronounsGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch3PronounsGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch3WhereIsItGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch3WhereIsItGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch3VerbsGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch3VerbsGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    /////////////////////////////////////////////////////////////////////////
                    
                    for (int i = 0; i < ch4TranslationGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch4TranslationGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch4PhotoGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch4PhotoGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch4MembersOfTheFamilyGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch4MembersOfTheFamilyGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch4VerbsGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch4VerbsGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch4AdjetivesGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch4AdjetivesGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch4PlacesToGoGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch4PlacesToGoGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }

                    for (int i = 0; i < ch4FinalGame.Get_Number_Of_Questions(); i++)
                    {
                        if (ch4FinalGame.mastered[i] == true)
                        {
                            w.Write("true");
                        }
                        else
                        {
                            w.Write("false");
                        }
                    }
                }
            }
        }

        public void ReadFromBinaryFile(string filePath)
        {
            string temp;

            if (File.Exists(filePath))
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader r = new BinaryReader(fs))
                    {
                        for (int i = 0; i < ch1TranslationGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch1TranslationGame.mastered[i] = true;
                            }
                            else
                            {
                                ch1TranslationGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch1PhotoGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch1PhotoGame.mastered[i] = true;
                            }
                            else
                            {
                                ch1PhotoGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch1LetterGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch1LetterGame.mastered[i] = true;
                            }
                            else
                            {
                                ch1LetterGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch1NumberGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch1NumberGame.mastered[i] = true;
                            }
                            else
                            {
                                ch1NumberGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch1ColorGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch1ColorGame.mastered[i] = true;
                            }
                            else
                            {
                                ch1ColorGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch1DaysOfTheWeekGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch1DaysOfTheWeekGame.mastered[i] = true;
                            }
                            else
                            {
                                ch1DaysOfTheWeekGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch1MonthsOfTheYearGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch1MonthsOfTheYearGame.mastered[i] = true;
                            }
                            else
                            {
                                ch1MonthsOfTheYearGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch1SeasonsOfTheYearGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch1SeasonsOfTheYearGame.mastered[i] = true;
                            }
                            else
                            {
                                ch1SeasonsOfTheYearGame.mastered[i] = false;
                            }
                        }

                        /////////////////////////////////////////////////////////////////////////

                        for (int i = 0; i < ch2TranslationGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch2TranslationGame.mastered[i] = true;
                            }
                            else
                            {
                                ch2TranslationGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch2PhotoGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch2PhotoGame.mastered[i] = true;
                            }
                            else
                            {
                                ch2PhotoGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch2NationalitiesGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch2NationalitiesGame.mastered[i] = true;
                            }
                            else
                            {
                                ch2NationalitiesGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch2WhatTimeIsItGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch2WhatTimeIsItGame.mastered[i] = true;
                            }
                            else
                            {
                                ch2WhatTimeIsItGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch2VerbsGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch2VerbsGame.mastered[i] = true;
                            }
                            else
                            {
                                ch2VerbsGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch2InterrogativeWordsGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch2InterrogativeWordsGame.mastered[i] = true;
                            }
                            else
                            {
                                ch2InterrogativeWordsGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch2CountriesGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch2CountriesGame.mastered[i] = true;
                            }
                            else
                            {
                                ch2CountriesGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch2ILikeYouLikeGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch2ILikeYouLikeGame.mastered[i] = true;
                            }
                            else
                            {
                                ch2ILikeYouLikeGame.mastered[i] = false;
                            }
                        }

                        /////////////////////////////////////////////////////////////////////////

                        for (int i = 0; i < ch3TranslationGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch3TranslationGame.mastered[i] = true;
                            }
                            else
                            {
                                ch3TranslationGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch3PhotoGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch3PhotoGame.mastered[i] = true;
                            }
                            else
                            {
                                ch3PhotoGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch3ScheduleGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch3ScheduleGame.mastered[i] = true;
                            }
                            else
                            {
                                ch3ScheduleGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch3BigNumbersGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch3BigNumbersGame.mastered[i] = true;
                            }
                            else
                            {
                                ch3BigNumbersGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch3BuildingsGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch3BuildingsGame.mastered[i] = true;
                            }
                            else
                            {
                                ch3BuildingsGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch3PronounsGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch3PronounsGame.mastered[i] = true;
                            }
                            else
                            {
                                ch3PronounsGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch3WhereIsItGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch3WhereIsItGame.mastered[i] = true;
                            }
                            else
                            {
                                ch3WhereIsItGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch3VerbsGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch3VerbsGame.mastered[i] = true;
                            }
                            else
                            {
                                ch3VerbsGame.mastered[i] = false;
                            }
                        }

                        /////////////////////////////////////////////////////////////////////////

                        for (int i = 0; i < ch4TranslationGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch4TranslationGame.mastered[i] = true;
                            }
                            else
                            {
                                ch4TranslationGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch4PhotoGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch4PhotoGame.mastered[i] = true;
                            }
                            else
                            {
                                ch4PhotoGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch4MembersOfTheFamilyGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch4MembersOfTheFamilyGame.mastered[i] = true;
                            }
                            else
                            {
                                ch4MembersOfTheFamilyGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch4VerbsGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch4VerbsGame.mastered[i] = true;
                            }
                            else
                            {
                                ch4VerbsGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch4AdjetivesGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch4AdjetivesGame.mastered[i] = true;
                            }
                            else
                            {
                                ch4AdjetivesGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch4PlacesToGoGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch4PlacesToGoGame.mastered[i] = true;

                            }
                            else
                            {
                                ch4PlacesToGoGame.mastered[i] = false;
                            }
                        }

                        for (int i = 0; i < ch4FinalGame.Get_Number_Of_Questions(); i++)
                        {
                            temp = r.ReadString();
                            if (temp == "true")
                            {
                                ch4FinalGame.mastered[i] = true;

                            }
                            else
                            {
                                ch4FinalGame.mastered[i] = false;
                            }
                        }

                    }
                }
            }
            else
            {
                WriteToBinaryFile("score.dat");
            }
        }

        private void picExit_MouseMove(object sender, MouseEventArgs e)
        {
            if (insideExitButton == false)
            {
                insideExitButton = true;
                Image imgExitButton2 = Resources.Exit_Button_2;
                picExit.BackgroundImage = imgExitButton2;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void picExit_MouseLeave(object sender, EventArgs e)
        {
            insideExitButton = false;
            Image imgExitButton = Resources.Exit_Button;
            picExit.BackgroundImage = imgExitButton;
        }

        private void picExit_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Image imgExitButton3 = Resources.Exit_Button_3;
                picExit.BackgroundImage = imgExitButton3;
            }
        }

        private void picExit_MouseUp(object sender, MouseEventArgs e)
        {
            if (insideExitButton == true)
            {
                Image imgExitButton2 = Resources.Exit_Button_2;
                picExit.BackgroundImage = imgExitButton2;
                if (e.Button == MouseButtons.Left)
                {
                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }

                    WriteToBinaryFile("score.dat");

                    EndProgram();
                }
            }
            else
            {
                Image imgExitButton = Resources.Exit_Button;
                picExit.BackgroundImage = imgExitButton;
            }
        }

        private void picMinimize_MouseMove(object sender, MouseEventArgs e)
        {
            if (insideMinimizeButton == false)
            {
                insideMinimizeButton = true;
                Image imgMinimizeButton2 = Resources.Minimize_Button_2;
                picMinimize.BackgroundImage = imgMinimizeButton2;

                if(soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void picMinimize_MouseLeave(object sender, EventArgs e)
        {
            insideMinimizeButton = false;
            Image imgMinimizeButton = Resources.Minimize_Button;
            picMinimize.BackgroundImage = imgMinimizeButton;
        }

        private void picMinimize_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Image imgMinimizeButton3 = Resources.Minimize_Button_3;
                picMinimize.BackgroundImage = imgMinimizeButton3;
            }
        }

        private void picMinimize_MouseUp(object sender, MouseEventArgs e)
        {
            if (insideMinimizeButton == true)
            {
                Image imgMinimizeButton2 = Resources.Minimize_Button_2;
                picMinimize.BackgroundImage = imgMinimizeButton2;
                if (e.Button == MouseButtons.Left)
                {
                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }

                    WindowState = FormWindowState.Minimized;
                }
            }
            else
            {
                Image imgMinimizeButton = Resources.Minimize_Button;
                picMinimize.BackgroundImage = imgMinimizeButton;
            }
        }

        private void picSound_MouseMove(object sender, MouseEventArgs e)
        {
            if(insideSoundButton == false)
            {
                insideSoundButton = true;

                if (soundEnabled == true)
                {
                    Image imgSoundButton2 = Resources.Sound_Button_2;
                    picSound.BackgroundImage = imgSoundButton2;
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();

                }
                else
                {
                    Image imgSoundButton2 = Resources.Sound_Disabled_Button_2;
                    picSound.BackgroundImage = imgSoundButton2;
                }
            }
        }

        private void picSound_MouseLeave(object sender, EventArgs e)
        {
            
            if(insideSoundButton == true)
            {
                insideSoundButton = false;

                if (soundEnabled == true)
                {
                    Image imgSoundButton = Resources.Sound_Button;
                    picSound.BackgroundImage = imgSoundButton;
                }
                else
                {
                    Image imgSoundButton = Resources.Sound_Disabled_Button;
                    picSound.BackgroundImage = imgSoundButton;
                }
            }
        }

        private void picSound_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (soundEnabled == true)
                {
                    Image imgSoundButton3 = Resources.Sound_Button_3;
                    picSound.BackgroundImage = imgSoundButton3;
                }
                else
                {
                    Image imgSoundButton3 = Resources.Sound_Button_3;
                    picSound.BackgroundImage = imgSoundButton3;
                }
            }
        }

        private void picSound_MouseUp(object sender, MouseEventArgs e)
        {
            if (insideSoundButton == true)
            {
                if (soundEnabled == true)
                {
                    Image imgSoundButton2 = Resources.Sound_Button_2;
                    picSound.BackgroundImage = imgSoundButton2;
                }
                else
                {
                    Image imgSoundButton2 = Resources.Sound_Disabled_Button_2;
                    picSound.BackgroundImage = imgSoundButton2;
                }

                if (e.Button == MouseButtons.Left)
                {
                    if (soundEnabled == true)
                    {
                        Image imgSoundButton2 = Resources.Sound_Disabled_Button_2;
                        picSound.BackgroundImage = imgSoundButton2;

                        soundEnabled = false;
                    }
                    else
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();

                        Image imgSoundButton2 = Resources.Sound_Button_2;
                        picSound.BackgroundImage = imgSoundButton2;

                        soundEnabled = true;
                    }
                }
            }
            else
            {
                if (soundEnabled == true)
                {
                    Image imgSoundButton = Resources.Sound_Button;
                    picSound.BackgroundImage = imgSoundButton;
                }
                else
                {
                    Image imgSoundButton = Resources.Sound_Disabled_Button;
                    picSound.BackgroundImage = imgSoundButton;
                }
            }
        }

        private void picResults_MouseMove(object sender, MouseEventArgs e)
        {
            if(insideResultsButton == false)
            {
                insideResultsButton = true;
                Image imgResultsButton2 = Resources.Results_Button_2;
                picResults.BackgroundImage = imgResultsButton2;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void picResults_MouseLeave(object sender, EventArgs e)
        {
            insideResultsButton = false;
            Image imgResultsButton = Resources.Results_Button;
            picResults.BackgroundImage = imgResultsButton;
        }

        private void picResults_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Image imgResultsButton3 = Resources.Results_Button_3;
                picResults.BackgroundImage = imgResultsButton3;
            }
        }

        private void picResults_MouseUp(object sender, MouseEventArgs e)
        {
            if (insideResultsButton == true)
            {
                if (e.Button == MouseButtons.Left)
                {
                    //DO ACTION HERE

                    Image imgResultsButton2 = Resources.Results_Button_2;
                    picResults.BackgroundImage = imgResultsButton2;

                    if (pnlGrade.Visible == false)
                    {
                        picResults.Visible = false;
                        pnlResults.Visible = true;

                        ch1Score = 0;
                        ch2Score = 0;
                        ch3Score = 0;
                        ch4Score = 0;
                        score = 0;

                        lstResults.Items.Clear();

                        ch1TotalScore = ch1TranslationGame.Get_Number_Of_Questions() +
                                        ch1LetterGame.Get_Number_Of_Questions() +
                                        ch1NumberGame.Get_Number_Of_Questions() +
                                        ch1ColorGame.Get_Number_Of_Questions() +
                                        ch1DaysOfTheWeekGame.Get_Number_Of_Questions() +
                                        ch1MonthsOfTheYearGame.Get_Number_Of_Questions() +
                                        ch1SeasonsOfTheYearGame.Get_Number_Of_Questions();

                        ch2TotalScore = ch2TranslationGame.Get_Number_Of_Questions() +
                                        ch2NationalitiesGame.Get_Number_Of_Questions() +
                                        ch2WhatTimeIsItGame.Get_Number_Of_Questions() +
                                        ch2VerbsGame.Get_Number_Of_Questions() +
                                        ch2InterrogativeWordsGame.Get_Number_Of_Questions() +
                                        ch2CountriesGame.Get_Number_Of_Questions() +
                                        ch2ILikeYouLikeGame.Get_Number_Of_Questions();

                        ch3TotalScore = ch3TranslationGame.Get_Number_Of_Questions() +
                                        ch3ScheduleGame.Get_Number_Of_Questions() +
                                        ch3BigNumbersGame.Get_Number_Of_Questions() +
                                        ch3BuildingsGame.Get_Number_Of_Questions() +
                                        ch3PronounsGame.Get_Number_Of_Questions() +
                                        ch3WhereIsItGame.Get_Number_Of_Questions() +
                                        ch3VerbsGame.Get_Number_Of_Questions();

                        ch4TotalScore = ch4TranslationGame.Get_Number_Of_Questions() +
                                        ch4MembersOfTheFamilyGame.Get_Number_Of_Questions() +
                                        ch4VerbsGame.Get_Number_Of_Questions() +
                                        ch4AdjetivesGame.Get_Number_Of_Questions() +
                                        ch4PlacesToGoGame.Get_Number_Of_Questions() +
                                        ch4FinalGame.Get_Number_Of_Questions();

                        totalScore = ch1TotalScore +
                                     ch2TotalScore +
                                     ch3TotalScore +
                                     ch4TotalScore;

                        lstResults.Items.Add("Chapter 1: Translation Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch1TranslationGame.Get_Number_Of_Questions(); i++)
                        {
                            if(ch1TranslationGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1TranslationGame.answer[i] + " - " + "Mastered");
                                ch1Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1TranslationGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 1: Letters Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch1LetterGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch1LetterGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1LetterGame.answer[i] + " - " + "Mastered");
                                ch1Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1LetterGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 1: Numbers Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch1NumberGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch1NumberGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1NumberGame.answer[i] + " - " + "Mastered");
                                ch1Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1NumberGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 1: Colors Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch1ColorGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch1ColorGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1ColorGame.answer[i] + " - " + "Mastered");
                                ch1Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1ColorGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 1: Days of the Week Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch1DaysOfTheWeekGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch1DaysOfTheWeekGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1DaysOfTheWeekGame.answer[i] + " - " + "Mastered");
                                ch1Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1DaysOfTheWeekGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 1: Months of the Year Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch1MonthsOfTheYearGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch1MonthsOfTheYearGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1MonthsOfTheYearGame.answer[i] + " - " + "Mastered");
                                ch1Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1MonthsOfTheYearGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 1: Seasons of the Year Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch1SeasonsOfTheYearGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch1SeasonsOfTheYearGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1SeasonsOfTheYearGame.answer[i] + " - " + "Mastered");
                                ch1Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch1SeasonsOfTheYearGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");
                        lstResults.Items.Add("Chapter 1 Score: " + Convert.ToString(ch1Score) + " / " + Convert.ToString(ch1TotalScore));
                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 2: Translation Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch2TranslationGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch2TranslationGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2TranslationGame.answer[i] + " - " + "Mastered");
                                ch2Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2TranslationGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 2: Nationalities Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch2NationalitiesGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch2NationalitiesGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2NationalitiesGame.answer[i] + " - " + "Mastered");
                                ch2Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2NationalitiesGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 2: What Time Is It Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch2WhatTimeIsItGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch2WhatTimeIsItGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2WhatTimeIsItGame.answer[i] + " - " + "Mastered");
                                ch2Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2WhatTimeIsItGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 2: Verbs Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch2VerbsGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch2VerbsGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2VerbsGame.answer[i] + " - " + "Mastered");
                                ch2Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2VerbsGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 2: Interrogative Words Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch2InterrogativeWordsGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch2InterrogativeWordsGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2InterrogativeWordsGame.answer[i] + " - " + "Mastered");
                                ch2Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2InterrogativeWordsGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 2: Countries Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch2CountriesGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch2CountriesGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2CountriesGame.answer[i] + " - " + "Mastered");
                                ch2Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2CountriesGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 2: I Like / You Like Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch2ILikeYouLikeGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch2ILikeYouLikeGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2ILikeYouLikeGame.answer[i] + " - " + "Mastered");
                                ch2Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch2ILikeYouLikeGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");
                        lstResults.Items.Add("Chapter 2 Score: " + Convert.ToString(ch2Score) + " / " + Convert.ToString(ch2TotalScore));
                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 3: Translation Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch3TranslationGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch3TranslationGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3TranslationGame.answer[i] + " - " + "Mastered");
                                ch3Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3TranslationGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 3: Schedule Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch3ScheduleGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch3ScheduleGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3ScheduleGame.answer[i] + " - " + "Mastered");
                                ch3Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3ScheduleGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 3: Big Numbers Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch3BigNumbersGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch3BigNumbersGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3BigNumbersGame.answer[i] + " - " + "Mastered");
                                ch3Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3BigNumbersGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 3: Buildings Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch3BuildingsGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch3BuildingsGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3BuildingsGame.answer[i] + " - " + "Mastered");
                                ch3Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3BuildingsGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 3: Pronouns Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch3PronounsGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch3PronounsGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3PronounsGame.answer[i] + " - " + "Mastered");
                                ch3Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3PronounsGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 3: Where Is It Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch3WhereIsItGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch3WhereIsItGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3WhereIsItGame.answer[i] + " - " + "Mastered");
                                ch3Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3WhereIsItGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 3: More Verbs Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch3VerbsGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch3VerbsGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3VerbsGame.answer[i] + " - " + "Mastered");
                                ch3Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch3VerbsGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");
                        lstResults.Items.Add("Chapter 3 Score: " + Convert.ToString(ch3Score) + " / " + Convert.ToString(ch3TotalScore));
                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 4: Translation Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch4TranslationGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch4TranslationGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4TranslationGame.answer[i] + " - " + "Mastered");
                                ch4Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4TranslationGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 4: Members Of The Family Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch4MembersOfTheFamilyGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch4MembersOfTheFamilyGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4MembersOfTheFamilyGame.answer[i] + " - " + "Mastered");
                                ch4Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4MembersOfTheFamilyGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 4: And More Verbs Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch4VerbsGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch4VerbsGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4VerbsGame.answer[i] + " - " + "Mastered");
                                ch4Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4VerbsGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 4: Adjetives Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch4AdjetivesGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch4AdjetivesGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4AdjetivesGame.answer[i] + " - " + "Mastered");
                                ch4Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4AdjetivesGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 4: Places To Go Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch4PlacesToGoGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch4PlacesToGoGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4PlacesToGoGame.answer[i] + " - " + "Mastered");
                                ch4Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4PlacesToGoGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");

                        lstResults.Items.Add("Chapter 4: Final Game");
                        lstResults.Items.Add("----------------------------");

                        for (int i = 0; i < ch4FinalGame.Get_Number_Of_Questions(); i++)
                        {
                            if (ch4FinalGame.mastered[i] == true)
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4FinalGame.answer[i] + " - " + "Mastered");
                                ch4Score += 1;
                                score += 1;
                            }
                            else
                            {
                                lstResults.Items.Add(Convert.ToString(i + 1) + ": " + ch4FinalGame.answer[i] + " - " + " ");
                            }
                        }

                        lstResults.Items.Add("");
                        lstResults.Items.Add("Chapter 4 Score: " + Convert.ToString(ch4Score) + " / " + Convert.ToString(ch4TotalScore));
                        lstResults.Items.Add("");
                        lstResults.Items.Add("Total Score: " + Convert.ToString(score) + " / " + Convert.ToString(totalScore));
                    }

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
            else
            {
                Image imgResultsButton = Resources.Results_Button;
                picResults.BackgroundImage = imgResultsButton;
            }
        }

        private static void AddFontFromResource(PrivateFontCollection privateFontCollection, string fontResourceName)
        {
            var fontBytes = GetFontResourceBytes(typeof(frmMain).Assembly, fontResourceName);
            var fontData = Marshal.AllocCoTaskMem(fontBytes.Length);
            Marshal.Copy(fontBytes, 0, fontData, fontBytes.Length);
            privateFontCollection.AddMemoryFont(fontData, fontBytes.Length);
            // Marshal.FreeCoTaskMem(fontData);  Nasty bug alert, read the comment
        }

        private static byte[] GetFontResourceBytes(Assembly assembly, string fontResourceName)
        {
            var resourceStream = assembly.GetManifestResourceStream(fontResourceName);
            if (resourceStream == null)
                throw new Exception(string.Format("Unable to find font '{0}' in embedded resources.", fontResourceName));
            var fontBytes = new byte[resourceStream.Length];
            resourceStream.Read(fontBytes, 0, (int)resourceStream.Length);
            resourceStream.Close();
            return fontBytes;
        }

        private void Modernize_Font()
        {
            AddFontFromResource(pfcLight, "Arriba_Ultimate_Study_Guide.Fonts.OpenSans-Light.ttf");
            AddFontFromResource(pfcLightItalic, "Arriba_Ultimate_Study_Guide.Fonts.OpenSans-LightItalic.ttf");

            lblAdjetives.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblAdjetiveslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblAuthor.Font = new Font(pfcLightItalic.Families[0], 16, FontStyle.Italic);
            lblBack.Font = new Font(pfcLight.Families[0], 72, FontStyle.Regular);
            lblBigNumbers.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblBigNumberslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblBuildings.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblBuildingslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCapitulo1.Font = new Font(pfcLight.Families[0], 36, FontStyle.Underline);
            lblCapitulo2.Font = new Font(pfcLight.Families[0], 36, FontStyle.Underline);
            lblCapitulo3.Font = new Font(pfcLight.Families[0], 36, FontStyle.Underline);
            lblCapitulo4.Font = new Font(pfcLight.Families[0], 36, FontStyle.Underline);

            lblCh1TranslationGameAccentA.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameAccentAlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh1TranslationGameAccentE.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameAccentElg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh1TranslationGameAccentI.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameAccentIlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh1TranslationGameAccentN.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameAccentNlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh1TranslationGameAccentO.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameAccentOlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh1TranslationGameAccentU.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameAccentU2.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameAccentUlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh1TranslationGameAccentUlg2.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh1TranslationGameAnswer.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);
            lblCh1TranslationGameCorrect.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh1TranslationGameCorrecto.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameIncorrect.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh1TranslationGameIncorrecto.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameInstructions.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);
            lblCh1TranslationGamePregunta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameQuestion.Font = new Font(pfcLight.Families[0], 16, FontStyle.Regular);
            lblCh1TranslationGameQuestionNum.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh1TranslationGameRespuesta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameTiempo.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameTime.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh1TranslationGameTitle.Font = new Font(pfcLight.Families[0], 28, FontStyle.Underline);
            lblCh1TranslationGameTuRespuesta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameUDExclamation.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameUDExclamationlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh1TranslationGameUDQuestion.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh1TranslationGameUDQuestionlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh1TranslationGameYourAnswer.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);

            lblCh2TranslationGameAccentA.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameAccentAlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh2TranslationGameAccentE.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameAccentElg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh2TranslationGameAccentI.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameAccentIlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh2TranslationGameAccentN.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameAccentNlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh2TranslationGameAccentO.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameAccentOlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh2TranslationGameAccentU.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameAccentU2.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameAccentUlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh2TranslationGameAccentU2lg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh2TranslationGameAnswer.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);
            lblCh2TranslationGameCorrect.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh2TranslationGameCorrecto.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameIncorrect.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh2TranslationGameIncorrecto.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameInstructions.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);
            lblCh2TranslationGamePregunta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameQuestion.Font = new Font(pfcLight.Families[0], 16, FontStyle.Regular);
            lblCh2TranslationGameQuestionNum.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh2TranslationGameRespuesta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameTiempo.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameTime.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh2TranslationGameTitle.Font = new Font(pfcLight.Families[0], 28, FontStyle.Underline);
            lblCh2TranslationGameTuRespuesta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameUDExclamation.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameUDExclamationlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh2TranslationGameUDQuestion.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh2TranslationGameUDQuestionlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh2TranslationGameYourAnswer.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);

            lblCh3TranslationGameAccentA.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameAccentAlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh3TranslationGameAccentE.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameAccentElg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh3TranslationGameAccentI.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameAccentIlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh3TranslationGameAccentN.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameAccentNlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh3TranslationGameAccentO.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameAccentOlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh3TranslationGameAccentU.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameAccentU2.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameAccentUlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh3TranslationGameAccentU2lg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh3TranslationGameAnswer.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);
            lblCh3TranslationGameCorrect.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh3TranslationGameCorrecto.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameIncorrect.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh3TranslationGameIncorrecto.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameInstructions.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);
            lblCh3TranslationGamePregunta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameQuestion.Font = new Font(pfcLight.Families[0], 16, FontStyle.Regular);
            lblCh3TranslationGameQuestionNum.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh3TranslationGameRespuesta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameTiempo.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameTime.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh3TranslationGameTitle.Font = new Font(pfcLight.Families[0], 28, FontStyle.Underline);
            lblCh3TranslationGameTuRespuesta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameUDExclamation.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameUDExclamationlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh3TranslationGameUDQuestion.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh3TranslationGameUDQuestionlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh3TranslationGameYourAnswer.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);

            lblCh4TranslationGameAccentA.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameAccentAlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh4TranslationGameAccentE.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameAccentElg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh4TranslationGameAccentI.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameAccentIlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh4TranslationGameAccentN.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameAccentNlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh4TranslationGameAccentO.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameAccentOlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh4TranslationGameAccentU.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameAccentU2.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameAccentUlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh4TranslationGameAccentU2lg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh4TranslationGameAnswer.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);
            lblCh4TranslationGameCorrect.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh4TranslationGameCorrecto.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameIncorrect.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh4TranslationGameIncorrecto.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameInstructions.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);
            lblCh4TranslationGamePregunta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameQuestion.Font = new Font(pfcLight.Families[0], 16, FontStyle.Regular);
            lblCh4TranslationGameQuestionNum.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh4TranslationGameRespuesta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameTiempo.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameTime.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCh4TranslationGameTitle.Font = new Font(pfcLight.Families[0], 28, FontStyle.Underline);
            lblCh4TranslationGameTuRespuesta.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameUDExclamation.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameUDExclamationlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh4TranslationGameUDQuestion.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCh4TranslationGameUDQuestionlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCh4TranslationGameYourAnswer.Font = new Font(pfcLightItalic.Families[0], 18, FontStyle.Italic);

            lblChapter1.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblChapter1lg.Font = new Font(pfcLight.Families[0], 48, FontStyle.Regular);
            lblChapter2.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblChapter2lg.Font = new Font(pfcLight.Families[0], 48, FontStyle.Regular);
            lblChapter3.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblChapter3lg.Font = new Font(pfcLight.Families[0], 48, FontStyle.Regular);
            lblChapter4.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblChapter4lg.Font = new Font(pfcLight.Families[0], 48, FontStyle.Regular);
            lblColors.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblColorslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblCorrect.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblCorrecto.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCountries.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblCountrieslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblDaysWeek.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblDaysWeeklg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblFamily.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblFamilylg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblFinal.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblFinallg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblForward.Font = new Font(pfcLight.Families[0], 72, FontStyle.Regular);
            lblGrade.Font = new Font(pfcLightItalic.Families[0], 72, FontStyle.Italic);
            lblILikeYouLike.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblILikeYouLikelg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblIncorrect.Font = new Font(pfcLightItalic.Families[0], 24, FontStyle.Italic);
            lblIncorrecto.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblInterrogativeWords.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblInterrogativeWordslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblLetters.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblLetterslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblMonthsYear.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblMonthsYearlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblNationalities.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblNationalitieslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblNota.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblNumbers.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblNumberslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblPhotos.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblPhotos2.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblPhotos2lg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblPhotos3.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblPhotos3lg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblPhotos4.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblPhotos4lg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblPhotoslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblPlacesToGo.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblPlacesToGolg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblPronouns.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblPronounslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblSchedule.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblSchedulelg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblSeasonsYear.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblSeasonsYearlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblTitle.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblTranslation.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblTranslation2.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblTranslation2lg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblTranslation3.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblTranslation3lg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblTranslation4.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblTranslation4lg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblTranslationlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblVerbos2.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblVerbos2lg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblVerbs.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblVerbs3.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblVerbs3lg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblVerbslg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblWhatTimeIsIt.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblWhatTimeIsItlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            lblWhereIsIt.Font = new Font(pfcLight.Families[0], 24, FontStyle.Regular);
            lblWhereIsItlg.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);

            txtCh1TranslationGameAnswer.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            txtCh2TranslationGameAnswer.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            txtCh3TranslationGameAnswer.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);
            txtCh4TranslationGameAnswer.Font = new Font(pfcLight.Families[0], 36, FontStyle.Regular);

            //lblAdjetives: Open Sans Light, 36pt
            //lblAdjetiveslg: Open Sans Light, 48pt
            //lblAuthor: Open Sans Light, 20.25pt, style = Italic
            //lblBack: Open Sans Light, 72pt
            //lblBigNumbers: Open Sans Light, 36pt
            //lblBigNumberslg: Open Sans Light, 48pt
            //lblBuildings: Open Sans Light, 36pt
            //lblBuildingslg: Open Sans Light, 48pt
            //lblCapitulo1: Open Sans Light, 48pt, style = Underline
            //lblCapitulo2: Open Sans Light, 48pt, style = Underline
            //lblCapitulo3: Open Sans Light, 48pt, style = Underline
            //lblCapitulo4: Open Sans Light, 48pt, style = Underline
            //lblCh1TranslationGameAccentA: Open Sans Light, 36pt
            //lblCh1TranslationGameAccentAlg: Open Sans Light, 48pt
            //lblCh1TranslationGameAccentE: Open Sans Light, 36pt
            //lblCh1TranslationGameAccentElg: Open Sans Light, 48pt
            //lblCh1TranslationGameAccentI: Open Sans Light, 36pt
            //lblCh1TranslationGameAccentIlg: Open Sans Light, 48pt
            //lblCh1TranslationGameAccentN: Open Sans Light, 36pt
            //lblCh1TranslationGameAccentNlg: Open Sans Light, 48pt
            //lblCh1TranslationGameAccentO: Open Sans Light, 36pt
            //lblCh1TranslationGameAccentOlg: Open Sans Light, 48pt
            //lblCh1TranslationGameAccentU: Open Sans Light, 36pt
            //lblCh1TranslationGameAccentU2: Open Sans Light, 36pt
            //lblCh1TranslationGameAccentUlg: Open Sans Light, 48pt
            //lblCh1TranslationGameAccentUlg2: Open Sans Light, 48pt
            //lblCh1TranslationGameAnswer: Open Sans Light, 24pt, style = Italic
            //lblCh1TranslationGameCorrect: Open Sans Light, 24pt, style = Italic
            //lblCh1TranslationGameCorrecto: Open Sans Light, 24pt
            //lblCh1TranslationGameIncorrect: Open Sans Light, 24pt, style = Italic
            //lblCh1TranslationGameIncorrecto: Open Sans Light, 24pt
            //lblCh1TranslationGameInstructions: Open Sans Light, 18pt, style = Italic
            //lblCh1TranslationGamePregunta: Open Sans Light, 24pt
            //lblCh1TranslationGameQuestion: Open Sans Light, 15.75pt
            //lblCh1TranslationGameQuestionNum: Open Sans Light, 24pt, style = Italic
            //lblCh1TranslationGameRespuesta: Open Sans Light, 24pt
            //lblCh1TranslationGameTiempo: Open Sans Light, 24pt
            //lblCh1TranslationGameTime: Open Sans Light, 24pt, style = Italic
            //lblCh1TranslationGameTitle: Open Sans Light, 28pt, style = Underline
            //lblCh1TranslationGameTuRespuesta: Open Sans Light, 24pt
            //lblCh1TranslationGameUDExclamation: Open Sans Light, 36pt
            //lblCh1TranslationGameUDExclamationlg: Open Sans Light, 48pt
            //lblCh1TranslationGameUDQuestion: Open Sans Light, 36pt
            //lblCh1TranslationGameUDQuestionlg: Open Sans Light, 48pt
            //lblCh1TranslationGameYourAnswer: Open Sans Light, 24pt, style = Italic
            //lblCh2TranslationGameAccentA: Open Sans Light, 36pt
            //lblCh2TranslationGameAccentAlg: Open Sans Light, 48pt
            //lblCh2TranslationGameAccentE: Open Sans Light, 36pt
            //lblCh2TranslationGameAccentElg: Open Sans Light, 48pt
            //lblCh2TranslationGameAccentI: Open Sans Light, 36pt
            //lblCh2TranslationGameAccentIlg: Open Sans Light, 48pt
            //lblCh2TranslationGameAccentN: Open Sans Light, 36pt
            //lblCh2TranslationGameAccentNlg: Open Sans Light, 48pt
            //lblCh2TranslationGameAccentO: Open Sans Light, 36pt
            //lblCh2TranslationGameAccentOlg: Open Sans Light, 48pt
            //lblCh2TranslationGameAccentU: Open Sans Light, 36pt
            //lblCh2TranslationGameAccentU2: Open Sans Light, 36pt
            //lblCh2TranslationGameAccentUlg: Open Sans Light, 48pt
            //lblCh2TranslationGameAccentUlg2: Open Sans Light, 48pt
            //lblCh2TranslationGameAnswer: Open Sans Light, 24pt, style = Italic
            //lblCh2TranslationGameCorrect: Open Sans Light, 24pt, style = Italic
            //lblCh2TranslationGameCorrecto: Open Sans Light, 24pt
            //lblCh2TranslationGameIncorrect: Open Sans Light, 24pt, style = Italic
            //lblCh2TranslationGameIncorrecto: Open Sans Light, 24pt
            //lblCh2TranslationGameInstructions: Open Sans Light, 18pt, style = Italic
            //lblCh2TranslationGamePregunta: Open Sans Light, 24pt
            //lblCh2TranslationGameQuestion: Open Sans Light, 15.75pt
            //lblCh2TranslationGameQuestionNum: Open Sans Light, 24pt, style = Italic
            //lblCh2TranslationGameRespuesta: Open Sans Light, 24pt
            //lblCh2TranslationGameTiempo: Open Sans Light, 24pt
            //lblCh2TranslationGameTime: Open Sans Light, 24pt, style = Italic
            //lblCh2TranslationGameTitle: Open Sans Light, 28pt, style = Underline
            //lblCh2TranslationGameTuRespuesta: Open Sans Light, 24pt
            //lblCh2TranslationGameUDExclamation: Open Sans Light, 36pt
            //lblCh2TranslationGameUDExclamationlg: Open Sans Light, 48pt
            //lblCh2TranslationGameUDQuestion: Open Sans Light, 36pt
            //lblCh2TranslationGameUDQuestionlg: Open Sans Light, 48pt
            //lblCh2TranslationGameYourAnswer: Open Sans Light, 24pt, style = Italic
            //lblCh3TranslationGameAccentA: Open Sans Light, 36pt
            //lblCh3TranslationGameAccentAlg: Open Sans Light, 48pt
            //lblCh3TranslationGameAccentE: Open Sans Light, 36pt
            //lblCh3TranslationGameAccentElg: Open Sans Light, 48pt
            //lblCh3TranslationGameAccentI: Open Sans Light, 36pt
            //lblCh3TranslationGameAccentIlg: Open Sans Light, 48pt
            //lblCh3TranslationGameAccentN: Open Sans Light, 36pt
            //lblCh3TranslationGameAccentNlg: Open Sans Light, 48pt
            //lblCh3TranslationGameAccentO: Open Sans Light, 36pt
            //lblCh3TranslationGameAccentOlg: Open Sans Light, 48pt
            //lblCh3TranslationGameAccentU: Open Sans Light, 36pt
            //lblCh3TranslationGameAccentU2: Open Sans Light, 36pt
            //lblCh3TranslationGameAccentUlg: Open Sans Light, 48pt
            //lblCh3TranslationGameAccentUlg2: Open Sans Light, 48pt
            //lblCh3TranslationGameAnswer: Open Sans Light, 24pt, style = Italic
            //lblCh3TranslationGameCorrect: Open Sans Light, 24pt, style = Italic
            //lblCh3TranslationGameCorrecto: Open Sans Light, 24pt
            //lblCh3TranslationGameIncorrect: Open Sans Light, 24pt, style = Italic
            //lblCh3TranslationGameIncorrecto: Open Sans Light, 24pt
            //lblCh3TranslationGameInstructions: Open Sans Light, 18pt, style = Italic
            //lblCh3TranslationGamePregunta: Open Sans Light, 24pt
            //lblCh3TranslationGameQuestion: Open Sans Light, 15.75pt
            //lblCh3TranslationGameQuestionNum: Open Sans Light, 24pt, style = Italic
            //lblCh3TranslationGameRespuesta: Open Sans Light, 24pt
            //lblCh3TranslationGameTiempo: Open Sans Light, 24pt
            //lblCh3TranslationGameTime: Open Sans Light, 24pt, style = Italic
            //lblCh3TranslationGameTitle: Open Sans Light, 28pt, style = Underline
            //lblCh3TranslationGameTuRespuesta: Open Sans Light, 24pt
            //lblCh3TranslationGameUDExclamation: Open Sans Light, 36pt
            //lblCh3TranslationGameUDExclamationlg: Open Sans Light, 48pt
            //lblCh3TranslationGameUDQuestion: Open Sans Light, 36pt
            //lblCh3TranslationGameUDQuestionlg: Open Sans Light, 48pt
            //lblCh3TranslationGameYourAnswer: Open Sans Light, 24pt, style = Italic
            //lblCh4TranslationGameAccentA: Open Sans Light, 36pt
            //lblCh4TranslationGameAccentAlg: Open Sans Light, 48pt
            //lblCh4TranslationGameAccentE: Open Sans Light, 36pt
            //lblCh4TranslationGameAccentElg: Open Sans Light, 48pt
            //lblCh4TranslationGameAccentI: Open Sans Light, 36pt
            //lblCh4TranslationGameAccentIlg: Open Sans Light, 48pt
            //lblCh4TranslationGameAccentN: Open Sans Light, 36pt
            //lblCh4TranslationGameAccentNlg: Open Sans Light, 48pt
            //lblCh4TranslationGameAccentO: Open Sans Light, 36pt
            //lblCh4TranslationGameAccentOlg: Open Sans Light, 48pt
            //lblCh4TranslationGameAccentU: Open Sans Light, 36pt
            //lblCh4TranslationGameAccentU2: Open Sans Light, 36pt
            //lblCh4TranslationGameAccentUlg: Open Sans Light, 48pt
            //lblCh4TranslationGameAccentUlg2: Open Sans Light, 48pt
            //lblCh4TranslationGameAnswer: Open Sans Light, 24pt, style = Italic
            //lblCh4TranslationGameCorrect: Open Sans Light, 24pt, style = Italic
            //lblCh4TranslationGameCorrecto: Open Sans Light, 24pt
            //lblCh4TranslationGameIncorrect: Open Sans Light, 24pt, style = Italic
            //lblCh4TranslationGameIncorrecto: Open Sans Light, 24pt
            //lblCh4TranslationGameInstructions: Open Sans Light, 18pt, style = Italic
            //lblCh4TranslationGamePregunta: Open Sans Light, 24pt
            //lblCh4TranslationGameQuestion: Open Sans Light, 15.75pt
            //lblCh4TranslationGameQuestionNum: Open Sans Light, 24pt, style = Italic
            //lblCh4TranslationGameRespuesta: Open Sans Light, 24pt
            //lblCh4TranslationGameTiempo: Open Sans Light, 24pt
            //lblCh4TranslationGameTime: Open Sans Light, 24pt, style = Italic
            //lblCh4TranslationGameTitle: Open Sans Light, 28pt, style = Underline
            //lblCh4TranslationGameTuRespuesta: Open Sans Light, 24pt
            //lblCh4TranslationGameUDExclamation: Open Sans Light, 36pt
            //lblCh4TranslationGameUDExclamationlg: Open Sans Light, 48pt
            //lblCh4TranslationGameUDQuestion: Open Sans Light, 36pt
            //lblCh4TranslationGameUDQuestionlg: Open Sans Light, 48pt
            //lblCh4TranslationGameYourAnswer: Open Sans Light, 24pt, style = Italic
            //lblChapter1: Open Sans Light, 36pt
            //lblChapter1lg: Open Sans Light, 48pt
            //lblChapter2: Open Sans Light, 36pt
            //lblChapter2lg: Open Sans Light, 48pt
            //lblChapter3: Open Sans Light, 36pt
            //lblChapter3lg: Open Sans Light, 48pt
            //lblChapter4: Open Sans Light, 36pt
            //lblChapter4lg: Open Sans Light, 48pt
            //lblColors: Open Sans Light, 36pt
            //lblColorslg: Open Sans Light, 48pt
            //lblCorrect: Open Sans Light, 24pt, style = Italic
            //lblCorrecto: Open Sans Light, 24pt
            //lblCountries: Open Sans Light, 36pt
            //lblCountrieslg: Open Sans Light, 48pt
            //lblDaysWeek: Open Sans Light, 36pt
            //lblDaysWeeklg: Open Sans Light, 48pt
            //lblFamily: Open Sans Light, 36pt
            //lblFamilylg: Open Sans Light, 48pt
            //lblFinal: Open Sans Light, 36pt
            //lblFinallg: Open Sans Light, 48pt
            //lblForward: Open Sans Light, 72pt
            //lblGrade: Open Sans Light, 72pt, style = Italic
            //lblILikeYouLike: Open Sans Light, 36pt
            //lblILikeYouLikelg: Open Sans Light, 48pt
            //lblIncorrect: Open Sans Light, 24pt, style = Italic
            //lblIncorrecto: Open Sans Light, 24pt
            //lblInterrogativeWords: Open Sans Light, 36pt
            //lblInterrogativeWordslg: Open Sans Light, 48pt
            //lblLetters: Open Sans Light, 36pt
            //lblLetterslg: Open Sans Light, 48pt
            //lblMonthsYear: Open Sans Light, 36pt
            //lblMonthsYearlg: Open Sans Light, 48pt
            //lblNationalities: Open Sans Light, 36pt
            //lblNationalitieslg: Open Sans Light, 48pt
            //lblNota: Open Sans Light, 24pt
            //lblNumbers: Open Sans Light, 36pt
            //lblNumberslg: Open Sans Light, 48pt
            //lblPhotos: Open Sans Light, 36pt
            //lblPhotos2: Open Sans Light, 36pt
            //lblPhotos2lg: Open Sans Light, 48pt
            //lblPhotos3: Open Sans Light, 36pt
            //lblPhotos3lg: Open Sans Light, 48pt
            //lblPhotos4: Open Sans Light, 36pt
            //lblPhotos4lg: Open Sans Light, 48pt
            //lblPhotoslg: Open Sans Light, 48pt
            //lblPlacesToGo: Open Sans Light, 36pt
            //lblPlacesToGolg: Open Sans Light, 48pt
            //lblPronouns: Open Sans Light, 36pt
            //lblPronounslg: Open Sans Light, 48pt
            //lblSchedule: Open Sans Light, 36pt
            //lblSchedulelg: Open Sans Light, 48pt
            //lblSeasonsYear: Open Sans Light, 36pt
            //lblSeasonsYearlg: Open Sans Light, 48pt
            //lblTitle: Open Sans Light, 48pt

            //lblTranslation: Open Sans Light, 36pt
            //lblTranslation2: Open Sans Light, 36pt
            //lblTranslation2lg: Open Sans Light, 48pt
            //lblTranslation3: Open Sans Light, 36pt
            //lblTranslation3lg: Open Sans Light, 48pt
            //lblTranslation4: Open Sans Light, 36pt
            //lblTranslation4lg: Open Sans Light, 48pt
            //lblTranslationlg: Open Sans Light, 48pt
            //lblVerbos2: Open Sans Light, 36pt
            //lblVerbos2lg: Open Sans Light, 48pt
            //lblVerbs: Open Sans Light, 36pt
            //lblVerbs3: Open Sans Light, 36pt
            //lblVerbs3lg: Open Sans Light, 48pt
            //lblVerbslg: Open Sans Light, 48pt
            //lblWhatTimeIsIt: Open Sans Light, 36pt
            //lblWhatTimeIsItlg: Open Sans Light, 48pt
            //lblWhereIsIt: Open Sans Light, 36pt
            //lblWhereIsItlg: Open Sans Light, 48pt

            //txtCh1TranslationGameAnswer: Open Sans Light, 36pt
            //txtCh2TranslationGameAnswer: Open Sans Light, 36pt
            //txtCh3TranslationGameAnswer: Open Sans Light, 36pt
            //txtCh4TranslationGameAnswer: Open Sans Light, 36pt
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //PICTUREBOX SIZE FOR PHOTO GAME: 623, 690
            Modernize_Font();
            this.Show();

            ch1TranslationGame = new Ch1TranslationGame();
            ch1PhotoGame = new Ch1PhotoGame();
            ch1LetterGame = new Ch1LetterGame();
            ch1NumberGame = new Ch1NumberGame();
            ch1ColorGame = new Ch1ColorGame();
            ch1DaysOfTheWeekGame = new Ch1DaysOfTheWeekGame();
            ch1MonthsOfTheYearGame = new Ch1MonthsOfTheYearGame();
            ch1SeasonsOfTheYearGame = new Ch1SeasonsOfTheYearGame();

            ch2TranslationGame = new Ch2TranslationGame();
            ch2PhotoGame = new Ch2PhotoGame();
            ch2NationalitiesGame = new Ch2NationalitiesGame();
            ch2WhatTimeIsItGame = new Ch2WhatTimeIsItGame();
            ch2VerbsGame = new Ch2VerbsGame();
            ch2InterrogativeWordsGame = new Ch2InterrogativeWordsGame();
            ch2CountriesGame = new Ch2CountriesGame();
            ch2ILikeYouLikeGame = new Ch2ILikeYouLikeGame();

            ch3TranslationGame = new Ch3TranslationGame();
            ch3PhotoGame = new Ch3PhotoGame();
            ch3ScheduleGame = new Ch3ScheduleGame();
            ch3BigNumbersGame = new Ch3BigNumbersGame();
            ch3BuildingsGame = new Ch3BuildingsGame();
            ch3PronounsGame = new Ch3PronounsGame();
            ch3WhereIsItGame = new Ch3WhereIsItGame();
            ch3VerbsGame = new Ch3VerbsGame();
            
            ch4TranslationGame = new Ch4TranslationGame();
            ch4PhotoGame = new Ch4PhotoGame();
            ch4MembersOfTheFamilyGame = new Ch4MembersOfTheFamilyGame();
            ch4VerbsGame = new Ch4VerbsGame();
            ch4AdjetivesGame = new Ch4AdjetivesGame();
            ch4PlacesToGoGame = new Ch4PlacesToGoGame();
            ch4FinalGame = new Ch4FinalGame();

            ReadFromBinaryFile("score.dat");

            assembly = Assembly.GetExecutingAssembly();
            xaudio = new XAudio2();
            var masteringsound = new MasteringVoice(xaudio);

            beep2_soundstream = new SoundStream(assembly.GetManifestResourceStream("Arriba_Ultimate_Study_Guide.Audio.beep2.wav"));
            nanoblade_soundstream = new SoundStream(assembly.GetManifestResourceStream("Arriba_Ultimate_Study_Guide.Audio.nanoblade.wav"));
            applause_soundstream = new SoundStream(assembly.GetManifestResourceStream("Arriba_Ultimate_Study_Guide.Audio.applause.wav"));
            wrong_soundstream = new SoundStream(assembly.GetManifestResourceStream("Arriba_Ultimate_Study_Guide.Audio.wrong.wav"));

            beep2_waveFormat = beep2_soundstream.Format;
            nanoblade_waveFormat = nanoblade_soundstream.Format;
            applause_waveFormat = applause_soundstream.Format;
            wrong_waveFormat = wrong_soundstream.Format;

            beep2_buffer = new AudioBuffer
            {
                Stream = beep2_soundstream.ToDataStream(),
                AudioBytes = (int)beep2_soundstream.Length,
                Flags = BufferFlags.EndOfStream
            };

            nanoblade_buffer = new AudioBuffer
            {
                Stream = nanoblade_soundstream.ToDataStream(),
                AudioBytes = (int)nanoblade_soundstream.Length,
                Flags = BufferFlags.EndOfStream
            };

            applause_buffer = new AudioBuffer
            {
                Stream = applause_soundstream.ToDataStream(),
                AudioBytes = (int)applause_soundstream.Length,
                Flags = BufferFlags.EndOfStream
            };

            wrong_buffer = new AudioBuffer
            {
                Stream = wrong_soundstream.ToDataStream(),
                AudioBytes = (int)wrong_soundstream.Length,
                Flags = BufferFlags.EndOfStream
            };


            pnlButtons.Location = new Point(Width - pnlButtons.Width, 0);
            pnlResults.Location = new Point(Width / 2 - pnlResults.Width / 2, Height / 2 - pnlResults.Height / 2);
            pnlCh1TranslationGame.Location = new Point(Width / 2 - pnlCh1TranslationGame.Width / 2, Height / 2 - pnlCh1TranslationGame.Height / 2);
            pnlCh2TranslationGame.Location = new Point(Width / 2 - pnlCh2TranslationGame.Width / 2, Height / 2 - pnlCh2TranslationGame.Height / 2);
            pnlCh3TranslationGame.Location = new Point(Width / 2 - pnlCh3TranslationGame.Width / 2, Height / 2 - pnlCh3TranslationGame.Height / 2);
            pnlCh4TranslationGame.Location = new Point(Width / 2 - pnlCh4TranslationGame.Width / 2, Height / 2 - pnlCh4TranslationGame.Height / 2);
            pnlGrade.Location = new Point(Width / 2 - pnlGrade.Width / 2, Height / 2 - pnlGrade.Height / 2);

            //pnlChapters
            pnlChapters.Location = new Point(Width / 2 - pnlChapters.Width / 2, Height / 2 - pnlChapters.Height / 2);
            lblChapter1.Left = pnlChapters.Width / 2 - lblChapter1.Width / 2;
            lblChapter1lg.Left = pnlChapters.Width / 2 - lblChapter1lg.Width / 2;
            lblChapter2.Left = pnlChapters.Width / 2 - lblChapter2.Width / 2;
            lblChapter2lg.Left = pnlChapters.Width / 2 - lblChapter2lg.Width / 2;
            lblChapter3.Left = pnlChapters.Width / 2 - lblChapter3.Width / 2;
            lblChapter3lg.Left = pnlChapters.Width / 2 - lblChapter3lg.Width / 2;
            lblChapter4.Left = pnlChapters.Width / 2 - lblChapter4.Width / 2;
            lblChapter4lg.Left = pnlChapters.Width / 2 - lblChapter4lg.Width / 2;

            //pnlChapter1
            pnlChapter1.Location = new Point(Width / 2 - pnlChapter1.Width / 2, Height / 2 - pnlChapter1.Height / 2);
            lblCapitulo1.Left = pnlChapter1.Width / 2 - lblCapitulo1.Width / 2;
            lblTranslation.Left = pnlChapter1.Width / 2 - lblTranslation.Width / 2;
            lblTranslationlg.Left = pnlChapter1.Width / 2 - lblTranslationlg.Width / 2;
            lblPhotos.Left = pnlChapter1.Width / 2 - lblPhotos.Width / 2;
            lblPhotoslg.Left = pnlChapter1.Width / 2 - lblPhotoslg.Width / 2;
            lblLetters.Left = pnlChapter1.Width / 2 - lblLetters.Width / 2;
            lblLetterslg.Left = pnlChapter1.Width / 2 - lblLetterslg.Width / 2;
            lblNumbers.Left = pnlChapter1.Width / 2 - lblNumbers.Width / 2;
            lblNumberslg.Left = pnlChapter1.Width / 2 - lblNumberslg.Width / 2;
            lblColors.Left = pnlChapter1.Width / 2 - lblColors.Width / 2;
            lblColorslg.Left = pnlChapter1.Width / 2 - lblColorslg.Width / 2;
            lblDaysWeek.Left = pnlChapter1.Width / 2 - lblDaysWeek.Width / 2;
            lblDaysWeeklg.Left = pnlChapter1.Width / 2 - lblDaysWeeklg.Width / 2;
            lblMonthsYear.Left = pnlChapter1.Width / 2 - lblMonthsYear.Width / 2;
            lblMonthsYearlg.Left = pnlChapter1.Width / 2 - lblMonthsYearlg.Width / 2;
            lblSeasonsYear.Left = pnlChapter1.Width / 2 - lblSeasonsYear.Width / 2;
            lblSeasonsYearlg.Left = pnlChapter1.Width / 2 - lblSeasonsYearlg.Width / 2;

            //pnlChapter2
            pnlChapter2.Location = new Point(Width / 2 - pnlChapter2.Width / 2, Height / 2 - pnlChapter2.Height / 2);
            lblCapitulo2.Left = pnlChapter2.Width / 2 - lblCapitulo2.Width / 2;
            lblTranslation2.Left = pnlChapter2.Width / 2 - lblTranslation2.Width / 2;
            lblTranslation2lg.Left = pnlChapter2.Width / 2 - lblTranslation2lg.Width / 2;
            lblPhotos2.Left = pnlChapter2.Width / 2 - lblPhotos2.Width / 2;
            lblPhotos2lg.Left = pnlChapter2.Width / 2 - lblPhotos2lg.Width / 2;
            lblNationalities.Left = pnlChapter2.Width / 2 - lblNationalities.Width / 2;
            lblNationalitieslg.Left = pnlChapter2.Width / 2 - lblNationalitieslg.Width / 2;
            lblWhatTimeIsIt.Left = pnlChapter2.Width / 2 - lblWhatTimeIsIt.Width / 2;
            lblWhatTimeIsItlg.Left = pnlChapter2.Width / 2 - lblWhatTimeIsItlg.Width / 2;
            lblVerbs.Left = pnlChapter2.Width / 2 - lblVerbs.Width / 2;
            lblVerbslg.Left = pnlChapter2.Width / 2 - lblVerbslg.Width / 2;
            lblInterrogativeWords.Left = pnlChapter2.Width / 2 - lblInterrogativeWords.Width / 2;
            lblInterrogativeWordslg.Left = pnlChapter2.Width / 2 - lblInterrogativeWordslg.Width / 2;
            lblCountries.Left = pnlChapter2.Width / 2 - lblCountries.Width / 2;
            lblCountrieslg.Left = pnlChapter2.Width / 2 - lblCountrieslg.Width / 2;
            lblILikeYouLike.Left = pnlChapter2.Width / 2 - lblILikeYouLike.Width / 2;
            lblILikeYouLikelg.Left = pnlChapter2.Width / 2 - lblILikeYouLikelg.Width / 2;

            //pnlChapter3
            pnlChapter3.Location = new Point(Width / 2 - pnlChapter3.Width / 2, Height / 2 - pnlChapter3.Height / 2);
            lblCapitulo3.Left = pnlChapter3.Width / 2 - lblCapitulo3.Width / 2;
            lblTranslation3.Left = pnlChapter3.Width / 2 - lblTranslation3.Width / 2;
            lblTranslation3lg.Left = pnlChapter3.Width / 2 - lblTranslation3lg.Width / 2;
            lblPhotos3.Left = pnlChapter3.Width / 2 - lblPhotos3.Width / 2;
            lblPhotos3lg.Left = pnlChapter3.Width / 2 - lblPhotos3lg.Width / 2;
            lblSchedule.Left = pnlChapter3.Width / 2 - lblSchedule.Width / 2;
            lblSchedulelg.Left = pnlChapter3.Width / 2 - lblSchedulelg.Width / 2;
            lblBigNumbers.Left = pnlChapter3.Width / 2 - lblBigNumbers.Width / 2;
            lblBigNumberslg.Left = pnlChapter3.Width / 2 - lblBigNumberslg.Width / 2;
            lblBuildings.Left = pnlChapter3.Width / 2 - lblBuildings.Width / 2;
            lblBuildingslg.Left = pnlChapter3.Width / 2 - lblBuildingslg.Width / 2;
            lblPronouns.Left = pnlChapter3.Width / 2 - lblPronouns.Width / 2;
            lblPronounslg.Left = pnlChapter3.Width / 2 - lblPronounslg.Width / 2;
            lblWhereIsIt.Left = pnlChapter3.Width / 2 - lblWhereIsIt.Width / 2;
            lblWhereIsItlg.Left = pnlChapter3.Width / 2 - lblWhereIsItlg.Width / 2;
            lblVerbos2.Left = pnlChapter3.Width / 2 - lblVerbos2.Width / 2;
            lblVerbos2lg.Left = pnlChapter3.Width / 2 - lblVerbos2lg.Width / 2;

            //pnlChapter4
            pnlChapter4.Location = new Point(Width / 2 - pnlChapter4.Width / 2, Height / 2 - pnlChapter4.Height / 2);
            lblCapitulo4.Left = pnlChapter4.Width / 2 - lblCapitulo4.Width / 2;
            lblTranslation4.Left = pnlChapter4.Width / 2 - lblTranslation4.Width / 2;
            lblTranslation4lg.Left = pnlChapter4.Width / 2 - lblTranslation4lg.Width / 2;
            lblPhotos4.Left = pnlChapter4.Width / 2 - lblPhotos4.Width / 2;
            lblPhotos4lg.Left = pnlChapter4.Width / 2 - lblPhotos4lg.Width / 2;
            lblFamily.Left = pnlChapter4.Width / 2 - lblFamily.Width / 2;
            lblFamilylg.Left = pnlChapter4.Width / 2 - lblFamilylg.Width / 2;
            lblVerbs3.Left = pnlChapter4.Width / 2 - lblVerbs3.Width / 2;
            lblVerbs3lg.Left = pnlChapter4.Width / 2 - lblVerbs3lg.Width / 2;
            lblAdjetives.Left = pnlChapter4.Width / 2 - lblAdjetives.Width / 2;
            lblAdjetiveslg.Left = pnlChapter4.Width / 2 - lblAdjetiveslg.Width / 2;
            lblPlacesToGo.Left = pnlChapter4.Width / 2 - lblPlacesToGo.Width / 2;
            lblPlacesToGolg.Left = pnlChapter4.Width / 2 - lblPlacesToGolg.Width / 2;
            lblFinal.Left = pnlChapter4.Width / 2 - lblFinal.Width / 2;
            lblFinallg.Left = pnlChapter4.Width / 2 - lblFinallg.Width / 2;

            //Other
            lblBack.Left = pnlChapter1.Left - lblBack.Width;
            lblForward.Left = pnlChapter1.Width;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapters
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lblChapter1_MouseMove(object sender, MouseEventArgs e)
        {
            lblChapter1.Visible = false;
            lblChapter2.Visible = true;
            lblChapter3.Visible = true;
            lblChapter4.Visible = true;
            lblChapter1lg.Visible = true;
            lblChapter2lg.Visible = false;
            lblChapter3lg.Visible = false;
            lblChapter4lg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblChapter1lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblChapter1lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }
        private void lblChapter1lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblChapter1lg.ForeColor = Color.FromArgb(0, 164, 164);
                pnlChapters.Visible = false;
                pnlChapter1.Visible = true;
                chapter1Enabled = true;
                lblBack.Visible = true;

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblChapter1lg_MouseLeave(object sender, EventArgs e)
        {
            lblChapter1.Visible = true;
            lblChapter2.Visible = true;
            lblChapter3.Visible = true;
            lblChapter4.Visible = true;
            lblChapter1lg.Visible = false;
            lblChapter2lg.Visible = false;
            lblChapter3lg.Visible = false;
            lblChapter4lg.Visible = false;
        }

        private void lblChapter2_MouseMove(object sender, MouseEventArgs e)
        {
            lblChapter1.Visible = true;
            lblChapter2.Visible = false;
            lblChapter3.Visible = true;
            lblChapter4.Visible = true;
            lblChapter1lg.Visible = false;
            lblChapter2lg.Visible = true;
            lblChapter3lg.Visible = false;
            lblChapter4lg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblChapter2lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblChapter2lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblChapter2lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblChapter2lg.ForeColor = Color.FromArgb(0, 164, 164);
                pnlChapters.Visible = false;
                pnlChapter2.Visible = true;
                chapter2Enabled = true;
                lblBack.Visible = true;

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblChapter2lg_MouseLeave(object sender, EventArgs e)
        {
            lblChapter1.Visible = true;
            lblChapter2.Visible = true;
            lblChapter3.Visible = true;
            lblChapter4.Visible = true;
            lblChapter1lg.Visible = false;
            lblChapter2lg.Visible = false;
            lblChapter3lg.Visible = false;
            lblChapter4lg.Visible = false;
        }

        private void lblChapter3_MouseMove(object sender, MouseEventArgs e)
        {
            lblChapter1.Visible = true;
            lblChapter2.Visible = true;
            lblChapter3.Visible = false;
            lblChapter4.Visible = true;
            lblChapter1lg.Visible = false;
            lblChapter2lg.Visible = false;
            lblChapter3lg.Visible = true;
            lblChapter4lg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblChapter3lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblChapter3lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblChapter3lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblChapter3lg.ForeColor = Color.FromArgb(0, 164, 164);
                pnlChapters.Visible = false;
                pnlChapter3.Visible = true;
                chapter3Enabled = true;
                lblBack.Visible = true;

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblChapter3lg_MouseLeave(object sender, EventArgs e)
        {
            lblChapter1.Visible = true;
            lblChapter2.Visible = true;
            lblChapter3.Visible = true;
            lblChapter4.Visible = true;
            lblChapter1lg.Visible = false;
            lblChapter2lg.Visible = false;
            lblChapter3lg.Visible = false;
            lblChapter4lg.Visible = false;
        }

        private void lblChapter4_MouseMove(object sender, MouseEventArgs e)
        {
            lblChapter1.Visible = true;
            lblChapter2.Visible = true;
            lblChapter3.Visible = true;
            lblChapter4.Visible = false;
            lblChapter1lg.Visible = false;
            lblChapter2lg.Visible = false;
            lblChapter3lg.Visible = false;
            lblChapter4lg.Visible = true;

            if(soundEnabled == true)
            {
            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
            }
        }

        private void lblChapter4lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblChapter4lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblChapter4lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblChapter4lg.ForeColor = Color.FromArgb(0, 164, 164);
                pnlChapters.Visible = false;
                pnlChapter4.Visible = true;
                chapter4Enabled = true;
                lblBack.Visible = true;

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblChapter4lg_MouseLeave(object sender, EventArgs e)
        {
            lblChapter1.Visible = true;
            lblChapter2.Visible = true;
            lblChapter3.Visible = true;
            lblChapter4.Visible = true;
            lblChapter1lg.Visible = false;
            lblChapter2lg.Visible = false;
            lblChapter3lg.Visible = false;
            lblChapter4lg.Visible = false;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 1
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void lblTranslation_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation.Visible = false;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = true;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblTranslationlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblTranslationlg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblTranslationlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblTranslationlg.ForeColor = Color.FromArgb(0, 164, 164);

                ch1TranslationGame.questionsInGame = 268;

                if (ch1TranslationGame.questionsInGame > 0)
                {
                    ch1TranslationGameEnabled = true;
                    lblCh1TranslationGameTitle.Text = "Cap 1: Traducción";
                    pnlChapter1.Visible = false;
                    pnlCh1TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch1TranslationGame.Randomize_Questions();
                    ch1TranslationGame.minutes = 30;
                    ch1TranslationGame.seconds = 0;
                    ch1TranslationGame.questionNumber = 1;
                    ch1TranslationGame.score = 0;
                    ch1TranslationGame.antiScore = 0;
                    ch1TranslationGame.index = 0;
                    ch1TranslationGame.text = string.Empty;
                    ch1TranslationGame.yourAnswer = string.Empty;
                    tmrCh1TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh1TranslationGameTime.Text = ch1TranslationGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1TranslationGame.seconds.ToString().PadLeft(2, '0');
                    lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1TranslationGame.score);
                    lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1TranslationGame.antiScore);
                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1TranslationGame.questionNumber) + " of " + Convert.ToString(ch1TranslationGame.questionsInGame);
                    lblCh1TranslationGameAnswer.Text = string.Empty;
                    lblCh1TranslationGameYourAnswer.Text = string.Empty;
                    ch1TranslationGame.index = 0;
                    lblCh1TranslationGameQuestion.Text = ch1TranslationGame.Get_Question(ch1TranslationGame.randomOrder[ch1TranslationGame.index]);
                    txtCh1TranslationGameAnswer.Text = string.Empty;
                    txtCh1TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblTranslationlg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;
        }

        private void lblPhotos_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = false;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = true;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblPhotoslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPhotoslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblPhotoslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPhotoslg.ForeColor = Color.FromArgb(0, 164, 164);

                if (ch1PhotoGame.questionsInGame > 0)
                {

                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblPhotoslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;
        }

        private void lblLetters_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = false;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = true;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblLetterslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblLetterslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblLetterslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblLetterslg.ForeColor = Color.FromArgb(0, 164, 164);

                ch1LetterGame.questionsInGame = 27;

                if (ch1LetterGame.questionsInGame > 0)
                {
                    ch1LetterGameEnabled = true;
                    lblCh1TranslationGameTitle.Text = "Cap 1: Letras";
                    pnlChapter1.Visible = false;
                    pnlCh1TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch1LetterGame.Randomize_Questions();
                    ch1LetterGame.minutes = 2;
                    ch1LetterGame.seconds = 0;
                    ch1LetterGame.questionNumber = 1;
                    ch1LetterGame.score = 0;
                    ch1LetterGame.antiScore = 0;
                    ch1LetterGame.index = 0;
                    ch1LetterGame.text = string.Empty;
                    ch1LetterGame.yourAnswer = string.Empty;
                    tmrCh1TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh1TranslationGameTime.Text = ch1LetterGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1LetterGame.seconds.ToString().PadLeft(2, '0');
                    lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1LetterGame.score);
                    lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1LetterGame.antiScore);
                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1LetterGame.questionNumber) + " of " + Convert.ToString(ch1LetterGame.questionsInGame);
                    lblCh1TranslationGameAnswer.Text = string.Empty;
                    lblCh1TranslationGameYourAnswer.Text = string.Empty;
                    ch1LetterGame.index = 0;
                    lblCh1TranslationGameQuestion.Text = ch1LetterGame.Get_Question(ch1LetterGame.randomOrder[ch1LetterGame.index]);
                    txtCh1TranslationGameAnswer.Text = string.Empty;
                    txtCh1TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblLetterslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;
        }

        private void lblNumbers_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = false;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = true;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblNumberslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblNumberslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblNumberslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblNumberslg.ForeColor = Color.FromArgb(0, 164, 164);

                ch1NumberGame.questionsInGame = 38;

                if (ch1NumberGame.questionsInGame > 0)
                {
                    ch1NumberGameEnabled = true;
                    lblCh1TranslationGameTitle.Text = "Cap 1: Números";
                    pnlChapter1.Visible = false;
                    pnlCh1TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch1NumberGame.Randomize_Questions();
                    ch1NumberGame.minutes = 5;
                    ch1NumberGame.seconds = 0;
                    ch1NumberGame.questionNumber = 1;
                    ch1NumberGame.score = 0;
                    ch1NumberGame.antiScore = 0;
                    ch1NumberGame.index = 0;
                    ch1NumberGame.text = string.Empty;
                    ch1NumberGame.yourAnswer = string.Empty;
                    tmrCh1TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh1TranslationGameTime.Text = ch1NumberGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1NumberGame.seconds.ToString().PadLeft(2, '0');
                    lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1NumberGame.score);
                    lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1NumberGame.antiScore);
                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1NumberGame.questionNumber) + " of " + Convert.ToString(ch1NumberGame.questionsInGame);
                    lblCh1TranslationGameAnswer.Text = string.Empty;
                    lblCh1TranslationGameYourAnswer.Text = string.Empty;
                    ch1NumberGame.index = 0;
                    lblCh1TranslationGameQuestion.Text = ch1NumberGame.Get_Question(ch1NumberGame.randomOrder[ch1NumberGame.index]);
                    txtCh1TranslationGameAnswer.Text = string.Empty;
                    txtCh1TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblNumberslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;
        }

        private void lblColors_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = false;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = true;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblColorslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblColorslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblColorslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblColorslg.ForeColor = Color.FromArgb(0, 164, 164);

                ch1ColorGame.questionsInGame = 18;

                if (ch1ColorGame.questionsInGame > 0)
                {
                    ch1ColorGameEnabled = true;
                    lblCh1TranslationGameTitle.Text = "Cap 1: Colores";
                    pnlChapter1.Visible = false;
                    pnlCh1TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch1ColorGame.Randomize_Questions();
                    ch1ColorGame.minutes = 3;
                    ch1ColorGame.seconds = 0;
                    ch1ColorGame.questionNumber = 1;
                    ch1ColorGame.score = 0;
                    ch1ColorGame.antiScore = 0;
                    ch1ColorGame.index = 0;
                    ch1ColorGame.text = string.Empty;
                    ch1ColorGame.yourAnswer = string.Empty;
                    tmrCh1TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh1TranslationGameTime.Text = ch1ColorGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1ColorGame.seconds.ToString().PadLeft(2, '0');
                    lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1ColorGame.score);
                    lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1ColorGame.antiScore);
                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1ColorGame.questionNumber) + " of " + Convert.ToString(ch1ColorGame.questionsInGame);
                    lblCh1TranslationGameAnswer.Text = string.Empty;
                    lblCh1TranslationGameYourAnswer.Text = string.Empty;
                    ch1ColorGame.index = 0;
                    lblCh1TranslationGameQuestion.Text = ch1ColorGame.Get_Question(ch1ColorGame.randomOrder[ch1ColorGame.index]);
                    txtCh1TranslationGameAnswer.Text = string.Empty;
                    txtCh1TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblColorslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;
        }

        private void lblDaysWeek_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = false;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = true;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblDaysWeeklg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblDaysWeeklg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblDaysWeeklg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblDaysWeeklg.ForeColor = Color.FromArgb(0, 164, 164);

                ch1DaysOfTheWeekGame.questionsInGame = 7;

                if (ch1DaysOfTheWeekGame.questionsInGame > 0)
                {
                    ch1DaysOfTheWeekGameEnabled = true;
                    lblCh1TranslationGameTitle.Text = "Cap 1: Los Días de la Semana";
                    pnlChapter1.Visible = false;
                    pnlCh1TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch1DaysOfTheWeekGame.Randomize_Questions();
                    ch1DaysOfTheWeekGame.minutes = 2;
                    ch1DaysOfTheWeekGame.seconds = 0;
                    ch1DaysOfTheWeekGame.questionNumber = 1;
                    ch1DaysOfTheWeekGame.score = 0;
                    ch1DaysOfTheWeekGame.antiScore = 0;
                    ch1DaysOfTheWeekGame.index = 0;
                    ch1DaysOfTheWeekGame.text = string.Empty;
                    ch1DaysOfTheWeekGame.yourAnswer = string.Empty;
                    tmrCh1TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh1TranslationGameTime.Text = ch1DaysOfTheWeekGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1DaysOfTheWeekGame.seconds.ToString().PadLeft(2, '0');
                    lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.score);
                    lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.antiScore);
                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1DaysOfTheWeekGame.questionNumber) + " of " + Convert.ToString(ch1DaysOfTheWeekGame.questionsInGame);
                    lblCh1TranslationGameAnswer.Text = string.Empty;
                    lblCh1TranslationGameYourAnswer.Text = string.Empty;
                    ch1DaysOfTheWeekGame.index = 0;
                    lblCh1TranslationGameQuestion.Text = ch1DaysOfTheWeekGame.Get_Question(ch1DaysOfTheWeekGame.randomOrder[ch1DaysOfTheWeekGame.index]);
                    txtCh1TranslationGameAnswer.Text = string.Empty;
                    txtCh1TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblDaysWeeklg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;
        }

        private void lblMonthsYear_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = false;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = true;
            lblSeasonsYearlg.Visible = false;

            if(soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblMonthsYearlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblMonthsYearlg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblMonthsYearlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblMonthsYearlg.ForeColor = Color.FromArgb(0, 164, 164);

                ch1MonthsOfTheYearGame.questionsInGame = 12;

                if (ch1MonthsOfTheYearGame.questionsInGame > 0)
                {
                    ch1MonthsOfTheYearGameEnabled = true;
                    lblCh1TranslationGameTitle.Text = "Cap 1: Los Meses Del Año";
                    pnlChapter1.Visible = false;
                    pnlCh1TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch1MonthsOfTheYearGame.Randomize_Questions();
                    ch1MonthsOfTheYearGame.minutes = 2;
                    ch1MonthsOfTheYearGame.seconds = 0;
                    ch1MonthsOfTheYearGame.questionNumber = 1;
                    ch1MonthsOfTheYearGame.score = 0;
                    ch1MonthsOfTheYearGame.antiScore = 0;
                    ch1MonthsOfTheYearGame.index = 0;
                    ch1MonthsOfTheYearGame.text = string.Empty;
                    ch1MonthsOfTheYearGame.yourAnswer = string.Empty;
                    tmrCh1TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh1TranslationGameTime.Text = ch1MonthsOfTheYearGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1MonthsOfTheYearGame.seconds.ToString().PadLeft(2, '0');
                    lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.score);
                    lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.antiScore);
                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1MonthsOfTheYearGame.questionNumber) + " of " + Convert.ToString(ch1MonthsOfTheYearGame.questionsInGame);
                    lblCh1TranslationGameAnswer.Text = string.Empty;
                    lblCh1TranslationGameYourAnswer.Text = string.Empty;
                    ch1MonthsOfTheYearGame.index = 0;
                    lblCh1TranslationGameQuestion.Text = ch1MonthsOfTheYearGame.Get_Question(ch1MonthsOfTheYearGame.randomOrder[ch1MonthsOfTheYearGame.index]);
                    txtCh1TranslationGameAnswer.Text = string.Empty;
                    txtCh1TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblMonthsYearlg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;
        }

        private void lblSeasonsYear_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = false;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = true;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblSeasonsYearlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblSeasonsYearlg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblSeasonsYearlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblSeasonsYearlg.ForeColor = Color.FromArgb(0, 164, 164);

                ch1SeasonsOfTheYearGame.questionsInGame = 4;

                if (ch1SeasonsOfTheYearGame.questionsInGame > 0)
                {
                    ch1SeasonsOfTheYearGameEnabled = true;
                    lblCh1TranslationGameTitle.Text = "Cap 1: Las Estaciones Del Año";
                    pnlChapter1.Visible = false;
                    pnlCh1TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch1SeasonsOfTheYearGame.Randomize_Questions();
                    ch1SeasonsOfTheYearGame.minutes = 1;
                    ch1SeasonsOfTheYearGame.seconds = 0;
                    ch1SeasonsOfTheYearGame.questionNumber = 1;
                    ch1SeasonsOfTheYearGame.score = 0;
                    ch1SeasonsOfTheYearGame.antiScore = 0;
                    ch1SeasonsOfTheYearGame.index = 0;
                    ch1SeasonsOfTheYearGame.text = string.Empty;
                    ch1SeasonsOfTheYearGame.yourAnswer = string.Empty;
                    tmrCh1TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh1TranslationGameTime.Text = ch1SeasonsOfTheYearGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1SeasonsOfTheYearGame.seconds.ToString().PadLeft(2, '0');
                    lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.score);
                    lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.antiScore);
                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1SeasonsOfTheYearGame.questionNumber) + " of " + Convert.ToString(ch1SeasonsOfTheYearGame.questionsInGame);
                    lblCh1TranslationGameAnswer.Text = string.Empty;
                    lblCh1TranslationGameYourAnswer.Text = string.Empty;
                    ch1SeasonsOfTheYearGame.index = 0;
                    lblCh1TranslationGameQuestion.Text = ch1SeasonsOfTheYearGame.Get_Question(ch1SeasonsOfTheYearGame.randomOrder[ch1SeasonsOfTheYearGame.index]);
                    txtCh1TranslationGameAnswer.Text = string.Empty;
                    txtCh1TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblSeasonsYearlg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation.Visible = true;
            lblPhotos.Visible = true;
            lblLetters.Visible = true;
            lblNumbers.Visible = true;
            lblColors.Visible = true;
            lblDaysWeek.Visible = true;
            lblMonthsYear.Visible = true;
            lblSeasonsYear.Visible = true;
            lblTranslationlg.Visible = false;
            lblPhotoslg.Visible = false;
            lblLetterslg.Visible = false;
            lblNumberslg.Visible = false;
            lblColorslg.Visible = false;
            lblDaysWeeklg.Visible = false;
            lblMonthsYearlg.Visible = false;
            lblSeasonsYearlg.Visible = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 2
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lblTranslation2_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation2.Visible = false;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = true;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblTranslation2lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblTranslation2lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblTranslation2lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblTranslation2lg.ForeColor = Color.FromArgb(0, 164, 164);

                ch2TranslationGame.questionsInGame = 484;

                if (ch2TranslationGame.questionsInGame > 0)
                {
                    ch2TranslationGameEnabled = true;
                    lblCh2TranslationGameTitle.Text = "Cap 2: Traducción";
                    pnlChapter2.Visible = false;
                    pnlCh2TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch2TranslationGame.Randomize_Questions();
                    ch2TranslationGame.minutes = 60;
                    ch2TranslationGame.seconds = 0;
                    ch2TranslationGame.questionNumber = 1;
                    ch2TranslationGame.score = 0;
                    ch2TranslationGame.antiScore = 0;
                    ch2TranslationGame.index = 0;
                    ch2TranslationGame.text = string.Empty;
                    ch2TranslationGame.yourAnswer = string.Empty;
                    tmrCh2TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh2TranslationGameTime.Text = ch2TranslationGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2TranslationGame.seconds.ToString().PadLeft(2, '0');
                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2TranslationGame.score);
                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2TranslationGame.antiScore);
                    lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2TranslationGame.questionNumber) + " of " + Convert.ToString(ch2TranslationGame.questionsInGame);
                    lblCh2TranslationGameAnswer.Text = string.Empty;
                    lblCh2TranslationGameYourAnswer.Text = string.Empty;
                    ch2TranslationGame.index = 0;
                    lblCh2TranslationGameQuestion.Text = ch2TranslationGame.Get_Question(ch2TranslationGame.randomOrder[ch2TranslationGame.index]);
                    txtCh2TranslationGameAnswer.Text = string.Empty;
                    txtCh2TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }

            }
        }

        private void lblTranslation2lg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;
        }

        private void lblPhotos2_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = false;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = true;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblPhotos2lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPhotos2lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblPhotos2lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPhotos2lg.ForeColor = Color.FromArgb(0, 164, 164);

                if (ch2PhotoGame.questionsInGame > 0)
                {

                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblPhotos2lg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;
        }

        private void lblNationalities_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = false;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = true;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblNationalitieslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblNationalitieslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblNationalitieslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblNationalitieslg.ForeColor = Color.FromArgb(0, 164, 164);

                ch2NationalitiesGame.questionsInGame = 52;

                if (ch2NationalitiesGame.questionsInGame > 0)
                {
                    ch2NationalitiesGameEnabled = true;
                    lblCh2TranslationGameTitle.Text = "Cap 2: Nacionalidades";
                    pnlChapter2.Visible = false;
                    pnlCh2TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch2NationalitiesGame.Randomize_Questions();
                    ch2NationalitiesGame.minutes = 10;
                    ch2NationalitiesGame.seconds = 0;
                    ch2NationalitiesGame.questionNumber = 1;
                    ch2NationalitiesGame.score = 0;
                    ch2NationalitiesGame.antiScore = 0;
                    ch2NationalitiesGame.index = 0;
                    ch2NationalitiesGame.text = string.Empty;
                    ch2NationalitiesGame.yourAnswer = string.Empty;
                    tmrCh2TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh2TranslationGameTime.Text = ch2NationalitiesGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2NationalitiesGame.seconds.ToString().PadLeft(2, '0');
                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2NationalitiesGame.score);
                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2NationalitiesGame.antiScore);
                    lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2NationalitiesGame.questionNumber) + " of " + Convert.ToString(ch2NationalitiesGame.questionsInGame);
                    lblCh2TranslationGameAnswer.Text = string.Empty;
                    lblCh2TranslationGameYourAnswer.Text = string.Empty;
                    ch2NationalitiesGame.index = 0;
                    lblCh2TranslationGameQuestion.Text = ch2NationalitiesGame.Get_Question(ch2NationalitiesGame.randomOrder[ch2NationalitiesGame.index]);
                    txtCh2TranslationGameAnswer.Text = string.Empty;
                    txtCh2TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblNationalitieslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;
        }

        private void lblWhatTimeIsIt_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = false;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = true;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblWhatTimeIsItlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblWhatTimeIsItlg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblWhatTimeIsItlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblWhatTimeIsItlg.ForeColor = Color.FromArgb(0, 164, 164);

                ch2WhatTimeIsItGame.questionsInGame = 17;

                if (ch2WhatTimeIsItGame.questionsInGame > 0)
                {
                    ch2WhatTimeIsItGameEnabled = true;
                    lblCh2TranslationGameTitle.Text = "Cap 2: ¿Qué hora es?";
                    pnlChapter2.Visible = false;
                    pnlCh2TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch2WhatTimeIsItGame.Randomize_Questions();
                    ch2WhatTimeIsItGame.minutes = 5;
                    ch2WhatTimeIsItGame.seconds = 0;
                    ch2WhatTimeIsItGame.questionNumber = 1;
                    ch2WhatTimeIsItGame.score = 0;
                    ch2WhatTimeIsItGame.antiScore = 0;
                    ch2WhatTimeIsItGame.index = 0;
                    ch2WhatTimeIsItGame.text = string.Empty;
                    ch2WhatTimeIsItGame.yourAnswer = string.Empty;
                    tmrCh2TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh2TranslationGameTime.Text = ch2WhatTimeIsItGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2WhatTimeIsItGame.seconds.ToString().PadLeft(2, '0');
                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.score);
                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.antiScore);
                    lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2WhatTimeIsItGame.questionNumber) + " of " + Convert.ToString(ch2WhatTimeIsItGame.questionsInGame);
                    lblCh2TranslationGameAnswer.Text = string.Empty;
                    lblCh2TranslationGameYourAnswer.Text = string.Empty;
                    ch2WhatTimeIsItGame.index = 0;
                    lblCh2TranslationGameQuestion.Text = ch2WhatTimeIsItGame.Get_Question(ch2WhatTimeIsItGame.randomOrder[ch2WhatTimeIsItGame.index]);
                    txtCh2TranslationGameAnswer.Text = string.Empty;
                    txtCh2TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblWhatTimeIsItlg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;
        }

        private void lblVerbs_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = false;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = true;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblVerbslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblVerbslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblVerbslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblVerbslg.ForeColor = Color.FromArgb(0, 164, 164);

                ch2VerbsGame.questionsInGame = 320;

                if (ch2VerbsGame.questionsInGame > 0)
                {
                    ch2VerbsGameEnabled = true;
                    lblCh2TranslationGameTitle.Text = "Cap 2: Verbos";
                    pnlChapter2.Visible = false;
                    pnlCh2TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch2VerbsGame.Randomize_Questions();
                    ch2VerbsGame.minutes = 60;
                    ch2VerbsGame.seconds = 0;
                    ch2VerbsGame.questionNumber = 1;
                    ch2VerbsGame.score = 0;
                    ch2VerbsGame.antiScore = 0;
                    ch2VerbsGame.index = 0;
                    ch2VerbsGame.text = string.Empty;
                    ch2VerbsGame.yourAnswer = string.Empty;
                    tmrCh2TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh2TranslationGameTime.Text = ch2VerbsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2VerbsGame.seconds.ToString().PadLeft(2, '0');
                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2VerbsGame.score);
                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2VerbsGame.antiScore);
                    lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2VerbsGame.questionNumber) + " of " + Convert.ToString(ch2VerbsGame.questionsInGame);
                    lblCh2TranslationGameAnswer.Text = string.Empty;
                    lblCh2TranslationGameYourAnswer.Text = string.Empty;
                    ch2VerbsGame.index = 0;
                    lblCh2TranslationGameQuestion.Text = ch2VerbsGame.Get_Question(ch2VerbsGame.randomOrder[ch2VerbsGame.index]);
                    txtCh2TranslationGameAnswer.Text = string.Empty;
                    txtCh2TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblVerbslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;
        }

        private void lblInterrogativeWords_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = false;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = true;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblInterrogativeWordslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblInterrogativeWordslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblInterrogativeWordslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblInterrogativeWordslg.ForeColor = Color.FromArgb(0, 164, 164);

                ch2InterrogativeWordsGame.questionsInGame = 17;

                if (ch2InterrogativeWordsGame.questionsInGame > 0)
                {
                    ch2InterrogativeWordsGameEnabled = true;
                    lblCh2TranslationGameTitle.Text = "Cap 2: Palabras interrogativas";
                    pnlChapter2.Visible = false;
                    pnlCh2TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch2InterrogativeWordsGame.Randomize_Questions();
                    ch2InterrogativeWordsGame.minutes = 3;
                    ch2InterrogativeWordsGame.seconds = 0;
                    ch2InterrogativeWordsGame.questionNumber = 1;
                    ch2InterrogativeWordsGame.score = 0;
                    ch2InterrogativeWordsGame.antiScore = 0;
                    ch2InterrogativeWordsGame.index = 0;
                    ch2InterrogativeWordsGame.text = string.Empty;
                    ch2InterrogativeWordsGame.yourAnswer = string.Empty;
                    tmrCh2TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh2TranslationGameTime.Text = ch2InterrogativeWordsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2InterrogativeWordsGame.seconds.ToString().PadLeft(2, '0');
                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.score);
                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.antiScore);
                    lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2InterrogativeWordsGame.questionNumber) + " of " + Convert.ToString(ch2InterrogativeWordsGame.questionsInGame);
                    lblCh2TranslationGameAnswer.Text = string.Empty;
                    lblCh2TranslationGameYourAnswer.Text = string.Empty;
                    ch2InterrogativeWordsGame.index = 0;
                    lblCh2TranslationGameQuestion.Text = ch2InterrogativeWordsGame.Get_Question(ch2InterrogativeWordsGame.randomOrder[ch2InterrogativeWordsGame.index]);
                    txtCh2TranslationGameAnswer.Text = string.Empty;
                    txtCh2TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblInterrogativeWordslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;
        }

        private void lblCountries_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = false;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = true;
            lblILikeYouLikelg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblCountrieslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblCountrieslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblCountrieslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblCountrieslg.ForeColor = Color.FromArgb(0, 164, 164);

                ch2CountriesGame.questionsInGame = 27;

                if (ch2CountriesGame.questionsInGame > 0)
                {
                    ch2CountriesGameEnabled = true;
                    lblCh2TranslationGameTitle.Text = "Cap 2: Países";
                    pnlChapter2.Visible = false;
                    pnlCh2TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch2CountriesGame.Randomize_Questions();
                    ch2CountriesGame.minutes = 5;
                    ch2CountriesGame.seconds = 0;
                    ch2CountriesGame.questionNumber = 1;
                    ch2CountriesGame.score = 0;
                    ch2CountriesGame.antiScore = 0;
                    ch2CountriesGame.index = 0;
                    ch2CountriesGame.text = string.Empty;
                    ch2CountriesGame.yourAnswer = string.Empty;
                    tmrCh2TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh2TranslationGameTime.Text = ch2CountriesGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2CountriesGame.seconds.ToString().PadLeft(2, '0');
                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2CountriesGame.score);
                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2CountriesGame.antiScore);
                    lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2CountriesGame.questionNumber) + " of " + Convert.ToString(ch2CountriesGame.questionsInGame);
                    lblCh2TranslationGameAnswer.Text = string.Empty;
                    lblCh2TranslationGameYourAnswer.Text = string.Empty;
                    ch2CountriesGame.index = 0;
                    lblCh2TranslationGameQuestion.Text = ch2CountriesGame.Get_Question(ch2CountriesGame.randomOrder[ch2CountriesGame.index]);
                    txtCh2TranslationGameAnswer.Text = string.Empty;
                    txtCh2TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblCountrieslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;
        }

        private void lblILikeYouLike_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = false;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = true;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblILikeYouLikelg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblILikeYouLikelg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblILikeYouLikelg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblILikeYouLikelg.ForeColor = Color.FromArgb(0, 164, 164);

                ch2ILikeYouLikeGame.questionsInGame = 64;

                if (ch2ILikeYouLikeGame.questionsInGame > 0)
                {
                    ch2ILikeYouLikeGameEnabled = true;
                    lblCh2TranslationGameTitle.Text = "Cap 2: Me Gusta / Te Gusta";
                    pnlChapter2.Visible = false;
                    pnlCh2TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch2ILikeYouLikeGame.Randomize_Questions();
                    ch2ILikeYouLikeGame.minutes = 10;
                    ch2ILikeYouLikeGame.seconds = 0;
                    ch2ILikeYouLikeGame.questionNumber = 1;
                    ch2ILikeYouLikeGame.score = 0;
                    ch2ILikeYouLikeGame.antiScore = 0;
                    ch2ILikeYouLikeGame.index = 0;
                    ch2ILikeYouLikeGame.text = string.Empty;
                    ch2ILikeYouLikeGame.yourAnswer = string.Empty;
                    tmrCh2TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh2TranslationGameTime.Text = ch2ILikeYouLikeGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2ILikeYouLikeGame.seconds.ToString().PadLeft(2, '0');
                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.score);
                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.antiScore);
                    lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2ILikeYouLikeGame.questionNumber) + " of " + Convert.ToString(ch2ILikeYouLikeGame.questionsInGame);
                    lblCh2TranslationGameAnswer.Text = string.Empty;
                    lblCh2TranslationGameYourAnswer.Text = string.Empty;
                    ch2ILikeYouLikeGame.index = 0;
                    lblCh2TranslationGameQuestion.Text = ch2ILikeYouLikeGame.Get_Question(ch2ILikeYouLikeGame.randomOrder[ch2ILikeYouLikeGame.index]);
                    txtCh2TranslationGameAnswer.Text = string.Empty;
                    txtCh2TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblILikeYouLikelg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation2.Visible = true;
            lblPhotos2.Visible = true;
            lblNationalities.Visible = true;
            lblWhatTimeIsIt.Visible = true;
            lblVerbs.Visible = true;
            lblInterrogativeWords.Visible = true;
            lblCountries.Visible = true;
            lblILikeYouLike.Visible = true;
            lblTranslation2lg.Visible = false;
            lblPhotos2lg.Visible = false;
            lblNationalitieslg.Visible = false;
            lblWhatTimeIsItlg.Visible = false;
            lblVerbslg.Visible = false;
            lblInterrogativeWordslg.Visible = false;
            lblCountrieslg.Visible = false;
            lblILikeYouLikelg.Visible = false;
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 3
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lblTranslation3_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation3.Visible = false;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = true;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblTranslation3lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblTranslation3lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblTranslation3lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblTranslation3lg.ForeColor = Color.FromArgb(0, 164, 164);

                ch3TranslationGame.questionsInGame = 224;

                if (ch3TranslationGame.questionsInGame > 0)
                {
                    ch3TranslationGameEnabled = true;
                    lblCh3TranslationGameTitle.Text = "Cap 3: Traducción";
                    pnlChapter3.Visible = false;
                    pnlCh3TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch3TranslationGame.Randomize_Questions();
                    ch3TranslationGame.minutes = 30;
                    ch3TranslationGame.seconds = 0;
                    ch3TranslationGame.questionNumber = 1;
                    ch3TranslationGame.score = 0;
                    ch3TranslationGame.antiScore = 0;
                    ch3TranslationGame.index = 0;
                    ch3TranslationGame.text = string.Empty;
                    ch3TranslationGame.yourAnswer = string.Empty;
                    tmrCh3TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh3TranslationGameTime.Text = ch3TranslationGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3TranslationGame.seconds.ToString().PadLeft(2, '0');
                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3TranslationGame.score);
                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3TranslationGame.antiScore);
                    lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3TranslationGame.questionNumber) + " of " + Convert.ToString(ch3TranslationGame.questionsInGame);
                    lblCh3TranslationGameAnswer.Text = string.Empty;
                    lblCh3TranslationGameYourAnswer.Text = string.Empty;
                    ch3TranslationGame.index = 0;
                    lblCh3TranslationGameQuestion.Text = ch3TranslationGame.Get_Question(ch3TranslationGame.randomOrder[ch3TranslationGame.index]);
                    txtCh3TranslationGameAnswer.Text = string.Empty;
                    txtCh3TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblTranslation3lg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;
        }

        private void lblPhotos3_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = false;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = true;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblPhotos3lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPhotos3lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblPhotos3lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPhotos3lg.ForeColor = Color.FromArgb(0, 164, 164);

                if (ch3PhotoGame.questionsInGame > 0)
                {

                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblPhotos3lg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;
        }

        private void lblSchedule_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = false;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = true;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblSchedulelg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblSchedulelg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblSchedulelg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblSchedulelg.ForeColor = Color.FromArgb(0, 164, 164);

                ch3ScheduleGame.questionsInGame = 28;

                if (ch3ScheduleGame.questionsInGame > 0)
                {
                    ch3ScheduleGameEnabled = true;
                    lblCh3TranslationGameTitle.Text = "Cap 3: Materias";
                    pnlChapter3.Visible = false;
                    pnlCh3TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch3ScheduleGame.Randomize_Questions();
                    ch3ScheduleGame.minutes = 5;
                    ch3ScheduleGame.seconds = 0;
                    ch3ScheduleGame.questionNumber = 1;
                    ch3ScheduleGame.score = 0;
                    ch3ScheduleGame.antiScore = 0;
                    ch3ScheduleGame.index = 0;
                    ch3ScheduleGame.text = string.Empty;
                    ch3ScheduleGame.yourAnswer = string.Empty;
                    tmrCh3TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh3TranslationGameTime.Text = ch3ScheduleGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3ScheduleGame.seconds.ToString().PadLeft(2, '0');
                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3ScheduleGame.score);
                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3ScheduleGame.antiScore);
                    lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3ScheduleGame.questionNumber) + " of " + Convert.ToString(ch3ScheduleGame.questionsInGame);
                    lblCh3TranslationGameAnswer.Text = string.Empty;
                    lblCh3TranslationGameYourAnswer.Text = string.Empty;
                    ch3ScheduleGame.index = 0;
                    lblCh3TranslationGameQuestion.Text = ch3ScheduleGame.Get_Question(ch3ScheduleGame.randomOrder[ch3ScheduleGame.index]);
                    txtCh3TranslationGameAnswer.Text = string.Empty;
                    txtCh3TranslationGameAnswer.Focus();
                }


                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblSchedulelg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;
        }

        private void lblBigNumbers_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = false;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = true;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblBigNumberslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblBigNumberslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblBigNumberslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblBigNumberslg.ForeColor = Color.FromArgb(0, 164, 164);

                ch3BigNumbersGame.questionsInGame = 21;

                if (ch3BigNumbersGame.questionsInGame > 0)
                {
                    ch3BigNumbersGameEnabled = true;
                    lblCh3TranslationGameTitle.Text = "Cap 3: Números Grande";
                    pnlChapter3.Visible = false;
                    pnlCh3TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch3BigNumbersGame.Randomize_Questions();
                    ch3BigNumbersGame.minutes = 5;
                    ch3BigNumbersGame.seconds = 0;
                    ch3BigNumbersGame.questionNumber = 1;
                    ch3BigNumbersGame.score = 0;
                    ch3BigNumbersGame.antiScore = 0;
                    ch3BigNumbersGame.index = 0;
                    ch3BigNumbersGame.text = string.Empty;
                    ch3BigNumbersGame.yourAnswer = string.Empty;
                    tmrCh3TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh3TranslationGameTime.Text = ch3BigNumbersGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3BigNumbersGame.seconds.ToString().PadLeft(2, '0');
                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3BigNumbersGame.score);
                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3BigNumbersGame.antiScore);
                    lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3BigNumbersGame.questionNumber) + " of " + Convert.ToString(ch3BigNumbersGame.questionsInGame);
                    lblCh3TranslationGameAnswer.Text = string.Empty;
                    lblCh3TranslationGameYourAnswer.Text = string.Empty;
                    ch3BigNumbersGame.index = 0;
                    lblCh3TranslationGameQuestion.Text = ch3BigNumbersGame.Get_Question(ch3BigNumbersGame.randomOrder[ch3BigNumbersGame.index]);
                    txtCh3TranslationGameAnswer.Text = string.Empty;
                    txtCh3TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblBigNumberslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;
        }

        private void lblBuildings_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = false;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = true;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblBuildingslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblBuildingslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblBuildingslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblBuildingslg.ForeColor = Color.FromArgb(0, 164, 164);

                ch3BuildingsGame.questionsInGame = 22;

                if (ch3BuildingsGame.questionsInGame > 0)
                {
                    ch3BuildingsGameEnabled = true;
                    lblCh3TranslationGameTitle.Text = "Cap 3: Edificios";
                    pnlChapter3.Visible = false;
                    pnlCh3TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch3BuildingsGame.Randomize_Questions();
                    ch3BuildingsGame.minutes = 5;
                    ch3BuildingsGame.seconds = 0;
                    ch3BuildingsGame.questionNumber = 1;
                    ch3BuildingsGame.score = 0;
                    ch3BuildingsGame.antiScore = 0;
                    ch3BuildingsGame.index = 0;
                    ch3BuildingsGame.text = string.Empty;
                    ch3BuildingsGame.yourAnswer = string.Empty;
                    tmrCh3TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh3TranslationGameTime.Text = ch3BuildingsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3BuildingsGame.seconds.ToString().PadLeft(2, '0');
                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3BuildingsGame.score);
                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3BuildingsGame.antiScore);
                    lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3BuildingsGame.questionNumber) + " of " + Convert.ToString(ch3BuildingsGame.questionsInGame);
                    lblCh3TranslationGameAnswer.Text = string.Empty;
                    lblCh3TranslationGameYourAnswer.Text = string.Empty;
                    ch3BuildingsGame.index = 0;
                    lblCh3TranslationGameQuestion.Text = ch3BuildingsGame.Get_Question(ch3BuildingsGame.randomOrder[ch3BuildingsGame.index]);
                    txtCh3TranslationGameAnswer.Text = string.Empty;
                    txtCh3TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblBuildingslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;
        }

        private void lblPronouns_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = false;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = true;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblPronounslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPronounslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblPronounslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPronounslg.ForeColor = Color.FromArgb(0, 164, 164);

                ch3PronounsGame.questionsInGame = 18;

                if (ch3PronounsGame.questionsInGame > 0)
                {
                    ch3PronounsGameEnabled = true;
                    lblCh3TranslationGameTitle.Text = "Cap 3: Pronombres";
                    pnlChapter3.Visible = false;
                    pnlCh3TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch3PronounsGame.Randomize_Questions();
                    ch3PronounsGame.minutes = 3;
                    ch3PronounsGame.seconds = 0;
                    ch3PronounsGame.questionNumber = 1;
                    ch3PronounsGame.score = 0;
                    ch3PronounsGame.antiScore = 0;
                    ch3PronounsGame.index = 0;
                    ch3PronounsGame.text = string.Empty;
                    ch3PronounsGame.yourAnswer = string.Empty;
                    tmrCh3TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh3TranslationGameTime.Text = ch3PronounsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3PronounsGame.seconds.ToString().PadLeft(2, '0');
                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3PronounsGame.score);
                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3PronounsGame.antiScore);
                    lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3PronounsGame.questionNumber) + " of " + Convert.ToString(ch3PronounsGame.questionsInGame);
                    lblCh3TranslationGameAnswer.Text = string.Empty;
                    lblCh3TranslationGameYourAnswer.Text = string.Empty;
                    ch3PronounsGame.index = 0;
                    lblCh3TranslationGameQuestion.Text = ch3PronounsGame.Get_Question(ch3PronounsGame.randomOrder[ch3PronounsGame.index]);
                    txtCh3TranslationGameAnswer.Text = string.Empty;
                    txtCh3TranslationGameAnswer.Focus();
                }


                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblPronounslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;
        }

        private void lblWhereIsIt_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = false;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = true;
            lblVerbos2lg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblWhereIsItlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblWhereIsItlg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblWhereIsItlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblWhereIsItlg.ForeColor = Color.FromArgb(0, 164, 164);

                ch3WhereIsItGame.questionsInGame = 17;

                if (ch3WhereIsItGame.questionsInGame > 0)
                {
                    ch3WhereIsItGameEnabled = true;
                    lblCh3TranslationGameTitle.Text = "Cap 3: Dónde Está";
                    pnlChapter3.Visible = false;
                    pnlCh3TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch3WhereIsItGame.Randomize_Questions();
                    ch3WhereIsItGame.minutes = 2;
                    ch3WhereIsItGame.seconds = 0;
                    ch3WhereIsItGame.questionNumber = 1;
                    ch3WhereIsItGame.score = 0;
                    ch3WhereIsItGame.antiScore = 0;
                    ch3WhereIsItGame.index = 0;
                    ch3WhereIsItGame.text = string.Empty;
                    ch3WhereIsItGame.yourAnswer = string.Empty;
                    tmrCh3TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh3TranslationGameTime.Text = ch3WhereIsItGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3WhereIsItGame.seconds.ToString().PadLeft(2, '0');
                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3WhereIsItGame.score);
                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3WhereIsItGame.antiScore);
                    lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3WhereIsItGame.questionNumber) + " of " + Convert.ToString(ch3WhereIsItGame.questionsInGame);
                    lblCh3TranslationGameAnswer.Text = string.Empty;
                    lblCh3TranslationGameYourAnswer.Text = string.Empty;
                    ch3WhereIsItGame.index = 0;
                    lblCh3TranslationGameQuestion.Text = ch3WhereIsItGame.Get_Question(ch3WhereIsItGame.randomOrder[ch3WhereIsItGame.index]);
                    txtCh3TranslationGameAnswer.Text = string.Empty;
                    txtCh3TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblWhereIsItlg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;
        }

        private void lblVerbos2_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = false;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = true;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblVerbos2lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblVerbos2lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblVerbos2lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblVerbos2lg.ForeColor = Color.FromArgb(0, 164, 164);

                ch3VerbsGame.questionsInGame = 30;

                if (ch3VerbsGame.questionsInGame > 0)
                {
                    ch3VerbsGameEnabled = true;
                    lblCh3TranslationGameTitle.Text = "Cap 3: Verbos";
                    pnlChapter3.Visible = false;
                    pnlCh3TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch3VerbsGame.Randomize_Questions();
                    ch3VerbsGame.minutes = 10;
                    ch3VerbsGame.seconds = 0;
                    ch3VerbsGame.questionNumber = 1;
                    ch3VerbsGame.score = 0;
                    ch3VerbsGame.antiScore = 0;
                    ch3VerbsGame.index = 0;
                    ch3VerbsGame.text = string.Empty;
                    ch3VerbsGame.yourAnswer = string.Empty;
                    tmrCh3TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh3TranslationGameTime.Text = ch3VerbsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3VerbsGame.seconds.ToString().PadLeft(2, '0');
                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3VerbsGame.score);
                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3VerbsGame.antiScore);
                    lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3VerbsGame.questionNumber) + " of " + Convert.ToString(ch3VerbsGame.questionsInGame);
                    lblCh3TranslationGameAnswer.Text = string.Empty;
                    lblCh3TranslationGameYourAnswer.Text = string.Empty;
                    ch3VerbsGame.index = 0;
                    lblCh3TranslationGameQuestion.Text = ch3VerbsGame.Get_Question(ch3VerbsGame.randomOrder[ch3VerbsGame.index]);
                    txtCh3TranslationGameAnswer.Text = string.Empty;
                    txtCh3TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblVerbos2lg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation3.Visible = true;
            lblPhotos3.Visible = true;
            lblSchedule.Visible = true;
            lblBigNumbers.Visible = true;
            lblBuildings.Visible = true;
            lblPronouns.Visible = true;
            lblWhereIsIt.Visible = true;
            lblVerbos2.Visible = true;
            lblTranslation3lg.Visible = false;
            lblPhotos3lg.Visible = false;
            lblSchedulelg.Visible = false;
            lblBigNumberslg.Visible = false;
            lblBuildingslg.Visible = false;
            lblPronounslg.Visible = false;
            lblWhereIsItlg.Visible = false;
            lblVerbos2lg.Visible = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 4
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lblTranslation4_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation4.Visible = false;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = true;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblTranslation4lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblTranslation4lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblTranslation4lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblTranslation4lg.ForeColor = Color.FromArgb(0, 164, 164);

                ch4TranslationGame.questionsInGame = 387;

                if (ch4TranslationGame.questionsInGame > 0)
                {
                    ch4TranslationGameEnabled = true;
                    lblCh4TranslationGameTitle.Text = "Cap 4: Traducción";
                    pnlChapter4.Visible = false;
                    pnlCh4TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch4TranslationGame.Randomize_Questions();
                    ch4TranslationGame.minutes = 60;
                    ch4TranslationGame.seconds = 0;
                    ch4TranslationGame.questionNumber = 1;
                    ch4TranslationGame.score = 0;
                    ch4TranslationGame.antiScore = 0;
                    ch4TranslationGame.index = 0;
                    ch4TranslationGame.text = string.Empty;
                    ch4TranslationGame.yourAnswer = string.Empty;
                    tmrCh4TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh4TranslationGameTime.Text = ch4TranslationGame.minutes.ToString().PadLeft(2, '0') + ":" + ch4TranslationGame.seconds.ToString().PadLeft(2, '0');
                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4TranslationGame.score);
                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4TranslationGame.antiScore);
                    lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4TranslationGame.questionNumber) + " of " + Convert.ToString(ch4TranslationGame.questionsInGame);
                    lblCh4TranslationGameAnswer.Text = string.Empty;
                    lblCh4TranslationGameYourAnswer.Text = string.Empty;
                    ch4TranslationGame.index = 0;
                    lblCh4TranslationGameQuestion.Text = ch4TranslationGame.Get_Question(ch4TranslationGame.randomOrder[ch4TranslationGame.index]);
                    txtCh4TranslationGameAnswer.Text = string.Empty;
                    txtCh4TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblTranslation4lg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;
        }

        private void lblPhotos4_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = false;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = true;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblPhotos4lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPhotos4lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblPhotos4lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPhotos4lg.ForeColor = Color.FromArgb(0, 164, 164);

                if (ch4PhotoGame.questionsInGame > 0)
                {

                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblPhotos4lg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;
        }

        private void lblFamily_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = false;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = true;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblFamilylg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblFamilylg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblFamilylg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblFamilylg.ForeColor = Color.FromArgb(0, 164, 164);

                ch4MembersOfTheFamilyGame.questionsInGame = 32;

                if (ch4MembersOfTheFamilyGame.questionsInGame > 0)
                {
                    ch4MembersOfTheFamilyGameEnabled = true;
                    lblCh4TranslationGameTitle.Text = "Cap 4: Miembros de la Familia";
                    pnlChapter4.Visible = false;
                    pnlCh4TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch4MembersOfTheFamilyGame.Randomize_Questions();
                    ch4MembersOfTheFamilyGame.minutes = 10;
                    ch4MembersOfTheFamilyGame.seconds = 0;
                    ch4MembersOfTheFamilyGame.questionNumber = 1;
                    ch4MembersOfTheFamilyGame.score = 0;
                    ch4MembersOfTheFamilyGame.antiScore = 0;
                    ch4MembersOfTheFamilyGame.index = 0;
                    ch4MembersOfTheFamilyGame.text = string.Empty;
                    ch4MembersOfTheFamilyGame.yourAnswer = string.Empty;
                    tmrCh4TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh4TranslationGameTime.Text = ch4MembersOfTheFamilyGame.minutes.ToString().PadLeft(2, '0') + ":" + ch4MembersOfTheFamilyGame.seconds.ToString().PadLeft(2, '0');
                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.score);
                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.antiScore);
                    lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4MembersOfTheFamilyGame.questionNumber) + " of " + Convert.ToString(ch4MembersOfTheFamilyGame.questionsInGame);
                    lblCh4TranslationGameAnswer.Text = string.Empty;
                    lblCh4TranslationGameYourAnswer.Text = string.Empty;
                    ch4MembersOfTheFamilyGame.index = 0;
                    lblCh4TranslationGameQuestion.Text = ch4MembersOfTheFamilyGame.Get_Question(ch4MembersOfTheFamilyGame.randomOrder[ch4MembersOfTheFamilyGame.index]);
                    txtCh4TranslationGameAnswer.Text = string.Empty;
                    txtCh4TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblFamilylg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;
        }

        private void lblVerbs3_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = false;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = true;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblVerbs3lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblVerbs3lg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblVerbs3lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblVerbs3lg.ForeColor = Color.FromArgb(0, 164, 164);

                ch4VerbsGame.questionsInGame = 290;

                if (ch4VerbsGame.questionsInGame > 0)
                {
                    ch4VerbsGameEnabled = true;
                    lblCh4TranslationGameTitle.Text = "Cap 4: Verbos";
                    pnlChapter4.Visible = false;
                    pnlCh4TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch4VerbsGame.Randomize_Questions();
                    ch4VerbsGame.minutes = 60;
                    ch4VerbsGame.seconds = 0;
                    ch4VerbsGame.questionNumber = 1;
                    ch4VerbsGame.score = 0;
                    ch4VerbsGame.antiScore = 0;
                    ch4VerbsGame.index = 0;
                    ch4VerbsGame.text = string.Empty;
                    ch4VerbsGame.yourAnswer = string.Empty;
                    tmrCh4TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh4TranslationGameTime.Text = ch4VerbsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch4VerbsGame.seconds.ToString().PadLeft(2, '0');
                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4VerbsGame.score);
                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4VerbsGame.antiScore);
                    lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4VerbsGame.questionNumber) + " of " + Convert.ToString(ch4VerbsGame.questionsInGame);
                    lblCh4TranslationGameAnswer.Text = string.Empty;
                    lblCh4TranslationGameYourAnswer.Text = string.Empty;
                    ch4VerbsGame.index = 0;
                    lblCh4TranslationGameQuestion.Text = ch4VerbsGame.Get_Question(ch4VerbsGame.randomOrder[ch4VerbsGame.index]);
                    txtCh4TranslationGameAnswer.Text = string.Empty;
                    txtCh4TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblVerbs3lg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;
        }

        private void lblAdjetives_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = false;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = true;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblAdjetiveslg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblAdjetiveslg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblAdjetiveslg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblAdjetiveslg.ForeColor = Color.FromArgb(0, 164, 164);

                ch4AdjetivesGame.questionsInGame = 15;

                if (ch4AdjetivesGame.questionsInGame > 0)
                {
                    ch4AdjetivesGameEnabled = true;
                    lblCh4TranslationGameTitle.Text = "Cap 4: Adjetivos";
                    pnlChapter4.Visible = false;
                    pnlCh4TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch4AdjetivesGame.Randomize_Questions();
                    ch4AdjetivesGame.minutes = 5;
                    ch4AdjetivesGame.seconds = 0;
                    ch4AdjetivesGame.questionNumber = 1;
                    ch4AdjetivesGame.score = 0;
                    ch4AdjetivesGame.antiScore = 0;
                    ch4AdjetivesGame.index = 0;
                    ch4AdjetivesGame.text = string.Empty;
                    ch4AdjetivesGame.yourAnswer = string.Empty;
                    tmrCh4TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh4TranslationGameTime.Text = ch4AdjetivesGame.minutes.ToString().PadLeft(2, '0') + ":" + ch4AdjetivesGame.seconds.ToString().PadLeft(2, '0');
                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4AdjetivesGame.score);
                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4AdjetivesGame.antiScore);
                    lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4AdjetivesGame.questionNumber) + " of " + Convert.ToString(ch4AdjetivesGame.questionsInGame);
                    lblCh4TranslationGameAnswer.Text = string.Empty;
                    lblCh4TranslationGameYourAnswer.Text = string.Empty;
                    ch4AdjetivesGame.index = 0;
                    lblCh4TranslationGameQuestion.Text = ch4AdjetivesGame.Get_Question(ch4AdjetivesGame.randomOrder[ch4AdjetivesGame.index]);
                    txtCh4TranslationGameAnswer.Text = string.Empty;
                    txtCh4TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblAdjetiveslg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;
        }

        private void lblPlacesToGo_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = false;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = true;
            lblFinallg.Visible = false;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblPlacesToGolg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPlacesToGolg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblPlacesToGolg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblPlacesToGolg.ForeColor = Color.FromArgb(0, 164, 164);

                ch4PlacesToGoGame.questionsInGame = 11;

                if (ch4PlacesToGoGame.questionsInGame > 0)
                {
                    ch4PlacesToGoGameEnabled = true;
                    lblCh4TranslationGameTitle.Text = "Cap 4: Lugares Para Ir";
                    pnlChapter4.Visible = false;
                    pnlCh4TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch4PlacesToGoGame.Randomize_Questions();
                    ch4PlacesToGoGame.minutes = 5;
                    ch4PlacesToGoGame.seconds = 0;
                    ch4PlacesToGoGame.questionNumber = 1;
                    ch4PlacesToGoGame.score = 0;
                    ch4PlacesToGoGame.antiScore = 0;
                    ch4PlacesToGoGame.index = 0;
                    ch4PlacesToGoGame.text = string.Empty;
                    ch4PlacesToGoGame.yourAnswer = string.Empty;
                    tmrCh4TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh4TranslationGameTime.Text = ch4PlacesToGoGame.minutes.ToString().PadLeft(2, '0') + ":" + ch4PlacesToGoGame.seconds.ToString().PadLeft(2, '0');
                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4PlacesToGoGame.score);
                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4PlacesToGoGame.antiScore);
                    lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4PlacesToGoGame.questionNumber) + " of " + Convert.ToString(ch4PlacesToGoGame.questionsInGame);
                    lblCh4TranslationGameAnswer.Text = string.Empty;
                    lblCh4TranslationGameYourAnswer.Text = string.Empty;
                    ch4PlacesToGoGame.index = 0;
                    lblCh4TranslationGameQuestion.Text = ch4PlacesToGoGame.Get_Question(ch4PlacesToGoGame.randomOrder[ch4PlacesToGoGame.index]);
                    txtCh4TranslationGameAnswer.Text = string.Empty;
                    txtCh4TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblPlacesToGolg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;
        }

        private void lblFinal_MouseMove(object sender, MouseEventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = false;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = true;

            if (soundEnabled == true)
            {
                beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                beep2_voice.Start();
            }
        }

        private void lblFinallg_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblFinallg.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblFinallg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblFinallg.ForeColor = Color.FromArgb(0, 164, 164);

                ch4FinalGame.questionsInGame = 1367;

                if (ch4FinalGame.questionsInGame > 0)
                {
                    ch4FinalGameEnabled = true;
                    lblCh4TranslationGameTitle.Text = "Cap 4: Final";
                    pnlChapter4.Visible = false;
                    pnlCh4TranslationGame.Visible = true;
                    lblBack.Visible = true;
                    ch4FinalGame.Randomize_Questions();
                    ch4FinalGame.minutes = 180;
                    ch4FinalGame.seconds = 0;
                    ch4FinalGame.questionNumber = 1;
                    ch4FinalGame.score = 0;
                    ch4FinalGame.antiScore = 0;
                    ch4FinalGame.index = 0;
                    ch4FinalGame.text = string.Empty;
                    ch4FinalGame.yourAnswer = string.Empty;
                    tmrCh4TranslationGame.Enabled = true;
                    enterKeyPressed = false;
                    lblCh4TranslationGameTime.Text = ch4FinalGame.minutes.ToString().PadLeft(3, '0') + ":" + ch4FinalGame.seconds.ToString().PadLeft(2, '0');
                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4FinalGame.score);
                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4FinalGame.antiScore);
                    lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4FinalGame.questionNumber) + " of " + Convert.ToString(ch4FinalGame.questionsInGame);
                    lblCh4TranslationGameAnswer.Text = string.Empty;
                    lblCh4TranslationGameYourAnswer.Text = string.Empty;
                    ch4FinalGame.index = 0;
                    lblCh4TranslationGameQuestion.Text = ch4FinalGame.Get_Question(ch4FinalGame.randomOrder[ch4FinalGame.index]);
                    txtCh4TranslationGameAnswer.Text = string.Empty;
                    txtCh4TranslationGameAnswer.Focus();
                }

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblFinallg_MouseLeave(object sender, EventArgs e)
        {
            lblTranslation4.Visible = true;
            lblPhotos4.Visible = true;
            lblFamily.Visible = true;
            lblVerbs3.Visible = true;
            lblAdjetives.Visible = true;
            lblPlacesToGo.Visible = true;
            lblFinal.Visible = true;
            lblTranslation4lg.Visible = false;
            lblPhotos4lg.Visible = false;
            lblFamilylg.Visible = false;
            lblVerbs3lg.Visible = false;
            lblAdjetiveslg.Visible = false;
            lblPlacesToGolg.Visible = false;
            lblFinallg.Visible = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Back and Forward Buttons
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lblForward_MouseMove(object sender, MouseEventArgs e)
        {
            lblForward.ForeColor = Color.FromArgb(0, 164, 164);
            if (insideForwardButton == false)
            {
                insideForwardButton = true;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblForward_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblForward.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblForward_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblForward.ForeColor = Color.FromArgb(0, 164, 164);

                if (soundEnabled == true)
                {
                    nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                    nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                    nanoblade_voice.Start();
                }
            }
        }

        private void lblForward_MouseLeave(object sender, EventArgs e)
        {
            lblForward.ForeColor = Color.FromArgb(255, 255, 255);
            insideForwardButton = false;
        }

        private void lblBack_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblBack.ForeColor = Color.FromArgb(0, 164, 164);
                if (insideBackButton == false)
                {
                    insideBackButton = true;

                    if (soundEnabled == true)
                    {
                        beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                        beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                        beep2_voice.Start();
                    }
                }
            }
        }

        private void lblBack_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblBack.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblBack_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblBack.ForeColor = Color.FromArgb(0, 164, 164);

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Chapters Mode
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (pnlChapters.Visible == false && pnlChapter1.Visible == true)
                    {
                        pnlChapter1.Visible = false;
                        pnlChapters.Visible = true;
                        lblBack.Visible = false;
                        chapter1Enabled = false;
                    }
                    else if (pnlChapters.Visible == false && pnlChapter2.Visible == true)
                    {
                        pnlChapter2.Visible = false;
                        pnlChapters.Visible = true;
                        lblBack.Visible = false;
                        chapter2Enabled = false;
                    }
                    else if (pnlChapters.Visible == false && pnlChapter3.Visible == true)
                    {
                        pnlChapter3.Visible = false;
                        pnlChapters.Visible = true;
                        lblBack.Visible = false;
                        chapter3Enabled = false;
                    }
                    else if (pnlChapters.Visible == false && pnlChapter4.Visible == true)
                    {
                        pnlChapter4.Visible = false;
                        pnlChapters.Visible = true;
                        lblBack.Visible = false;
                        chapter4Enabled = false;
                    }

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Chapter 1
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (pnlChapter1.Visible == false && pnlCh1TranslationGame.Visible == true)
                    {
                        if (ch1TranslationGameEnabled == true)
                        {
                            ch1TranslationGameEnabled = false;
                        }
                        else if (ch1PhotoGameEnabled == true)
                        {
                            ch1PhotoGameEnabled = false;
                        }
                        else if (ch1LetterGameEnabled == true)
                        {
                            ch1LetterGameEnabled = false;
                        }
                        else if (ch1NumberGameEnabled == true)
                        {
                            ch1NumberGameEnabled = false;
                        }
                        else if (ch1ColorGameEnabled == true)
                        {
                            ch1ColorGameEnabled = false;
                        }
                        else if (ch1DaysOfTheWeekGameEnabled == true)
                        {
                            ch1DaysOfTheWeekGameEnabled = false;
                        }
                        else if (ch1MonthsOfTheYearGameEnabled == true)
                        {
                            ch1MonthsOfTheYearGameEnabled = false;
                        }
                        else if (ch1SeasonsOfTheYearGameEnabled == true)
                        {
                            ch1SeasonsOfTheYearGameEnabled = false;
                        }

                        WriteToBinaryFile("score.dat");

                        tmrCh1TranslationGame.Enabled = false;
                        pnlCh1TranslationGame.Visible = false;
                        pnlChapter1.Visible = true;
                    }

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Chapter 2
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (pnlChapter2.Visible == false && pnlCh2TranslationGame.Visible == true)
                    {
                        if (ch2TranslationGameEnabled == true)
                        {
                            ch2TranslationGameEnabled = false;
                        }
                        else if (ch2PhotoGameEnabled == true)
                        {
                            ch2PhotoGameEnabled = false;
                        }
                        else if (ch2NationalitiesGameEnabled == true)
                        {
                            ch2NationalitiesGameEnabled = false;
                        }
                        else if (ch2WhatTimeIsItGameEnabled == true)
                        {
                            ch2WhatTimeIsItGameEnabled = false;
                        }
                        else if (ch2VerbsGameEnabled == true)
                        {
                            ch2VerbsGameEnabled = false;
                        }
                        else if (ch2InterrogativeWordsGameEnabled == true)
                        {
                            ch2InterrogativeWordsGameEnabled = false;
                        }
                        else if (ch2CountriesGameEnabled == true)
                        {
                            ch2CountriesGameEnabled = false;
                        }
                        else if (ch2ILikeYouLikeGameEnabled == true)
                        {
                            ch2ILikeYouLikeGameEnabled = false;
                        }

                        WriteToBinaryFile("score.dat");

                        tmrCh2TranslationGame.Enabled = false;
                        pnlCh2TranslationGame.Visible = false;
                        pnlChapter2.Visible = true;
                    }

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Chapter 3
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (pnlChapter3.Visible == false && pnlCh3TranslationGame.Visible == true)
                    {
                        if (ch3TranslationGameEnabled == true)
                        {
                            ch3TranslationGameEnabled = false;
                        }
                        else if (ch3PhotoGameEnabled == true)
                        {
                            ch3PhotoGameEnabled = false;
                        }
                        else if (ch3ScheduleGameEnabled == true)
                        {
                            ch3ScheduleGameEnabled = false;
                        }
                        else if (ch3BigNumbersGameEnabled == true)
                        {
                            ch3BigNumbersGameEnabled = false;
                        }
                        else if (ch3BuildingsGameEnabled == true)
                        {
                            ch3BuildingsGameEnabled = false;
                        }
                        else if (ch3PronounsGameEnabled == true)
                        {
                            ch3PronounsGameEnabled = false;
                        }
                        else if (ch3WhereIsItGameEnabled == true)
                        {
                            ch3WhereIsItGameEnabled = false;
                        }
                        else if (ch3VerbsGameEnabled == true)
                        {
                            ch3VerbsGameEnabled = false;
                        }

                        WriteToBinaryFile("score.dat");

                        tmrCh3TranslationGame.Enabled = false;
                        pnlCh3TranslationGame.Visible = false;
                        pnlChapter3.Visible = true;
                    }

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    // Chapter 4
                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    if (pnlChapter4.Visible == false && pnlCh4TranslationGame.Visible == true)
                    {

                        if (ch4TranslationGameEnabled == true)
                        {
                            ch4TranslationGameEnabled = false;
                        }
                        else if (ch4PhotoGameEnabled == true)
                        {
                            ch4PhotoGameEnabled = false;
                        }
                        else if (ch4MembersOfTheFamilyGameEnabled == true)
                        {
                            ch4MembersOfTheFamilyGameEnabled = false;
                        }
                        else if (ch4VerbsGameEnabled == true)
                        {
                            ch4VerbsGameEnabled = false;
                        }
                        else if (ch4AdjetivesGameEnabled == true)
                        {
                            ch4AdjetivesGameEnabled = false;
                        }
                        else if (ch4PlacesToGoGameEnabled == true)
                        {
                            ch4PlacesToGoGameEnabled = false;
                        }
                        else if (ch4FinalGameEnabled == true)
                        {
                            ch4FinalGameEnabled = false;
                        }

                        WriteToBinaryFile("score.dat");

                        tmrCh4TranslationGame.Enabled = false;
                        pnlCh4TranslationGame.Visible = false;
                        pnlChapter4.Visible = true;
                    }
                }
            }

            if (soundEnabled == true)
            {
                nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                nanoblade_voice.Start();
            }
        }

        private void lblBack_MouseLeave(object sender, EventArgs e)
        {
            lblBack.ForeColor = Color.FromArgb(255, 255, 255);
            insideBackButton = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 1 - Translation Game - Accent Marks
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lblCh1TranslationGameAccentA_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh1TranslationGameAccentA.Visible = false;
                lblCh1TranslationGameAccentE.Visible = true;
                lblCh1TranslationGameAccentI.Visible = true;
                lblCh1TranslationGameAccentO.Visible = true;
                lblCh1TranslationGameAccentU.Visible = true;
                lblCh1TranslationGameAccentU2.Visible = true;
                lblCh1TranslationGameAccentN.Visible = true;
                lblCh1TranslationGameUDQuestion.Visible = true;
                lblCh1TranslationGameUDExclamation.Visible = true;
                lblCh1TranslationGameAccentAlg.Visible = true;
                lblCh1TranslationGameAccentElg.Visible = false;
                lblCh1TranslationGameAccentIlg.Visible = false;
                lblCh1TranslationGameAccentOlg.Visible = false;
                lblCh1TranslationGameAccentUlg.Visible = false;
                lblCh1TranslationGameAccentUlg2.Visible = false;
                lblCh1TranslationGameAccentNlg.Visible = false;
                lblCh1TranslationGameUDQuestionlg.Visible = false;
                lblCh1TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh1TranslationGameAccentAlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentAlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh1TranslationGameAccentAlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentAlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch1TranslationGame.text = txtCh1TranslationGameAnswer.Text.Insert(txtCh1TranslationGameAnswer.SelectionStart, "á");
                    int cursorPosition = txtCh1TranslationGameAnswer.SelectionStart;
                    txtCh1TranslationGameAnswer.Text = ch1TranslationGame.text;
                    txtCh1TranslationGameAnswer.Focus();
                    txtCh1TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh1TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh1TranslationGameAccentAlg_MouseLeave(object sender, EventArgs e)
        {
            lblCh1TranslationGameAccentA.Visible = true;
            lblCh1TranslationGameAccentE.Visible = true;
            lblCh1TranslationGameAccentI.Visible = true;
            lblCh1TranslationGameAccentO.Visible = true;
            lblCh1TranslationGameAccentU.Visible = true;
            lblCh1TranslationGameAccentU2.Visible = true;
            lblCh1TranslationGameAccentN.Visible = true;
            lblCh1TranslationGameUDQuestion.Visible = true;
            lblCh1TranslationGameUDExclamation.Visible = true;
            lblCh1TranslationGameAccentAlg.Visible = false;
            lblCh1TranslationGameAccentElg.Visible = false;
            lblCh1TranslationGameAccentIlg.Visible = false;
            lblCh1TranslationGameAccentOlg.Visible = false;
            lblCh1TranslationGameAccentUlg.Visible = false;
            lblCh1TranslationGameAccentUlg2.Visible = false;
            lblCh1TranslationGameAccentNlg.Visible = false;
            lblCh1TranslationGameUDQuestionlg.Visible = false;
            lblCh1TranslationGameUDExclamationlg.Visible = false;
        }

        private void lblCh1TranslationGameAccentE_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh1TranslationGameAccentA.Visible = true;
                lblCh1TranslationGameAccentE.Visible = false;
                lblCh1TranslationGameAccentI.Visible = true;
                lblCh1TranslationGameAccentO.Visible = true;
                lblCh1TranslationGameAccentU.Visible = true;
                lblCh1TranslationGameAccentU2.Visible = true;
                lblCh1TranslationGameAccentN.Visible = true;
                lblCh1TranslationGameUDQuestion.Visible = true;
                lblCh1TranslationGameUDExclamation.Visible = true;
                lblCh1TranslationGameAccentAlg.Visible = false;
                lblCh1TranslationGameAccentElg.Visible = true;
                lblCh1TranslationGameAccentIlg.Visible = false;
                lblCh1TranslationGameAccentOlg.Visible = false;
                lblCh1TranslationGameAccentUlg.Visible = false;
                lblCh1TranslationGameAccentUlg2.Visible = false;
                lblCh1TranslationGameAccentNlg.Visible = false;
                lblCh1TranslationGameUDQuestionlg.Visible = false;
                lblCh1TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh1TranslationGameAccentElg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentElg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh1TranslationGameAccentElg_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (pnlGrade.Visible == false)
                {
                    lblCh1TranslationGameAccentElg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch1TranslationGame.text = txtCh1TranslationGameAnswer.Text.Insert(txtCh1TranslationGameAnswer.SelectionStart, "é");
                    int cursorPosition = txtCh1TranslationGameAnswer.SelectionStart;
                    txtCh1TranslationGameAnswer.Text = ch1TranslationGame.text;
                    txtCh1TranslationGameAnswer.Focus();
                    txtCh1TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh1TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh1TranslationGameAccentElg_MouseLeave(object sender, EventArgs e)
        {
            lblCh1TranslationGameAccentA.Visible = true;
            lblCh1TranslationGameAccentE.Visible = true;
            lblCh1TranslationGameAccentI.Visible = true;
            lblCh1TranslationGameAccentO.Visible = true;
            lblCh1TranslationGameAccentU.Visible = true;
            lblCh1TranslationGameAccentU2.Visible = true;
            lblCh1TranslationGameAccentN.Visible = true;
            lblCh1TranslationGameUDQuestion.Visible = true;
            lblCh1TranslationGameUDExclamation.Visible = true;
            lblCh1TranslationGameAccentAlg.Visible = false;
            lblCh1TranslationGameAccentElg.Visible = false;
            lblCh1TranslationGameAccentIlg.Visible = false;
            lblCh1TranslationGameAccentOlg.Visible = false;
            lblCh1TranslationGameAccentUlg.Visible = false;
            lblCh1TranslationGameAccentUlg2.Visible = false;
            lblCh1TranslationGameAccentNlg.Visible = false;
            lblCh1TranslationGameUDQuestionlg.Visible = false;
            lblCh1TranslationGameUDExclamationlg.Visible = false;
        }

        private void lblCh1TranslationGameAccentI_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh1TranslationGameAccentA.Visible = true;
                lblCh1TranslationGameAccentE.Visible = true;
                lblCh1TranslationGameAccentI.Visible = false;
                lblCh1TranslationGameAccentO.Visible = true;
                lblCh1TranslationGameAccentU.Visible = true;
                lblCh1TranslationGameAccentU2.Visible = true;
                lblCh1TranslationGameAccentN.Visible = true;
                lblCh1TranslationGameUDQuestion.Visible = true;
                lblCh1TranslationGameUDExclamation.Visible = true;
                lblCh1TranslationGameAccentAlg.Visible = false;
                lblCh1TranslationGameAccentElg.Visible = false;
                lblCh1TranslationGameAccentIlg.Visible = true;
                lblCh1TranslationGameAccentOlg.Visible = false;
                lblCh1TranslationGameAccentUlg.Visible = false;
                lblCh1TranslationGameAccentUlg2.Visible = false;
                lblCh1TranslationGameAccentNlg.Visible = false;
                lblCh1TranslationGameUDQuestionlg.Visible = false;
                lblCh1TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh1TranslationGameAccentIlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentIlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh1TranslationGameAccentIlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentIlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch1TranslationGame.text = txtCh1TranslationGameAnswer.Text.Insert(txtCh1TranslationGameAnswer.SelectionStart, "í");
                    int cursorPosition = txtCh1TranslationGameAnswer.SelectionStart;
                    txtCh1TranslationGameAnswer.Text = ch1TranslationGame.text;
                    txtCh1TranslationGameAnswer.Focus();
                    txtCh1TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh1TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh1TranslationGameAccentIlg_MouseLeave(object sender, EventArgs e)
        {
            lblCh1TranslationGameAccentA.Visible = true;
            lblCh1TranslationGameAccentE.Visible = true;
            lblCh1TranslationGameAccentI.Visible = true;
            lblCh1TranslationGameAccentO.Visible = true;
            lblCh1TranslationGameAccentU.Visible = true;
            lblCh1TranslationGameAccentU2.Visible = true;
            lblCh1TranslationGameAccentN.Visible = true;
            lblCh1TranslationGameUDQuestion.Visible = true;
            lblCh1TranslationGameUDExclamation.Visible = true;
            lblCh1TranslationGameAccentAlg.Visible = false;
            lblCh1TranslationGameAccentElg.Visible = false;
            lblCh1TranslationGameAccentIlg.Visible = false;
            lblCh1TranslationGameAccentOlg.Visible = false;
            lblCh1TranslationGameAccentUlg.Visible = false;
            lblCh1TranslationGameAccentUlg2.Visible = false;
            lblCh1TranslationGameAccentNlg.Visible = false;
            lblCh1TranslationGameUDQuestionlg.Visible = false;
            lblCh1TranslationGameUDExclamationlg.Visible = false;
        }

        private void lblCh1TranslationGameAccentO_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh1TranslationGameAccentA.Visible = true;
                lblCh1TranslationGameAccentE.Visible = true;
                lblCh1TranslationGameAccentI.Visible = true;
                lblCh1TranslationGameAccentO.Visible = false;
                lblCh1TranslationGameAccentU.Visible = true;
                lblCh1TranslationGameAccentU2.Visible = true;
                lblCh1TranslationGameAccentN.Visible = true;
                lblCh1TranslationGameUDQuestion.Visible = true;
                lblCh1TranslationGameUDExclamation.Visible = true;
                lblCh1TranslationGameAccentAlg.Visible = false;
                lblCh1TranslationGameAccentElg.Visible = false;
                lblCh1TranslationGameAccentIlg.Visible = false;
                lblCh1TranslationGameAccentOlg.Visible = true;
                lblCh1TranslationGameAccentUlg.Visible = false;
                lblCh1TranslationGameAccentUlg2.Visible = false;
                lblCh1TranslationGameAccentNlg.Visible = false;
                lblCh1TranslationGameUDQuestionlg.Visible = false;
                lblCh1TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh1TranslationGameAccentOlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentOlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh1TranslationGameAccentOlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentOlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch1TranslationGame.text = txtCh1TranslationGameAnswer.Text.Insert(txtCh1TranslationGameAnswer.SelectionStart, "ó");
                    int cursorPosition = txtCh1TranslationGameAnswer.SelectionStart;
                    txtCh1TranslationGameAnswer.Text = ch1TranslationGame.text;
                    txtCh1TranslationGameAnswer.Focus();
                    txtCh1TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh1TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh1TranslationGameAccentOlg_MouseLeave(object sender, EventArgs e)
        {
            lblCh1TranslationGameAccentA.Visible = true;
            lblCh1TranslationGameAccentE.Visible = true;
            lblCh1TranslationGameAccentI.Visible = true;
            lblCh1TranslationGameAccentO.Visible = true;
            lblCh1TranslationGameAccentU.Visible = true;
            lblCh1TranslationGameAccentU2.Visible = true;
            lblCh1TranslationGameAccentN.Visible = true;
            lblCh1TranslationGameUDQuestion.Visible = true;
            lblCh1TranslationGameUDExclamation.Visible = true;
            lblCh1TranslationGameAccentAlg.Visible = false;
            lblCh1TranslationGameAccentElg.Visible = false;
            lblCh1TranslationGameAccentIlg.Visible = false;
            lblCh1TranslationGameAccentOlg.Visible = false;
            lblCh1TranslationGameAccentUlg.Visible = false;
            lblCh1TranslationGameAccentUlg2.Visible = false;
            lblCh1TranslationGameAccentNlg.Visible = false;
            lblCh1TranslationGameUDQuestionlg.Visible = false;
            lblCh1TranslationGameUDExclamationlg.Visible = false;
        }

        private void lblCh1TranslationGameAccentU_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh1TranslationGameAccentA.Visible = true;
                lblCh1TranslationGameAccentE.Visible = true;
                lblCh1TranslationGameAccentI.Visible = true;
                lblCh1TranslationGameAccentO.Visible = true;
                lblCh1TranslationGameAccentU.Visible = false;
                lblCh1TranslationGameAccentU2.Visible = true;
                lblCh1TranslationGameAccentN.Visible = true;
                lblCh1TranslationGameUDQuestion.Visible = true;
                lblCh1TranslationGameUDExclamation.Visible = true;
                lblCh1TranslationGameAccentAlg.Visible = false;
                lblCh1TranslationGameAccentElg.Visible = false;
                lblCh1TranslationGameAccentIlg.Visible = false;
                lblCh1TranslationGameAccentOlg.Visible = false;
                lblCh1TranslationGameAccentUlg.Visible = true;
                lblCh1TranslationGameAccentUlg2.Visible = false;
                lblCh1TranslationGameAccentNlg.Visible = false;
                lblCh1TranslationGameUDQuestionlg.Visible = false;
                lblCh1TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh1TranslationGameAccentUlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentUlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh1TranslationGameAccentUlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentUlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch1TranslationGame.text = txtCh1TranslationGameAnswer.Text.Insert(txtCh1TranslationGameAnswer.SelectionStart, "ú");
                    int cursorPosition = txtCh1TranslationGameAnswer.SelectionStart;
                    txtCh1TranslationGameAnswer.Text = ch1TranslationGame.text;
                    txtCh1TranslationGameAnswer.Focus();
                    txtCh1TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh1TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh1TranslationGameAccentUlg_MouseLeave(object sender, EventArgs e)
        {
            lblCh1TranslationGameAccentA.Visible = true;
            lblCh1TranslationGameAccentE.Visible = true;
            lblCh1TranslationGameAccentI.Visible = true;
            lblCh1TranslationGameAccentO.Visible = true;
            lblCh1TranslationGameAccentU.Visible = true;
            lblCh1TranslationGameAccentU2.Visible = true;
            lblCh1TranslationGameAccentN.Visible = true;
            lblCh1TranslationGameUDQuestion.Visible = true;
            lblCh1TranslationGameUDExclamation.Visible = true;
            lblCh1TranslationGameAccentAlg.Visible = false;
            lblCh1TranslationGameAccentElg.Visible = false;
            lblCh1TranslationGameAccentIlg.Visible = false;
            lblCh1TranslationGameAccentOlg.Visible = false;
            lblCh1TranslationGameAccentUlg.Visible = false;
            lblCh1TranslationGameAccentUlg2.Visible = false;
            lblCh1TranslationGameAccentNlg.Visible = false;
            lblCh1TranslationGameUDQuestionlg.Visible = false;
            lblCh1TranslationGameUDExclamationlg.Visible = false;
        }

        private void lblCh1TranslationGameAccentU2_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh1TranslationGameAccentA.Visible = true;
                lblCh1TranslationGameAccentE.Visible = true;
                lblCh1TranslationGameAccentI.Visible = true;
                lblCh1TranslationGameAccentO.Visible = true;
                lblCh1TranslationGameAccentU.Visible = true;
                lblCh1TranslationGameAccentU2.Visible = false;
                lblCh1TranslationGameAccentN.Visible = true;
                lblCh1TranslationGameUDQuestion.Visible = true;
                lblCh1TranslationGameUDExclamation.Visible = true;
                lblCh1TranslationGameAccentAlg.Visible = false;
                lblCh1TranslationGameAccentElg.Visible = false;
                lblCh1TranslationGameAccentIlg.Visible = false;
                lblCh1TranslationGameAccentOlg.Visible = false;
                lblCh1TranslationGameAccentUlg.Visible = false;
                lblCh1TranslationGameAccentUlg2.Visible = true;
                lblCh1TranslationGameAccentNlg.Visible = false;
                lblCh1TranslationGameUDQuestionlg.Visible = false;
                lblCh1TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh1TranslationGameAccentUlg2_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentUlg2.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh1TranslationGameAccentUlg2_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentUlg2.ForeColor = Color.FromArgb(0, 164, 164);
                    ch1TranslationGame.text = txtCh1TranslationGameAnswer.Text.Insert(txtCh1TranslationGameAnswer.SelectionStart, "ü");
                    int cursorPosition = txtCh1TranslationGameAnswer.SelectionStart;
                    txtCh1TranslationGameAnswer.Text = ch1TranslationGame.text;
                    txtCh1TranslationGameAnswer.Focus();
                    txtCh1TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh1TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh1TranslationGameAccentUlg2_MouseLeave(object sender, EventArgs e)
        {
            lblCh1TranslationGameAccentA.Visible = true;
            lblCh1TranslationGameAccentE.Visible = true;
            lblCh1TranslationGameAccentI.Visible = true;
            lblCh1TranslationGameAccentO.Visible = true;
            lblCh1TranslationGameAccentU.Visible = true;
            lblCh1TranslationGameAccentU2.Visible = true;
            lblCh1TranslationGameAccentN.Visible = true;
            lblCh1TranslationGameUDQuestion.Visible = true;
            lblCh1TranslationGameUDExclamation.Visible = true;
            lblCh1TranslationGameAccentAlg.Visible = false;
            lblCh1TranslationGameAccentElg.Visible = false;
            lblCh1TranslationGameAccentIlg.Visible = false;
            lblCh1TranslationGameAccentOlg.Visible = false;
            lblCh1TranslationGameAccentUlg.Visible = false;
            lblCh1TranslationGameAccentUlg2.Visible = false;
            lblCh1TranslationGameAccentNlg.Visible = false;
            lblCh1TranslationGameUDQuestionlg.Visible = false;
            lblCh1TranslationGameUDExclamationlg.Visible = false;
        }

        private void lblCh1TranslationGameAccentN_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh1TranslationGameAccentA.Visible = true;
                lblCh1TranslationGameAccentE.Visible = true;
                lblCh1TranslationGameAccentI.Visible = true;
                lblCh1TranslationGameAccentO.Visible = true;
                lblCh1TranslationGameAccentU.Visible = true;
                lblCh1TranslationGameAccentU2.Visible = true;
                lblCh1TranslationGameAccentN.Visible = false;
                lblCh1TranslationGameUDQuestion.Visible = true;
                lblCh1TranslationGameUDExclamation.Visible = true;
                lblCh1TranslationGameAccentAlg.Visible = false;
                lblCh1TranslationGameAccentElg.Visible = false;
                lblCh1TranslationGameAccentIlg.Visible = false;
                lblCh1TranslationGameAccentOlg.Visible = false;
                lblCh1TranslationGameAccentUlg.Visible = false;
                lblCh1TranslationGameAccentUlg2.Visible = false;
                lblCh1TranslationGameAccentNlg.Visible = true;
                lblCh1TranslationGameUDQuestionlg.Visible = false;
                lblCh1TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh1TranslationGameAccentNlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentNlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh1TranslationGameAccentNlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameAccentNlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch1TranslationGame.text = txtCh1TranslationGameAnswer.Text.Insert(txtCh1TranslationGameAnswer.SelectionStart, "ñ");
                    int cursorPosition = txtCh1TranslationGameAnswer.SelectionStart;
                    txtCh1TranslationGameAnswer.Text = ch1TranslationGame.text;
                    txtCh1TranslationGameAnswer.Focus();
                    txtCh1TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh1TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh1TranslationGameAccentNlg_MouseLeave(object sender, EventArgs e)
        {
            lblCh1TranslationGameAccentA.Visible = true;
            lblCh1TranslationGameAccentE.Visible = true;
            lblCh1TranslationGameAccentI.Visible = true;
            lblCh1TranslationGameAccentO.Visible = true;
            lblCh1TranslationGameAccentU.Visible = true;
            lblCh1TranslationGameAccentU2.Visible = true;
            lblCh1TranslationGameAccentN.Visible = true;
            lblCh1TranslationGameUDQuestion.Visible = true;
            lblCh1TranslationGameUDExclamation.Visible = true;
            lblCh1TranslationGameAccentAlg.Visible = false;
            lblCh1TranslationGameAccentElg.Visible = false;
            lblCh1TranslationGameAccentIlg.Visible = false;
            lblCh1TranslationGameAccentOlg.Visible = false;
            lblCh1TranslationGameAccentUlg.Visible = false;
            lblCh1TranslationGameAccentUlg2.Visible = false;
            lblCh1TranslationGameAccentNlg.Visible = false;
            lblCh1TranslationGameUDQuestionlg.Visible = false;
            lblCh1TranslationGameUDExclamationlg.Visible = false;
        }

        private void lblCh1TranslationGameUDQuestion_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh1TranslationGameAccentA.Visible = true;
                lblCh1TranslationGameAccentE.Visible = true;
                lblCh1TranslationGameAccentI.Visible = true;
                lblCh1TranslationGameAccentO.Visible = true;
                lblCh1TranslationGameAccentU.Visible = true;
                lblCh1TranslationGameAccentU2.Visible = true;
                lblCh1TranslationGameAccentN.Visible = true;
                lblCh1TranslationGameUDQuestion.Visible = false;
                lblCh1TranslationGameUDExclamation.Visible = true;
                lblCh1TranslationGameAccentAlg.Visible = false;
                lblCh1TranslationGameAccentElg.Visible = false;
                lblCh1TranslationGameAccentIlg.Visible = false;
                lblCh1TranslationGameAccentOlg.Visible = false;
                lblCh1TranslationGameAccentUlg.Visible = false;
                lblCh1TranslationGameAccentUlg2.Visible = false;
                lblCh1TranslationGameAccentNlg.Visible = false;
                lblCh1TranslationGameUDQuestionlg.Visible = true;
                lblCh1TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh1TranslationGameUDQuestionlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameUDQuestionlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh1TranslationGameUDQuestionlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameUDQuestionlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch1TranslationGame.text = txtCh1TranslationGameAnswer.Text.Insert(txtCh1TranslationGameAnswer.SelectionStart, "¿");
                    int cursorPosition = txtCh1TranslationGameAnswer.SelectionStart;
                    txtCh1TranslationGameAnswer.Text = ch1TranslationGame.text;
                    txtCh1TranslationGameAnswer.Focus();
                    txtCh1TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh1TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh1TranslationGameUDQuestionlg_MouseLeave(object sender, EventArgs e)
        {
            lblCh1TranslationGameAccentA.Visible = true;
            lblCh1TranslationGameAccentE.Visible = true;
            lblCh1TranslationGameAccentI.Visible = true;
            lblCh1TranslationGameAccentO.Visible = true;
            lblCh1TranslationGameAccentU.Visible = true;
            lblCh1TranslationGameAccentU2.Visible = true;
            lblCh1TranslationGameAccentN.Visible = true;
            lblCh1TranslationGameUDQuestion.Visible = true;
            lblCh1TranslationGameUDExclamation.Visible = true;
            lblCh1TranslationGameAccentAlg.Visible = false;
            lblCh1TranslationGameAccentElg.Visible = false;
            lblCh1TranslationGameAccentIlg.Visible = false;
            lblCh1TranslationGameAccentOlg.Visible = false;
            lblCh1TranslationGameAccentUlg.Visible = false;
            lblCh1TranslationGameAccentUlg2.Visible = false;
            lblCh1TranslationGameAccentNlg.Visible = false;
            lblCh1TranslationGameUDQuestionlg.Visible = false;
            lblCh1TranslationGameUDExclamationlg.Visible = false;
        }

        private void lblCh1TranslationGameUDExclamation_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh1TranslationGameAccentA.Visible = true;
                lblCh1TranslationGameAccentE.Visible = true;
                lblCh1TranslationGameAccentI.Visible = true;
                lblCh1TranslationGameAccentO.Visible = true;
                lblCh1TranslationGameAccentU.Visible = true;
                lblCh1TranslationGameAccentU2.Visible = true;
                lblCh1TranslationGameAccentN.Visible = true;
                lblCh1TranslationGameUDQuestion.Visible = true;
                lblCh1TranslationGameUDExclamation.Visible = false;
                lblCh1TranslationGameAccentAlg.Visible = false;
                lblCh1TranslationGameAccentElg.Visible = false;
                lblCh1TranslationGameAccentIlg.Visible = false;
                lblCh1TranslationGameAccentOlg.Visible = false;
                lblCh1TranslationGameAccentUlg.Visible = false;
                lblCh1TranslationGameAccentUlg2.Visible = false;
                lblCh1TranslationGameAccentNlg.Visible = false;
                lblCh1TranslationGameUDQuestionlg.Visible = false;
                lblCh1TranslationGameUDExclamationlg.Visible = true;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh1TranslationGameUDExclamationlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameUDExclamationlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh1TranslationGameUDExclamationlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh1TranslationGameUDExclamationlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch1TranslationGame.text = txtCh1TranslationGameAnswer.Text.Insert(txtCh1TranslationGameAnswer.SelectionStart, "¡");
                    int cursorPosition = txtCh1TranslationGameAnswer.SelectionStart;
                    txtCh1TranslationGameAnswer.Text = ch1TranslationGame.text;
                    txtCh1TranslationGameAnswer.Focus();
                    txtCh1TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh1TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh1TranslationGameUDExclamationlg_MouseLeave(object sender, EventArgs e)
        {
            lblCh1TranslationGameAccentA.Visible = true;
            lblCh1TranslationGameAccentE.Visible = true;
            lblCh1TranslationGameAccentI.Visible = true;
            lblCh1TranslationGameAccentO.Visible = true;
            lblCh1TranslationGameAccentU.Visible = true;
            lblCh1TranslationGameAccentU2.Visible = true;
            lblCh1TranslationGameAccentN.Visible = true;
            lblCh1TranslationGameUDQuestion.Visible = true;
            lblCh1TranslationGameUDExclamation.Visible = true;
            lblCh1TranslationGameAccentAlg.Visible = false;
            lblCh1TranslationGameAccentElg.Visible = false;
            lblCh1TranslationGameAccentIlg.Visible = false;
            lblCh1TranslationGameAccentOlg.Visible = false;
            lblCh1TranslationGameAccentUlg.Visible = false;
            lblCh1TranslationGameAccentUlg2.Visible = false;
            lblCh1TranslationGameAccentNlg.Visible = false;
            lblCh1TranslationGameUDQuestionlg.Visible = false;
            lblCh1TranslationGameUDExclamationlg.Visible = false;
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 2 - Translation Game - Accent Marks
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        private void lblCh2TranslationGameAccentA_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = false;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = true;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh2TranslationGameAccentAlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentAlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh2TranslationGameAccentAlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentAlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch2TranslationGame.text = txtCh2TranslationGameAnswer.Text.Insert(txtCh2TranslationGameAnswer.SelectionStart, "á");
                    int cursorPosition = txtCh2TranslationGameAnswer.SelectionStart;
                    txtCh2TranslationGameAnswer.Text = ch2TranslationGame.text;
                    txtCh2TranslationGameAnswer.Focus();
                    txtCh2TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh2TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh2TranslationGameAccentAlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh2TranslationGameAccentE_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = false;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = true;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh2TranslationGameAccentElg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentElg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh2TranslationGameAccentElg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentElg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch2TranslationGame.text = txtCh2TranslationGameAnswer.Text.Insert(txtCh2TranslationGameAnswer.SelectionStart, "é");
                    int cursorPosition = txtCh2TranslationGameAnswer.SelectionStart;
                    txtCh2TranslationGameAnswer.Text = ch2TranslationGame.text;
                    txtCh2TranslationGameAnswer.Focus();
                    txtCh2TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh2TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh2TranslationGameAccentElg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh2TranslationGameAccentI_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = false;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = true;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh2TranslationGameAccentIlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentIlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh2TranslationGameAccentIlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentIlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch2TranslationGame.text = txtCh2TranslationGameAnswer.Text.Insert(txtCh2TranslationGameAnswer.SelectionStart, "í");
                    int cursorPosition = txtCh2TranslationGameAnswer.SelectionStart;
                    txtCh2TranslationGameAnswer.Text = ch2TranslationGame.text;
                    txtCh2TranslationGameAnswer.Focus();
                    txtCh2TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh2TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh2TranslationGameAccentIlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh2TranslationGameAccentO_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = false;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = true;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh2TranslationGameAccentOlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentOlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh2TranslationGameAccentOlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentOlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch2TranslationGame.text = txtCh2TranslationGameAnswer.Text.Insert(txtCh2TranslationGameAnswer.SelectionStart, "ó");
                    int cursorPosition = txtCh2TranslationGameAnswer.SelectionStart;
                    txtCh2TranslationGameAnswer.Text = ch2TranslationGame.text;
                    txtCh2TranslationGameAnswer.Focus();
                    txtCh2TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh2TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh2TranslationGameAccentOlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh2TranslationGameAccentU_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = false;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = true;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh2TranslationGameAccentUlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentUlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh2TranslationGameAccentUlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentUlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch2TranslationGame.text = txtCh2TranslationGameAnswer.Text.Insert(txtCh2TranslationGameAnswer.SelectionStart, "ú");
                    int cursorPosition = txtCh2TranslationGameAnswer.SelectionStart;
                    txtCh2TranslationGameAnswer.Text = ch2TranslationGame.text;
                    txtCh2TranslationGameAnswer.Focus();
                    txtCh2TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh2TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh2TranslationGameAccentUlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh2TranslationGameAccentU2_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = false;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = true;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh2TranslationGameAccentU2lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentU2lg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh2TranslationGameAccentU2lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentU2lg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch2TranslationGame.text = txtCh2TranslationGameAnswer.Text.Insert(txtCh2TranslationGameAnswer.SelectionStart, "ü");
                    int cursorPosition = txtCh2TranslationGameAnswer.SelectionStart;
                    txtCh2TranslationGameAnswer.Text = ch2TranslationGame.text;
                    txtCh2TranslationGameAnswer.Focus();
                    txtCh2TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh2TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh2TranslationGameAccentU2lg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh2TranslationGameAccentN_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = false;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = true;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh2TranslationGameAccentNlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentNlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh2TranslationGameAccentNlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameAccentNlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch2TranslationGame.text = txtCh2TranslationGameAnswer.Text.Insert(txtCh2TranslationGameAnswer.SelectionStart, "ñ");
                    int cursorPosition = txtCh2TranslationGameAnswer.SelectionStart;
                    txtCh2TranslationGameAnswer.Text = ch2TranslationGame.text;
                    txtCh2TranslationGameAnswer.Focus();
                    txtCh2TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh2TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh2TranslationGameAccentNlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh2TranslationGameUDQuestion_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = false;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = true;
                lblCh2TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh2TranslationGameUDQuestionlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameUDQuestionlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh2TranslationGameUDQuestionlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameUDQuestionlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch2TranslationGame.text = txtCh2TranslationGameAnswer.Text.Insert(txtCh2TranslationGameAnswer.SelectionStart, "¿");
                    int cursorPosition = txtCh2TranslationGameAnswer.SelectionStart;
                    txtCh2TranslationGameAnswer.Text = ch2TranslationGame.text;
                    txtCh2TranslationGameAnswer.Focus();
                    txtCh2TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh2TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh2TranslationGameUDQuestionlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh2TranslationGameUDExclamation_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = false;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = true;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh2TranslationGameUDExclamationlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameUDExclamationlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh2TranslationGameUDExclamationlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh2TranslationGameUDExclamationlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch2TranslationGame.text = txtCh2TranslationGameAnswer.Text.Insert(txtCh2TranslationGameAnswer.SelectionStart, "¡");
                    int cursorPosition = txtCh2TranslationGameAnswer.SelectionStart;
                    txtCh2TranslationGameAnswer.Text = ch2TranslationGame.text;
                    txtCh2TranslationGameAnswer.Focus();
                    txtCh2TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh2TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh2TranslationGameUDExclamationlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh2TranslationGameAccentA.Visible = true;
                lblCh2TranslationGameAccentE.Visible = true;
                lblCh2TranslationGameAccentI.Visible = true;
                lblCh2TranslationGameAccentO.Visible = true;
                lblCh2TranslationGameAccentU.Visible = true;
                lblCh2TranslationGameAccentU2.Visible = true;
                lblCh2TranslationGameAccentN.Visible = true;
                lblCh2TranslationGameUDQuestion.Visible = true;
                lblCh2TranslationGameUDExclamation.Visible = true;
                lblCh2TranslationGameAccentAlg.Visible = false;
                lblCh2TranslationGameAccentElg.Visible = false;
                lblCh2TranslationGameAccentIlg.Visible = false;
                lblCh2TranslationGameAccentOlg.Visible = false;
                lblCh2TranslationGameAccentUlg.Visible = false;
                lblCh2TranslationGameAccentU2lg.Visible = false;
                lblCh2TranslationGameAccentNlg.Visible = false;
                lblCh2TranslationGameUDQuestionlg.Visible = false;
                lblCh2TranslationGameUDExclamationlg.Visible = false;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 3 - Translation Game - Accent Marks
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lblCh3TranslationGameAccentA_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = false;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = true;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh3TranslationGameAccentAlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentAlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh3TranslationGameAccentAlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentAlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch3TranslationGame.text = txtCh3TranslationGameAnswer.Text.Insert(txtCh3TranslationGameAnswer.SelectionStart, "á");
                    int cursorPosition = txtCh3TranslationGameAnswer.SelectionStart;
                    txtCh3TranslationGameAnswer.Text = ch3TranslationGame.text;
                    txtCh3TranslationGameAnswer.Focus();
                    txtCh3TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh3TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh3TranslationGameAccentAlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh3TranslationGameAccentE_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = false;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = true;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh3TranslationGameAccentElg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentElg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh3TranslationGameAccentElg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentElg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch3TranslationGame.text = txtCh3TranslationGameAnswer.Text.Insert(txtCh3TranslationGameAnswer.SelectionStart, "é");
                    int cursorPosition = txtCh3TranslationGameAnswer.SelectionStart;
                    txtCh3TranslationGameAnswer.Text = ch3TranslationGame.text;
                    txtCh3TranslationGameAnswer.Focus();
                    txtCh3TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh3TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh3TranslationGameAccentElg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh3TranslationGameAccentI_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = false;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = true;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh3TranslationGameAccentIlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentIlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh3TranslationGameAccentIlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentIlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch3TranslationGame.text = txtCh3TranslationGameAnswer.Text.Insert(txtCh3TranslationGameAnswer.SelectionStart, "í");
                    int cursorPosition = txtCh3TranslationGameAnswer.SelectionStart;
                    txtCh3TranslationGameAnswer.Text = ch3TranslationGame.text;
                    txtCh3TranslationGameAnswer.Focus();
                    txtCh3TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh3TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh3TranslationGameAccentIlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh3TranslationGameAccentO_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = false;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = true;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh3TranslationGameAccentOlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentOlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh3TranslationGameAccentOlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentOlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch3TranslationGame.text = txtCh3TranslationGameAnswer.Text.Insert(txtCh3TranslationGameAnswer.SelectionStart, "ó");
                    int cursorPosition = txtCh3TranslationGameAnswer.SelectionStart;
                    txtCh3TranslationGameAnswer.Text = ch3TranslationGame.text;
                    txtCh3TranslationGameAnswer.Focus();
                    txtCh3TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh3TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh3TranslationGameAccentOlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh3TranslationGameAccentU_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = false;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = true;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh3TranslationGameAccentUlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentUlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh3TranslationGameAccentUlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentUlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch3TranslationGame.text = txtCh3TranslationGameAnswer.Text.Insert(txtCh3TranslationGameAnswer.SelectionStart, "ú");
                    int cursorPosition = txtCh3TranslationGameAnswer.SelectionStart;
                    txtCh3TranslationGameAnswer.Text = ch3TranslationGame.text;
                    txtCh3TranslationGameAnswer.Focus();
                    txtCh3TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh3TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh3TranslationGameAccentUlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh3TranslationGameAccentU2_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = false;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = true;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh3TranslationGameAccentU2lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentU2lg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh3TranslationGameAccentU2lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentU2lg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch3TranslationGame.text = txtCh3TranslationGameAnswer.Text.Insert(txtCh3TranslationGameAnswer.SelectionStart, "ü");
                    int cursorPosition = txtCh3TranslationGameAnswer.SelectionStart;
                    txtCh3TranslationGameAnswer.Text = ch3TranslationGame.text;
                    txtCh3TranslationGameAnswer.Focus();
                    txtCh3TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh3TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh3TranslationGameAccentU2lg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh3TranslationGameAccentN_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = false;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = true;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh3TranslationGameAccentNlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentNlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh3TranslationGameAccentNlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameAccentNlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch3TranslationGame.text = txtCh3TranslationGameAnswer.Text.Insert(txtCh3TranslationGameAnswer.SelectionStart, "ñ");
                    int cursorPosition = txtCh3TranslationGameAnswer.SelectionStart;
                    txtCh3TranslationGameAnswer.Text = ch3TranslationGame.text;
                    txtCh3TranslationGameAnswer.Focus();
                    txtCh3TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh3TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh3TranslationGameAccentNlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh3TranslationGameUDQuestion_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = false;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = true;
                lblCh3TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh3TranslationGameUDQuestionlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameUDQuestionlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh3TranslationGameUDQuestionlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameUDQuestionlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch3TranslationGame.text = txtCh3TranslationGameAnswer.Text.Insert(txtCh3TranslationGameAnswer.SelectionStart, "¿");
                    int cursorPosition = txtCh3TranslationGameAnswer.SelectionStart;
                    txtCh3TranslationGameAnswer.Text = ch3TranslationGame.text;
                    txtCh3TranslationGameAnswer.Focus();
                    txtCh3TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh3TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh3TranslationGameUDQuestionlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh3TranslationGameUDExclamation_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = false;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = true;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh3TranslationGameUDExclamationlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameUDExclamationlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh3TranslationGameUDExclamationlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh3TranslationGameUDExclamationlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch3TranslationGame.text = txtCh3TranslationGameAnswer.Text.Insert(txtCh3TranslationGameAnswer.SelectionStart, "¡");
                    int cursorPosition = txtCh3TranslationGameAnswer.SelectionStart;
                    txtCh3TranslationGameAnswer.Text = ch3TranslationGame.text;
                    txtCh3TranslationGameAnswer.Focus();
                    txtCh3TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh3TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh3TranslationGameUDExclamationlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh3TranslationGameAccentA.Visible = true;
                lblCh3TranslationGameAccentE.Visible = true;
                lblCh3TranslationGameAccentI.Visible = true;
                lblCh3TranslationGameAccentO.Visible = true;
                lblCh3TranslationGameAccentU.Visible = true;
                lblCh3TranslationGameAccentU2.Visible = true;
                lblCh3TranslationGameAccentN.Visible = true;
                lblCh3TranslationGameUDQuestion.Visible = true;
                lblCh3TranslationGameUDExclamation.Visible = true;
                lblCh3TranslationGameAccentAlg.Visible = false;
                lblCh3TranslationGameAccentElg.Visible = false;
                lblCh3TranslationGameAccentIlg.Visible = false;
                lblCh3TranslationGameAccentOlg.Visible = false;
                lblCh3TranslationGameAccentUlg.Visible = false;
                lblCh3TranslationGameAccentU2lg.Visible = false;
                lblCh3TranslationGameAccentNlg.Visible = false;
                lblCh3TranslationGameUDQuestionlg.Visible = false;
                lblCh3TranslationGameUDExclamationlg.Visible = false;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 4 - Translation Game - Accent Marks
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void lblCh4TranslationGameAccentA_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = false;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = true;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh4TranslationGameAccentAlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentAlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh4TranslationGameAccentAlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentAlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch4TranslationGame.text = txtCh4TranslationGameAnswer.Text.Insert(txtCh4TranslationGameAnswer.SelectionStart, "á");
                    int cursorPosition = txtCh4TranslationGameAnswer.SelectionStart;
                    txtCh4TranslationGameAnswer.Text = ch4TranslationGame.text;
                    txtCh4TranslationGameAnswer.Focus();
                    txtCh4TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh4TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh4TranslationGameAccentAlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh4TranslationGameAccentE_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = false;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = true;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh4TranslationGameAccentElg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentElg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh4TranslationGameAccentElg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentElg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch4TranslationGame.text = txtCh4TranslationGameAnswer.Text.Insert(txtCh4TranslationGameAnswer.SelectionStart, "é");
                    int cursorPosition = txtCh4TranslationGameAnswer.SelectionStart;
                    txtCh4TranslationGameAnswer.Text = ch4TranslationGame.text;
                    txtCh4TranslationGameAnswer.Focus();
                    txtCh4TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh4TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh4TranslationGameAccentElg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh4TranslationGameAccentI_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = false;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = true;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh4TranslationGameAccentIlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentIlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh4TranslationGameAccentIlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentIlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch4TranslationGame.text = txtCh4TranslationGameAnswer.Text.Insert(txtCh4TranslationGameAnswer.SelectionStart, "í");
                    int cursorPosition = txtCh4TranslationGameAnswer.SelectionStart;
                    txtCh4TranslationGameAnswer.Text = ch4TranslationGame.text;
                    txtCh4TranslationGameAnswer.Focus();
                    txtCh4TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh4TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh4TranslationGameAccentIlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh4TranslationGameAccentO_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = false;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = true;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh4TranslationGameAccentOlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentOlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh4TranslationGameAccentOlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentOlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch4TranslationGame.text = txtCh4TranslationGameAnswer.Text.Insert(txtCh4TranslationGameAnswer.SelectionStart, "ó");
                    int cursorPosition = txtCh4TranslationGameAnswer.SelectionStart;
                    txtCh4TranslationGameAnswer.Text = ch4TranslationGame.text;
                    txtCh4TranslationGameAnswer.Focus();
                    txtCh4TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh4TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh4TranslationGameAccentOlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh4TranslationGameAccentU_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = false;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = true;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh4TranslationGameAccentUlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentUlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh4TranslationGameAccentUlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentUlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch4TranslationGame.text = txtCh4TranslationGameAnswer.Text.Insert(txtCh4TranslationGameAnswer.SelectionStart, "ú");
                    int cursorPosition = txtCh4TranslationGameAnswer.SelectionStart;
                    txtCh4TranslationGameAnswer.Text = ch4TranslationGame.text;
                    txtCh4TranslationGameAnswer.Focus();
                    txtCh4TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh4TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh4TranslationGameAccentUlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh4TranslationGameAccentU2_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = false;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = true;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh4TranslationGameAccentU2lg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentU2lg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh4TranslationGameAccentU2lg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentU2lg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch4TranslationGame.text = txtCh4TranslationGameAnswer.Text.Insert(txtCh4TranslationGameAnswer.SelectionStart, "ü");
                    int cursorPosition = txtCh4TranslationGameAnswer.SelectionStart;
                    txtCh4TranslationGameAnswer.Text = ch4TranslationGame.text;
                    txtCh4TranslationGameAnswer.Focus();
                    txtCh4TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh4TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh4TranslationGameAccentU2lg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh4TranslationGameAccentN_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = false;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = true;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh4TranslationGameAccentNlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentNlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh4TranslationGameAccentNlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameAccentNlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch4TranslationGame.text = txtCh4TranslationGameAnswer.Text.Insert(txtCh4TranslationGameAnswer.SelectionStart, "ñ");
                    int cursorPosition = txtCh4TranslationGameAnswer.SelectionStart;
                    txtCh4TranslationGameAnswer.Text = ch4TranslationGame.text;
                    txtCh4TranslationGameAnswer.Focus();
                    txtCh4TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh4TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh4TranslationGameAccentNlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh4TranslationGameUDQuestion_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = false;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = true;
                lblCh4TranslationGameUDExclamationlg.Visible = false;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh4TranslationGameUDQuestionlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameUDQuestionlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh4TranslationGameUDQuestionlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameUDQuestionlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch4TranslationGame.text = txtCh4TranslationGameAnswer.Text.Insert(txtCh4TranslationGameAnswer.SelectionStart, "¿");
                    int cursorPosition = txtCh4TranslationGameAnswer.SelectionStart;
                    txtCh4TranslationGameAnswer.Text = ch4TranslationGame.text;
                    txtCh4TranslationGameAnswer.Focus();
                    txtCh4TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh4TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh4TranslationGameUDQuestionlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;
            }
        }

        private void lblCh4TranslationGameUDExclamation_MouseMove(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = false;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = true;

                if (soundEnabled == true)
                {
                    beep2_voice = new SourceVoice(xaudio, beep2_waveFormat, true);
                    beep2_voice.SubmitSourceBuffer(beep2_buffer, beep2_soundstream.DecodedPacketsInfo);
                    beep2_voice.Start();
                }
            }
        }

        private void lblCh4TranslationGameUDExclamationlg_MouseDown(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameUDExclamationlg.ForeColor = Color.FromArgb(0, 69, 87);
                }
            }
        }

        private void lblCh4TranslationGameUDExclamationlg_MouseUp(object sender, MouseEventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                if (e.Button == MouseButtons.Left)
                {
                    lblCh4TranslationGameUDExclamationlg.ForeColor = Color.FromArgb(0, 164, 164);
                    ch4TranslationGame.text = txtCh4TranslationGameAnswer.Text.Insert(txtCh4TranslationGameAnswer.SelectionStart, "¡");
                    int cursorPosition = txtCh4TranslationGameAnswer.SelectionStart;
                    txtCh4TranslationGameAnswer.Text = ch4TranslationGame.text;
                    txtCh4TranslationGameAnswer.Focus();
                    txtCh4TranslationGameAnswer.SelectionStart = cursorPosition + 1;
                    txtCh4TranslationGameAnswer.SelectionLength = 0;

                    if (soundEnabled == true)
                    {
                        nanoblade_voice = new SourceVoice(xaudio, nanoblade_waveFormat, true);
                        nanoblade_voice.SubmitSourceBuffer(nanoblade_buffer, nanoblade_soundstream.DecodedPacketsInfo);
                        nanoblade_voice.Start();
                    }
                }
            }
        }

        private void lblCh4TranslationGameUDExclamationlg_MouseLeave(object sender, EventArgs e)
        {
            if (pnlGrade.Visible == false)
            {
                lblCh4TranslationGameAccentA.Visible = true;
                lblCh4TranslationGameAccentE.Visible = true;
                lblCh4TranslationGameAccentI.Visible = true;
                lblCh4TranslationGameAccentO.Visible = true;
                lblCh4TranslationGameAccentU.Visible = true;
                lblCh4TranslationGameAccentU2.Visible = true;
                lblCh4TranslationGameAccentN.Visible = true;
                lblCh4TranslationGameUDQuestion.Visible = true;
                lblCh4TranslationGameUDExclamation.Visible = true;
                lblCh4TranslationGameAccentAlg.Visible = false;
                lblCh4TranslationGameAccentElg.Visible = false;
                lblCh4TranslationGameAccentIlg.Visible = false;
                lblCh4TranslationGameAccentOlg.Visible = false;
                lblCh4TranslationGameAccentUlg.Visible = false;
                lblCh4TranslationGameAccentU2lg.Visible = false;
                lblCh4TranslationGameAccentNlg.Visible = false;
                lblCh4TranslationGameUDQuestionlg.Visible = false;
                lblCh4TranslationGameUDExclamationlg.Visible = false;
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 1 - Translation Game
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txtCh1TranslationGameAnswer_TextChanged(object sender, EventArgs e)
        {
            if (ch1TranslationGameEnabled == true)
            {
                ch1TranslationGame.text = txtCh1TranslationGameAnswer.Text;
            }
            else if (ch1PhotoGameEnabled == true)
            {
                ch1PhotoGame.text = txtCh1TranslationGameAnswer.Text;
            }
            else if (ch1LetterGameEnabled == true)
            {
                ch1LetterGame.text = txtCh1TranslationGameAnswer.Text;
            }
            else if (ch1NumberGameEnabled == true)
            {
                ch1NumberGame.text = txtCh1TranslationGameAnswer.Text;
            }
            else if (ch1ColorGameEnabled == true)
            {
                ch1ColorGame.text = txtCh1TranslationGameAnswer.Text;
            }
            else if (ch1DaysOfTheWeekGameEnabled == true)
            {
                ch1DaysOfTheWeekGame.text = txtCh1TranslationGameAnswer.Text;
            }
            else if (ch1MonthsOfTheYearGameEnabled == true)
            {
                ch1MonthsOfTheYearGame.text = txtCh1TranslationGameAnswer.Text;
            }
            else if (ch1SeasonsOfTheYearGameEnabled == true)
            {
                ch1SeasonsOfTheYearGame.text = txtCh1TranslationGameAnswer.Text;
            }
        }

        private void txtCh1TranslationGameAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if(pnlGrade.Visible == false && pnlChapter1.Visible == false && pnlCh1TranslationGame.Visible == true)
            {
                e.Handled = false;
                if (e.KeyCode == Keys.Enter && enterKeyPressed == false)
                {
                    enterKeyPressed = true;

                    if (ch1TranslationGameEnabled == true)
                    {
                        if(ch1TranslationGame.index <= ch1TranslationGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch1TranslationGame.text.ToLower() == ch1TranslationGame.Get_Answer(ch1TranslationGame.randomOrder[ch1TranslationGame.index]).ToLower())
                                {
                                    ch1TranslationGame.score++;
                                    ch1TranslationGame.mastered[ch1TranslationGame.randomOrder[ch1TranslationGame.index]] = true;
                                    ch1TranslationGame.text = string.Empty;
                                    ch1TranslationGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                    lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1TranslationGame.score);
                                    lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1TranslationGame.antiScore);
                                    lblCh1TranslationGameAnswer.Text = ch1TranslationGame.Get_Answer(ch1TranslationGame.randomOrder[ch1TranslationGame.index]);
                                    lblCh1TranslationGameYourAnswer.Text = ch1TranslationGame.yourAnswer;

                                    ch1TranslationGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch1TranslationGame.index == ch1TranslationGame.questionsInGame)
                                    {
                                        ch1TranslationGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh1TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch1TranslationGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch1TranslationGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch1TranslationGame.score, ch1TranslationGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch1TranslationGame.index < ch1TranslationGame.questionsInGame)
                                    {
                                        ch1TranslationGame.questionNumber++;
                                        lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1TranslationGame.questionNumber) + " of " + Convert.ToString(ch1TranslationGame.questionsInGame);
                                        lblCh1TranslationGameQuestion.Text = ch1TranslationGame.Get_Question(ch1TranslationGame.randomOrder[ch1TranslationGame.index]);
                                        txtCh1TranslationGameAnswer.Text = string.Empty;
                                        txtCh1TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch1TranslationGame.antiScore++;
                                    ch1TranslationGame.text = string.Empty;
                                    ch1TranslationGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                    lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1TranslationGame.score);
                                    lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1TranslationGame.antiScore);
                                    lblCh1TranslationGameAnswer.Text = ch1TranslationGame.Get_Answer(ch1TranslationGame.randomOrder[ch1TranslationGame.index]);
                                    lblCh1TranslationGameYourAnswer.Text = ch1TranslationGame.yourAnswer;

                                    ch1TranslationGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch1TranslationGame.index == ch1TranslationGame.questionsInGame)
                                    {
                                        ch1TranslationGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh1TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch1TranslationGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch1TranslationGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch1TranslationGame.score, ch1TranslationGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch1TranslationGame.index < ch1TranslationGame.questionsInGame)
                                    {
                                        ch1TranslationGame.questionNumber++;
                                        lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1TranslationGame.questionNumber) + " of " + Convert.ToString(ch1TranslationGame.questionsInGame);
                                        lblCh1TranslationGameQuestion.Text = ch1TranslationGame.Get_Question(ch1TranslationGame.randomOrder[ch1TranslationGame.index]);
                                        txtCh1TranslationGameAnswer.Text = string.Empty;
                                        txtCh1TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {
                                MessageBox.Show(Convert.ToString(ch1TranslationGame.questionNumber));
                                MessageBox.Show(Convert.ToString(ch1TranslationGame.index));
                            }
                        }
                    }
                    else if (ch1PhotoGameEnabled == true)
                    {
                        if (ch1PhotoGame.index <= ch1PhotoGame.questionsInGame - 1)
                        {
                            if (ch1PhotoGame.text.ToLower() == ch1PhotoGame.Get_Answer(ch1PhotoGame.randomOrder[ch1PhotoGame.index]).ToLower())
                            {
                                ch1PhotoGame.score++;
                                ch1PhotoGame.mastered[ch1PhotoGame.randomOrder[ch1PhotoGame.index]] = true;
                                ch1PhotoGame.text = string.Empty;
                                ch1PhotoGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1PhotoGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1PhotoGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1PhotoGame.Get_Answer(ch1PhotoGame.randomOrder[ch1PhotoGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1PhotoGame.yourAnswer;

                                ch1PhotoGame.index++;

                                if (soundEnabled == true)
                                {
                                    applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                    applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                    applause_voice.Start();
                                }

                                if (ch1PhotoGame.index == ch1PhotoGame.questionsInGame)
                                {
                                    ch1PhotoGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1PhotoGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1PhotoGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1PhotoGame.score, ch1PhotoGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1PhotoGame.index < ch1PhotoGame.questionsInGame)
                                {
                                    ch1PhotoGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1PhotoGame.questionNumber) + " of " + Convert.ToString(ch1PhotoGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1PhotoGame.Get_Question(ch1PhotoGame.randomOrder[ch1PhotoGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }

                            }
                            else
                            {
                                ch1PhotoGame.antiScore++;
                                ch1PhotoGame.text = string.Empty;
                                ch1PhotoGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1PhotoGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1PhotoGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1PhotoGame.Get_Answer(ch1PhotoGame.randomOrder[ch1PhotoGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1PhotoGame.yourAnswer;

                                ch1PhotoGame.index++;

                                if (soundEnabled == true)
                                {
                                    wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                    wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                    wrong_voice.Start();
                                }

                                if (ch1PhotoGame.index == ch1PhotoGame.questionsInGame)
                                {
                                    ch1PhotoGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1PhotoGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1PhotoGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1PhotoGame.score, ch1PhotoGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1PhotoGame.index < ch1PhotoGame.questionsInGame)
                                {
                                    ch1PhotoGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1PhotoGame.questionNumber) + " of " + Convert.ToString(ch1PhotoGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1PhotoGame.Get_Question(ch1PhotoGame.randomOrder[ch1PhotoGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }
                            }
                        }
                    }
                    else if (ch1LetterGameEnabled == true)
                    {
                        if (ch1LetterGame.index <= ch1LetterGame.questionsInGame - 1)
                        {
                            if (ch1LetterGame.text.ToLower() == ch1LetterGame.Get_Answer(ch1LetterGame.randomOrder[ch1LetterGame.index]).ToLower())
                            {
                                ch1LetterGame.score++;
                                ch1LetterGame.mastered[ch1LetterGame.randomOrder[ch1LetterGame.index]] = true;
                                ch1LetterGame.text = string.Empty;
                                ch1LetterGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1LetterGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1LetterGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1LetterGame.Get_Answer(ch1LetterGame.randomOrder[ch1LetterGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1LetterGame.yourAnswer;

                                ch1LetterGame.index++;

                                if (soundEnabled == true)
                                {
                                    applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                    applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                    applause_voice.Start();
                                }

                                if (ch1LetterGame.index == ch1LetterGame.questionsInGame)
                                {
                                    ch1LetterGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1LetterGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1LetterGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1LetterGame.score, ch1LetterGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1LetterGame.index < ch1LetterGame.questionsInGame)
                                {
                                    ch1LetterGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1LetterGame.questionNumber) + " of " + Convert.ToString(ch1LetterGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1LetterGame.Get_Question(ch1LetterGame.randomOrder[ch1LetterGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }

                            }
                            else
                            {
                                ch1LetterGame.antiScore++;
                                ch1LetterGame.text = string.Empty;
                                ch1LetterGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1LetterGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1LetterGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1LetterGame.Get_Answer(ch1LetterGame.randomOrder[ch1LetterGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1LetterGame.yourAnswer;

                                ch1LetterGame.index++;

                                if (soundEnabled == true)
                                {
                                    wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                    wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                    wrong_voice.Start();
                                }

                                if (ch1LetterGame.index == ch1LetterGame.questionsInGame)
                                {
                                    ch1LetterGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1LetterGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1LetterGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1LetterGame.score, ch1LetterGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1LetterGame.index < ch1LetterGame.questionsInGame)
                                {
                                    ch1LetterGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1LetterGame.questionNumber) + " of " + Convert.ToString(ch1LetterGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1LetterGame.Get_Question(ch1LetterGame.randomOrder[ch1LetterGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }
                            }
                        }
                    }
                    else if (ch1NumberGameEnabled == true)
                    {
                        if (ch1NumberGame.index <= ch1NumberGame.questionsInGame - 1)
                        {
                            if (ch1NumberGame.text.ToLower() == ch1NumberGame.Get_Answer(ch1NumberGame.randomOrder[ch1NumberGame.index]).ToLower())
                            {
                                ch1NumberGame.score++;
                                ch1NumberGame.mastered[ch1NumberGame.randomOrder[ch1NumberGame.index]] = true;
                                ch1NumberGame.text = string.Empty;
                                ch1NumberGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1NumberGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1NumberGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1NumberGame.Get_Answer(ch1NumberGame.randomOrder[ch1NumberGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1NumberGame.yourAnswer;

                                ch1NumberGame.index++;

                                if (soundEnabled == true)
                                {
                                    applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                    applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                    applause_voice.Start();
                                }

                                if (ch1NumberGame.index == ch1NumberGame.questionsInGame)
                                {
                                    ch1NumberGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1NumberGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1NumberGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1NumberGame.score, ch1NumberGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1NumberGame.index < ch1NumberGame.questionsInGame)
                                {
                                    ch1NumberGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1NumberGame.questionNumber) + " of " + Convert.ToString(ch1NumberGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1NumberGame.Get_Question(ch1NumberGame.randomOrder[ch1NumberGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }

                            }
                            else
                            {
                                ch1NumberGame.antiScore++;
                                ch1NumberGame.text = string.Empty;
                                ch1NumberGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1NumberGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1NumberGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1NumberGame.Get_Answer(ch1NumberGame.randomOrder[ch1NumberGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1NumberGame.yourAnswer;

                                ch1NumberGame.index++;

                                if (soundEnabled == true)
                                {
                                    wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                    wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                    wrong_voice.Start();
                                }

                                if (ch1NumberGame.index == ch1NumberGame.questionsInGame)
                                {
                                    ch1NumberGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1NumberGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1NumberGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1NumberGame.score, ch1NumberGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1NumberGame.index < ch1NumberGame.questionsInGame)
                                {
                                    ch1NumberGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1NumberGame.questionNumber) + " of " + Convert.ToString(ch1NumberGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1NumberGame.Get_Question(ch1NumberGame.randomOrder[ch1NumberGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }
                            }
                        }
                    }
                    else if (ch1ColorGameEnabled == true)
                    {
                        if (ch1ColorGame.index <= ch1ColorGame.questionsInGame - 1)
                        {
                            if (ch1ColorGame.text.ToLower() == ch1ColorGame.Get_Answer(ch1ColorGame.randomOrder[ch1ColorGame.index]).ToLower())
                            {
                                ch1ColorGame.score++;
                                ch1ColorGame.mastered[ch1ColorGame.randomOrder[ch1ColorGame.index]] = true;
                                ch1ColorGame.text = string.Empty;
                                ch1ColorGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1ColorGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1ColorGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1ColorGame.Get_Answer(ch1ColorGame.randomOrder[ch1ColorGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1ColorGame.yourAnswer;

                                ch1ColorGame.index++;

                                if (soundEnabled == true)
                                {
                                    applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                    applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                    applause_voice.Start();
                                }

                                if (ch1ColorGame.index == ch1ColorGame.questionsInGame)
                                {
                                    ch1ColorGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1ColorGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1ColorGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1ColorGame.score, ch1ColorGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1ColorGame.index < ch1ColorGame.questionsInGame)
                                {
                                    ch1ColorGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1ColorGame.questionNumber) + " of " + Convert.ToString(ch1ColorGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1ColorGame.Get_Question(ch1ColorGame.randomOrder[ch1ColorGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }

                            }
                            else
                            {
                                ch1ColorGame.antiScore++;
                                ch1ColorGame.text = string.Empty;
                                ch1ColorGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1ColorGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1ColorGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1ColorGame.Get_Answer(ch1ColorGame.randomOrder[ch1ColorGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1ColorGame.yourAnswer;

                                ch1ColorGame.index++;

                                if (soundEnabled == true)
                                {
                                    wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                    wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                    wrong_voice.Start();
                                }

                                if (ch1ColorGame.index == ch1ColorGame.questionsInGame)
                                {
                                    ch1ColorGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1ColorGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1ColorGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1ColorGame.score, ch1ColorGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1ColorGame.index < ch1ColorGame.questionsInGame)
                                {
                                    ch1ColorGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1ColorGame.questionNumber) + " of " + Convert.ToString(ch1ColorGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1ColorGame.Get_Question(ch1ColorGame.randomOrder[ch1ColorGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }
                            }
                        }
                    }
                    else if (ch1DaysOfTheWeekGameEnabled == true)
                    {
                        if (ch1DaysOfTheWeekGame.index <= ch1DaysOfTheWeekGame.questionsInGame - 1) 
                        {
                            if (ch1DaysOfTheWeekGame.text.ToLower() == ch1DaysOfTheWeekGame.Get_Answer(ch1DaysOfTheWeekGame.randomOrder[ch1DaysOfTheWeekGame.index]).ToLower())
                            {
                                ch1DaysOfTheWeekGame.score++;
                                ch1DaysOfTheWeekGame.mastered[ch1DaysOfTheWeekGame.randomOrder[ch1DaysOfTheWeekGame.index]] = true;
                                ch1DaysOfTheWeekGame.text = string.Empty;
                                ch1DaysOfTheWeekGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1DaysOfTheWeekGame.Get_Answer(ch1DaysOfTheWeekGame.randomOrder[ch1DaysOfTheWeekGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1DaysOfTheWeekGame.yourAnswer;

                                ch1DaysOfTheWeekGame.index++;

                                if (soundEnabled == true)
                                {
                                    applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                    applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                    applause_voice.Start();
                                }

                                if (ch1DaysOfTheWeekGame.index == ch1DaysOfTheWeekGame.questionsInGame)
                                {
                                    ch1DaysOfTheWeekGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1DaysOfTheWeekGame.score, ch1DaysOfTheWeekGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1DaysOfTheWeekGame.index < ch1DaysOfTheWeekGame.questionsInGame)
                                {
                                    ch1DaysOfTheWeekGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1DaysOfTheWeekGame.questionNumber) + " of " + Convert.ToString(ch1DaysOfTheWeekGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1DaysOfTheWeekGame.Get_Question(ch1DaysOfTheWeekGame.randomOrder[ch1DaysOfTheWeekGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }

                            }
                            else
                            {
                                ch1DaysOfTheWeekGame.antiScore++;
                                ch1DaysOfTheWeekGame.text = string.Empty;
                                ch1DaysOfTheWeekGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1DaysOfTheWeekGame.Get_Answer(ch1DaysOfTheWeekGame.randomOrder[ch1DaysOfTheWeekGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1DaysOfTheWeekGame.yourAnswer;

                                ch1DaysOfTheWeekGame.index++;

                                if (soundEnabled == true)
                                {
                                    wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                    wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                    wrong_voice.Start();
                                }

                                if (ch1DaysOfTheWeekGame.index == ch1DaysOfTheWeekGame.questionsInGame)
                                {
                                    ch1DaysOfTheWeekGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1DaysOfTheWeekGame.score, ch1DaysOfTheWeekGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1DaysOfTheWeekGame.index < ch1DaysOfTheWeekGame.questionsInGame)
                                {
                                    ch1DaysOfTheWeekGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1DaysOfTheWeekGame.questionNumber) + " of " + Convert.ToString(ch1DaysOfTheWeekGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1DaysOfTheWeekGame.Get_Question(ch1DaysOfTheWeekGame.randomOrder[ch1DaysOfTheWeekGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }
                            }
                        }
                    }
                    else if (ch1MonthsOfTheYearGameEnabled == true)
                    {
                        if (ch1MonthsOfTheYearGame.index <= ch1MonthsOfTheYearGame.questionsInGame - 1)
                        {
                            if (ch1MonthsOfTheYearGame.text.ToLower() == ch1MonthsOfTheYearGame.Get_Answer(ch1MonthsOfTheYearGame.randomOrder[ch1MonthsOfTheYearGame.index]).ToLower())
                            {
                                ch1MonthsOfTheYearGame.score++;
                                ch1MonthsOfTheYearGame.mastered[ch1MonthsOfTheYearGame.randomOrder[ch1MonthsOfTheYearGame.index]] = true;
                                ch1MonthsOfTheYearGame.text = string.Empty;
                                ch1MonthsOfTheYearGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1MonthsOfTheYearGame.Get_Answer(ch1MonthsOfTheYearGame.randomOrder[ch1MonthsOfTheYearGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1MonthsOfTheYearGame.yourAnswer;

                                ch1MonthsOfTheYearGame.index++;

                                if (soundEnabled == true)
                                {
                                    applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                    applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                    applause_voice.Start();
                                }

                                if (ch1MonthsOfTheYearGame.index == ch1MonthsOfTheYearGame.questionsInGame)
                                {
                                    ch1MonthsOfTheYearGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1MonthsOfTheYearGame.score, ch1MonthsOfTheYearGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1MonthsOfTheYearGame.index < ch1MonthsOfTheYearGame.questionsInGame)
                                {
                                    ch1MonthsOfTheYearGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1MonthsOfTheYearGame.questionNumber) + " of " + Convert.ToString(ch1MonthsOfTheYearGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1MonthsOfTheYearGame.Get_Question(ch1MonthsOfTheYearGame.randomOrder[ch1MonthsOfTheYearGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }

                            }
                            else
                            {
                                ch1MonthsOfTheYearGame.antiScore++;
                                ch1MonthsOfTheYearGame.text = string.Empty;
                                ch1MonthsOfTheYearGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1MonthsOfTheYearGame.Get_Answer(ch1MonthsOfTheYearGame.randomOrder[ch1MonthsOfTheYearGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1MonthsOfTheYearGame.yourAnswer;

                                ch1MonthsOfTheYearGame.index++;

                                if (soundEnabled == true)
                                {
                                    wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                    wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                    wrong_voice.Start();
                                }

                                if (ch1MonthsOfTheYearGame.index == ch1MonthsOfTheYearGame.questionsInGame)
                                {
                                    ch1MonthsOfTheYearGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1MonthsOfTheYearGame.score, ch1MonthsOfTheYearGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1MonthsOfTheYearGame.index < ch1MonthsOfTheYearGame.questionsInGame)
                                {
                                    ch1MonthsOfTheYearGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1MonthsOfTheYearGame.questionNumber) + " of " + Convert.ToString(ch1MonthsOfTheYearGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1MonthsOfTheYearGame.Get_Question(ch1MonthsOfTheYearGame.randomOrder[ch1MonthsOfTheYearGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }
                            }
                        }
                    }
                    else if (ch1SeasonsOfTheYearGameEnabled == true)
                    {
                        if (ch1SeasonsOfTheYearGame.index <= ch1SeasonsOfTheYearGame.questionsInGame - 1)
                        {
                            if (ch1SeasonsOfTheYearGame.text.ToLower() == ch1SeasonsOfTheYearGame.Get_Answer(ch1SeasonsOfTheYearGame.randomOrder[ch1SeasonsOfTheYearGame.index]).ToLower())
                            {
                                ch1SeasonsOfTheYearGame.score++;
                                ch1SeasonsOfTheYearGame.mastered[ch1SeasonsOfTheYearGame.randomOrder[ch1SeasonsOfTheYearGame.index]] = true;
                                ch1SeasonsOfTheYearGame.text = string.Empty;
                                ch1SeasonsOfTheYearGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1SeasonsOfTheYearGame.Get_Answer(ch1SeasonsOfTheYearGame.randomOrder[ch1SeasonsOfTheYearGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1SeasonsOfTheYearGame.yourAnswer;

                                ch1SeasonsOfTheYearGame.index++;

                                if (soundEnabled == true)
                                {
                                    applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                    applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                    applause_voice.Start();
                                }

                                if (ch1SeasonsOfTheYearGame.index == ch1SeasonsOfTheYearGame.questionsInGame)
                                {
                                    ch1SeasonsOfTheYearGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1SeasonsOfTheYearGame.score, ch1SeasonsOfTheYearGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1SeasonsOfTheYearGame.index < ch1SeasonsOfTheYearGame.questionsInGame)
                                {
                                    ch1SeasonsOfTheYearGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1SeasonsOfTheYearGame.questionNumber) + " of " + Convert.ToString(ch1SeasonsOfTheYearGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1SeasonsOfTheYearGame.Get_Question(ch1SeasonsOfTheYearGame.randomOrder[ch1SeasonsOfTheYearGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }

                            }
                            else
                            {
                                ch1SeasonsOfTheYearGame.antiScore++;
                                ch1SeasonsOfTheYearGame.text = string.Empty;
                                ch1SeasonsOfTheYearGame.yourAnswer = txtCh1TranslationGameAnswer.Text;

                                lblCh1TranslationGameCorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.score);
                                lblCh1TranslationGameIncorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.antiScore);
                                lblCh1TranslationGameAnswer.Text = ch1SeasonsOfTheYearGame.Get_Answer(ch1SeasonsOfTheYearGame.randomOrder[ch1SeasonsOfTheYearGame.index]);
                                lblCh1TranslationGameYourAnswer.Text = ch1SeasonsOfTheYearGame.yourAnswer;

                                ch1SeasonsOfTheYearGame.index++;

                                if (soundEnabled == true)
                                {
                                    wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                    wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                    wrong_voice.Start();
                                }

                                if (ch1SeasonsOfTheYearGame.index == ch1SeasonsOfTheYearGame.questionsInGame)
                                {
                                    ch1SeasonsOfTheYearGame.index = 0;

                                    tmrGrade.Enabled = true;
                                    tmrCh1TranslationGame.Enabled = false;
                                    pnlGrade.Visible = true;
                                    WriteToBinaryFile("score.dat");

                                    lblCorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.score);
                                    lblIncorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.antiScore);

                                    float grade = Convert.ToSingle(Decimal.Divide(ch1SeasonsOfTheYearGame.score, ch1SeasonsOfTheYearGame.questionsInGame)) * 100.0f;

                                    switch (grade)
                                    {
                                        case float n when (n >= 90.0f):
                                            {
                                                lblGrade.Text = "A";
                                                break;
                                            }
                                        case float n when (n >= 80.0f && n < 90.0f):
                                            {
                                                lblGrade.Text = "B";
                                                break;
                                            }
                                        case float n when (n >= 70.0f && n < 80.0f):
                                            {
                                                lblGrade.Text = "C";
                                                break;
                                            }
                                        case float n when (n >= 60.0f && n < 70.0f):
                                            {
                                                lblGrade.Text = "D";
                                                break;
                                            }
                                        case float n when (n < 60.0f):
                                            {
                                                lblGrade.Text = "F";
                                                break;
                                            }
                                    }
                                }
                                else if (ch1SeasonsOfTheYearGame.index < ch1SeasonsOfTheYearGame.questionsInGame)
                                {
                                    ch1SeasonsOfTheYearGame.questionNumber++;
                                    lblCh1TranslationGameQuestionNum.Text = Convert.ToString(ch1SeasonsOfTheYearGame.questionNumber) + " of " + Convert.ToString(ch1SeasonsOfTheYearGame.questionsInGame);
                                    lblCh1TranslationGameQuestion.Text = ch1SeasonsOfTheYearGame.Get_Question(ch1SeasonsOfTheYearGame.randomOrder[ch1SeasonsOfTheYearGame.index]);
                                    txtCh1TranslationGameAnswer.Text = string.Empty;
                                    txtCh1TranslationGameAnswer.Focus();
                                }
                            }
                        }
                    }
                }
            }
        }

        private void txtCh1TranslationGameAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (enterKeyPressed == true)
            {
                // Stop the character from being entered into the control
                e.Handled = true;
            }
        }

        private void txtCh1TranslationGameAnswer_KeyUp(object sender, KeyEventArgs e)
        {
            if (pnlGrade.Visible == false && pnlChapter1.Visible == false && pnlCh1TranslationGame.Visible == true)
            {
                if (e.KeyCode == Keys.Enter && enterKeyPressed == true)
                {
                    enterKeyPressed = false;
                }
            }
        }

        private void txtCh2TranslationGameAnswer_TextChanged(object sender, EventArgs e)
        {
            if (ch2TranslationGameEnabled == true)
            {
                ch2TranslationGame.text = txtCh2TranslationGameAnswer.Text;
            }
            else if (ch2PhotoGameEnabled == true)
            {
                ch2PhotoGame.text = txtCh2TranslationGameAnswer.Text;
            }
            else if (ch2NationalitiesGameEnabled == true)
            {
                ch2NationalitiesGame.text = txtCh2TranslationGameAnswer.Text;
            }
            else if (ch2WhatTimeIsItGameEnabled == true)
            {
                ch2WhatTimeIsItGame.text = txtCh2TranslationGameAnswer.Text;
            }
            else if (ch2VerbsGameEnabled == true)
            {
                ch2VerbsGame.text = txtCh2TranslationGameAnswer.Text;
            }
            else if (ch2InterrogativeWordsGameEnabled == true)
            {
                ch2InterrogativeWordsGame.text = txtCh2TranslationGameAnswer.Text;
            }
            else if (ch2CountriesGameEnabled == true)
            {
                ch2CountriesGame.text = txtCh2TranslationGameAnswer.Text;
            }
            else if (ch2ILikeYouLikeGameEnabled == true)
            {
                ch2ILikeYouLikeGame.text = txtCh2TranslationGameAnswer.Text;
            }
        }

        private void txtCh2TranslationGameAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (pnlGrade.Visible == false && pnlChapter2.Visible == false && pnlCh2TranslationGame.Visible == true)
            {
                e.Handled = false;
                if (e.KeyCode == Keys.Enter && enterKeyPressed == false)
                {
                    enterKeyPressed = true;

                    if (ch2TranslationGameEnabled == true)
                    {
                        if (ch2TranslationGame.index <= ch2TranslationGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch2TranslationGame.text.ToLower() == ch2TranslationGame.Get_Answer(ch2TranslationGame.randomOrder[ch2TranslationGame.index]).ToLower())
                                {
                                    ch2TranslationGame.score++;
                                    ch2TranslationGame.mastered[ch2TranslationGame.randomOrder[ch2TranslationGame.index]] = true;
                                    ch2TranslationGame.text = string.Empty;
                                    ch2TranslationGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2TranslationGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2TranslationGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2TranslationGame.Get_Answer(ch2TranslationGame.randomOrder[ch2TranslationGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2TranslationGame.yourAnswer;

                                    ch2TranslationGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch2TranslationGame.index == ch2TranslationGame.questionsInGame)
                                    {
                                        ch2TranslationGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2TranslationGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2TranslationGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2TranslationGame.score, ch2TranslationGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2TranslationGame.index < ch2TranslationGame.questionsInGame)
                                    {
                                        ch2TranslationGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2TranslationGame.questionNumber) + " of " + Convert.ToString(ch2TranslationGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2TranslationGame.Get_Question(ch2TranslationGame.randomOrder[ch2TranslationGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch2TranslationGame.antiScore++;
                                    ch2TranslationGame.text = string.Empty;
                                    ch2TranslationGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2TranslationGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2TranslationGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2TranslationGame.Get_Answer(ch2TranslationGame.randomOrder[ch2TranslationGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2TranslationGame.yourAnswer;

                                    ch2TranslationGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch2TranslationGame.index == ch2TranslationGame.questionsInGame)
                                    {
                                        ch2TranslationGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2TranslationGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2TranslationGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2TranslationGame.score, ch2TranslationGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2TranslationGame.index < ch2TranslationGame.questionsInGame)
                                    {
                                        ch2TranslationGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2TranslationGame.questionNumber) + " of " + Convert.ToString(ch2TranslationGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2TranslationGame.Get_Question(ch2TranslationGame.randomOrder[ch2TranslationGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch2PhotoGameEnabled == true)
                    {
                        if (ch2PhotoGame.index <= ch2PhotoGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch2PhotoGame.text.ToLower() == ch2PhotoGame.Get_Answer(ch2PhotoGame.randomOrder[ch2PhotoGame.index]).ToLower())
                                {
                                    ch2PhotoGame.score++;
                                    ch2PhotoGame.mastered[ch2PhotoGame.randomOrder[ch2PhotoGame.index]] = true;
                                    ch2PhotoGame.text = string.Empty;
                                    ch2PhotoGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2PhotoGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2PhotoGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2PhotoGame.Get_Answer(ch2PhotoGame.randomOrder[ch2PhotoGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2PhotoGame.yourAnswer;

                                    ch2PhotoGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch2PhotoGame.index == ch2PhotoGame.questionsInGame)
                                    {
                                        ch2PhotoGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2PhotoGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2PhotoGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2PhotoGame.score, ch2PhotoGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2PhotoGame.index < ch2PhotoGame.questionsInGame)
                                    {
                                        ch2PhotoGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2PhotoGame.questionNumber) + " of " + Convert.ToString(ch2PhotoGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2PhotoGame.Get_Question(ch2PhotoGame.randomOrder[ch2PhotoGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch2PhotoGame.antiScore++;
                                    ch2PhotoGame.text = string.Empty;
                                    ch2PhotoGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2PhotoGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2PhotoGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2PhotoGame.Get_Answer(ch2PhotoGame.randomOrder[ch2PhotoGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2PhotoGame.yourAnswer;

                                    ch2PhotoGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch2PhotoGame.index == ch2PhotoGame.questionsInGame)
                                    {
                                        ch2PhotoGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2PhotoGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2PhotoGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2PhotoGame.score, ch2PhotoGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2PhotoGame.index < ch2PhotoGame.questionsInGame)
                                    {
                                        ch2PhotoGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2PhotoGame.questionNumber) + " of " + Convert.ToString(ch2PhotoGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2PhotoGame.Get_Question(ch2PhotoGame.randomOrder[ch2PhotoGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch2NationalitiesGameEnabled == true)
                    {
                        if (ch2NationalitiesGame.index <= ch2NationalitiesGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch2NationalitiesGame.text.ToLower() == ch2NationalitiesGame.Get_Answer(ch2NationalitiesGame.randomOrder[ch2NationalitiesGame.index]).ToLower())
                                {
                                    ch2NationalitiesGame.score++;
                                    ch2NationalitiesGame.mastered[ch2NationalitiesGame.randomOrder[ch2NationalitiesGame.index]] = true;
                                    ch2NationalitiesGame.text = string.Empty;
                                    ch2NationalitiesGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2NationalitiesGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2NationalitiesGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2NationalitiesGame.Get_Answer(ch2NationalitiesGame.randomOrder[ch2NationalitiesGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2NationalitiesGame.yourAnswer;

                                    ch2NationalitiesGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch2NationalitiesGame.index == ch2NationalitiesGame.questionsInGame)
                                    {
                                        ch2NationalitiesGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2NationalitiesGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2NationalitiesGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2NationalitiesGame.score, ch2NationalitiesGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2NationalitiesGame.index < ch2NationalitiesGame.questionsInGame)
                                    {
                                        ch2NationalitiesGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2NationalitiesGame.questionNumber) + " of " + Convert.ToString(ch2NationalitiesGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2NationalitiesGame.Get_Question(ch2NationalitiesGame.randomOrder[ch2NationalitiesGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch2NationalitiesGame.antiScore++;
                                    ch2NationalitiesGame.text = string.Empty;
                                    ch2NationalitiesGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2NationalitiesGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2NationalitiesGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2NationalitiesGame.Get_Answer(ch2NationalitiesGame.randomOrder[ch2NationalitiesGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2NationalitiesGame.yourAnswer;

                                    ch2NationalitiesGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch2NationalitiesGame.index == ch2NationalitiesGame.questionsInGame)
                                    {
                                        ch2NationalitiesGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2NationalitiesGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2NationalitiesGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2NationalitiesGame.score, ch2NationalitiesGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2NationalitiesGame.index < ch2NationalitiesGame.questionsInGame)
                                    {
                                        ch2NationalitiesGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2NationalitiesGame.questionNumber) + " of " + Convert.ToString(ch2NationalitiesGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2NationalitiesGame.Get_Question(ch2NationalitiesGame.randomOrder[ch2NationalitiesGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch2WhatTimeIsItGameEnabled == true)
                    {
                        if (ch2WhatTimeIsItGame.index <= ch2WhatTimeIsItGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch2WhatTimeIsItGame.text.ToLower() == ch2WhatTimeIsItGame.Get_Answer(ch2WhatTimeIsItGame.randomOrder[ch2WhatTimeIsItGame.index]).ToLower())
                                {
                                    ch2WhatTimeIsItGame.score++;
                                    ch2WhatTimeIsItGame.mastered[ch2WhatTimeIsItGame.randomOrder[ch2WhatTimeIsItGame.index]] = true;
                                    ch2WhatTimeIsItGame.text = string.Empty;
                                    ch2WhatTimeIsItGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2WhatTimeIsItGame.Get_Answer(ch2WhatTimeIsItGame.randomOrder[ch2WhatTimeIsItGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2WhatTimeIsItGame.yourAnswer;

                                    ch2WhatTimeIsItGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch2WhatTimeIsItGame.index == ch2WhatTimeIsItGame.questionsInGame)
                                    {
                                        ch2WhatTimeIsItGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2WhatTimeIsItGame.score, ch2WhatTimeIsItGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2WhatTimeIsItGame.index < ch2WhatTimeIsItGame.questionsInGame)
                                    {
                                        ch2WhatTimeIsItGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2WhatTimeIsItGame.questionNumber) + " of " + Convert.ToString(ch2WhatTimeIsItGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2WhatTimeIsItGame.Get_Question(ch2WhatTimeIsItGame.randomOrder[ch2WhatTimeIsItGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch2WhatTimeIsItGame.antiScore++;
                                    ch2WhatTimeIsItGame.text = string.Empty;
                                    ch2WhatTimeIsItGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2WhatTimeIsItGame.Get_Answer(ch2WhatTimeIsItGame.randomOrder[ch2WhatTimeIsItGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2WhatTimeIsItGame.yourAnswer;

                                    ch2WhatTimeIsItGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch2WhatTimeIsItGame.index == ch2WhatTimeIsItGame.questionsInGame)
                                    {
                                        ch2WhatTimeIsItGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2WhatTimeIsItGame.score, ch2WhatTimeIsItGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2WhatTimeIsItGame.index < ch2WhatTimeIsItGame.questionsInGame)
                                    {
                                        ch2WhatTimeIsItGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2WhatTimeIsItGame.questionNumber) + " of " + Convert.ToString(ch2WhatTimeIsItGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2WhatTimeIsItGame.Get_Question(ch2WhatTimeIsItGame.randomOrder[ch2WhatTimeIsItGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch2VerbsGameEnabled == true)
                    {
                        if (ch2VerbsGame.index <= ch2VerbsGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch2VerbsGame.text.ToLower() == ch2VerbsGame.Get_Answer(ch2VerbsGame.randomOrder[ch2VerbsGame.index]).ToLower())
                                {
                                    ch2VerbsGame.score++;
                                    ch2VerbsGame.mastered[ch2VerbsGame.randomOrder[ch2VerbsGame.index]] = true;
                                    ch2VerbsGame.text = string.Empty;
                                    ch2VerbsGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2VerbsGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2VerbsGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2VerbsGame.Get_Answer(ch2VerbsGame.randomOrder[ch2VerbsGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2VerbsGame.yourAnswer;

                                    ch2VerbsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch2VerbsGame.index == ch2VerbsGame.questionsInGame)
                                    {
                                        ch2VerbsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2VerbsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2VerbsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2VerbsGame.score, ch2VerbsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2VerbsGame.index < ch2VerbsGame.questionsInGame)
                                    {
                                        ch2VerbsGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2VerbsGame.questionNumber) + " of " + Convert.ToString(ch2VerbsGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2VerbsGame.Get_Question(ch2VerbsGame.randomOrder[ch2VerbsGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch2VerbsGame.antiScore++;
                                    ch2VerbsGame.text = string.Empty;
                                    ch2VerbsGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2VerbsGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2VerbsGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2VerbsGame.Get_Answer(ch2VerbsGame.randomOrder[ch2VerbsGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2VerbsGame.yourAnswer;

                                    ch2VerbsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch2VerbsGame.index == ch2VerbsGame.questionsInGame)
                                    {
                                        ch2VerbsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2VerbsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2VerbsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2VerbsGame.score, ch2VerbsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2VerbsGame.index < ch2VerbsGame.questionsInGame)
                                    {
                                        ch2VerbsGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2VerbsGame.questionNumber) + " of " + Convert.ToString(ch2VerbsGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2VerbsGame.Get_Question(ch2VerbsGame.randomOrder[ch2VerbsGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch2InterrogativeWordsGameEnabled == true)
                    {
                        if (ch2InterrogativeWordsGame.index <= ch2InterrogativeWordsGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch2InterrogativeWordsGame.text.ToLower() == ch2InterrogativeWordsGame.Get_Answer(ch2InterrogativeWordsGame.randomOrder[ch2InterrogativeWordsGame.index]).ToLower())
                                {
                                    ch2InterrogativeWordsGame.score++;
                                    ch2InterrogativeWordsGame.mastered[ch2InterrogativeWordsGame.randomOrder[ch2InterrogativeWordsGame.index]] = true;
                                    ch2InterrogativeWordsGame.text = string.Empty;
                                    ch2InterrogativeWordsGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2InterrogativeWordsGame.Get_Answer(ch2InterrogativeWordsGame.randomOrder[ch2InterrogativeWordsGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2InterrogativeWordsGame.yourAnswer;

                                    ch2InterrogativeWordsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch2InterrogativeWordsGame.index == ch2InterrogativeWordsGame.questionsInGame)
                                    {
                                        ch2InterrogativeWordsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2InterrogativeWordsGame.score, ch2InterrogativeWordsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2InterrogativeWordsGame.index < ch2InterrogativeWordsGame.questionsInGame)
                                    {
                                        ch2InterrogativeWordsGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2InterrogativeWordsGame.questionNumber) + " of " + Convert.ToString(ch2InterrogativeWordsGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2InterrogativeWordsGame.Get_Question(ch2InterrogativeWordsGame.randomOrder[ch2InterrogativeWordsGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch2InterrogativeWordsGame.antiScore++;
                                    ch2InterrogativeWordsGame.text = string.Empty;
                                    ch2InterrogativeWordsGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2InterrogativeWordsGame.Get_Answer(ch2InterrogativeWordsGame.randomOrder[ch2InterrogativeWordsGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2InterrogativeWordsGame.yourAnswer;

                                    ch2InterrogativeWordsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch2InterrogativeWordsGame.index == ch2InterrogativeWordsGame.questionsInGame)
                                    {
                                        ch2InterrogativeWordsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2InterrogativeWordsGame.score, ch2InterrogativeWordsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2InterrogativeWordsGame.index < ch2InterrogativeWordsGame.questionsInGame)
                                    {
                                        ch2InterrogativeWordsGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2InterrogativeWordsGame.questionNumber) + " of " + Convert.ToString(ch2InterrogativeWordsGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2InterrogativeWordsGame.Get_Question(ch2InterrogativeWordsGame.randomOrder[ch2InterrogativeWordsGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch2CountriesGameEnabled == true)
                    {
                        if (ch2CountriesGame.index <= ch2CountriesGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch2CountriesGame.text.ToLower() == ch2CountriesGame.Get_Answer(ch2CountriesGame.randomOrder[ch2CountriesGame.index]).ToLower())
                                {
                                    ch2CountriesGame.score++;
                                    ch2CountriesGame.mastered[ch2CountriesGame.randomOrder[ch2CountriesGame.index]] = true;
                                    ch2CountriesGame.text = string.Empty;
                                    ch2CountriesGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2CountriesGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2CountriesGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2CountriesGame.Get_Answer(ch2CountriesGame.randomOrder[ch2CountriesGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2CountriesGame.yourAnswer;

                                    ch2CountriesGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch2CountriesGame.index == ch2CountriesGame.questionsInGame)
                                    {
                                        ch2CountriesGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2CountriesGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2CountriesGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2CountriesGame.score, ch2CountriesGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2CountriesGame.index < ch2CountriesGame.questionsInGame)
                                    {
                                        ch2CountriesGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2CountriesGame.questionNumber) + " of " + Convert.ToString(ch2CountriesGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2CountriesGame.Get_Question(ch2CountriesGame.randomOrder[ch2CountriesGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch2CountriesGame.antiScore++;
                                    ch2CountriesGame.text = string.Empty;
                                    ch2CountriesGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2CountriesGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2CountriesGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2CountriesGame.Get_Answer(ch2CountriesGame.randomOrder[ch2CountriesGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2CountriesGame.yourAnswer;

                                    ch2CountriesGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch2CountriesGame.index == ch2CountriesGame.questionsInGame)
                                    {
                                        ch2CountriesGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2CountriesGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2CountriesGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2CountriesGame.score, ch2CountriesGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2CountriesGame.index < ch2CountriesGame.questionsInGame)
                                    {
                                        ch2CountriesGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2CountriesGame.questionNumber) + " of " + Convert.ToString(ch2CountriesGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2CountriesGame.Get_Question(ch2CountriesGame.randomOrder[ch2CountriesGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch2ILikeYouLikeGameEnabled == true)
                    {
                        if (ch2ILikeYouLikeGame.index <= ch2ILikeYouLikeGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch2ILikeYouLikeGame.text.ToLower() == ch2ILikeYouLikeGame.Get_Answer(ch2ILikeYouLikeGame.randomOrder[ch2ILikeYouLikeGame.index]).ToLower())
                                {
                                    ch2ILikeYouLikeGame.score++;
                                    ch2ILikeYouLikeGame.mastered[ch2ILikeYouLikeGame.randomOrder[ch2ILikeYouLikeGame.index]] = true;
                                    ch2ILikeYouLikeGame.text = string.Empty;
                                    ch2ILikeYouLikeGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2ILikeYouLikeGame.Get_Answer(ch2ILikeYouLikeGame.randomOrder[ch2ILikeYouLikeGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2ILikeYouLikeGame.yourAnswer;

                                    ch2ILikeYouLikeGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch2ILikeYouLikeGame.index == ch2ILikeYouLikeGame.questionsInGame)
                                    {
                                        ch2ILikeYouLikeGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2ILikeYouLikeGame.score, ch2ILikeYouLikeGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2ILikeYouLikeGame.index < ch2ILikeYouLikeGame.questionsInGame)
                                    {
                                        ch2ILikeYouLikeGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2ILikeYouLikeGame.questionNumber) + " of " + Convert.ToString(ch2ILikeYouLikeGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2ILikeYouLikeGame.Get_Question(ch2ILikeYouLikeGame.randomOrder[ch2ILikeYouLikeGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch2ILikeYouLikeGame.antiScore++;
                                    ch2ILikeYouLikeGame.text = string.Empty;
                                    ch2ILikeYouLikeGame.yourAnswer = txtCh2TranslationGameAnswer.Text;

                                    lblCh2TranslationGameCorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.score);
                                    lblCh2TranslationGameIncorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.antiScore);
                                    lblCh2TranslationGameAnswer.Text = ch2ILikeYouLikeGame.Get_Answer(ch2ILikeYouLikeGame.randomOrder[ch2ILikeYouLikeGame.index]);
                                    lblCh2TranslationGameYourAnswer.Text = ch2ILikeYouLikeGame.yourAnswer;

                                    ch2ILikeYouLikeGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch2ILikeYouLikeGame.index == ch2ILikeYouLikeGame.questionsInGame)
                                    {
                                        ch2ILikeYouLikeGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh2TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch2ILikeYouLikeGame.score, ch2ILikeYouLikeGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch2ILikeYouLikeGame.index < ch2ILikeYouLikeGame.questionsInGame)
                                    {
                                        ch2ILikeYouLikeGame.questionNumber++;
                                        lblCh2TranslationGameQuestionNum.Text = Convert.ToString(ch2ILikeYouLikeGame.questionNumber) + " of " + Convert.ToString(ch2ILikeYouLikeGame.questionsInGame);
                                        lblCh2TranslationGameQuestion.Text = ch2ILikeYouLikeGame.Get_Question(ch2ILikeYouLikeGame.randomOrder[ch2ILikeYouLikeGame.index]);
                                        txtCh2TranslationGameAnswer.Text = string.Empty;
                                        txtCh2TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
        }

        private void txtCh2TranslationGameAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (enterKeyPressed == true)
            {
                // Stop the character from being entered into the control
                e.Handled = true;
            }
        }

        private void txtCh2TranslationGameAnswer_KeyUp(object sender, KeyEventArgs e)
        {
            if (pnlGrade.Visible == false && pnlChapter2.Visible == false && pnlCh2TranslationGame.Visible == true)
            {
                if (e.KeyCode == Keys.Enter && enterKeyPressed == true)
                {
                    enterKeyPressed = false;
                }
            }
        }

        private void txtCh3TranslationGameAnswer_TextChanged(object sender, EventArgs e)
        {
            if (ch3TranslationGameEnabled == true)
            {
                ch3TranslationGame.text = txtCh3TranslationGameAnswer.Text;
            }
            else if (ch3PhotoGameEnabled == true)
            {
                ch3PhotoGame.text = txtCh3TranslationGameAnswer.Text;
            }
            else if (ch3ScheduleGameEnabled == true)
            {
                ch3ScheduleGame.text = txtCh3TranslationGameAnswer.Text;
            }
            else if (ch3BigNumbersGameEnabled == true)
            {
                ch3BigNumbersGame.text = txtCh3TranslationGameAnswer.Text;
            }
            else if (ch3BuildingsGameEnabled == true)
            {
                ch3BuildingsGame.text = txtCh3TranslationGameAnswer.Text;
            }
            else if (ch3PronounsGameEnabled == true)
            {
                ch3PronounsGame.text = txtCh3TranslationGameAnswer.Text;
            }
            else if (ch3WhereIsItGameEnabled == true)
            {
                ch3WhereIsItGame.text = txtCh3TranslationGameAnswer.Text;
            }
            else if (ch3VerbsGameEnabled == true)
            {
                ch3VerbsGame.text = txtCh3TranslationGameAnswer.Text;
            }
        }

        private void txtCh3TranslationGameAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (pnlGrade.Visible == false && pnlChapter3.Visible == false && pnlCh3TranslationGame.Visible == true)
            {
                e.Handled = false;
                if (e.KeyCode == Keys.Enter && enterKeyPressed == false)
                {
                    enterKeyPressed = true;

                    if (ch3TranslationGameEnabled == true)
                    {
                        if (ch3TranslationGame.index <= ch3TranslationGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch3TranslationGame.text.ToLower() == ch3TranslationGame.Get_Answer(ch3TranslationGame.randomOrder[ch3TranslationGame.index]).ToLower())
                                {
                                    ch3TranslationGame.score++;
                                    ch3TranslationGame.mastered[ch3TranslationGame.randomOrder[ch3TranslationGame.index]] = true;
                                    ch3TranslationGame.text = string.Empty;
                                    ch3TranslationGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3TranslationGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3TranslationGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3TranslationGame.Get_Answer(ch3TranslationGame.randomOrder[ch3TranslationGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3TranslationGame.yourAnswer;

                                    ch3TranslationGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch3TranslationGame.index == ch3TranslationGame.questionsInGame)
                                    {
                                        ch3TranslationGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3TranslationGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3TranslationGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3TranslationGame.score, ch3TranslationGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3TranslationGame.index < ch3TranslationGame.questionsInGame)
                                    {
                                        ch3TranslationGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3TranslationGame.questionNumber) + " of " + Convert.ToString(ch3TranslationGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3TranslationGame.Get_Question(ch3TranslationGame.randomOrder[ch3TranslationGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch3TranslationGame.antiScore++;
                                    ch3TranslationGame.text = string.Empty;
                                    ch3TranslationGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3TranslationGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3TranslationGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3TranslationGame.Get_Answer(ch3TranslationGame.randomOrder[ch3TranslationGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3TranslationGame.yourAnswer;

                                    ch3TranslationGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch3TranslationGame.index == ch3TranslationGame.questionsInGame)
                                    {
                                        ch3TranslationGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3TranslationGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3TranslationGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3TranslationGame.score, ch3TranslationGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3TranslationGame.index < ch3TranslationGame.questionsInGame)
                                    {
                                        ch3TranslationGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3TranslationGame.questionNumber) + " of " + Convert.ToString(ch3TranslationGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3TranslationGame.Get_Question(ch3TranslationGame.randomOrder[ch3TranslationGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch3PhotoGameEnabled == true)
                    {
                        if (ch3PhotoGame.index <= ch3PhotoGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch3PhotoGame.text.ToLower() == ch3PhotoGame.Get_Answer(ch3PhotoGame.randomOrder[ch3PhotoGame.index]).ToLower())
                                {
                                    ch3PhotoGame.score++;
                                    ch3PhotoGame.mastered[ch3PhotoGame.randomOrder[ch3PhotoGame.index]] = true;
                                    ch3PhotoGame.text = string.Empty;
                                    ch3PhotoGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3PhotoGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3PhotoGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3PhotoGame.Get_Answer(ch3PhotoGame.randomOrder[ch3PhotoGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3PhotoGame.yourAnswer;

                                    ch3PhotoGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch3PhotoGame.index == ch3PhotoGame.questionsInGame)
                                    {
                                        ch3PhotoGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3PhotoGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3PhotoGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3PhotoGame.score, ch3PhotoGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3PhotoGame.index < ch3PhotoGame.questionsInGame)
                                    {
                                        ch3PhotoGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3PhotoGame.questionNumber) + " of " + Convert.ToString(ch3PhotoGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3PhotoGame.Get_Question(ch3PhotoGame.randomOrder[ch3PhotoGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch3PhotoGame.antiScore++;
                                    ch3PhotoGame.text = string.Empty;
                                    ch3PhotoGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3PhotoGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3PhotoGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3PhotoGame.Get_Answer(ch3PhotoGame.randomOrder[ch3PhotoGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3PhotoGame.yourAnswer;

                                    ch3PhotoGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch3PhotoGame.index == ch3PhotoGame.questionsInGame)
                                    {
                                        ch3PhotoGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3PhotoGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3PhotoGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3PhotoGame.score, ch3PhotoGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3PhotoGame.index < ch3PhotoGame.questionsInGame)
                                    {
                                        ch3PhotoGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3PhotoGame.questionNumber) + " of " + Convert.ToString(ch3PhotoGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3PhotoGame.Get_Question(ch3PhotoGame.randomOrder[ch3PhotoGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch3ScheduleGameEnabled == true)
                    {
                        if (ch3ScheduleGame.index <= ch3ScheduleGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch3ScheduleGame.text.ToLower() == ch3ScheduleGame.Get_Answer(ch3ScheduleGame.randomOrder[ch3ScheduleGame.index]).ToLower())
                                {
                                    ch3ScheduleGame.score++;
                                    ch3ScheduleGame.mastered[ch3ScheduleGame.randomOrder[ch3ScheduleGame.index]] = true;
                                    ch3ScheduleGame.text = string.Empty;
                                    ch3ScheduleGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3ScheduleGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3ScheduleGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3ScheduleGame.Get_Answer(ch3ScheduleGame.randomOrder[ch3ScheduleGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3ScheduleGame.yourAnswer;

                                    ch3ScheduleGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch3ScheduleGame.index == ch3ScheduleGame.questionsInGame)
                                    {
                                        ch3ScheduleGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3ScheduleGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3ScheduleGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3ScheduleGame.score, ch3ScheduleGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3ScheduleGame.index < ch3ScheduleGame.questionsInGame)
                                    {
                                        ch3ScheduleGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3ScheduleGame.questionNumber) + " of " + Convert.ToString(ch3ScheduleGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3ScheduleGame.Get_Question(ch3ScheduleGame.randomOrder[ch3ScheduleGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch3ScheduleGame.antiScore++;
                                    ch3ScheduleGame.text = string.Empty;
                                    ch3ScheduleGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3ScheduleGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3ScheduleGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3ScheduleGame.Get_Answer(ch3ScheduleGame.randomOrder[ch3ScheduleGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3ScheduleGame.yourAnswer;

                                    ch3ScheduleGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch3ScheduleGame.index == ch3ScheduleGame.questionsInGame)
                                    {
                                        ch3ScheduleGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3ScheduleGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3ScheduleGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3ScheduleGame.score, ch3ScheduleGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3ScheduleGame.index < ch3ScheduleGame.questionsInGame)
                                    {
                                        ch3ScheduleGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3ScheduleGame.questionNumber) + " of " + Convert.ToString(ch3ScheduleGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3ScheduleGame.Get_Question(ch3ScheduleGame.randomOrder[ch3ScheduleGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch3BigNumbersGameEnabled == true)
                    {
                        if (ch3BigNumbersGame.index <= ch3BigNumbersGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch3BigNumbersGame.text.ToLower() == ch3BigNumbersGame.Get_Answer(ch3BigNumbersGame.randomOrder[ch3BigNumbersGame.index]).ToLower())
                                {
                                    ch3BigNumbersGame.score++;
                                    ch3BigNumbersGame.mastered[ch3BigNumbersGame.randomOrder[ch3BigNumbersGame.index]] = true;
                                    ch3BigNumbersGame.text = string.Empty;
                                    ch3BigNumbersGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3BigNumbersGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3BigNumbersGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3BigNumbersGame.Get_Answer(ch3BigNumbersGame.randomOrder[ch3BigNumbersGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3BigNumbersGame.yourAnswer;

                                    ch3BigNumbersGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch3BigNumbersGame.index == ch3BigNumbersGame.questionsInGame)
                                    {
                                        ch3BigNumbersGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3BigNumbersGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3BigNumbersGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3BigNumbersGame.score, ch3BigNumbersGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3BigNumbersGame.index < ch3BigNumbersGame.questionsInGame)
                                    {
                                        ch3BigNumbersGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3BigNumbersGame.questionNumber) + " of " + Convert.ToString(ch3BigNumbersGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3BigNumbersGame.Get_Question(ch3BigNumbersGame.randomOrder[ch3BigNumbersGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch3BigNumbersGame.antiScore++;
                                    ch3BigNumbersGame.text = string.Empty;
                                    ch3BigNumbersGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3BigNumbersGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3BigNumbersGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3BigNumbersGame.Get_Answer(ch3BigNumbersGame.randomOrder[ch3BigNumbersGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3BigNumbersGame.yourAnswer;

                                    ch3BigNumbersGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch3BigNumbersGame.index == ch3BigNumbersGame.questionsInGame)
                                    {
                                        ch3BigNumbersGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3BigNumbersGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3BigNumbersGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3BigNumbersGame.score, ch3BigNumbersGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3BigNumbersGame.index < ch3BigNumbersGame.questionsInGame)
                                    {
                                        ch3BigNumbersGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3BigNumbersGame.questionNumber) + " of " + Convert.ToString(ch3BigNumbersGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3BigNumbersGame.Get_Question(ch3BigNumbersGame.randomOrder[ch3BigNumbersGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch3BuildingsGameEnabled == true)
                    {
                        if (ch3BuildingsGame.index <= ch3BuildingsGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch3BuildingsGame.text.ToLower() == ch3BuildingsGame.Get_Answer(ch3BuildingsGame.randomOrder[ch3BuildingsGame.index]).ToLower())
                                {
                                    ch3BuildingsGame.score++;
                                    ch3BuildingsGame.mastered[ch3BuildingsGame.randomOrder[ch3BuildingsGame.index]] = true;
                                    ch3BuildingsGame.text = string.Empty;
                                    ch3BuildingsGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3BuildingsGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3BuildingsGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3BuildingsGame.Get_Answer(ch3BuildingsGame.randomOrder[ch3BuildingsGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3BuildingsGame.yourAnswer;

                                    ch3BuildingsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch3BuildingsGame.index == ch3BuildingsGame.questionsInGame)
                                    {
                                        ch3BuildingsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3BuildingsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3BuildingsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3BuildingsGame.score, ch3BuildingsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3BuildingsGame.index < ch3BuildingsGame.questionsInGame)
                                    {
                                        ch3BuildingsGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3BuildingsGame.questionNumber) + " of " + Convert.ToString(ch3BuildingsGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3BuildingsGame.Get_Question(ch3BuildingsGame.randomOrder[ch3BuildingsGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch3BuildingsGame.antiScore++;
                                    ch3BuildingsGame.text = string.Empty;
                                    ch3BuildingsGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3BuildingsGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3BuildingsGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3BuildingsGame.Get_Answer(ch3BuildingsGame.randomOrder[ch3BuildingsGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3BuildingsGame.yourAnswer;

                                    ch3BuildingsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch3BuildingsGame.index == ch3BuildingsGame.questionsInGame)
                                    {
                                        ch3BuildingsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3BuildingsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3BuildingsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3BuildingsGame.score, ch3BuildingsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3BuildingsGame.index < ch3BuildingsGame.questionsInGame)
                                    {
                                        ch3BuildingsGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3BuildingsGame.questionNumber) + " of " + Convert.ToString(ch3BuildingsGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3BuildingsGame.Get_Question(ch3BuildingsGame.randomOrder[ch3BuildingsGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch3PronounsGameEnabled == true)
                    {
                        if (ch3PronounsGame.index <= ch3PronounsGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch3PronounsGame.text.ToLower() == ch3PronounsGame.Get_Answer(ch3PronounsGame.randomOrder[ch3PronounsGame.index]).ToLower())
                                {
                                    ch3PronounsGame.score++;
                                    ch3PronounsGame.mastered[ch3PronounsGame.randomOrder[ch3PronounsGame.index]] = true;
                                    ch3PronounsGame.text = string.Empty;
                                    ch3PronounsGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3PronounsGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3PronounsGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3PronounsGame.Get_Answer(ch3PronounsGame.randomOrder[ch3PronounsGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3PronounsGame.yourAnswer;

                                    ch3PronounsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch3PronounsGame.index == ch3PronounsGame.questionsInGame)
                                    {
                                        ch3PronounsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3PronounsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3PronounsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3PronounsGame.score, ch3PronounsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3PronounsGame.index < ch3PronounsGame.questionsInGame)
                                    {
                                        ch3PronounsGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3PronounsGame.questionNumber) + " of " + Convert.ToString(ch3PronounsGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3PronounsGame.Get_Question(ch3PronounsGame.randomOrder[ch3PronounsGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch3PronounsGame.antiScore++;
                                    ch3PronounsGame.text = string.Empty;
                                    ch3PronounsGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3PronounsGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3PronounsGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3PronounsGame.Get_Answer(ch3PronounsGame.randomOrder[ch3PronounsGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3PronounsGame.yourAnswer;

                                    ch3PronounsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch3PronounsGame.index == ch3PronounsGame.questionsInGame)
                                    {
                                        ch3PronounsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3PronounsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3PronounsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3PronounsGame.score, ch3PronounsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3PronounsGame.index < ch3PronounsGame.questionsInGame)
                                    {
                                        ch3PronounsGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3PronounsGame.questionNumber) + " of " + Convert.ToString(ch3PronounsGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3PronounsGame.Get_Question(ch3PronounsGame.randomOrder[ch3PronounsGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch3WhereIsItGameEnabled == true)
                    {
                        if (ch3WhereIsItGame.index <= ch3WhereIsItGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch3WhereIsItGame.text.ToLower() == ch3WhereIsItGame.Get_Answer(ch3WhereIsItGame.randomOrder[ch3WhereIsItGame.index]).ToLower())
                                {
                                    ch3WhereIsItGame.score++;
                                    ch3WhereIsItGame.mastered[ch3WhereIsItGame.randomOrder[ch3WhereIsItGame.index]] = true;
                                    ch3WhereIsItGame.text = string.Empty;
                                    ch3WhereIsItGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3WhereIsItGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3WhereIsItGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3WhereIsItGame.Get_Answer(ch3WhereIsItGame.randomOrder[ch3WhereIsItGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3WhereIsItGame.yourAnswer;

                                    ch3WhereIsItGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch3WhereIsItGame.index == ch3WhereIsItGame.questionsInGame)
                                    {
                                        ch3WhereIsItGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3WhereIsItGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3WhereIsItGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3WhereIsItGame.score, ch3WhereIsItGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3WhereIsItGame.index < ch3WhereIsItGame.questionsInGame)
                                    {
                                        ch3WhereIsItGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3WhereIsItGame.questionNumber) + " of " + Convert.ToString(ch3WhereIsItGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3WhereIsItGame.Get_Question(ch3WhereIsItGame.randomOrder[ch3WhereIsItGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch3WhereIsItGame.antiScore++;
                                    ch3WhereIsItGame.text = string.Empty;
                                    ch3WhereIsItGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3WhereIsItGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3WhereIsItGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3WhereIsItGame.Get_Answer(ch3WhereIsItGame.randomOrder[ch3WhereIsItGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3WhereIsItGame.yourAnswer;

                                    ch3WhereIsItGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch3WhereIsItGame.index == ch3WhereIsItGame.questionsInGame)
                                    {
                                        ch3WhereIsItGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3WhereIsItGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3WhereIsItGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3WhereIsItGame.score, ch3WhereIsItGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3WhereIsItGame.index < ch3WhereIsItGame.questionsInGame)
                                    {
                                        ch3WhereIsItGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3WhereIsItGame.questionNumber) + " of " + Convert.ToString(ch3WhereIsItGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3WhereIsItGame.Get_Question(ch3WhereIsItGame.randomOrder[ch3WhereIsItGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch3VerbsGameEnabled == true)
                    {
                        if (ch3VerbsGame.index <= ch3VerbsGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch3VerbsGame.text.ToLower() == ch3VerbsGame.Get_Answer(ch3VerbsGame.randomOrder[ch3VerbsGame.index]).ToLower())
                                {
                                    ch3VerbsGame.score++;
                                    ch3VerbsGame.mastered[ch3VerbsGame.randomOrder[ch3VerbsGame.index]] = true;
                                    ch3VerbsGame.text = string.Empty;
                                    ch3VerbsGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3VerbsGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3VerbsGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3VerbsGame.Get_Answer(ch3VerbsGame.randomOrder[ch3VerbsGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3VerbsGame.yourAnswer;

                                    ch3VerbsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch3VerbsGame.index == ch3VerbsGame.questionsInGame)
                                    {
                                        ch3VerbsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3VerbsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3VerbsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3VerbsGame.score, ch3VerbsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3VerbsGame.index < ch3VerbsGame.questionsInGame)
                                    {
                                        ch3VerbsGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3VerbsGame.questionNumber) + " of " + Convert.ToString(ch3VerbsGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3VerbsGame.Get_Question(ch3VerbsGame.randomOrder[ch3VerbsGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch3VerbsGame.antiScore++;
                                    ch3VerbsGame.text = string.Empty;
                                    ch3VerbsGame.yourAnswer = txtCh3TranslationGameAnswer.Text;

                                    lblCh3TranslationGameCorrect.Text = Convert.ToString(ch3VerbsGame.score);
                                    lblCh3TranslationGameIncorrect.Text = Convert.ToString(ch3VerbsGame.antiScore);
                                    lblCh3TranslationGameAnswer.Text = ch3VerbsGame.Get_Answer(ch3VerbsGame.randomOrder[ch3VerbsGame.index]);
                                    lblCh3TranslationGameYourAnswer.Text = ch3VerbsGame.yourAnswer;

                                    ch3VerbsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch3VerbsGame.index == ch3VerbsGame.questionsInGame)
                                    {
                                        ch3VerbsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh3TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch3VerbsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch3VerbsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch3VerbsGame.score, ch3VerbsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch3VerbsGame.index < ch3VerbsGame.questionsInGame)
                                    {
                                        ch3VerbsGame.questionNumber++;
                                        lblCh3TranslationGameQuestionNum.Text = Convert.ToString(ch3VerbsGame.questionNumber) + " of " + Convert.ToString(ch3VerbsGame.questionsInGame);
                                        lblCh3TranslationGameQuestion.Text = ch3VerbsGame.Get_Question(ch3VerbsGame.randomOrder[ch3VerbsGame.index]);
                                        txtCh3TranslationGameAnswer.Text = string.Empty;
                                        txtCh3TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
        }

        private void txtCh3TranslationGameAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (enterKeyPressed == true)
            {
                // Stop the character from being entered into the control
                e.Handled = true;
            }
        }

        private void txtCh3TranslationGameAnswer_KeyUp(object sender, KeyEventArgs e)
        {
            if (pnlGrade.Visible == false && pnlChapter3.Visible == false && pnlCh3TranslationGame.Visible == true)
            {
                if (e.KeyCode == Keys.Enter && enterKeyPressed == true)
                {
                    enterKeyPressed = false;
                }
            }
        }

        private void txtCh4TranslationGameAnswer_TextChanged(object sender, EventArgs e)
        {
            if (ch4TranslationGameEnabled == true)
            {
                ch4TranslationGame.text = txtCh4TranslationGameAnswer.Text;
            }
            else if (ch4PhotoGameEnabled == true)
            {
                ch4PhotoGame.text = txtCh4TranslationGameAnswer.Text;
            }
            else if (ch4MembersOfTheFamilyGameEnabled == true)
            {
                ch4MembersOfTheFamilyGame.text = txtCh4TranslationGameAnswer.Text;
            }
            else if (ch4VerbsGameEnabled == true)
            {
                ch4VerbsGame.text = txtCh4TranslationGameAnswer.Text;
            }
            else if (ch4AdjetivesGameEnabled == true)
            {
                ch4AdjetivesGame.text = txtCh4TranslationGameAnswer.Text;
            }
            else if (ch4PlacesToGoGameEnabled == true)
            {
                ch4PlacesToGoGame.text = txtCh4TranslationGameAnswer.Text;
            }
            else if (ch4FinalGameEnabled == true)
            {
                ch4FinalGame.text = txtCh4TranslationGameAnswer.Text;
            }
        }

        private void txtCh4TranslationGameAnswer_KeyDown(object sender, KeyEventArgs e)
        {
            if (pnlGrade.Visible == false && pnlChapter4.Visible == false && pnlCh4TranslationGame.Visible == true)
            {
                e.Handled = false;
                if (e.KeyCode == Keys.Enter && enterKeyPressed == false)
                {
                    enterKeyPressed = true;

                    if (ch4TranslationGameEnabled == true)
                    {
                        if (ch4TranslationGame.index <= ch4TranslationGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch4TranslationGame.text.ToLower() == ch4TranslationGame.Get_Answer(ch4TranslationGame.randomOrder[ch4TranslationGame.index]).ToLower())
                                {
                                    ch4TranslationGame.score++;
                                    ch4TranslationGame.mastered[ch4TranslationGame.randomOrder[ch4TranslationGame.index]] = true;
                                    ch4TranslationGame.text = string.Empty;
                                    ch4TranslationGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4TranslationGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4TranslationGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4TranslationGame.Get_Answer(ch4TranslationGame.randomOrder[ch4TranslationGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4TranslationGame.yourAnswer;

                                    ch4TranslationGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch4TranslationGame.index == ch4TranslationGame.questionsInGame)
                                    {
                                        ch4TranslationGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4TranslationGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4TranslationGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4TranslationGame.score, ch4TranslationGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4TranslationGame.index < ch4TranslationGame.questionsInGame)
                                    {
                                        ch4TranslationGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4TranslationGame.questionNumber) + " of " + Convert.ToString(ch4TranslationGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4TranslationGame.Get_Question(ch4TranslationGame.randomOrder[ch4TranslationGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch4TranslationGame.antiScore++;
                                    ch4TranslationGame.text = string.Empty;
                                    ch4TranslationGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4TranslationGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4TranslationGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4TranslationGame.Get_Answer(ch4TranslationGame.randomOrder[ch4TranslationGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4TranslationGame.yourAnswer;

                                    ch4TranslationGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch4TranslationGame.index == ch4TranslationGame.questionsInGame)
                                    {
                                        ch4TranslationGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4TranslationGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4TranslationGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4TranslationGame.score, ch4TranslationGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4TranslationGame.index < ch4TranslationGame.questionsInGame)
                                    {
                                        ch4TranslationGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4TranslationGame.questionNumber) + " of " + Convert.ToString(ch4TranslationGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4TranslationGame.Get_Question(ch4TranslationGame.randomOrder[ch4TranslationGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch4PhotoGameEnabled == true)
                    {
                        if (ch4PhotoGame.index <= ch4PhotoGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch4PhotoGame.text.ToLower() == ch4PhotoGame.Get_Answer(ch4PhotoGame.randomOrder[ch4PhotoGame.index]).ToLower())
                                {
                                    ch4PhotoGame.score++;
                                    ch4PhotoGame.mastered[ch4PhotoGame.randomOrder[ch4PhotoGame.index]] = true;
                                    ch4PhotoGame.text = string.Empty;
                                    ch4PhotoGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4PhotoGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4PhotoGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4PhotoGame.Get_Answer(ch4PhotoGame.randomOrder[ch4PhotoGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4PhotoGame.yourAnswer;

                                    ch4PhotoGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch4PhotoGame.index == ch4PhotoGame.questionsInGame)
                                    {
                                        ch4PhotoGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4PhotoGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4PhotoGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4PhotoGame.score, ch4PhotoGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4PhotoGame.index < ch4PhotoGame.questionsInGame)
                                    {
                                        ch4PhotoGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4PhotoGame.questionNumber) + " of " + Convert.ToString(ch4PhotoGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4PhotoGame.Get_Question(ch4PhotoGame.randomOrder[ch4PhotoGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch4PhotoGame.antiScore++;
                                    ch4PhotoGame.text = string.Empty;
                                    ch4PhotoGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4PhotoGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4PhotoGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4PhotoGame.Get_Answer(ch4PhotoGame.randomOrder[ch4PhotoGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4PhotoGame.yourAnswer;

                                    ch4PhotoGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch4PhotoGame.index == ch4PhotoGame.questionsInGame)
                                    {
                                        ch4PhotoGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4PhotoGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4PhotoGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4PhotoGame.score, ch4PhotoGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4PhotoGame.index < ch4PhotoGame.questionsInGame)
                                    {
                                        ch4PhotoGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4PhotoGame.questionNumber) + " of " + Convert.ToString(ch4PhotoGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4PhotoGame.Get_Question(ch4PhotoGame.randomOrder[ch4PhotoGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch4MembersOfTheFamilyGameEnabled == true)
                    {
                        if (ch4MembersOfTheFamilyGame.index <= ch4MembersOfTheFamilyGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch4MembersOfTheFamilyGame.text.ToLower() == ch4MembersOfTheFamilyGame.Get_Answer(ch4MembersOfTheFamilyGame.randomOrder[ch4MembersOfTheFamilyGame.index]).ToLower())
                                {
                                    ch4MembersOfTheFamilyGame.score++;
                                    ch4MembersOfTheFamilyGame.mastered[ch4MembersOfTheFamilyGame.randomOrder[ch4MembersOfTheFamilyGame.index]] = true;
                                    ch4MembersOfTheFamilyGame.text = string.Empty;
                                    ch4MembersOfTheFamilyGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4MembersOfTheFamilyGame.Get_Answer(ch4MembersOfTheFamilyGame.randomOrder[ch4MembersOfTheFamilyGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4MembersOfTheFamilyGame.yourAnswer;

                                    ch4MembersOfTheFamilyGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch4MembersOfTheFamilyGame.index == ch4MembersOfTheFamilyGame.questionsInGame)
                                    {
                                        ch4MembersOfTheFamilyGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4MembersOfTheFamilyGame.score, ch4MembersOfTheFamilyGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4MembersOfTheFamilyGame.index < ch4MembersOfTheFamilyGame.questionsInGame)
                                    {
                                        ch4MembersOfTheFamilyGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4MembersOfTheFamilyGame.questionNumber) + " of " + Convert.ToString(ch4MembersOfTheFamilyGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4MembersOfTheFamilyGame.Get_Question(ch4MembersOfTheFamilyGame.randomOrder[ch4MembersOfTheFamilyGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch4MembersOfTheFamilyGame.antiScore++;
                                    ch4MembersOfTheFamilyGame.text = string.Empty;
                                    ch4MembersOfTheFamilyGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4MembersOfTheFamilyGame.Get_Answer(ch4MembersOfTheFamilyGame.randomOrder[ch4MembersOfTheFamilyGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4MembersOfTheFamilyGame.yourAnswer;

                                    ch4MembersOfTheFamilyGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch4MembersOfTheFamilyGame.index == ch4MembersOfTheFamilyGame.questionsInGame)
                                    {
                                        ch4MembersOfTheFamilyGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4MembersOfTheFamilyGame.score, ch4MembersOfTheFamilyGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4MembersOfTheFamilyGame.index < ch4MembersOfTheFamilyGame.questionsInGame)
                                    {
                                        ch4MembersOfTheFamilyGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4MembersOfTheFamilyGame.questionNumber) + " of " + Convert.ToString(ch4MembersOfTheFamilyGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4MembersOfTheFamilyGame.Get_Question(ch4MembersOfTheFamilyGame.randomOrder[ch4MembersOfTheFamilyGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch4VerbsGameEnabled == true)
                    {
                        if (ch4VerbsGame.index <= ch4VerbsGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch4VerbsGame.text.ToLower() == ch4VerbsGame.Get_Answer(ch4VerbsGame.randomOrder[ch4VerbsGame.index]).ToLower())
                                {
                                    ch4VerbsGame.score++;
                                    ch4VerbsGame.mastered[ch4VerbsGame.randomOrder[ch4VerbsGame.index]] = true;
                                    ch4VerbsGame.text = string.Empty;
                                    ch4VerbsGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4VerbsGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4VerbsGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4VerbsGame.Get_Answer(ch4VerbsGame.randomOrder[ch4VerbsGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4VerbsGame.yourAnswer;

                                    ch4VerbsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch4VerbsGame.index == ch4VerbsGame.questionsInGame)
                                    {
                                        ch4VerbsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4VerbsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4VerbsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4VerbsGame.score, ch4VerbsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4VerbsGame.index < ch4VerbsGame.questionsInGame)
                                    {
                                        ch4VerbsGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4VerbsGame.questionNumber) + " of " + Convert.ToString(ch4VerbsGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4VerbsGame.Get_Question(ch4VerbsGame.randomOrder[ch4VerbsGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch4VerbsGame.antiScore++;
                                    ch4VerbsGame.text = string.Empty;
                                    ch4VerbsGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4VerbsGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4VerbsGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4VerbsGame.Get_Answer(ch4VerbsGame.randomOrder[ch4VerbsGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4VerbsGame.yourAnswer;

                                    ch4VerbsGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch4VerbsGame.index == ch4VerbsGame.questionsInGame)
                                    {
                                        ch4VerbsGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4VerbsGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4VerbsGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4VerbsGame.score, ch4VerbsGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4VerbsGame.index < ch4VerbsGame.questionsInGame)
                                    {
                                        ch4VerbsGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4VerbsGame.questionNumber) + " of " + Convert.ToString(ch4VerbsGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4VerbsGame.Get_Question(ch4VerbsGame.randomOrder[ch4VerbsGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch4AdjetivesGameEnabled == true)
                    {
                        if (ch4AdjetivesGame.index <= ch4AdjetivesGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch4AdjetivesGame.text.ToLower() == ch4AdjetivesGame.Get_Answer(ch4AdjetivesGame.randomOrder[ch4AdjetivesGame.index]).ToLower())
                                {
                                    ch4AdjetivesGame.score++;
                                    ch4AdjetivesGame.mastered[ch4AdjetivesGame.randomOrder[ch4AdjetivesGame.index]] = true;
                                    ch4AdjetivesGame.text = string.Empty;
                                    ch4AdjetivesGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4AdjetivesGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4AdjetivesGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4AdjetivesGame.Get_Answer(ch4AdjetivesGame.randomOrder[ch4AdjetivesGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4AdjetivesGame.yourAnswer;

                                    ch4AdjetivesGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch4AdjetivesGame.index == ch4AdjetivesGame.questionsInGame)
                                    {
                                        ch4AdjetivesGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4AdjetivesGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4AdjetivesGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4AdjetivesGame.score, ch4AdjetivesGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4AdjetivesGame.index < ch4AdjetivesGame.questionsInGame)
                                    {
                                        ch4AdjetivesGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4AdjetivesGame.questionNumber) + " of " + Convert.ToString(ch4AdjetivesGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4AdjetivesGame.Get_Question(ch4AdjetivesGame.randomOrder[ch4AdjetivesGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch4AdjetivesGame.antiScore++;
                                    ch4AdjetivesGame.text = string.Empty;
                                    ch4AdjetivesGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4AdjetivesGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4AdjetivesGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4AdjetivesGame.Get_Answer(ch4AdjetivesGame.randomOrder[ch4AdjetivesGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4AdjetivesGame.yourAnswer;

                                    ch4AdjetivesGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch4AdjetivesGame.index == ch4AdjetivesGame.questionsInGame)
                                    {
                                        ch4AdjetivesGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4AdjetivesGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4AdjetivesGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4AdjetivesGame.score, ch4AdjetivesGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4AdjetivesGame.index < ch4AdjetivesGame.questionsInGame)
                                    {
                                        ch4AdjetivesGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4AdjetivesGame.questionNumber) + " of " + Convert.ToString(ch4AdjetivesGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4AdjetivesGame.Get_Question(ch4AdjetivesGame.randomOrder[ch4AdjetivesGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch4PlacesToGoGameEnabled == true)
                    {
                        if (ch4PlacesToGoGame.index <= ch4PlacesToGoGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch4PlacesToGoGame.text.ToLower() == ch4PlacesToGoGame.Get_Answer(ch4PlacesToGoGame.randomOrder[ch4PlacesToGoGame.index]).ToLower())
                                {
                                    ch4PlacesToGoGame.score++;
                                    ch4PlacesToGoGame.mastered[ch4PlacesToGoGame.randomOrder[ch4PlacesToGoGame.index]] = true;
                                    ch4PlacesToGoGame.text = string.Empty;
                                    ch4PlacesToGoGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4PlacesToGoGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4PlacesToGoGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4PlacesToGoGame.Get_Answer(ch4PlacesToGoGame.randomOrder[ch4PlacesToGoGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4PlacesToGoGame.yourAnswer;

                                    ch4PlacesToGoGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch4PlacesToGoGame.index == ch4PlacesToGoGame.questionsInGame)
                                    {
                                        ch4PlacesToGoGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4PlacesToGoGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4PlacesToGoGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4PlacesToGoGame.score, ch4PlacesToGoGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4PlacesToGoGame.index < ch4PlacesToGoGame.questionsInGame)
                                    {
                                        ch4PlacesToGoGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4PlacesToGoGame.questionNumber) + " of " + Convert.ToString(ch4PlacesToGoGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4PlacesToGoGame.Get_Question(ch4PlacesToGoGame.randomOrder[ch4PlacesToGoGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch4PlacesToGoGame.antiScore++;
                                    ch4PlacesToGoGame.text = string.Empty;
                                    ch4PlacesToGoGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4PlacesToGoGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4PlacesToGoGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4PlacesToGoGame.Get_Answer(ch4PlacesToGoGame.randomOrder[ch4PlacesToGoGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4PlacesToGoGame.yourAnswer;

                                    ch4PlacesToGoGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch4PlacesToGoGame.index == ch4PlacesToGoGame.questionsInGame)
                                    {
                                        ch4PlacesToGoGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4PlacesToGoGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4PlacesToGoGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4PlacesToGoGame.score, ch4PlacesToGoGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4PlacesToGoGame.index < ch4PlacesToGoGame.questionsInGame)
                                    {
                                        ch4PlacesToGoGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4PlacesToGoGame.questionNumber) + " of " + Convert.ToString(ch4PlacesToGoGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4PlacesToGoGame.Get_Question(ch4PlacesToGoGame.randomOrder[ch4PlacesToGoGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                    else if (ch4FinalGameEnabled == true)
                    {
                        if (ch4FinalGame.index <= ch4FinalGame.questionsInGame - 1)
                        {
                            try
                            {
                                if (ch4FinalGame.text.ToLower() == ch4FinalGame.Get_Answer(ch4FinalGame.randomOrder[ch4FinalGame.index]).ToLower())
                                {
                                    ch4FinalGame.score++;
                                    ch4FinalGame.mastered[ch4FinalGame.randomOrder[ch4FinalGame.index]] = true;
                                    ch4FinalGame.text = string.Empty;
                                    ch4FinalGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4FinalGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4FinalGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4FinalGame.Get_Answer(ch4FinalGame.randomOrder[ch4FinalGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4FinalGame.yourAnswer;

                                    ch4FinalGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        applause_voice = new SourceVoice(xaudio, applause_waveFormat, true);
                                        applause_voice.SubmitSourceBuffer(applause_buffer, applause_soundstream.DecodedPacketsInfo);
                                        applause_voice.Start();
                                    }

                                    if (ch4FinalGame.index == ch4FinalGame.questionsInGame)
                                    {
                                        ch4FinalGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4FinalGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4FinalGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4FinalGame.score, ch4FinalGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4FinalGame.index < ch4FinalGame.questionsInGame)
                                    {
                                        ch4FinalGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4FinalGame.questionNumber) + " of " + Convert.ToString(ch4FinalGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4FinalGame.Get_Question(ch4FinalGame.randomOrder[ch4FinalGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }

                                }
                                else
                                {
                                    ch4FinalGame.antiScore++;
                                    ch4FinalGame.text = string.Empty;
                                    ch4FinalGame.yourAnswer = txtCh4TranslationGameAnswer.Text;

                                    lblCh4TranslationGameCorrect.Text = Convert.ToString(ch4FinalGame.score);
                                    lblCh4TranslationGameIncorrect.Text = Convert.ToString(ch4FinalGame.antiScore);
                                    lblCh4TranslationGameAnswer.Text = ch4FinalGame.Get_Answer(ch4FinalGame.randomOrder[ch4FinalGame.index]);
                                    lblCh4TranslationGameYourAnswer.Text = ch4FinalGame.yourAnswer;

                                    ch4FinalGame.index++;

                                    if (soundEnabled == true)
                                    {
                                        wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                                        wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                                        wrong_voice.Start();
                                    }

                                    if (ch4FinalGame.index == ch4FinalGame.questionsInGame)
                                    {
                                        ch4FinalGame.index = 0;

                                        tmrGrade.Enabled = true;
                                        tmrCh4TranslationGame.Enabled = false;
                                        pnlGrade.Visible = true;
                                        WriteToBinaryFile("score.dat");

                                        lblCorrect.Text = Convert.ToString(ch4FinalGame.score);
                                        lblIncorrect.Text = Convert.ToString(ch4FinalGame.antiScore);

                                        float grade = Convert.ToSingle(Decimal.Divide(ch4FinalGame.score, ch4FinalGame.questionsInGame)) * 100.0f;

                                        switch (grade)
                                        {
                                            case float n when (n >= 90.0f):
                                                {
                                                    lblGrade.Text = "A";
                                                    break;
                                                }
                                            case float n when (n >= 80.0f && n < 90.0f):
                                                {
                                                    lblGrade.Text = "B";
                                                    break;
                                                }
                                            case float n when (n >= 70.0f && n < 80.0f):
                                                {
                                                    lblGrade.Text = "C";
                                                    break;
                                                }
                                            case float n when (n >= 60.0f && n < 70.0f):
                                                {
                                                    lblGrade.Text = "D";
                                                    break;
                                                }
                                            case float n when (n < 60.0f):
                                                {
                                                    lblGrade.Text = "F";
                                                    break;
                                                }
                                        }
                                    }
                                    else if (ch4FinalGame.index < ch4FinalGame.questionsInGame)
                                    {
                                        ch4FinalGame.questionNumber++;
                                        lblCh4TranslationGameQuestionNum.Text = Convert.ToString(ch4FinalGame.questionNumber) + " of " + Convert.ToString(ch4FinalGame.questionsInGame);
                                        lblCh4TranslationGameQuestion.Text = ch4FinalGame.Get_Question(ch4FinalGame.randomOrder[ch4FinalGame.index]);
                                        txtCh4TranslationGameAnswer.Text = string.Empty;
                                        txtCh4TranslationGameAnswer.Focus();
                                    }
                                }
                            }
                            catch
                            {

                            }
                        }
                    }
                }
            }
        }

        private void txtCh4TranslationGameAnswer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (enterKeyPressed == true)
            {
                // Stop the character from being entered into the control
                e.Handled = true;
            }
        }

        private void txtCh4TranslationGameAnswer_KeyUp(object sender, KeyEventArgs e)
        {
            if (pnlGrade.Visible == false && pnlChapter4.Visible == false && pnlCh4TranslationGame.Visible == true)
            {
                if (e.KeyCode == Keys.Enter && enterKeyPressed == true)
                {
                    enterKeyPressed = false;
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 1 - Translation Game Timer
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void tmrCh1TranslationGame_Tick(object sender, EventArgs e)
        {
            if (ch1TranslationGameEnabled == true)
            {
                ch1TranslationGame.seconds -= 1;

                if (ch1TranslationGame.seconds < 0)
                {
                    if (ch1TranslationGame.minutes > 0)
                    {
                        ch1TranslationGame.minutes -= 1;
                        ch1TranslationGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh1TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch1TranslationGame.score);
                        lblIncorrect.Text = Convert.ToString(ch1TranslationGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch1TranslationGame.score, ch1TranslationGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh1TranslationGameTime.Text = ch1TranslationGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1TranslationGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch1PhotoGameEnabled == true)
            {
                ch1PhotoGame.seconds -= 1;

                if (ch1PhotoGame.seconds < 0)
                {
                    if (ch1PhotoGame.minutes > 0)
                    {
                        ch1PhotoGame.minutes -= 1;
                        ch1PhotoGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh1TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch1PhotoGame.score);
                        lblIncorrect.Text = Convert.ToString(ch1PhotoGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch1PhotoGame.score, ch1PhotoGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh1TranslationGameTime.Text = ch1PhotoGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1PhotoGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch1LetterGameEnabled == true)
            {
                ch1LetterGame.seconds -= 1;

                if (ch1LetterGame.seconds < 0)
                {
                    if (ch1LetterGame.minutes > 0)
                    {
                        ch1LetterGame.minutes -= 1;
                        ch1LetterGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh1TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch1LetterGame.score);
                        lblIncorrect.Text = Convert.ToString(ch1LetterGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch1LetterGame.score, ch1LetterGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh1TranslationGameTime.Text = ch1LetterGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1LetterGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch1NumberGameEnabled == true)
            {
                ch1NumberGame.seconds -= 1;

                if (ch1NumberGame.seconds < 0)
                {
                    if (ch1NumberGame.minutes > 0)
                    {
                        ch1NumberGame.minutes -= 1;
                        ch1NumberGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh1TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch1NumberGame.score);
                        lblIncorrect.Text = Convert.ToString(ch1NumberGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch1NumberGame.score, ch1NumberGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh1TranslationGameTime.Text = ch1NumberGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1NumberGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch1ColorGameEnabled == true)
            {
                ch1ColorGame.seconds -= 1;

                if (ch1ColorGame.seconds < 0)
                {
                    if (ch1ColorGame.minutes > 0)
                    {
                        ch1ColorGame.minutes -= 1;
                        ch1ColorGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh1TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch1ColorGame.score);
                        lblIncorrect.Text = Convert.ToString(ch1ColorGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch1ColorGame.score, ch1ColorGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }
                    }
                }
                lblCh1TranslationGameTime.Text = ch1ColorGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1ColorGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch1DaysOfTheWeekGameEnabled == true)
            {
                ch1DaysOfTheWeekGame.seconds -= 1;

                if (ch1DaysOfTheWeekGame.seconds < 0)
                {
                    if (ch1DaysOfTheWeekGame.minutes > 0)
                    {
                        ch1DaysOfTheWeekGame.minutes -= 1;
                        ch1DaysOfTheWeekGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh1TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.score);
                        lblIncorrect.Text = Convert.ToString(ch1DaysOfTheWeekGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch1DaysOfTheWeekGame.score, ch1DaysOfTheWeekGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }
                    }
                }
                lblCh1TranslationGameTime.Text = ch1DaysOfTheWeekGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1DaysOfTheWeekGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch1MonthsOfTheYearGameEnabled == true)
            {
                ch1MonthsOfTheYearGame.seconds -= 1;

                if (ch1MonthsOfTheYearGame.seconds < 0)
                {
                    if (ch1MonthsOfTheYearGame.minutes > 0)
                    {
                        ch1MonthsOfTheYearGame.minutes -= 1;
                        ch1MonthsOfTheYearGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh1TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.score);
                        lblIncorrect.Text = Convert.ToString(ch1MonthsOfTheYearGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch1MonthsOfTheYearGame.score, ch1MonthsOfTheYearGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }
                    }
                }
                lblCh1TranslationGameTime.Text = ch1MonthsOfTheYearGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1MonthsOfTheYearGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch1SeasonsOfTheYearGameEnabled == true)
            {
                ch1SeasonsOfTheYearGame.seconds -= 1;

                if (ch1SeasonsOfTheYearGame.seconds < 0)
                {
                    if (ch1SeasonsOfTheYearGame.minutes > 0)
                    {
                        ch1SeasonsOfTheYearGame.minutes -= 1;
                        ch1SeasonsOfTheYearGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh1TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.score);
                        lblIncorrect.Text = Convert.ToString(ch1SeasonsOfTheYearGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch1SeasonsOfTheYearGame.score, ch1SeasonsOfTheYearGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }
                    }
                }
                lblCh1TranslationGameTime.Text = ch1SeasonsOfTheYearGame.minutes.ToString().PadLeft(2, '0') + ":" + ch1SeasonsOfTheYearGame.seconds.ToString().PadLeft(2, '0');
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 2 - Translation Game Timer
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void tmrCh2TranslationGame_Tick(object sender, EventArgs e)
        {
            if (ch2TranslationGameEnabled == true)
            {
                ch2TranslationGame.seconds -= 1;

                if (ch2TranslationGame.seconds < 0)
                {
                    if (ch2TranslationGame.minutes > 0)
                    {
                        ch2TranslationGame.minutes -= 1;
                        ch2TranslationGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh2TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch2TranslationGame.score);
                        lblIncorrect.Text = Convert.ToString(ch2TranslationGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch2TranslationGame.score, ch2TranslationGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh2TranslationGameTime.Text = ch2TranslationGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2TranslationGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch2PhotoGameEnabled == true)
            {
                ch2PhotoGame.seconds -= 1;

                if (ch2PhotoGame.seconds < 0)
                {
                    if (ch2PhotoGame.minutes > 0)
                    {
                        ch2PhotoGame.minutes -= 1;
                        ch2PhotoGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh2TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch2PhotoGame.score);
                        lblIncorrect.Text = Convert.ToString(ch2PhotoGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch2PhotoGame.score, ch2PhotoGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh2TranslationGameTime.Text = ch2PhotoGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2PhotoGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch2NationalitiesGameEnabled == true)
            {
                ch2NationalitiesGame.seconds -= 1;

                if (ch2NationalitiesGame.seconds < 0)
                {
                    if (ch2NationalitiesGame.minutes > 0)
                    {
                        ch2NationalitiesGame.minutes -= 1;
                        ch2NationalitiesGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh2TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch2NationalitiesGame.score);
                        lblIncorrect.Text = Convert.ToString(ch2NationalitiesGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch2NationalitiesGame.score, ch2NationalitiesGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh2TranslationGameTime.Text = ch2NationalitiesGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2NationalitiesGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch2WhatTimeIsItGameEnabled == true)
            {
                ch2WhatTimeIsItGame.seconds -= 1;

                if (ch2WhatTimeIsItGame.seconds < 0)
                {
                    if (ch2WhatTimeIsItGame.minutes > 0)
                    {
                        ch2WhatTimeIsItGame.minutes -= 1;
                        ch2WhatTimeIsItGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh2TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.score);
                        lblIncorrect.Text = Convert.ToString(ch2WhatTimeIsItGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch2WhatTimeIsItGame.score, ch2WhatTimeIsItGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh2TranslationGameTime.Text = ch2WhatTimeIsItGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2WhatTimeIsItGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch2VerbsGameEnabled == true)
            {
                ch2VerbsGame.seconds -= 1;

                if (ch2VerbsGame.seconds < 0)
                {
                    if (ch2VerbsGame.minutes > 0)
                    {
                        ch2VerbsGame.minutes -= 1;
                        ch2VerbsGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh2TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch2VerbsGame.score);
                        lblIncorrect.Text = Convert.ToString(ch2VerbsGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch2VerbsGame.score, ch2VerbsGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh2TranslationGameTime.Text = ch2VerbsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2VerbsGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch2InterrogativeWordsGameEnabled == true)
            {
                ch2InterrogativeWordsGame.seconds -= 1;

                if (ch2InterrogativeWordsGame.seconds < 0)
                {
                    if (ch2InterrogativeWordsGame.minutes > 0)
                    {
                        ch2InterrogativeWordsGame.minutes -= 1;
                        ch2InterrogativeWordsGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh2TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.score);
                        lblIncorrect.Text = Convert.ToString(ch2InterrogativeWordsGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch2InterrogativeWordsGame.score, ch2InterrogativeWordsGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh2TranslationGameTime.Text = ch2InterrogativeWordsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2InterrogativeWordsGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch2CountriesGameEnabled == true)
            {
                ch2CountriesGame.seconds -= 1;

                if (ch2CountriesGame.seconds < 0)
                {
                    if (ch2CountriesGame.minutes > 0)
                    {
                        ch2CountriesGame.minutes -= 1;
                        ch2CountriesGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh2TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch2CountriesGame.score);
                        lblIncorrect.Text = Convert.ToString(ch2CountriesGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch2CountriesGame.score, ch2CountriesGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh2TranslationGameTime.Text = ch2CountriesGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2CountriesGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch2ILikeYouLikeGameEnabled == true)
            {
                ch2ILikeYouLikeGame.seconds -= 1;

                if (ch2ILikeYouLikeGame.seconds < 0)
                {
                    if (ch2ILikeYouLikeGame.minutes > 0)
                    {
                        ch2ILikeYouLikeGame.minutes -= 1;
                        ch2ILikeYouLikeGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh2TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.score);
                        lblIncorrect.Text = Convert.ToString(ch2ILikeYouLikeGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch2ILikeYouLikeGame.score, ch2ILikeYouLikeGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh2TranslationGameTime.Text = ch2ILikeYouLikeGame.minutes.ToString().PadLeft(2, '0') + ":" + ch2ILikeYouLikeGame.seconds.ToString().PadLeft(2, '0');
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 3 - Translation Game Timer
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void tmrCh3TranslationGame_Tick(object sender, EventArgs e)
        {
            if (ch3TranslationGameEnabled == true)
            {
                ch3TranslationGame.seconds -= 1;

                if (ch3TranslationGame.seconds < 0)
                {
                    if (ch3TranslationGame.minutes > 0)
                    {
                        ch3TranslationGame.minutes -= 1;
                        ch3TranslationGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh3TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch3TranslationGame.score);
                        lblIncorrect.Text = Convert.ToString(ch3TranslationGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch3TranslationGame.score, ch3TranslationGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh3TranslationGameTime.Text = ch3TranslationGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3TranslationGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch3PhotoGameEnabled == true)
            {
                ch3PhotoGame.seconds -= 1;

                if (ch3PhotoGame.seconds < 0)
                {
                    if (ch3PhotoGame.minutes > 0)
                    {
                        ch3PhotoGame.minutes -= 1;
                        ch3PhotoGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh3TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch3PhotoGame.score);
                        lblIncorrect.Text = Convert.ToString(ch3PhotoGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch3PhotoGame.score, ch3PhotoGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh3TranslationGameTime.Text = ch3PhotoGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3PhotoGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch3ScheduleGameEnabled == true)
            {
                ch3ScheduleGame.seconds -= 1;

                if (ch3ScheduleGame.seconds < 0)
                {
                    if (ch3ScheduleGame.minutes > 0)
                    {
                        ch3ScheduleGame.minutes -= 1;
                        ch3ScheduleGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh3TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch3ScheduleGame.score);
                        lblIncorrect.Text = Convert.ToString(ch3ScheduleGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch3ScheduleGame.score, ch3ScheduleGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh3TranslationGameTime.Text = ch3ScheduleGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3ScheduleGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch3BigNumbersGameEnabled == true)
            {
                ch3BigNumbersGame.seconds -= 1;

                if (ch3BigNumbersGame.seconds < 0)
                {
                    if (ch3BigNumbersGame.minutes > 0)
                    {
                        ch3BigNumbersGame.minutes -= 1;
                        ch3BigNumbersGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh3TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch3BigNumbersGame.score);
                        lblIncorrect.Text = Convert.ToString(ch3BigNumbersGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch3BigNumbersGame.score, ch3BigNumbersGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh3TranslationGameTime.Text = ch3BigNumbersGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3BigNumbersGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch3BuildingsGameEnabled == true)
            {
                ch3BuildingsGame.seconds -= 1;

                if (ch3BuildingsGame.seconds < 0)
                {
                    if (ch3BuildingsGame.minutes > 0)
                    {
                        ch3BuildingsGame.minutes -= 1;
                        ch3BuildingsGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh3TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch3BuildingsGame.score);
                        lblIncorrect.Text = Convert.ToString(ch3BuildingsGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch3BuildingsGame.score, ch3BuildingsGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh3TranslationGameTime.Text = ch3BuildingsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3BuildingsGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch3PronounsGameEnabled == true)
            {
                ch3PronounsGame.seconds -= 1;

                if (ch3PronounsGame.seconds < 0)
                {
                    if (ch3PronounsGame.minutes > 0)
                    {
                        ch3PronounsGame.minutes -= 1;
                        ch3PronounsGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh3TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch3PronounsGame.score);
                        lblIncorrect.Text = Convert.ToString(ch3PronounsGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch3PronounsGame.score, ch3PronounsGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh3TranslationGameTime.Text = ch3PronounsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3PronounsGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch3WhereIsItGameEnabled == true)
            {
                ch3WhereIsItGame.seconds -= 1;

                if (ch3WhereIsItGame.seconds < 0)
                {
                    if (ch3WhereIsItGame.minutes > 0)
                    {
                        ch3WhereIsItGame.minutes -= 1;
                        ch3WhereIsItGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh3TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch3WhereIsItGame.score);
                        lblIncorrect.Text = Convert.ToString(ch3WhereIsItGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch3WhereIsItGame.score, ch3WhereIsItGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh3TranslationGameTime.Text = ch3WhereIsItGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3WhereIsItGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch3VerbsGameEnabled == true)
            {
                ch3VerbsGame.seconds -= 1;

                if (ch3VerbsGame.seconds < 0)
                {
                    if (ch3VerbsGame.minutes > 0)
                    {
                        ch3VerbsGame.minutes -= 1;
                        ch3VerbsGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh3TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch3VerbsGame.score);
                        lblIncorrect.Text = Convert.ToString(ch3VerbsGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch3VerbsGame.score, ch3VerbsGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh3TranslationGameTime.Text = ch3VerbsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch3VerbsGame.seconds.ToString().PadLeft(2, '0');
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Chapter 4 - Translation Game Timer
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void tmrCh4TranslationGame_Tick(object sender, EventArgs e)
        {
            if (ch4TranslationGameEnabled == true)
            {
                ch4TranslationGame.seconds -= 1;

                if (ch4TranslationGame.seconds < 0)
                {
                    if (ch4TranslationGame.minutes > 0)
                    {
                        ch4TranslationGame.minutes -= 1;
                        ch4TranslationGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh4TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch4TranslationGame.score);
                        lblIncorrect.Text = Convert.ToString(ch4TranslationGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch4TranslationGame.score, ch4TranslationGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh4TranslationGameTime.Text = ch4TranslationGame.minutes.ToString().PadLeft(2, '0') + ":" + ch4TranslationGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch4PhotoGameEnabled == true)
            {
                ch4PhotoGame.seconds -= 1;

                if (ch4PhotoGame.seconds < 0)
                {
                    if (ch4PhotoGame.minutes > 0)
                    {
                        ch4PhotoGame.minutes -= 1;
                        ch4PhotoGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh4TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch4PhotoGame.score);
                        lblIncorrect.Text = Convert.ToString(ch4PhotoGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch4PhotoGame.score, ch4PhotoGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh4TranslationGameTime.Text = ch4PhotoGame.minutes.ToString().PadLeft(2, '0') + ":" + ch4PhotoGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch4MembersOfTheFamilyGameEnabled == true)
            {
                ch4MembersOfTheFamilyGame.seconds -= 1;

                if (ch4MembersOfTheFamilyGame.seconds < 0)
                {
                    if (ch4MembersOfTheFamilyGame.minutes > 0)
                    {
                        ch4MembersOfTheFamilyGame.minutes -= 1;
                        ch4MembersOfTheFamilyGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh4TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.score);
                        lblIncorrect.Text = Convert.ToString(ch4MembersOfTheFamilyGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch4MembersOfTheFamilyGame.score, ch4MembersOfTheFamilyGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh4TranslationGameTime.Text = ch4MembersOfTheFamilyGame.minutes.ToString().PadLeft(2, '0') + ":" + ch4MembersOfTheFamilyGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch4VerbsGameEnabled == true)
            {
                ch4VerbsGame.seconds -= 1;

                if (ch4VerbsGame.seconds < 0)
                {
                    if (ch4VerbsGame.minutes > 0)
                    {
                        ch4VerbsGame.minutes -= 1;
                        ch4VerbsGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh4TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch4VerbsGame.score);
                        lblIncorrect.Text = Convert.ToString(ch4VerbsGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch4VerbsGame.score, ch4VerbsGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh4TranslationGameTime.Text = ch4VerbsGame.minutes.ToString().PadLeft(2, '0') + ":" + ch4VerbsGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch4AdjetivesGameEnabled == true)
            {
                ch4AdjetivesGame.seconds -= 1;

                if (ch4AdjetivesGame.seconds < 0)
                {
                    if (ch4AdjetivesGame.minutes > 0)
                    {
                        ch4AdjetivesGame.minutes -= 1;
                        ch4AdjetivesGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh4TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch4AdjetivesGame.score);
                        lblIncorrect.Text = Convert.ToString(ch4AdjetivesGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch4AdjetivesGame.score, ch4AdjetivesGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh4TranslationGameTime.Text = ch4AdjetivesGame.minutes.ToString().PadLeft(2, '0') + ":" + ch4AdjetivesGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch4PlacesToGoGameEnabled == true)
            {
                ch4PlacesToGoGame.seconds -= 1;

                if (ch4PlacesToGoGame.seconds < 0)
                {
                    if (ch4PlacesToGoGame.minutes > 0)
                    {
                        ch4PlacesToGoGame.minutes -= 1;
                        ch4PlacesToGoGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh4TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch4PlacesToGoGame.score);
                        lblIncorrect.Text = Convert.ToString(ch4PlacesToGoGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch4PlacesToGoGame.score, ch4PlacesToGoGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh4TranslationGameTime.Text = ch4PlacesToGoGame.minutes.ToString().PadLeft(2, '0') + ":" + ch4PlacesToGoGame.seconds.ToString().PadLeft(2, '0');
            }
            else if (ch4FinalGameEnabled == true)
            {
                ch4FinalGame.seconds -= 1;

                if (ch4FinalGame.seconds < 0)
                {
                    if (ch4FinalGame.minutes > 0)
                    {
                        ch4FinalGame.minutes -= 1;
                        ch4FinalGame.seconds = 59;
                    }
                    else
                    {
                        if (soundEnabled == true)
                        {
                            wrong_voice = new SourceVoice(xaudio, wrong_waveFormat, true);
                            wrong_voice.SubmitSourceBuffer(wrong_buffer, wrong_soundstream.DecodedPacketsInfo);
                            wrong_voice.Start();
                        }

                        tmrGrade.Enabled = true;
                        tmrCh4TranslationGame.Enabled = false;
                        pnlGrade.Visible = true;
                        WriteToBinaryFile("score.dat");
                        enterKeyPressed = true;

                        lblCorrect.Text = Convert.ToString(ch4FinalGame.score);
                        lblIncorrect.Text = Convert.ToString(ch4FinalGame.antiScore);

                        float grade = Convert.ToSingle(Decimal.Divide(ch4FinalGame.score, ch4FinalGame.questionsInGame)) * 100.0f;

                        switch (grade)
                        {
                            case float n when (n >= 90.0f):
                                {
                                    lblGrade.Text = "A";
                                    break;
                                }
                            case float n when (n >= 80.0f && n < 90.0f):
                                {
                                    lblGrade.Text = "B";
                                    break;
                                }
                            case float n when (n >= 70.0f && n < 80.0f):
                                {
                                    lblGrade.Text = "C";
                                    break;
                                }
                            case float n when (n >= 60.0f && n < 70.0f):
                                {
                                    lblGrade.Text = "D";
                                    break;
                                }
                            case float n when (n < 60.0f):
                                {
                                    lblGrade.Text = "F";
                                    break;
                                }
                        }


                    }
                }
                lblCh4TranslationGameTime.Text = ch4FinalGame.minutes.ToString().PadLeft(3, '0') + ":" + ch4FinalGame.seconds.ToString().PadLeft(2, '0');
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // Grade Box
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void tmrGrade_Tick(object sender, EventArgs e)
        {
            tmrGrade.Enabled = false;
            pnlGrade.Visible = false;

            if (chapter1Enabled == true)
            {
                pnlChapter1.Visible = true;

                if (pnlCh1TranslationGame.Visible == true)
                {
                    if (ch1TranslationGameEnabled == true)
                    {
                        ch1TranslationGameEnabled = false;
                    }
                    else if (ch1PhotoGameEnabled == true)
                    {
                        ch1PhotoGameEnabled = false;
                    }
                    else if (ch1LetterGameEnabled == true)
                    {
                        ch1LetterGameEnabled = false;
                    }
                    else if (ch1NumberGameEnabled == true)
                    {
                        ch1NumberGameEnabled = false;
                    }
                    else if (ch1ColorGameEnabled == true)
                    {
                        ch1ColorGameEnabled = false;
                    }
                    else if (ch1DaysOfTheWeekGameEnabled == true)
                    {
                        ch1DaysOfTheWeekGameEnabled = false;
                    }
                    else if (ch1MonthsOfTheYearGameEnabled == true)
                    {
                        ch1MonthsOfTheYearGameEnabled = false;
                    }
                    else if (ch1SeasonsOfTheYearGameEnabled == true)
                    {
                        ch1SeasonsOfTheYearGameEnabled = false;
                    }

                    pnlCh1TranslationGame.Visible = false;
                }
            }
            else if (chapter2Enabled == true)
            {
                pnlChapter2.Visible = true;

                if (pnlCh2TranslationGame.Visible == true)
                {
                    if (ch2TranslationGameEnabled == true)
                    {
                        ch2TranslationGameEnabled = false;
                    }
                    else if (ch2PhotoGameEnabled == true)
                    {
                        ch2PhotoGameEnabled = false;
                    }
                    else if (ch2NationalitiesGameEnabled == true)
                    {
                        ch2NationalitiesGameEnabled = false;
                    }
                    else if (ch2WhatTimeIsItGameEnabled == true)
                    {
                        ch2WhatTimeIsItGameEnabled = false;
                    }
                    else if (ch2VerbsGameEnabled == true)
                    {
                        ch2VerbsGameEnabled = false;
                    }
                    else if (ch2InterrogativeWordsGameEnabled == true)
                    {
                        ch2InterrogativeWordsGameEnabled = false;
                    }
                    else if (ch2CountriesGameEnabled == true)
                    {
                        ch2CountriesGameEnabled = false;
                    }
                    else if (ch2ILikeYouLikeGameEnabled == true)
                    {
                        ch2ILikeYouLikeGameEnabled = false;
                    }

                    pnlCh2TranslationGame.Visible = false;
                }
            }
            else if (chapter3Enabled == true)
            {
                pnlChapter3.Visible = true;

                if (pnlCh3TranslationGame.Visible == true)
                {
                    if (ch3TranslationGameEnabled == true)
                    {
                        ch3TranslationGameEnabled = false;
                    }
                    else if (ch3PhotoGameEnabled == true)
                    {
                        ch3PhotoGameEnabled = false;
                    }
                    else if (ch3ScheduleGameEnabled == true)
                    {
                        ch3ScheduleGameEnabled = false;
                    }
                    else if (ch3BigNumbersGameEnabled == true)
                    {
                        ch3BigNumbersGameEnabled = false;
                    }
                    else if (ch3BuildingsGameEnabled == true)
                    {
                        ch3BuildingsGameEnabled = false;
                    }
                    else if (ch3PronounsGameEnabled == true)
                    {
                        ch3PronounsGameEnabled = false;
                    }
                    else if (ch3WhereIsItGameEnabled == true)
                    {
                        ch3WhereIsItGameEnabled = false;
                    }
                    else if (ch3VerbsGameEnabled == true)
                    {
                        ch3VerbsGameEnabled = false;
                    }

                    pnlCh3TranslationGame.Visible = false;
                }
            }
            else if (chapter4Enabled == true)
            {
                pnlChapter4.Visible = true;

                if (pnlCh4TranslationGame.Visible == true)
                {
                    if (ch4TranslationGameEnabled == true)
                    {
                        ch4TranslationGameEnabled = false;
                    }
                    else if (ch4PhotoGameEnabled == true)
                    {
                        ch4PhotoGameEnabled = false;
                    }
                    else if (ch4MembersOfTheFamilyGameEnabled == true)
                    {
                        ch4MembersOfTheFamilyGameEnabled = false;
                    }
                    else if (ch4VerbsGameEnabled == true)
                    {
                        ch4VerbsGameEnabled = false;
                    }
                    else if (ch4AdjetivesGameEnabled == true)
                    {
                        ch4AdjetivesGameEnabled = false;
                    }
                    else if (ch4PlacesToGoGameEnabled == true)
                    {
                        ch4PlacesToGoGameEnabled = false;
                    }
                    else if (ch4FinalGameEnabled == true)
                    {
                        ch4FinalGameEnabled = false;
                    }

                    pnlCh4TranslationGame.Visible = false;
                }
            }
        }

        private void lblOk_MouseMove(object sender, MouseEventArgs e)
        {
            if (insideOkButton == false)
            {
                insideOkButton = true;
                lblOk.ForeColor = Color.FromArgb(0, 164, 164);
            }
        }

        private void lblOk_MouseLeave(object sender, EventArgs e)
        {
            if (insideOkButton == true)
            {
                insideOkButton = false;
                lblOk.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }

        private void lblOk_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lblOk.ForeColor = Color.FromArgb(0, 69, 87);
            }
        }

        private void lblOk_MouseUp(object sender, MouseEventArgs e)
        {

            if (insideOkButton == true)
            {
                lblOk.ForeColor = Color.FromArgb(0, 164, 164);
                if (e.Button == MouseButtons.Left)
                {
                    picResults.Visible = true;
                    pnlResults.Visible = false;
                }
            }
            else
            {
                lblOk.ForeColor = Color.FromArgb(255, 255, 255);
            }
        }
    }
}
