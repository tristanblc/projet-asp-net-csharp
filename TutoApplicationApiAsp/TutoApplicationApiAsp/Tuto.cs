using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TutoApplicationApiAsp
{
    public class Tuto
    {

        public string titre { get; set; }
        public int price { get; set; }
        public string img { get; set; }
        public string desc { get; set; }


        public override string ToString()
        {
            return  titre +" | "+ price + " | " + img + " | " + desc ;
        }


    }
}
