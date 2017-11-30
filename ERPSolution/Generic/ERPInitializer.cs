using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ERPSolution.Models
{
    public class ERPInitializer : DropCreateDatabaseIfModelChanges<ERPContext>
    {
        public ERPInitializer()
        {
            this.Seed(new ERPContext());
        }

        protected override void Seed(ERPContext context)
        {
            base.Seed(context);
            //
            foreach (var user2 in context.UserMaster)
                context.UserMaster.Remove(user2);

            foreach (var id in context.Identity)
                context.Identity.Remove(id);

            foreach (var secureData in context.SecureData)
                context.SecureData.Remove(secureData);

            context.SaveChanges();
            //

            var identity = new Identity();
            identity.Id = Guid.NewGuid();
            identity.Name = "Pratik";
            identity.Code = "CodenameDJ";
            identity.EMailId = "pratik.jaisinghani2013@gmail.com";
            identity.CreatedBy = Guid.NewGuid();
            identity.MobileNo = "8055333533";
            identity.ValidationStatus = Common.EnumMaster.ValidationStatus.Suspended;
            identity.CreatedDateTime = DateTime.Now;
            identity.SaveAll();

            var user = new UserMaster();
            user.Id = Guid.NewGuid();
            user.IdentityId = identity.Id;
            user.ContactId = Guid.NewGuid();
            user.FirstName = "Pratik";
            user.Gender = Common.EnumMaster.Gender.Male;
            user.MiddleName = "Mahesh";
            user.LastName = "Jaisinghani";
            user.MobileNo = identity.MobileNo;
            user.CreatedBy = identity.CreatedBy;
            user.CreatedDateTime = DateTime.Now;
            user.SaveAll();


        }
    }
}