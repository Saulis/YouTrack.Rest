using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YouTrack.Rest
{
    public static class Commands
    {
        public static string SetSubsystem(string subsystem)
        {
            return String.Format("Subsystem {0}", subsystem);
        }

        public static string SetType(string type)
        {
            return String.Format("Type {0}", type);
        }
    }
}
