namespace Vidly.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddDescriptionToMembershipType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Description", c => c.String());

            Sql("UPDATE dbo.MembershipTypes SET Description='Pay as You Go' WHERE Id = 1");
            Sql("UPDATE dbo.MembershipTypes SET Description='Monthly' WHERE Id = 2");
            Sql("UPDATE dbo.MembershipTypes SET Description='Quarterly' WHERE Id = 3");
            Sql("UPDATE dbo.MembershipTypes SET Description='Yearly' WHERE Id = 4");
        }

        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Description");
        }
    }
}
