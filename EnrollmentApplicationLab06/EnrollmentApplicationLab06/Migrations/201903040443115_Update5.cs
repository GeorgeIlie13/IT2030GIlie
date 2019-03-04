namespace EnrollmentApplicationLab06.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update5 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "Address2", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "Address2", c => c.String(nullable: false));
        }
    }
}
