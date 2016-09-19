using System;
using System.Collections;

namespace ProjectSpacer
{
    public class Type4Set<T> 
    {

        T _corner;
        public T Corner { get { return _corner; } }

        T _edge;
        public T Edge { get { return _edge; } }

        T _inverse;
        public T Inverse { get { return _inverse; } }

        T _interior;
        public T Interior { get { return _interior; } }


        public Type4Set (T corner, T edge, T inverse, T interior)
        {
            _corner = corner;
            _edge = edge;
            _inverse = inverse;
            _interior = interior;
        }

    }
}
