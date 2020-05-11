using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboSuitItem : MonoBehaviour
{
    public GameObject effect;
    private Transform player;
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
        playerObject.GetComponent<MovementController>().RobotItemUsed();
        //Instantiate(effect, player.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
