using HotelApp.Data;
using HotelApp.Models.Custormers;

namespace HotelApp.Repositories.Customers
{
    public class CustomersRepository : RepositoryBase<Customer>
    {
        public CustomersRepository(DataContext context) : base(context) { }
    }
}
