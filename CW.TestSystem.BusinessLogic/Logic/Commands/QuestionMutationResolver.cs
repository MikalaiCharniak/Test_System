using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using HotChocolate;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CW.TestSystem.BusinessLogic.Logic.Commands
{
    public class QuestionMutationResolver
    {
        public async Task<Question> CreateQuestionAsync([Service] TestSystemDbContext context, Question questionInput)
        {
            var question = await context.Questions.AddAsync(questionInput);
            await context.SaveChangesAsync();
            return question.Entity;
        }

        public async Task<Question> UpdateQuestionAsync([Service] TestSystemDbContext context, Question updateQuestion)
        {
            var question = context.Update(updateQuestion);
            await context.SaveChangesAsync();
            return question.Entity;
        }

        public async Task<bool> DeleteQuestionAsync([Service] TestSystemDbContext context, Guid id)
        {
            var state = context.Questions.Remove(await context.Questions.FindAsync(id)).State;
            await context.SaveChangesAsync();
            var result = state == EntityState.Deleted ? true : false;
            return result;
        }
    }
}