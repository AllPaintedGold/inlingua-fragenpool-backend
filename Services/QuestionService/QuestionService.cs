using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;
// write string for json column like this: "{ \"FirstName\":\"chh\",\"LastName\":\"Trivedi\",\"huch\":{\"a\",\"b\",\"c\"} }"
namespace backend.Services.QuestionService
{
    public class QuestionService : IQuestionService
    {
        private readonly DataContext _context;

        public QuestionService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Question>> AddQuestion(Question newQuestion)
        {
            var serviceResponse = new ServiceResponse<Question>();
            try
            {
                _context.Questions.Add(newQuestion);
                await _context.SaveChangesAsync();
                serviceResponse.Message = "succesfully added question";
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<Question>> DeleteQuestion(int id)
        {
            var response = new ServiceResponse<Question>();
            try
            {
                 Question question = await _context.Questions.FirstOrDefaultAsync(e => e.Id == id);
                 if(question != null)
                 {
                    _context.Questions.Remove(question);
                    await _context.SaveChangesAsync();
                 }
                 else
                 {
                    response.Success = false;
                    response.Message = "Question not found";
                 }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response; 
        }

        public async Task<ServiceResponse<Question>> GetQuestionById(int id)
        {
            var serviceResponse = new ServiceResponse<Question>();
            try
            {
                var dbQuestion = await _context.Questions.FirstOrDefaultAsync(e => e.Id == id );
                if(dbQuestion != null)
                {
                    serviceResponse.Data = dbQuestion;
                }
                else
                {
                    serviceResponse.Message = "Question not found";
                    serviceResponse.Success = false;
                }
            
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Success = false;
            }
            return serviceResponse;
            
        }

        public async Task<ServiceResponse<List<Question>>> GetQuestionsForSubject(string subject)
        {
            var response = new ServiceResponse<List<Question>>();
            try
            {
                var dbQuestions = await _context.Questions
                    .Where(e => e.Subject == subject)
                    .ToListAsync();
                response.Data = dbQuestions;
                if(response.Data.Count == 0)
                {
                    response.Message = "no questions yet";
                    response.Success = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            return response;

        }

        public async Task<ServiceResponse<Question>> UpdateQuestion(Question updatedQuestion)
        {
            var response = new ServiceResponse<Question>();

            try
            {
                var dbQuestion = await _context.Questions.FirstOrDefaultAsync(e => e.Id == updatedQuestion.Id );
                dbQuestion.DateOfLastChange = DateTime.Now;
                dbQuestion.LastChangedBy = "User";
                dbQuestion.Subject = updatedQuestion.Subject;
                dbQuestion.TypeSpecifics = updatedQuestion.TypeSpecifics;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Success = false;
            }
            
            return response;
        }

    }
}