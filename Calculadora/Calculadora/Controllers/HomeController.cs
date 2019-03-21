using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Calculadora.Controllers
{
    public class HomeController : Controller
    {
        
        double numero1, numero2,aux;
        
        // GET: Home
        public ActionResult Index()
        {

            //Inicializa o visor a zero
            ViewBag.Ecra = "0";

            //variavel auxiliar
            Session["primeiraVezOperador"] = true;
            Session["num1"] = 0.0;
            Session["limpaVisor"] = false;
            Session["op"] = "";
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

                    //apaga ecrã depois do operador ser pressionado a 1ª vez
                    if ((bool)Session["limpaVisor"] == true)
                    {

                        ecra = "";
                        Session["limpaVisor"] = false;

                    }
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
                        Session["primeiraVezOperador"] = false;
                        Session["num1"] = ecra;
                        Session["op"] = bt;
                        Session["limpaVisor"] = true;

                    }
                    else
                    {
                        switch (Session["op"])
                        {
                            case "+":

                                Session["num1"] = Convert.ToDouble(Session["num1"]) + Convert.ToDouble(ecra);
                                break;
                            case "-":
                               
                                Session["num1"] = Convert.ToDouble(Session["num1"]) + Convert.ToDouble(ecra);
                                break;
                            case "x":
                               
                                Session["num1"] = Convert.ToDouble(Session["num1"]) + Convert.ToDouble(ecra);
                                break;
                            case ":":
                                
                                Session["num1"] = Convert.ToDouble(Session["num1"]) + Convert.ToDouble(ecra);
                                break;

                        }
                        
                        Session["op"] = bt;
                        Session["limpaVisor"] = true;

                    }


                    break;


                case "=":


                    numero2 = Convert.ToDouble(ecra);
                    numero1 = (double)Session["num1"];

                    switch (Session["op"])
                    {
                        case "+":
                            aux = numero1 + numero2;
                            ecra = "" + aux;
                            break;
                        case "-":
                            aux = numero1 - numero2;
                            ecra = "" + aux;
                            break;
                        case "x":
                            aux = numero1 * numero2;
                            ecra = "" + aux;
                            break;
                        case ":":
                            aux = numero1 / numero2;
                            ecra = "" + aux;
                            break;

                    }
                    Session["primeiraVezOperador"] = true;
                    Session["limpaVisor"] = true;


                    
                    break;

                case "+/-":
                    ecra = "" + Convert.ToDouble(ecra) * -1;
                    break;

                case "C":
                    ecra = "0";
                    numero1 = 0;
                    numero2 = 0;
                    Session["op"] = "";
                    Session["num1"] = 0;
                    break;
                    


            }
            //prepara o conteúdo a aparecer no VISOR da View
            ViewBag.Ecra = ecra;


            return View();
        }
    }
}