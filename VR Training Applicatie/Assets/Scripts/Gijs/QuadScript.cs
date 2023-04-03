using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadScript : MonoBehaviour
{
    [Header("Componenets")]
    [SerializeField] private Material mMaterial;
    [SerializeField] private MeshRenderer mMeshRenderer;

    [Header("Game Objects")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Button button;
    [SerializeField] private GameObject TargetField;
    GameObject go;

    [Header("Heatmap Stuff")]
    [SerializeField] private float[] mPoints;
    [SerializeField] private int mHitCount;
    [SerializeField] private float mDelay;
    [SerializeField] private float speed = 10f;

    [Header("Bool")]
    [SerializeField] private bool presentationHasStarted;

    // Start is called before the first frame updates
    void Start()
    {
        mDelay = 3;

        mMeshRenderer = GetComponent<MeshRenderer>();
        mMaterial = mMeshRenderer.material;

        mPoints = new float[335 * 3]; // 32 points
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(Screen.width / 2, Screen.height / 2);

        Ray ray = playerCamera.ScreenPointToRay(pos);
        Debug.DrawRay(ray.origin, ray.direction * 50, Color.yellow);

        SpawnGO();
    }

    #region Spawning Balls
    public void SpawnGO()
    {
        if (presentationHasStarted == true)
        {
            mDelay -= Time.deltaTime;
            if (mDelay <= 0)
            {
                go = Instantiate(Resources.Load<GameObject>("Projectile"), playerCamera.transform.position, playerCamera.transform.rotation);
                go.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * speed, ForceMode.Impulse);

                mDelay = 0.5f;
            }
        }
        else if (presentationHasStarted == false)
        {
            mDelay = 0.1f;
        }
    }
    #endregion

    #region Start/Stop Presentation
    public void StartPresentation()
    {
        Debug.Log("START PRESENTATION");
        presentationHasStarted = true;
        TurnOffMesh();
    }

    public void StopPresentation()
    {
        Debug.Log("STOP PRESENTATION");
        presentationHasStarted = false;
        TurnOnMesh();
    }
    #endregion

    #region Turning off everything / Turning on everything
    public void TurnOnMesh()
    {
        //TargetField.SetActive(true);
        mMeshRenderer.enabled = true;
    }

    public void TurnOffMesh()
    {
        //TargetField.SetActive(false);
        mMeshRenderer.enabled = false;
    }
    #endregion

    #region Shader/Hits
    private void OnCollisionEnter(Collision collision)
    {
        foreach(ContactPoint cp in collision.contacts)
        {
            Debug.Log("Contact with object " + cp.otherCollider.gameObject.name);

            Vector3 StartOfRay = cp.point - cp.normal;
            Vector3 RayDir = cp.normal;

            Ray ray = new Ray(StartOfRay, RayDir);
            RaycastHit hit;

            bool hitit = Physics.Raycast(ray, out hit, 10f, LayerMask.GetMask("HeatMapLayer"));

            if (hitit)
            {
                Debug.Log("Hit Object " + hit.collider.gameObject.name);
                Debug.Log("Hit Texture coordinates = " + hit.textureCoord.x + "," + hit.textureCoord.y);
                addHitPoint(hit.textureCoord.x * 4 - 2, hit.textureCoord.y * 4 - 2);
            }
            Destroy(cp.otherCollider.gameObject);
        }
    }

    public void addHitPoint(float xp, float yp)
    {
        mPoints[mHitCount * 3] = xp;
        mPoints[mHitCount * 3 + 1] = yp;
        mPoints[mHitCount * 3 + 2] = Random.Range(1f, 3f);

        mHitCount++;
        mHitCount %= 256;

        Debug.Log("hit count:" + mHitCount);

        mMaterial.SetFloatArray("_Hits", mPoints);
        mMaterial.SetInt("_HitCount", mHitCount);
    }
    #endregion
}
