using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    public List<GameObject> Sockets;
    private List<SocketPolarity> m_SocketState;
    private bool m_active = false;
    private Vector3 m_startPos;
    private Vector3 m_endPos;

    [SerializeField]
    private float Interpolation;
    [SerializeField]
    private float MaxDistance;
    private Vector3 m_pos;
    // Start is called before the first frame update
    void Start() {
        m_SocketState = new List<SocketPolarity>();
        foreach (GameObject item in Sockets) {
            m_SocketState.Add(item.GetComponent<SocketPolarity>());
        }
        m_pos = m_startPos  = m_endPos= transform.position;
    }

    // Update is called once per frame
    void Update() {
        int amount = 0;
        foreach (SocketPolarity item in m_SocketState) {
            if (item.m_Active) {
                ++amount;
            }
        }

        m_active = amount > 0 ? true : false;

        if (m_active) {
            m_endPos.x = m_startPos.x + MaxDistance;
        }
        else {
            m_endPos.x = m_startPos.x;
        }

        m_pos += (m_endPos - m_pos) / Interpolation;
        transform.position = m_pos;
    }
}
