using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageSource.Concrete
{
    public class SerializerImp : ISerializer
    {
        public string ToJson<T>(T source)
        {
            //TODO: Implement a Serialize method from Object to JSON string.
            
            throw new NotImplementedException();
        }

        public T ToObject<T>(string source)
        {
            //TODO: Implement a Deserialize method from JSON string to Object.
            
            throw new NotImplementedException();
        }
    }
}
