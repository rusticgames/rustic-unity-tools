using UnityEngine;
using System.Collections;

namespace Rustic
{
    public class ScreenShake : MonoBehaviour
    {
	public float _xAmount;
	public float _yAmount;
	public float _duration;
	public float _frequency;

	private Camera camera;
	private Vector3 cameraInitPos;

	void Start()
	{
	    camera = Camera.main;
	    cameraInitPos = camera.transform.position;
	    StartCoroutine(Shake());
	}

	IEnumerator Shake()
	{
	    var time = 0f;

	    while(time < _duration) {
		time += Time.deltaTime + _frequency;

		var xPos = Random.Range(1, _xAmount);
		var yPos = Random.Range(1, _yAmount);
		var zPos = camera.transform.position.z;

		camera.transform.position = new Vector3(xPos, yPos, zPos);

		yield return new WaitForSeconds(_frequency);
	    }

	    camera.transform.position = cameraInitPos;

	    Destroy(gameObject);
	}
    }
}
