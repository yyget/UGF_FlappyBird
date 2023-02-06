using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarForce
{


/// <summary>
/// �ܵ�ʵ��ű�
/// </summary>
public class Pipe : Entity
{
    /// <summary>
    /// �ܵ�ʵ������
    /// </summary>
    private PipeData m_PipeData = null;

    /// <summary>
    /// �Ϲܵ�
    /// </summary>
    private Transform m_UpPipe = null;

    /// <summary>
    /// �¹ܵ�
    /// </summary>
    private Transform m_DownPipe = null;

    protected override void OnShow(object userData)
    {
        base.OnShow(userData);
        m_PipeData = (PipeData)userData;

        //���ó�ʼλ��
        CachedTransform.SetLocalPositionX(10f);

        if (m_UpPipe == null || m_DownPipe == null)
        {
            m_UpPipe = transform.Find("UpPipe");
            m_DownPipe = transform.Find("DownPipe");
        }

        //�������¹ܵ���ƫ��
        m_UpPipe.SetLocalPositionY(m_PipeData.OffsetUp);
        m_DownPipe.SetPositionY(m_PipeData.OffsetDown);

            //�����¼�
            GameEntry.Event.Subscribe(RestartEventArgs.EventId, OnRestart);

        }

    protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
    {
        base.OnUpdate(elapseSeconds, realElapseSeconds);

        CachedTransform.Translate(Vector3.left * m_PipeData.MoveSpeed * elapseSeconds, Space.World);
        if (CachedTransform.position.x <= m_PipeData.HideTarget)
        {
            //��������
            GameEntry.Entity.HideEntity(this);
        }


    }


    protected override void OnHide(bool isShutdown, object userData)
    {
        base.OnHide(isShutdown,userData);
        m_UpPipe.gameObject.SetActive(true);
        m_DownPipe.gameObject.SetActive(true);
            //ȡ�������¼�
            GameEntry.Event.Unsubscribe(RestartEventArgs.EventId, OnRestart);


        }
        private void OnRestart(object sender, GameEventArgs e)
        {
            GameEntry.Entity.HideEntity(this);
        }


    }
}
