//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication2.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Messages = new HashSet<Message>();
        }
    
        public int Id { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    
        public virtual ICollection<Message> Messages { get; set; }
    }
}
