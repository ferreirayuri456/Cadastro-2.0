using System;

namespace Cadastro.model
{
    class Pessoa
    {
        public Pessoa(int id, string nome, long cpf, Endereco endereco, Telefone telefones)
        {
            this.Id = id;
            this.Nome = nome;
            this.Cpf = cpf;
            this.Endereco = endereco;
            this.Telefones = telefones;
        }

        private int Id { get; set; }
        private String Nome { get; set; }
        private long Cpf { get; set; }
        private Endereco Endereco { get; set; }
        private Telefone Telefones { get; set; }






    }
}
