﻿namespace Ankh_Morpork_MVC.Repositories
{
    public interface IHoodRepository : IEventProcessRepository
    {
        void AddFee(double fee);
    }
}