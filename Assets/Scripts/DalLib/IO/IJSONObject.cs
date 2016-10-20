using UnityEngine;

namespace ProjectSpacer
{
    public interface IJSONObject
    {
        string GetJSONString();
        T FromJSON<T>(string JSONString);
    }
}
 