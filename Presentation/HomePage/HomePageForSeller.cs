using Data.Entities;
using Data.Entities.Models;
using Domain.Repositorys;
using Presentation.SignUpPage;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.HomePage
{
    public static class HomePageForSeller
    {
        public static void SellerPage(Seller seller)
        {
            int pickedOperation = 0;
            while (true)
            {
                Console.Clear();
                pickedOperation = 0;
                Console.WriteLine($"Vaša zarada iznosi: {seller.profitFromProducts} eur");
                Console.WriteLine("\nOstavite polje za unos prazno kako bi izašli iz ovog izbornika\nUpišite broj operacije koju želite napraviti:\n1-Pregled proizvoda\n2-Dodavanje proizvoda\n3-Pregled proizvoda po kategoriji\n4-Pregled zarade u određenom vremenskom razdoblju");
                while (pickedOperation == 0)
                {
                    var wantedOperation = Console.ReadLine();
                    if (wantedOperation == "")
                    {
                        EnteringAplication.Entry();
                    }
                    int.TryParse(wantedOperation, out pickedOperation);
                    if (!HelpFunctions.IsOperationValid(new List<int> { 1, 2, 3, 4}, pickedOperation))
                    {
                        Console.Write("Operacija koju želite obaviti ne postoji. Pokušajte ponovo: ");
                    }
                }
                switch (pickedOperation)
                {
                    case 1:
                        Console.Clear();
                        if (seller.productsOfSeller.Count == 0) Console.WriteLine("Trenutno nemate stvari za prodaju");
                        else
                        {
                            Console.WriteLine("Ovo su vaši proizvodi: ");
                            foreach (var product in seller.productsOfSeller)
                            {
                                Console.WriteLine($" -Ime: {product.productName}\n -Opis: {product.productDescription}\n -Kategorija:{product.productCategory}\n -Cijena: {product.productPrice}\n -Status: {product.productStatus}\n");
                            }
                        }
                        Console.ReadKey();
                        break;

                    case 2:
                        Console.Clear();
                        Console.Write("Upišite ime novog proizvoda: ");
                        string newProductName = Console.ReadLine();
                        if (newProductName == "") break;

                        Console.Write("Upišite opis novog proizvoda: ");
                        string newProductDescription = Console.ReadLine();
                        if (newProductDescription == "") break;

                        Console.Write("Upišite kategoriju novog proizvoda(Školski pribor, Pića, Hrana): ");
                        var tryNewProductCategory = Console.ReadLine();
                        if (tryNewProductCategory == "") break;
                        string newProductCategory = tryNewProductCategory;
                        while (!SellerFunctions.IsCategoryValid(newProductCategory))
                        {
                            if (!SellerFunctions.IsCategoryValid(newProductCategory))
                            {
                                Console.Write("Unesena kategorja nije validna. Pokušajte ponovo: ");
                                newProductCategory = Console.ReadLine();
                            }
                        }

                        Console.Write("Upišite cijenu novog proizvoda: ");
                        var tryNewProductPrice = Console.ReadLine();
                        if (tryNewProductPrice == "") break;
                        double.TryParse(tryNewProductPrice, out double newProductPrice);
                        while(newProductPrice <= 0)
                        {
                            if (newProductPrice <= 0)
                            {
                                Console.Write("Unesena cijena nije validna. Pokušajte ponovo: ");
                                double.TryParse(Console.ReadLine(), out newProductPrice);
                            }
                        }

                        Console.Write("Želite li dodati ovaj proizvod?(Da,Ne)");
                        if(HelpFunctions.IsOperationConfirmed())
                        {
                            seller.productsOfSeller.Add(SellerFunctions.AddProduct(newProductName, newProductDescription, newProductCategory, newProductPrice, seller));
                            Console.WriteLine("Dodavanje projekta uspješno");
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.Write("Upišite željenu kategoriju: ");
                        string pickedCategory = null;
                        bool isCategoryEmpty=false;
                        while (pickedCategory == null)
                        {
                            pickedCategory = Console.ReadLine();
                            if (pickedCategory == "") break;
                            if (!SellerFunctions.IsCategoryValid(pickedCategory))
                            {
                                pickedCategory = null;
                                Console.Write("Kategorija ne postoji. Pokušajte ponovo: ");
                            }
                            else
                            {
                                Console.WriteLine("Vaši proizvodi:");
                                foreach (var product in seller.productsOfSeller)
                                {
                                    if (product.productCategory.ToLower() == pickedCategory.ToLower())
                                    {
                                        Console.WriteLine($" -Ime: {product.productName}\n -Opis: {product.productDescription}\n -Kategorija:{product.productCategory}\n -Cijena: {product.productPrice}\n -Status: {product.productStatus}\n");
                                    }
                                    else isCategoryEmpty = true;

                                }
                                Console.ReadKey();
                            }
                        }
                        if (isCategoryEmpty) Console.WriteLine("Nemate proizvoda u ovoj kategoriji");
                        break;
                    case 4:
                        Console.Clear();
                        bool requestToBreak = false;
                        Console.Write("Upišite datum i vrijeme od kojeg želite pregledavati zaradu(MM/DD/YY hh:mm:ss): ");
                        DateTime dateTimeToView = DateTime.MinValue;
                        while(dateTimeToView >=  DateTime.Now || dateTimeToView == DateTime.MinValue)
                        {
                            string tryToSetDateTimeToView = Console.ReadLine();
                            if(tryToSetDateTimeToView=="")
                            {
                                requestToBreak= true;
                                break;
                            }
                            dateTimeToView = DateTime.Parse(tryToSetDateTimeToView);
                            if (dateTimeToView >= DateTime.Now || dateTimeToView == DateTime.MinValue) Console.Write("Uneseno vrijeme nije valjano. Pokušajte ponovo: ");
                        }
                        if (requestToBreak) break;
                        double profitToView = 0;
                        foreach(var transaction in seller.transactionsOfSellersProducts)
                        {
                            if(transaction.timeOfTransaction < dateTimeToView)
                            {
                                profitToView += BuyerFunctions.FindProduct(transaction.idOfProduct.ToString()).productPrice;
                            }
                        }
                        Console.WriteLine("U tom vremenu ste imali zaradu od: " + profitToView);
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
