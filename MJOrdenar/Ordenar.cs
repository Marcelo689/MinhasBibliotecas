namespace MJOrdenar
{
    public static class MeuConsole
    {
        public static string Algo(this string palavra)
        {
            return palavra + " Convertida para Marcelo Jaeger";
        }
    }
    public static class Ordernar
    {
        public static List<int> OrdernarInteiros(this List<int> listaInteiros)
        {
            List<List<int>> saida = new List<List<int>>(); 

            List<int[]> listaDePares = listaInteiros.DividirArrayEmPares();

            int quantidadePares = listaInteiros.Count();

            bool quantidadeEhPar = quantidadePares % 2 == 0;

            if (quantidadeEhPar)
            {
                saida = MerjandoFileira(saida, listaDePares);
            }

            return saida.First();

        }

        private static List<List<int>> MerjandoFileira(List<List<int>> saida, List<int[]> listaDePares)
        {
            int quantidadeDePares = listaDePares.Count();

            for (int i = 0; i < quantidadeDePares; i += 2)
            {
                int[] par1 = listaDePares[i];
                int[] par2 = listaDePares[i + 1];

                List<int> mergeDosPares = MerjarPar(par1, par2);

                saida.Add(mergeDosPares);
            }

            bool listaNaoCompleta = saida.First().Count != quantidadeDePares;

            while (listaNaoCompleta)
            {
                saida = MerjandoFileira(saida, listaDePares);
            }

            return saida;
        }

        private static List<int> MerjarPar(int[] ints1, int[] ints2)
        {
            List<int> saida = new List<int>();

            List<int> array1 =  ints1.ToList();
            List<int> array2 = ints2.ToList();

            bool umDasListaNaoFoiZerada = (array1.Count == 0 || array2.Count == 0);

            while (umDasListaNaoFoiZerada)
            {
                bool primeiroElementoDoParDaEsquerdaEhMenorQueDaDireita = array1[0] < array2[0];

                if (primeiroElementoDoParDaEsquerdaEhMenorQueDaDireita)
                {
                    saida.AdicionaElementoNaSaidaERemoveDaListaDeOrigem(array1);
                }
                else
                {
                    saida.AdicionaElementoNaSaidaERemoveDaListaDeOrigem(array2);
                }
            }

            bool lista1EstaVazia = array1.Count == 0;

            if (lista1EstaVazia)
            {
                saida.AdicionarElementosParaSaida(array2);
            }
            else
            {
                saida.AdicionarElementosParaSaida(array1);
            }

            return saida;
        }

        private static void AdicionaElementoNaSaidaERemoveDaListaDeOrigem(this List<int> saida, List<int> array1)
        {
            saida.Add(array1[0]);
            array1.RemoveAt(0);
        }

        public static void AdicionarElementosParaSaida(this List<int> saida, List<int> lista)
        {
            foreach (int item in lista)
            {
                saida.Add(item);
            }
        }
        public static string Printar(this List<int[]> lista)
        {
            int contador = 1;
            string saida = string.Empty;
            foreach (int[] item in lista)
            {
                saida += ("\n\n" + contador + "º ----------------\n\n");
                foreach(int subItem in item)
                {
                    saida += ("     " + subItem + "     ");
                }
                contador++;
            }

            return saida;
        }

        public static List<int[]> DividirArrayEmPares(this List<int> lista)
        {
            int tamanhoLista = lista.Count;
            int numeroDeDivizoes = tamanhoLista / 2;
            List<int[]> saida = new List<int[]>();

            int tamanhoDeCadaPedaco = 2;

            for (int i = 0; i < numeroDeDivizoes; i += tamanhoDeCadaPedaco) {
                int valor1 = lista[i];
                int valor2 = lista[i + 1];

                int [] parOrdenado = OrdenarPar(valor1, valor2);
                saida.Add(parOrdenado);
            }

            return saida;
        }

        public static int [] OrdenarPar(int num1, int num2)
        {
            if(num1 > num2) {
                return new int [] { num2 , num1};
            }

            return new int[] { num1 , num2};
        }
    }
}