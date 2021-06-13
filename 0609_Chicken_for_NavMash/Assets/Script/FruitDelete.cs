using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitDelete : MonoBehaviour
{    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Box") || other.gameObject.CompareTag("Floor") || this.gameObject.transform.position.y < 0f)
            this.gameObject.SetActive(false);
        FruitManager.Re_Using_Fruit();
    }    

}
