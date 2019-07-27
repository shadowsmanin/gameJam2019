using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    // public variables(can change in unity editor GUI)
    public Vector2 startingPoint = new Vector2(1.0f, 1.0f);
    public Vector2 endPoint = new Vector2(100.0f, 100.0f);
    public float speed = 10.0f;

    void Start() {

        transform.position = startingPoint;     // move object to predefined starting point in 2D space

    }

    void Update() {

        float step = speed * Time.deltaTime;

        // moves object from starting point to predefined endpoint proportional to speed variable
        transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), endPoint, step);

    }
}
