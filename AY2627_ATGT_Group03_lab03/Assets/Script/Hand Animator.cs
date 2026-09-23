using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{

    private Animator animator;

    [SerializeField]
    private InputActionProperty TriggerValueAction;
    private InputActionProperty GripValueAction;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float triggerValue = TriggerValueAction.action.ReadValue<float>();
        float gripValue = GripValueAction.action.ReadValue<float>();

        animator.SetFloat("Trigger", triggerValue);
        animator.SetFloat("Grip", gripValue);

    }
}
