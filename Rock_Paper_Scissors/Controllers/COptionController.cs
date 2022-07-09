using Microsoft.AspNetCore.Mvc;
using Rock_Paper_Scissors.Models;
using System;

namespace Rock_Paper_Scissors.Controllers
{
    public class COptionController : Controller
    {
        public IActionResult Play()
        {
            return View();
        }
        
        public IActionResult PlayerVsComp(int id)
        {
            COption playerChoice = new COption() { Option = (Option)id };
            COption computerChoice = new COption() { Option = (Option)ComputerChoice() };
            string str;

            str = WinOrLose(playerChoice, computerChoice, true);

            ViewBag.Choices = "Player : " + playerChoice.Option.ToString() + "\nComputer : " + computerChoice.Option.ToString();
            ViewBag.Message = str;
            return View("Result");
        }

        public IActionResult CompVsComp()
        {
            COption computer1Choice = new COption() { Option = (Option)ComputerChoice() };
            COption computer2Choice = new COption() { Option = (Option)ComputerChoice() };
            string str = WinOrLose(computer1Choice, computer2Choice, false);

            ViewBag.Choices = "Computer 1 : " + computer1Choice.Option.ToString() + "\nComputer 2 : " + computer2Choice.Option.ToString();
            ViewBag.Message = str;
            return View("Result");
        }


        //Private methods to help functionality of the application

        //Computer's Random Choice
        private int ComputerChoice()
        {
            Random ran = new Random();
            return ran.Next(0, 3);
        }

        //To determine if it's a win or loss
        private string WinOrLose(COption p1, COption p2, bool type)
        {
            //type parameter is to regulate the output accordingly, whether it's player vs comp or comp vs comp
            /*
                0. Rock
                1. Paper
                2. Scissors             
             */


            /*from the options, each option can only lose to its successor, example Rock(index: 0) loses to its successor paper(index: 0+1)
            the modulus %3 is for the scissors, it has no successor but loses to Rock index : 0, so if p1 = 2 and p2= 0, calculation*/
            string player = type ? "Player" : "Computer";
            string output = "The winner is ";
            if ((int)p2.Option == (int)(p1.Option + 1) % 3) output += "Computer 2";
            else if ((int)p1.Option == (int)(p2.Option + 1) % 3) output += $"{player} 1";
            else output = "It's a draw";

            return output;
        }
    }
}
