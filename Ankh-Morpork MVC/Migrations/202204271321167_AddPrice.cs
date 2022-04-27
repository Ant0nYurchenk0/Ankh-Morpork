namespace Ankh_Morpork_MVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPrice : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Characters", name: "Fee", newName: "Fee1");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Characters", name: "Fee1", newName: "Fee");
        }
    }
}
