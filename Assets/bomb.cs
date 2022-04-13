using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Player")
        {
            Destroy(other.gameObject);
          
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
