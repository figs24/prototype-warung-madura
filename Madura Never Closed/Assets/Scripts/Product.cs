using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Product : Interactable
{
    [SerializeField] private TextMeshProUGUI stockText;
    [SerializeField] private int maxStock;
    
    public int currentStock;

    private void Start()
    {
        UpdateStockUI();
    }

    protected override void Interact()
    {
        currentStock = maxStock;
        UpdateStockUI();
    }

    public void ReduceStock()
    {
        currentStock--;
        UpdateStockUI();
    }

    private void UpdateStockUI()
    {
        stockText.text = currentStock + "/" + maxStock;
    }
}
