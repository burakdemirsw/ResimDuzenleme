using System.IO;
using System.Text;

namespace ResimDuzenleme.Operations
{
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => Encoding.UTF8;
    }
}
