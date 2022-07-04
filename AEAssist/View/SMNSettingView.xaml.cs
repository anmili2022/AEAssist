using System;
using System.Collections.Generic;
using UserControl = System.Windows.Controls.UserControl;

namespace AEAssist.View
{
    public partial class SMNSettingView : UserControl
    {
        public SMNSettingView()
        {
            InitializeComponent();

            var swiftcastOption = new Dictionary<int, string>
            {
                { 0, "None/不使用" },
                { 1, "Slipstream/螺旋气流" },
                { 2, "Ruby Catastrophe/红宝石" },
                { 3, "Any/任意"}
            };
            SwiftcastOption.ItemsSource = swiftcastOption;
            SwiftcastOption.SelectedIndex = SettingMgr.GetSetting<SMNSettings>().SwiftcastOption;



        }
        private void ChooseSwiftcastOption_OnSelectionChanged(object sender, EventArgs eventArgs)
        {
            SettingMgr.GetSetting<SMNSettings>().SwiftcastOption = int.Parse(SwiftcastOption.SelectedValue.ToString());
        }


    }
}