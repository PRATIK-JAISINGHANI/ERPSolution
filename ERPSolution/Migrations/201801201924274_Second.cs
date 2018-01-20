namespace ERPSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntityMaster",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        EntityType = c.Long(nullable: false),
                        EntityName = c.String(),
                        ClassName = c.String(),
                        AssemblyName = c.String(),
                        NamespaceName = c.String(),
                        IsParent = c.Boolean(nullable: false),
                        IsChild = c.Boolean(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EntityMaster");
        }
    }
}
