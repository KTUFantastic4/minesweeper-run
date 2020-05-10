using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//[RequireComponent(typeof(Rigidbody2D))]
public class SunItem : MonoBehaviour
{
    public GameObject effect;
    private Transform player;
    //public player
    // Start is called before the first frame update
    private void Start()
    {
        //var player = GameObject.Find("Player").GetComponent<Player>().lives+=1;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use()
    {
        //GameObject.Find("Player").GetComponent<Player>().lives += 1;
        var playerObject = GameObject.Find("Player");
        playerObject.GetComponent<MovementController>().SunItemUsed();
        Instantiate(effect, player.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
