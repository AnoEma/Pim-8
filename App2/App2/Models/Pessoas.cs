using SQLite;

namespace App2.Models
{
    public class Pessoas
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        //public Endereco Enderecos { get; set; }
        //public Telefone Telefones { get; set; }
        public bool Ativo { get; set; }

        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int Cep { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public string DDD { get; set; }
        public string NumeroTelefone { get; set; }
        public TipoTelefone Telefones { get; set; }
    }
}