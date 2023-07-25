using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingTableController : MonoBehaviour
{
    [SerializeField] private List<string> items;
    [SerializeField] private GameObject request;
    [SerializeField] private GameObject customer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        foreach (var item in items)
        {
            if (other.gameObject.CompareTag(item))
            {
                items.Remove(item);
                Destroy(other.gameObject);
                if (items.Count == 0)
                {
                    Destroy(request);
                    Destroy(customer);
                }
            }
        }
    }
}
