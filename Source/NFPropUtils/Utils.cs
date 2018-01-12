using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.Localization;

namespace NFPropUtils
{
  public static class Utils
  {

    public static string modName = "NFProps";

    /// Sets up an animation for KSP purposes and returns it
    public static AnimationState SetUpAnimation(string animationName, InternalModule prop, int layer)
    {
        Animation animation  = prop.internalProp.FindModelAnimators(animationName).First();
        AnimationState animationState = animation[animationName];
        animationState.speed = 0;
        animationState.layer = layer;
        animationState.enabled = true;
        animationState.wrapMode = WrapMode.ClampForever;

        animation.Blend(animationName);

        return animationState;
    }
  }
}
