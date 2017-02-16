using System;

namespace Sagitta.Enum
{
    public enum IllustType
    {
        Illust,

        Manga,

        Ugoira
    }

    public static class IllustTypeExt
    {
        internal static string ToParameterStr(this IllustType obj)
        {
            switch (obj)
            {
                case IllustType.Illust:
                    return "illust";

                case IllustType.Manga:
                    return "manga";

                default:
                    throw new ArgumentOutOfRangeException(nameof(obj), obj, null);
            }
        }
    }
}