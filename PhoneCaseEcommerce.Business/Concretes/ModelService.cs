using PhoneCaseEcommerce.Business.Abstract;
using PhoneCaseEcommerce.DataAccess.Abstract;
using PhoneCaseEcommerce.Entities.Models;

namespace PhoneCaseEcommerce.Business.Concretes
{
    public class ModelService : IModelService
    {
        private readonly IModelDal modelDal;

        public ModelService(IModelDal modelDal)
        {
            this.modelDal = modelDal;
        }

        public async Task<List<Model>> GetModelListAsync()
        {
            return await modelDal.GetList();
        }
    }
}
