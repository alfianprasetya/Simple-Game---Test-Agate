using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] AudioSource swordFX;
    [SerializeField] TMP_Text poin;
    [SerializeField]
    private float speed = 5.0f;
    private bool isMove = false;
    public GameObject swordPrefab;
    public List<GameObject> swordObject = new List<GameObject>();

    public UnityEvent onPlayerDie = new UnityEvent();

    void Update()
    {
        if(isMove)
        {
            poin.text = swordObject.Count.ToString();

            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");

            Vector2 direction = new Vector2(horizontalInput, verticalInput);

            transform.Translate(direction * speed * Time.deltaTime);  

            direction.Normalize();
            if(direction.magnitude > 0.1f)
            {
                animator.SetFloat("Horizontal", direction.x);
                animator.SetFloat("Vertical", direction.y);
            }
            animator.SetFloat("Speed", direction.magnitude);

            if(swordObject.Count == 0)
            {
                GetComponent<Collider>().isTrigger = true;
            }
            else
                GetComponent<Collider>().isTrigger = false;

            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Item"))
        {
            
            // GameObject sword = Instantiate(swordPrefab, new Vector3(this.transform.position.x, this.transform.position.y * -1, this.transform.position.z), this.transform.rotation);  
            GameObject sword = Instantiate(swordPrefab, this.transform);
            swordObject.Add(sword);
            // GenerateSword(-25f, 100f, 6);
            
        }

        if(other.gameObject.CompareTag("SwordEnemy"))
        {
            swordFX.Play();
        }

        if(other.gameObject.CompareTag("SwordEnemy") && swordObject.Count == 0)
        {
            Time.timeScale = 0;
            isMove = false;
            onPlayerDie.Invoke();
        }
    }

    private void GenerateSword()
    {
        GameObject sword = Instantiate(swordPrefab, this.transform);
        swordObject.Add(sword);
    }

    public void DeleteList(GameObject sword)
    {
        swordObject.Remove(sword);
    }

    public void IsMove()
    {
        isMove = true;
        GenerateSword();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
