using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using EF.Core.Data;

namespace EF.Data.Mapping
{
   public class  BookMap : EntityTypeConfiguration<Car>
    {
       public BookMap()
       {
           HasKey(t => t.ID);
           Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           Property(t => t.Model).IsRequired();
           Property(t => t.Make).IsRequired();
           
           ToTable("Cars");
       }
    }
}
