using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Lights : Form
    {
        int GridOrigin = 100;
        const int LightSpacing = 100;

       public const int NumLightsX = 5;
        public const int NumLightsY = 5;

       public static Light[,] lights = new Light[NumLightsX, NumLightsY];


        public Lights()
        {
            InitializeComponent();
            CreateLights();
            TurnRandomLightsOn();
        }

      

        private void CreateLights()
            {
            for (int y = 0; y < NumLightsY; y++)
            {
                for (int x = 0; x < NumLightsX; x++)
                {
                    Light l = new Light(x,y);

                    l.Location = new Point(x*LightSpacing + GridOrigin, y *LightSpacing + GridOrigin) ;

                    this.Controls.Add(l);

                    lights[x, y] = l;
                }
            }

            }

        void TurnRandomLightsOn()
        {
            Random rand1 = new Random();
            int NumLights = rand1.Next(1, NumLightsX*NumLightsY); // between 1 and all the lights

            for (int i = 0; i < NumLights; i++)
            {
                int x = rand1.Next(1, NumLightsX);
                int y = rand1.Next(1, NumLightsY);

                lights[x, y].SwitchColour();

              
            }
        }

        public static bool CheckWin()
        {
            bool win = true;

            foreach (Light l in WindowsFormsApp1.Lights.lights)
            {
                if (l.ON)
                    win = false;
            }

            return win;
        }


        public class Light : Button
    {


        public bool ON = false;

        public const int LightWidth = 75;
        public const int LightHeight = 75;

        int XPos;
        int YPos;

        public Light(int _xpos, int _ypos)
        {
            XPos = _xpos;
            YPos = _ypos;

            BackColor = Color.Blue;
            ForeColor = Color.Black;
            Size = new Size(LightWidth, LightHeight);
            Click += new EventHandler(button_click);
        }

        public  void button_click(object sender, EventArgs e)
        {
            Button b = (Button)sender;


            SwitchColour(b); // this light

            int LeftX = XPos - 1;
            if(LeftX>=0 )
                    SwitchColour(WindowsFormsApp1.Lights.lights[LeftX, YPos]); // light to the left

            int RightX = XPos + 1;
            if (RightX < WindowsFormsApp1.Lights.NumLightsX)
                    SwitchColour(WindowsFormsApp1.Lights.lights[RightX, YPos]); // light to the right

            int UpY = YPos + 1;
            if (UpY < WindowsFormsApp1.Lights.NumLightsY)
                    SwitchColour(WindowsFormsApp1.Lights.lights[XPos, UpY]); // light above

            int DownY = YPos -1;
            if(DownY >=0)
                    SwitchColour(WindowsFormsApp1.Lights.lights[XPos, DownY]); // light below



             

               CheckWin();

        }

        public void SwitchColour(Button _b)
        {
            ON = !ON;

            if (_b.BackColor == Color.Blue)
                _b.BackColor = Color.Yellow;
            else
                _b.BackColor = Color.Blue;
        }

        public void SwitchColour()           // same method as above but defaults to this light, for use in the switch random lights on method
        {
            ON = !ON;

            Button _b = this;

            if (_b.BackColor == Color.Blue)
                _b.BackColor = Color.Yellow;
            else
                _b.BackColor = Color.Blue;
        }


        
    }

    }
}
