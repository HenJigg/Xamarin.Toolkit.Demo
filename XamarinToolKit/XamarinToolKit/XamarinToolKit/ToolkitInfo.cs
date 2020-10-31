using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XamarinToolKit.Model;

namespace XamarinToolKit
{
    public class ToolkitInfo
    {
        public ToolkitMaster master { get; set; }

        public ObservableCollection<ToolkitDetail> details { get; set; }
    }
}
