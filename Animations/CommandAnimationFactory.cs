using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName ="CommandAnimationFactory", menuName ="ScriptableObjects/CommandAnimationFactory")]
public class CommandAnimationFactory : SerializedMonoBehaviour
{
    public GameObject commandAnimation;

    public GameObject createAnimation(BattleCommand cmd)
    {
        return Instantiate(commandAnimation, cmd.target.transform);
    }
}
