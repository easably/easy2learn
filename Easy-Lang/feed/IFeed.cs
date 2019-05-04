using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace f.feed
{
    public interface IFeed
    {
        bool IsInited { set; get; }
        void Refresh();
    }
}
