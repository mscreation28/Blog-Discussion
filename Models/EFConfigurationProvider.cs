using BlogDiscussion2.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogDiscussion2.Models
{
    public class EFConfigurationProvider : ConfigurationProvider
    {
        public EFConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        public Action<DbContextOptionsBuilder> OptionsAction { get; }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

            OptionsAction(builder);

            using (var dbContext = new ApplicationDbContext(builder.Options))
            {
                dbContext.Database.EnsureCreated();
            }
        }
    }
}
