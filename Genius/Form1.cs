using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Media;

namespace Genius
{
    public partial class Form1 : Form
    {

        List<string> sequelColors = new List<string>();
        List<string> sequelPlayer = new List<string>();
        string[] colors = { "Red", "Yellow", "Blue", "Green" };
        bool canPlay = false;
        int points, indexList;
        string actualPlayer, actualColor;

        public Form1()
        {
            InitializeComponent();
        }

        private void SortColor() {

            Random rdn = new Random();
            actualColor = colors[rdn.Next(0, colors.Length)];
            sequelColors.Add(actualColor);

            foreach (var color in sequelColors) {

                Application.DoEvents();
                Thread.Sleep(250);
                ShowColor(color);
            }

            canPlay = true;
        
        }


        private void ShowColor(string actualColor) {

            switch (actualColor) {

                case "Red": pbRed.BackColor = Color.Red;
                    SystemSounds.Exclamation.Play();
                    Application.DoEvents();
                    Thread.Sleep(800);
                    pbRed.BackColor = Color.DarkRed;
                    break;

                case "Yellow": pbYellow.BackColor = Color.Yellow;
                    SystemSounds.Beep.Play();
                    Application.DoEvents();
                    Thread.Sleep(800);
                    pbYellow.BackColor = Color.Goldenrod;
                    break;

                case "Blue": pbBlue.BackColor = Color.Cyan;
                    SystemSounds.Asterisk.Play();
                    Application.DoEvents();
                    Thread.Sleep(800);
                    pbBlue.BackColor = Color.Blue;
                    break;

                case "Green": pbGreen.BackColor = Color.Lime;
                    SystemSounds.Hand.Play();
                    Application.DoEvents();
                    Thread.Sleep(800);
                    pbGreen.BackColor = Color.DarkGreen;
                    break;
            }
        
        }

        private void PbClick_Click(object sender, EventArgs e) {

            PictureBox pic = (PictureBox)sender;
            if (canPlay) {

                canPlay = false;
                actualPlayer = pic.Tag.ToString();
                sequelPlayer.Add(actualPlayer);
                ShowColor(actualPlayer);

                if (sequelPlayer[indexList] == sequelColors[indexList]) {

                    points++; lblPontos.Text = "Pontos: " + points.ToString();
                    indexList++;
                    CheckSequence();
                
                } else {

                    MessageBox.Show("Sequência incorreta. Final do jogo!");
                
                }
            
            }
        
        }

        private void CheckSequence() {

            if (indexList == sequelColors.Count) {

                indexList = 0; sequelPlayer.Clear(); SortColor();
            
            
            } else {

                canPlay = true;
            
            }
        
        }

        private void Menu_Click(object sender, EventArgs e) {

            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            switch (menu.Tag.ToString()) {
            
                case "Inicio":
                    points = 0; lblPontos.Text = "Pontos:"; sequelColors.Clear(); sequelPlayer.Clear(); canPlay = false; indexList = 0;
                    SortColor(); break;

                case "Sobre":
                    if (canPlay) {

                        string infos = "Jogo criado por: Mayara \n Nome do jogo: Genius \n Ano: 2017";
                        MessageBox.Show(infos, "Sobre");
                    }
                    break;

                case "Sair":
                    DialogResult msg = MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo);

                    if (msg == DialogResult.Yes) {

                        Application.Exit();
                    }

                    break;
            
            }
        
        }
    }
}
