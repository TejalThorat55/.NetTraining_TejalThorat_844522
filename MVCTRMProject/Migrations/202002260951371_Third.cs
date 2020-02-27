namespace MVCCodeTRMProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Third : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RequestDetails", "ExecId", c => c.Int(nullable: false));
            AlterColumn("dbo.RequestDetails", "TrainerId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RequestDetails", "TrainerId", c => c.Int());
            AlterColumn("dbo.RequestDetails", "ExecId", c => c.Int());
        }
    }
}
