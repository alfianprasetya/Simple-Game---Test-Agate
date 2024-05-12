using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ItemManager : MonoBehaviour
{
    [SerializeField]
    int poin = 5;

    public TMP_Text poinText;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("SwordPlayer"))
        {
            GetComponent<Renderer>().material.color = Color.red;
            poin--;
        }

        else if(other.gameObject.CompareTag("Player"))
        {
            GetComponent<Renderer>().material.color = Color.red;
            poin--;
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("SwordPlayer"))
        {
            GetComponent<Renderer>().material.color = Color.white;
        }
    }

    private void Update() 
    {
        poinText.text = poin.ToString();
        if(poin <= 0)
        {
            // StartCoroutine(FadeOut());
            Destroy(this.gameObject);
        }
    }

    IEnumerator FadeOut()
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            GetComponent<Renderer>().material.color = new Color(1, 1, 1, i);
            yield return null;
        }
        Destroy(this.gameObject);
    }
}
