using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Gun : MonoBehaviour
{

    public InputActionProperty TriggerAction;

    [SerializeField]
    private Transform shootingPoint;

    [SerializeField]
    private GameObject bulletprefab;

    [SerializeField]
    public float power;

    // Start is called before the first frame update
    private void OnEnable()
    {
        TriggerAction.action.performed += Fire;
    }

    private void OnDisable()
    {
        TriggerAction.action.performed -= Fire; 
    }

    void Fire(InputAction.CallbackContext context)
    {
        GameObject bullet = Instantiate(bulletprefab, shootingPoint.position, shootingPoint.rotation) as GameObject;
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.AddForce(Vector3.forward * power, ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
