namespace App1.Views
{
    public sealed partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void ListViewBase_OnItemClick(object sender, Windows.UI.Xaml.Controls.ItemClickEventArgs e)
        {
            App.FrameManager.RightFrameAndNav(frame =>
            {
                frame.Navigate(typeof (DetailView));
            });
        }
    }
}
