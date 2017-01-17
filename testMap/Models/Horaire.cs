using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testMap.Models
{
    public class Horaire
    {
        public int Id { get; set; }
        public string Intervalle { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
