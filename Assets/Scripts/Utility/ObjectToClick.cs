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
        CommonEvents.Instance.OnClicked += CircleAnimation;
    }

    private void OnDisable()
    {
        CommonEvents.Instance.OnClicked -= CircleAnimation;
    }

    private void OnMouseDown()
    {
        //_animator.SetTrigger(_triggerName);
        CommonEvents.Instance.OnClicked.Invoke();
    }

    private void CircleAnimation()
    {
        _animator.SetTrigger(_triggerName);
    }
}
