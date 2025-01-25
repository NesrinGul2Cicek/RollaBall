using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject oyuncu;
    Vector3 ofset;
    // Start is called before the first frame update
    void Start()
    {
        // ofset = kameranýn konumu - oyuncunun konumu
        // this gerekli deðil
        ofset = this.transform.position - oyuncu.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Update içine de yazýlabilir ama burasý daha iyi :))
        // yeni kamera konumu = ofset + oyuncunun konumu
        transform.position = ofset + oyuncu.transform.position;
    }
}
