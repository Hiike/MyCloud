using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApplication1
{
    class Item
    {
        public long Bytes { get; set; }

        public string Modified { get; set; }

        public string Path { get; set; }

        public bool Is_Dir { get; set; }

        public bool Is_Deleted { get; set; }

        public string Size { get; set; }

        public string Root { get; set; }

        public string Icon { get; set; }

        public int Revision { get; set; }

        public string Name { get; set; }

        public string Extension { get; set; }
    }
}
