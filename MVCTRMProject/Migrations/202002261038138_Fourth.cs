namespace MVCCodeTRMProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fourth : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LoginDetails", "UserName", c => c.String());
            AlterColumn("dbo.LoginDetails", "Password", c => c.String());
            AlterColumn("dbo.RequestDetails", "RequestName", c => c.String());
            AlterColumn("dbo.RequestDetails", "Skill", c => c.String());
            AlterColumn("dbo.RequestDetails", "Status", c => c.String());
            AlterColumn("dbo.RoleDetails", "RoleName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RoleDetails", "RoleName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.RequestDetails", "Status", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.RequestDetails", "Skill", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.RequestDetails", "RequestName", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.LoginDetails", "Password", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.LoginDetails", "UserName", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
