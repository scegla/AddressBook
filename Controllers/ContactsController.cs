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
            return _blContact.GetAll();
        }

        [System.Web.Http.Route("api/contacts/{id}")]
        [ResponseType(typeof(Contact))]
        [System.Web.Http.HttpGet]
        public Contact GetContact(int id)
        {
            return _blContact.Get(id);
        }

        [System.Web.Http.Route("api/contacts/AddContact")]
        [ResponseType(typeof(Contact))]
        [System.Web.Http.HttpPost]
        public Contact AddContact(Contact contact)
        {
            _blContact.Add(contact);

            return contact;
        }

        [ResponseType(typeof(Contact))]
        [System.Web.Http.Route("api/contacts/Delete")]
        [System.Web.Http.HttpDelete]
        public void DeleteContact(int id)
        {
            _blContact.Delete(id);
        }

        [System.Web.Http.Route("api/contacts/EditContact")]
        [ResponseType(typeof(Contact))]
        [System.Web.Http.HttpPost]
        public Contact EditContact(Contact contact)
        {
            _blContact.Update(contact);

            return contact;
        }

        [System.Web.Http.Route("api/contacts/SearchContact")]
        [ResponseType(typeof(Contact))]
        [System.Web.Http.HttpPost]
        public List<Contact> SearchContact(ContactSearch contact)
        {
            return _blContact.Search(contact);
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