using UnityEngine;

public class SkillList : MonoBehaviour
{
    public void showList()
    {
        gameObject.SetActive(true);
    }

    public void hideList()
    {
        gameObject.SetActive(false);
    }
}
