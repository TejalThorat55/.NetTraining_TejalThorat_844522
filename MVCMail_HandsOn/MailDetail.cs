//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_MailHandsOn
{
    using System;
    using System.Collections.Generic;
    
    public partial class MailDetail
    {
        public int MailId { get; set; }
        public int UserId { get; set; }
        public string MailFrom { get; set; }
        public string Sub { get; set; }
        public System.DateTime ReceiveDate { get; set; }
        public string Msg { get; set; }
    
        public virtual UserInfo UserInfo { get; set; }
    }
}
