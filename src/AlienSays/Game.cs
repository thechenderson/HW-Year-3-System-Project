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

        Leaderboards leaderboard;

        public alienSaysForm(Leaderboards leaderboard)
        {
            InitializeComponent();
            this.leaderboard = leaderboard;

        }



        bool gameInProgress = false; //If game is runnning = true
        List<int> colourList = new List<int>(); //Stores the pattern of colours generated
        Random generateColour = new Random(); //Used to generate a random int that represents the colour in the sequence.
        List<int> userGuess = new List<int>(); //Used to store each of users guesses as to what the pattern was.
        int score = 0; //Stores the current score

        int[] highScores = new int[4]; //Array to store top 5 high scores
        string[] highScoreNames = new string[4]; //Array to store names of highest scorers.



        private void alienSaysForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.Text = String.Empty;

            string fileRead;

            System.IO.StreamReader scoreFile = new System.IO.StreamReader(@"..\..\..\..\src\AlienSays\Resources\highScoresValue.txt");
            System.IO.StreamReader nameFile = new System.IO.StreamReader(@"..\..\..\..\src\AlienSays\Resources\highScoresName.txt");

            int fileReadToInt;


            for (int i = 0; i <= highScores.Count(); i++) //For each item in the high scores array (5 items) populate with high scores from the text file on game start
            {
                while ((fileRead = scoreFile.ReadLine()) != null) //While there is still a line in the scores file
                {
                    Int32.TryParse(fileRead, out fileReadToInt);
                    highScores[i] = fileReadToInt; //Populate the scores array
                }
                while ((fileRead = nameFile.ReadLine()) != null) //While there is still a line in the names file
                {
                    highScoreNames[i] = fileRead; //Populate the names array
                }
            }

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
                        redButton.BackgroundImage = Properties.Resources.redButtonOn;
                        redButton.Update();
                        Thread.Sleep(250);
                        redButton.BackgroundImage = Properties.Resources.redButtonOff;
                        redButton.Update();
                        Thread.Sleep(250);
                        break;

                    case 1:
                        yellowButton.BackgroundImage = Properties.Resources.yellowButtonOn;
                        yellowButton.Update();
                        Thread.Sleep(250);
                        yellowButton.BackgroundImage = Properties.Resources.yellowButtonOff;
                        yellowButton.Update();
                        Thread.Sleep(250);
                        break;

                    case 2:
                        greenButton.BackgroundImage = Properties.Resources.greenButtonOn;
                        greenButton.Update();
                        Thread.Sleep(250);
                        greenButton.BackgroundImage = Properties.Resources.greenButtonOff;
                        greenButton.Update();
                        Thread.Sleep(250);
                        break;

                    case 3:
                        blueButton.BackgroundImage = Properties.Resources.blueButtonOn;
                        blueButton.Update();
                        Thread.Sleep(250);
                        blueButton.BackgroundImage = Properties.Resources.blueButtonOff;
                        blueButton.Update();
                        Thread.Sleep(250);
                        break;
                }
            }
        }

        //Compares the users sequence to the correct sequence
        private void checkCorrect()
        {
            for(int i = 0; i < (userGuess.Count); i++) //For each guess the user has made so far
            {
                if (userGuess[i] != colourList[i]) //Check if pattern list matches users pattern list.
                {
                    gameInProgress = false; //User has got the sequence wrong so game end


                    for (int j = 3; j < highScores.Count(); j--) //For each of the currently available high scores
                    {
                        if(userGuess.Count() > highScores[j]) //If current score is greater than the current high score in the array add new high score to the array 
                        {
                            highScores[j] = userGuess.Count();
                           // highScoreNames[j] = 
                            /*
                             *How are names to be set using card reader or user enters name.
                            */
                        }
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
                redButton.BackgroundImage = Properties.Resources.redButtonOn;
                redButton.Update();
                Thread.Sleep(100);
                redButton.BackgroundImage = Properties.Resources.redButtonOff;
                redButton.Update();
                Thread.Sleep(100);

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
                yellowButton.BackgroundImage = Properties.Resources.yellowButtonOn;
                yellowButton.Update();
                Thread.Sleep(100);
                yellowButton.BackgroundImage = Properties.Resources.yellowButtonOff;
                yellowButton.Update();
                Thread.Sleep(100);

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
                greenButton.BackgroundImage = Properties.Resources.greenButtonOn;
                greenButton.Update();
                Thread.Sleep(100);
                greenButton.BackgroundImage = Properties.Resources.greenButtonOff;
                greenButton.Update();
                Thread.Sleep(100);

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
                blueButton.BackgroundImage = Properties.Resources.blueButtonOn;
                blueButton.Update();
                Thread.Sleep(100);
                blueButton.BackgroundImage = Properties.Resources.blueButtonOff;
                blueButton.Update();
                Thread.Sleep(100);
            }
            if(userGuess.Count == colourList.Count)
            {
                checkCorrect();
            }
            

        }

        private void leaderboardsButton_Click(object sender, EventArgs e)
        {
            if (gameInProgress == true)
            {
                return;
            }
            else
            {
                leaderboard.Show();
            }
        }

    }
}