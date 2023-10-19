using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{

    public GameObject DishWashSignal;
    // Start is called before the first frame update
    void Start()
    {
        DishWashSignal.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Done();
        }
    }

    void Done()
    {
        DishWashSignal.SetActive(true);
    }
}