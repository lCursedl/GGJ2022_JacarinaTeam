using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPolarity : MonoBehaviour
{
    // Start is called before the first frame update
    private bool m_polarity;
    private SphereCollider m_playerField;
    [SerializeField]
    private float FieldRadius;
    [SerializeField]
    private float FieldForce;
    private bool m_fieldActive = false;
    private PlayerMovement m_movementScript;
    void Start() {
        m_polarity = gameObject.tag.Equals("Positive");
        m_playerField = gameObject.AddComponent<SphereCollider>();
        m_movementScript = GetComponent<PlayerMovement>();
        m_playerField.radius = FieldRadius;
        m_playerField.isTrigger = true;
    }

    // Update is called once per frame
    void Update() {
        m_playerField.radius = FieldRadius;
        if(Input.GetButtonDown("Activate") && m_movementScript.Selected) {
            m_fieldActive = !m_fieldActive;
        }
        //if(m_fieldActive) {
        //    Debug.Log("ForceField active.");
        //}
    }

    private void OnTriggerEnter(Collider other) {
               
    }

    private void OnTriggerStay(Collider other)
    {
        if (m_fieldActive) {
            GameObject otherObject = other.gameObject;
            if(!otherObject.name.Equals("Catodo") && !otherObject.name.Equals("Anodo")) {
                if(otherObject.GetComponent<Rigidbody>() != null) {
                    if (other.gameObject.tag.Equals(gameObject.tag))
                    {
                        Vector3 force = otherObject.transform.position - gameObject.transform.position;
                        force.Normalize();
                        force *= FieldForce;
                        otherObject.GetComponent<Rigidbody>().velocity = force;
                    }
                    else
                    {
                        Vector3 force = gameObject.transform.position - otherObject.transform.position;
                        force.Normalize();
                        force *= FieldForce;
                        otherObject.GetComponent<Rigidbody>().velocity = force;
                    }
                }                
            }
            
        }
    }

}
