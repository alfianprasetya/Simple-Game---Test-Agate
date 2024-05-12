using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float lerpSpeed = 5.0f;
    [SerializeField] float leftLimit;
    [SerializeField] float rightLimit;
    [SerializeField] float topLimit;
    [SerializeField] float bottomLimit;

    private GameObject player;
    private Vector3 offset;
    private Vector3 targetPos;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        if(player == null) return;

        offset = transform.position - player.transform.position;
    }

    void Update()
    {
        if(player == null) return;

        targetPos = player.transform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
    
        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, topLimit),
            transform.position.z
        );
    }
}
