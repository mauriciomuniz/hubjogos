using hubjogos;
using ArquivosVelha;

namespace LogicaVelha
{
    class TelaVelha
    {
        public static void ImprimeVelha(PartidaVelha p)
        {
            Console.WriteLine("+---+---+---+");
            for (int L = 0; L < p.Tab.Linhas; L++)
            {
                for (int C = 0; C < p.Tab.Colunas; C++)
                {
                    Console.Write("|  " + p.Mat[L, C]);
                }
                Console.Write("|");
                Console.WriteLine();
                Console.WriteLine("+---+---+---+");
            }

            Console.WriteLine();
            Console.WriteLine("Rodada número: " + p.Rodada);
            Console.WriteLine();
            Console.WriteLine($"{p.Usuario1.Name} - X vs O - {p.Usuario2.Name}");
            if (!p.Finalizada)
            {
                Console.WriteLine("Aguardando vez do " + p.UsuarioLogado.Name + " - " + p.Simbolo);
                Console.WriteLine();
            }
            else
            {
                if(!p.Velha)
                {
                    Console.WriteLine("Vitória: " + p.UsuarioLogado.Name + " - " + p.Simbolo);
                    p.UsuarioLogado.NumeroVitorias();
                    Console.WriteLine(p.UsuarioLogado.ContadorVitorias);
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("Deu velha"); 
                }
            }
        }

        public static void ImprimeJogada(PartidaVelha p)
        {
            Console.WriteLine($"Vai jogar {p.Simbolo} em qual posicão? ");
            string posicao = Console.ReadLine();
            p.RealizaJogada(posicao);
        }
    }
}