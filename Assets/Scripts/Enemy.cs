using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    private GameObject player;
    
    public bool isStunned = false; 

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        if (!isStunned && player != null)
        {
            Vector3 dir = player.transform.position - transform.position; 
            dir.Normalize(); 
            rb.AddForce(dir * speed);
        }
    }
    
    public void StunEnemy(float duration)
    {
        StartCoroutine(StunRoutine(duration));
    }
    
    private IEnumerator StunRoutine(float duration)
    {
        isStunned = true;
        
        rb.linearVelocity = Vector3.zero;
        rb.isKinematic = true; 
        
        yield return new WaitForSeconds(duration);
        rb.isKinematic = false; 
        
        isStunned = false;
    }
}