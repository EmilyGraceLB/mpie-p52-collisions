using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UIElements;

public class AmmoCollection : MonoBehaviour
{
    // Start is called before the first frame update
     public float ammoLevel = 0;
    public float shotCount = 20;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Ray ray =  Camera.main.ViewportPointToRay(new Vector3(0.5f ,0.5f ,0.0f));
        Input.GetMouseButtonDown(0);
        if(Input.GetMouseButtonDown(0) == true) {
            shotCount--;
            Console.Write("ammoLevel" + shotCount);
        }
        RaycastHit result;
        if(Physics.Raycast(ray, out result)) {
            GameObject g = result.collider.gameObject;
            Animation a = g.transform.parent.GetComponent<Animation>();
            a.Play("LowerBridge");
        }

    }

    private void OnTriggerEnter(Collider other) { 
        //checks if collider is the collider on the ammo box
        if(other.gameObject.name == "AmmoBox") {
            //hide ammo box
            other.gameObject.SetActive(false);
            //sets ammo level to 20
            ammoLevel = 20;
            //prints ammo level to console
            Console.Write("ammoLevel"+ammoLevel);
        }   
    }
}
