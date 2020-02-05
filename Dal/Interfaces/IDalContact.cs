using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PhoneBooth.Models;

namespace PhoneBooth.Dal.Interfaces
{
    public interface IDalContact
    {
        List<Contact> GetAll();
        List<Contact> Search(ContactSearch search);
        Contact Get(int id);
        void Add(Contact contact);
        void Delete(int id);
        void Update(Contact contact);

        void Dispose();
    }
}