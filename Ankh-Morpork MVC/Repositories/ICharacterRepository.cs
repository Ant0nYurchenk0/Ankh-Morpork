﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ankh_Morpork_MVC.Models;

namespace Ankh_Morpork_MVC.Repositories
{
    public interface ICharacterRepository
    {        
        bool ProcessResponce(bool accept);
    }
}