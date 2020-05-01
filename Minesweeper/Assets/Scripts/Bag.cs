using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag : MonoBehaviour
{
    public bool isClosed = false;
    public GameObject bagObject;

    public void OpenCloseBag()
    {
        if (isClosed == true)
        {
            bagObject.SetActive(true);
            isClosed = false;
        }
        else
        {
            bagObject.SetActive(false);
            isClosed = true;
        }
    }
}
