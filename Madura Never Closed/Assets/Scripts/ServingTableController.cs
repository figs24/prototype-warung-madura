using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingTableController : MonoBehaviour
{
    [SerializeField] private List<string> items;
    [SerializeField] private GameObject request;
    [SerializeField] private GameObject customer;

    private void OnCollisionEnter(Collision other)
    {
        foreach (var item in items)
        {
            if (other.gameObject.CompareTag(item))
            {
                Destroy(other.gameObject);
                items.Remove(item);
                if (items.Count == 0)
                {
                    Destroy(request);
                    Destroy(customer);
                }
            }
        }
    }
}
