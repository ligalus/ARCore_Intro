using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodConsumer : MonoBehaviour
{


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "food") //edamas senes
        {
            collision.gameObject.SetActive(false);
            Slithering s = GetComponentInParent<Slithering>();

            if (s != null)
            {
                s.AddBodyPart();
            }
        }

        else if (collision.gameObject.tag == "notfood") //needamas senes
        {
            //Application.Quit();
            /////Debug.Log("Nekas nesanak");
        }

    }


}
