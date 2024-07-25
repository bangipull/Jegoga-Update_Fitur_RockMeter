using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    private bool isPaused = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();      
    }

    private void Start()
    {
        isPaused = false; // Ensure isPaused is reset

        rb.velocity = new Vector3(0, -speed, 0);
    }

    void Update()
    {

        // Logic untuk menggerakkan Note
    }

    public void Pause()
    {
        isPaused = true;
    }

    public void Resume()
    {
        isPaused = false;
    }
}
