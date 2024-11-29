using Data.Entities;
using Data.Entities.Models;
using Data.Entities.Seeds;
using Domain.Repositorys;
using Presentation.HomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.SignUpPage
{
    public static class EnteringAplication
    {
        public static User pickedUser = null;
        public static void Main(string[] args)
        {
            Seeds.SetUpSeeds();
            Entry();
        }
        public static void Entry()
        {
            pickedUser = null;
            Console.Clear();
            Console.Write("Upišite svoj email (Ako želite napraviti korisnički račun, upišite /SIGNUP): ");
            string email = null;
            while (pickedUser == null)
            {
                email = Console.ReadLine();
                if (email == "/SIGNUP")
                {
                    pickedUser = CreatingUser();
                    if (pickedUser == null) Console.Write("Upišite svoj email (Ako želite napraviti korisnički račun, upišite /SIGNUP): ");
                }
                else
                {
                    pickedUser = UserRepository.FindingUser(email);
                    if (pickedUser == null) Console.Write("Ne postoji korisnik sa tim emailom. Pokušajte ponovo: ");
                }
            }
            UserRepository.AddUser(pickedUser);
            if (pickedUser is Seller) HomePageForSeller.SellerPage((Seller) pickedUser);
            if (pickedUser is Buyer) HomePageForBuyer.BuyerPage((Buyer) pickedUser);

        }
        public static User CreatingUser()
        {
            User userToCreate = null;
            Console.WriteLine("\nOstavite prostor za unos podataka prazno ako želite izaći iz registracije");
            Console.Write("Upišite ime novog korisnika: ");

            var nameForSignUp = Console.ReadLine();
            if (nameForSignUp == "") return null;

            Console.Write("Upišite prezime novog korisnika: ");
            var surnameForSignUp = Console.ReadLine();
            if (surnameForSignUp == "") return null;

            Console.Write("Upišite email koji želite koristiti: ");
            string emailForSignUp = null;
            while (emailForSignUp == null)
            {
                emailForSignUp = HelpFunctions.CheckifEmailIsValid();
                if (emailForSignUp == "") return null;
                else if (emailForSignUp == null) Console.Write("Uneseni email nije točan. Pokušajte ponovo: ");
            }

            Console.Write("Želite li da se ovaj račun koristi za kupnju ili prodaju (Upišite kupnja ili prodaja): ");
            string typeOfUserForSignUp = "";
            do
            {
                typeOfUserForSignUp = Console.ReadLine();
                if (typeOfUserForSignUp == "") return null;
                else if (typeOfUserForSignUp == "kupnja")
                {
                    Console.Write("Unesite početni iznos: ");
                    double.TryParse(Console.ReadLine(), out var startingBalance);
                    if (startingBalance == 0) return null;
                    else
                    {
                        userToCreate = new Buyer(nameForSignUp, surnameForSignUp, emailForSignUp, startingBalance);
                    }
                }
                else if (typeOfUserForSignUp == "prodaja")
                {
                    userToCreate = new Seller(nameForSignUp, surnameForSignUp, emailForSignUp, new List<Product>());
                }
                else
                {
                    Console.Write("Unos nije validan. Pokušajte ponovo: ");
                }
            } while (userToCreate == null);
            return userToCreate;
        }
    }
}
