namespace ClientEx1Web06
{
    public class Client
    {
        public string Cpf { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
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
