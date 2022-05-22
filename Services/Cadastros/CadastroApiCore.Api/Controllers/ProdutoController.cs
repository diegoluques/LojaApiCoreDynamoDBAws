using AutoMapper;
using CadastroApiCore.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using SharedApiCore.Domain.Contracts.Repositories;
using SharedApiCore.Domain.Entities;

namespace CadastroApiCore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _ProdutoRepository;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoRepository ProdutoRepository, IMapper mapper)
        {
            _ProdutoRepository = ProdutoRepository;
            _mapper = mapper;
        }

        // GET: api/<ProdutoController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoUpdateDto>>> GetAll()
        {
            var result = await _ProdutoRepository.GetAll();
            var ProdutoResult = _mapper.Map<IEnumerable<ProdutoUpdateDto>>(result);
            return Ok(ProdutoResult);
        }

        //GET api/<ProdutoController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProdutoUpdateDto>> GetId(Guid id)
        {
            var result = await _ProdutoRepository.GetId(id);
            var ProdutoResult = _mapper.Map<ProdutoUpdateDto>(result);
            return ProdutoResult == null ? NotFound("Record not Found") : Ok(ProdutoResult);
        }

        // POST api/<ProdutoController>
        [HttpPost]
        public async Task<ActionResult<ProdutoUpdateDto>> Save(ProdutoInsertDto ProdutoDto)
        {
            var result = await _ProdutoRepository.Save(_mapper.Map<Produto>(ProdutoDto));
            var ProdutoResult = _mapper.Map<ProdutoUpdateDto>(result);
            return Ok(ProdutoResult);
        }

        [HttpPut]
        public async Task<ActionResult<ProdutoUpdateDto>> Put(ProdutoUpdateDto ProdutoDto)
        {
            var result = await _ProdutoRepository.Save(_mapper.Map<Produto>(ProdutoDto));
            var ProdutoResult = _mapper.Map<ProdutoUpdateDto>(result);
            return Ok(ProdutoResult);
        }

        // DELETE api/<ProdutoController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _ProdutoRepository.Delete(id);
            return Ok();
        }
    }
}
