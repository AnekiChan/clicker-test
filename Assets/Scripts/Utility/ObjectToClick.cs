using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectToClick : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private string _triggerName;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnMouseDown()
    {
        _animator.SetTrigger(_triggerName);
        CoinStats.OnClicked.Invoke();
    }
}
