using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Dominio.Repositorios;
using ControleFinanceiro.ViewModels;
using System.Web.Mvc;

namespace ControleFinanceiro.Controllers
{
    [RoutePrefix("lancamentos")]
    public class LancamentoController : Controller
    {
        private readonly ILancamentoRepositorio _repositorio;

        public LancamentoController(ILancamentoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [Route("listar", Name = "ListarLancamentos")]
        public ActionResult Index()
        {
            var lancamentos = _repositorio.Listar(); 

            return View(lancamentos);
        }

        #region Incluir
        [Route("incluir")]
        public ViewResult Incluir()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("incluir")]
        public ActionResult Incluir(LancamentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lancamento = new Lancamento(model.Descricao, model.Valor, model.Data, model.Categoria, model.LancamentoMensal);
                _repositorio.Incluir(lancamento);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        #endregion

        #region Alterar
        [Route("alterar/{id:int}", Name = "AlterarLancamento")]
        public ViewResult Alterar(int id)
        {
            var model = Buscar(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("alterar")]
        public ActionResult Alterar(LancamentoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var lancamento = new Lancamento(model.Descricao, model.Valor, model.Data, model.Categoria, model.LancamentoMensal);
                lancamento.Id = model.Id;
                _repositorio.Alterar(lancamento);
                return RedirectToAction("Index");
            }

            return View(model);
        }
        #endregion

        #region Deletar
        [Route("deletar/{id:int}")]
        public ViewResult Deletar(int id)
        {
            var model = Buscar(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("deletar/{id:int}")]
        public RedirectToRouteResult ConfirmarDeletar(int id)
        {
            _repositorio.Deletar(id);
            return RedirectToAction("Index");
        }
        #endregion

        #region Detalhes
        [Route("detalhes/{id:int}")]
        public ViewResult Detalhes(int id)
        {
            var model = Buscar(id);
            return View(model);
        }
        #endregion

        private LancamentoViewModel Buscar(int id)
        {
            var lancamento = _repositorio.Buscar(id);
            var model = new LancamentoViewModel()
            {
                Id = lancamento.Id,
                Descricao = lancamento.Descricao,
                Valor = lancamento.Valor,
                Data = lancamento.Data,
                Categoria = lancamento.Categoria,
                LancamentoMensal = lancamento.LancamentoMensal
            };

            return model;
        }


    }
}