using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextClamp : MonoBehaviour
{
    public GameObject textPanel;

    void Update()
    {
       Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
       textPanel.transform.position = namePos;
    }
}
