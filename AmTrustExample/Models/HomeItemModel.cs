using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmTrustExample.Models
{
    public class HomeItemModel
    {
        public int HomeItemIndex { get; set; }
        public string ItemName { get; set; }

        public HomeItemModel(int index, string name)
        {
            HomeItemIndex = index;
            ItemName = name;
        }
    }
}
