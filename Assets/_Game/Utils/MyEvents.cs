using System;
using UnityEngine;

namespace MyEvents
{
    public abstract class Event<T> where T : Event<T> 
    {
        public string description;

        private bool hasFired;
        
        public delegate void EventListener(T e);
        private static event EventListener listeners;
        
        public static void RegisterListener(EventListener listener) {
            listeners += listener;
        }

        public static void UnregisterListener(EventListener listener) {
            listeners -= listener;
        }

        public void FireEvent() {
            if (hasFired) {
                throw new Exception("This event has already fired, to prevent infinite loops you can't refire an event");
            }
        
            hasFired = true;
            
            if (listeners != null) {
                listeners(this as T);
            }
        }
    }

    public class DebugEvent : Event<DebugEvent>
    {
        public int verbosityLevel;
    }
    
    public class FloorPointEvent : Event<FloorPointEvent>
    {
        public GameObject obj;
        public Vector2 floorPoint;
    }
    
    //Examples
//    public class UnitHealthEvent : Event<UnitHealthEvent>
//    {
//        public GameObject gObj;
//        public bool isDead;
//    }
//    
//    public class UnitAttackEvent : Event<UnitAttackEvent>
//    {
//        public int gObjId;
//    }
}