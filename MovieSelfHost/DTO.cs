using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSelfHost
{
    public class clsGenre

    {   public int GenreID { get; set; }
        public string Name { get; set; }
        public string Tags { get; set; }

        public List<clsAllMovie> MovieList { get; set; }

    }

    public class clsAllMovie
    {
        public int MovieID { get; set; }
        public int GenreID { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public DateTime DateTimeModified { get; set; }
        public int Quantity { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Rentable { get; set; }
        public int? Discount { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t ${1}\t {2}", Title, Price, Quantity);
        }
    }


}
