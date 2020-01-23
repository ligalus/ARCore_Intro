using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class Intro : MonoBehaviour
{
    [SerializeField] private GameObject Text;
    [SerializeField] private int timer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HideObject());
    }

    IEnumerator HideObject()
    {
        yield return new WaitForSeconds(timer);
        Text.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
