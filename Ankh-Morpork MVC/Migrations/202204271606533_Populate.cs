namespace Ankh_Morpork_MVC.Migrations
{
    using Ankh_Morpork_MVC.Constants;
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Populate : DbMigration
    {
        public override void Up()
        {
            PopulateAssassins();
            PopulateBeggars();
            PopulateThieves();
            PopulateClowns();
            PopulateItems();

        }
        public override void Down()
        {
        }

        private void PopulateItems()
        {
            Sql($"insert into Characters (Name, MeetMessage, Price, ItemType, Discriminator, GuildData) values (" +
                $"'Beer'," +
                $"'Welcome to The Mended Drum'," +
                $"2," +
                $"1," +
                $"'Item'," +
                $"'{GuildDatas.Beer}');");
            Sql($"insert into Characters (Name, MeetMessage, Price, ItemType, Discriminator, GuildData) values (" +
                $"'Premium Hood'," +
                $"'Welcome to The Atelier of Shades'," +
                $"10," +
                $"2," +
                $"'Item'," +
                $"'{GuildDatas.Hood}');");
            Sql($"insert into Characters (Name, MeetMessage, Price, ItemType, Discriminator, GuildData) values (" +
                $"'Green Hood'," +
                $"'A hood hanging on a rope abouve the street'," +
                $"3," +
                $"2," +
                $"'Item'," +
                $"'{GuildDatas.Hood}');");
            Sql($"insert into Characters (Name, MeetMessage, Price, ItemType, Discriminator, GuildData) values (" +
                $"'Worn Hood'," +
                $"'A dirty hood lying on by the road. Still good to disguise, though...'," +
                $"0," +
                $"2," +
                $"'Item'," +
                $"'{GuildDatas.Hood}');");
        }

        private void PopulateClowns()
        {
            Sql($"insert into characters (Name, MeetMessage, Reward, Discriminator, GuildData) values(" +
                $"'Alan'," +
                $"'Hello adventurer'," +
                $"0.5," +
                $"'Clown'," +
                $"'{GuildDatas.Clown}');");
            Sql($"insert into characters (Name, MeetMessage, Reward,Discriminator, GuildData) values(" +
                $"'Ilon'," +
                $"'You give me $1000, I give you $10000'," +
                $"1," +
                $"'Clown'," +
                $"'{GuildDatas.Clown}');");
            Sql($"insert into characters (Name, MeetMessage, Reward,Discriminator, GuildData) values(" +
                $"'Pchel'," +
                $"'Wanna have a drink?'," +
                $"2," +
                $"'Clown'," +
                $"'{GuildDatas.Clown}');");
            Sql($"insert into characters (Name, MeetMessage, Reward,Discriminator, GuildData) values(" +
                $"'Freddy'," +
                $"'Quiero darte dinero.'," +
                $"3," +
                $"'Clown'," +
                $"'{GuildDatas.Clown}');");
            Sql($"insert into characters (Name, MeetMessage, Reward,Discriminator, GuildData) values(" +
                $"'Maximus'," +
                $"'Hello adventurer, wanna check your IQ'," +
                $"5," +
                $"'Clown'," +
                $"'{GuildDatas.Clown}');");
            Sql($"insert into characters (Name, MeetMessage, Reward,Discriminator, GuildData) values(" +
                $"'Huan'," +
                $"'Give me a ride!!!'," +
                $"6," +
                $"'Clown'," +
                $"'{GuildDatas.Clown}');");
            Sql($"insert into characters (Name, MeetMessage, Reward,Discriminator, GuildData) values(" +
                $"'Ko-Ko'," +
                $"'What card is in my pocket???'," +
                $"7," +
                $"'Clown'," +
                $"'{GuildDatas.Clown}');");
            Sql($"insert into characters (Name, MeetMessage, Reward,Discriminator, GuildData) values(" +
                $"'Oldman Giuseppe'," +
                $"'Take it, boy, I am not gonna need it...'," +
                $"8," +
                $"'Clown'," +
                $"'{GuildDatas.Clown}');");
            Sql($"insert into characters (Name, MeetMessage, Reward,Discriminator, GuildData) values(" +
                $"'Chel'," +
                $"'HA-HA-HA-HA-HA'," +
                $"10," +
                $"'Clown'," +
                $"'{GuildDatas.Clown}');");
        }

        private void PopulateThieves()
        {
            Sql($"insert into Characters (Name, MeetMessage, Fee, Discriminator, GuildData) values(" +
                $"'Benjamin'," +
                $"'Hey, you, gimme your wallet'," +
                $"10," +
                $"'Thieve'," +
                $"'{GuildDatas.Thieve}');");
            Sql($"insert into Characters (Name, MeetMessage, Fee, Discriminator, GuildData) values(" +
                $"'Vitya'," +
                $"'Gop stop'," +
                $"10," +
                $"'Thieve'," +
                $"'{GuildDatas.Thieve}');");
            Sql($"insert into Characters (Name, MeetMessage, Fee, Discriminator, GuildData) values(" +
                $"'Katie'," +
                $"'Honey, whats that up in the sky'," +
                $"10," +
                $"'Thieve'," +
                $"'{GuildDatas.Thieve}');");
            Sql($"insert into Characters (Name, MeetMessage, Fee, Discriminator, GuildData) values(" +
                $"'Ibrahim'," +
                $"'جئت لأسرق منك'," +
                $"10," +
                $"'Thieve'," +
                $"'{GuildDatas.Thieve}');");
            Sql($"insert into Characters (Name, MeetMessage, Fee, Discriminator, GuildData) values(" +
                $"'Franklin'," +
                $"'Yo, nigga, money or life'," +
                $"10," +
                $"'Thieve'," +
                $"'{GuildDatas.Thieve}');");
            Sql($"insert into Characters (Name, MeetMessage, Fee, Discriminator, GuildData) values(" +
                $"'George'," +
                $"'Have some bucks?'," +
                $"10," +
                $"'Thieve'," +
                $"'{GuildDatas.Thieve}');");
        }

        private void PopulateBeggars()
        {

            Sql($"insert into characters (Name, MeetMessage, MoneyFee, BeerFee, Discriminator, GuildData) values (" +
                $"'Garold'," +
                $"'Toss a coin to your twitcher'," +
                $"3," +
                $"'False'," +
                $"'Beggar'," +
                $"'{GuildDatas.Beggar}');");
            Sql($"insert into characters (Name, MeetMessage, MoneyFee, BeerFee,Discriminator, GuildData) values (" +
                $"'Frank'," +
                $"'The best is yet to come...'," +
                $"2," +
                $"'False'," +
                $"'Beggar'," +
                $"'{GuildDatas.Beggar}');");
            Sql($"insert into characters (Name, MeetMessage, MoneyFee, BeerFee,Discriminator, GuildData) values (" +
                $"'Nicolas'," +
                $"'Need dollar'," +
                $"1," +
                $"'False'," +
                $"'Beggar'," +
                $"'{GuildDatas.Beggar}');");
            Sql($"insert into characters (Name, MeetMessage, MoneyFee, BeerFee,Discriminator, GuildData) values (" +
                $"'Billy'," +
                $"'Asking for money is my job and duty'," +
                $"1," +
                $"'False'," +
                $"'Beggar'," +
                $"'{GuildDatas.Beggar}');");
            Sql($"insert into characters (Name, MeetMessage, MoneyFee, BeerFee,Discriminator, GuildData) values (" +
                $"'Antonio'," +
                $"'Dammi dei soldi'," +
                $"0.9," +
                $"'False'," +
                $"'Beggar'," +
                $"'{GuildDatas.Beggar}');");
            Sql($"insert into characters (Name, MeetMessage, MoneyFee, BeerFee,Discriminator, GuildData) values (" +
                $"'One-eye Hog'," +
                $"'Hey millionaire, wanna share your dirty money!?'," +
                $"0.8," +
                $"'False'," +
                $"'Beggar'," +
                $"'{GuildDatas.Beggar}');");
            Sql($"insert into characters (Name, MeetMessage, MoneyFee, BeerFee,Discriminator, GuildData) values (" +
                $"'Edward'," +
                $"'Gimme something'," +
                $"0.6," +
                $"'False'," +
                $"'Beggar'," +
                $"'{GuildDatas.Beggar}');");
            Sql($"insert into characters (Name, MeetMessage, MoneyFee, BeerFee,Discriminator, GuildData) values (" +
                $"'Tommy'," +
                $"'Hey Jimmy, gimme something'," +
                $"0.5," +
                $"'False'," +
                $"'Beggar'," +
                $"'{GuildDatas.Beggar}');");
            Sql($"insert into characters (Name, MeetMessage, MoneyFee, BeerFee,Discriminator, GuildData) values (" +
                $"'Fat Man'," +
                $"'I wanna eat, adventurer, give me some money for meal'," +
                $"0.08," +
                $"'False'," +
                $"'Beggar'," +
                $"'{GuildDatas.Beggar}');");
            Sql($"insert into characters (Name, MeetMessage, MoneyFee, BeerFee,Discriminator, GuildData) values (" +
                $"'Valera'," +
                $"'Arrrkhh!!! Why would wake me up, man'," +
                $"0.02," +
                $"'False'," +
                $"'Beggar'," +
                $"'{GuildDatas.Beggar}');");
            Sql($"insert into characters (Name, MeetMessage, MoneyFee, BeerFee,Discriminator, GuildData) values (" +
                $"'Valentine Half-glass'," +
                $"'Why lie? I need a beer.'," +
                $"0," +
                $"'True'," +
                $"'Beggar'," +
                $"'{GuildDatas.Beggar}');");

        }

        private void PopulateAssassins()
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
