using PhoneBooth.Models;

namespace PhoneBooth.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PhoneBooth.Models.ContactsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(PhoneBooth.Models.ContactsContext context)
        {
            context.Contacts.AddOrUpdate(x => x.Id,
                new Contact() { Id = 1, FirstName = "Jane", LastName = "Austen", PhoneNum = "031123456", Address = "Hrusica 1" },
                new Contact() { Id = 2, FirstName = "Charles", LastName = "Dickens", PhoneNum = "041123455", Address = "Podgrad 23" },
                new Contact() { Id = 3, FirstName = "Miguel", LastName = "Cervantes", PhoneNum = "0401234556", Address = "Kozina 5" }
            );
        }
    }
}
