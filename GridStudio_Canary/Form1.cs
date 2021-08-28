using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GridStudio_Canary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btn_mode01_Click(null, null);
        }

        #region VARIABLES------------------------------------------------------------------------------

        public int PuntosDibujados = 0;
        public int PuntosMaximos = 5;
        public int color = 1;
        public string LineZ = "2";
        public int panelpos = 1;
        public int selectmode = 1;
        public int RBS = 1;
        public int cache1;
        

        List<int> pos = new List<int>();
        List<int> originales = new List<int>();

        #endregion

        #region ROTAR----------------------------------------------------------------------------------
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (PuntosDibujados == PuntosMaximos)
            {
                #region CFX-CFY----------------------------------------------------------------------------
                int[] CFX = new int[PuntosMaximos];
                int[] CFY = new int[PuntosMaximos];
                if (PuntosMaximos == 2)
                {
                    CFX[0] = pos[0];
                    CFY[0] = pos[1];
                    CFX[1] = pos[2];
                    CFY[1] = pos[3];
                }
                if (PuntosMaximos == 3)
                {
                    CFX[0] = pos[0];
                    CFY[0] = pos[1];
                    CFX[1] = pos[2];
                    CFY[1] = pos[3];
                    CFX[2] = pos[4];
                    CFY[2] = pos[5];
                }
                if (PuntosMaximos == 4)
                {
                    CFX[0] = pos[0];
                    CFY[0] = pos[1];
                    CFX[1] = pos[2];
                    CFY[1] = pos[3];
                    CFX[2] = pos[4];
                    CFY[2] = pos[5];
                    CFX[3] = pos[6];
                    CFY[3] = pos[7];
                }
                if (PuntosMaximos == 5)
                {
                    CFX[0] = pos[0];
                    CFY[0] = pos[1];
                    CFX[1] = pos[2];
                    CFY[1] = pos[3];
                    CFX[2] = pos[4];
                    CFY[2] = pos[5];
                    CFX[3] = pos[6];
                    CFY[3] = pos[7];
                    CFX[4] = pos[8];
                    CFY[4] = pos[9];
                }

                #endregion

                double AX = 0;
                double AY = 0;

                for (int i = 0; i < PuntosMaximos; i++)
                {
                    AX = AX + CFX[i];
                    AY = AY + CFY[i];
                }
                AX = AX / PuntosMaximos;
                AY = AY / PuntosMaximos;
                AX = Math.Round(AX);
                AY = Math.Round(AY);

                double Angulo = Math.PI * (-trackBar2.Value) / 180;
                Graphics g = pictureBox1.CreateGraphics();
                g.Clear(Color.Black);
                g.TranslateTransform(int.Parse("" + AX), int.Parse("" + AY));
                Point[] PRotacion = new Point[PuntosMaximos];


                for (int i = 0; i < PuntosMaximos; i++)
                {
                    int x = int.Parse("" + Math.Round(RX(AX,AY, CFX[i], CFY[i], Angulo)));
                    int y = int.Parse("" + Math.Round(RY(AX, AY, CFX[i], CFY[i], Angulo)));
                    PRotacion[i] = new Point(x - int.Parse(""+AX), y-int.Parse(""+AY));
                }

                #region COLORS-----------------------------------------------------------------------------
                //color seleccionado 
                Pen lapiz = new Pen(Color.Red, int.Parse(LineZ));
                if (color == 1)
                {
                    lapiz = new Pen(Color.Red, int.Parse(LineZ));
                }
                if (color == 2)
                {
                    lapiz = new Pen(Color.Blue, int.Parse(LineZ));
                }
                if (color == 3)
                {
                    Color rosaboton = Color.FromArgb(229, 0, 229);
                    lapiz = new Pen(rosaboton, int.Parse(LineZ));
                }
                #endregion

                g.DrawPolygon(lapiz, PRotacion);

                if (PuntosMaximos == 2)
                {
                    pos[0] = CFX[0];
                    pos[1] = CFY[0];
                    pos[2] = CFX[1];
                    pos[3] = CFY[1];
                }
                if (PuntosMaximos == 3)
                {
                    pos[0] = CFX[0];
                    pos[1] = CFY[0];
                    pos[2] = CFX[1];
                    pos[3] = CFY[1];
                    pos[4] = CFX[2];
                    pos[5] = CFY[2];
                }
                if (PuntosMaximos == 4)
                {
                    pos[0] = CFX[0];
                    pos[1] = CFY[0];
                    pos[2] = CFX[1];
                    pos[3] = CFY[1];
                    pos[4] = CFX[2];
                    pos[5] = CFY[2];
                    pos[6] = CFX[3];
                    pos[7] = CFY[3];
                }
                if (PuntosMaximos == 5)
                {
                    pos[0] = CFX[0];
                    pos[1] = CFY[0];
                    pos[2] = CFX[1];
                    pos[3] = CFY[1];
                    pos[4] = CFX[2];
                    pos[5] = CFY[2];
                    pos[6] = CFX[3];
                    pos[7] = CFY[3];
                    pos[8] = CFX[4];
                    pos[9] = CFY[4];
                }
            }
            else
            {
                MessageBox.Show("First finish drawing!!!!!!", "Finish the figure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    
            }
            

        }
        static double RX(double Xo, double Yo, double X, double Y, double Angulo)
        {

            return (Xo + (X - Xo) * Cos(Angulo) - (Y - Yo) * Sen(Angulo));

        }
        static double RY(double Xo, double Yo, double X, double Y, double Angulo)
        {
            return (Yo + (X - Xo) * Sen(Angulo) + (Y - Yo) * Cos(Angulo));
        }
        static double Sen(double anguloR)
        {
            return Math.Round(Math.Sin(anguloR), 2);
        }
        static double Cos(double anguloR)
        {
            return Math.Round(Math.Cos(anguloR), 2);

        }
        #endregion

        #region PUNTOS ORIGINALES----------------------------------------------------------------------
        private void button10_Click_1(object sender, EventArgs e)
        {
            if (PuntosDibujados == PuntosMaximos)
            {
                if (PuntosMaximos == 2)
                {
                    MessageBox.Show("A figure of " + PuntosMaximos + " points was selected" + "\n\nPoint 1: X:" +originales[0].ToString() +"  Y:-"+originales[1].ToString()+"\nPoint 2: X:" +originales[2].ToString() +"  Y:-"+originales[3].ToString(), "Starting Points");
                }
                if (PuntosMaximos == 3)
                {
                    MessageBox.Show("A figure of " + PuntosMaximos + " points was selected" + "\n\nPoint 1: X:" + originales[0].ToString() + "  Y:-" + originales[1].ToString() + "\nPoint 2: X:" + originales[2].ToString() + "  Y:-" + originales[3].ToString() + "\nPoint 3: X:" + originales[4].ToString() + "  Y:-" + originales[5].ToString(), "Starting Points");
                }
                if (PuntosMaximos == 4)
                {
                    MessageBox.Show("A figure of " + PuntosMaximos + " points was selected" + "\n\nPoint 1: X:" + originales[0].ToString() + "  Y:-" + originales[1].ToString() + "\nPoint 2: X:" + originales[2].ToString() + "  Y:-" + originales[3].ToString() + "\nPoint 3: X:" + originales[4].ToString() + "  Y:-" + originales[5].ToString() + "\nPoint 4: X:" + originales[6].ToString() + "  Y:-" + originales[7].ToString(), "Starting Points");
                }
                if (PuntosMaximos == 5)
                {
                    MessageBox.Show("A figure of " + PuntosMaximos + " points was selected" + "\n\nPoint 1: X:" + originales[0].ToString() + "  Y:-" + originales[1].ToString() + "\nPoint 2: X:" + originales[2].ToString() + "  Y:-" + originales[3].ToString() + "\nPoint 3: X:" + originales[4].ToString() + "  Y:-" + originales[5].ToString() + "\nPoint 4: X:" + originales[6].ToString() + "  Y:-" + originales[7].ToString() + "\nPoint 5: X:" + originales[8].ToString() + "  Y:-" + originales[9].ToString(), "Starting Points");
                }
                
            }
            else
            {
                MessageBox.Show("First finish drawing!!!!!!", "Finish the figure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        #endregion

        #region PICTUREBOX-----------------------------------------------------------------------------
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
                        
            #region MODE 1-----------------------------------------------------------------------------
            if (selectmode == 1)
            {
                if (PuntosDibujados < PuntosMaximos)
                {
                    int corX = e.X;
                    int corY = e.Y;

                    DibujoG(corX, corY);
                    originales.Add(corX);
                    originales.Add(corY);

                }
                else
                {
                    MessageBox.Show("No puedes dibujar mas de " + PuntosMaximos + " puntos");
                }
                
                
            }
            #endregion
            
            #region MODE 2-----------------------------------------------------------------------------
            if (selectmode == 2)
            {
                if (PuntosDibujados == PuntosMaximos)
                {                    
                    int VcorX = e.X;
                    int VcorY = e.Y;

                    int DcorX = VcorX - pos[0];
                    int DcorY = VcorY - pos[1];

                    Dibujomodo2(DcorX, DcorY);
                }
                else
                {
                    MessageBox.Show("First finish drawing!!!!!!", "Finish the figure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

            }
            #endregion
            
        }
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            label24.Text = "X:" + e.X + "\nY:-" + e.Y;
        }
        #endregion

        #region ESCALA---------------------------------------------------------------------------------
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (PuntosDibujados==PuntosMaximos)
            {
                #region COLORS-----------------------------------------------------------------------------
                //color seleccionado 
                Pen lapiz = new Pen(Color.Red, int.Parse(LineZ));
                Pen lapizboorador = new Pen(Color.Black, int.Parse(LineZ));
                if (color == 1)
                {
                    lapiz = new Pen(Color.Red, int.Parse(LineZ));
                }
                if (color == 2)
                {
                    lapiz = new Pen(Color.Blue, int.Parse(LineZ));
                }
                if (color == 3)
                {
                    Color rosaboton = Color.FromArgb(229, 0, 229);
                    lapiz = new Pen(rosaboton, int.Parse(LineZ));
                }
                Graphics g = pictureBox1.CreateGraphics();
                #endregion

                #region REDIBUJAR----------------------------------------------------------------------------------
                if (PuntosMaximos == 2)
                {
                    //Diferencia
                    int Df1X = pos[2] - pos[0];
                    int Df1Y = pos[1] - pos[3];     
                                       
                    //Borrar
                    g.Clear(Color.Black);

                    //Nuveo
                    g.DrawRectangle(lapiz, new Rectangle(pos[0], pos[1], 3, 3));
                    g.DrawRectangle(lapiz, new Rectangle(pos[2] + (Df1X*(trackBar1.Value -5)), pos[3] - (Df1Y*(trackBar1.Value-5)), 3, 3));
                    g.DrawLine(lapiz, pos[0], pos[1], pos[2] + (Df1X * (trackBar1.Value - 5)), pos[3] - (Df1Y * (trackBar1.Value - 5)));

                    cache1 = (trackBar1.Value-5);
                }

                if (PuntosDibujados == 3)
                {
                    //Diferencia
                    int Df1X = pos[2] - pos[0];
                    int Df1Y = pos[1] - pos[3];
                    int Df2X = pos[4] - pos[0];
                    int Df2Y = pos[1] - pos[5];

                    
                    //Borrar
                    g.Clear(Color.Black);
                     
                    //Nuveo
                    g.DrawRectangle(lapiz, new Rectangle(pos[0], pos[1], 3, 3));
                    g.DrawRectangle(lapiz, new Rectangle(pos[2] + (Df1X * (trackBar1.Value - 5)), pos[3] - (Df1Y * (trackBar1.Value - 5)), 3, 3));
                    g.DrawRectangle(lapiz, new Rectangle(pos[4] + (Df2X * (trackBar1.Value - 5)), pos[5] - (Df2Y * (trackBar1.Value - 5)), 3, 3));
                    g.DrawLine(lapiz, pos[0], pos[1], pos[2] + (Df1X * (trackBar1.Value - 5)), pos[3] - (Df1Y * (trackBar1.Value - 5)));
                    g.DrawLine(lapiz, pos[2] + (Df1X * (trackBar1.Value - 5)), pos[3] - (Df1Y * (trackBar1.Value - 5)), pos[4] + (Df2X * (trackBar1.Value - 5)), pos[5] - (Df2Y * (trackBar1.Value - 5)));
                    g.DrawLine(lapiz, pos[0], pos[1], pos[4] + (Df2X * (trackBar1.Value - 5)), pos[5] - (Df2Y * (trackBar1.Value - 5)));

                    cache1 = (trackBar1.Value - 5);
                    
                }
                if (PuntosDibujados == 4)
                {
                    //Diferencia
                    int Df1X = pos[2] - pos[0];
                    int Df1Y = pos[1] - pos[3];
                    int Df2X = pos[4] - pos[0];
                    int Df2Y = pos[1] - pos[5];
                    int Df3X = pos[6] - pos[0];
                    int Df3Y = pos[1] - pos[7];


                    //Borrar
                    g.Clear(Color.Black);

                    //Nuveo
                    g.DrawRectangle(lapiz, new Rectangle(pos[0], pos[1], 3, 3));
                    g.DrawRectangle(lapiz, new Rectangle(pos[2] + (Df1X * (trackBar1.Value - 5)), pos[3] - (Df1Y * (trackBar1.Value - 5)), 3, 3));
                    g.DrawRectangle(lapiz, new Rectangle(pos[4] + (Df2X * (trackBar1.Value - 5)), pos[5] - (Df2Y * (trackBar1.Value - 5)), 3, 3));
                    g.DrawRectangle(lapiz, new Rectangle(pos[6] + (Df3X * (trackBar1.Value - 5)), pos[7] - (Df3Y * (trackBar1.Value - 5)), 3, 3));

                    g.DrawLine(lapiz, pos[0], pos[1], pos[2] + (Df1X * (trackBar1.Value - 5)), pos[3] - (Df1Y * (trackBar1.Value - 5)));
                    g.DrawLine(lapiz, pos[2] + (Df1X * (trackBar1.Value - 5)), pos[3] - (Df1Y * (trackBar1.Value - 5)), pos[4] + (Df2X * (trackBar1.Value - 5)), pos[5] - (Df2Y * (trackBar1.Value - 5)));
                    g.DrawLine(lapiz, pos[4] + (Df2X * (trackBar1.Value - 5)), pos[5] - (Df2Y * (trackBar1.Value - 5)), pos[6] + (Df3X * (trackBar1.Value - 5)), pos[7] - (Df3Y * (trackBar1.Value - 5)));
                    g.DrawLine(lapiz, pos[0], pos[1], pos[6] + (Df3X * (trackBar1.Value - 5)), pos[7] - (Df3Y * (trackBar1.Value - 5)));

                    cache1 = (trackBar1.Value - 5);
                }
                if (PuntosDibujados == 5)
                {
                    //Diferencia
                    int Df1X = pos[2] - pos[0];
                    int Df1Y = pos[1] - pos[3];
                    int Df2X = pos[4] - pos[0];
                    int Df2Y = pos[1] - pos[5];
                    int Df3X = pos[6] - pos[0];
                    int Df3Y = pos[1] - pos[7];
                    int Df4X = pos[8] - pos[0];
                    int Df4Y = pos[1] - pos[9];


                    //Borrar
                    g.Clear(Color.Black);

                    //Nuveo
                    g.DrawRectangle(lapiz, new Rectangle(pos[0], pos[1], 3, 3));
                    g.DrawRectangle(lapiz, new Rectangle(pos[2] + (Df1X * (trackBar1.Value - 5)), pos[3] - (Df1Y * (trackBar1.Value - 5)), 3, 3));
                    g.DrawRectangle(lapiz, new Rectangle(pos[4] + (Df2X * (trackBar1.Value - 5)), pos[5] - (Df2Y * (trackBar1.Value - 5)), 3, 3));
                    g.DrawRectangle(lapiz, new Rectangle(pos[6] + (Df3X * (trackBar1.Value - 5)), pos[7] - (Df3Y * (trackBar1.Value - 5)), 3, 3));
                    g.DrawRectangle(lapiz, new Rectangle(pos[8] + (Df4X * (trackBar1.Value - 5)), pos[9] - (Df4Y * (trackBar1.Value - 5)), 3, 3));

                    g.DrawLine(lapiz, pos[0], pos[1], pos[2] + (Df1X * (trackBar1.Value - 5)), pos[3] - (Df1Y * (trackBar1.Value - 5)));
                    g.DrawLine(lapiz, pos[2] + (Df1X * (trackBar1.Value - 5)), pos[3] - (Df1Y * (trackBar1.Value - 5)), pos[4] + (Df2X * (trackBar1.Value - 5)), pos[5] - (Df2Y * (trackBar1.Value - 5)));
                    g.DrawLine(lapiz, pos[4] + (Df2X * (trackBar1.Value - 5)), pos[5] - (Df2Y * (trackBar1.Value - 5)), pos[6] + (Df3X * (trackBar1.Value - 5)), pos[7] - (Df3Y * (trackBar1.Value - 5)));
                    g.DrawLine(lapiz, pos[6] + (Df3X * (trackBar1.Value - 5)), pos[7] - (Df3Y * (trackBar1.Value - 5)), pos[8] + (Df4X * (trackBar1.Value - 5)), pos[9] - (Df4Y * (trackBar1.Value - 5)));
                    g.DrawLine(lapiz, pos[0], pos[1], pos[8] + (Df4X * (trackBar1.Value - 5)), pos[9] - (Df4Y * (trackBar1.Value - 5)));

                    cache1 = (trackBar1.Value - 5);
                }
            }
            else
            {
                MessageBox.Show("First finish drawing!!!!!!", "Finish the figure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
                #endregion
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            if (PuntosDibujados == PuntosMaximos)
            {
                if (PuntosMaximos == 2)
                {
                    int Df1X = pos[2] - pos[0];
                    int Df1Y = pos[1] - pos[3];

                    pos[2] = pos[2] + (Df1X * (trackBar1.Value - 5));
                    pos[3] = pos[3] - (Df1Y * (trackBar1.Value - 5));

                    MessageBox.Show("Scale saved successfully", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                if (PuntosMaximos == 3)
                {
                    int Df1X = pos[2] - pos[0];
                    int Df1Y = pos[1] - pos[3];
                    int Df2X = pos[4] - pos[0];
                    int Df2Y = pos[1] - pos[5];

                    pos[2] = pos[2] + (Df1X * (trackBar1.Value - 5));
                    pos[3] = pos[3] - (Df1Y * (trackBar1.Value - 5));
                    pos[4] = pos[4] + (Df2X * (trackBar1.Value - 5));
                    pos[5] = pos[5] - (Df2Y * (trackBar1.Value - 5));

                    MessageBox.Show("Scale saved successfully", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                if (PuntosMaximos == 4)
                {
                    int Df1X = pos[2] - pos[0];
                    int Df1Y = pos[1] - pos[3];
                    int Df2X = pos[4] - pos[0];
                    int Df2Y = pos[1] - pos[5];
                    int Df3X = pos[6] - pos[0];
                    int Df3Y = pos[1] - pos[7];

                    pos[2] = pos[2] + (Df1X * (trackBar1.Value - 5));
                    pos[3] = pos[3] - (Df1Y * (trackBar1.Value - 5));
                    pos[4] = pos[4] + (Df2X * (trackBar1.Value - 5));
                    pos[5] = pos[5] - (Df2Y * (trackBar1.Value - 5));
                    pos[6] = pos[6] + (Df3X * (trackBar1.Value - 5));
                    pos[7] = pos[7] - (Df3Y * (trackBar1.Value - 5));

                    MessageBox.Show("Scale saved successfully", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                if (PuntosMaximos == 5)
                {
                    int Df1X = pos[2] - pos[0];
                    int Df1Y = pos[1] - pos[3];
                    int Df2X = pos[4] - pos[0];
                    int Df2Y = pos[1] - pos[5];
                    int Df3X = pos[6] - pos[0];
                    int Df3Y = pos[1] - pos[7];
                    int Df4X = pos[8] - pos[0];
                    int Df4Y = pos[1] - pos[9];

                    pos[2] = pos[2] + (Df1X * (trackBar1.Value - 5));
                    pos[3] = pos[3] - (Df1Y * (trackBar1.Value - 5));
                    pos[4] = pos[4] + (Df2X * (trackBar1.Value - 5));
                    pos[5] = pos[5] - (Df2Y * (trackBar1.Value - 5));
                    pos[6] = pos[6] + (Df3X * (trackBar1.Value - 5));
                    pos[7] = pos[7] - (Df3Y * (trackBar1.Value - 5));
                    pos[8] = pos[8] + (Df4X * (trackBar1.Value - 5));
                    pos[9] = pos[9] - (Df4Y * (trackBar1.Value - 5));

                    MessageBox.Show("Scale saved successfully", "Finished", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    
                }
            }
            else
            {
                MessageBox.Show("First finish drawing!!!!!!", "Finish the figure", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        #endregion

        #region MOVIMIENTO-----------------------------------------------------------------------------
        public void Dibujomodo2(int DcorX, int DcorY)
        {
            #region COLORS-----------------------------------------------------------------------------
            //color seleccionado 
            Pen lapiz = new Pen(Color.Red, int.Parse(LineZ));
            Pen lapizboorador = new Pen(Color.Black, int.Parse(LineZ));
            if (color == 1)
            {
                lapiz = new Pen(Color.Red, int.Parse(LineZ));
            }
            if (color == 2)
            {
                lapiz = new Pen(Color.Blue, int.Parse(LineZ));
            }
            if (color == 3)
            {
                Color rosaboton = Color.FromArgb(229, 0, 229);
                lapiz = new Pen(rosaboton, int.Parse(LineZ));
            }
            Graphics g = pictureBox1.CreateGraphics();
            #endregion

            #region MOVIMIENTO-------------------------------------------------------------------------
            if (PuntosMaximos == 2)
            {
                
                int corX = pos[0] + DcorX;
                int corY = pos[1] + DcorY;
                int corX2 = pos[2] + DcorX;
                int corY2 = pos[3] + DcorY;

                lbl_PX.Text = corX.ToString();
                lbl_PY.Text = "-"+corY.ToString();

                //Borrar
                g.Clear(Color.Black);

                //Remplazar
                pos.Insert(0, corX);
                pos.Insert(1, corY);
                pos.Insert(2, corX2);
                pos.Insert(3, corY2);

                //Nuveo
                g.DrawRectangle(lapiz, new Rectangle(corX, corY, 3, 3));
                g.DrawRectangle(lapiz, new Rectangle(corX2, corY2, 3, 3));
                g.DrawLine(lapiz, corX,corY,corX2,corY2);


            }

            if (PuntosMaximos == 3)
            {
                int corX = pos[0] + DcorX;
                int corY = pos[1] + DcorY;
                int corX2 = pos[2] + DcorX;
                int corY2 = pos[3] + DcorY;
                int corX3 = pos[4] + DcorX;
                int corY3 = pos[5] + DcorY;

                lbl_PX.Text = corX.ToString();
                lbl_PY.Text = "-"+corY.ToString();


                //Borrar
                g.Clear(Color.Black);

                //Remplazar
                pos.Insert(0, corX);
                pos.Insert(1, corY);
                pos.Insert(2, corX2);
                pos.Insert(3, corY2);
                pos.Insert(4, corX3);
                pos.Insert(5, corY3);

                //Nuveo
                g.DrawRectangle(lapiz, new Rectangle(corX, corY, 3, 3));
                g.DrawRectangle(lapiz, new Rectangle(corX2, corY2, 3, 3));
                g.DrawRectangle(lapiz, new Rectangle(corX3, corY3, 3, 3));
                g.DrawLine(lapiz, corX, corY, corX2, corY2);
                g.DrawLine(lapiz, corX, corY, corX3, corY3);
                g.DrawLine(lapiz, corX2, corY2, corX3, corY3);
                
            }
            if (PuntosMaximos == 4)
            {
                int corX = pos[0] + DcorX;
                int corY = pos[1] + DcorY;
                int corX2 = pos[2] + DcorX;
                int corY2 = pos[3] + DcorY;
                int corX3 = pos[4] + DcorX;
                int corY3 = pos[5] + DcorY;
                int corX4 = pos[6] + DcorX;
                int corY4 = pos[7] + DcorY;

                lbl_PX.Text = corX.ToString();
                lbl_PY.Text = "-"+corY.ToString();


                //Borrar
                g.Clear(Color.Black);

                //Remplazar
                pos.Insert(0, corX);
                pos.Insert(1, corY);
                pos.Insert(2, corX2);
                pos.Insert(3, corY2);
                pos.Insert(4, corX3);
                pos.Insert(5, corY3);
                pos.Insert(6, corX4);
                pos.Insert(7, corY4);

                //Nuveo
                g.DrawRectangle(lapiz, new Rectangle(corX, corY, 3, 3));
                g.DrawRectangle(lapiz, new Rectangle(corX2, corY2, 3, 3));
                g.DrawRectangle(lapiz, new Rectangle(corX3, corY3, 3, 3));
                g.DrawRectangle(lapiz, new Rectangle(corX4, corY4, 3, 3));
                g.DrawLine(lapiz, corX, corY, corX2, corY2);
                g.DrawLine(lapiz, corX, corY, corX4, corY4);
                g.DrawLine(lapiz, corX2, corY2, corX3, corY3);
                g.DrawLine(lapiz, corX3, corY3, corX4, corY4);

            }
            if (PuntosMaximos == 5)
            {
                int corX = pos[0] + DcorX;
                int corY = pos[1] + DcorY;
                int corX2 = pos[2] + DcorX;
                int corY2 = pos[3] + DcorY;
                int corX3 = pos[4] + DcorX;
                int corY3 = pos[5] + DcorY;
                int corX4 = pos[6] + DcorX;
                int corY4 = pos[7] + DcorY;
                int corX5 = pos[8] + DcorX;
                int corY5 = pos[9] + DcorY;

                lbl_PX.Text = corX.ToString();
                lbl_PY.Text = "-"+corY.ToString();


                //Borrar
                g.Clear(Color.Black);

                //Remplazar
                pos.Insert(0, corX);
                pos.Insert(1, corY);
                pos.Insert(2, corX2);
                pos.Insert(3, corY2);
                pos.Insert(4, corX3);
                pos.Insert(5, corY3);
                pos.Insert(6, corX4);
                pos.Insert(7, corY4);
                pos.Insert(8, corX5);
                pos.Insert(9, corY5);

                //Nuveo
                g.DrawRectangle(lapiz, new Rectangle(pos[0], pos[1], 3, 3));
                g.DrawRectangle(lapiz, new Rectangle(pos[2], pos[3], 3, 3));
                g.DrawRectangle(lapiz, new Rectangle(pos[4], pos[5], 3, 3));
                g.DrawRectangle(lapiz, new Rectangle(pos[6], pos[7], 3, 3));
                g.DrawRectangle(lapiz, new Rectangle(pos[8], pos[9], 3, 3));
                g.DrawLine(lapiz, corX, corY, corX2, corY2);
                g.DrawLine(lapiz, corX, corY, corX5, corY5);
                g.DrawLine(lapiz, corX2, corY2, corX3, corY3);
                g.DrawLine(lapiz, corX3, corY3, corX4, corY4);
                g.DrawLine(lapiz, pos[6], pos[7], pos[8], pos[9]);

            }
            #endregion
        }
        #endregion

        #region DIBUJAR--------------------------------------------------------------------------------
        public void DibujoG(int corX, int corY)
        {
            #region COLORS-----------------------------------------------------------------------------
            //color seleccionado 
            Pen lapiz = new Pen(Color.Red, int.Parse(LineZ));
            Pen lapizboorador = new Pen(Color.Black, int.Parse(LineZ));
            if (color == 1)
            {
                lapiz = new Pen(Color.Red, int.Parse(LineZ));
            }
            if (color == 2)
            {
                lapiz = new Pen(Color.Blue, int.Parse(LineZ));
            }
            if (color == 3)
            {
                Color rosaboton = Color.FromArgb(229, 0, 229);
                lapiz = new Pen(rosaboton, int.Parse(LineZ));
            }
            #endregion

            #region DIBUJAR----------------------------------------------------------------------------
            //Hoja para dibujar
            Graphics g = pictureBox1.CreateGraphics();

            //dibujar metodo 1
            g.DrawRectangle(lapiz, new Rectangle(corX, corY, 3, 3));
            PuntosDibujados = PuntosDibujados + 1;
            lbl_PX.Text = corX.ToString();
            lbl_PY.Text = "-"+corY.ToString();

            pos.Add(corX);
            pos.Add(corY);

            if (pos.Count > 3)
            {
                g.DrawLine(lapiz, pos[pos.Count -4],pos[pos.Count - 3],pos[pos.Count-2],pos[pos.Count -1]);
            }

            if (PuntosDibujados == PuntosMaximos)
            {
                g.DrawLine(lapiz, pos[pos.Count -2], pos[pos.Count -1], pos[0], pos[1]);
            }
            #endregion
            
        }
        #endregion
        
        #region PANELES--------------------------------------------------------------------------------
        private void btn_mode01_Click(object sender, EventArgs e)
        {
            panelpos = 1;
            selectmode = 1;

            pbx_panel_1.BringToFront();
            btn_mode01.BringToFront();
            btn_mode02.BringToFront();
            btn_mode03.BringToFront();
            btn_mode04.BringToFront();
            btn_mode05.BringToFront();

            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            textBox1.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;

            pbx_mode.BringToFront();
            label10.BringToFront();
            label14.BringToFront();


        }

        private void btn_mode02_Click(object sender, EventArgs e)
        {
            panelpos = 2;
            selectmode = 2;

            pbx_panel_2.BringToFront();
            btn_mode01.BringToFront();
            btn_mode02.BringToFront();
            btn_mode03.BringToFront();
            btn_mode04.BringToFront();
            btn_mode05.BringToFront();
            


            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            textBox1.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            label11.BringToFront();
            label21.BringToFront();
            
            
        }

        private void btn_mode03_Click(object sender, EventArgs e)
        {
            panelpos = 3;
            selectmode = 3;


            pbx_panel_3.BringToFront();
            btn_mode01.BringToFront();
            btn_mode02.BringToFront();
            btn_mode03.BringToFront();
            btn_mode04.BringToFront();
            btn_mode05.BringToFront();
            label22.BringToFront();
            trackBar1.BringToFront();
            label23.BringToFront();
            button9.BringToFront();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            textBox1.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            label13.BringToFront();
        }

        private void btn_mode04_Click(object sender, EventArgs e)
        {
            panelpos = 4;
            selectmode = 5;


            pbx_panel_4.BringToFront();
            btn_mode01.BringToFront();
            btn_mode02.BringToFront();
            btn_mode03.BringToFront();
            btn_mode04.BringToFront();
            btn_mode05.BringToFront();
            trackBar2.BringToFront();
            label26.BringToFront();
            label27.BringToFront();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            textBox1.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            label15.BringToFront();
        }

        private void btn_mode05_Click(object sender, EventArgs e)
        {
            panelpos = 5;
            selectmode = 6;


            pbx_panel_5.BringToFront();
            btn_mode01.BringToFront();
            btn_mode02.BringToFront();
            btn_mode03.BringToFront();
            btn_mode04.BringToFront();
            btn_mode05.BringToFront();

            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            textBox1.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            button8.Enabled = false;

            label16.BringToFront();
            label17.BringToFront();
            label18.BringToFront();
            label19.BringToFront();
            label20.BringToFront();

        }
        #endregion

        #region DESIGN---------------------------------------------------------------------------------
        private void btn_right_Click(object sender, EventArgs e)
        {
            if (panelpos <= 5)
            {
                panelpos = panelpos + 1;
            }
            if (panelpos == 6)
            {
                panelpos = 1;
            }


            if (panelpos == 1)
            {
                btn_mode01_Click(null, null);
            }
            if (panelpos == 2)
            {
                btn_mode02_Click(null, null);
            }
            if (panelpos == 3)
            {
                btn_mode03_Click(null, null);
            }
            if (panelpos == 4)
            {
                btn_mode04_Click(null, null);
            }
            if (panelpos == 5)
            {
                btn_mode05_Click(null, null);
            }
        }

        private void btn_left_Click(object sender, EventArgs e)
        {

            if (panelpos >= 1)
            {
                panelpos = panelpos - 1;
            }
            if (panelpos == 0)
            {
                panelpos = 5;
            }



            if (panelpos == 1)
            {
                btn_mode01_Click(null, null);
            }
            if (panelpos == 2)
            {
                btn_mode02_Click(null, null);
            }
            if (panelpos == 3)
            {
                btn_mode03_Click(null, null);
            }
            if (panelpos == 4)
            {
                btn_mode04_Click(null, null);
            }
            if (panelpos == 5)
            {
                btn_mode05_Click(null, null);
            }
        }
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            LineZ = textBox1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            color = 1;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            color = 2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            color = 3;
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PuntosMaximos = 2;
            PuntosDibujados = 0;
            pictureBox1.Image = null;
            lbl_PX.Text = "-";
            lbl_PY.Text = "-";
            pos.Clear();
            originales.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PuntosMaximos = 3;
            PuntosDibujados = 0;
            pictureBox1.Image = null;
            lbl_PX.Text = "-";
            lbl_PY.Text = "-";
            pos.Clear();
            originales.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PuntosMaximos = 4;
            PuntosDibujados = 0;
            pictureBox1.Image = null;
            lbl_PX.Text = "-";
            lbl_PY.Text = "-";
            pos.Clear();
            originales.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PuntosMaximos = 5;
            PuntosDibujados = 0;
            pictureBox1.Image = null;
            lbl_PX.Text = "-";
            lbl_PY.Text = "-";
            pos.Clear();
            originales.Clear();
        }
        #endregion

        #region MISS_CLICK-----------------------------------------------------------------------------
        private void button11_Click(object sender, EventArgs e)
        {


        }
        private void button9_Click_1(object sender, EventArgs e)
        {

        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void button28_Click(object sender, EventArgs e)
        {

        }
        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {

        }

        private void button22_Click(object sender, EventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void label9_Click(object sender, EventArgs e)
        {

        }

        #endregion

    }
}
