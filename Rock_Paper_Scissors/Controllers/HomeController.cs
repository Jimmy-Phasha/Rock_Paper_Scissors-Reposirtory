using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rock_Paper_Scissors.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Play()
        {
            return View();
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

        private string WinOrLose(string user, string comp)
        {
            string str = "";

            if (user == comp)
                str = "It is a DRAW!";

            else if ((user == "ROCK" && comp == "PAPER") || (user == "PAPER" && comp == "SCISSORS") || (user == "SCISSORS" && comp == "ROCK"))
            {
                str = "You Lose";
            }

            else if ((user == "ROCK" && comp == "SCISSORS") || (user == "PAPER" && comp == "ROCK") || (user == "SCISSORS" && comp=="PAPER"))
                str = "You WIN!!";

            return str;
        }
    }
}
