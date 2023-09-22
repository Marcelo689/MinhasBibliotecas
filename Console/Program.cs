using MJOrdenar;

List<int> lista = new List<int>{ 2, 3, 4, 12, 4, 35, 34, 5, 235, 32, 54, 54, 3, 5234 };
string algo = "hahahha";

List<int> listaMerge = lista.OrdernarInteiros();

foreach (var item in listaMerge)
{
    Console.WriteLine(item);
}