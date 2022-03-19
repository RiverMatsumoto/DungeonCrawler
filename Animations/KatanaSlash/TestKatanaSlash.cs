using UnityEngine;
using Sirenix.OdinInspector;

public class TestKatanaSlash : MonoBehaviour
{
    public Animator anim;

    [Button]
    public void PlayAnimation(string name)
    {
        anim.Play("KatanaSlash");
    }
}
