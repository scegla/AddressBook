using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
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
            if (search != null)
            {
                if (search.Id > 0)
                {
                    return db.Contacts.Where(x => x.Id == search.Id).ToList();
                }
                string sqlQueryWhere = "";
                if (!String.IsNullOrEmpty(search.Address))
                {
                    sqlQueryWhere += String.Format("ADDRESS LIKE '{0}%'", search.Address);
                }
                if (!String.IsNullOrEmpty(search.FirstName))
                {
                    if (sqlQueryWhere != "")
                    {
                        sqlQueryWhere += " OR ";
                    }
                    sqlQueryWhere += String.Format("FIRSTNAME LIKE '{0}%'", search.FirstName);
                }
                if (!String.IsNullOrEmpty(search.LastName))
                {
                    if (sqlQueryWhere != "")
                    {
                        sqlQueryWhere += " OR ";
                    }
                    sqlQueryWhere += String.Format("LASTNAME LIKE '{0}%'", search.LastName);
                }
                if (!String.IsNullOrEmpty(search.Address))
                {
                    if (sqlQueryWhere != "")
                    {
                        sqlQueryWhere += " OR ";
                    }
                    sqlQueryWhere += String.Format("ADDRESS LIKE '{0}%'", search.Address);
                }
                if (!String.IsNullOrEmpty(search.PhoneNum))
                {
                    if (sqlQueryWhere != "")
                    {
                        sqlQueryWhere += " OR ";
                    }
                    sqlQueryWhere += String.Format("PHONENUM LIKE '{0}%'", search.PhoneNum);
                }

                if (sqlQueryWhere != "")
                {
                    return db.Contacts.SqlQuery(String.Format("SELECT * FROM CONTACTS WHERE {0}", sqlQueryWhere)).ToList();
                }
                return db.Contacts.ToList();
            }

            return null;
        }

        public Contact Get(int id)
        {
            if (ContactExists(id))
            {
                return db.Contacts.Find(id);
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