﻿using System.Collections.Generic;
using System.IO;
using Maple2.File.IO.Crypto.Common;

namespace Maple2.File.IO.Crypto.Stream {
    public class PackStreamVer2 : IPackStream {
        public PackVersion Version => PackVersion.NS2F;

        public ulong CompressedHeaderSize { get; set; }
        public ulong EncodedHeaderSize { get; set; }
        public ulong HeaderSize { get; set; }

        public ulong CompressedDataSize { get; set; }
        public ulong EncodedDataSize { get; set; }
        public ulong DataSize { get; set; }

        public ulong FileListCount { get; set; }
        public List<PackFileEntry> FileList { get; }

        private PackStreamVer2() {
            this.FileList = new List<PackFileEntry>();
        }

        public static PackStreamVer2 ParseHeader(BinaryReader reader) {
            return new PackStreamVer2 {
                FileListCount = reader.ReadUInt32(),
                CompressedDataSize = reader.ReadUInt64(),
                EncodedDataSize = reader.ReadUInt64(),
                HeaderSize = reader.ReadUInt64(),
                CompressedHeaderSize = reader.ReadUInt64(),
                EncodedHeaderSize = reader.ReadUInt64(),
                DataSize = reader.ReadUInt64()
            };
        }

        public void Encode(BinaryWriter pWriter) {
            pWriter.Write(this.FileListCount);
            pWriter.Write(this.CompressedDataSize);
            pWriter.Write(this.EncodedDataSize);
            pWriter.Write(this.HeaderSize);
            pWriter.Write(this.CompressedHeaderSize);
            pWriter.Write(this.EncodedHeaderSize);
            pWriter.Write(this.DataSize);
        }

        public void InitFileList(BinaryReader reader) {
            for (ulong i = 0; i < FileListCount; i++) {
                IPackFileHeader fileHeader = new PackFileHeaderVer2(reader);
                FileList[fileHeader.FileIndex - 1].FileHeader = fileHeader;
            }
        }
    }
}
