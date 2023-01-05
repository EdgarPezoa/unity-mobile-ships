using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    [SerializeField] float fireRate = 0.07f;
    [SerializeField] GameObject Laser;
    PlayerInput playerInput;
    InputAction fireAction;
    bool isFire = false;
    bool isShooting = false;

    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        fireAction = playerInput.actions.FindAction("Fire");
        fireAction.performed += FireContext;
        fireAction.canceled += FireContext;
    }

    void Update()
    {
        if (isFire && !isShooting)
        {
            isShooting = true;
            StartCoroutine(Shoot());
        }
    }

    private void OnEnable()
    {
        fireAction.Enable();
    }

    private void OnDisable()
    {
        fireAction.Disable();
    }

    //CUSTOM METHODS
    void FireContext(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            isFire = true;
        }

        if (context.canceled)
        {
            isFire = false;
        }
    }

    IEnumerator Shoot()
    {
        while (isFire)
        {
            Instantiate(
                        Laser,
                        transform.position,
                        Quaternion.identity
                    );
            yield return new WaitForSeconds(fireRate);
        }
        isShooting = false;
    }
}
