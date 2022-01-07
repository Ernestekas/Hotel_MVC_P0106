using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Models.Generic
{
    public class Entity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
