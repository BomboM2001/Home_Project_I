using System;
using System.Collections.Generic;
using System.Text;

namespace homeproject
{
    class Player : Object
    {
        public int x;
        public int y;
        public Player(int x, int y, string clientObject) : base(clientObject)
        {
            this.x = x;
            this.y = y;
            this.newObject = clientObject;
        }
    }
}
