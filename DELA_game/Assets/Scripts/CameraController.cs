using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;
    private Quaternion startRotation;
    private bool isZooming = false;
    private bool isZoomedIn = false;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!isZoomedIn)
        {
            transform.position = player.transform.position + offset;
            transform.rotation = startRotation;
        }
    }

    public void ZoomOnNPC(Transform npcTransform)
    {
        isZoomedIn = true;
        Vector3 targetPosition = npcTransform.position + npcTransform.forward * 3f + Vector3.up * 1.5f;  // Position camera slightly above and behind the NPC
        Quaternion targetRotation = Quaternion.LookRotation(npcTransform.position - targetPosition);
        StartCoroutine(SmoothZoom(targetPosition, targetRotation));
    }

    IEnumerator SmoothZoom(Vector3 targetPosition, Quaternion targetRotation)
    {
        if (isZooming) yield break;
        isZooming = true;

        float startTime = Time.time;
        while (Time.time - startTime < 1.5f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 5f * Time.deltaTime);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);
            yield return null;
        }

        isZooming = false;
    }

    public void ResetCamera()
    {
        StartCoroutine(SmoothZoom(player.transform.position + offset, startRotation));
        isZoomedIn = false;
    }
}
