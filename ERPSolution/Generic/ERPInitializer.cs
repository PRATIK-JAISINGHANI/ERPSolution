using ERPSolution.Generic;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
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
            EntityBase.ERPContext = context;
            //
            foreach (var user2 in EntityBase.ERPContext.UserMaster)
                EntityBase.ERPContext.UserMaster.Remove(user2);

            foreach (var id in EntityBase.ERPContext.Identity)
                EntityBase.ERPContext.Identity.Remove(id);

            foreach (var secureData2 in EntityBase.ERPContext.SecureData)
                EntityBase.ERPContext.SecureData.Remove(secureData2);

            EntityBase.ERPContext.SaveChanges();
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
            var result = identity.SaveAll();

            var user = new UserMaster();
            user.Id = Guid.NewGuid();
            user.IdentityId = identity.Id;
            user.ContactId = Guid.NewGuid();
            user.Code = identity.Code;
            user.Gender = Common.EnumMaster.Gender.Male;
            user.Name = identity.Name;
            user.MobileNo = identity.MobileNo;
            user.CreatedBy = identity.CreatedBy;
            user.CreatedDateTime = DateTime.Now;
            user.SaveAll();

            var secureData = new SecureData();
            secureData.Id = Guid.NewGuid();
            secureData.IdentityId = identity.Id;
            secureData.Data = "q";
            secureData.CreatedBy = user.CreatedBy;
            secureData.CreatedDateTime = DateTime.Now;
            secureData.SaveAll();

        }
    }
}