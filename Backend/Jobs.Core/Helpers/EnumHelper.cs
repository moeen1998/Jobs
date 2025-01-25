
using Jobs.Core.Attributes;

namespace Jobs.Core.Helpers;
public static class EnumHelper
{
    public static string GetDescription(this object obj)
    {
        return 
            obj is not null ?
            DescriptionAttribute.GetDescription(obj) :
            "NO AVAILABLE DESCRIPTION";
    }
}
