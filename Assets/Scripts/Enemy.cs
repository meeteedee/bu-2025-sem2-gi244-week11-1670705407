using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    private Rigidbody rb;
    private GameObject player;
    
    public bool isStunned = false; 
    
    public float deathYThreshold = -10f; 

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
        
        CheckOutOfBounds();
    }
    
    private void CheckOutOfBounds()
    {
        if (transform.position.y < deathYThreshold)
        {
            Destroy(gameObject); 
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