using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.QuestionService
{
    public interface IQuestionService
    {
        Task<ServiceResponse<Question>> AddQuestion(Question newQuestion);
        Task<ServiceResponse<Question>> GetQuestionById(int id);
        Task<ServiceResponse<Question>> UpdateQuestion(Question updatedQuestion);
        Task<ServiceResponse<Question>> DeleteQuestion(int id);
        Task<ServiceResponse<List<Question>>> GetQuestionsForSubject(string subject);
    }
}