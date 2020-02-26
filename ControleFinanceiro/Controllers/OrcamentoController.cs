using ControleFinanceiro.Dominio.Enums;
using ControleFinanceiro.Dominio.Repositorios;
using ControleFinanceiro.ViewModels;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ControleFinanceiro.Controllers
{
    [RoutePrefix("orcamento")]
    public class OrcamentoController : Controller
    {
        private readonly IMetaRepositorio _metaRepositorio;
        private readonly ILancamentoRepositorio _lancamentoRepositorio;

        public OrcamentoController(IMetaRepositorio metaRepositorio, ILancamentoRepositorio lancamentoRepositorio)
        {
            _metaRepositorio = metaRepositorio;
            _lancamentoRepositorio = lancamentoRepositorio;
        }

        public ActionResult Index()
        {
            var model = new OrcamentoViewModel();
            var lancamentos = _lancamentoRepositorio.Listar().ToList();
            var metas = _metaRepositorio.Listar();

            model.Lancamentos = lancamentos;
            model.Metas = metas;

            PreencherModelo(model);

            //Cores dos totais
            ViewBag.ClasseValorInvestimento = (model.TotalDisponivelInvestir >= model.TotalInvestir) ? "bg-sucess" : "bg-danger";
            ViewBag.ClasseValorGastos = (model.TotalGastos <= model.TotalGastar) ? "bg-sucess" : "bg-danger";

            return View(model);
        }

        #region Métodos Auxiliares
        private void PreencherModelo(OrcamentoViewModel model)
        {
            DefinirRenda(model);
            DefinirGastos(model);
            DefinirInvestimentos(model);
            DefinirMetaGastos(model);
        }

        private void DefinirRenda(OrcamentoViewModel model)
        {
            model.TotalRendas = model.Lancamentos
                .Where(x => x.Categoria.Equals(ECategoria.Remuneracao) || x.Categoria.Equals(ECategoria.OutrasRendas))
                .Sum(x => x.Valor);
        }

        private void DefinirGastos(OrcamentoViewModel model)
        {
            model.TotalGastosEssenciais = model.Lancamentos
                .Where(x => x.Categoria.Equals(ECategoria.GastoEssencial))
                .Sum(x => x.Valor);

            model.TotalGastosLivres = model.Lancamentos
                .Where(x => x.Categoria.Equals(ECategoria.GastoLivre))
                .Sum(x => x.Valor);

            model.TotalGastos = model.TotalGastosEssenciais + model.TotalGastosLivres;
        }

        private void DefinirInvestimentos(OrcamentoViewModel model)
        {
            var totalGastos = model.TotalGastosEssenciais + model.TotalGastosLivres;

            model.TotalDisponivelInvestir = model.TotalRendas - totalGastos;

            model.TotalPorcentagemInvestir = model.Metas
                .Where(x => x.Tipo.Equals(ETipoMeta.Investimento))
                .Sum(x => x.Porcentagem);

            model.TotalInvestir = model.Metas
                .Where(x => x.Tipo.Equals(ETipoMeta.Investimento))
                .Sum(x => (Convert.ToDecimal(x.Porcentagem) * model.TotalRendas) / 100);
        }

        private void DefinirMetaGastos(OrcamentoViewModel model)
        {
            model.TotalPorcentagemGastar = model.Metas
                .Where(x => x.Tipo == ETipoMeta.Gasto)
                .Sum(x => x.Porcentagem); ;

            model.TotalGastar = (model.TotalRendas * Convert.ToDecimal(model.TotalPorcentagemGastar)) / 100;
        }
        #endregion

    }
}