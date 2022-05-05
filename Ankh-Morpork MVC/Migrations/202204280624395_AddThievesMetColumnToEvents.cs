namespace Ankh_Morpork_MVC.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddThievesMetColumnToEvents : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "ThievesMet", c => c.Int(nullable: false));
        }

        public override void Down()
        {
            DropColumn("dbo.Events", "ThievesMet");
        }
    }
}
