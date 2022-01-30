using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [HideInInspector]
    public bool m_Active;
    private BoxCollider m_triggerZone;
    // Start is called before the first frame update
    void Start() {
        m_triggerZone = gameObject.AddComponent<BoxCollider>();
        m_triggerZone.isTrigger = true;
        m_triggerZone.center = new Vector3(0.0f, 0.25f, 0.0f);
        m_triggerZone.size = new Vector3(1.0f, 0.5f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        m_Active = true;
        Debug.Log("Pressed");
    }

    private void OnTriggerExit(Collider other) {
        m_Active = false;
        Debug.Log("Release");
    }
}
