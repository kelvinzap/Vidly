namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateRemainingNameInMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name = 'Quarterly' WHERE Id = 3");
            Sql("Update MembershipTypes SET Name = 'Annualy' WHERE Id = 4");

        }

        public override void Down()
        {
        }
    }
}
