using Windows.ApplicationModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using App1.FrameManager;

namespace App1.Utils
{
    public enum AdaptiveType
    {
        Show2,
        Show12,
        Show123,
        Show3,
    }

    public class DeviceAdaptiveTrigger : StateTriggerBase
    {
        private const double minwidth = 800;
        private const double maxwidth = 1000;

        private readonly IFrameManager _frameManager;
        private bool rightFrameHasContent;

        public DeviceAdaptiveTrigger()
        {
            if (!DesignMode.DesignModeEnabled)
            {
                _frameManager = App.FrameManager;
                Window.Current.SizeChanged += Current_SizeChanged;
                _frameManager.RightFrameContentChange += _frameManager_RightFrameContentChange;
            }
            
        }

        private void _frameManager_RightFrameContentChange(object sender, bool e)
        {
            rightFrameHasContent = e;
            var adaptiveType = AdaptiveDevice(Window.Current.Bounds.Width);
            SetActive(adaptiveType == AdaptiveType);
        }


        private void Current_SizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
            var adaptiveType = AdaptiveDevice(e.Size.Width);
            SetActive(adaptiveType == AdaptiveType);
        }
        
        private AdaptiveType AdaptiveDevice(double width)
        {
            if (width > 0 && width <= minwidth)
            {
                if (rightFrameHasContent)
                {
                    return AdaptiveType.Show3;
                }
                else
                {
                    return AdaptiveType.Show2;
                }
            }
            else if (width > minwidth && width <= maxwidth)
            {
                if (rightFrameHasContent)
                {
                    return AdaptiveType.Show3;
                }
                else
                {
                    return AdaptiveType.Show12;
                }
            }
            else
            {
                return AdaptiveType.Show123;
            }
        }


        private AdaptiveType _adaptiveType;

        public AdaptiveType AdaptiveType
        {
            get { return _adaptiveType; }
            set
            {
                _adaptiveType = value;
                var device = AdaptiveDevice(Window.Current.Bounds.Width);
                SetActive(device == _adaptiveType);
            }
        }
    }
}
