namespace ApplicationForm.Models
{
    public class Form : BaseModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string CurrentAddress { get; set; }
        public string IdNumber {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender {  get; set; }
        public string ProgramTittle { get; set; }
        public string ProgramDescription { get; set; }
        //public List<Question> Question { get; set; } = new List<Question>();
        
    }
}
