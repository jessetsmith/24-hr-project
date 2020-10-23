namespace _24HourProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Author_UserId = c.Guid(nullable: false),
                        CommentPost_PostId = c.Int(nullable: false),
                        ReplyComment_CommentId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.User", t => t.Author_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Post", t => t.CommentPost_PostId, cascadeDelete: true)
                .ForeignKey("dbo.Comment", t => t.ReplyComment_CommentId)
                .Index(t => t.Author_UserId)
                .Index(t => t.CommentPost_PostId)
                .Index(t => t.ReplyComment_CommentId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Text = c.String(nullable: false),
                        Author_UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.User", t => t.Author_UserId, cascadeDelete: true)
                .Index(t => t.Author_UserId);
            
            CreateTable(
                "dbo.Like",
                c => new
                    {
                        LikeId = c.Int(nullable: false, identity: true),
                        LikedPost_PostId = c.Int(nullable: false),
                        Liker_UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.LikeId)
                .ForeignKey("dbo.Post", t => t.LikedPost_PostId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.Liker_UserId, cascadeDelete: true)
                .Index(t => t.LikedPost_PostId)
                .Index(t => t.Liker_UserId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Like", "Liker_UserId", "dbo.User");
            DropForeignKey("dbo.Like", "LikedPost_PostId", "dbo.Post");
            DropForeignKey("dbo.Comment", "ReplyComment_CommentId", "dbo.Comment");
            DropForeignKey("dbo.Comment", "CommentPost_PostId", "dbo.Post");
            DropForeignKey("dbo.Post", "Author_UserId", "dbo.User");
            DropForeignKey("dbo.Comment", "Author_UserId", "dbo.User");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Like", new[] { "Liker_UserId" });
            DropIndex("dbo.Like", new[] { "LikedPost_PostId" });
            DropIndex("dbo.Post", new[] { "Author_UserId" });
            DropIndex("dbo.Comment", new[] { "ReplyComment_CommentId" });
            DropIndex("dbo.Comment", new[] { "CommentPost_PostId" });
            DropIndex("dbo.Comment", new[] { "Author_UserId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Like");
            DropTable("dbo.Post");
            DropTable("dbo.User");
            DropTable("dbo.Comment");
        }
    }
}
