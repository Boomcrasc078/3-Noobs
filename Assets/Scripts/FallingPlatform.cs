using System.Collections;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    private float fallWait = 2f;
    private float destroyWait = 1f;
   

    private bool isFalling;
    private Rigidbody2D rgbd; 
    
    void Start()
    {
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!isFalling && collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall()
    {
        isFalling = true;
        yield return new WaitForSeconds(fallWait);
        rgbd.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyWait);
        
    }
    

   
}
