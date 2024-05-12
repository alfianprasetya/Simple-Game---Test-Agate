using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{
    PlayerController playerController;
    [SerializeField] AudioSource swordFX;

    [SerializeField]
    private float speedSword = 150f;
    private Transform parentObject;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        parentObject = this.transform.parent;

    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(parentObject.localPosition, Vector3.forward, Time.deltaTime*speedSword);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            speedSword = speedSword * -1;  
        }

        if(other.gameObject.CompareTag("SwordEnemy"))
        {
            swordFX.Play();
            playerController.DeleteList(this.gameObject);
            Destroy(this.gameObject);
        }
    }
}
