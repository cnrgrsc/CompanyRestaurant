using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyRestaurant.Common.Image
{
    public static class Image
    {
        public static string Images(string ımageName)
        {

            string fileName = "";

            var uniqueName = Guid.NewGuid().ToString();

            var fileArray = ımageName.Split('.');

            var extension = fileArray[fileArray.Length - 1];

            if (extension == "png" || extension == "jpg" || extension == "gif" || extension == "jpeg")
            {
                fileName = uniqueName + "." + extension;

                return fileName;

            }
            else
            {
                return "0";
            }
        }
    }
}
