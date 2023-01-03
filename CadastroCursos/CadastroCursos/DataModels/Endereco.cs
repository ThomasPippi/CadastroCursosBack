using System.Security.Policy;

namespace CadastroCursos.DataModels
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public int cep { get; set; }
        public string Nome_rua { get; set; }
        public string Bairro { get; set; }
        public int numero { get; set; }
    }
}
