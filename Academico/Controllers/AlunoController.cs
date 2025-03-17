using System.Globalization;
using Academico.Models;
using Microsoft.AspNetCore.Mvc;

namespace Academico.Controllers
{
    public class AlunoController : Controller
    {
        private static List<Aluno> alunos=new List<Aluno>()
        {
            new Aluno()
            {
                AlunoID = 1,
                Nome = "Aluno Teste",
                Email = "teste@mail.com",
                Telefone = "33499662",
                Endereco = "Rua Vinte e Um",
                Complemento = "Casa 2",
                Bairro = "Roma",
                Municipio = "Volta Redonda",
                Uf = "AC",
                Cep = "27211-800"

            }
    };
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //EVITA QUE VENHA DADOS DE OUTROS LUGARES QUE NAAO SEJAM DA PÁGINA OFICIAL, pois ele verifica se veio da página correta

        public IActionResult Create([Bind("Nome","Email","Telefone","Endereco","Complemento","Bairro","Municipio","Uf","Cep")]Aluno aluno)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    aluno.AlunoID = alunos.Count + 1;
                    alunos.Add(aluno);
                    return RedirectToAction("Index");
                }
                return View(aluno);
            }
            catch
            {
                return View(aluno);
            }
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Aluno aluno)
        {
            alunos.Remove(alunos.Where(i => i.AlunoID == aluno.AlunoID).First());
            alunos.Add(aluno);
            return RedirectToAction("Index");
        }

        public IActionResult Details (int id)
        {
            var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);
            if(aluno == null)
            {
                return NotFound();
            }
            return View(aluno);
        }

        public IActionResult Delete(int id)
        {
            {
                var aluno = alunos.FirstOrDefault(a => a.AlunoID==id);
                if(aluno == null)
                {
                    return NotFound();
                }

                return View(aluno);
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var aluno = alunos.FirstOrDefault(a => a.AlunoID == id);
                if(aluno== null)
                {
                    return NotFound();
                }
                alunos.Remove(aluno);
                return RedirectToAction("Index");
            }
            catch (Exception ex) 
            {
                ModelState.AddModelError("", $"Não foi possível excluir o aluno: {ex.Message}");
            }
            return View(alunos);
        }
        public IActionResult Index()
        {
            return View(alunos);
        }
    }
}
