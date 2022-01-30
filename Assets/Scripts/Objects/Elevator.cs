using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public List<GameObject> Buttons;
    private List<Button> m_buttonStates;
    private bool m_active = false;
    private Vector3 m_startPos;
    private Vector3 m_endPos;
    [SerializeField]
    private float Interpolation;
    [SerializeField]
    private float MaxHeigth;
    private Vector3 m_pos;
    // Start is called before the first frame update
    void Start() {
        m_buttonStates = new List<Button>();
        foreach (GameObject item in Buttons) {
            m_buttonStates.Add(item.GetComponent<Button>());
        }
        m_startPos = transform.position;
        m_pos = m_startPos;
        m_endPos = m_startPos;
    }

    // Update is called once per frame
    void Update() {
        int amount = 0;
        foreach (Button item in m_buttonStates) {
            if (item.m_Active) {
                ++amount;
            }
        }

        m_active = amount > 0 ? true : false;

        if(m_active) {
            m_endPos.y = m_startPos.y + MaxHeigth;
        }
        else {
            m_endPos.y = m_startPos.y;
        }

        m_pos += (m_endPos - m_pos) / Interpolation;
        transform.position = m_pos;
    }
}
