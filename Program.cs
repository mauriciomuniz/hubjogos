using hubjogos;
using ArquivosVelha;
using LogicaVelha;

namespace hubjogos
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 11111;
            do{
                Painel hub = new Painel();
            while (!hub.Logado)
            {
                Console.Clear();
                Tela.TelaMenu(hub);
            }
            Console.Clear();
            switch (Tela.TelaMenuJogos(hub))
            {
                case "1":
                    PartidaVelha p = new PartidaVelha(hub);
                    do
                    {
                        try
                        {
                            Console.Clear();
                            TelaVelha.ImprimeVelha(p);
                            TelaVelha.ImprimeJogada(p);
                        }
                        catch (JogosExceptions e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Digite qualquer tecla para tentar novamente");
                            Console.ReadKey();
                        }
                    }
                    while (!p.Finalizada);
                    Console.Clear();
                    TelaVelha.ImprimeVelha(p); 
                    break;
                case "2":
                    Console.WriteLine("Batalha naval aqui");
                    break;
                case "3":
                    opcao =99999;
                    break;
                default:
                    Console.WriteLine("Opcao inválida");
                    break;
            }

            }
            while(opcao>0);
            

        }
    }
}