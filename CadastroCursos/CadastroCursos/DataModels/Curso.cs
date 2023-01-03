namespace CadastroCursos.DataModels
{
    public class Curso
    {
        public int CursoId { get; set; } 
        public string Nome_curso { get; set; }
        public string Turno_curso { get; set; }
        public int Versao_curso { get; set; }
        public int Conceito_mec { get; set; }
        public string Nome_unidade { get; set; }
        public int? EnderecoId { get; set; }
       
        public virtual Endereco? endereco { get; set; }

    }
}
