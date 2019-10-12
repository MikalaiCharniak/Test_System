using CW.TestSystem.Model.RelationValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CW.TestSystem.DataProvider.ModelEFConfiguration
{
    public class QuestionTagConfiguration : IEntityTypeConfiguration<QuestionTag>
    {
        public void Configure(EntityTypeBuilder<QuestionTag> builder)
        {
            builder.HasKey(x => new { x.QuestionId, x.TagId });

            builder.HasOne(x => x.Question).
                WithMany(x => x.Tags).
                HasForeignKey(x => x.QuestionId);

            builder.HasOne(x => x.Tag).
                WithMany(x => x.Questions).
                HasForeignKey(x => x.TagId);
        }
    }
}
