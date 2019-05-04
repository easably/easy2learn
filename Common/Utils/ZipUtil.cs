using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.IO.Compression;

namespace f
{
    public static class ZipUtil
    {
        public static byte[] Compress(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream();
            DeflateStream compressedzipStream = new DeflateStream(ms, CompressionMode.Compress, true);
            compressedzipStream.Write(buffer, 0, buffer.Length);
            compressedzipStream.Close();
            byte[] ret = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(ret, 0, ret.Length);
            return ret;
        }

        private const int buffer_size = 100;

        public static byte[] DeCompress(byte[] buffer)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(buffer, 0, buffer.Length);
            ms.Position = 0;
            DeflateStream zipStream = new DeflateStream(ms, CompressionMode.Decompress);

            byte[] ret = new byte[ms.Length * 5];
            int totalCount = zipStream.Read(ret, 0, buffer.Length);
            int offset = buffer.Length;
            while (true)
            {
                int bytesRead = zipStream.Read(ret, offset, buffer_size);
                if (bytesRead == 0)
                {
                    break;
                }
                offset += bytesRead;
                totalCount += bytesRead;
            }
            byte[] ret2 = new byte[totalCount];
            Array.Copy(ret, ret2, totalCount);
            return ret2;
        }
    }
}