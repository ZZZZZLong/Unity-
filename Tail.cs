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
        
        _targetPosition = followTransform.position - followTransform.forward * distance;//����β����Ҫ�����λ��
        Debug.DrawLine(_targetPosition, _targetPosition+(transform.position - _targetPosition) * delayTime, color: Color.blue);
        _targetPosition += (transform.position - _targetPosition) * delayTime;//���д����Ŀ���Ǹ�������֮��ľ�����delaytime�����ʽ��в�ֵ ���Խ�delayTime���ɱ���
        //target2 ��ʹ�� distance = 0 delayTime =0.5 ��ʱ�� ����Debug.DrawLine���Կ��� target2��Ϊ��target��tranform���е� ����ʵ�����Զ��ʱ�� �ƶ��� ����ʱ���ƶ�����ƽ���ƶ�
        _targetPosition.z = 0f;
        Debug.DrawLine(transform.position, _targetPosition,color:Color.red);
      

        transform.position = Vector3.Lerp(transform.position , _targetPosition , Time.deltaTime * moveStep);
    }

}
