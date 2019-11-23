using HotChocolate;
using Microsoft.EntityFrameworkCore;
using CW.TestSystem.DataProvider.DbInfrastracture;
using CW.TestSystem.Model.CoreEntities;
using System.Threading.Tasks;
using System;
using System.Linq;
using CW.TestSystem.BusinessLogic.Infrastructure.RelationModels;

namespace CW.TestSystem.BusinessLogic.Logic.Commands
{
    public class TestMutationResolver
    {
        public async Task<Test> CreateTestAsync([Service] TestSystemDbContext context, Test testInput)
        {

            testInput.CreateDate = DateTime.Now;
            var test = context.Tests.Add(testInput);
            await context.SaveChangesAsync();
            return test.Entity;
        }

        public async Task<bool> AddQuestionsAsync([Service] TestSystemDbContext context, TestQuestionRelation testQuestions)
        {
            testQuestions.TestsQuestions.ToList().ForEach(x => x.TestId = testQuestions.TestId);
            context.TestQuestion.AddRange(testQuestions.TestsQuestions);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveQuestionsAsync([Service] TestSystemDbContext context, TestQuestionRelation testQuestions)
        {
            testQuestions.TestsQuestions.ToList().ForEach(x => x.TestId = testQuestions.TestId);
            context.TestQuestion.RemoveRange(testQuestions.TestsQuestions);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<Test> UpdateTestAsync([Service] TestSystemDbContext context, Test updateTest)
        {
            var test = context.Tests.Update(updateTest);
            await context.SaveChangesAsync();
            return test.Entity;
        }

        public async Task<bool> DeleteTestAsync([Service] TestSystemDbContext context, Guid id)
        {
            var state = context.Tests.Remove(await context.Tests.FindAsync(id)).State;
            await context.SaveChangesAsync();
            var result = state == EntityState.Deleted ? true : false;
            return result;
        }

        public async Task<bool> AddTagsAsync([Service] TestSystemDbContext context, TagTestRelation tagTest)
        {
            tagTest.TestsTags.ToList().ForEach(x => x.TestId = tagTest.TestId);
            context.TestTag.AddRange(tagTest.TestsTags);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveTagsAsync([Service] TestSystemDbContext context, TagTestRelation tagTest)
        {
            tagTest.TestsTags.ToList().ForEach(x => x.TestId = tagTest.TestId);
            context.TestTag.RemoveRange(tagTest.TestsTags);
            await context.SaveChangesAsync();
            return true;
        }
    }
}