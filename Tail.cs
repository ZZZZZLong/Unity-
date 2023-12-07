using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public Transform nerworkedOwner;
    public Transform followTransform;

    [SerializeField] private float delayTime = 0.1f;
    [SerializeField] private float distance = 0.3f;
    [SerializeField] private float moveStep = 10f;


    private Vector3 _targetPosition;

    private void Update()
    {
        
        _targetPosition = followTransform.position - followTransform.forward * distance;//这是尾巴需要到达的位置
        Debug.DrawLine(_targetPosition, _targetPosition+(transform.position - _targetPosition) * delayTime, color: Color.blue);
        _targetPosition += (transform.position - _targetPosition) * delayTime;//这行代码的目的是更新两者之间的距离以delaytime的速率进行插值 可以将delayTime看成比例
        //target2 在使得 distance = 0 delayTime =0.5 的时候 利用Debug.DrawLine可以看到 target2作为了target和tranform的中点 可以实现相距远的时候 移动快 近的时候移动慢的平滑移动
        _targetPosition.z = 0f;
        Debug.DrawLine(transform.position, _targetPosition,color:Color.red);
      

        transform.position = Vector3.Lerp(transform.position , _targetPosition , Time.deltaTime * moveStep);
    }

}
