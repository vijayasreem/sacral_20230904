public interface IDocumentVerificationService
{
    Task<DocumentVerificationModel> GetById(int id);
    Task<List<DocumentVerificationModel>> GetAll();
    Task<int> Create(DocumentVerificationModel model);
    Task<bool> Update(DocumentVerificationModel model);
    Task<bool> Delete(int id);
}