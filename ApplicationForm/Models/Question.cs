namespace ApplicationForm.Models
{
    public class Question : BaseModel
    {
        public string Text { get; set; }

        public string? Answer { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public string QuestionTypeId {  get; set; }
        public QuestionType QuestionType { get; set; }
        //public string FormId {  get; set; }
        //public Form Form { get; set; }

    }
}
