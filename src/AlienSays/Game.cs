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
using System.IO;

namespace AlienSays
{
    public partial class alienSaysForm : Form
    {
        const int START = 1;
        const int EXIT = 2;
        const int FR = 3;
        const int ENG = 4;


        bool inGame = false;
        bool french = false;
        int selected_button = 1;

        bool gameInProgress = false; //If game is runnning = true
        List<int> colourList = new List<int>(); //Stores the pattern of colours generated
        Random generateColour = new Random(); //Used to generate a random int that represents the colour in the sequence.
        List<int> userGuess = new List<int>(); //Used to store each of users guesses as to what the pattern was.
        int score = 0; //Stores the current score

        List<int> highScores = new List<int>();
        List<string> highScoreNames = new List<string>();

        string currentUserName;

        public alienSaysForm(int Scr)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.Manual;
            this.Location = Screen.AllScreens[Scr].WorkingArea.Location;
            int h = Screen.AllScreens[Scr].Bounds.Height;
            int w = Screen.AllScreens[Scr].Bounds.Width;
            this.Size = new Size(w, h);
            startButton.FlatAppearance.BorderSize = 5;
            
        }

        private void alienSaysForm_Load(object sender, EventArgs e)
        {
            highScores.Clear();
            highScoreNames.Clear();
            //this.WindowState = FormWindowState.Maximized;
            this.ControlBox = false;
            this.Text = String.Empty;


            readHighScoreFiles(highScores, highScoreNames);
        }

        public void set_inGame(bool inGame)
        {
            this.inGame = inGame;
        }

        public bool get_inGame()
        {
            return inGame;
        }

