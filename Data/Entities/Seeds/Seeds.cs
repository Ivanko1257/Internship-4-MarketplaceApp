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
        public static Dictionary<Guid, User> Users = new Dictionary<Guid, User>()
        {
            {Guid.NewGuid(), new Buyer("Petar", "Krešimir","kresimir@gmail.com", 10)},
            {Guid.NewGuid(), new Buyer("Dmitar", "Zvonimir", "zvonimir@gmail.com", 300) },
            {Guid.NewGuid(), new Buyer("Jelena", "Arpadović", "jelenaarp@gmail.com", 250) },
            {Guid.NewGuid(), new Buyer("Stjepan", "Držislav", "drzilav@gmail.com", 30) },
            {Guid.NewGuid(), new Buyer("Petar", "Snačić", "snacic@gmail.com", 40.5) },
            {Guid.NewGuid(), new Seller("Ladislav", "Arpadović", "ladislavarp@gmail.com", new List<Guid>{idPen,idEraser,idSharpener}) },
            {Guid.NewGuid(), new Seller("Sigmund", "Luksemburški", "luksemburg@gmail.com", new List<Guid>{idNoteBook})},
            {Guid.NewGuid(), new Seller("Karlo", "Robert", "robert@gmail.com", new List<Guid>{idFanta, idSprite })},
            {Guid.NewGuid(), new Seller("Pavao", "Šubić-Bribirski","subicbrib@gmail.com", new List<Guid>{idOreo, idChips}) },
            {Guid.NewGuid(), new Seller("Stjepan", "Kotromanić", "kotromanic@gmail.com", new List<Guid>{idWater, idBread}) }
        };
        static Guid idPen = Guid.NewGuid();
        static Guid idEraser = Guid.NewGuid();
        static Guid idSharpener = Guid.NewGuid();
        static Guid idNoteBook = Guid.NewGuid();
        static Guid idFanta = Guid.NewGuid();
        static Guid idWater = Guid.NewGuid();
        static Guid idOreo = Guid.NewGuid();
        static Guid idSprite = Guid.NewGuid();
        static Guid idBread = Guid.NewGuid();
        static Guid idChips = Guid.NewGuid();
        public static Dictionary<Guid, Product> Products = new Dictionary<Guid, Product>()
        {
            {idPen, new Product("Olovka","Za pisanje na papiru", "Školski pribor", 1.49)},
            {idEraser, new Product("Gumica","Za brisanje na papiru", "Školski pribor", 1.99)},
            {idSharpener, new Product("Oštrilo","Za oštriti olovke", "Školski pribor", 2.49)},
            {idNoteBook, new Product("Bilježnica bez crta", "52 stranice A4 papira","Školski pribor", 1.99)},
            {idFanta, new Product("Fanta","Gazirano piće s okusom naranče","Pića", 1.29) },
            {idSprite, new Product("Sprite","Gazirano piće s okusom limuna", "Pića", 1.29) },
            {idWater, new Product("Voda","Svjeđža voda iz izvora rijeke Jadro","Pića", 1.09) },
            {idOreo, new Product("Oreo","Pakiranje čokoladnih Oreo keksa", "Hrana", 2.49) },
            {idBread, new Product("Narodni kruh", "Domaći kruh", "Hrana", 1.89) },
            {idChips, new Product("Lays čips", "Slani čips od krumpira","Hrana", 0.99)}
        };
    }
}
