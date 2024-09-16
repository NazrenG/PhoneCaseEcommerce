using PhoneCaseEcommerce.Entities.Models;

namespace PhoneCaseEcommerce.Business.Abstract
{
    public interface IModelService
    {
        Task<List<Model>> GetModelListAsync();
    }
}
