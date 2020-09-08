using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp.Objects
{
    public interface INewSubscriptionService
    {
        string GetSubscriptionUrl();
    }

    public class NewSubscriptionService : INewSubscriptionService
    {
        public string GetSubscriptionUrl()
        {
            var form = new NewPodcastForm();
            return form.ShowDialog() == DialogResult.OK ? form.PodcastUrl : null;
        }
    }
}
