using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAt : MonoBehaviour
{
    [SerializeField]
    private Camera _camera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 screenPosition = this.transform.position;
        Ray ray = _camera.ScreenPointToRay(screenPosition);

        Debug.DrawRay(ray.origin, ray.direction * Mathf.Infinity, Color.red);

        if(Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            if(raycastHit.collider != null)
            {
                raycastHit.collider.GetComponent<Renderer>().material.color = Color.green;
            }
            else if (raycastHit.collider == null)
            {
                raycastHit.collider.GetComponent<Renderer>().material.color = Color.clear;
            }
        }
    }
}
