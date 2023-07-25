using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomerTimer : MonoBehaviour
{
    [SerializeField] private float maxValue = 3f;

    [SerializeField] private Slider customerTimer;

    private float currentValue;

    // Start is called before the first frame update
    void Start()
    {
        currentValue = maxValue;
        customerTimer.maxValue = maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue -= Time.deltaTime;
        customerTimer.value = currentValue;
    }
}
