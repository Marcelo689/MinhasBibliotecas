﻿namespace MJOrdenar
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
        private static List<int> MerjarPar(int[] ints1, int[] ints2)
        {
            List<int> saida = new List<int>();

            List<int> array1 =  ints1.ToList();
            List<int> array2 = ints2.ToList();

            bool EnquantoTamanhoDaListaNaoForIgualAoTotalDeElementos = saida.Count != ints1.Length + ints2.Length;

            while (EnquantoTamanhoDaListaNaoForIgualAoTotalDeElementos)
            {
                if (array1[0] < array2[0])
                {
                    saida.Add(array1[0]);
                    array1.RemoveAt(0);
                }
                else
                {
                    saida.Add(array2[0]);
                    array2.RemoveAt(0);
                }
            }

            return saida;
        }

        public static string Printar(this IEnumerable<int[]> lista)
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

        public static IEnumerable<int[]> DividirArrayEmPares(this int[] lista)
        {
            int tamanhoLista = lista.Length;
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