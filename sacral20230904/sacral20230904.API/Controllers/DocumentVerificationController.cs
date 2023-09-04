
using Microsoft.AspNetCore.Mvc;
using sacral20230904.DTO;
using sacral20230904.Service;
using System.Collections.Generic;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var documentVerification = await _documentVerificationService.GetById(id);

            if (documentVerification == null)
            {
                return NotFound();
            }

            return Ok(documentVerification);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var documentVerifications = await _documentVerificationService.GetAll();

            return Ok(documentVerifications);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DocumentVerificationModel documentVerification)
        {
            var id = await _documentVerificationService.Create(documentVerification);

            return CreatedAtAction(nameof(GetById), new { id = id }, documentVerification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, DocumentVerificationModel documentVerification)
        {
            if (id != documentVerification.Id)
            {
                return BadRequest();
            }

            var result = await _documentVerificationService.Update(documentVerification);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _documentVerificationService.Delete(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
