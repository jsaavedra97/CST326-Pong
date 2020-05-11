using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameObject clone;
    public bool isMultiBall;

    private void OnTriggerEnter(Collider other)
    {
        // This power up creates a new ball evry time it is hit
        if(other.gameObject.name == "Ball" && isMultiBall)
		{
            Debug.Log("Ball Collided with me");
			GameObject clone = Instantiate(other.gameObject, transform.position, transform.rotation);
            Destroy(clone, 3f);

        }
        
        // This power up increases the balls size
        if (other.gameObject.name == "Ball" && !isMultiBall)
		{
            other.gameObject.transform.localScale = new Vector3(2, 2, 2);
		}


    }

    void OnCollisionEnter(Collision collision)
	{
        Destroy(this);
	}
}
