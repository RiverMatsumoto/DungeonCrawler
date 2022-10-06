using UnityEngine;
using Sirenix.OdinInspector;

public class CommandAnimation : MonoBehaviour
{
    public delegate void AnimationStarted();
    public static event AnimationStarted _animationStarted;
    public delegate void AnimationEnded();
    public static event AnimationEnded _animationEnded;
    public Animator _anim;
    public BattleCommand cmd { get; set; }

    [Button]
    public void PlayAnimation(string animation, BattleEntity target)
    {
        this.transform.position = target.transform.position;
        _anim.Play(animation);
    }

    public static void animationStarted() => _animationStarted();

    public static void animationEnded() => _animationEnded();
}
