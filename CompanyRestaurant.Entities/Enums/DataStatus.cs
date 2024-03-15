using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.Entities.Enums
{
    public enum DataStatus
    {
        //Bu enum verinin eklenme,güncellenme,silinme durumunu tutmaktadır.
        Inserted=1,  
        Updated=2,   
        Deleted=3,
        Unknow=4

    }
}
