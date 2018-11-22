using Firefly.DAL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public partial class ContactTitle : INameable
    {
        public ContactTitle()
        {
            Contacts = new HashSet<Contact>();
        }

        public int ContactTitleId { get; set; }
        public string Name { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
