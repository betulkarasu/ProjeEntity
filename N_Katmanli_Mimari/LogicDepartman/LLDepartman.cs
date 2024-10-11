using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Data_Accsess_Layer_Departman;
using EntityDepartman;

namespace LogicDepartman
{
    public class LLDepartman

    {
        public static List<EntityDEP> LLDepartman()

        { return DEPARTMAN.Departman(); 

        }


        
       
    }
}
