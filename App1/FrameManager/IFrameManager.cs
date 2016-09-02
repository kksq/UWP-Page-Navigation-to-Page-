using System;
using Windows.UI.Xaml.Controls;

namespace App1.FrameManager
{
    public interface IFrameManager
    {
        /// <summary>
        /// 右边的容器导航改变（改变返回键）改变布局（Adapter）
        /// </summary>
        event EventHandler<bool> RightFrameContentChange;

        /// <summary>
        /// 返回到主页面（通知UI改变ListView.SelectedIndex）
        /// </summary>
        event EventHandler<object> Back2MainView;

        Frame MainFrame { get; set; }
        Frame CenterFrame { get; set; }
        Frame RightFrame { get; set; }

        void RightFrameClearAndNav(Action<Frame> action);
        void RightFrameAndNav(Action<Frame> action);
        bool RightFrameGoback();
    }
}