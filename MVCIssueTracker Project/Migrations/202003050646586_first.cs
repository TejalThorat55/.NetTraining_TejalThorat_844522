namespace MVCIssueTrackerCode.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BugPoolDetails",
                c => new
                    {
                        BugId = c.Int(nullable: false, identity: true),
                        BugTitle = c.String(nullable: false),
                        Priority = c.String(nullable: false),
                        TesterId = c.Int(nullable: false),
                        DeveloperId = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        RaisedDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BugId);
            
            CreateTable(
                "dbo.CommentDetails",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        BugId = c.Int(nullable: false),
                        CommentedBy = c.Int(nullable: false),
                        Comments = c.String(nullable: false),
                        CommentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.BugPoolDetails", t => t.BugId, cascadeDelete: true)
                .Index(t => t.BugId);
            
            CreateTable(
                "dbo.LoginDetails",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 8),
                        Password = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.MapDetails",
                c => new
                    {
                        MapId = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ProjId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MapId)
                .ForeignKey("dbo.ProjectDetails", t => t.ProjId, cascadeDelete: true)
                .ForeignKey("dbo.RoleDetails", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.LoginDetails", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId)
                .Index(t => t.ProjId);
            
            CreateTable(
                "dbo.ProjectDetails",
                c => new
                    {
                        ProjId = c.Int(nullable: false, identity: true),
                        ProjName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProjId);
            
            CreateTable(
                "dbo.RoleDetails",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 8),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MapDetails", "UserId", "dbo.LoginDetails");
            DropForeignKey("dbo.MapDetails", "RoleId", "dbo.RoleDetails");
            DropForeignKey("dbo.MapDetails", "ProjId", "dbo.ProjectDetails");
            DropForeignKey("dbo.CommentDetails", "BugId", "dbo.BugPoolDetails");
            DropIndex("dbo.MapDetails", new[] { "ProjId" });
            DropIndex("dbo.MapDetails", new[] { "UserId" });
            DropIndex("dbo.MapDetails", new[] { "RoleId" });
            DropIndex("dbo.CommentDetails", new[] { "BugId" });
            DropTable("dbo.RoleDetails");
            DropTable("dbo.ProjectDetails");
            DropTable("dbo.MapDetails");
            DropTable("dbo.LoginDetails");
            DropTable("dbo.CommentDetails");
            DropTable("dbo.BugPoolDetails");
        }
    }
}
