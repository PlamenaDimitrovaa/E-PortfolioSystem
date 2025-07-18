﻿using E_PortfolioSystem.Data.Models;
using E_PortfolioSystem.Web.ViewModels.Subject;

namespace E_PortfolioSystem.Services.Data.Interfaces
{
    public interface ISubjectService
    {
        Task<IEnumerable<SubjectViewModel>> GetSubjectsByStudentAsync(string studentId);
        Task<SubjectDetailsViewModel?> GetSubjectDetailsAsync(Guid subjectId, Guid studentId);
        Task UpdateSubjectAttachedDocumentAsync(Guid subjectId, Guid studentId, string fileName, string filePath);
        Task<Subject?> GetSubjectWithDocumentAsync(Guid subjectId, Guid studentId);
        Task<IEnumerable<TeacherSubjectViewModel>> GetSubjectsByTeacherAsync(string teacherId);
        Task<bool> IsTeacherOfSubjectAsync(string teacherId, string subjectId);
        Task CreateAsync(SubjectFormModel model, string teacherId);
        Task UpdateAsync(SubjectFormModel model, string teacherId);
        Task DeleteSubjectAsync(Guid subjectId);
        Task<IEnumerable<SubjectViewModel>> GetSubjectsByTeacherAndStudentAsync(Guid teacherId, Guid studentId);
        Task AddProjectToSubjectAsync(SubjectProjectFormModel model, string userId);
        Task<TeacherSubjectDetailsViewModel?> GetTeacherSubjectDetailsAsync(Guid subjectId);
        Task<StudentSubjectDetailsViewModel?> GetStudentSubjectDetailsAsync(Guid subjectId, Guid studentId);
    }
}
