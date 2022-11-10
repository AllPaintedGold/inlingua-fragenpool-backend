using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Models;

namespace backend.Services.SubjectService
{
    public interface ISubjectService
    {
        Task<ServiceResponse<Subject>> AddSubject(Subject newSubject);
        Task<ServiceResponse<Subject>> DeleteSubject(int id);
        Task<ServiceResponse<List<Subject>>> GetAllSubjects();
    }
}