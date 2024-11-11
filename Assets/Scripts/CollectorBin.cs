using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorBin : MonoBehaviour
{
    private void Start()
    {
        GetComponent<CollectorTriggerZone>().onEnterEvent.AddListener(InsideCollector);
    }

    public void InsideCollector(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

}
