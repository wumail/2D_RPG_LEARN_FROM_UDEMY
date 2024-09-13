using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]private float parallaxEffect;
    private float length;
    private GameObject mainCamera;
    private float x;
    // Start is called before the first frame update
    void Start()
    {
        mainCamera = GameObject.Find("Main Camera");
        x = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float moved = mainCamera.transform.position.x * (1 - parallaxEffect);
        float distance = mainCamera.transform.position.x * parallaxEffect;
        transform.position = new Vector3(x + distance, transform.position.y);
        if(x + length < moved) {
            x += length;
        } else if(x - length > moved) {
            x -= length;
        }
    }
}
