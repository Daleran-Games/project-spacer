using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

namespace ProjectSpacer
{
    public class StatCollection
    {

        private Dictionary<Type, IStat> _statDictionary;

        public StatCollection()
        {
            _statDictionary = new Dictionary<Type, IStat>();
        }

        public void AddStat<T>(IStat newStat) where T : IStat
        {
            _statDictionary[typeof(T)] = newStat;
        }
        
        public T GetStat<T>() where T : IStat
        {
            IStat retrievedStat;
            if (_statDictionary.TryGetValue(typeof(T), out retrievedStat))
            {
                return (T)retrievedStat;
            }
            else
                return default(T);
        }

        public bool ContainsStat<T>() where T: IStat
        {
            if (_statDictionary.ContainsKey(typeof(T)))
                return true;
            else
                return false;
        }

    }
}


