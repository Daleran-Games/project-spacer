using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpacer
{
    public interface IEffect
    {
         Dictionary<GridEffect, Vector2> GetEffect();
    }

}