        /*
         * Read saved high scores and names from text files and set labels to match
         */
        private void readHighScoreFiles(List<int> highScoreList, List<string> highScoreNames)
        {

            int fileReadToInt;

            var readScoresStream = new FileStream(@"..\..\..\..\src\AlienSays\Resources\highScoresValue.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            var readNamesStream = new FileStream(@"..\..\..\..\src\AlienSays\Resources\highScoresName.txt", FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            var readScores = new System.IO.StreamReader(readScoresStream);
            var readNames = new System.IO.StreamReader(readNamesStream);


            string scoreLineRead;
            string nameLineRead;



            for (int i = 0; i <= highScores.Count(); i++) //For each item in the high scores array (5 items) populate with high scores from the text file on game start
            {
                while ((scoreLineRead = readScores.ReadLine()) != null) //While there is still a line in the scores file
                {
                    Int32.TryParse(scoreLineRead, out fileReadToInt);
                    highScores.Add(fileReadToInt); //Populate the scores array
                }



                while ((nameLineRead = readNames.ReadLine()) != null) //While there is still a line in the names file
                {
                    highScoreNames.Add(nameLineRead); //Populate the names array
                }
            }

            score1Label.Text = highScores[0].ToString();
            score2Label.Text = highScores[1].ToString();
            score3Label.Text = highScores[2].ToString();
            score4Label.Text = highScores[3].ToString();
            score5Label.Text = highScores[4].ToString();

            name1Label.Text = highScoreNames[0];
            name2Label.Text = highScoreNames[1];
            name3Label.Text = highScoreNames[2];
            name4Label.Text = highScoreNames[3];
            name5Label.Text = highScoreNames[4];

        }

        /*
         * Adds a new item to the array that stores the sequence and displays the sequence again with the added colour
         */
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

        /*
         * Compares the users sequence to the correct sequence
         */
        private void checkCorrect()
        {
            for(int i = 0; i < (userGuess.Count()); i++) //For each guess the user has made so far
            {
                if (userGuess[i] != colourList[i]) //Check if pattern list matches users pattern list.
                {
                    gameInProgress = false; //User has got the sequence wrong so game ends
                    updateHighScores(highScores, highScoreNames, (userGuess.Count()));
                    break;
                }
            }
            if (gameInProgress)
            {
                score += 1;
                currentScoreLabel.Text = "Score: " + score;
                displaySequence();
            }
        }

        // Button Presses Start --------------------------------------------------------------------------------------------------------
        private void startButton_Click(object sender, EventArgs e)
        {
            gameInProgress = true;
            score = 0;
            currentScoreLabel.Text = "Score: " + score;
            colourList.Clear();
            displaySequence();
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
        //Button Presses End --------------------------------------------------------------------------------------------------------

        /*
         * Function that updates the high scores and names to match the users current score, placing them on the leaderboard appropriately
         */
        private void updateHighScores(List<int> scoreList, List<string> nameList, int currentScore)
        {

            for (int i = 0; i <= 4; i++)
            {
                if (currentScore > scoreList[i])
                {

                    scoreList.Insert(i, currentScore - 1);

                    set_userid(currentUserName);

                    nameList.Insert(i, currentUserName);/////////////////////////////////////////////////////////




                    score1Label.Text = highScores[0].ToString();
                    score2Label.Text = highScores[1].ToString();
                    score3Label.Text = highScores[2].ToString();
                    score4Label.Text = highScores[3].ToString();
                    score5Label.Text = highScores[4].ToString();

                    name1Label.Text = highScoreNames[0];
                    name2Label.Text = highScoreNames[1];
                    name3Label.Text = highScoreNames[2];
                    name4Label.Text = highScoreNames[3];
                    name5Label.Text = highScoreNames[4];

                    break;
                }
            }
        }

        /*
         * Function to write scores and names from their respective arrays into the text files stored on the system
         */
        private void writeTextFiles()
        {
            File.WriteAllText("..\\..\\..\\..\\src\\AlienSays\\Resources\\highScoresValue.txt", String.Empty); //Empty scores file
            File.WriteAllText("..\\..\\..\\..\\src\\AlienSays\\Resources\\highScoresName.txt", String.Empty); //Empty names file

            Console.WriteLine("TEXT FILES ARE EMPTIED");

            var writeScoresStream = new FileStream(@"..\..\..\..\src\AlienSays\Resources\highScoresValue.txt", FileMode.Append, FileAccess.Write, FileShare.Read);
            var writeNamesStream = new FileStream(@"..\..\..\..\src\AlienSays\Resources\highScoresName.txt", FileMode.Append, FileAccess.Write, FileShare.Read);

            var writeScores = new System.IO.StreamWriter(writeScoresStream);
            var writeNames = new System.IO.StreamWriter(writeNamesStream);

            for (int i = 0; i <= 4; i++)
            {
                Console.WriteLine(highScores[i]);
                writeScores.WriteLine(highScores[i]);
                writeScores.Flush();
                writeNames.WriteLine(highScoreNames[i]);
                writeNames.Flush();
            }
            writeScores.Close();
            writeNames.Close();
        }

        private void exit_button_Click(object sender, EventArgs e)
        {

            writeTextFiles();

            inGame = false; //No longer in the game
            this.Hide(); //Hide current form
            
        }

        public void white_click()
        {
            switch (selected_button)
            {
                case START:
                    startButton.PerformClick();
                    break;
                case EXIT:
                    exit_button.PerformClick();
                    break;
                case FR:
                    fr_button.PerformClick();
                    break;
                case ENG:
                    eng_buttton.PerformClick();
                    break;
            }
        }

        public void black_click()
        {
            selected_button += 1;
            switch (selected_button)
            {
                case START:
                    eng_buttton.FlatAppearance.BorderSize = 0;
                    startButton.FlatAppearance.BorderSize = 5;
                    break;
                case EXIT:
                    startButton.FlatAppearance.BorderSize = 0;
                    exit_button.FlatAppearance.BorderSize = 5;
                    break;
                case FR:
                    exit_button.FlatAppearance.BorderSize = 0;
                    fr_button.FlatAppearance.BorderSize = 5;
                    break;
                case ENG:
                    fr_button.FlatAppearance.BorderSize = 0;
                    eng_buttton.FlatAppearance.BorderSize = 5;
                    break;
                case 5:
                    eng_buttton.FlatAppearance.BorderSize = 0;
                    startButton.FlatAppearance.BorderSize = 5;
                    selected_button = START;
                    break;
            }
        }

        public void blue_click()
        {
            blueButton.PerformClick();
        }
        public void green_click()
        {
            greenButton.PerformClick();
        }
        public void yellow_click()
        {
            yellowButton.PerformClick();
        }
        public void red_click()
        {
            redButton.PerformClick();
        }

        private void fr_button_Click(object sender, EventArgs e)
        {
            french = true;
            redButton.Text = "ROUGE";
            yellowButton.Text = "JAUNE";
            greenButton.Text = "VERT";
            blueButton.Text = "BLEU";
            startButton.Text = "JOUER";
            exit_button.Text = "RETOUR";
            rankLabel.Text = "RANG";
            nameLabel.Text = "NOM";
            label1.Text = "Alien à dit...";
            
        }

        private void eng_buttton_Click(object sender, EventArgs e)
        {
            french = false;
            redButton.Text = "RED";
            yellowButton.Text = "YELLOW";
            greenButton.Text = "GREEN";
            blueButton.Text = "BLUE";
            startButton.Text = "START";
            exit_button.Text = "EXIT";
            rankLabel.Text = "RANK";
            nameLabel.Text = "NAME";
            label1.Text = "Alien says...";
        }

        public void set_french(bool french)
        {

            if (french)
            {
                this.french = true;
                redButton.Text = "ROUGE";
                yellowButton.Text = "JAUNE";
                greenButton.Text = "VERT";
                blueButton.Text = "BLEU";
                startButton.Text = "JOUER";
                exit_button.Text = "RETOUR";
                rankLabel.Text = "RANG";
                nameLabel.Text = "NOM";
                label1.Text = "Alien à dit...";
            }
            else
            {
                this.french = false;
                redButton.Text = "RED";
                yellowButton.Text = "YELLOW";
                greenButton.Text = "GREEN";
                blueButton.Text = "BLUE";
                startButton.Text = "START";
                exit_button.Text = "EXIT";
                rankLabel.Text = "RANK";
                nameLabel.Text = "NAME";
                label1.Text = "Alien says...";
            }
        }
        public bool get_french()
        {
            return french;
        }

        public void set_userid(string userID)
        {
            currentUserName = userID;    
        }

    }
}