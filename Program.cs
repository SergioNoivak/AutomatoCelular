using System;
using System.Threading.Tasks;
using System.Collections;
namespace ConsoleApp1
{

     class AutomatoCelular
    {
        int[] celulas;

        public AutomatoCelular()
        {
            this.celulas = new int[10] { 1, 0, 0, 1, 0, 0, 1, 1, 1, 0 };
        }

        string vizinhanca(int i)
        {
           int vizinhoDir = this.celulas[Math.Abs((i - 1) % this.celulas.Length)];
           int vizinhoEsq = this.celulas[(i + 1) % this.celulas.Length];
            return vizinhoDir.ToString() + this.celulas[i].ToString() + vizinhoEsq.ToString();

        }

        int funcaoTransicao(string vizinhanca)
        {
            switch (vizinhanca)
            {
                case "000":
                    return 1;
                    break;
                case "001":
                    return 0;
                    break;
                case "010":
                    return 0;
                    break;
                case "011":
                    return 1;
                    break;
                case "100":
                    return 0;
                    break;

              case "101":
                    return 1;
                    break;
                case "110":
                    return 0;
                    break;
                case "111":
                    return 1;

                    break;
            }
            return -1;

        }
        public void imprimeAutomato()
        {
            Console.Write("{");
               Array.ForEach(this.celulas, element => Console.Write(element+","));
            Console.WriteLine("}");

        }

       public  void iterar()
        {
            Parallel.For(0, 10, i => this.celulas[i] = this.funcaoTransicao(this.vizinhanca(i)));

        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            AutomatoCelular a = new AutomatoCelular();
            for(var i = 0; i < 4; i++)
            {
                Console.Write("t=" + i + " ");
             a.imprimeAutomato();
             a.iterar();
            }
            Console.Write("t=" + 4 + " ");
            a.imprimeAutomato();


        }
    }
}
