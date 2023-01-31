using hubjogos;
using LogicaVelha;
using System.Text.Json;

namespace ArquivosVelha
{
    class Painel
    {
        public List<Usuario> Usuarios { get; private set; }
        public Usuario Usuario1 { get; private set; }
        public Usuario Usuario2 { get; private set; }
        public Usuario UsuarioLogado { get; private set; }
        public bool Logado { get; private set; }
        public string fileName = "usuarios.json";

        public Painel()
        {
            FileInfo fi = new FileInfo(fileName);
            string deseriJson = File.ReadAllText(fileName);
            if (fi.Length == 0)
            {
                Usuarios = new List<Usuario>();
            }
            else
            {
                Usuarios = JsonSerializer.Deserialize<List<Usuario>>(deseriJson)!;
            } 
            
            Logado = false;
        }

        

        public void FazCadastro(string name, string password)
        {
            if (Usuarios.Exists(x => x.Name == name))
            {
                throw new JogosExceptions($"O usuário {name} já existe. Escolha outro nome de usuário.");
            }
            else
            {
                Usuario usuario = new Usuario(name, password);
                Usuarios.Add(usuario);
                var options = new JsonSerializerOptions { WriteIndented = true };
                string jsonString = JsonSerializer.Serialize(Usuarios, options);
                File.WriteAllText(fileName, jsonString);
            }

        }

        public bool FazLogin(string name, string senha)
        {
            bool logarConta = Usuarios.Exists(x => x.Name == name && x.Password == senha);

            if (logarConta)
            {
                if (Usuario1 == null)
                {
                    Usuario1 = Usuarios.Find(x => x.Name == name && x.Password == senha);
                    UsuarioLogado = Usuario1;
                }
                else
                {
                    if (Usuarios.Find(x => x.Name == name && x.Password == senha) == Usuario1)
                    {
                        throw new JogosExceptions("Esse usuário já está logado.");
                    }
                    else
                    {
                        Usuario2 = Usuarios.Find(x => x.Name == name && x.Password == senha);
                        Logado = true;
                    }
                }
                return true;
            }
            return false;
        }

        
        public void AtualizarJson()
        {
            foreach (Usuario u in Usuarios)
                {
                    if (u == UsuarioLogado)
                    { 
                        u.NumeroVitorias();                          
                    }
                }
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Usuarios, options);
            File.WriteAllText(fileName, jsonString);
        }

        

        

        public void VerificaNumeroJogadores()
        {
            if(Usuarios.Count < 2)
            {
                throw new JogosExceptions("Você precisa cadastrar no mínimo dois usuários para logar no Painel"); ; 
            }
        }

        
    }
}