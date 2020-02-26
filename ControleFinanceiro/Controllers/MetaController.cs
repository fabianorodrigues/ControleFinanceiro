using ControleFinanceiro.Dominio.Entidades;
using ControleFinanceiro.Dominio.Repositorios;
using ControleFinanceiro.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace ControleFinanceiro.Controllers
{
    [RoutePrefix("orcamento/metas")]
    public class MetaController : Controller
    {
        public readonly IMetaRepositorio _repositorio;

        public MetaController(IMetaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        [Route("listar", Name = "ListarMetas")]
        public ViewResult Index()
        {
            var metas = _repositorio.Listar().ToList();
            metas = metas
                .OrderBy(x => x.Tipo)
                .ThenByDescending(x => x.Porcentagem)
                .ToList();
            return View(metas);
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
        public ActionResult Incluir(MetaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var meta = new Meta(model.Id, model.Destino, model.Porcentagem, model.TipoMeta);
                _repositorio.Incluir(meta);

                return RedirectToAction("Index");
            }

            return View(model);
        }
        #endregion

        #region Alterar
        [Route("alterar/{id:int}", Name = "AlterarMeta")]
        public ViewResult Alterar(int id)
        {
            var model = Buscar(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("alterar")]
        public ActionResult Alterar(MetaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var meta = new Meta(model.Id, model.Destino, model.Porcentagem, model.TipoMeta);
                _repositorio.Alterar(meta);

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

        private MetaViewModel Buscar(int id)
        {
            var meta = _repositorio.Buscar(id);

            var model = new MetaViewModel()
            {
                Id = meta.Id,
                Destino = meta.Destino,
                Porcentagem = meta.Porcentagem,
                TipoMeta = meta.Tipo
            };

            return model;
        }
    }
}