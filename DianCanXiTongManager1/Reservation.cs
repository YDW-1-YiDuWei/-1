using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DianCanXiTongManager
{
    class Reservation
    {
        public int id { get; set; }
        public int ClientId { get; set; }
        public double Money { get; set; }
        public int CuisineInformationId { get; set; }
    }
}
