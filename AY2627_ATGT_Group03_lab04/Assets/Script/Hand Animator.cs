using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimator : MonoBehaviour
{
    public enum HandSide
    {
        Auto = 0,
        Left = 1,
        Right = 2
    }

    [SerializeField] private HandSide handSide = HandSide.Auto;
    [SerializeField] private InputActionAsset inputActions;
    [SerializeField] private InputActionProperty TriggerValueAction;
    [SerializeField] private InputActionProperty GripValueAction;

    private Animator animator;
    private InputAction triggerAction;
    private InputAction gripAction;

    void Awake()
    {
        animator = GetComponent<Animator>();
        ResolveHandSide();
        ResolveActions();
    }

    void OnEnable()
    {
        ResolveActions();
        triggerAction?.Enable();
        gripAction?.Enable();
        triggerAction?.actionMap?.Enable();
        gripAction?.actionMap?.Enable();
    }

    void ResolveHandSide()
    {
        if (handSide != HandSide.Auto)
            return;

        string n = gameObject.name.ToLowerInvariant();
        handSide = n.Contains("right") ? HandSide.Right : HandSide.Left;
    }

    void ResolveActions()
    {
        if (TriggerValueAction.action != null)
            triggerAction = TriggerValueAction.action;
        if (GripValueAction.action != null)
            gripAction = GripValueAction.action;

        if (triggerAction != null && gripAction != null)
            return;

        if (inputActions == null)
        {
            var assets = Resources.FindObjectsOfTypeAll<InputActionAsset>();
            foreach (var asset in assets)
            {
                if (asset != null && asset.name.Contains("XRI Default"))
                {
                    inputActions = asset;
                    break;
                }
            }
        }

        if (inputActions == null)
            return;

        string mapName = handSide == HandSide.Right
            ? "XRI RightHand Interaction"
            : "XRI LeftHand Interaction";

        if (triggerAction == null)
            triggerAction = inputActions.FindAction(mapName + "/Activate Value", false);
        if (gripAction == null)
            gripAction = inputActions.FindAction(mapName + "/Select Value", false);
    }

    void Update()
    {
        if (animator == null || triggerAction == null || gripAction == null)
            return;

        animator.SetFloat("Trigger", triggerAction.ReadValue<float>());
        animator.SetFloat("Grip", gripAction.ReadValue<float>());
    }
}
