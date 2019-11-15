using CW.TestSystem.Model.CoreEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace CW.TestSystem.DataProvider.ModelEFConfiguration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.Answers).
                WithOne(x => x.Question).
                HasForeignKey(x => x.QuestionId).
                OnDelete(DeleteBehavior.Cascade);
        }
    }
}