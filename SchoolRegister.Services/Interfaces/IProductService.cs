using System.Collections.Generic;
using SchoolRegister.Model.DataModels;

namespace SchoolRegister.Services.Interfaces
{
    public interface IProductService
    {
        void Add(Product product);
        void Update(Product product, int productId);
        bool Delete(int id);
        Product Get(int id);
        IList<Product> Get();
    }
}
