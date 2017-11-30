namespace ERPSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SecureData", "CreatedBy", c => c.Guid(nullable: false));
            AddColumn("dbo.SecureData", "CreatedDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SecureData", "CreatedDateTime");
            DropColumn("dbo.SecureData", "CreatedBy");
        }
    }
}
