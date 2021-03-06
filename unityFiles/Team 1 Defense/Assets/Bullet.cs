﻿using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;
    public float speed = 70f;
    public GameObject impactEffect;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        // hit detection
        if (direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        // bullet movement
        transform.Translate(direction.normalized * distanceThisFrame, Space.World);
    }
    
    void HitTarget()
    {
        GameObject effectInst = (GameObject) Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectInst, 2f);
        // later add way to damage enemy... for now just insta kill them
        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
