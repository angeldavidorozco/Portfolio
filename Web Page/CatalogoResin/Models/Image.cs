using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoResin.Models
{
    public class Image
    {
        public string ImageID { get; set; }
        public string ImagePath { get; set; }
        public string ImageType { get; set; }
        public string ImageBase { get; set; }
        public bool Act { get; set; }
    }
}
