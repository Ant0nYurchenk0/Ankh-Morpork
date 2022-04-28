//namespace Ankh_Morpork_MVC.Migrations
//{
//    using System;
//    using System.Collections.Generic;
//    using System.Data.Entity.Infrastructure.Annotations;
//    using System.Data.Entity.Migrations;
    
//    public partial class PopulateAssassinsTable : DbMigration
//    {
//        public override void Up()
//        {
//            Sql("insert into characters (Name, MeetMessage, OfferMessage, MinReward, MaxReward, Discriminator) values ('Robert von Schneider', 'Hey mister, hold on, I came to kill you! And bribery is TOTALLY not an option!!!', 'OK, how much you WILL DEFINITELY NOT give me?', 15, 30, 'Assassin')");
//            AddColumn("dbo.Characters", "GuildData", c => c.String(
//                annotations: new Dictionary<string, AnnotationValues>
//                {
//                    { 
//                        "DefaultValue",
//                        new AnnotationValues(oldValue: null, newValue: "The Ankh-Morpork Assassins' Guild is a school for professional killers. It is pretty easy to get into a trouble in the Shades and make enemies. Someone definitely wants to kill you. You can create a contract with the guild to kill the enemy first. Each assassin takes the contract only if not occupied.")
//                    },
//                }));
//            AlterColumn("dbo.Characters", "IsBusy", c => c.Boolean(
//                annotations: new Dictionary<string, AnnotationValues>
//                {
//                    { 
//                        "DefaultValue",
//                        new AnnotationValues(oldValue: null, newValue: "False")
//                    },
//                }));
//            DropColumn("dbo.Characters", "DenyMessage");
//            DropColumn("dbo.Characters", "AcceptMessage");
//        }
        
//        public override void Down()
//        {
//            AddColumn("dbo.Characters", "AcceptMessage", c => c.String());
//            AddColumn("dbo.Characters", "DenyMessage", c => c.String());
//            AlterColumn("dbo.Characters", "IsBusy", c => c.Boolean(
//                annotations: new Dictionary<string, AnnotationValues>
//                {
//                    { 
//                        "DefaultValue",
//                        new AnnotationValues(oldValue: "False", newValue: null)
//                    },
//                }));
//            DropColumn("dbo.Characters", "GuildData",
//                removedAnnotations: new Dictionary<string, object>
//                {
//                    { "DefaultValue", "The Ankh-Morpork Assassins' Guild is a school for professional killers. It is pretty easy to get into a trouble in the Shades and make enemies. Someone definitely wants to kill you. You can create a contract with the guild to kill the enemy first. Each assassin takes the contract only if not occupied." },
//                });
//        }
//    }
//}
