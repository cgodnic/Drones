using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviourScript : MonoBehaviour {
    //Min-Max velikost kocke
    public float mScaleMax  = 5f;
    public float mScaleMin  = 2f;
 
    // Max hitrost
    public float mOrbitMaxSpeed = 30f;
 
    // Hitrost
    private float mOrbitSpeed;
 
    // Rotacija objekta
    private Transform mOrbitAnchor;
 
    //Smer premikanja
    private Vector3 mOrbitDirection;
 
    // Scale
    private Vector3 mCubeMaxScale;
     
    // Spreminjanje hitrosti
    public float mGrowingSpeed  = 10f;
    private bool mIsCubeScaled  = false;

     
    void Start () {
        CubeSettings();
    }
 
    private void CubeSettings(){
        // kamera
        mOrbitAnchor = Camera.main.transform;
 
        // smer orbite
        float x = Random.Range(-1f,1f);
        float y = Random.Range(-1f,1f);
        float z = Random.Range(-1f,1f);
        mOrbitDirection = new Vector3( x, y , z );
 
        // hitrost
        mOrbitSpeed = Random.Range( 5f, mOrbitMaxSpeed );
 
        // velikost
        float scale = Random.Range(mScaleMin, mScaleMax);
        mCubeMaxScale = new Vector3( scale, scale, scale );
 
        // nastavi na 0 da se pol poveca
        transform.localScale = Vector3.zero;
    }



    private void RotateCube(){
        // vrti se okol kamere
        transform.RotateAround(
            mOrbitAnchor.position, mOrbitDirection, mOrbitSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update () {
        // naredi orbito in vrti
        RotateCube();
    
        if ( !mIsCubeScaled )
            ScaleObj();
    }
 
// Povečaj objekt iz 0 na 1
    private void ScaleObj(){
        if ( transform.localScale != mCubeMaxScale )
            transform.localScale = Vector3.Lerp( transform.localScale, mCubeMaxScale, Time.deltaTime * mGrowingSpeed );
        else
            mIsCubeScaled = true;
    }

        // Življenje kocke
    public int mCubeHealth  = 100;
     
    //Ali je živa
    private bool mIsAlive = true;
     
    // Cube got Hit
    // false če smo jo uničili
    public bool Hit( int hitDamage ){
        mCubeHealth -= hitDamage;
        if ( mCubeHealth >= 0 && mIsAlive ) {
            StartCoroutine( DestroyCube());
            return true;
        }
        return false;
    }
 
    // Uniči kocko
    private IEnumerator DestroyCube(){
        mIsAlive = false;
        // KOcka izgine
        GetComponent<Renderer>().enabled = false;
        //explosion.Play();
        FindObjectOfType<AudioMan>().Play("Explosion");
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
