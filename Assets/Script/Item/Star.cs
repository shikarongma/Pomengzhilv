using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [Header("�����¼�")]
    public DestroyStarEventSO destroystarSO;

    [Header("�¼�����")]
    public ChangePositionEventSO changePositionSO;

    private AudioDefination audioDefination;//������Ч

    public int Order;

    private void Awake()
    {
        audioDefination = GetComponent<AudioDefination>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            destroystarSO.RaiseEvent(Order);
            Destroy(this.gameObject);
            audioDefination.PlayAudioClip();
        }
    }

    private void OnEnable()
    {
        changePositionSO.OnEventRaised += ChangePosition;
    }

    private void OnDisable()
    {
        changePositionSO.OnEventRaised -= ChangePosition;
    }

    private void ChangePosition(Vector3 position)
    {
        gameObject.SetActive(false);
        gameObject.transform.position = new Vector3(position.x,position.y,position.z);
        gameObject.SetActive(true);
    }
}
