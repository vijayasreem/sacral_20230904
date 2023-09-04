
using sacral20230904.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sacral20230904.Service
{
    public interface IDocumentVerificationModelService
    {
        Task<DocumentVerificationModel> GetById(int id);
        Task<List<DocumentVerificationModel>> GetAll();
        Task<int> Create(DocumentVerificationModel model);
        Task<bool> Update(DocumentVerificationModel model);
        Task<bool> Delete(int id);
    }
}
