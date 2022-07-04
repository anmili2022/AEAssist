using System;

namespace AEAssist.View
{
    [AttributeUsage(AttributeTargets.Property)]
    public class GUILabelAttribute : Attribute
    {
        public string LabelName;

        public GUILabelAttribute(string str)
        {
            this.LabelName = str;
        }
    }
}