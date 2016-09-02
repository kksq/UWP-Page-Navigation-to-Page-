using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using App1.Annotations;

namespace App1.FrameManager
{
    public abstract class FrameManagerBase : INotifyPropertyChanged, IFrameManager
    {
        /// <summary>
        /// 右边的容器导航改变（改变返回键）改变布局（Adapter）
        /// </summary>
        public event EventHandler<bool> RightFrameContentChange;

        /// <summary>
        /// 返回到主页面（通知UI改变ListView.SelectedIndex）
        /// </summary>
        public event EventHandler<object> Back2MainView;

        public Frame MainFrame { get; set; }
        public Frame CenterFrame { get; set; }
        public abstract Frame RightFrame { get; set; }

        public void RightFrameClearAndNav(Action<Frame> action)
        {
            action(RightFrame);
            while (RightFrame.BackStack.Count > 1)
            {
                RightFrame.BackStack.RemoveAt(1);
            }


            RightFrameContentChange?.Invoke(this, true);
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        public void RightFrameAndNav(Action<Frame> action)
        {
            action(RightFrame);
            RightFrameContentChange?.Invoke(this, true);
            SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = AppViewBackButtonVisibility.Visible;
        }

        public bool RightFrameGoback()
        {
            if (RightFrame.CanGoBack)
            {
                RightFrame.GoBack();
                RightFrameContentChange?.Invoke(this, RightFrame.CanGoBack);
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = RightFrame.CanGoBack
                    ? AppViewBackButtonVisibility.Visible
                    : AppViewBackButtonVisibility.Collapsed;

                return true;
            }
            else
            {
                return false;
            }
        }


        #region EventInvoke

        protected virtual void OnRightFrameContentChange(bool e)
        {
            RightFrameContentChange?.Invoke(this, e);
        }

        protected virtual void OnBack2MainView(object e)
        {
            Back2MainView?.Invoke(this, e);
        }

        #endregion


        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
