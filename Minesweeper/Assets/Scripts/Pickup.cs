﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.items[i] == 0)
                {
                    inventory.items[i] = 1;
                    
                    Instantiate(itemButton, inventory.slots[i].transform, false);
                    Destroy(gameObject);FindObjectOfType<AudioManager>().Play("PickupSound");
                    break;
                }
            }

        }
    }
}
