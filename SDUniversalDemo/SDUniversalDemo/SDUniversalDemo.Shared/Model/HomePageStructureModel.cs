using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SDUniversalDemo.Model
{
    public class HomePageStructureModel : BaseDataModel
    {
        public bool successful { get; set; }
        public Bucket buckets { get; set; }
    }
    public class Bucket : BaseDataModel
    {
        public long id { get; set; }
        public string colour { get; set; }
        public string displayName { get; set; }
        public string iconUrl { get; set; }
        public string priority { get; set; }
        public string iphoneImageUrl { get; set; }
        public string windowsImageUrl { get; set; }
        public string ipadImageUrl { get; set; }
        public ObservableCollection<Bucket> buckets { get; set; }
    }
}
