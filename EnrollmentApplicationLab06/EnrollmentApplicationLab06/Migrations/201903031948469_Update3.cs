namespace EnrollmentApplicationLab06.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enrollments", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enrollments", "Notes");
        }
    }
}
