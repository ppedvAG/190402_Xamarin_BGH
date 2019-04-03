using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation_Demo.MD
{

    public class MasterDetail_RootMenuItem
    {
        public MasterDetail_RootMenuItem(Type TargetType)
        {
            this.TargetType = TargetType;
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}