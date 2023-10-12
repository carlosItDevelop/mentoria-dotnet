using Cooperchip.ADOnetWithgenerics.API.Infra;
using Cooperchip.ADOnetWithgenerics.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cooperchip.ADOnetWithgenerics.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {

        private readonly IGenericRepository<Fornecedor> _genericRepository;
        private readonly ILogger _logger;

        public FornecedorController(IGenericRepository<Fornecedor> genericRepository, ILogger<FornecedorController> logger)
        {
            _genericRepository = genericRepository;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var fornecedores = await _genericRepository.GetAllAsync();
            if (fornecedores is null)
                return NotFound();

            foreach (var item in fornecedores)
            {
                _logger.LogInformation($"Id: {item.Id}, Nome: {item.Nome}, CNPJ: {item.Cnpj}");

            }
            return Ok(fornecedores);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var fornecedor = await _genericRepository.GetByIdAsync(id);
            if (fornecedor is null)
                return NotFound();

            _logger.LogInformation($"Nome do Fornecedor: {fornecedor.Nome}");
            return Ok(fornecedor);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Fornecedor fornecedor)
        {
            await _genericRepository.AddAsync(fornecedor);
            return CreatedAtAction(nameof(GetById), new {id = fornecedor.Id}, fornecedor);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, Fornecedor fornecedor)
        {
            if (id != fornecedor.Id) return BadRequest();

            await _genericRepository.UpdateAsync(fornecedor);
            _logger.LogInformation($"Nome do Fornecedor alterado: {fornecedor.Nome}");

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _genericRepository.DeleteAsync(id);
            return NoContent();
        }


    }

}
