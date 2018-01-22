using ERPSolution.Generic;
using ERPSolution.Helper;
using ERPSolution.InitializerModels;
using ERPSolution.MetadataModels;
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

            foreach (var instanceValues in EntityBase.ERPContext.ApplicationDefaults)
                EntityBase.ERPContext.ApplicationDefaults.Remove(instanceValues);

            foreach (var entity1 in EntityBase.ERPContext.EntityMaster)
                EntityBase.ERPContext.EntityMaster.Remove(entity1);

            EntityBase.ERPContext.SaveChanges();

            var applicationDefault = new ApplicationDefaults();
            applicationDefault.PropertyName = "EncryptionKey";
            applicationDefault.DataType = "System.String";
            applicationDefault.Value = "MAKV2SPBNI99212";
            applicationDefault.IsActive = true;
            applicationDefault.SaveAll();
            //
            var entity = new EntityMaster();
            entity.EntityType = Common.EntityTypeName.UserMaster;
            entity.EntityName = "UserMaster";
            entity.AssemblyName = "ERPSolution";
            entity.NamespaceName = "ERPSolution.Models.UserMaster";
            entity.IsParent = true;
            entity.IsChild = false;
            entity.SaveAll();

            var entity2 = new EntityMaster();
            entity2.EntityType = Common.EntityTypeName.Identity;
            entity2.EntityName = "Identity";
            entity2.AssemblyName = "ERPSolution";
            entity2.NamespaceName = "ERPSolution.Models.Identity";
            entity2.IsParent = true;
            entity2.IsChild = false;
            entity2.SaveAll();
            //
            EntityBase.InstanceValues = EntityBase.ERPContext.ApplicationDefaults.Where(ad => ad.IsActive == true).ToList<ApplicationDefaults>();
            //
            Metadata.Entities = EntityBase.ERPContext.EntityMaster.ToList<EntityMaster>();

            //foreach (var secureData2 in EntityBase.ERPContext.SecureData)
            //    EntityBase.ERPContext.SecureData.Remove(secureData2);

            //EntityBase.ERPContext.SaveChanges();
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

            //var user3 = EntityBase.ERPContext.UserMaster.Where(um => um.Code == "CodenameDj").First();
            //user3.Code = "CodenameDj2410";
            //user3.SaveAll();

            //var userEdit = new UserMaster(Guid.Parse(user.Id.ToString()));
            AuthenticationHelper.Authenticate(identity.Code, secureData.Data);
            //Type typeName = Type.GetType("ERPSolution.Models.UserMaster");
            var userdata = EntityHelper.GetEntity(Common.EntityTypeName.UserMaster, user.Id) as UserMaster;
            userdata.MobileNo = "7020328833";
            userdata.SaveAll();
        }
    }
}