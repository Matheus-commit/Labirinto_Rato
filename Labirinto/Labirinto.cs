using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Labirinto
{
    internal class Labirinto
    {
        //Metodo que povoa o Labirinto
        public static void povoaArray(int[,] lab)
        {

            Random numRandom = new Random();            

            for (int i = 0; i < lab.GetLength(0); i++)
            {
                for (int j = 0; j < lab.GetLength(1); j++)
                {
                    int num = numRandom.Next(0, 5);

                    if (num >= 1) {
                        lab[i, j] = 1;
                    }
                    else { 
                        lab[i, j] = 0;
                    }
                }
            }
        }

        //Metodo que imprime o labirinto
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static void imprimeArray(int[,] lab)
        {
            System.Threading.Thread.Sleep(100);
            Console.Clear();

            for (int linha = 0; linha < lab.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < lab.GetLength(1); coluna++)
                {
                    if (linha == 0 && coluna == 0)
                    {
                        Console.Write("{0}", "Q ");
                    }
                    else
                    {
                        if (lab[linha, coluna] == 0) { Console.Write("{0}", "| "); }
                        else if (lab[linha, coluna] == 1) { Console.Write("{0}", ". "); }
                        else if (lab[linha, coluna] == -1) { Console.Write("{0}", "x "); }
                        else if (lab[linha, coluna] == 3) { Console.Write("{0}", "R "); }
                    }
                    //Console.Write(" | {0}", lab[linha, coluna].ToString("D2"));
                }
                Console.WriteLine(" ");
            }
        }

        //Metodo que percorre o labirinto e verifica se a posição, passada por parametro, é valida = 1 ou invalida = 0(parede)
        public static bool percorreLabirinto(int[,] lab, int line, int col)
        {

            bool result = false;

            for (int linha = 0; linha < lab.GetLength(0); linha++)
            {
                if (linha == line)
                {
                    for (int coluna = 0; coluna < lab.GetLength(1); coluna++)
                    {
                        if (col == coluna && lab[line, col] == 1)
                        {
                            result = true;
                        }
                    }
                }
            }
            return result;
        }

        public static bool verificaEsquerda(int[,] lab, int line, int col) {
            bool result = false;
            if (percorreLabirinto(lab, line, (col - 1)))
            {
                result = true;
            }            
            return result;            
        }

        public static bool verificaDireita(int[,] lab, int line, int col){
            bool result = false;
            if (percorreLabirinto(lab, line, (col + 1)))
            {
                result = true;
            }
            return result;
        }

        public static bool verificaCima(int[,] lab, int line, int col)
        {
            bool result = false;
            if (percorreLabirinto(lab, (line - 1), col))
            {
                result = true;
            }
            return result;
        }

        public static bool verificaBaixo(int[,] lab, int line, int col)
        {
            bool result = false;
            if (percorreLabirinto(lab, (line + 1), col))
            {
                result = true;
            }
            return result;
        }
    }
}
