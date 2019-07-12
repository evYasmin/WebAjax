using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace View.Controllers
{
    public class HospitalController : Controller
    {
        private HospitalRepository repository;

        public HospitalController()
        {
            repository = new HospitalRepository();
        }

        // GET: Hospital
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        // JsonResult retorna um json para a requisição
        [HttpPost]
        public JsonResult Store(Hospital hospital)
        {
            hospital.RegistroAtivo = true;
            repository.Inserir(hospital);
            //retorna no formato de json o objeto de hospital
            // que foi persistido no banco de dados.

            return Json(hospital);
        }
        [HttpGet]
        public JsonResult ObterTodos(string busca)
        {
            List<Hospital> hospitais = repository.ObterTodos(busca);
            return Json(hospitais, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        [Route("apagar/{id}")]
        public JsonResult Apagar(int id)
        {
            bool apagou = repository.Apagar(id);
            return Json(new { status = apagou }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet, Route("obterpeloid/{id")]
        public JsonResult ObterPeloId(int id)
        {
            Hospital hospital = repository.ObterPeloId(id);
            return Json(hospital, JsonRequestBehavior.AllowGet);
        }

    }
}