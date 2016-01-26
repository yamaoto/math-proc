using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mathproc
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    [Serializable]
    public class MpException : Exception
    {
        public MpException()
        {
        }

        public readonly ErrorCodes Code;

        public MpException(string message, ErrorCodes code) : base(message)
        {
            Code = code;
        }

        public MpException(string message, ErrorCodes code, Exception inner) : base(message, inner)
        {
            Code = code;
        }

        protected MpException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {            
        }

        public static string GetMessage(ErrorCodes code)
        {
            return Messages[code];
        }

        public static Dictionary<ErrorCodes, string> Messages = new Dictionary<ErrorCodes, string>()
        {
            {ErrorCodes.TP_Если_1,"Ошибка в конструкции 'ТО', в начале необходимо указать условие." },
            {ErrorCodes.TP_Если_2,"Ошибка в конструкции 'ИНАЧЕ', в начале необходимо указать условие." },
            {ErrorCodes.TP_Если_3,"ЗАРЕЗЕРВИРОВАННАЯ ОШИБКА" },
            {ErrorCodes.TP_Если_4,"ЗАРЕЗЕРВИРОВАННАЯ ОШИБКА" },

            {ErrorCodes.TP_Выражения1,"Использование оператора без операндов." },
            {ErrorCodes.TP_Выражения2,"Ошибка определения оператора." },
            {ErrorCodes.TP_Выражения3,"Ошибка разборки скобок в выражении." },
            {ErrorCodes.TP_Выражения4,"ЗАРЕЗЕРВИРОВАННАЯ ОШИБКА" },

        };
    }
    public enum ErrorCodes : int
    {
        Unknown=0,
        TP_Если_1=101,
        TP_Если_2=102,
        TP_Если_3=103,
        TP_Если_4=104,

        TP_Выражения1=111,
        TP_Выражения2=112,
        TP_Выражения3=113,
        TP_Выражения4=114,
    }


}
