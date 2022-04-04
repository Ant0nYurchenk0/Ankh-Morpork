namespace Game
{
    internal interface IBeggarBuilder : INpcBuilder<BeggarNpc>
    {
        void AddFee(double fee);
    }
}
