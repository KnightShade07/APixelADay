using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APixelADay.Models
{
    public class BlobStorageHelper
    {
        private async Task<FileStream> UploadBlob(PixelArt p, IFormFile Pixel)
        {
            string con = _config.GetSection("BlobStorageString").Value;

            BlobServiceClient blobService = new BlobServiceClient(con);

            //creates container to hold BLOBs.
            BlobContainerClient containerClient = blobService.GetBlobContainerClient("PixelArts");
            //makes sure container exists
            if (!containerClient.Exists())
            {
                await containerClient.CreateAsync();
                await containerClient.SetAccessPolicyAsync(PublicAccessType.Blob);
            }




            //Add BLOB to container.
            string newfileName = Guid.NewGuid().ToString() + Path.GetExtension(Pixel.FileName);
            BlobClient blobClient = containerClient.GetBlobClient(newfileName);
            FileStream fileStream = System.IO.File.OpenRead("");
            await blobClient.UploadAsync(p.PixelArtPhoto.OpenReadStream());
            return fileStream;
        }
    }
}
