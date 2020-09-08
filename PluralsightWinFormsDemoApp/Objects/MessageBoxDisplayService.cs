using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Objects
{
    public class MessageBoxDisplayService : IMessageBoxDisplayService
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }
    }

    public interface IMessageBoxDisplayService
    {
        void Show(string message);
    }
}
