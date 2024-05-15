using ApplicationForm.Models;

namespace ApplicationForm.DTOs
{
    public class QuestionDTO
    {
        public string Id {  get; set; }
        public string Text { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public string QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }
    }

    public class QuestionRequestModel
    {
        public string Text { get; set; }
        public string QuestionTypeId { get; set; }
        //public QuestionType QuestionType { get; set; }
    }

    public class QuestionResponseModel : BaseResponse<QuestionDTO>
    {
        public QuestionDTO Question { get; set; }

    }

    public class UpdateQuestionRequestModel
    {
        public string Text { get; set; }
        public string QuestionTypeId { get; set; }
        public List<string> Options { get; set; } = new List<string>();
        public QuestionType QuestionType { get; set; }

    }


}
