using Renci.SshNet;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace Robot_Client
{
    public partial class Form1 : Form
    {
        private SshClient RPi = null;
        private ShellStream shell = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void DrawingPlot()
        {
            Pen PlotLine, ExtraPlotLine;
            PlotLine = new Pen(Color.Black, 2);
            ExtraPlotLine = new Pen(Color.Black);
            Graphics plot = CarPosition.CreateGraphics();
            //drawing plot axis
            plot.DrawLine(PlotLine, 0, CarPosition.Height / 2, CarPosition.Width, CarPosition.Height / 2);
            plot.DrawLine(PlotLine, CarPosition.Width / 2, 0, CarPosition.Width / 2, CarPosition.Height);
            //drawing Oy arrow
            plot.DrawLine(PlotLine, ((CarPosition.Width / 2) - 7), 10, (CarPosition.Width / 2), 0);
            plot.DrawLine(PlotLine, (CarPosition.Width / 2), 0, ((CarPosition.Width / 2) + 7), 10);
            //drawimg OX arrow
            plot.DrawLine(PlotLine, (CarPosition.Width - 10), ((CarPosition.Height / 2) - 7), CarPosition.Width, (CarPosition.Height / 2));
            plot.DrawLine(PlotLine, CarPosition.Width, (CarPosition.Height / 2), (CarPosition.Width - 10), ((CarPosition.Height / 2) + 7));

            float LenghX = ((CarPosition.Width / 2) - 7) / 10;
            float LenghY = ((CarPosition.Height / 2) - 7) / 10;

            Font drawFont = new Font("Arial", 9);
            SolidBrush drawBrush = new SolidBrush(Color.Black);

            plot.DrawString("0", drawFont, drawBrush, new PointF(((CarPosition.Width / 2) + 2), (CarPosition.Height / 2) + 2));

            plot.DrawString("Y", new Font("Arial", 11), drawBrush, new PointF(((CarPosition.Width / 2) - 22), 2));
            plot.DrawString("X", new Font("Arial", 11), drawBrush, new PointF(CarPosition.Width - 15, ((CarPosition.Height / 2) - 22)));

            float sum = 0;

            for (int i = 1; i <= 10; i++)
            {
                sum = sum + LenghX;
                //splitting Ox in 10 sections
                plot.DrawLine(PlotLine, ((CarPosition.Width / 2) + sum), ((CarPosition.Height / 2) + 5), ((CarPosition.Width / 2) + sum), ((CarPosition.Height / 2) - 5));
                plot.DrawLine(PlotLine, ((CarPosition.Width / 2) - sum), ((CarPosition.Height / 2) + 5), ((CarPosition.Width / 2) - sum), ((CarPosition.Height / 2) - 5));
                //putting the section number
                plot.DrawString(Convert.ToString(i * 10), drawFont, drawBrush, new PointF(((CarPosition.Width / 2) + sum - 5), ((CarPosition.Height / 2) + 6)));
                plot.DrawString(Convert.ToString(i * -10), drawFont, drawBrush, new PointF(((CarPosition.Width / 2) - sum - 7), ((CarPosition.Height / 2) + 6)));
                //drawing extra lines Ox
                plot.DrawLine(ExtraPlotLine, ((CarPosition.Width / 2) + sum), 0, ((CarPosition.Width / 2) + sum), CarPosition.Height);
                plot.DrawLine(ExtraPlotLine, ((CarPosition.Width / 2) - sum), 0, ((CarPosition.Width / 2) - sum), CarPosition.Height);
            }

            sum = 0;

            for (int i = 1; i <= 10; i++)
            {
                sum = sum + LenghY;
                //splitting Oy in 10 sections
                plot.DrawLine(PlotLine, ((CarPosition.Width / 2) - 5), ((CarPosition.Height / 2) + sum), ((CarPosition.Width / 2) + 5), ((CarPosition.Height / 2) + sum));
                plot.DrawLine(PlotLine, ((CarPosition.Width / 2) - 5), ((CarPosition.Height / 2) - sum), ((CarPosition.Width / 2) + 5), ((CarPosition.Height / 2) - sum));
                //putting the section number
                plot.DrawString(Convert.ToString(i * 10), drawFont, drawBrush, new PointF(((CarPosition.Width / 2) + 6), ((CarPosition.Height / 2) - sum - 5)));
                plot.DrawString(Convert.ToString(i * -10), drawFont, drawBrush, new PointF(((CarPosition.Width / 2) + 6), ((CarPosition.Height / 2) + sum - 7)));
                //drawing extra lines Oy
                plot.DrawLine(ExtraPlotLine, 0, ((CarPosition.Height / 2) + sum), CarPosition.Width, ((CarPosition.Height / 2) + sum));
                plot.DrawLine(ExtraPlotLine, 0, ((CarPosition.Height / 2) - sum), CarPosition.Width, ((CarPosition.Height / 2) - sum));
            }

            plot.Dispose();
        }

        private void DrawingRectangle(int _x, int _y) //painting the rectangle acording to coordinats
        {
            Pen DrawRec = new Pen(Color.Green);
            SolidBrush FillRec = new SolidBrush(Color.Green);
            Graphics plot = CarPosition.CreateGraphics();

            float LenghX = ((CarPosition.Width / 2) - 7) / 10;
            float LenghY = ((CarPosition.Height / 2) - 7) / 10;

            if (_y >= 0)
            {
                Rectangle rect = new Rectangle((CarPosition.Width / 2 + _x *(int) LenghX), (CarPosition.Height / 2 - _y * (int) LenghY) - (int)LenghY, CarPosition.Width / 20 - 1, CarPosition.Height / 20 - 1);
                plot.DrawRectangle(DrawRec, rect);
                plot.FillRectangle(FillRec, rect);
            }
            else
            {
                Rectangle rect = new Rectangle((CarPosition.Width / 2 + _x * (int)LenghX), (CarPosition.Height / 2 - _y * (int)LenghY), CarPosition.Width / 20 - 1, CarPosition.Height / 20 - 1);
                plot.DrawRectangle(DrawRec, rect);
                plot.FillRectangle(FillRec, rect);
            }

            plot.Dispose();
        }

        private void DrawingLine(int _x, int _y) //drawing line betweem center and rectangle
        {
            Pen DrawLine = new Pen(Color.Yellow, 3);
            Graphics plot = CarPosition.CreateGraphics();

            float LenghX = ((CarPosition.Width / 2) - 7) / 10;
            float LenghY = ((CarPosition.Height / 2) - 7) / 10;

            if (_x >= 0)
                plot.DrawLine(DrawLine, CarPosition.Width / 2, CarPosition.Height / 2, (CarPosition.Width / 2 + _x * (int)LenghX), (CarPosition.Height / 2 - _y * (int)LenghY));
            else
                plot.DrawLine(DrawLine, CarPosition.Width / 2, CarPosition.Height / 2, (CarPosition.Width / 2 + _x * (int)LenghX) + (int)LenghX, (CarPosition.Height / 2 - _y * (int)LenghY));

            plot.Dispose();
        }
        private void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                /*string IP = IPBox.Text;
                string UserName = UsernameBox.Text;
                string Password = PasswordBox.Text;

                SshClient RPi = new SshClient(IP, UserName, Password);

                RPi.Connect();
                RPi.Disconnect();
                RPi.Dispose();*/

                panel1.Visible = true;
                DrawingPlot();
            }
            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            Close();
            /*panel1.Visible = false;
            AxisX.Clear();
            AxisY.Clear();
            CarPosition.Refresh();*/
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string SendValue = "s";
        private float previousX, previousY;

        private void button1_Click(object sender, EventArgs e)
        {
            float DeF_X = Convert.ToSingle(AxisX.Text);
            float DeF_Y = Convert.ToSingle(AxisY.Text);

            CarPosition.Refresh();
            SSHInfo.Clear();
            DrawingPlot();

            DrawingRectangle((int)Math.Floor(DeF_X / 10), (int)Math.Floor(DeF_Y / 10));
            DrawingLine((int)Math.Floor(DeF_X / 10), (int)Math.Floor(DeF_Y / 10));

            previousX = CarPosition.Width / 2;
            previousY = CarPosition.Height / 2;

            RPi = new SshClient(IPBox.Text, UsernameBox.Text, PasswordBox.Text);

            RPi.Connect();

            shell = RPi.CreateShellStream("shell", 100, 100, 100, 100, 1024);
            shell.Write("python3 /home/pi/Documents/fuzzy/fuzzy_script.py \n");
            shell.Write(Convert.ToString(DeF_X) + "\n");
            shell.Write(Convert.ToString(DeF_Y) + "\n");

            shell.Flush();

            bool fl = true;
            int counter = 0;

            while (fl)
            {
                if (shell != null && shell.DataAvailable)
                {
                    string[] info;
                    string data = shell.Read();
                   
                    if (counter > 56)
                    {
                        char[] deter = { '\r', '\n'};
                        info = data.Split(deter);
                        foreach (string s in info)
                        {
                            if (s == "")
                                continue;

                            SSHInfo.AppendText(s + "\r\n");

                            if (s == "DONE" || s == "Terminated")
                            {
                                fl = false;
                                shell.Close();
                                RPi.Disconnect();
                                break;
                            }

                            if (s[0] == 'D')
                            {
                                SensorReading.Clear();
                                SensorReading.ForeColor = Color.Black;
                                SensorReading.AppendText(s);
                            }
                            if (s[0] == 'P')
                            {
                                PWM.Clear();
                                PWM.AppendText(s);
                            }
                            if (s[0] == 'S')
                            {
                                Speed.Clear();
                                Speed.AppendText(s);
                            }
                            if (s[0] == 'T')
                            {
                                TraveledDistance.Clear();
                                TraveledDistance.AppendText(s);
                            }

                            if (s[0] == 'X')
                                drawRobotWay(Convert.ToSingle(s.Substring(4, s.IndexOf(':') - 4)), Convert.ToSingle(s.Substring(s.IndexOf(':') + 5)));
                        }
                    }
                    else
                    {
                        counter ++;
                        data = null;
                    }
                }
            }
        }

        private void drawRobotWay(float x, float y)//draw robot way
        {
            Pen Line = new Pen(Color.Blue, 2);
            Graphics plot = CarPosition.CreateGraphics();

            float LenghX = ((CarPosition.Width / 2) - 7) / 10;
            float LenghY = ((CarPosition.Height / 2) - 7) / 10;

            plot.DrawLine(Line,previousX, previousY, (CarPosition.Width / 2 + (x / 10 * LenghX)), (CarPosition.Height / 2 - (y / 10 * LenghY)));

            previousX = (CarPosition.Width / 2 + (x / 10 * LenghX));
            previousY = (CarPosition.Height / 2 - (y / 10 * LenghY));
        }

        private int counter = 0;

        private void ManualControl_MouseClick(object sender, MouseEventArgs e)
        {
            counter++;
        }

        private void ManualControl_Click(object sender, EventArgs e)
        {
            if (counter % 2 == 0)
            {
                WASDKeys.Visible = true;
                ManualDrive();
            }
            else
                WASDKeys.Visible = false;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (counter % 2 != 0)
            {
                if (e.KeyCode == Keys.W)
                {
                    Forward.BackColor = Color.Yellow;
                    SendValue = "w";
                }
                if (e.KeyCode == Keys.A)
                {
                    Left.BackColor = Color.Yellow;
                    SendValue = "a";
                }
                if (e.KeyCode == Keys.S)
                {
                    Reverse.BackColor = Color.Yellow;
                    SendValue = "r";
                }
                if (e.KeyCode == Keys.D)
                    Right.BackColor = Color.Yellow;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (counter % 2 != 0)
            {
                if (e.KeyCode == Keys.W)
                {
                    Forward.BackColor = SystemColors.Control;
                    SendValue = "s";
                }
                if (e.KeyCode == Keys.A)
                {
                    Left.BackColor = SystemColors.Control;
                    SendValue = "s";
                }
                if (e.KeyCode == Keys.S)
                {
                    Reverse.BackColor = SystemColors.Control;
                    SendValue = "s";
                }
                if (e.KeyCode == Keys.D)
                {
                    Right.BackColor = SystemColors.Control;
                    SendValue = "s";
                }
            }
        }
        private void ManualDrive()
        {
            //SshClient RPi = new SshClient(IPBox.Text, UsernameBox.Text, PasswordBox.Text);
        }
    }
}
