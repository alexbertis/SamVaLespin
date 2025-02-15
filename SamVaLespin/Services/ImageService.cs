using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SamVaLespin.Services
{
    public class ImageService
    {

        private byte[][] _images;

        public ImageService() 
        {
            Initialise();
        }

        private void Initialise()
        {
            var tempImages = new List<byte[]>();
            var filenames = Directory.GetFiles("img");
            foreach (var filename in filenames)
            {
                tempImages.Add(File.ReadAllBytes(filename));
            }
            _images = tempImages.ToArray();
        }

        public byte[] GetRandomPicture() => Random.Shared.GetItems(_images, 1).FirstOrDefault();
    }
}
