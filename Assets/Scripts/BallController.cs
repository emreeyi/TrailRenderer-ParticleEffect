using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody rg;
    public float speed = 10;
    public GameObject patlamaefekti;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 force = new Vector3(0, 0, 100);
        rg.AddForce(force *speed* Time.deltaTime);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "WoodenCrateCracked")
        {
            patlamaefekti.SetActive(true);
            Transform[] cocuklar = collision.transform.gameObject.GetComponentsInChildren<Transform>();
            collision.transform.gameObject.GetComponent<BoxCollider>().enabled = false;
            foreach (var gelencocuklar in cocuklar)
            {
                gelencocuklar.gameObject.AddComponent<Rigidbody>();
                
            }
        }
    }
}
