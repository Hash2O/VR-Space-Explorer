using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public List<GameObject> breakableParts;

    public float timeToBreak;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        foreach (var part in breakableParts)
        {
            part.SetActive(false);
        }
    }

    public void Break()
    {
        timer += Time.deltaTime;

        if (timer > timeToBreak)
        {
            foreach (var part in breakableParts)
            {
                //Parts initialization
                part.SetActive(true);
                //Separation from parent
                part.transform.parent = null;
            }
            //Parent GO deactivated
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
