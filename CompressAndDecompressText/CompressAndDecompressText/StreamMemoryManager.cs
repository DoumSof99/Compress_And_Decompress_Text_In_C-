using Microsoft.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompressAndDecompressText
{
    // Use RecyclableMemoryStreamManager for efficient memory management
    internal class StreamMemoryManager
    {
        private static RecyclableMemoryStreamManager? _instance;

        internal static RecyclableMemoryStreamManager Instance
        {
            get
            {
                _instance = new RecyclableMemoryStreamManager();
                return _instance;
            }
        }
    }

    public static class MemoryManager
    {
        public static MemoryStream GetStream()
        {
            // GetStream() creates a MemoryStream managed by the RecyclableMemoryStreamManager
            return StreamMemoryManager.Instance.GetStream();   
        }

        public static MemoryStream GetStream(byte[] data)
        {
            // GetStream() creates a MemoryStream managed by the RecyclableMemoryStreamManager
            return StreamMemoryManager.Instance.GetStream("data", data, 0, data.Length);
        }
    }
}
