using AutoMapper;
using CadastroApiCore.API.Dtos;
using Microsoft.AspNetCore.Mvc;
using SharedApiCore.Domain.Contracts;
using SharedApiCore.Domain.Contracts.Repositories;
using SharedApiCore.Domain.DataTransferObjects;
using SharedApiCore.Domain.Entities;

namespace CadastroApiCore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaRepository pessoaRepository, IPessoaService pessoaService, IMapper mapper)
        {
            this._pessoaRepository = pessoaRepository;
            this._pessoaService = pessoaService;
            this._mapper = mapper;
        }

        // GET: api/<PessoaController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaUpdateDto>>> GetAll()
        {
            var result = await this._pessoaService.GetAll();

            var pessoaResult = _mapper.Map<IEnumerable<PessoaUpdateDto>>(result);
            return Ok(pessoaResult);

            //var result = await _pessoaRepository.GetAll();
            //var pessoaResult = _mapper.Map<IEnumerable<PessoaUpdateDto>>(result);
            //return Ok(pessoaResult);
        }

        //GET api/<PessoaController>/5
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<PessoaUpdateDto>> GetId(Guid id)
        {
            var result = await _pessoaRepository.GetId(id);
            var pessoaResult = _mapper.Map<PessoaUpdateDto>(result);
            return pessoaResult == null ? NotFound("Record not Found") : Ok(pessoaResult);
        }

        // POST api/<PessoaController>
        [HttpPost]
        public async Task<ActionResult<PessoaUpdateDto>> Save(PessoaInsertDto pessoaDto)
        {
            var result = await _pessoaRepository.Save(_mapper.Map<Pessoa>(pessoaDto));
            var pessoaResult = _mapper.Map<PessoaUpdateDto>(result);
            return Ok(pessoaResult);
        }

        [HttpPost("Foto")] 
        public async Task<ActionResult<PessoaUpdatePhotoDto>> SavePhoto([FromForm] PessoaInsertPhotoDto pessoaDto)
        {
            var result = await this._pessoaService.SavePhoto( pessoaDto );
            var pessoaResult = _mapper.Map<PessoaUpdatePhotoDto>(result);
            return Ok(pessoaResult);
        }

        [HttpPut]
        public async Task<ActionResult<PessoaUpdateDto>> Put(PessoaUpdateDto pessoaDto)
        {
            var result = await _pessoaRepository.Save(_mapper.Map<Pessoa>(pessoaDto));
            var pessoaResult = _mapper.Map<PessoaUpdateDto>(result);
            return Ok(pessoaResult);
        }

        // DELETE api/<PessoaController>/5
        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await _pessoaRepository.Delete(id);
            return Ok();
        }
    }
}
