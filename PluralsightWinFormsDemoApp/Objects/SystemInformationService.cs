using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Objects
{
    public interface ISystemInformationService
    {
        bool IsHighContrastColorScheme { get; }
    }

    public class SystemInformationService : ISystemInformationService
    {
        public bool IsHighContrastColorScheme => SystemInformation.HighContrast;
    }
}
