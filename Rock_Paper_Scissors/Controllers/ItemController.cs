using Microsoft.AspNetCore.Mvc;
using System;
using Rock_Paper_Scissors.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Play()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult PlayerVsComp(int id)
        {
            Item Item = DB.GetItem(id);
            string user = Item.Name;
            string comp = ComputerChoice();
            string str;

            if (id == 1)
                user = "ROCK";
            else if (id == 2)
                user = "PAPER";
            else
                user = "SCISSORS";

            str = WinOrLose(user, comp);

            ViewBag.Message = str;
            return View("Result");
        }

        public IActionResult CompVsComp()
        {
            string comp1 = ComputerChoice();
            string comp2 = ComputerChoice();
            string str = WinOrLose(comp1, comp2);

            ViewBag.Message = str;
            return View("Result");
        }


        //Private methods to help functionality of computer

        //Computer's Random Choice
        private string ComputerChoice()
        {
            Random ran = new Random();
            int num = ran.Next(1, 4);
            string str;

            if (num == 1)
                str = "ROCK";
            else if (num == 2)
                str = "PAPER";
            else
                str = "SCISSORS";

            return str;
        }

        //To determine if it's a win or loss
        private string WinOrLose(string user, string comp)
        {
            string str = "";

            if (user == comp)
                str = "It is a DRAW!";

            else if ((user == "ROCK" && comp == "PAPER") || (user == "PAPER" && comp == "SCISSORS") || (user == "SCISSORS" && comp == "ROCK"))
            {
                str = "You Lose";
            }

            else if ((user == "ROCK" && comp == "SCISSORS") || (user == "PAPER" && comp == "ROCK") || (user == "SCISSORS" && comp == "PAPER"))
                str = "You WIN!!";

            return str;
        }
    }
}
