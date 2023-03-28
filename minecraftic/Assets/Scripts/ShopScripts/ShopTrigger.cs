using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private GameObject shopImage;
    private void OnTriggerEnter(Collider other)
    {
        shopImage.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        shopImage.SetActive(false);
    }

}
