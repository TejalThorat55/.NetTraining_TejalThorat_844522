namespace MVCCodeTRMProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginDetails",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 10),
                        Password = c.String(nullable: false, maxLength: 10),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.RequestDetails",
                c => new
                    {
                        RequestId = c.Int(nullable: false, identity: true),
                        RequestName = c.String(nullable: false, maxLength: 10),
                        Skill = c.String(nullable: false, maxLength: 10),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Status = c.String(nullable: false, maxLength: 10),
                        ExecId = c.Int(),
                        TrainerId = c.Int(),
                    })
                .PrimaryKey(t => t.RequestId);
            
            CreateTable(
                "dbo.RoleDetails",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RoleDetails");
            DropTable("dbo.RequestDetails");
            DropTable("dbo.LoginDetails");
        }
    }
}
