using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float width, height, startingPositionX, startingPositionY;
    [SerializeField] private GameObject cam;
    [SerializeField]private float parallaxEffectX, parallaxEffectY;
    [SerializeField] private float offsetX, offsetY;

    // Start is called before the first frame update
    void Start()
    {
        startingPositionX = transform.position.x;
        startingPositionY = transform.position.y;
        width = GetComponent<SpriteRenderer>().bounds.size.x;
        height = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distX = (cam.transform.position.x * parallaxEffectX) + offsetX;
        float distY = (cam.transform.position.y * parallaxEffectY) + offsetY;
        transform.position = new Vector3(startingPositionX + distX, startingPositionY + distY, transform.position.z);
    }
}
