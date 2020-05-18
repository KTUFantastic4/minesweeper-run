using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunItem : MonoBehaviour
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
        playerObject.GetComponent<MovementController>().SunItemUsed();
        Instantiate(effect, player.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
