using HotelApp.Data;
using HotelApp.Models.Custormers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp.Repositories.Customers
{
    public class CustomersRepository : RepositoryBase<Customer>
    {
        public CustomersRepository(DataContext context) : base(context) { }

    }
}
