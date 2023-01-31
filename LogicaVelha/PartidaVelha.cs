using hubjogos;
using ArquivosVelha;
using System.Text.Json;
using System.Xml.Linq;

namespace LogicaVelha
{
    class PartidaVelha
    {
        public Tabuleiro Tab { get; private set; }
        public List<Usuario> Usuarios { get; private set; }
        public Usuario Usuario1 { get; private set; }
        public Usuario Usuario2 { get; private set; }
        public Usuario UsuarioLogado { get; private set; }
        public string Simbolo { get; private set; }
        public bool Finalizada { get; private set; }
        public bool Velha { get; private set; }
        public string[,] Mat { get; private set; }
        public int Rodada { get; private set; }
        
        public PartidaVelha(Painel hub)
        {
            Tab = new Tabuleiro(3, 3);
            Mat = new string[Tab.Linhas, Tab.Colunas];
            
            Usuario1 = hub.Usuario1;
            Usuario2 = hub.Usuario2;
            UsuarioLogado = Usuario1;
            Simbolo = "X";
            Finalizada = false;
            Rodada = 1;
            EnumeraVelha();
        }



        public void RealizaJogada(string posicao)
        {
            ValidaJogada(posicao);
            for (int L = 0; L < Tab.Linhas; L++)
            {
                for (int C = 0; C < Tab.Colunas; C++)
                {
                    if (Mat[L, C] == posicao)
                    {
                        Mat[L, C] = Simbolo;
                    }
                }
            }
            if (FimDeJogo())
            {
                return;
            }
            MudarJogador();
            Rodada++;
        }

        private void ValidaJogada(string posicao)
        {
            int aux;
            int.TryParse(posicao, out aux);
            for (int L = 0; L < Tab.Linhas; L++)
            {
                for (int C = 0; C < Tab.Colunas; C++)
                {
                    if (aux < 1 || aux > 9)
                    {
                        throw new JogosExceptions("Posicao inválida! Tente novamente");
                    }
                    if (Mat[L, C] == posicao)
                    {
                        return;
                    }                    
                }
            }
            throw new JogosExceptions("Já existe um símbolo nessa posição!");

        }

        private void MudarJogador()
        {
            if (Simbolo == "X")
            {
                Simbolo = "O";
                UsuarioLogado = Usuario2;
            }
            else
            {
                Simbolo = "X";
                UsuarioLogado = Usuario1;
            }
        }

        private bool FimDeJogo()
        {
            // vencendo em alguma linha:
            for (int L = 0; L < 3; L++)
            {
                if (Mat[L, 0] == Mat[L, 1] && Mat[L, 1] == Mat[L, 2])
                {
                    Finalizada = true;
                    
                    return true;
                }
            }
            // vencendo em alguma coluna: 
            for (int C = 0; C < 3; C++)
            {
                if (Mat[0, C] == Mat[1, C] && Mat[1, C] == Mat[2, C])
                {
                    Finalizada = true;
                    
                    return true;
                }
            }

            // vencendo em alguma diagonal: Diagonal principal
            if (Mat[0, 0] == Mat[1, 1] && Mat[1, 1] == Mat[2, 2])
            {
                Finalizada = true;
                
                return true;
            }
            // diagonal secundária
            if (Mat[0, 2] == Mat[1, 1] && Mat[1, 1] == Mat[2, 0])
            {
                Finalizada = true;
                
                return true;
            }
            int contVelha = 0;
            for (int L = 0; L < 3; L++)
            {
                for (int C = 0; C < 3; C++)
                {
                    if (Mat[L, C] != "X" && Mat[L, C] != "O")
                    {
                        contVelha++;
                    }
                }
            }

            if (contVelha == 0)
            {
                Velha = true; 
                Finalizada = true;
                return true;
            }
            return false;
        }
        private void EnumeraVelha()
        {
            int cont = 1;
            for (int L = 0; L < Tab.Linhas; L++)
            {
                for (int C = 0; C < Tab.Colunas; C++)
                {
                    Mat[L, C] = cont.ToString();
                    cont++;
                }
            }
        }

        
        
    }
}