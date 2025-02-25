using System.Globalization;
using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class AlunoController : Controller
    {
        private static List<Aluno> alunos=new List<Aluno>();

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //EVITA QUE VENHA DADOS DE OUTROS LUGARES QUE NAAO SEJAM DA PÁGINA OFICIAL, pois ele verifica se veio da página correta

        public IActionResult Create(Aluno aluno)
        {
            alunos.Add(aluno);
            return RedirectToAction("index");
        }
        public IActionResult Edit(int id)
        {
            var aluno = alunos.FirstOrDefault( a => a.AlunoID == id);
            if(aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }
        public IActionResult Index()
        {
            return View(alunos);
        }
    }
}
