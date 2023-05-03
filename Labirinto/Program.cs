using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Labirinto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Posicao pQueijo = new Posicao(0, 0);
            
            int qtdRatos = 0;
            int tamanhoLab = 0;

            Console.Write("Informe o tamanho do labirinto: ");
            tamanhoLab = Convert.ToInt32(Console.ReadLine());
            Console.Write("Informe a quantidade de ratos: ");
            qtdRatos = Convert.ToInt32(Console.ReadLine());

            int[,] labirinto = new int[tamanhoLab, tamanhoLab];
            Labirinto.povoaArray(labirinto);

            for (int i = 0; i < qtdRatos; i++)
            {
                Rato r = new Rato(labirinto, qtdRatos);
                Thread newThread = new Thread(new ThreadStart(r.Run));
                
                newThread.Start();               
            }            
        }
    }
}
