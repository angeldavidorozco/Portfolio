using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogoResin.Models
{
    public class Product
    {
        public Base BaseID { get; set; }
        public string TopColorValue { get; set; }
        public string BotColorValue { get; set; }
        public Image oImageID { get; set; }
        public Extra oExtraID { get; set; }
        public bool TopGlitter { get; set; }
        public bool BotGlitter { get; set; }

    }
}
