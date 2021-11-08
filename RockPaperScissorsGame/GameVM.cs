using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RockPaperScissorsGame
{
    enum MessageCodes
    {
        NO_VALUES,
        COMP_WIN,
        PLY_WIN,
        AGAIN,
        GAMEOVER_COM,
        GAMEOVER_PLY,
        NONE
    }
    class GameVM : INotifyPropertyChanged
    {
        enum compChoice
        {
            Rock = 1,
            Paper,
            Scissors
        }

        int round = 3;
        #region Properties
        private int scoreComputer = 0;
        public int ScoreComputer
        {
            get { return scoreComputer; }
            set { scoreComputer = value; notifyChange(); }
        }

        private int scorePlayer = 0;
        public int ScorePlayer
        {
            get { return scorePlayer; }
            set { scorePlayer = value; notifyChange(); }
        }
        private string imagePath = "";
        public string ImagePath
        {
            get { return imagePath; }
            set { imagePath = value; notifyChange(); }
        }
        private MessageCodes messageCode;
        public MessageCodes MessageCode
        {
            get { return messageCode; }
            set { messageCode = value; notifyChange(); }
        }
        #endregion
        #region Computer Choices
        Random random = new Random();
        string computerChoice = "";
        public void rndNumber()
        {
            compChoice RandomChoices = (compChoice)random.Next(1, 4);

            switch (RandomChoices)
            {
                case compChoice.Rock:
                    ImagePath = getImageBitmap(RandomChoices.ToString());
                    computerChoice = "Rock";
                    break;
                case compChoice.Paper:
                    ImagePath = getImageBitmap(RandomChoices.ToString());
                    computerChoice = "Paper";
                    break;
                case compChoice.Scissors:
                    ImagePath = getImageBitmap(RandomChoices.ToString());
                    computerChoice = "Scissors";
                    break;
                default:
                    break;
            }
        }
        const string ImgExtension = ".bmp";
        const string URIPrefix = "Images/";
        public string getImageBitmap(string choiceImage)
        {
            return $"{URIPrefix}{choiceImage}{ImgExtension}";
        }
        #endregion
        #region Player Choices Methods 
        public string playerChoice = "";
        Boolean gameover = false;
        public void gameWinner()
        {
            if (gameover != true)
            {
                if (computerChoice == "Rock" && playerChoice == "Scissors")

                {
                    ScoreComputer += 1;
                    round -= 3;
                    MessageCode = MessageCodes.COMP_WIN;

                }
                else if (computerChoice == "Scissors" && playerChoice == "Paper")
                {
                    ScoreComputer += 1;
                    round -= 1;
                    MessageCode = MessageCodes.COMP_WIN;

                }
                else if (computerChoice == "Paper" && playerChoice == "Rock")
                {
                    ScoreComputer += 1;
                    round -= 1;
                    MessageCode = MessageCodes.COMP_WIN;

                }
                if (playerChoice == "Rock" && computerChoice == "Scissors")
                {
                    ScorePlayer += 1;
                    round -= 1;
                    MessageCode = MessageCodes.PLY_WIN;

                }
                else if (playerChoice == "Scissors" && computerChoice == "Paper")
                {
                    ScorePlayer += 1;
                    round -= 1;
                    MessageCode = MessageCodes.PLY_WIN;

                }
                else if (playerChoice == "Paper" && computerChoice == "Rock")
                {
                    ScorePlayer += 1;
                    round -= 1;
                    MessageCode = MessageCodes.PLY_WIN;

                }
                else if (playerChoice == computerChoice)
                {
                    rndNumber();
                    MessageCode = MessageCodes.AGAIN;
                }
                else if (playerChoice == "")
                {
                    MessageCode = MessageCodes.NONE;
                    rndNumber();
                }
                rndNumber();
                if (round <= 0)
                {
                    gameover = true;
                    if (ScorePlayer > ScoreComputer)
                    {
                        MessageCode = MessageCodes.GAMEOVER_COM;
                    }
                    else if (ScorePlayer < ScoreComputer)
                    {
                        MessageCode = MessageCodes.GAMEOVER_PLY;
                    }
                }
            }         
        }
        public void Clear()
        {
            ScorePlayer = 0;
            ScoreComputer = 0;
            rndNumber();
            MessageCode = MessageCodes.NO_VALUES;
            gameover = false;
            round = 3;
        }
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void notifyChange([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
