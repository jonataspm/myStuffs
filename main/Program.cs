    class Program
    {
        static void Main(string[] args)
        {
            List<string> homens = new List<string>();
            List<string> mulheres = new List<string>();

            Console.WriteLine("Digite 3 nomes de homens");

            homens.Add(Console.ReadLine());
            homens.Add(Console.ReadLine());
            homens.Add(Console.ReadLine());

            Console.WriteLine("Digite 3 nomes de mulheres");

            mulheres.Add(Console.ReadLine());
            mulheres.Add(Console.ReadLine());
            mulheres.Add(Console.ReadLine());

            List<Casal> casais = new List<Casal>();

            Console.WriteLine(homens);
            Console.WriteLine(mulheres);


            for (int i = 0; i < homens.Count; i++)
            {
                for (int j = 0; j < mulheres.Count; j++)
                {
                    Casal casal = new Casal();
                    casal.pessoa1 = homens[i];
                    casal.pessoa2 = mulheres[j];
                    bool condicao = casais.Exists(c => c.pessoa1 == casal.pessoa2) && casais.Exists(c => c.pessoa2 == casal.pessoa1);

                    if (!condicao)
                    {
                        casais.Add(casal);
                    }
                }
            }

            for (int i = 0; i < mulheres.Count; i++)
            {
                for (int j = 0; j < homens.Count; j++)
                {
                    Casal casal = new Casal();
                    casal.pessoa1 = mulheres[i];
                    casal.pessoa2 = homens[j];
                    bool condicao = casais.Exists(c => c.pessoa1 == casal.pessoa2) && casais.Exists(c => c.pessoa2 == casal.pessoa1);

                    if (!condicao)
                    {
                        casais.Add(casal);
                    }
                }
            }

            for (int i = 0; i < homens.Count; i++)
            {
                for (int j = 0; j < homens.Count; j++)
                {
                    Casal casal = new Casal();
                    casal.pessoa1 = homens[i];
                    casal.pessoa2 = homens[j];
                    bool condicao = casais.Exists(c => c.pessoa1 == casal.pessoa2) && casais.Exists(c => c.pessoa2 == casal.pessoa1);

                    if (casal.pessoa1 != casal.pessoa2 && !condicao)
                    {
                        casais.Add(casal);
                    }
                }
            }

            for (int i = 0; i < mulheres.Count; i++)
            {
                for (int j = 0; j < mulheres.Count; j++)
                {
                    Casal casal = new Casal();
                    casal.pessoa1 = mulheres[i];
                    casal.pessoa2 = mulheres[j];
                    bool condicao = casais.Exists(c => c.pessoa1 == casal.pessoa2) && casais.Exists(c => c.pessoa2 == casal.pessoa1);

                    if (casal.pessoa1 != casal.pessoa2 && !condicao)
                    {
                        casais.Add(casal);
                    }
                }
            }

            foreach (var item in casais)
            {
                Console.WriteLine($"[{item.pessoa1}, {item.pessoa2}]");
                Console.WriteLine($"");
            }

            Console.ReadLine();
        }
    }

    class Casal
    {
        public string pessoa1 { get; set; }
        public string pessoa2 { get; set; }
   }
