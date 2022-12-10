using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject poolingObjectPrefab;    // ������
    private Queue<GameObject> poolingObjectQueue; // �̸� ������ ������Ʈ�� ������ ť

    private void Start()
    {
        Initialize(10); // 10���� ������Ʈ �̸� ����
    }

    // ������Ʈ�� �̸� ����
    private void Initialize(int initCount)
    {
        poolingObjectQueue = new Queue<GameObject>();
        for(int i = 0; i < initCount; i++)
        {
            poolingObjectQueue.Enqueue(CreateNewObject());  // initCount���� ������Ʈ�� �����Ͽ� ��ť
        }
    }

    // ������ �����Ͽ� ������ ������Ʈ ���� �� ��Ȱ��ȭ�Ͽ� ����
    private GameObject CreateNewObject()
    {
        var newObj = Instantiate(poolingObjectPrefab);  // ����
        newObj.gameObject.SetActive(false); // ��Ȱ��ȭ
        newObj.transform.SetParent(transform);  // gameObject�� �ڽ� ������Ʈ�� ��ġ
        return newObj;
    }

    // �ٸ� ��ũ��Ʈ���� ���� ������Ʈ ��û�ϸ� ����(��ť or ���� ����)
    public GameObject GetObject()
    {
        if (poolingObjectQueue.Count > 0)
        {
            var obj = poolingObjectQueue.Dequeue();
            obj.transform.SetParent(null);
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            var newObj = CreateNewObject();
            newObj.gameObject.SetActive(true);
            newObj.transform.SetParent(null);
            return newObj;
        }
    }

    // �ٸ� ��ũ��Ʈ���� ������Ʈ �ݳ�
    public void ReturnObject(GameObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        poolingObjectQueue.Enqueue(obj);
    }
}