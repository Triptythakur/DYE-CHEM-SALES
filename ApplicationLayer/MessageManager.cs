using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreLayer;
using DataBaseLayer;

namespace ApplicationLayer
{
     public  class MessageManager
    {
        public void Add(Messagess message)
        {
            DataLayer.Add(message);
        }
    }
}
