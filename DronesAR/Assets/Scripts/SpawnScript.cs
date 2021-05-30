using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class SpawnScript : MonoBehaviour
{

    public GameObject mCubeObj;

    // stevilo vseh kock
    public int mTotalCubes = 10;

    // cas za spawnat kocke
    public float mTimeToSpawn = 1f;

    // obdrzimo kocke na sceni
    private GameObject[] mCubes;

    //pozicija
    private bool mPositionSet;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLoop());
        mCubes = new GameObject[mTotalCubes]; // inicializiramo tabelo kock
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    // Spawn za kocko
    private GameObject SpawnElement()
    {
        // spawn the element on a random position, inside a imaginary sphere
        GameObject cube = Instantiate(mCubeObj, (Random.insideUnitSphere * 4) + transform.position, transform.rotation) as GameObject;
        // define a random scale for the cube
        float scale = Random.Range(0.5f, 2f);
        // change the cube scale
        cube.transform.localScale = new Vector3(scale, scale, scale);
        return cube;
    }

    // zanka za spawnanje kock
    private IEnumerator SpawnLoop()
    {
        // pozicija za spawn
        StartCoroutine(ChangePosition());

        yield return new WaitForSeconds(0.2f); // pocakaj preden spawnas novega

        int i = 0;
        while (i <= (mTotalCubes - 1))
        {
            mCubes[i] = SpawnElement();  //ustvari elemnt
            i++;
            yield return new WaitForSeconds(Random.Range(mTimeToSpawn, mTimeToSpawn * 3));
        }
    }

    private IEnumerator ChangePosition()
    {
        yield return new WaitForSeconds(0.2f);  // pocakaj preden spawnas novega
        // definiramo spawn posicijo samo enkrat
        if (!mPositionSet)
        {
            // spremeni pozicijo, ce je vuforia aktivna
            if (VuforiaBehaviour.Instance.enabled)
                SetPosition();
        }
    }


    private bool SetPosition()
    {
        // pridobi pozicijo kamere
        Transform cam = Camera.main.transform;

        // pozicija se nastavi 10 enot naprej od kamere
        transform.position = cam.forward * 10;
        return true;
    }

}
