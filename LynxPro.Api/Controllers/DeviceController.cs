using LynxPro.Models;
using LynxPro.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LynxPro.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeviceController(IUnitOfWork unitOfWork) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            var entities = await unitOfWork.LynxRepository.GetAllAsync();

            return Ok(entities);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var entity = await unitOfWork.LynxRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Device entity)
        {
            unitOfWork.LynxRepository.Add(entity);
            await unitOfWork.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = entity.DeviceId }, entity);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Device entity)
        {
            if (id != entity.DeviceId)
            {
                return BadRequest();
            }

            unitOfWork.LynxRepository.Update(entity);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await unitOfWork.LynxRepository.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            unitOfWork.LynxRepository.Delete(entity);
            await unitOfWork.SaveChangesAsync();

            return NoContent();
        }
    }
}