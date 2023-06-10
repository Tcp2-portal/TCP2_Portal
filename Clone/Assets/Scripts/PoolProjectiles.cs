using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Weapon))]
public class PoolProjectiles : MonoBehaviour
{
    public GameObject projectileTypes;
    public int poolSize;
    private List<GameObject> pool;
    public Transform target;

    void Awake()
    {
        this.pool = new List<GameObject>();
        CreatePool();
    }
    public GameObject GetElement(int index)
    {
        return pool[index];
    }

    private void CreatePool()
    {
        for (int i = 0; i < poolSize; i++)
        {
            CreateElement();
        }
    }

    private void CreateElement()
    {
        GameObject projectile = Instantiate(projectileTypes, null);
        projectile.GetComponent<Projectile>().gun = GetComponent<Weapon>();
        projectile.SetActive(false);  
        pool.Add(projectile);
    }
    //put 
    public void PutProjectile(int key)
    {
        pool[key].SetActive(false);
    }
    //get
    public GameObject GetProjectile(int index)
    {
        int count = 0;
        while (pool[index].activeInHierarchy)
        {
            if (count > pool.Count)
            {
                CreateElement();
            }
            index = (index + 1) % pool.Count;
            count++;
        }
        return pool[index];
    }
    public int GetId(GameObject projectile){
        for(int i = 0; i < pool.Count; i++){
            if(pool[i].Equals(projectile)){
                return i;
            }
        }
        return -1;
    }
}
