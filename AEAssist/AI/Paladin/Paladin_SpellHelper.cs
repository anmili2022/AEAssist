using System;
using System.Linq;
using System.Windows.Media;
using AEAssist.Define;
using AEAssist.Define.DataStruct;
using AEAssist.Helper;
using Buddy.Coroutines;
using ff14bot;
using ff14bot.Helpers;
using ff14bot.Managers;
using ff14bot.Objects;
using ff14bot.RemoteWindows;
namespace AEAssist.AI.Paladin
{
    public static class Paladin_SpellHelper
    {
        
        public static bool Debugging { get; set; } = true;
        public static bool CheckUseAOE()
        {
            return false;
        }
    }
}