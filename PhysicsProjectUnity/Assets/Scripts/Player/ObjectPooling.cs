using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Name of Creater: Benjamin McDonald
/// Date of Creation: 1/3/2021
/// Last Modified: 9/4/2021
/// </summary>
public class ObjectPooling : MonoBehaviour
{
    [System.Serializable]
    public class ObjectPoolItem
    {
        public int amountToPool;
        public GameObject objectToPool;
    }
    public static ObjectPooling SharedInstance;//A instance of the calss.
    private List<GameObject> pooledObjects;//A list of pooled items
    public List<ObjectPoolItem> itemsToPool;//The types of items to pool
    [HideInInspector] public List<GameObject> itemsToStore;//In this, you can have extra ammo to pickup.
    [HideInInspector] public bool recharge = false;//recharges to the 
    private int objectsInHand;//determines how many objects are remaining.
    private void Awake()
    {
        SharedInstance = this;//Creates a shared instance of the class.

        pooledObjects = new List<GameObject>();//Creates a new instance of the pooled objects
        foreach (ObjectPoolItem item in itemsToPool)//Depending on how many different items there is to pool
        {
            for (int i = 0; i < item.amountToPool; i++)//Loops through every item in the items to pool
            {
                GameObject obj = Instantiate(item.objectToPool);//Creates a new instance of the item.
                obj.SetActive(false);//Sets it active on instance
                pooledObjects.Add(obj);//Adds it to the pooled list.
            }
        }
    }

    //Finding the first object that is not active in the hierarchy.
    public GameObject GetPooledObject(string tag)//Gets the first pooled object in the heirachy that is not active.
    {
        for (int i = 0; i < pooledObjects.Count; i++)//Loops through ever object that is in the list
        {
            if (!pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)//If the object in the list is inactive and is the same tag.
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
    //Checks if any are active in the hierarchy. Finds the first one.
    public GameObject CheckPooledObject(string tag)//Checks if the pooled object is active in the heirachy
    {
        for (int i = 0; i < pooledObjects.Count; i++)//Loops through the pooled objects
        {
            if (pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag)//If it is active and it is equal to the tag.
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
    //Checks how many objects are available.
    public int CheckValueInHand(string tag)//Checks how many objects are available.
    {
        objectsInHand = 0;//Defaults the count at 0.
        for (int i = 0; i < pooledObjects.Count; i++)//Goes through the loop to check how many are available.
        {
            if (pooledObjects[i].tag == tag)//If it has the tag
                objectsInHand += 1;
            if (pooledObjects[i].activeInHierarchy && pooledObjects[i].tag == tag && recharge == false)//If it has the tag, is active in heirachy and the recharge of collecting is false.
                objectsInHand -= 1;
        }
        return objectsInHand;
    }

    public List<GameObject> AllObjectsOfType(string tag)
    {
        List<GameObject> objArray = new List<GameObject>();
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (pooledObjects[i].tag == tag)
            {
                objArray.Add(pooledObjects[i].gameObject);
            }
            
        }
        return objArray;
    }
}
