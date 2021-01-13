using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if( Physics.Raycast(ray,out hit))
            {
                if(hit.collider != null)
                {
                    hit.collider.gameObject.GetComponent<EnemyStats>().health -= 1;
                }
            }
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    hit.collider.gameObject.GetComponent<EnemyStats>().health -= 1;
                }
            }
        }
    }
    
}
