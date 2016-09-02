using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using App1.Utils;

namespace App1.Views
{
    public sealed partial class MainShellView
    {
        public MainShellView()
        {
            this.InitializeComponent();
            App.FrameManager.Back2MainView += FrameManager_Back2MainView;
        }

        private void FrameManager_Back2MainView(object sender, object e)
        {
            //返回到主页面，更新UI
            mainListView.SelectedIndex = 0;
        }

        private void mainListView_OnItemClick(object sender, ItemClickEventArgs e)
        {
            var headerInfo = (HeaderInfo)e.ClickedItem;
            switch (headerInfo.Title)
            {
                case "新闻":
                    App.FrameManager.CenterFrame.Navigate(typeof(MainView));
                    break;
                case "栏目":
                    App.FrameManager.CenterFrame.Navigate(typeof(CategoryView));
                    break;
                case "收藏":
                    break;
                case "推荐":
                    break;
                case "设置":
                    break;
            }
        }

        private void VisualStateGroup_OnCurrentStateChanged(object sender, VisualStateChangedEventArgs e)
        {
            if (DeviceInfoHelper.DeviceType == DeviceType.Desktop)
            {
                //从RightFrame返回MainShellView，加动画
                if (e.OldState == Show123 || e.OldState == Show3)
                {
                    if (e.NewState == Show12 || e.NewState == Show2)
                    {
                        var animation = new PopInThemeAnimation
                        {
                            FromHorizontalOffset = 0,
                            FromVerticalOffset = 100,
                            SpeedRatio = 0.5,
                        };
                        Storyboard.SetTarget(animation, centerPanel);
                        var sb = new Storyboard();
                        sb.Children.Add(animation);
                        sb.Begin();
                    }
                }
            }
        }

        private void RightFrame_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (App.FrameManager.RightFrame == null)
            {
                App.FrameManager.RightFrame = (Frame) sender;
                App.FrameManager.RightFrame.Navigate(typeof (PlaceholdView));
            }
        }

        private void CenterFrame_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (App.FrameManager.CenterFrame == null)
            {
                App.FrameManager.CenterFrame = (Frame)sender;
                App.FrameManager.CenterFrame.Navigate(typeof (MainView));
            }
        }
    }
}
