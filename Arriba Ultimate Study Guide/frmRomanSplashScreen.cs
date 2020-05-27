using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using SharpDX.XAudio2;
using SharpDX.Multimedia;
using SharpDX.IO;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Text;
using Microsoft.Win32;

namespace Arriba_Ultimate_Study_Guide
{
    public partial class frmRomanSplashScreen : Form
    {
        //private bool installOnce = false;

        //[DllImport("gdi32", EntryPoint = "AddFontResource")]
        //public static extern int AddFontResourceA(string lpFileName);
        //[DllImport("gdi32.dll")]
        //private static extern int AddFontResource(string lpszFilename);
        //[DllImport("gdi32.dll")]
        //private static extern int CreateScalableFontResource(uint fdwHidden, string lpszFontRes, string lpszFontFile, string lpszCurrentPath);

        ///// <summary>
        ///// Installs font on the user's system and adds it to the registry so it's available on the next session
        ///// Your font must be included in your project with its build path set to 'Content' and its Copy property
        ///// set to 'Copy Always'
        ///// </summary>
        ///// <param name="contentFontName">Your font to be passed as a resource (i.e. "myfont.tff")</param>
        //private void RegisterFont(string contentFontName)
        //{
        //    // Creates the full path where your font will be installed
        //    string fontDestination = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), contentFontName);

        //    string stringToRemove = "Arriba_Ultimate_Study_Guide.Fonts.";
        //    int length = stringToRemove.Length;

        //    string newFontDestination = fontDestination.Remove(fontDestination.IndexOf(stringToRemove), length);

        //    //string[] list = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Fonts));

        //    //for (int i = 0; i < list.Length; i++)
        //    //{
        //    //    listBox1.Items.Add(list[i]);
        //    //}

            

        //    //MessageBox.Show(fontDestination + "\n" + newFontDestination, "Arriba Ultimate Study Guide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

        //    if (!File.Exists(newFontDestination))
        //    {
        //        //MessageBox.Show("Does not exist, install", "Arriba Ultimate Study Guide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        //// Copies font to destination
        //        //File.Copy(Path.Combine(Directory.GetCurrentDirectory(), contentFontName), fontDestination);

        //        //// Retrieves font name
        //        //// Makes sure you reference System.Drawing
        //        //PrivateFontCollection fontCol = new PrivateFontCollection();
        //        //fontCol.AddFontFile(fontDestination);
        //        //var actualFontName = fontCol.Families[0].Name;

        //        ////Add font
        //        //AddFontResource(fontDestination);
        //        ////Add registry entry   
        //        //Registry.SetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion\Fonts", actualFontName, contentFontName, RegistryValueKind.String);
        //    }
        //    else
        //    {
        //        //MessageBox.Show("exists, doesnt install", "Arriba Ultimate Study Guide", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //    }
        //}

        public frmRomanSplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var newForm = new frmSplashScreen();
            Visible = false;
            newForm.Show();
            timer1.Enabled = false;
        }

        private void frmRomanSplashScreen_Load(object sender, EventArgs e)
        {
            this.Show();
             
            XAudio2 xaudio;
            Assembly assembly;

            AudioBuffer logo_buffer;
            SoundStream logo_soundstream;
            SourceVoice logo_voice;
            WaveFormat logo_waveFormat;
            assembly = Assembly.GetExecutingAssembly();
            xaudio = new XAudio2();
            var masteringsound = new MasteringVoice(xaudio);

            logo_soundstream = new SoundStream(assembly.GetManifestResourceStream("Arriba_Ultimate_Study_Guide.Audio.logosong.wav"));

            logo_waveFormat = logo_soundstream.Format;

            logo_buffer = new AudioBuffer
            {
                Stream = logo_soundstream.ToDataStream(),
                AudioBytes = (int)logo_soundstream.Length,
                Flags = BufferFlags.EndOfStream
            };

            logo_voice = new SourceVoice(xaudio, logo_waveFormat, true);
            logo_voice.SubmitSourceBuffer(logo_buffer, logo_soundstream.DecodedPacketsInfo);
            logo_voice.Start();

            //if (installOnce == false)
            //{
            //    try
            //    {
            //        RegisterFont("Arriba_Ultimate_Study_Guide.Fonts.OpenSans-Bold.ttf");
            //        //RegisterFont("Arriba_Ultimate_Study_Guide.Fonts.OpenSans-BoldItalic.ttf");
            //        //RegisterFont("Arriba_Ultimate_Study_Guide.Fonts.OpenSans-ExtraBold.ttf");
            //        //RegisterFont("Arriba_Ultimate_Study_Guide.Fonts.OpenSans-ExtraBoldItalic.ttf");
            //        //RegisterFont("Arriba_Ultimate_Study_Guide.Fonts.OpenSans-Italic.ttf");
            //        //RegisterFont("Arriba_Ultimate_Study_Guide.Fonts.OpenSans-Light.ttf");
            //        //RegisterFont("Arriba_Ultimate_Study_Guide.Fonts.OpenSans-LightItalic.ttf");
            //        //RegisterFont("Arriba_Ultimate_Study_Guide.Fonts.OpenSans-Regular.ttf");
            //        //RegisterFont("Arriba_Ultimate_Study_Guide.Fonts.OpenSans-Semibold.ttf");
            //        //RegisterFont("Arriba_Ultimate_Study_Guide.Fonts.OpenSans-SemiboldItalic.ttf");
            //    }
            //    catch (IOException error)
            //    {
            //        if (error.Source != null)
            //            MessageBox.Show("Cannot install OpenSans fonts from resource. IOException source: {0}, " + error.Source, "Arriba Ultimate Study Guide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        throw;
            //    }
            //    installOnce = true;
            //}

        }
    }
}
