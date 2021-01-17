using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AboutPanel : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _animator.SetBool("PanelEnabled", true);
    }
}
