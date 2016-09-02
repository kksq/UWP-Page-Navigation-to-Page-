using System;
using System.Linq;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using App1.Utils;

namespace App1.FrameManager
{
    public class MobileFrameManager : FrameManagerBase
    {
        public MobileFrameManager()
        {
            SystemNavigationManager.GetForCurrentView().BackRequested += FrameManager_BackRequested;
        }

        private bool _readyToExit;

        private void FrameManager_BackRequested(object sender, BackRequestedEventArgs e)
        {
            if (!RightFrameGoback())
            {
                if (DeviceInfoHelper.DeviceType == DeviceType.Mobile)
                {
                    if (CenterFrame.CanGoBack && CenterFrame.BackStack.Count > 0 &&
                        CenterFrame.BackStack.First().SourcePageType != CenterFrame.CurrentSourcePageType)
                    {
                        while (CenterFrame.BackStack.Count > 1)
                        {
                            CenterFrame.BackStack.RemoveAt(1);
                        }
                        CenterFrame.GoBack();
                        OnBack2MainView(null);
                    }
                    else
                    {
                        if (_readyToExit)
                        {
                            Application.Current.Exit();
                        }
                        else
                        {
//                            ToastHelper.ToastInfo("再按一次返回退出App", _globalInfoManager.IsNightMode, () =>
//                            {
//                                _readyToExit = false;
//                            });
//                            _readyToExit = true;
                        }
                    }
                }
            }
            e.Handled = true;
        }

        public override Frame RightFrame
        {
            get { return MainFrame; }
            set { throw new NotImplementedException("手机没有RightFrame"); }
        }
    }
}
