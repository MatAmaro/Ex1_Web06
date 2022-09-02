using System.ComponentModel.DataAnnotations;

namespace ClientEx1Web06
{
    public class Client
    {
        public long Id { get; set; }

        [StringLength(11, ErrorMessage = "Só é possível inserir 11 caracteres", MinimumLength = 11)] 
        [Required]
        public string cpf { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "É necessário inserir uma data valida")]
        public DateTime DataNascimento { get; set; }

        [Range(15, 120)]
        public int Idade => AgeCalculator();

        public Client()
        {
        }

        public Client(long id, string cpf, string nome, DateTime datanascimento, int age)
        {
            Id = id;
            this.cpf = cpf;
            Nome = nome;
            DataNascimento = datanascimento;
        }

        private int AgeCalculator()
        {
            int yearsDiference = DateTime.Now.Year - DataNascimento.Year;
            int age;
            DateTime birthday = DataNascimento.AddYears(yearsDiference);
            if (DateTime.Now >= birthday)
            {
                age = DateTime.Now.Year - DataNascimento.Year;
            }
            else
            {
                age = DateTime.Now.Year - DataNascimento.Year - 1;
            }
            return age;
        }
    }
}
