using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Labirinto{
   
    internal class Rato 
    {
        Stack<Posicao> memoriaRato = new Stack<Posicao>();

        Random posRandom = new Random();
        protected int xRato = -5;
        protected int yRato = -5;

        protected int[,] lab;
        public bool loop = true;
        int qtdRatos;

        public Rato(int[,] lab, int qtd) { 
            this.lab = lab;
            this.qtdRatos = qtd;
        }

        public int getXrato() {
            return this.xRato;
        }

        public int getYrato()
        {
            return this.yRato;
        }
       
        public Posicao sorteiaPosicao() {
            int x = posRandom.Next((lab.GetLength(0) / 2), (lab.GetLength(0) - 1));
            int y = posRandom.Next((lab.GetLength(0) / 2), (lab.GetLength(0) - 1));

            Posicao p = new Posicao(x, y);

            return p;
        }

        public void andar(Posicao pInicial)
        {            
            xRato = pInicial.x;
            yRato = pInicial.y;

            while (loop)
            {
                Posicao p1 = new Posicao(xRato, yRato);   
                lab[p1.x, p1.y] = 3;               

                if (xRato != 0 || yRato != 0)
                {
                    if (Labirinto.verificaCima(lab, p1.x, p1.y))
                    {
                        xRato = p1.x - 1;
                        lab[p1.x, p1.y] = -1;
                        lab[((p1.x) - 1), p1.y] = 3;
                        memoriaRato.Push(p1);
                    }
                    else if (Labirinto.verificaEsquerda(lab, p1.x, p1.y))
                    {
                        yRato = p1.y - 1;
                        lab[p1.x, p1.y] = -1;
                        lab[p1.x, ((p1.y) - 1)] = 3;
                        memoriaRato.Push(p1);
                    }
                    else if (Labirinto.verificaDireita(lab, p1.x, p1.y))
                    {
                        yRato = p1.y + 1;
                        lab[p1.x, p1.y] = -1;
                        lab[p1.x, ((p1.y) + 1)] = 3;
                        memoriaRato.Push(p1);
                    }
                    else if (Labirinto.verificaBaixo(lab, p1.x, p1.y))
                    {
                        xRato = p1.x + 1;
                        lab[p1.x, p1.y] = -1;
                        lab[((p1.x) + 1), p1.y] = 3;
                        memoriaRato.Push(p1);
                    }
                    else
                    {
                        lab[p1.x, p1.y] = -1;
                        if (memoriaRato.Count != 0)
                        {
                            p1 = memoriaRato.Pop();
                            xRato = p1.x;
                            yRato = p1.y;
                            lab[p1.x, p1.y] = 3;
                        }
                        else {
                            loop = false;
                            Console.WriteLine("Memoria vazia");
                        }                        
                    }
                    
                    Labirinto.imprimeArray(lab);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Queijo encontrado!!");
                    this.xRato = 0;
                    this.yRato = 0;
                    Environment.Exit(0);
                }                              
            }            
        }
        public void Run(){
            Posicao pInicial = sorteiaPosicao();
            andar(pInicial);    
        }
    }    
}
