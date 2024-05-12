using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField] Animator animator;
    [SerializeField, Range(1, 10)]
    private float speed = 1;

    private GameObject target;
    private GameObject manager;

    public List<GameObject> swordObject = new List<GameObject>();
    void Start()
    {
        manager = GameObject.Find("Game Manager");
        gameManager = manager.GetComponent<GameManager>();
        target = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("SwordPlayer") && swordObject.Count == 0)
        {
            speed = 0;
            animator.SetBool("isDeath", true);
        }
    }

    public void Death()
    {
        Destroy(this.gameObject);
    }
    public void DeleteList(GameObject sword)
    {
        swordObject.Remove(sword);
    }
}
