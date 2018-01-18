namespace ERPSolution.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
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
            
            CreateTable(
                "dbo.Identity",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Code = c.String(maxLength: 200),
                        Name = c.String(),
                        MobileNo = c.String(),
                        EMailId = c.String(),
                        ValidationStatus = c.Int(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SecureData",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdentityId = c.Guid(nullable: false),
                        Data = c.String(),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AuthenticationToken = c.Guid(nullable: false),
                        IdentityId = c.Guid(nullable: false),
                        IPAddress = c.String(),
                        AuthorizeTill = c.DateTime(nullable: false),
                        AuthenticationType = c.Int(nullable: false),
                        SessionStatus = c.Int(nullable: false),
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
                        Code = c.String(maxLength: 200),
                        Name = c.String(),
                        Gender = c.Int(nullable: false),
                        MobileNo = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        CreatedBy = c.Guid(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
            DropTable("dbo.UserMaster");
            DropTable("dbo.Session");
            DropTable("dbo.SecureData");
            DropTable("dbo.Identity");
            DropTable("dbo.ApplicationDefaults");
        }
    }
}
