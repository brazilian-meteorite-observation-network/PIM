using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsClient._Data
{
    public class Object
    {
        private int id;
        private string variable;
        private float longitude;
        private float latitude;
        private float height;

        public int Id { get => id; set => id = value; }
        public string Variable { get => variable; set => variable = value; }
        public float Longitude { get => longitude; set => longitude = value; }
        public float Latitude { get => latitude; set => latitude = value; }
        public float Height { get => height; set => height = value; }
    }
}
