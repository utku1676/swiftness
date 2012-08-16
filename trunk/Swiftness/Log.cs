using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cpg.Swiftness
{
    enum LogLevel
    {
        DEBUG = 0,
        INFO = 1, 
        WARNING = 2,
        CRITICAL = 3,
        ERROR = 4
    }

    static class Log
    {
        static Forms.frmLog log;

        public static void Setup(Forms.frmLog frmLog)
        {
            log = frmLog;
        }
        
        public static void Write(string message)
        {
            log.WriteLog(message);
        }


    }
}
