using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    // Start is called before the first frame update


    public void DecreaseStack()
    {
        GameManager.Instance.currentStack--;
    }


    private void OnTriggerEnter(Collider other)
    {
        Character character = other.GetComponent<Character>();
        if (character&&GameManager.Instance.currentStack>0)
        {
            DecreaseStack();
        }
    }
    
    
}
