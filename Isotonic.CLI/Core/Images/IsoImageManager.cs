using DiscUtils.Iso9660;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isotonic.CLI.Core.Images
{
    public class IsoImageManager
    {
        public string FilePath { get; }

        public string VolumeLabel { get => cdReader.VolumeLabel; }

        public string VolumeId { get => cdReader.VolumeId.ToString(); }

        public int DirectoryCount { get; private set; }

        public int FileCount { get; private set; }

        public int TotalObjectsCount { get => FileCount + DirectoryCount; }

        CDReader cdReader;

        public IsoImageManager(string filePath)
        {
            FilePath = filePath;

            cdReader = new CDReader(File.Open(FilePath, new FileStreamOptions()
            {
                Access = FileAccess.ReadWrite,
                BufferSize = 8192 * 8192,
                Mode = FileMode.Open,
                Options = FileOptions.SequentialScan
            }), true);

            InitializeManager();
        }

        private void InitializeManager()
        {
            DirectoryCount = cdReader.GetDirectories("/", "*", SearchOption.AllDirectories).Count();

            FileCount = cdReader.GetFiles("/", "*", SearchOption.AllDirectories).Count();
        }

        
    }
}
