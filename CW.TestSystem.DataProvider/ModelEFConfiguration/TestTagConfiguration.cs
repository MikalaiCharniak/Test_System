using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CW.TestSystem.Model.RelationValueObjects;

namespace CW.TestSystem.DataProvider.ModelEFConfiguration
{
    public class TestTagConfiguration : IEntityTypeConfiguration<TestTag>
    {
        public void Configure(EntityTypeBuilder<TestTag> builder)
        {
            builder.HasKey(x => new { x.TestId, x.TagId });

            builder.HasOne(x => x.Test).
                WithMany(x => x.Tags).
                HasForeignKey(x => x.TestId);

            builder.HasOne(x => x.Tag).
                WithMany(x => x.Tests).
                HasForeignKey(x => x.TagId);
        }
    }
}
