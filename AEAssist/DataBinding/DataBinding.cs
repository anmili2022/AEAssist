﻿using System;
using AEAssist.AI;
using AETriggers.TriggerModel;
using PropertyChanged;

namespace AEAssist
{
    [AddINotifyPropertyChangedInterface]
    public class DataBinding
    {
        private static DataBinding _instance;


        public static DataBinding Instance => _instance ?? (_instance = new DataBinding());

        public bool CloseBuff
        {
            get;
            set;
            // var msg = !_closeBuff ? "Burst On" : "Burst Off";
            // GUIHelper.ShowToast(msg,2000);
        }

        public bool Stop { get; set; }

        public bool AutoAttack { get; set; }

        public bool UseTrueNorth { get; set; }

        public bool UseAOE { get; set; } = true;

        public string TimeStr { get; set; }


        public GeneralSettings GeneralSettings { get; } = SettingMgr.GetSetting<GeneralSettings>();
        public BardSettings BardSettings => SettingMgr.GetSetting<BardSettings>();
        public ReaperSettings ReaperSettings => SettingMgr.GetSetting<ReaperSettings>();

        public DebugCenter DebugCenter => DebugCenter.Intance;

        public HotkeySetting HotkeySetting => SettingMgr.GetSetting<HotkeySetting>();
        public TriggerLine CurrTriggerLine { get; set; }

        public void Reset()
        {
            CloseBuff = false;
            Stop = false;
            UseApex = true;
            UseDot = true;
            AutoAttack = false;
            UseHarpe = false;
            UseSoulGauge = true;
            DoubleEnshroudPrefer = true;
            UseAOE = true;
            TimeStr = "";
        }


        public void Update()
        {
            if (GeneralSettings.ShowBattleTime)
                TimeStr = $"战斗时间:  {AIRoot.Instance.BattleData.BattleTime / 1000}";
            else
                TimeStr = $"本地时间:  {DateTime.Now:hh:mm:ss}";
        }


        #region Bard

        public bool UseDot { get; set; } = true;

        public bool UseApex { get; set; } = true;

        #endregion

        #region Reaper

        public bool UseHarpe { get; set; }
        public bool UseSoulGauge { get; set; } = true;

        public bool DoubleEnshroudPrefer { get; set; } = true;

        #endregion
    }
}