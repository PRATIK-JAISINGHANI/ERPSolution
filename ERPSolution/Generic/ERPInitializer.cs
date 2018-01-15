using ERPSolution.Generic;
using ERPSolution.InitializerModels;
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
            EntityBase.InstanceValues = EntityBase.ERPContext.ApplicationDefaults.Where(ad => ad.IsActive == true).ToList<ApplicationDefaults>();
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
            identity.Name = "Pratik";
            identity.Code = "CodenameDJ";
            identity.EMailId = "pratik.jaisinghani2013@gmail.com";
            identity.MobileNo = "8055333533";
            identity.ValidationStatus = Common.EnumMaster.ValidationStatus.Suspended;
            var result = identity.SaveAll();

            var user = new UserMaster();
            user.IdentityId = identity.Id;
            user.ContactId = Guid.NewGuid();
            user.Code = identity.Code;
            user.Gender = Common.EnumMaster.Gender.Male;
            user.Name = identity.Name;
            user.MobileNo = identity.MobileNo;
            user.SaveAll();

            var secureData = new SecureData();
            secureData.IdentityId = identity.Id;
            secureData.Data = "q";
            secureData.SaveAll();

            var user3 = EntityBase.ERPContext.UserMaster.Where(um => um.Code == "CodenameDj").First();
            user3.Code = "CodenameDj2410";
            user3.SaveAll();
        }
    }
}