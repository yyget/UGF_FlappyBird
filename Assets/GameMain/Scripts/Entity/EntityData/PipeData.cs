using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarForce { 
/// <summary>
/// �ܵ�ʵ������
/// </summary>
public class PipeData : EntityData
{
    /// <summary>
    /// �ƶ��ٶ�
    /// </summary>
    public float MoveSpeed { get; private set; }

    /// <summary>
    /// �Ϲܵ�ƫ��
    /// </summary>
    public float OffsetUp { get; private set; }

    /// <summary>
    /// �¹ܵ�ƫ��
    /// </summary>
    public float OffsetDown { get; private set; }

    /// <summary>
    /// �����Ŀ��ʱ��������
    /// </summary>
    public float HideTarget { get; private set; }

    public PipeData(int entityId, int typeId, float moveSpeed) : base(entityId, typeId)
    {
        MoveSpeed = moveSpeed;
        OffsetUp = Random.Range(4.1f, 7f);
        OffsetDown = Random.Range(-3f, -4.5f);
        HideTarget = -9.4f;
    }
}
}
