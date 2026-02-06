using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Key> Keys = new();
    public float RayLength = 5;

    private Camera _camera;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool UseKey(int keyId)
    {
        for (int i = 0; i < Keys.Count; i++)
        {
            if (Keys[i].Id == keyId)
            {
                Destroy(Keys[i].gameObject);
                Keys.RemoveAt(i);
                return true;
            }
        }

        return false;
    }

    private void OnInteract()
    {
        RaycastHit hit;

        if(Physics.Raycast(_camera.transform.position, _camera.transform.forward, out hit, RayLength))
        {
            if(hit.collider.TryGetComponent(out Key key))
            {
                Keys.Add(key);
                hit.collider.gameObject.SetActive(false);
            }
        }
    }

    private void OnPrevious()
    {
        if (Keys.Count > 0)
        {
            Keys[0].transform.position = transform.position;
            Keys[0].gameObject.SetActive(true);
            Keys.RemoveAt(0);
        }
    }
}
