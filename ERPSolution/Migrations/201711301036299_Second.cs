namespace ERPSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SecureData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdentityId = c.Guid(nullable: false),
                        Data = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SecureData");
        }
    }
}
