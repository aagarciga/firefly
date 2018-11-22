using Firefly.DAL.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firefly.DAL.Model.Base
{
    public partial class Language : INameable
    {
        public Language()
        {
            Contacts = new HashSet<Contact>();
        }

        public int LanguageId { get; set; }
        public string Name { get; set; }

        public ICollection<Contact> Contacts { get; set; }
    }
}
