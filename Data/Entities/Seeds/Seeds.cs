using Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities.Seeds
{
    public static class Seeds
    {

        public static Buyer user1 = new Buyer("Petar", "Krešimir", "kresimir@gmail.com", 10);
        public static Buyer user2 = new Buyer("Dmitar", "Zvonimir", "zvonimir@gmail.com", 300);
        public static Buyer user3 = new Buyer("Jelena", "Arpadović", "jelenaarp@gmail.com", 250);
        public static Buyer user4 = new Buyer("Stjepan", "Držislav", "drzilav@gmail.com", 30);
        public static Buyer user5 = new Buyer("Petar", "Snačić", "snacic@gmail.com", 40.5);
        public static Seller user6 = new Seller("Ladislav", "Arpadović", "ladislavarp@gmail.com", new List<Product> {});
        public static Seller user7 = new Seller("Karlo", "Robert", "robert@gmail.com", new List<Product> {});
        public static Seller user8 = new Seller("Pavao", "Šubić-Bribirski", "subicbrib@gmail.com", new List<Product> {});
        public static Seller user9 = new Seller("Stjepan", "Kotromanić", "kotromanic@gmail.com", new List<Product> {});
        public static Product product1 = new Product("Olovka", "Za pisanje na papiru", "Školski pribor", 1.49, user6);
        public static Product product2 = new Product("Gumica", "Za brisanje na papiru", "Školski pribor", 1.99, user6);
        public static Product product3 = new Product("Oštrilo", "Za oštriti olovke", "Školski pribor", 2.49, user6);
        public static Product product4 = new Product("Bilježnica bez crta", "52 stranice A4 papira", "Školski pribor", 1.99,user7);
        public static Product product5 = new Product("Fanta", "Gazirano piće s okusom naranče", "Pića", 1.29,user7);
        public static Product product6 = new Product("Sprite", "Gazirano piće s okusom limuna", "Pića", 1.29,user8);
        public static Product product7 = new Product("Oreo", "Pakiranje čokoladnih Oreo keksa", "Hrana", 2.49,user8);
        public static Product product8 = new Product("Lays čips", "Slani čips od krumpira", "Hrana", 0.99,user9);
        public static Product product9 = new Product("Voda", "Svjeđža voda iz izvora rijeke Jadro", "Pića", 1.09,user9);
        public static Product product0 = new Product("Narodni kruh", "Domaći kruh", "Hrana", 1.89, user9);
        public static void SetUpSeeds()
        {
            user6.productsOfSeller = new List<Product>() { product0, product1, product2 };
            user7.productsOfSeller = new List<Product>() { product3, product4 };
            user8.productsOfSeller = new List<Product>() { product5, product6 };
            user9.productsOfSeller = new List<Product>() { product7, product8, product9 };
        }
        public static Dictionary<Guid, User> Users = new Dictionary<Guid, User>()
        {
            {user1.id,user1},
            {user2.id,user2},
            {user3.id,user3},
            {user4.id,user4},
            {user5.id,user5},
            {user6.id,user6},
            {user7.id,user7},
            {user8.id,user8},
            {user9.id,user9}

        };
        public static Dictionary<Guid, Product> Products = new Dictionary<Guid, Product>
        {
            {product0.id,product0},
            {product1.id,product1},
            {product2.id,product2},
            {product3.id,product3},
            {product4.id,product4},
            {product5.id,product5},
            {product6.id,product6},
            {product7.id,product7},
            {product8.id,product8},
            {product9.id,product9}
        };
        public static List<string> Cupons = new List<string>()
        {
            "$V0LIMDUMP$",
            "$CES@RICA$",
            "$M@HUNA$"
        };
    }
}
