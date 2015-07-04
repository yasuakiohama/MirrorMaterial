using UnityEngine;
using System.Collections;

public class Mirror : MonoBehaviour
{
    private float MAP_RADIUS  = 10.0f;
    public Transform target;

    void Start()
    {
        InvokeRepeating ("Tern", 1, 1);
    }

    void Tern()
    {
        target.transform.localScale = new Vector3 (target.transform.localScale.x * -1, target.transform.localScale.y, target.transform.localScale.z);
    }

    void Update ()
    {
        Vector2 offset;
        offset.x = OffsetRange (-target.position.x / MAP_RADIUS);
        offset.y = OffsetRange (-target.position.y / MAP_RADIUS);
        if (target.transform.localScale.x < 0) {
            offset.x = -offset.x;
            this.GetComponent<MeshRenderer> ().material.SetTextureOffset ("_MainTex", offset);
            this.GetComponent<MeshRenderer> ().material.SetTextureScale ("_MainTex", new Vector2 (-1, 1));
        } else {
            this.GetComponent<MeshRenderer> ().material.SetTextureOffset ("_MainTex", offset);
            this.GetComponent<MeshRenderer> ().material.SetTextureScale ("_MainTex", new Vector2 (1, 1));
        }
    }

    float OffsetRange (float value)
    {
        return Mathf.Max (-0.5f, Mathf.Min (value, 0.5f));
    }
}
