using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Gun : MonoBehaviour
{
    [SerializeField] private Transform shootingPoint;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private float power = 2f;

    private XRGrabInteractable grabInteractable;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    void OnEnable()
    {
        if (grabInteractable != null)
            grabInteractable.activated.AddListener(OnActivated);
    }

    void OnDisable()
    {
        if (grabInteractable != null)
            grabInteractable.activated.RemoveListener(OnActivated);
    }

    void OnActivated(ActivateEventArgs args)
    {
        if (shootingPoint == null || bulletprefab == null)
            return;

        GameObject bullet = Instantiate(bulletprefab, shootingPoint.position, shootingPoint.rotation);
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        if (bulletRB != null)
            bulletRB.AddForce(shootingPoint.forward * power, ForceMode.Impulse);
    }
}
