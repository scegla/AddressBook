using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;
using System.Linq;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Ajax.Utilities;
using PhoneBooth.Dal.Interfaces;
using PhoneBooth.Models;

namespace PhoneBooth.Dal
{
    public class DalContact : IDalContact
    {
        private ContactsContext db;

        public DalContact(ContactsContext context)
        {
            db = context;
        }

        public List<Contact> GetAll()
        {
            return db.Contacts.ToList();
        }

        public List<Contact> Search(ContactSearch search)
        {
            try
            {
                if (search != null)
                {
                    if (search.Id > 0)
                    {
                        return db.Contacts.Where(x => x.Id == search.Id).ToList();
                    }

                    return db.Contacts.Where(p =>
                            !p.FirstName.Equals("") && p.FirstName.ToLower().Contains(search.FirstName) &&
                            !p.LastName.Equals("") && p.LastName.ToLower().Contains(search.LastName) &&
                            !p.PhoneNum.Equals("") && p.PhoneNum.ToLower().Contains(search.PhoneNum) &&
                            !p.Address.Equals("") && p.Address.ToLower().Contains(search.Address))
                        .ToList();
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.ToString());
            }
            return null;
        }

        public Contact Get(int id)
        {
            if (ContactExists(id))
            {
                var cont = db.Contacts.Find(id);
                if (cont == null)
                {
                    throw new Exception($"Contact with id: {id} doesn't exists");
                }
                return cont;
            }
            return null;
        }

        public void Add(Contact contact)
        {
            if (ContactExists(contact.Id))
            {
                throw new Exception(String.Format("Contact with id: {0} already exists", contact.Id));
            }

            if (PhoneNumExists(contact.PhoneNum))
            {
                throw new Exception(String.Format("Contact with phoneNum: {0} already exists", contact.PhoneNum));
            }

            db.Contacts.Add(contact);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                throw new Exception(String.Format("Contact with id: {0} doesn't exists", id));
            }

            db.Contacts.Remove(contact);
            db.SaveChanges();
            
        }

        public void Update(Contact contact)
        {
            if (!ContactExists(contact.Id))
            {
                throw new Exception(String.Format("Contact with id: {0} doesn't exists", contact.Id));
            }

            db.Contacts.AddOrUpdate(contact);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        private bool ContactExists(int id)
        {
            return db.Contacts.Count(e => e.Id == id) > 0;
        }

        private bool PhoneNumExists(string phoneNum)
        {
            return db.Contacts.Count(e => e.PhoneNum == phoneNum) > 0;
        }
    }
}