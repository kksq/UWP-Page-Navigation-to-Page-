using System.Collections.Generic;
using Windows.UI.Xaml.Controls;

namespace App1.Utils
{
    public class GlobalResources
    {
        public List<HeaderInfo> MainTitles => new List<HeaderInfo>
        {
            new HeaderInfo {SymbolIcon = Symbol.List, Title = "新闻"},
            new HeaderInfo {SymbolIcon = Symbol.AlignLeft, Title = "栏目"},
            new HeaderInfo {SymbolIcon = Symbol.Emoji2, Title = "收藏"},
            new HeaderInfo {SymbolIcon = Symbol.Link, Title = "推荐"},
            new HeaderInfo {SymbolIcon = Symbol.Setting, Title = "设置"},
        };
    }
}
