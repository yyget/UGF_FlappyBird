using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarForce
{
    /// <summary>
    /// С�������¼�
    /// </summary>
    public class BirdDeadEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(BirdDeadEventArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public override void Clear()
        {

        }
    }
}

 
