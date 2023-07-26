using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask productMask;
    [SerializeField] private KeyCode restockKeycode, pickKeyCode;

    [SerializeField] Transform holdArea;
    [SerializeField] private float pickupForce = 150f;
    private GameObject heldObj;
    private Rigidbody heldObjRb;
    private void Update()
    {
        InteractObject();
    }

    private void InteractObject()
    {
        Ray ray = new Ray(transform.position + Vector3.up * 1.2f, transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        if (Physics.Raycast(ray, out RaycastHit hit, distance, productMask))
        {
            if (hit.collider.TryGetComponent(out Interactable interactable))
            {
                int currentStock = interactable.GetComponent<Product>().currentStock;
                if (Input.GetKeyDown(restockKeycode))
                {
                    interactable.BaseInteract();
                }
                
                if (Input.GetKeyDown(pickKeyCode) && currentStock > 0)
                {
                    if (heldObj == null)
                    {
                        interactable.GetComponent<Product>().ReduceStock();
                        PickupObject(hit.transform.gameObject);
                    }
                    else
                    {
                        DropObject();
                    }
                }
                if (heldObj != null)
                {
                    MoveObject();
                }
            }
        }
    }
    
    void MoveObject()
    {
        if (Vector3.Distance(heldObj.transform.position, holdArea.position) > 0.1f)
        {
            Vector3 moveDirection = (holdArea.position - heldObj.transform.position);
            heldObjRb.AddForce(moveDirection * pickupForce);
        }
    }

    void PickupObject(GameObject pickObj)
    {
        Vector3 pos = holdArea.position;
        var obj = Instantiate(pickObj, pos, Quaternion.identity, holdArea);
        obj.AddComponent<Rigidbody>();
        heldObjRb = obj.GetComponent<Rigidbody>();
        heldObjRb.useGravity = false;
        heldObjRb.constraints = RigidbodyConstraints.FreezeAll;
        heldObj = obj;
    }

    void DropObject()
    {
        heldObjRb.useGravity = true;
        heldObjRb.drag = 1;
        heldObjRb.constraints = RigidbodyConstraints.None;

        heldObj.transform.parent = null;
        heldObj = null;
    }
}
