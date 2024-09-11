namespace OnlineStore.Service.Services
{
    public class CategoryServices : ICategoryServices
    {
        private IUnitOfWork _unitOfWork;
        private IRepository<Category> Categories;

        public CategoryServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            Categories=_unitOfWork.Repository<Category>();
        }

        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }

        public IEnumerable<Category> GetCategories()
        {
          return Categories.GetAll();
        }

        public Category GetCategory(int id)
        {
            return Categories.GetById(id);
        }

        public void RemoveCategory(int id)
        {
            Categories.Delete(id);
        }

        public void UpdateCategory(Category category)
        {
            Categories.Update(category);
        }
    }
}
