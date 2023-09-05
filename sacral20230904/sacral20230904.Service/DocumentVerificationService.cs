using sacral20230904.DataAccess;
using sacral20230904.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace sacral20230904.Service
{
    public class DocumentVerificationService : IDocumentVerificationService
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public DocumentVerificationService(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        public async Task<int> AddAsync(DocumentVerificationModel documentVerification)
        {
            return await _dataAccessProvider.AddAsync(documentVerification);
        }

        public async Task<DocumentVerificationModel> GetByIdAsync(int id)
        {
            return await _dataAccessProvider.GetByIdAsync(id);
        }

        public async Task<List<DocumentVerificationModel>> GetAllAsync()
        {
            return await _dataAccessProvider.GetAllAsync();
        }

        public async Task UpdateAsync(DocumentVerificationModel documentVerification)
        {
            await _dataAccessProvider.UpdateAsync(documentVerification);
        }

        public async Task DeleteAsync(int id)
        {
            await _dataAccessProvider.DeleteAsync(id);
        }
    }
}