namespace DataMigrations.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatingPerson : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Person", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Person", "Title");
        }
    }
}
