using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    internal class shape1
    {
        internal string detailName;
        internal bool addInDrawList = true;
        internal bool rotatable = false;
        internal bool reflectable = false;
        public static Action<shape1> addShape;

        public virtual point north() { return null; }
        public virtual point south() { return null; }
        public virtual point east() { return null; }
        public virtual point west() { return null; }
        public virtual point neast() { return null; }
        public virtual point seast() { return null; }
        public virtual point nwest() { return null; }
        public virtual point swest() { return null; }

        public virtual void draw() { }
        public virtual void move(int x, int y) {}
        public virtual void resize(int d) { }
}
