using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Web.WebPages;
using FluentValidation;
using FluentValidation.Results;
using PhoneBooth.Dal;
using PhoneBooth.Dal.Interfaces;
using PhoneBooth.Models;

namespace PhoneBooth.BL
{
    public class BLContact
    {
        private IDalContact _dalContact;
        ContactValidator validator = new ContactValidator();
        ContactSearchValidator validatorSearch = new ContactSearchValidator();
        public BLContact(ContactsContext cc)
        {
            _dalContact = new DalContact(cc);
        }

        public List<Contact> GetAll()
        {
            try
            {
                return _dalContact.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Contact Get(int id)
        {
            try
            {
                return _dalContact.Get(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Add(Contact cont)
        {
            try
            {
                ValidationResult results = validator.Validate(cont);
                if (results.IsValid)
                {
                    _dalContact.Add(cont);
                }
                else
                {
                    //!results.IsValid
                    if (results.Errors != null && results.Errors.Count > 0)
                    {
                        foreach (var failure in results.Errors)
                        {
                            throw new Exception("Property " + failure.PropertyName + " failed validation. Error was: " +
                                                failure.ErrorMessage);
                        }
                    }
                }
            }
            catch (ValidationException e)
            {
                throw new Exception($"validation error: {e.ToString()}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Update(Contact cont)
        {
            try
            {
                ValidationResult results = validator.Validate(cont);
                if (results.IsValid)
                {
                    _dalContact.Update(cont);
                }
                else
                {
                    //!results.IsValid
                    if (results.Errors != null && results.Errors.Count > 0)
                    {
                        foreach (var failure in results.Errors)
                        {
                            throw new Exception("Property " + failure.PropertyName + " failed validation. Error was: " +
                                                failure.ErrorMessage);
                        }
                    }
                }

                _dalContact.Update(cont);
            }
            catch (ValidationException e)
            {
                throw new Exception($"validation error: {e.ToString()}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _dalContact.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Contact> Search(ContactSearch cs)
        {
            try
            {
                //Validation
                if (cs != null)
                {
                    ValidationResult results = validatorSearch.Validate(cs);
                    if (results.IsValid)
                    {
                        return _dalContact.Search(cs);
                    }
                    else
                    {
                        //!results.IsValid
                        if (results.Errors != null && results.Errors.Count > 0)
                        {
                            foreach (var failure in results.Errors)
                            {
                                throw new Exception("Property " + failure.PropertyName + " failed validation. Error was: " +
                                                    failure.ErrorMessage);
                            }
                        }
                    }
                }
                return null;
            }
            catch (ValidationException e)
            {
                throw new Exception($"validation error: {e.ToString()}");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [Obsolete]
        private bool IsValid(ContactSearch cs)
        {
            var pattern = @"^[a-zA-Z0-9 ]*$";
            var patternOnlyDigits = @"^[0-9]*$";

            //FirstName
            if (!String.IsNullOrEmpty(cs.FirstName))
            {
                if (!Regex.IsMatch(cs.FirstName, pattern))
                {
                    return false;
                }
            }
            //LastName
            if (!String.IsNullOrEmpty(cs.LastName))
            {
                if (!Regex.IsMatch(cs.LastName, pattern))
                {
                    return false;
                }
            }
            //Address
            if (!String.IsNullOrEmpty(cs.Address))
            {
                if (!Regex.IsMatch(cs.Address, pattern))
                {
                    return false;
                }
            }
            //PhoneNum
            if (!String.IsNullOrEmpty(cs.PhoneNum))
            {
                if (!Regex.IsMatch(cs.PhoneNum, patternOnlyDigits))
                {
                    return false;
                }
            }

            return true;
        }

        [Obsolete]
        private bool IsValid(Contact cs)
        {
            var pattern = @"^[a-zA-Z0-9 ]*$";
            var patternOnlyDigits = @"^[0-9]*$";

            //FirstName
            if (!String.IsNullOrEmpty(cs.FirstName))
            {
                if (!Regex.IsMatch(cs.FirstName, pattern))
                {
                    return false;
                }
            }
            //LastName
            if (!String.IsNullOrEmpty(cs.LastName))
            {
                if (!Regex.IsMatch(cs.LastName, pattern))
                {
                    return false;
                }
            }
            //Address
            if (!String.IsNullOrEmpty(cs.Address))
            {
                if (!Regex.IsMatch(cs.Address, pattern))
                {
                    return false;
                }
            }
            //PhoneNum
            if (!String.IsNullOrEmpty(cs.PhoneNum))
            {
                if (!Regex.IsMatch(cs.PhoneNum, patternOnlyDigits))
                {
                    return false;
                }
            }

            return true;
        }
    }
}