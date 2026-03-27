using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public Rigidbody box;
    public Coroutine goodbyeRoutine;
    void Start()
    {
        StartCoroutine(SpawnRoutine());
        //InvokeRepeating(nameof(RandomSpawn), 0, 5);
        //StartCoroutine(Hello());
        //StartCoroutine(Goodbye());
        //StartCoroutine(MoveBox());
        //goodbyeRoutine = StartCoroutine(Goodbye());

    }

    IEnumerator SpawnRoutine()
    {
        yield return new WaitForSeconds(5);
        while (true)
        {
            RandomSpawn();
            yield return new WaitForSeconds(3);
        }
        
    }
    void RandomSpawn()
    {
        var index = Random.Range(0, spawnPoints.Length);
        var spawnPoint = spawnPoints[index];
        Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
    }

    private void Update()
    {
        /*if (Time.time > 5)
            if (goodbyeRoutine != null)
            {
                StartCoroutine(goodbyeRoutine);
            }*/
    }

    /*IEnumerator MoveBox()
    {
        while (true)
        {
        box.linearVelocity = 10 * Vector3.up;
        yield return new WaitForSeconds(3);
        box.linearVelocity = 10 * Vector3.right;
        yield return new WaitForSeconds(3);
        box.linearVelocity = 10 * Vector3.down;
        yield return new WaitForSeconds(3);
        box.linearVelocity = 10 * Vector3.left;
        }
    }
    IEnumerator Goodbye()
    {
        while (true)
        {
            Debug.Log("Bye" + Time.frameCount + " " + Time.time);
            //yield return new WaitForSeconds(1);
            yield return null();
            //if (Time.time > 5)
           // {
          //      yield break;
          //  }
            yield return Hello();
            
        }
        
    }
    IEnumerator Hello()
    {
        Debug.Log("Hello" + Time.frameCount);
        Debug.Log("Hello" + Time.frameCount);
        Debug.Log("Hello" + Time.frameCount);
        yield return null;
        Debug.Log("Hello" + Time.frameCount);
        yield return null;
        Debug.Log("Hello" + Time.frameCount);
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        yield return null;
        Debug.Log("Hello" + Time.frameCount);
    }*/
}
