using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingArea : MonoBehaviour
{
    private Vector3 originPosition; // ��ֹ� ��ġ ������

    [SerializeField] private List<Vector3> startPoint;  // ��ֹ��� �������� �����ϴ� ��ġ

    private ObjectPool objectPool;


    // Start is called before the first frame update
    void Start()
    {
        objectPool = GetComponent<ObjectPool>();

        originPosition = transform.position + new Vector3(0, GetComponent<BoxCollider>().bounds.size.y / 2, 0);

        StartCoroutine(Fall());
    }

    private IEnumerator Fall()
    {
        while (true)
        {
            for (int i = 0; i < startPoint.Count; i++)
            {
                GameObject obj = objectPool.GetObject();
                obj.transform.position = originPosition + startPoint[i];

                yield return new WaitForSeconds(0.5f);
            }
            yield return new WaitForSeconds(2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer==LayerMask.NameToLayer("Obstacle") && other.CompareTag("Fall"))
        {
            objectPool.ReturnObject(other.gameObject);
        }
    }
}
