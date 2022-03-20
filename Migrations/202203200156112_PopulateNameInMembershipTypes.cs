namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateNameInMembershipTypes : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipTypes SET Name = 'Pay as You Go' WHERE Id = 1");
            Sql("Update MembershipTypes SET Name = 'Monthly' WHERE Id = 2");
        }

        public override void Down()
        {
        }
    }
}
