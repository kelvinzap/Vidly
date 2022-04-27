using System.Data.Entity.Migrations.Model;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeNumberAvailableCOlumn : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberAvailable = InStock");
        }
        
        public override void Down()
        {
        }
    }
}
