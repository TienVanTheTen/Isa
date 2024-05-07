using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpManager : MonoBehaviour
{
    const string PICKUP_TAG = "Pickup";

    //if you collide with something that you can pickup
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(PICKUP_TAG))
        {
            IPickup pickUps = collision.GetComponent<IPickup>();
            pickUps.PickUp(gameObject);
        }
    }
}
