using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using KSP.Localization;

namespace NFPropUtils
{
  public class ModuleAnimatableProp: InternalModule
  {
    [KSPField]
    public string animationName = "";

    [KSPField]
    public int animationLayer = 1;

    [KSPField]
    public float animationSpeed = 1f;

    [KSPField]
    public float animationRandomSpeed = 0f;

    [KSPField]
    public float animationRandomStart = 0f;

    private AnimationState anim;
    private float animRealSpeed;

    public void Start()
    {
      if (animationName != "")
      {
        anim = Utils.SetUpAnimation(animationName, this.internalProp, animationLayer);
        anim.normalizedTime = Random.Range(0f, animationRandomStart);
        animRealSpeed = animationSpeed + Random.Range(-animationRandomSpeed, animationRandomSpeed);
      }
    }
    public void FixedUpdate()
    {
      if (anim != null)
      {
        anim.normalizedTime += TimeWarp.fixedDeltaTime * animRealSpeed;
        // Wrap me
        if (anim.normalizedTime >= 1.0)
          anim.normalizedTime = 0.0;
      }
    }
  }

}
