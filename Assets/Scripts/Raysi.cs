using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Raysi : MonoBehaviour
{
        Camera cam;
        Vector3 pos = new Vector3(200, 200, 0);
        RaycastHit hit;
        

    // Update is called once per frame
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        Ray ray = cam.ScreenPointToRay(pos);
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
        
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object");

        RaycastHit[] hit;
        hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);

        for (int i = 0; i < hits.Lenght; i++)
        {
            RaycastHit hit = hit[i];
            Render rend = hit.transform.GetComponent<renderer>();

            if (rend)
            {
                rend.material.shader = Shader.Find("Transparent/Diffuse");
                Color tempColor = rend.material.color;
                tempColor.a = 0.3F;
                rend.material.color = tempColor;
            }
        }
    }

    void FisxedUpdate()
    {
        int layerMask = 1 << 8;

        layerMask = layerMask;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
            Debug.Log("Did Hit");
        }
        else 
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            Debug.Log("Did not Hit");
        }

        {

        
    }

    }
}
