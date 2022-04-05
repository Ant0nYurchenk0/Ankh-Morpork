namespace Game
{
    internal interface IBeggarBuilder : INpcBuilder<BeggarNpc>
    {
        void AddFee(decimal fee);
    }
}
