using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    private CharacterController m_controller;
    [SerializeField]
    private float Speed = 1.0f;
    [SerializeField]
    private float JumpHeight = 1.0f;
    private float m_gravity = -9.81f;
    private float m_oririginalStep;
    private float m_ySpeed;
    public bool Selected;
    // Start is called before the first frame update
    void Start() {
        m_controller = GetComponent<CharacterController>();
        m_oririginalStep = m_controller.stepOffset;
    }

    // Update is called once per frame
    void Update() {
        Vector3 movement = new Vector3(0, 0, 0);
        float magnitude = 0.0f;
        if(Selected) {
            movement.x = Input.GetAxis("Horizontal");
            movement.z = Input.GetAxis("Vertical");
            magnitude = Mathf.Clamp01(movement.magnitude) * Speed;
            movement.Normalize();
        }
        

        m_ySpeed += m_gravity * Time.deltaTime;

        if(m_controller.isGrounded) {
            m_controller.stepOffset = m_oririginalStep;
            m_ySpeed = -0.5f;
            if (Input.GetButtonDown("Jump") && Selected) {
                m_ySpeed = JumpHeight;
            }
        }
        else {
            m_controller.stepOffset = 0.0f;
        }

        Vector3 velocity = movement * magnitude;
        velocity.y = m_ySpeed;

        m_controller.Move(velocity * Time.deltaTime);
    }
}
