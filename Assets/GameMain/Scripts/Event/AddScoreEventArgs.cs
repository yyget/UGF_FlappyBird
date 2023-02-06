using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarForce
{


/// <summary>
/// �ӷ��¼�
/// </summary>
public class AddScoreEventArgs : GameEventArgs
{
    public static readonly int EventId = typeof(AddScoreEventArgs).GetHashCode();

    public override int Id
    {
        get
        {
            return EventId;
        }
    }

    /// <summary>
    /// �ӷ�����
    /// </summary>
    public int AddCount { get; private set; }

    /// <summary>
    /// ����¼�
    /// </summary>
    public AddScoreEventArgs Fill(int addCount)
    {
        AddCount = addCount;

        return this;
    }

    public override void Clear()
    {
        AddCount = 0;
    }
}
}