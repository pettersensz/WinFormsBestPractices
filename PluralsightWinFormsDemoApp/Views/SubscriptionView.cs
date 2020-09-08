using System;
using System.Windows.Forms;

namespace PluralsightWinFormsDemoApp
{
    public partial class SubscriptionView : UserControl, ISubscriptionView
    {
        public SubscriptionView()
        {
            InitializeComponent();
            treeViewPodcasts.AfterSelect += (s, a) => OnSelectionChanged();
        }

        public TreeNode SelectedNode => treeViewPodcasts.SelectedNode;

        public void AddNode(TreeNode treeNode)
        {
            treeViewPodcasts.Nodes.Add(treeNode);
        }

        public void RemoveNode(string key)
        {
            var node = treeViewPodcasts.Nodes[key];
            treeViewPodcasts.Nodes.Remove(node);
        }

        public void SelectNode(string key)
        {
            treeViewPodcasts.SelectedNode = treeViewPodcasts.Nodes[key];
        }

        public event EventHandler SelectionChanged;
        public event EventHandler AddPodcastClicked
        {
            add => buttonAdd.Click += value;
            remove => buttonAdd.Click -= value;
        }
        public event EventHandler RemovePodcastClicked
        {
            add => buttonRemove.Click += value;
            remove => buttonRemove.Click -= value;
        }

        protected virtual void OnSelectionChanged()
        {
            var handler = SelectionChanged;
            handler?.Invoke(this,EventArgs.Empty);
        }


    }

    public interface ISubscriptionView
    {
        TreeNode SelectedNode { get; }
        void AddNode(TreeNode treeNode);
        void RemoveNode(string key);
        void SelectNode(string key);
        event EventHandler SelectionChanged;

        event EventHandler AddPodcastClicked;
        event EventHandler RemovePodcastClicked;
    }
}
