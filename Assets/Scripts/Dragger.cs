using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Dragger : MonoBehaviour
{
    [SerializeField] private InputAction mouseClick;
    [SerializeField] private float mouseDragPhysicsSpeed;
    [SerializeField] private float mouseDragSpeed = .1f;

    private Camera mainCamera;
    private WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
    private Vector3 velocity = Vector3.zero;

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    private void OnEnable()
    {
        mouseClick.Enable();
        mouseClick.performed += MousePressed;
    }

    private void OnDisable()
    {
        mouseClick.performed -= MousePressed;
        mouseClick.Disable();
    }

    private void MousePressed(InputAction.CallbackContext context)
    {
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            if(hit.collider != null && hit.collider.gameObject.layer == LayerMask.NameToLayer("Drag"))
            {
                StartCoroutine(DragUpdate(hit.collider.gameObject));
            }
        }
    }

    private IEnumerator DragUpdate(GameObject clickedObject)
    {
        float initialDistance = Vector3.Distance(clickedObject.transform.position, mainCamera.transform.position);
        clickedObject.TryGetComponent<Rigidbody>(out var rb);
        while (mouseClick.ReadValue<float>() != 0)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
            if (rb == null)
            {
                yield return null;
            }
            else
            {
                clickedObject.transform.position = Vector3.SmoothDamp(new Vector3(clickedObject.transform.position.x, 1.5f, clickedObject.transform.position.z),
                    ray.GetPoint(initialDistance), ref velocity, mouseDragSpeed);
                yield return waitForFixedUpdate;
            }
        }
    }
 }
