namespace ERPSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Identity",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        MobileNo = c.String(),
                        EMailId = c.String(),
                        ValidationStatus = c.Int(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserMaster",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdentityId = c.Guid(nullable: false),
                        ContactId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        LastName = c.String(),
                        Gender = c.Int(nullable: false),
                        MobileNo = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserMaster");
            DropTable("dbo.Identity");
        }
    }
}
