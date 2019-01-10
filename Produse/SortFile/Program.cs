using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace SortFile
{
    class Program
    {
        private class Produs
        {
            public int CodProdus { get; set; }
            public string Denumire { get; set; }
            public string UnitateMasura { get; set; }
            public int Cantitate { get; set; }
            public int PretUnitar { get; set; }
        }

        private static IEnumerable<Produs> ReadProducts(string fileName)
        {
            var rgx = new Regex(@"(\w+?)\s+?-\s+?<(\d+?)>\s+?-\s+?<(\w+?)>\s+?-\s+?<(\d+?)>\s+?-\s+?<(\d+?)>\.");

            using (var sr = new StreamReader(fileName))
            {
                string line;
                while (!string.IsNullOrEmpty(line = sr.ReadLine()))
                {
                    var match = rgx.Match(line);
                    if (match.Success && match.Groups.Count == 6)
                    {
                        yield return new Produs
                        {
                            Denumire = match.Groups[1].Value,
                            CodProdus = int.Parse(match.Groups[2].Value),
                            UnitateMasura = match.Groups[3].Value,
                            Cantitate = int.Parse(match.Groups[4].Value),
                            PretUnitar = int.Parse(match.Groups[5].Value)
                        };
                    }
                }
            }
        }

        private static void WriteProducts(string fileName, IEnumerable<Produs> products)
        {
            using(var sw = new StreamWriter(fileName))
            {
                foreach (var product in products)
                {
                    sw.WriteLine("{0,-20}{1,-20}{2,-20}{3,-20}{4,-20}", product.Denumire, product.CodProdus,
                        product.UnitateMasura, product.Cantitate, product.PretUnitar);
                }
            }
        }

        static void Main(string[] args)
        {
            var products = ReadProducts("produse.txt");
            var orderedProducts = products.OrderBy(i => i.CodProdus);
            WriteProducts("produse-ordonate.txt", orderedProducts);
        }
    }
}
