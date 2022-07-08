using Microsoft.AspNetCore.Mvc;
using Rock_Paper_Scissors.Models;
using System;

namespace Rock_Paper_Scissors.Controllers
{
    public class ItemController : Controller
    {
        public IActionResult Play()
        {
            return View();
        }
        
        public IActionResult PlayerVsComp(int id)
        {
            Item Item = DB.GetItem(id); //gets item from data with similar id
            string user = Item.Name;
            string comp = ComputerChoice();
            string str;

            str = WinOrLose(user, comp, 0);

            ViewBag.Choices = "Player : " + user + "\nComputer : " + comp;
            ViewBag.Message = str;
            return View("Result");
        }

        public IActionResult CompVsComp()
        {
            string comp1 = ComputerChoice();
            string comp2 = ComputerChoice();
            string str = WinOrLose(comp1, comp2, 1);

            ViewBag.Choices = "Computer 1 : " + comp1 + "\nComputer 2 : " + comp2;
            ViewBag.Message = str;
            return View("Result");
        }


        //Private methods to help functionality of the application

        //Computer's Random Choice
        private string ComputerChoice()
        {
            Random ran = new Random();
            int num = ran.Next(1, 4);
            string str;

            Item item = DB.GetItem(num);
            str = item.Name;

            return str;
        }

        //To determine if it's a win or loss
        private string WinOrLose(string user, string comp, int i)
        {
            //integer parameter is to regulate the output accordingly, whether it's player vs comp or comp vs comp

            string str = "";

            if (user == comp)
                str = "It is a DRAW!";

            else if ((user == "ROCK" && comp == "PAPER") || (user == "PAPER" && comp == "SCISSORS") || (user == "SCISSORS" && comp == "ROCK"))
            {
                if (i == 0)
                    str = "You Lose";
                else
                    str = "Computer 2 Wins!!";

            }

            else if ((user == "ROCK" && comp == "SCISSORS") || (user == "PAPER" && comp == "ROCK") || (user == "SCISSORS" && comp == "PAPER"))
            {
                if (i == 0)
                    str = "You WIN!!";
                else
                    str = "Computer 1 Wins!!";
            }

            return str;
        }
    }
}
