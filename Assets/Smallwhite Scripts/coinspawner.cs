using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinspawner : MonoBehaviour
{
    [SerializeField] GameObject coin;
    float dis = (float)0.5;
    public int totalcoins = 0;
    // Start is called before the first frame update
    public void summon(Vector3 v)
    {
        //transform.position = v;
        Transform a=Instantiate(coin.transform);
        a.parent = transform;
        a.localPosition = new Vector3(v.x,v.y-dis,v.z);
        a.localRotation = Quaternion.Euler(90,0,0);
        Transform b = Instantiate(coin.transform);
        b.parent = transform;
        b.localPosition = new Vector3(v.x+dis,v.y-dis,v.z+dis);

        Transform c = Instantiate(coin.transform);
        c.parent = transform;
        c.localPosition = new Vector3(v.x-dis, v.y - dis, v.z+dis);

        Transform d = Instantiate(coin.transform);
        d.parent = transform;
        d.localPosition = new Vector3(v.x+dis, v.y-dis,v.z- dis);

        Transform e = Instantiate(coin.transform);
        e.parent = transform;
        e.localPosition = new Vector3(v.x- dis, v.y-dis,v.z- dis);
        b.localRotation = Quaternion.Euler(90, 0, 0);
        c.localRotation = Quaternion.Euler(90, 0, 0);
        d.localRotation = Quaternion.Euler(90, 0, 0);
        e.localRotation = Quaternion.Euler(90, 0, 0);
    }
}
