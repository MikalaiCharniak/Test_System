using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CW.TestSystem.Model.RelationValueObjects;

namespace CW.TestSystem.DataProvider.ModelEFConfiguration
{
    public class TestQuestionConfiguration : IEntityTypeConfiguration<TestQuestion>
    {
        public void Configure(EntityTypeBuilder<TestQuestion> builder)
        {
            builder.HasOne(x => x.Test).
                WithMany(x => x.Questions).
                HasForeignKey(x => x.TestId);

            builder.HasOne(x => x.Question).
                WithMany(x => x.Tests).
                HasForeignKey(x => x.QuestionId);
        }
    }
}
