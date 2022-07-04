using System;
using ff14bot.Enums;

namespace AEAssist
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class JobAttribute : Attribute
    {
        public ClassJobType ClassJobType;

        public JobAttribute(ClassJobType classJobType)
        {
            ClassJobType = classJobType;
        }
    }
}