using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    List<Transform> paths;
    float moveSpeed = 0f;
    int index = 0;

    private void Update()
    {
        IEFollowPath();
    }

    //CUSTOM METHODS
    public void setPaths(List<Transform> newPaths)
    {
        paths = newPaths;
    }

    public void setMoveSpeed(float newMoveSpeed)
    {
        moveSpeed = newMoveSpeed;
    }

    void IEFollowPath()
    {
        if (index < paths.Count)
        {
            Vector3 targetPosition = paths[index].position;
            float delta = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition)
            {
                index++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
