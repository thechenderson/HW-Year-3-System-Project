using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Media;


namespace AlienSays
{
    public partial class alienSaysForm : Form
    {

        public alienSaysForm()
        {
            InitializeComponent();
        }

        bool gameInProgress = false; //If game is runnning = true
        List<int> colourList = new List<int>(); //Stores the pattern of colours generated
        Random generateColour = new Random(); //Used to generate a random int that represents the colour in the sequence.
        List<int> userGuess = new List<int>(); //Used to store each of users guesses as to what the pattern was.
        int score = 0; //Stores the current score
        int highScore;
        Thread th;

        private void alienSaysForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.Text = String.Empty;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            gameInProgress = true;
            score = 0;
            scoreLabel.Text = "Score: " + score;
            colourList.Clear();
            displaySequence();
        }

        private void displaySequence()
        {
            colourList.Add(generateColour.Next(0, 4)); //Add a new colour to the sequence
            userGuess.Clear(); //Clear the users guess

            for (int i = 0; i <= (colourList.Count - 1); i++) //For each of the items in the colour list flash the corresponding colour button
            {
                switch (colourList[i])
                {
                    case 0:
                        redButton.BackColor = Color.Red;
                        redButton.Update();
                        Thread.Sleep(500);
                        redButton.BackColor = Color.Maroon;
                        redButton.Update();
                        break;

                    case 1:
                        yellowButton.BackColor = Color.Yellow;
                        yellowButton.Update();
                        Thread.Sleep(500);
                        yellowButton.BackColor = Color.DarkGoldenrod;
                        yellowButton.Update();
                        break;

                    case 2:
                        greenButton.BackColor = Color.Green;
                        greenButton.Update();
                        Thread.Sleep(500);
                        greenButton.BackColor = Color.DarkGreen;
                        greenButton.Update();
                        break;

                    case 3:
                        blueButton.BackColor = Color.Blue;
                        blueButton.Update();
                        Thread.Sleep(500);
                        blueButton.BackColor = Color.MidnightBlue;
                        blueButton.Update();
                        break;
                }
            }
        }

        //Compares the users sequence to the correct sequence
        private void checkCorrect()
        {
            for(int i = 0; i <= (userGuess.Count - 1); i++)
            {
                if (userGuess[i] != colourList[i]) //Check if pattern list matches users pattern list.
                {
                    gameInProgress = false; //User has got the sequence wrong so game end

                    if (userGuess.Count>highScore) //check to see if the highscore was beaten
                    {
                        highScore = userGuess.Count(); //Set the new highscore
                        highScoreLabel.Text = $"Highscore: {highScore}"; //Display the highest score in the label.
                    }

                    MessageBox.Show("YOU FAIL!");
                break;
                }
            }
            if (gameInProgress)
            {
                score += 1;
                scoreLabel.Text = "Score: " + score;

                displaySequence();
            }
        }

        private void redButton_Click(object sender, EventArgs e)
        {
            if(gameInProgress == false || userGuess.Count == colourList.Count)
            {
                return;
            }
            else
            {
                userGuess.Add(0);
                redButton.BackColor = Color.Red;
                Thread.Sleep(200);
                redButton.BackColor = Color.Maroon;
                Thread.Sleep(200);

            }
            if (userGuess.Count == colourList.Count)
            {
                checkCorrect();
            }

        }

        private void yellowButton_Click(object sender, EventArgs e)
        {

            if (gameInProgress == false || userGuess.Count == colourList.Count)
            {
                return;
            }
            else
            {
                userGuess.Add(1);
                yellowButton.BackColor = Color.Yellow;
                Thread.Sleep(200);
                yellowButton.BackColor = Color.DarkGoldenrod;
                Thread.Sleep(200);

            }
            if (userGuess.Count == colourList.Count)
            {
                checkCorrect();
            }


        }

        private void greenButton_Click(object sender, EventArgs e)
        {

            if (gameInProgress == false || userGuess.Count == colourList.Count)
            {
                return;
            }
            else
            {
                userGuess.Add(2);
                greenButton.BackColor = Color.Green;
                Thread.Sleep(200);
                greenButton.BackColor = Color.DarkGreen;
                Thread.Sleep(200);

            }
            if (userGuess.Count == colourList.Count)
            {
                checkCorrect();
            }

        }

        private void blueButton_Click(object sender, EventArgs e)
        {

            if (gameInProgress == false || userGuess.Count == colourList.Count)
            {
                return;
            }
            else
            {
                userGuess.Add(3);
                blueButton.BackColor = Color.Blue;
                Thread.Sleep(200);
                blueButton.BackColor = Color.MidnightBlue;
                Thread.Sleep(200);
            }
            if(userGuess.Count == colourList.Count)
            {
                checkCorrect();
            }
            

        }

        private void leaderboardsButton_Click(object sender, EventArgs e)
        {
            if(gameInProgress == true)
            {
                return;
            }
            else
            {
                this.Close();
                th = new Thread(openForm);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
                (new Leaderboards()).Show();
            }
        }

        private void openForm(object obj)
        {
            Application.Run(new Leaderboards());
        }

    }
}