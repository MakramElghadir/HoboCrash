using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hereComesTheSun : MonoBehaviour
{
    // Start is called before the first frame update
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            gameObject.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
