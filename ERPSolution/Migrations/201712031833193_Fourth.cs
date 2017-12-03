namespace ERPSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AuthenticationToken = c.Guid(nullable: false),
                        IdentityId = c.Guid(nullable: false),
                        IPAddress = c.String(),
                        AuthorizeTill = c.DateTime(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Session");
        }
    }
}
