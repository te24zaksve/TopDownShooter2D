using UnityEngine;

public class EnemySpawnScript : MonoBehaviour
{
    //components
    public Rigidbody2D prefabRb;
    public Transform enemySpawnPoint;
    public bool spawnEnemy = true;

    //variables
    private float time = 0;
    private float wait = 5;
    private int spawnAmount = 1;


    // Update is called once per frame
    void Update()
    {
        //sets up a timer
        time += Time.deltaTime;

        //Check if and how many enemies should spawn
        if (spawnEnemy)
        {
            spawnEnemy = false;
            //Debug.Log("spawnAmount "+spawnAmount);
            for (int i = 0; i < spawnAmount; i++)
            {
                //Debug.Log("loop "+i);
                Invoke("SpawnEnemy", i);
                Invoke("CanSpawnEnemy", (wait-(time/5)));
            }
        }
        //Debug.Log("wait " + (wait - (time / 5)) + " seconds");
        if ((wait - (time / 5)) <= 0.5)
        {
            spawnAmount += 1;
            time = 0;
        }

    }
    void CanSpawnEnemy()
    {
        spawnEnemy = true;
    }
    void SpawnEnemy()
    {
        //Spawn the enemy
        Rigidbody2D clone;
        clone = Instantiate(prefabRb, enemySpawnPoint.position, transform.rotation);
        clone.linearVelocity = transform.TransformDirection(Vector2.zero);
    }
}
