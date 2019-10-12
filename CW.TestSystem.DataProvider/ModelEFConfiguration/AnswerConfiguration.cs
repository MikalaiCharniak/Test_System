using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CW.TestSystem.Model.CoreEntities;

namespace CW.TestSystem.DataProvider.ModelEFConfiguration
{
    public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
    {
        public void Configure(EntityTypeBuilder<Answer> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Question).
                WithMany(x => x.Answers).
                HasForeignKey(x => x.QuestionId);
        }
    }
}
