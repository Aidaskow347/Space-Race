using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Space_Race
{
    public partial class Form1 : Form
    {
        //region for variables

        #region Variables

        //global player speed
        int player1Speed = 6;
        int player2Speed = 6;

        //player score keeper

        int player1Score = 0;
        int player2Score = 0;

        //lists for meteor speed and meteors

        List<int> meteorXSpeed = new List<int>();
        List<int> meteorYSpeed = new List<int>();

        List<int> meteorSize = new List<int>();

        //random variable and a integer to save the value
        int randValue = 0;

        Random ranGen = new Random();

        // bools for button pressing W & S for player 1, Up Arrow and Down Arrow for Player 2

        bool wDown = false;
        bool sDown = false;

        bool downDown = false;
        bool upDown = false;
        bool p1Boost = false;
        bool p2Boost = false;

        //stopwatches for thingies

        Stopwatch dashTimerP1 = new Stopwatch();
        Stopwatch dashTimerP2 = new Stopwatch();

        Stopwatch stopWatch = new Stopwatch();

        //soundplayer
        SoundPlayer boost1 = new SoundPlayer(Properties.Resources.boost);
        SoundPlayer boost2 = new SoundPlayer(Properties.Resources.boost);
        SoundPlayer hit = new SoundPlayer(Properties.Resources.hit);
        SoundPlayer score = new SoundPlayer(Properties.Resources.score);

        #endregion

        //region for declaring rectangles

        #region Rectangles

        // player 1

        Rectangle player1 = new Rectangle(175, 675, 20, 50);

        // player 2

        Rectangle player2 = new Rectangle(475, 675, 20, 50);

        // lists
        List<Rectangle> meteorXList = new List<Rectangle>();
        List<Rectangle> meteorYList = new List<Rectangle>();

        // drawing brushes

        SolidBrush meteorBrush = new SolidBrush(Color.White);

        SolidBrush player1Brush = new SolidBrush(Color.DodgerBlue);

        SolidBrush player2Brush = new SolidBrush(Color.Red);

        SolidBrush lightGrayBrush = new SolidBrush(Color.LightGray);

        SolidBrush redFlame = new SolidBrush(Color.Red);

        SolidBrush dashMeterP1 = new SolidBrush(Color.Purple);

        SolidBrush dashMeterP2 = new SolidBrush(Color.Blue);

        SolidBrush dashMeterInsideP1 = new SolidBrush(Color.DarkGreen);

        SolidBrush dashMeterInsideP2 = new SolidBrush(Color.DarkGreen);
        #endregion


        public Form1()
        {
            InitializeComponent();
        }

        // movememnt presses

        #region KeyPresses

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // switch case to check for up and down key presses on each player and
                // activate them while pressed

                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.Space:
                    if (gameTimer.Enabled == false)
                    {
                        gameStart();
                    }
                    break;
                case Keys.A:
                    p1Boost = true;
                    break;
                case Keys.Left:
                    p2Boost = true;
                    break;
                case Keys.Escape:

                    // close application if gametimer is deactivated

                    if (gameTimer.Enabled == false)
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.K:
                    if (gameTimer.Enabled == false)
                    {
                        
                        //display controls for player
                        player2Info.Text = "Player 2\n\n\n↑ = UP\n\n↓ = DOWN\n\n← = BOOST\n\nK = HIDE CONTROLS";
                        player1Info.Text = "Player 1\n\n\nW = UP\n\nS = DOWN\n\nA = BOOST\n\nESC = CLOSE GAME";
                        player2Info.ForeColor = Color.Red;
                        player1Info.ForeColor = Color.LightBlue;

                        if (player2Info.Visible == true)
                        {
                            hit.Play();
                            player2Info.Visible = false;
                            player1Info.Visible = false;
                        }
                        else
                        {
                            score.Play();
                            player2Info.Visible = true;
                            player1Info.Visible = true;
                        }
                    }
                    break;

            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                // switch case to check for up and down key presses movement on each player and
                // deactivate them while not active

                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.A:
                    p1Boost = false;
                    break;
                case Keys.Right:
                    p2Boost = false;
                    break;
            }
        }
        #endregion

        // code for what to do while game is in entry screen and end screen

        #region GameState Voids

        // void for game start

        private void gameStart()
        {
            //Reset scores

            player1Score = 0;
            player2Score = 0;
            player1ScoreLabel.Text = "0";
            player2ScoreLabel.Text = "0";
            // start game timer and stopwatches

            gameTimer.Start();
            stopWatch.Restart();

            dashTimerP1.Start();
            dashTimerP2.Start();

            //hidelabels, clear stopwatch label

            gameLabel.Visible = false;
            infoLabel.Visible = false;
            stopWatchLabel.Text = "";
        }

        //void for game end
        private void gameEnd()
        {
            // stop game and reset timers

            gameTimer.Stop();
            stopWatch.Stop();

            // reset player location

            player1.Y = 675;
            player2.Y = 675;

            // clear all lists

            meteorXList.Clear();
            meteorYList.Clear();
            meteorXSpeed.Clear();
            meteorYSpeed.Clear();

            //declare winner
            if (player1Score > player2Score)
            {
                gameLabel.Text = "Blue Wins!";

            }
            else if (player1Score == player2Score)
            {
                gameLabel.Text = "Draw!";
            }
            else
            {
                gameLabel.Text = "Red Wins!";
            }

            // make the labels visible again

            gameLabel.Visible = true;
            infoLabel.Visible = true;
        }

        #endregion

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //disable information if game is started
            player1Info.Visible = false;
            player2Info.Visible = false;
            //dash 

            #region Dash Timing

            if (dashTimerP1.ElapsedMilliseconds <= 5000)
            {
                p1Boost = false;
            }
            else
            {
                if (p1Boost == true)
                {
                    SoundPlayer soundPlayer1 = new SoundPlayer(Properties.Resources.boost);
                    soundPlayer1.Play();
                    dashTimerP1.Reset();
                    player1Speed = 15;
                    dashTimerP1.Start();
                }
            }
            if (dashTimerP2.ElapsedMilliseconds <= 5000)
            {
                p2Boost = false;
            }
            else
            {
                if (p2Boost == true)
                {
                    SoundPlayer soundPlayer2 = new SoundPlayer(Properties.Resources.boost);
                    soundPlayer2.Play();
                    dashTimerP2.Reset();
                    player2Speed = 15;
                    dashTimerP2.Start();
                }
            }

            // check if a players dash has been going for three seconds or more
            if (player1Speed > 10)
            {
                if (dashTimerP1.ElapsedMilliseconds >= 1500)
                {
                    player1Speed = 6;
                    p1Boost = false;
                    dashTimerP1.Reset();
                    dashTimerP1.Start();
                }
            }
            if (player2Speed > 10)
            {
                if (dashTimerP2.ElapsedMilliseconds >= 1500)
                {
                    player2Speed = 6;
                    p2Boost = false;
                    dashTimerP2.Reset();
                    dashTimerP2.Start();
                }
            }
            #endregion

            //start stopwatch and have it either whoever has the highest amount of points
            //towards the end or first to 3
            stopWatch.Start();

            stopWatchLabel.Text = stopWatch.Elapsed.ToString(@"ss");

            //code for moving the player upwards and downwards

            #region Player Movement

            //player 1

            if (wDown == true)
            {
                player1.Y -= player1Speed;
            }

            if (sDown == true && player1.Y < (this.Height - player1.Height))
            {
                player1.Y += player1Speed;
            }

            //player 2

            if (upDown == true && player2.Y > -30)
            {
                player2.Y -= player2Speed;
            }

            if (downDown == true && player2.Y < (this.Height - player1.Height))
            {
                player2.Y += player2Speed;
            }

            #endregion

            // code for scoring a point

            #region Scoring
            // if player hits the top of the screen

            if (player1.Y <= -45)
            {
                score.Play();
                player1.Y = this.Height + 15;
                player1Score++;
                player1ScoreLabel.Text = $"{player1Score}";
            }

            if (player2.Y <= -45)
            {
                score.Play();
                player2.Y = this.Height + 15;
                player2Score++;
                player2ScoreLabel.Text = $"{player2Score}";
            }

            // if player is off screen, return them to the screen

            if (player1.Y <= 0)
            {
                player1.Y -= 4;
            }
            if (player1.Y >= this.Height - 45)
            {
                player1.Y -= 4;
            }

            // same code but for player 2

            if (player2.Y <= 0)
            {
                player2.Y -= 4;
            }
            if (player2.Y >= this.Height - 45)
            {
                player2.Y -= 4;
            }
            #endregion

            // code for creating meteors

            #region Meteors

            //Left Side Meteors (X)
            //generate the length of the meteor

            int randBallValueX = ranGen.Next(5, 15);

            for (int i = 0; i < meteorXList.Count; i++)
            {
                // create a variable that moves the meteoroid

                int x = meteorXList[i].X + meteorXSpeed[i];

                //create new meteor

                meteorXList[i] = new Rectangle(x, meteorXList[i].Y, meteorXList[i].Width, 2);


            }
            int ballRandomX = ranGen.Next(0, 101);

            if (ballRandomX < 10)
            {
                //randomly generate a Y value to spawn the meteor on
                randValue = ranGen.Next(10, this.Height - 200);

                // new meteor rectangle
                Rectangle meteorX = new Rectangle(0, randValue, randBallValueX, 2);

                // add meteor to list
                meteorXList.Add(meteorX);

                // add speed to corresponding meteor
                meteorXSpeed.Add(ranGen.Next(3, 8));
            }

            //Right Side Meteors (Y)

            //generate the length of the meteor

            int randBallValueY = ranGen.Next(5, 15);


            for (int i = 0; i < meteorYList.Count; i++)
            {
                // create a variable that moves the meteoroid

                int x = meteorYList[i].X + meteorYSpeed[i];

                //create new meteor

                meteorYList[i] = new Rectangle(x, meteorYList[i].Y, meteorYList[i].Width, 2);


            }

            int ballRandomY = ranGen.Next(0, 101);

            if (ballRandomY < 10)
            {
                //randomly generate a Y value to spawn the meteor on

                randValue = ranGen.Next(10, this.Height - 200);

                //create meteor
                Rectangle meteorY = new Rectangle(this.Width, randValue, randBallValueY, 2);

                //add the new rectangle to the meteor list
                meteorYList.Add(meteorY);

                // initialize a speed for the corresponding meteor
                meteorYSpeed.Add(ranGen.Next(-8, -3));
            }


            //when meteor leaves screen XList

            for (int i = 0; i < meteorXList.Count; i++)
            {
                if (meteorXList[i].X >= this.Width)
                {
                    meteorXList.RemoveAt(i);
                    meteorXSpeed.RemoveAt(i);

                }
            }

            //when meteor leaves screen YList

            for (int i = 0; i < meteorYList.Count; i++)
            {
                if (meteorYList[i].X <= 0)
                {
                    meteorYList.RemoveAt(i);
                    meteorYSpeed.RemoveAt(i);

                }
            }

           


            // if player intersects with a meteor
            //X
            if (meteorXList.Count != 0)
            {
                for (int i = 0; i < meteorXList.Count; i++)
                {
                    
                    if (meteorXList[i].IntersectsWith(player1))
                    {
                        hit.Play();
                        player1.Y = 675;
                    }
                    if (meteorXList[i].IntersectsWith(player2))
                    {
                        hit.Play();
                        player2.Y = 675;
                    }
                }
            }
            //Y
            if (meteorYList.Count != 0)
            {
                for (int i = 0; i < meteorYList.Count; i++)
                {

                    if (meteorYList[i].IntersectsWith(player1))
                    {
                        hit.Play();
                        player1.Y = 675;
                    }
                    if (meteorYList[i].IntersectsWith(player2))
                    {
                        hit.Play();
                        player2.Y = 675;
                    }
                }
            }
            #endregion

            //game ending

            //if players reach a score of 5 

            if (player1Score == 5 || player2Score == 5)
            {
                gameEnd();
            }

            // if game has elapsed for a minute

            if (stopWatch.ElapsedMilliseconds > 60000)
            {
                gameEnd();
            }

            Refresh();
        }

        //paint method
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //code for drawing the rocketships

            #region RocketShips 

            // player 1

            // actual box around, commented out to have easy access to check for bugs

            //e.Graphics.FillRectangle(lightGrayBrush, player1);

            e.Graphics.FillRectangle(lightGrayBrush, player1.X + 3, player1.Y + 13, 14, 25);

            //top and bottom
            e.Graphics.FillPie(lightGrayBrush, player1.X, player1.Y - 20, 19, 40, 60, 60);

            e.Graphics.FillPie(lightGrayBrush, player1.X, player1.Y + 25, 19, 40, 170, 200);

            // windows
            e.Graphics.FillEllipse(player1Brush, player1.X + 5, player1.Y + 13, 9, 10);

            e.Graphics.FillEllipse(player1Brush, player1.X + 5, player1.Y + 26, 9, 10);

            // player 2

            // actual box around, commented out to have easy access to check for bugs

            //e.Graphics.FillRectangle(lightGrayBrush, player2);

            e.Graphics.FillRectangle(lightGrayBrush, player2.X + 3, player2.Y + 13, 14, 25);

            // top and bottom
            e.Graphics.FillPie(lightGrayBrush, player2.X, player2.Y - 20, 19, 40, 60, 60);

            e.Graphics.FillPie(lightGrayBrush, player2.X, player2.Y + 25, 19, 40, 170, 200);

            //windows
            e.Graphics.FillEllipse(player2Brush, player2.X + 5, player2.Y + 13, 9, 10);

            e.Graphics.FillEllipse(player2Brush, player2.X + 5, player2.Y + 26, 9, 10);
            #endregion

            // Draw a center line long enough to seperate the sides of the players (more viual than anything)

            e.Graphics.FillRectangle(meteorBrush, this.Width / 2 - 5, this.Height - 175, 5, 200);

            // drawing meteors

            //Left

            for (int i = 0; i < meteorXList.Count; i++)
            {
                e.Graphics.FillEllipse(meteorBrush, meteorXList[i]);
            }

            // Right

            for (int i = 0; i < meteorYList.Count; i++)
            {
                e.Graphics.FillEllipse(meteorBrush, meteorYList[i]);
            }

            //Drawing the Boosters Flames Code

            #region Boosting
            //player1 boosts
            int boostRand, boostRand2;
            if (player1Speed == 15)
            {
                for (int i = 0; i < 10; i++)
                {
                    boostRand = ranGen.Next(1, 5);

                    switch (boostRand)
                    {
                        case 1:
                            redFlame.Color = Color.White;
                            break;
                        case 2:
                            redFlame.Color = Color.Magenta;
                            break;
                        case 3:
                            redFlame.Color = Color.Orange;
                            break;
                        case 4:
                            redFlame.Color = Color.Red;
                            break;
                        case 5:
                            redFlame.Color = Color.GreenYellow;
                            break;
                    }
                    e.Graphics.FillEllipse(redFlame, player1.X - 1, player1.Y + player1.Height - 3, 5, 23);

                    e.Graphics.FillEllipse(redFlame, player1.X + player1.Width - 5, player1.Y + player1.Height - 3, 5, 23);
                }
            }

            //player2 boosts

            if (player2Speed == 15)
            {
                for (int i = 0; i < 10; i++)
                {
                    boostRand2 = ranGen.Next(1, 5);
                    switch (boostRand2)
                    {
                        case 1:
                            redFlame.Color = Color.White;
                            break;
                        case 2:
                            redFlame.Color = Color.Magenta;
                            break;
                        case 3:
                            redFlame.Color = Color.Orange;
                            break;
                        case 4:
                            redFlame.Color = Color.Red;
                            break;
                        case 5:
                            redFlame.Color = Color.GreenYellow;
                            break;
                    }
                    e.Graphics.FillEllipse(redFlame, player2.X - 1, player2.Y + player2.Height - 3, 5, 23);

                    e.Graphics.FillEllipse(redFlame, player2.X + player2.Width - 5, player2.Y + player2.Height - 3, 5, 23);

                }
            }
            #endregion

            //player boost meters

            //player 1

            //draw       dash border

            e.Graphics.FillRectangle(dashMeterP1, 0, this.Height - 125, 20, 150);

            //draw inside of dash border

            e.Graphics.FillRectangle(dashMeterInsideP1, 4, this.Height - 115, 11, 110);

            //player 2

            e.Graphics.FillRectangle(dashMeterP2, this.Width - 20, this.Height - 125, 20, 150);

            e.Graphics.FillRectangle(dashMeterInsideP2, this.Width - 15, this.Height - 115, 11, 110);
        }
    }
}
