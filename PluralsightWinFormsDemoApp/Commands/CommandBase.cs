using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Commands
{
    public abstract class CommandBase : IButtonCommand
    {
        private bool _isEnabled;
        private Image _icon;
        private string _toolTip;

        public event PropertyChangedEventHandler PropertyChanged;

        protected CommandBase()
        {
            _isEnabled = true;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void Execute();

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                if (_isEnabled != value) _isEnabled = value;
            }
        }
        public Image Icon { get; set; }

        public string ToolTip
        {
            get => _toolTip;
            set
            {
                if (_toolTip != value)
                {
                    _toolTip = value;
                    OnPropertyChanged("ToolTip");
                }
            }
        }
        public Keys ShortcutKey { get; set; }
    }
}
