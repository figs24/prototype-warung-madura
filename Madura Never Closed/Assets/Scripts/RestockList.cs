using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestockList : Interactable
{
    [SerializeField] private GameObject[] products;
    
    protected override void Interact()
    {
        for (int i = 0; i < products.Length; i++)
        {
            products[i].layer = 6;
        }
    }
}
