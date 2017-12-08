namespace ERPSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Identity", "Code", c => c.String(maxLength: 200));
            AlterColumn("dbo.UserMaster", "Code", c => c.String(maxLength: 200));
            CreateStoredProcedure(
                "dbo.UserMaster_Insert",
                p => new
                    {
                        Id = p.Guid(),
                        IdentityId = p.Guid(),
                        ContactId = p.Guid(),
                        Code = p.String(maxLength: 200),
                        Name = p.String(),
                        Gender = p.Int(),
                        MobileNo = p.String(),
                        IsActive = p.Boolean(),
                        CreatedBy = p.Guid(),
                        CreatedDateTime = p.DateTime(),
                    },
                body:
                    @"INSERT [dbo].[UserMaster]([Id], [IdentityId], [ContactId], [Code], [Name], [Gender], [MobileNo], [IsActive], [CreatedBy], [CreatedDateTime])
                      VALUES (@Id, @IdentityId, @ContactId, @Code, @Name, @Gender, @MobileNo, @IsActive, @CreatedBy, @CreatedDateTime)"
            );
            
            CreateStoredProcedure(
                "dbo.UserMaster_Update",
                p => new
                    {
                        Id = p.Guid(),
                        IdentityId = p.Guid(),
                        ContactId = p.Guid(),
                        Code = p.String(maxLength: 200),
                        Name = p.String(),
                        Gender = p.Int(),
                        MobileNo = p.String(),
                        IsActive = p.Boolean(),
                        CreatedBy = p.Guid(),
                        CreatedDateTime = p.DateTime(),
                    },
                body:
                    @"UPDATE [dbo].[UserMaster]
                      SET [IdentityId] = @IdentityId, [ContactId] = @ContactId, [Code] = @Code, [Name] = @Name, [Gender] = @Gender, [MobileNo] = @MobileNo, [IsActive] = @IsActive, [CreatedBy] = @CreatedBy, [CreatedDateTime] = @CreatedDateTime
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.UserMaster_Delete",
                p => new
                    {
                        Id = p.Guid(),
                    },
                body:
                    @"DELETE [dbo].[UserMaster]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.UserMaster_Delete");
            DropStoredProcedure("dbo.UserMaster_Update");
            DropStoredProcedure("dbo.UserMaster_Insert");
            AlterColumn("dbo.UserMaster", "Code", c => c.String());
            AlterColumn("dbo.Identity", "Code", c => c.String());
        }
    }
}
