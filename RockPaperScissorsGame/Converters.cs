using System;
using System.Globalization;
using System.Windows.Data;

namespace RockPaperScissorsGame
{
    public class MessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string message = "";

            switch ((MessageCodes)value)
            {
                case MessageCodes.COMP_WIN:
                    message = "Computer won the round";
                    break;
                case MessageCodes.PLY_WIN:
                    message = "Player won the round";
                    break;
                case MessageCodes.AGAIN:
                    message = "Same choice, play again";
                    break;
                case MessageCodes.NONE:
                    message = "Please make a choice";
                    break;
                case MessageCodes.GAMEOVER_COM:
                    break;
                case MessageCodes.GAMEOVER_PLY:
                    message = " Player won. Gameover!";
                    break;
            }

            return message;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
