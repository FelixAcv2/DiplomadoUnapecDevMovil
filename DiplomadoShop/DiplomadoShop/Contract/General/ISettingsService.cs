﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DiplomadoShop.Contract.General
{
   public interface ISettingsService
    {
        void AddItem(string key, string value);
        string GetItem(string key);

        string UserNameSetting { get; set; }
        string UserIdSetting { get; set; }

    }
}
