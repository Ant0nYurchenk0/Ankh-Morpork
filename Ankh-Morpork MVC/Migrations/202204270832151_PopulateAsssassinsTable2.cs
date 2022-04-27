namespace Ankh_Morpork_MVC.Migrations
{
    using Ankh_Morpork_MVC.Constants;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateAsssassinsTable2 : DbMigration
    {
        public override void Up()
        {
            Populate();
            AlterColumn("dbo.Characters", "GuildData", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValue",
                        new AnnotationValues(oldValue: "The Ankh-Morpork Assassins' Guild is a school for professional killers. It is pretty easy to get into a trouble in the Shades and make enemies. Someone definitely wants to kill you. You can create a contract with the guild to kill the enemy first. Each assassin takes the contract only if not occupied.", newValue: null)
                    },
                }));
            AlterColumn("dbo.Characters", "IsBusy", c => c.Boolean(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValue",
                        new AnnotationValues(oldValue: "False", newValue: null)
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Characters", "IsBusy", c => c.Boolean(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "False")
                    },
                }));
            AlterColumn("dbo.Characters", "GuildData", c => c.String(
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "DefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "The Ankh-Morpork Assassins' Guild is a school for professional killers. It is pretty easy to get into a trouble in the Shades and make enemies. Someone definitely wants to kill you. You can create a contract with the guild to kill the enemy first. Each assassin takes the contract only if not occupied.")
                    },
                }));
        }
        private void Populate()
        {
            
            Sql($"insert into characters (Name, MeetMessage, OfferMessage, MinReward, MaxReward, Discriminator, IsBusy, GuildData) values (" +
                $"'Alberto', " +
                $"'Let us be clear, I came to kill you, you can redeem yourself, what do you do?', " +
                $"'What is your offer', " +
                $"10, " +
                $"20, " +
                $"'Assassin'," +
                $"'False'," +
                $"'{GuildDatas.Assassin}');");
            Sql($"insert into characters (Name, MeetMessage, OfferMessage, MinReward, MaxReward, Discriminator, IsBusy, GuildData) values (" +
                $"'Vittorio', " +
                $"'Hi, wanna live?', " +
                $"'OK, how much you offer?', " +
                $"7, " +
                $"12, " +
                $"'Assassin'," +
                $"'False'," +
                $"'{GuildDatas.Assassin}');");
            Sql($"insert into characters (Name, MeetMessage, OfferMessage, MinReward, MaxReward, Discriminator, IsBusy, GuildData) values (" +
                $"'Tamara', " +
                $"'Hey sweety, wanna have a lunch with me?', " +
                $"'Pay for me', " +
                $"15, " +
                $"19, " +
                $"'Assassin'," +
                $"'False'," +
                $"'{GuildDatas.Assassin}');");
            Sql($"insert into characters (Name, MeetMessage, OfferMessage, MinReward, MaxReward, Discriminator, IsBusy, GuildData) values (" +
                $"'The Two Coin Butcher', " +
                $"'Hey you, someone wants to kill you, do you want us to kill him first', " +
                $"'Okey then,what is your deal?', " +
                $"2, " +
                $"9, " +
                $"'Assassin'," +
                $"'False'," +
                $"'{GuildDatas.Assassin}');");
            Sql($"insert into characters (Name, MeetMessage, OfferMessage, MinReward, MaxReward, Discriminator, IsBusy, GuildData) values (" +
                $"'Ivan', " +
                $"'Hey you, someone wants to kill you, do you want us to kill him first', " +
                $"'Okey then,what is your deal?', " +
                $"1, " +
                $"1, " +
                $"'Assassin'," +
                $"'False'," +
                $"'{GuildDatas.Assassin}');");

        }
    }
}
