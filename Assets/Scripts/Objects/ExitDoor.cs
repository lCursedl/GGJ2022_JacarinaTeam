using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    private BoxCollider m_triggerZone;
    public List<GameObject> Sockets;
    private List<SocketPolarity> m_onSockets;
    private int m_requiredSockets = 0;
    private bool m_activate = false;
    [HideInInspector]
    public bool m_levelClear = false;
    private int m_requiredPlayers = 0;

    // Start is called before the first frame update
    void Start() {
        m_onSockets = new List<SocketPolarity>();
        foreach (GameObject item in Sockets) {
            m_onSockets.Add(item.GetComponent<SocketPolarity>());
        }
        m_requiredSockets = Sockets.Count;
        m_triggerZone = gameObject.AddComponent<BoxCollider>();
        m_triggerZone.isTrigger = true;
        m_triggerZone.center = new Vector3(0.75f, 0.0f, 0.0f);
        m_triggerZone.size = new Vector3(1f, 2f, 3f);
    }

    // Update is called once per frame
    void Update() {
        int amount = 0;
        foreach (SocketPolarity item in m_onSockets) {
            if (item.m_Active) {
                ++amount;
            }
        }
        m_activate = amount == m_requiredSockets ? true : false;
        if (m_requiredPlayers == 2) {
            m_levelClear = true;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (m_activate) {
            if (other.gameObject.name.Equals("Anodo") || 
                other.gameObject.name.Equals("Catodo")) {
                ++m_requiredPlayers;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        if (m_activate) {
            if (other.gameObject.name.Equals("Anodo") ||
                other.gameObject.name.Equals("Catodo")) {
                --m_requiredPlayers;
            }
        }
    }

}
