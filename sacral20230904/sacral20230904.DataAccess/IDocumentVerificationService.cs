


using sacral20230904.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sacral20230904.Service
{
    public interface IDocumentVerificationService
    {
        Task<int> AddAsync(DocumentVerificationModel documentVerification);
        Task<DocumentVerificationModel> GetByIdAsync(int id);
        Task<List<DocumentVerificationModel>> GetAllAsync();
        Task UpdateAsync(DocumentVerificationModel documentVerification);
        Task DeleteAsync(int id);
    }
}
