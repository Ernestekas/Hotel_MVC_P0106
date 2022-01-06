using HotelApp.Data;
using HotelApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Repositories
{
    public class HotelsRepository : RepositoryBase<Hotel>
    {
        public HotelsRepository(DataContext context) : base(context) { }

    }
}
