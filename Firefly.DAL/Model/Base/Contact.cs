using Firefly.DAL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public partial class Contact : INameable, IAuditable, IArchibable
    {
        public Contact()
        {
            Contracts = new HashSet<Contract>();
            Contacts = new HashSet<Contact>();
        }

        public int ContactId { get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int ContactTitleId { get; set; }
        public int LanguageId { get; set; }
        public int ContactType { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsArchived { get; set; }
        public bool IsACompany { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public string TaxId { get; set; }
        public string JobPosition { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Note { get; set; }

        public Contact Parent { get; set; }

        public ContactTitle ContactTitle { get; set; }
        public Language Language {get; set;}
        
        public ICollection<Contract> Contracts { get; set; }
        /// <summary>
        /// Contacts And Addresses
        /// </summary>
        public ICollection<Contact> Contacts { get; set; }
    }
}
