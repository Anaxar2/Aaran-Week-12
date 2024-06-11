using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class potion : MonoBehaviour
{
    public potionInfo _potion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if(collision.tag == "Player")
        {
            collision.GetComponent<playerMovement>().health += _potion.health;
            collision.GetComponent<playerMovement>().stamina += _potion.stamina;
            collision.GetComponent<playerMovement>().magick += _potion.magick;
            Destroy (gameObject);
        }
    }
}
