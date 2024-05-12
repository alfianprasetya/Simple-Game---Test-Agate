using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordEnemy : MonoBehaviour
{
    private float speedSword = 150f;
    private Transform parentObject;
    // Start is called before the first frame update
    void Start()
    {
        parentObject = this.transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(parentObject.localPosition, Vector3.forward, Time.deltaTime*speedSword);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("SwordPlayer"))
        {
            parentObject.GetComponent<EnemyMovement>().DeleteList(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
