using Ckm.Convites.Business.Interfaces;
using Ckm.Convites.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Ckm.Convites.Mvc.Controllers
{
    public class PessoaController : Controller
    {
        private IPessoaManager _pessoaManager;
        public PessoaController(IPessoaManager pessoaManager)
        {
            _pessoaManager = pessoaManager;
        }

        [HttpGet]
        public IEnumerable<Pessoa> Get()
        {
            return _pessoaManager.GetAll();
        }

        public Pessoa Get(int id)
        {
            return _pessoaManager.GetById(id);
        }

        [HttpPost]
        public ActionResult Post( Pessoa pessoa)
        {
           var gravar =  _pessoaManager.Add(pessoa);           
            return Json(new { Message = gravar }, JsonRequestBehavior.AllowGet);
        }

        public void Put(int id, Pessoa pessoa)
        {
            _pessoaManager.Update(pessoa);
        }

        public void Delete(int pessoaId)
        {
            _pessoaManager.Delete(pessoaId);
        }
    }
}