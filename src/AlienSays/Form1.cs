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

        private void alienSaysForm_Load(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            gameInProgress = true;
            score = 0;
            scoreLabel.Text = "Score: " + score;
            colourList.Clear();
            displaySequence();

            /*if (gameInProgress == true) //If game is already running start doesnt do anything
                return;
            else
            {
                gameInProgress = true;
                while (gameInProgress == true)
                {
                    displaySequence(); //Display the sequence of colours
                    checkCorrect(); //Compare the users guess to the correct pattern
                }
                MessageBox.Show("YOU FAILED!");

            }*/
        }

        private void displaySequence()
        {
            colourList.Add(generateColour.Next(0, 4)); //Add a new colour to the sequence
            userGuess.Clear();

            for (int i = 0; i <= (colourList.Count - 1); i++) //For each of the items in the colour list flash the corresponding colour button
            {
                switch (colourList[i])
                {
                    case 0:
                        redButton.BackColor = Color.Red;
                        Thread.Sleep(200);
                        redButton.BackColor = Color.Maroon;
                        MessageBox.Show("Red");
                        break;

                    case 1:
                        yellowButton.BackColor = Color.Yellow;
                        Thread.Sleep(200);
                        yellowButton.BackColor = Color.DarkGoldenrod;
                        MessageBox.Show("Yellow");
                        break;

                    case 2:
                        greenButton.BackColor = Color.Green;
                        Thread.Sleep(200);
                        greenButton.BackColor = Color.DarkGreen;
                        MessageBox.Show("Green");
                        break;

                    case 3:
                        blueButton.BackColor = Color.Blue;
                        Thread.Sleep(200);
                        blueButton.BackColor = Color.MidnightBlue;
                        MessageBox.Show("Blue");
                        break;
                }
            }
        }

        private void checkCorrect()
        {
            for(int i = 0; i <= (userGuess.Count - 1); i++)
            {
                if (userGuess[i] != colourList[i])
                {
                    gameInProgress = false;
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
            }
            if(userGuess.Count == colourList.Count)
            {
                checkCorrect();
            }
            

        }
    }
}