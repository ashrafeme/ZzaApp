using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Zza.Data;
using Zza.Entities;

namespace Zza.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class ZzaService : IZaaService,IDisposable
    {
        protected readonly ZzaDbContext Db = new ZzaDbContext();

        public List<Product> GetProducts()
        {
            return this.Db.Products.ToList();
        }

        public List<Customer> GetCustomers()
        {
            return this.Db.Customers.ToList();
        }

       [OperationBehavior(TransactionScopeRequired =true)]
        public void SubmitOrder(Order order)
        {
            this.Db.Orders.Add(order);
            order.OrderItems.ForEach(item => this.Db.OrderItems.Add(item));
            this.Db.SaveChanges();
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
