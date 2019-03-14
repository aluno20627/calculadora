using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculadora.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {

            //Inicializa o visor a zero
            ViewBag.Ecra = "0";

            //variavel auxiliar
            Session["primeiraVezOperador"] = true;
            return View();
        }
        
        // POST: Home
        [HttpPost]
        public ActionResult Index(string bt, string visor)
        {
            //variável auxiliar
            string ecra = visor;

            //identificar o valor na variável 'bt'
            switch (bt)
            {   //se entrei aqui, é porque foi selecionado um 'algarismo'
                case "0":
                case "1":
                case "2":
                case "3":
                case "4":
                case "5":
                case "6":
                case "7":
                case "8":
                case "9":
                    //vou decidir o que fazer quando no visor só existe o 'zero'

                    if (visor == "0")  //outra opção seria visor.Equals("0")
                    {
                        ecra = bt;
                    }
                    else
                    {//visor e bt são strings por isso esta operação concatena as duas
                        ecra = ecra + bt;
                    }
                    break;
                //processar o caso da ','
                case ",":
                    if (!visor.Contains(",")) ecra = ecra + bt;
                    break;

                //se entrei aqui, é porque foi selecionado um 'operador'
                case "+":
                case "-":
                case "x":
                case ":":
                    //é a 1ª vez que carreguei num destes operadores?
                    if ((bool)Session["primeiraVezOperador"] == true)
                    {

                    }

                    break;


            }
            //prepara o conteúdo a aparecer no VISOR da View
            ViewBag.Ecra = ecra;


            return View();
        }
    }
}