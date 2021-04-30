using Domain;
using System;

namespace Samples
{
    public static class Func
    {
        public static string FuncDelegateWithAnonymousMethods()
        {
            Developer developer = new Developer() { FirstName = "VSeSharp" };
            Func<string> introduceMethodCall = delegate () { return developer.IntroduceDeveloper(); };
            return introduceMethodCall();
        }

        public static string FuncDelegateToANonStaticMethod()
        {
            Developer developer = new Developer() { FirstName = "VSeSharp" };
            Func<string> introduceMethodCall = developer.IntroduceDeveloper;
            return introduceMethodCall();
        }
    }
}
