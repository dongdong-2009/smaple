using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace HOL1_Ex2
{
    public interface IProject
    {
        int Id { get; } 
        string Name { get; }
        Control AsyncTrigger
        {
            get;
        }
    }
}
