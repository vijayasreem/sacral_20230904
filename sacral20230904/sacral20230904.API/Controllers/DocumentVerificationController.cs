
using Microsoft.AspNetCore.Mvc;
using sacral20230904.DTO;
using sacral20230904.Service;
using System.Threading.Tasks;

namespace sacral20230904.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class DocumentVerificationController : ControllerBase
    {
        private readonly IDocumentVerificationService _documentVerificationService;

        public DocumentVerificationController(IDocumentVerificationService documentVerificationService)
        {
            _documentVerificationService = documentVerificationService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(DocumentVerificationModel documentVerification)
        {
            var id = await _documentVerificationService.AddAsync(documentVerification);
            return Ok(id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var documentVerification = await _documentVerificationService.GetByIdAsync(id);
            if (documentVerification == null)
            {
                return NotFound();
            }
            return Ok(documentVerification);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var documentVerifications = await _documentVerificationService.GetAllAsync();
            return Ok(documentVerifications);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, DocumentVerificationModel documentVerification)
        {
            var existingDocumentVerification = await _documentVerificationService.GetByIdAsync(id);
            if (existingDocumentVerification == null)
            {
                return NotFound();
            }

            documentVerification.Id = id;
            await _documentVerificationService.UpdateAsync(documentVerification);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingDocumentVerification = await _documentVerificationService.GetByIdAsync(id);
            if (existingDocumentVerification == null)
            {
                return NotFound();
            }

            await _documentVerificationService.DeleteAsync(id);

            return NoContent();
        }
    }
}
