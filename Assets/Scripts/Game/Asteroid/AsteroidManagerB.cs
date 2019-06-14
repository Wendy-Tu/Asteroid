using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManagerB : MonoBehaviour
{
    #region SINGLETON
    public static AsteroidManagerB Instance;
    private void Awake()
    {
        Instance = this;
    }
    #endregion
    
    #region Variables
    //variables
    [Header("Asteroid Prefab References")]
    public GameObject[] AsteroidsPrefabs;
    [Header("Spawn Variables")]
    public float maxVelocity; //max velocity we will give our asteroid (weuse it to influence [Random]
    public float spawnRate;
    public float spawnPadding;
    [Header("Debug")]
    public Color debugColor = Color.cyan;
    #endregion

    #region START
    // Use this for initialization
    void Start()
    {
        //we call SpawnLoop ONCE in an InvokeRepeat
        InvokeRepeating("SpawnLoop", 0, spawnRate);
    }
    #endregion

    #region UPDATE
    // Update is called once per frame
    void Update()
    {

    }
    #endregion

    #region Spawn() Function
    //spawns an (a single) asteroid at the provided location with random force
    //Note: position is being randomised else where
    public static void Spawn(GameObject prefab, Vector3 position)
    {
        //randomize the rotation of the asteroid
        Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 30f));

        //spawn random asteroid at random positoin and default Quaternionf
        GameObject asteroid = Instantiate(prefab, position, randomRotation, Instance.transform);

        //get rigid body from asteroid 
        Rigidbody2D rigid = asteroid.GetComponent<Rigidbody2D>();

        //apply random force to rigid body
        Vector2 randomForce = Random.insideUnitCircle * Instance.maxVelocity;
        rigid.AddForce(randomForce, ForceMode2D.Impulse);
    }
    #endregion

    #region SpawnLoop() Function
    //Generates the random position
    //picks a random asteroid prefab from the AsteroidsPrefabs array
    //calls Spawn()
    void SpawnLoop()
    {
        //get camera bounds with padding
        Bounds camBounds = Camera.main.GetBounds(spawnPadding);

        //the ranomd position on the camera bounds
        Vector3 randomPos = camBounds.GetRandomPosOnBounds();

        //generate random index
        int rand = Random.Range(0, AsteroidsPrefabs.Length);

        //pick a random Asteroid
        GameObject asteroid = AsteroidsPrefabs[rand];

        //call spawn
        Spawn(asteroid, randomPos);
    }
    #endregion

    #region Gizmo
    private void OnDrawGizmos()
    {
        //get camera bounds with padding
        Bounds camBounds = Camera.main.GetBounds(spawnPadding);

        Gizmos.color = debugColor;
        Gizmos.DrawWireCube(camBounds.center, camBounds.size);
    }
    #endregion



}
