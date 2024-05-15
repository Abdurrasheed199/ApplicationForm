namespace ApplicationForm.DTOs
{
    public class FormDTO
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string CurrentAddress { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ProgramTittle { get; set; }
        public string ProgramDescription { get; set; }
    }

    public class AnswerQuestionRequestModel
    {
        public string QuestionId { get; set; }
        public string Answer { get; set; }
    }
    public class FormRequestModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Nationality { get; set; }
        public string CurrentAddress { get; set; }
        public string IdNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string ProgramTittle { get; set; }
        public string ProgramDescription { get; set; }
        public List<AnswerQuestionRequestModel> Answers { get; set; } = new List<AnswerQuestionRequestModel>();
       
        
    }

    public class FormResponseModel : BaseResponse<FormDTO>
    {
        public FormDTO Form { get; set; }
    }

}
