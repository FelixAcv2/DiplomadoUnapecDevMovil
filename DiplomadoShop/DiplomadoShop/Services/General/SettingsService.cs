﻿using DiplomadoShop.Contract.General;
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;


namespace DiplomadoShop.Services.General
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettings _settings;
        private const string UserName = "UserName";
        private const string UserId = "UserId";

        public SettingsService()
        {
            _settings = CrossSettings.Current;
        }

        public void AddItem(string key, string value)
        {
            _settings.AddOrUpdateValue(key, value);
        }

        public string GetItem(string key)
        {
            return _settings.GetValueOrDefault(key, string.Empty);
        }

        public string UserNameSetting
        {
            get => GetItem(UserName);
            set => AddItem(UserName, value);
        }

        public string UserIdSetting
        {
            get => GetItem(UserId);
            set => AddItem(UserId, value);
        }
    }
}
