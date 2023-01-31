using hubjogos;
using ArquivosVelha;
using LogicaVelha;

namespace hubjogos
{
    class Tela
    {
        
    public static void TelaMenu(Painel hub)
        {
            int opcao;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Login");
                Console.WriteLine("2 - Fazer Cadastro");
                Console.WriteLine("3 - Ranking");
                Console.WriteLine("4 - Todos usuários cadastrados");
                
                Console.Write("Escolha a opção desejada: ");
                opcao = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (opcao)
                {

                    case 1:
                        while (!hub.Logado)
                        {   hub.VerificaNumeroJogadores();
                            try
                            {
                                TelaLogin(hub);
                                Console.Clear();
                            }
                            catch (JogosExceptions e)
                            {
                                Console.WriteLine(e.Message);
                                Console.WriteLine("Realize a operação corretamente");
                                Console.ReadKey();
                                Console.Clear();
                            }
                        }
                        break;
                    case 2:
                        try
                        {
                            TelaCadastro(hub);
                            Console.WriteLine("Pronto! cadastro realizado com sucesso.");
                            Console.WriteLine("Qualquer digito para voltar a tela anterior");
                            Console.ReadKey();
                        }
                        catch (JogosExceptions e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Digite qualquer tecla.");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Ranking dos usuários: ");
                        Console.WriteLine("Ainda não implementado");
                        Console.ReadKey();
                        break;
                    
                    case 4:
                        TelaJogadores(hub);
                        Console.WriteLine("Qualquer digito para voltar a tela anterior");
                        Console.ReadKey();
                        break;
                        
                    default:
                        Console.WriteLine("Número inválido. Qualquer digito para voltar a tela anterior");
                        Console.ReadKey();
                        break;
                }
            } while (opcao < 1 || opcao > 4 || !hub.Logado);
        }

public static void TelaCadastro(Painel hub)
        {
            Console.WriteLine("Cadastro de Usuários");
            Console.Write("Digite o seu nome de usuário: ");
            string name = Console.ReadLine();
            Console.Write("Digite uma senha: ");
            string password = Console.ReadLine();
            Console.WriteLine();
            hub.FazCadastro(name,password);
            Console.WriteLine($"Cadastro feito");

        }

        public static void TelaLogin(Painel hub)
        {
            Console.Write($"Digite o nome de usuário: ");
            string name = Console.ReadLine();
            Console.Write("Digite a sua senha: ");
            string password = Console.ReadLine();
            bool usuarioLogado = hub.FazLogin(name, password);
            if (!usuarioLogado)
            {
                throw new JogosExceptions("Usuário ou senha inválidos.");
            }
            Console.WriteLine("Login efetuado com sucesso!");
            Console.ReadKey();
            Console.Clear();
            if (hub.Usuario1 != null && hub.Usuario2 != null)
            {
                Console.Write("Olá " + hub.Usuario1.Name + " e ");
                Console.WriteLine(hub.Usuario2.Name + " hora do jogo!");
                Console.WriteLine("Aperte qualquer tecla");
                Console.ReadKey();
            }

        }

        public static void TelaJogadores(Painel hub)
        {
            Console.WriteLine("Jogadores cadastrados: ");
            foreach (Usuario u in hub.Usuarios)
            {
                Console.WriteLine($"Usuário: {u.Name} - Partidas ganhas: {u.ContadorVitorias}");
                Console.WriteLine();
            }
        }



        

        public static string TelaMenuJogos(Painel hub)
        {
            
            Console.WriteLine($"Olá {hub.Usuario1.Name} e {hub.Usuario2.Name}! Bem-vindos!");
            Console.WriteLine("Qual jogo vocês querem jogar hoje? ");
            Console.WriteLine("1 - Jogo da velha: ");
            Console.WriteLine("2 - Batalha naval: ");
            Console.Write("Digite a sua opção: ");
            string opcao = Console.ReadLine();
            return opcao; 
        }
    }
}