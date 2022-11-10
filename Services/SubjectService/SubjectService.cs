using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Services.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private readonly DataContext _context;

        public SubjectService(DataContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<Subject>> AddSubject(Subject newSubject)
        {
            var response = new ServiceResponse<Subject>();
            response.Message = "blubb";
            _context.Subjects.Add(newSubject);
            await _context.SaveChangesAsync();
            return response;
        }

        public async Task<ServiceResponse<Subject>> DeleteSubject(int id)
        {
            var response = new ServiceResponse<Subject>();
            try
            {
                 Subject subject = await _context.Subjects.FirstOrDefaultAsync(e => e.Id == id);
                 if(subject != null)
                 {
                    _context.Subjects.Remove(subject);
                    await _context.SaveChangesAsync();
                 }
                 else
                 {
                    response.Success = false;
                    response.Message = "Subject not found";
                 }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            
            return response; 
        }

        public async Task<ServiceResponse<List<Subject>>> GetAllSubjects()
        {
            var response = new ServiceResponse<List<Subject>>();
            try
            {
                var dbSubjects = await _context.Subjects.ToListAsync();
                response.Data = dbSubjects;
                if(response.Data.Count == 0)
                {
                    response.Message = "no subjects yet";
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
    }
}