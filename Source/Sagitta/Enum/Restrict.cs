using System;

namespace Sagitta.Enum
{
    public enum Restrict
    {
        Public,

        Private,

        All
    }

    public static class RestrictExt
    {
        internal static string ToParameterStr(this Restrict restrict)
        {
            switch (restrict)
            {
                case Restrict.Public:
                    return "public";

                case Restrict.Private:
                    return "private";

                case Restrict.All:
                    return "all";

                default:
                    throw new ArgumentOutOfRangeException(nameof(restrict), restrict, null);
            }
        }
    }
}