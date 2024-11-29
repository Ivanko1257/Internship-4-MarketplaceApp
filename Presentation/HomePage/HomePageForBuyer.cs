using Data.Entities;
using Data.Entities.Models;
using Domain.Repositorys;
using Presentation.SignUpPage;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.HomePage
{
    public static class HomePageForBuyer
    {
        public static void BuyerPage(Buyer buyer)
        {
            int pickedOperation = 0;
            while (true)
            {
                Console.Clear();
                pickedOperation = 0;
                Console.WriteLine($"Vaše trenutno stanje računa je {buyer.userBalance}");
                Console.WriteLine("\nOstavite polje za unos prazno kako bi se vratili na prethodni izbornik\nUpišite broj operacije koju želite napraviti:\n1-Kupnja proizvoda\n2-Pregled liste omiljenih\n3-Dodavanje proizvoda u listu omiljenih\n4-Povratak proizvoda\n5-Povijest transakcija");
                while (pickedOperation == 0)
                {
                    var wantedOperation = Console.ReadLine();
                    if (wantedOperation == "")
                    {
                        EnteringAplication.Entry();
                    }
                    int.TryParse(wantedOperation, out pickedOperation);
                    if (!HelpFunctions.IsOperationValid(new List<int> { 1, 2, 3, 4 }, pickedOperation))
                    {
                        Console.Write("Operacija koju želite obaviti ne postoji. Pokušajte ponovo: ");
                    }
                }
                switch (pickedOperation)
                {
                    case 1:
                        Console.Clear();
                        bool requestToBreak = false;
                        Console.WriteLine("Proizvodi dostupni za kupnju:\n");
                        WriteAvalableProducts();
                        Console.WriteLine("Upišite ID proizvoda kojeg želite kupiti");
                        Product productToBuy = null;
                        while(productToBuy == null)
                        {
                            string tryToSetProductToBuy = Console.ReadLine();
                            if(tryToSetProductToBuy=="")
                            {
                                requestToBreak = true;
                                break;
                            }
                            productToBuy = BuyerFunctions.FindProduct(tryToSetProductToBuy);
                            if (productToBuy == null) Console.Write("Proizvod koji tražite ne postoji. Pokušajte ponovo: ");
                        }
                        if (requestToBreak) break;
                        if(productToBuy.productPrice>buyer.userBalance)
                        {
                            Console.Write("Nemate dovoljno novca na računu da biste kupili ovaj proizvod");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write($"Želite li kupiti proizvod {productToBuy.productName}?(Da,Ne): ");
                        if(HelpFunctions.IsOperationConfirmed())
                        {
                            productToBuy.productStatus = ProductStatus.Prodano;
                            Console.Write("Upišite kupon za 20% popusta (ako ne želite iskoristiti kupon, upišite SKIP):");
                            buyer.userBalance -= productToBuy.productPrice*BuyerFunctions.CouponDiscount();
                            productToBuy.sellerOfProduct.profitFromProducts += productToBuy.productPrice * 0.95;
                            Transaction newTransaction = new Transaction(productToBuy.id, buyer,productToBuy.sellerOfProduct);
                            productToBuy.sellerOfProduct.transactionsOfSellersProducts.Add(newTransaction);
                            buyer.transactionHistory.Add(newTransaction);
                            Console.WriteLine("Kupovina je uspiješna");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        if (buyer.productsInFavourites.Count == 0)
                        {
                            Console.WriteLine("Nemate proizvode u listi omiljenih");
                            Console.ReadKey();
                            break;
                        }
                        Console.WriteLine("Ovo su proizvodi u vašoj listi omiljenih:");
                        foreach(var product in buyer.productsInFavourites)
                        {
                            Console.WriteLine($" -ID: {product.id}\n -Ime: {product.productName}\n -Opis: {product.productDescription}\n -Kategorija:{product.productCategory}\n -Cijena: {product.productPrice}\n");
                        }
                        Console.ReadKey();
                        break;
                    case 3:
                        Console.Clear();
                        requestToBreak = false;
                        WriteAvalableProducts();
                        Console.Write("Unesite ID proizvoda kojeg želite dodati u listu omiljenih: ");
                        Product productToAdd = null;
                        while (productToAdd == null)
                        {
                            string tryToSetProductToAdd = Console.ReadLine();
                            if(tryToSetProductToAdd=="")
                            {
                                requestToBreak = true;
                                break;
                            }
                            productToAdd = BuyerFunctions.FindProduct(tryToSetProductToAdd);
                            if (productToAdd == null) Console.Write("Proizvod koji tražite ne postoji. Pokušajte ponovo: ");
                        }
                        if (requestToBreak) break;
                        if (BuyerFunctions.IsAlreadyInFavourites(buyer, productToAdd)) Console.WriteLine("Proizvod već postoji u listi omiljenih");
                        else
                        {
                            buyer.productsInFavourites.Add(productToAdd);
                            Console.WriteLine("Dodavanje je uspješno");
                        }
                        Console.ReadKey();
                        break;
                    case 4:
                        Console.Clear();
                        requestToBreak = false;
                        if (buyer.transactionHistory.Count == 0) Console.WriteLine("Trenutno nemate kupljenih proizvoda");
                        else
                        {
                            foreach (var transaction in buyer.transactionHistory)
                            {
                                Product product = BuyerFunctions.FindProduct(transaction.idOfProduct.ToString());
                                Console.WriteLine($"\n -ID proizvoda: {product.id}\n -Ime proizvoda: {product.productName}\n -Iznos: {product.productPrice}\n -Vrijeme transakcije: {transaction.timeOfTransaction}");
                            }
                            Console.Write("Upišite ID proizvoda kojeg želite vratiti: ");
                            Product productToReturn = null;
                            while(productToReturn == null)
                            {
                                string tryToSetProductToReturn = Console.ReadLine();
                                if(tryToSetProductToReturn=="")
                                {
                                    requestToBreak = true;
                                    break;
                                }
                                productToReturn = BuyerFunctions.FindProductInHistory(tryToSetProductToReturn, buyer);
                                if (productToReturn == null) Console.Write("Proizvod kojeg želite vratiti ne postoji. Pokušajte ponovo: ");
                            }
                            if (requestToBreak) break;
                            Console.Write($"Želite li vratiti {productToReturn.productName}?(Da, Ne): ");
                            if(HelpFunctions.IsOperationConfirmed())
                            {
                                productToReturn.productStatus = ProductStatus.NaProdaji;
                                buyer.userBalance += productToReturn.productPrice*0.8;
                                productToReturn.sellerOfProduct.profitFromProducts += productToReturn.productPrice;
                                Console.WriteLine("Povratak uspješan");
                                Console.ReadKey();
                            }
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Ovo su svi proizvodi koje ste kupili:");
                        if (buyer.transactionHistory.Count == 0) Console.WriteLine("Trenutno nemate kupljenih proivoda");
                        else
                        {
                            foreach (var transaction in buyer.transactionHistory)
                            {
                                Product product = BuyerFunctions.FindProduct(transaction.idOfProduct.ToString());
                                Console.WriteLine($"\n -ID proizvoda: {product.id}\n -Ime proizvoda: {product.productName}\n -Iznos: {product.productPrice}\n -Vrijeme transakcije: {transaction.timeOfTransaction}");
                            }
                        }
                        Console.ReadKey();
                        break;
                }
            }
        }
        public static void WriteAvalableProducts()
        {
            foreach (var product in UsersAndProductsData.products.Values)
            {
                if (product.productStatus == ProductStatus.NaProdaji)
                {
                    Console.WriteLine($" -ID: {product.id}\n -Ime: {product.productName}\n -Opis: {product.productDescription}\n -Kategorija:{product.productCategory}\n -Cijena: {product.productPrice}\n");
                }
            }
        }
    }
}