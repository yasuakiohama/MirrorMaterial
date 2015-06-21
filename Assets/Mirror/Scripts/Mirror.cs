using UnityEngine;
using System.Collections;

public class Mirror : MonoBehaviour
{
	private float MAP_RADIUS  = 10.0f;
	public Transform target;

	void Update () {
		Vector2 offset;
		offset.x = OffsetRange (-target.position.x / MAP_RADIUS);
		offset.y = OffsetRange (-target.position.y / MAP_RADIUS);
		this.GetComponent<MeshRenderer> ().material.SetTextureOffset ("_MainTex", offset);
	}

	float OffsetRange (float value)
	{
		return Mathf.Max (-0.5f, Mathf.Min (value, 0.5f));
	}
}
