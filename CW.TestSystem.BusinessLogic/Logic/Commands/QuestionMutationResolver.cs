using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using HotChocolate;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CW.TestSystem.BusinessLogic.Infrastructure.RelationModels;
using System.Linq;

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

        public async Task<bool> AddTagsAsync([Service] TestSystemDbContext context, TagQuestionRelation tagQuestion)
        {
            tagQuestion.QuestionsTags.ToList().ForEach(x => x.QuestionId = tagQuestion.QuestionId);
            context.QuestionTag.AddRange(tagQuestion.QuestionsTags);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveTagsAsync([Service] TestSystemDbContext context, TagQuestionRelation tagQuestion)
        {
            tagQuestion.QuestionsTags.ToList().ForEach(x => x.QuestionId = tagQuestion.QuestionId);
            context.QuestionTag.RemoveRange(tagQuestion.QuestionsTags);
            await context.SaveChangesAsync();
            return true;
        }
    }
}