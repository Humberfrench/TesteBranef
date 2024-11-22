namespace Teste.Branef.Domain.Entity
{
    public class Cliente
    {
        public Cliente()
        {
            Nome = string.Empty;
            Porte = string.Empty;
            Telefone = string.Empty;
            Email = string.Empty;
        }
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Porte { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

    }
}
