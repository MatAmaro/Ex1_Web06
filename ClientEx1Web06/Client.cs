using System.ComponentModel.DataAnnotations;

namespace ClientEx1Web06
{
    public class Client
    {
        [StringLength(11, ErrorMessage = "Só é possível inserir 11 caracteres")]
        [MinLength(11, ErrorMessage = "Só é possível inserir 11 caracteres")]
        [Required]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Name { get; set; }
        [Required(ErrorMessage = "É necessário inserir uma data valida")]
        public DateTime BirthDate { get; set; }
        [Range(15, 120)]
        public int Age => AgeClaculator();


        private int AgeClaculator()
        {
            int yearsDiference = DateTime.Now.Year - BirthDate.Year;
            int age;
            DateTime birthday = BirthDate.AddYears(yearsDiference);
            if (DateTime.Now >= birthday)
            {
                age = DateTime.Now.Year - BirthDate.Year;
            }
            else
            {
                age = DateTime.Now.Year - BirthDate.Year - 1;
            }
            return age;
        }

        public Client(string cpf, string name, DateTime birthDate)
        {
            Cpf = cpf;
            Name = name;
            BirthDate = birthDate;

        }
    }
}
