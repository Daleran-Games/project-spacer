using System;
using UnityEngine;
using System.Collections;


namespace ProjectSpacer
{
    public interface IStat 
    {
        Info StatInfo { get; }
        Type Type { get; }
    }
}

