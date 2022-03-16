using UnityEngine;

public class BackButton : MonoBehaviour
{
    public void CancelSelect() => PlayerSelectSystem.Instance.SelectPlayerCancel();
}