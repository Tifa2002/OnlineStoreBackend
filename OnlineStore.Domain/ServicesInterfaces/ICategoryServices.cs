using OnlineStore.Domain.Entities;
using System;
namespace OnlineStore.Domain.ServicesInterfaces
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetCategories();
        Category GetCategory(int id);
        void AddCategory(Category category);
        void RemoveCategory(int id);
        void UpdateCategory(Category category);
    }
}
