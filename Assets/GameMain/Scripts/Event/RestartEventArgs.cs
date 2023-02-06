using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace StarForce
{
    public class RestartEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(RestartEventArgs).GetHashCode();

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
