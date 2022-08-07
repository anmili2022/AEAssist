using PropertyChanged;
using System;

namespace AEAssist.TriggerAction
{
    [Trigger("ToggleStop 切换停手", ParamTooltip = " 切换停手，0 = off关闭停手, 1 = on打开停手")]
    [AddINotifyPropertyChangedInterface]
    public class TriggerAction_ToggleStop : ITriggerAction
    {
        public bool value { get; set; }

        public void WriteFromJson(string[] values)
        {
            if (!int.TryParse(values[0], out var va)) throw new Exception($"{values[0]}Error!\n");

            value = va == 1;
        }

        public string[] Pack2Json()
        {
            return new string[]
            {
                value ? "1" : "0"
            };
        }

        public void Check()
        {

        }
    }
}