using UnityEngine;
using System.Collections;

public class collisionScript : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    //for this to work both need colliders, one must have rigid body (spaceship) the other must have is trigger checked.
    void OnTriggerEnter(Collider col)
    {
        GameObject explosion = Instantiate(Resources.Load("FlareMobile", typeof(GameObject))) as GameObject;
        explosion.transform.position = transform.position;
        Destroy(col.gameObject);
        Destroy(explosion, 0.5f);
        Debug.Log("gonna destroy");


      
        
        Destroy(gameObject);

    }

}