using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public int amountToStart;//Variable to determine how many objects can be used at the start of the game.
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
    //This will be used for pickup. When an object is picked up, a new instantiated object is added.
    public void AddNewObject(GameObject distraction)//Adds the object to the list depending on if it is in the stored items list.
    {
        pooledObjects.Add(distraction);

        for (int i = 0; i < itemsToStore.Count; i++)//Loops through the list.
        {
            if (itemsToStore[i] == distraction)//Check if the distraction is in the list.
            {
                itemsToStore.RemoveAt(i);
                recharge = true;
            }
        }
    }
    public void RemoveObjects(GameObject distraction)//Removes the object from a list with the parameter of a gameobjects
    {
        itemsToStore.Add(distraction);
        for (int i = 0; i < pooledObjects.Count; i++)//Loops through the list of pooled items to remove.
        {
            if (pooledObjects[i] == distraction)
                pooledObjects.RemoveAt(i);
        }
    }
    public void SaveObjects()//This is to save the pooled amounts of objects inicially if the starting amount is different to the pooled amount.
    {
        for (int i = pooledObjects.Count; i > amountToStart; i--)//Compares how many are in the list and loops through it in contrast to the amount to start with.
        {
            itemsToStore.Add(pooledObjects[i - 1]);//Stores the extra distractions in a stored list
            pooledObjects.RemoveAt(i - 1);//Removed it from the original list.
        }
    }
    public GameObject GetOneStoredObject()//Finds one instance of the object in the heirachy that is stored.
    {
        GameObject obj;
        if (itemsToStore != null)//if the list is empty, return null
        {
            for (int i = 0; i < itemsToStore.Count; i++)//loop through to find the first stored object.
            {
                obj = itemsToStore[i];
                return obj;
            }
        }
        return null;
    }
}
