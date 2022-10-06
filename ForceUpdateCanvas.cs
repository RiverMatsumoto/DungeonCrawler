using UnityEngine;
using Sirenix.OdinInspector;

public class ForceUpdateCanvas : MonoBehaviour
{
    [Button]
    public void UpdateCanvas()
    {
        Canvas.ForceUpdateCanvases();
    }
}
