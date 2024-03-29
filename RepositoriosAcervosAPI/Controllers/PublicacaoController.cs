﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositorioAcervosAPI.Dominio;
using RepositorioAcervosAPI.Models;
using RepositorioAcervosAPI.Persistencia;

namespace RepositorioAcervosAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PublicacaoController : ControllerBase
    {
        [HttpGet]
        [Route("obtenhapublicacoes")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Publicacao/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //Registrar Publicacao
        [HttpPost]
        [Route("registrarpublicacao")]
        public RetornoPadrao RealizePublicacao([FromBody] Publicacao publicacao)
        {
            var mapeadorPublicacao = new MapeamentoPublicacao();
            var retorno = new RetornoPadrao();

            try
            {
                retorno.Result = mapeadorPublicacao.realizePublicacao(publicacao);
                retorno.Codigo = 0;
                retorno.Mensagem = "Publicação realizada com sucesso!";
            }
            catch (Exception erro)
            {
                retorno.Codigo = 1;
                retorno.Mensagem = $"Falha ao realizar publicação teste 28/05 \n:{erro.Message}";
            }

            return retorno;
        }

        [HttpGet]
        [Route("obtenhapublicacoespeloid")]
        public RetornoPadrao ObtenhaPublicacoesPeloId(int idUsuario)
        {
            var mapeadorPublicacao = new MapeamentoPublicacao();
            var retorno = new RetornoPadrao();

            try
            {
                retorno.Result = mapeadorPublicacao.ObtenhaPublicacoesPeloId(idUsuario);
                retorno.Codigo = 0;
                retorno.Mensagem = "";
            }
            catch (Exception)
            {
                retorno.Codigo = 1;
                retorno.Mensagem = $"Falha ao obter as publicacões do usuário";
            }

            return retorno;
        }

        [HttpPost]
        [Route("deletepublicacaopeloid")]
        public RetornoPadrao DeletePublicacaoPeloId([FromBody] Publicacao publicacao)
        {

            var mapeadorPublicacao = new MapeamentoPublicacao();
            var retorno = new RetornoPadrao();

            try
            {

                mapeadorPublicacao.DeletePublicacaoPeloId(publicacao.Id);
                retorno.Codigo = 0;
                retorno.Mensagem = "Publicação deletada com sucesso!";
            }
            catch (Exception)
            {
                retorno.Codigo = 1;
                retorno.Mensagem =  $"Falha ao deletar a publicação";
            }

            return retorno;
        }


        [HttpGet]
        [Route("obtenhatodaspublicacoesrepositorio")]
        public RetornoPadrao ObtenhaTodasPublicacoesDoRepositorio()
        {
            var mapeadorPublicacao = new MapeamentoPublicacao();
            var retorno = new RetornoPadrao();

            try
            {
                retorno.Result = mapeadorPublicacao.ObtenhaTodasPublicacoesRepositorio();
                retorno.Codigo = 0;
                retorno.Mensagem = "Publicações obtidas com sucesso";
            }
            catch (Exception)
            {
                retorno.Codigo = 1;
                retorno.Mensagem = $"Falha ao obter todas as publicações do repositório";
            }

            return retorno;
        }
    }
}
