using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluralsightWinFormsDemoApp.Properties;

namespace PluralsightWinFormsDemoApp.Objects
{
    public interface ISettingsService
    {
        bool FirstRun { get; set; }
        void Save();
    }

    internal class SettingsService : ISettingsService
    {
        public bool FirstRun
        {
            get => Settings.Default.FirstRun;
            set => Settings.Default.FirstRun = value;
        }

        public void Save()
        {
            Settings.Default.Save();
        }
    }


}
