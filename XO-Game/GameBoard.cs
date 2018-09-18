using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XO_Game
{
    public partial class GameBoard : Form
    {

        bool ChFirst = true;
        
        public GameBoard()
        {
            InitializeComponent();
            

        }

        private bool DrawFigure(int x, int y, bool type = true) 
        {
            x = x / 120;
            y = y / 120;
            int index = x + 3 * y;

            if (Game.Grid[index] == 0 || !type)
            {
                Message.Text = String.Empty;


                
                    Graphics GF = GameField.CreateGraphics();
                    Pen p = new Pen(Color.Green, 8);
                    if (type)                                               //Рисуем крестик
                    {
                        GF.DrawLine(p, 120 * x + 5,
                                       120 * y + 5,
                                       120 * (x + 1) - 5,
                                       120 * (y + 1) - 5);

                        GF.DrawLine(p, 120 * (x + 1) - 5,
                                       120 * y + 5,
                                       120 * x + 5,
                                       120 * (y + 1) - 5);

                        Game.MakeMove(index);
                        
                    }
                    else                                                    //Рисуем нолик
                    {
                        p.Color = Color.Blue;
                        GF.DrawEllipse(p, 120 * x + 5,
                                          120 * y + 5,
                                          107,
                                          107);

                        
                    }

                



                return true;
            }
            else
            {
                Message.Text = "Клетка занята!";
                return false;
            }
        }

        private void GameField_Paint(object sender, PaintEventArgs e)
        {
            Graphics GF = GameField.CreateGraphics();

            Pen pencil = new Pen(Color.Gray, 2);

            GF.DrawLine(pencil, 120, 0, 120, 360);
            GF.DrawLine(pencil, 240, 0, 240, 360);
            GF.DrawLine(pencil, 0, 120, 360, 120);
            GF.DrawLine(pencil, 0, 240, 360, 240);
            if (!ChFirst)
            {
                Game.MakeMove(0);
                int choise = Game.Choice;
                int x = 60 + 120 * (choise % 3);
                int y = 60 + 120 * (choise / 3);
                DrawFigure(x, y, false);
            }
        }

        private void PlayerFirst_CheckedChanged(object sender, EventArgs e)
        {
            ChFirst = true;
        }

        private void ComputerFirst_CheckedChanged(object sender, EventArgs e)
        {
            ChFirst = false;
        }

        private void GameField_MouseClick(object sender, MouseEventArgs e)
        {
            bool st = false;
            if (Game.isStarted)
                st = DrawFigure(e.X, e.Y, true);
            if(Game.isStarted && st)
            {
                Game.MakeMove(0);
                int choise = Game.Choice;
                int x = 60 + 120*(choise % 3);
                int y = 60 + 120 * (choise / 3);
                DrawFigure(x, y, false);

            }

            if (!Game.isStarted) ShowWinner(Game.Winner);
            
        }

        private void GameBoard_Load(object sender, EventArgs e)
        {
            Message.Text = String.Empty;
            Game.Reset(ChFirst);

        }

        private void NewGame_Click(object sender, EventArgs e)
        {
            Game.Reset(ChFirst);

            Message.Text = String.Empty;
            GameField.Invalidate();

        }

        public void ShowWinner(int Winner)
        {
            
            Graphics GF = GameField.CreateGraphics();
            Pen p = new Pen(Color.Black, 7);
            
            switch (Game.WinLine())
            {
                case 1: GF.DrawLine(p, 4, 60, 356, 60); break;
                case 2: GF.DrawLine(p, 4, 180, 356, 180); break;
                case 3: GF.DrawLine(p, 4, 300, 356, 300); break;
                case 4: GF.DrawLine(p, 60, 4, 60, 356); break;
                case 5: GF.DrawLine(p, 180, 4, 180, 356); break;
                case 6: GF.DrawLine(p, 300, 4, 300, 356); break;
                case 7: GF.DrawLine(p, 4, 4, 352, 350); break;
                case 8: GF.DrawLine(p, 352, 4, 4, 350); break;
            }
            
            if (Winner == 1) Message.Text = "Вы победили!";
            else if (Winner == 2) Message.Text = "Вы проиграли!";
            else Message.Text = "НИЧЬЯ!";
        }

       
    }
    
}
