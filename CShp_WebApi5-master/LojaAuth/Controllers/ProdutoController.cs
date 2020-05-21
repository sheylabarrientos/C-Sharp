﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LojaAuth.Api.Models;
using LojaAuth.DTO;
using LojaAuth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaAuth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProdutoController : ControllerBase
    {

        private readonly IProdutoService _produtoService;
        private readonly IMapper _mapper;

        public ProdutoController(IProdutoService produtoService, IMapper mapper)
        {
            _produtoService = produtoService;
            _mapper = mapper;
        }

        // GET: api/Produto
        [HttpGet]
        public ActionResult<IEnumerable<ProdutoDto>> Get()
        {
            var produtos = _produtoService.ListarProdutos();

            if (produtos != null)
            {
                return Ok(_mapper.Map<List<ProdutoDto>>(produtos));
            }
            else
                return NotFound();
        }

        // GET: api/Produto/5
        [HttpGet("{id}")]
        public ActionResult<ProdutoDto> Get(int id)
        {
            var produto = _produtoService.ProcurarPorId(id);

            if (produto != null)
            {
                var retorno = _mapper.Map<ProdutoDto>(produto);

                return Ok(retorno);
            }
            else
                return NotFound();
        }


        // GET: api/Produto/aleatorio
        [HttpGet("aleatorio")]
        public ActionResult<ProdutoJSONDTO> GetAleatorio()
        {
            var produto = _produtoService.ProcurarAleatorio();

            if (produto != null)
            {
                var retorno = _mapper.Map<ProdutoJSONDTO>(produto);

                return Ok(retorno);
            }
            else
                return NotFound();
        }

        // POST: api/Produto
        [HttpPost]
        public ActionResult<ProdutoDto> Post([FromBody]ProdutoDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // mapear Dto para Model
            var produto = _mapper.Map<Produto>(value);
            //Salvar
            var retorno = _produtoService.Salvar(produto);
            //mapear Model para Dto
            return Ok(_mapper.Map<ProdutoDto>(retorno));
        }

        // PUT: api/Produto/5
        [HttpPut]
        public ActionResult<ProdutoDto> Put([FromBody] ProdutoDto value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // mapear Dto para Model
            var produto = _mapper.Map<Produto>(value);
            //Salvar
            var retorno = _produtoService.Salvar(produto);
            //mapear Model para Dto

            return Ok(_mapper.Map<ProdutoDto>(retorno));
        }

    }
}
