using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int health = 5;
    [SerializeField] Image[] heart;

    void Update()
    {
        // Loop through all hearts
        for (int i = 0; i < heart.Length; i++)
        {
            if (i < health)
            {
                // Activate hearts based on health
                heart[i].enabled = true;
            }
            else
            {
                // Deactivate hearts if health is less than index
                heart[i].enabled = false;
            }
        }

        TestFunction();
    }


    void TestFunction()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (health > 0)
            {
                health--;
                Debug.Log("Health decreased. Current health: " + health);
            }
            else
            {
                
                Debug.Log("Health is already at zero.");
                return;
            }
        }
    }
}