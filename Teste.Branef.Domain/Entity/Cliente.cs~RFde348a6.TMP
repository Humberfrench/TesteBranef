using Dietcode.Core.DomainValidator;
using Dietcode.Core.Lib;

using System.Text.RegularExpressions;

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
            errors = new List<ValidationError>();
        }

        //props domains
        private readonly List<ValidationError> errors;
        public IList<ValidationError> Erros => errors;
        public bool Valid => !errors.Any((ValidationError vr) => vr.Erro);

        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Porte { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public bool IsNew() => ClienteId == 0;

        public void Validate()
        {
            if (!IsNomeValido())
            {
                errors.Add(new ValidationError("Nome é inválido"));
            }
            if (!IsEmailValido())
            {
                errors.Add(new ValidationError("O email é inválido"));
            }
            if (!IsTelefoneValido())
            {
                errors.Add(new ValidationError("Telefone é inválido"));
            }
            if (!IsPorteValido())
            {
                errors.Add(new ValidationError("Porte inválido"));
            }
        }
        private bool IsNomeValido()
        {
            return !Nome.IsNullOrEmptyOrWhiteSpace();
        }

        private bool IsEmailValido()
        {
            if (Email.IsNullOrEmptyOrWhiteSpace())
            {
                return false; // Email não pode ser nulo ou vazio
            }

            // Expressão regular para validar o formato do email
            var emailRegex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            return emailRegex.IsMatch(Email);
        }

        private bool IsTelefoneValido()
        {
            if (Telefone.IsNullOrEmptyOrWhiteSpace())
            {
                return false; // Email não pode ser nulo ou vazio
            }

            // Expressão regular para validar o formato do telefone
            // Exemplo: (XX) XXXXX-XXXX ou (XX) XXXX-XXXX
            var telefoneRegex = new Regex(@"^\(\d{2}\) \d{4,5}-\d{4}$");
            return telefoneRegex.IsMatch(Telefone);
        }

        private bool IsPorteValido()
        {
            if (Porte.IsNullOrEmptyOrWhiteSpace())
            {
                return false; // Email não pode ser nulo ou vazio
            }
            return (Porte == "P" || Porte == "M"  || Porte == "G");
        }
    }
}
