namespace ERPSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourth : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplicationDefaults",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        PropertyName = c.String(),
                        DataType = c.String(),
                        Value = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ApplicationDefaults");
        }
    }
}
