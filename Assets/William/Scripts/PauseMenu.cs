using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject innerManager;

    public void SetInnerActive(bool active)
    {
        innerManager.SetActive(active);
    }

}
