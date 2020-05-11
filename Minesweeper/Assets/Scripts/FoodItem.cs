using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodItem : MonoBehaviour
{
    public GameObject effect;
    private Transform player;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        var playerObject = GameObject.Find("Player");
        playerObject.GetComponent<MovementController>().FoodItemUsed();
        Instantiate(effect, player.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
