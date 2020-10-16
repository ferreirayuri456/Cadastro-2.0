namespace Cadastro.model
{
    internal class TipoTelefone
    {

        private int Id { get; set; }
        private string Tipo { get; set; }

        public TipoTelefone(int id, string tipo)
        {
            this.Id = id;
            this.Tipo = tipo;
        }
    }
}