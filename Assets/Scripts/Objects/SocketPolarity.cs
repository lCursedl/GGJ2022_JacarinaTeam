using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SocketPolarity : MonoBehaviour
{
    [HideInInspector]
    public bool m_Active;
    private BoxCollider m_triggerZone;
    // Start is called before the first frame update
    void Start() {
        m_triggerZone = gameObject.AddComponent<BoxCollider>();
        m_triggerZone.isTrigger = true;
        m_triggerZone.center = new Vector3(-0.25f, 0.0f, 0.0f);
        m_triggerZone.size = Vector3.one;
    }

    // Update is called once per frame
    void Update() {
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag(gameObject.tag)) {
            m_Active = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(m_Active && other.gameObject.CompareTag(gameObject.tag)) {
            m_Active = false;
        }
    }
}
