using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_THC_Inventory.Models
{
    public class WeightManager
    {
        public long Id { get; set; }
        public string Ticketnum { get; set; }
        public string Truckno { get; set; }
        public string Prodname { get; set; }
        public string Custname { get; set; }
        public DateTime Date_in { get; set; }
        public DateTime Date_out { get; set;}
        public int FirstWeight { get; set; }
        public int SecondWeight { get; set; }
        public string Note { get; set; }

    }
}
