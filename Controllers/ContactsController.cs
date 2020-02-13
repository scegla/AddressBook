using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Http.Description;
using PhoneBooth.BL;
using PhoneBooth.Dal;
using PhoneBooth.Dal.Interfaces;
using PhoneBooth.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.UI.WebControls;

namespace PhoneBooth.Controllers
{
    public class ContactsController : ApiController
    {
        private BLContact _blContact;
        private ContactsContext cc = new ContactsContext();

        public ContactsController()
        {
            _blContact = new BLContact(cc);
        }

        [System.Web.Http.Route("api/contacts")]
        [ResponseType(typeof(Contact))]
        [System.Web.Http.HttpGet]
        public List<Contact> GetContacts()
        {
            try
            {
                return _blContact.GetAll();
            }
            catch (Exception e)
            {
                throw new Exception("Exception: " + e.Message);
            }
        }

        [System.Web.Http.Route("api/contacts/{id}")]
        [ResponseType(typeof(Contact))]
        [System.Web.Http.HttpGet]
        public Contact GetContact(int id)
        {
            try
            {
                return _blContact.Get(id);
            }
            catch (Exception e)
            {
                throw new Exception("Exception: " + e.Message);
            }
        }

        [System.Web.Http.Route("api/contacts/AddContact")]
        [ResponseType(typeof(Contact))]
        [System.Web.Http.HttpPost]
        public Contact AddContact(Contact contact)
        {
            try
            {
                _blContact.Add(contact);

                return contact;
            }
            catch (Exception e)
            {
                throw new Exception("Exception: " + e.Message);
            }
        }

        [ResponseType(typeof(Contact))]
        [System.Web.Http.Route("api/contacts/Delete")]
        [System.Web.Http.HttpDelete]
        public void DeleteContact(int id)
        {
            try
            {
                _blContact.Delete(id);
            }
            catch (Exception e)
            {
                throw new Exception("Exception: " + e.Message);
            }
        }

        [System.Web.Http.Route("api/contacts/EditContact")]
        [ResponseType(typeof(Contact))]
        [System.Web.Http.HttpPost]
        public Contact EditContact(Contact contact)
        {
            try
            {
                _blContact.Update(contact);

                return contact;
            }
            catch (Exception e)
            {
                throw new Exception("Exception: " + e.Message);
            }
        }

        [System.Web.Http.Route("api/contacts/SearchContact")]
        [ResponseType(typeof(Contact))]
        [System.Web.Http.HttpPost]
        public List<Contact> SearchContact(ContactSearch contact)
        {
            try
            {
                return _blContact.Search(contact);
            }
            catch (Exception e)
            {
                throw new Exception("Exception: " + e.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cc.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}