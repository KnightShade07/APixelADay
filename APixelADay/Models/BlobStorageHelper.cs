using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace APixelADay.Models
{
    public class BlobStorageHelper
    {
        private IConfiguration _config;
        public BlobStorageHelper(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> UploadBlob( IFormFile Pixel)
        {
            string con = _config.GetSection("BlobStorageString").Value;

            BlobServiceClient blobService = new BlobServiceClient(con);

            //creates container to hold BLOBs.
            //BlobContainerClient blobContainerClient = new BlobContainerClient("UseDevelopmentStorage=true", "sample-container")
            BlobContainerClient containerClient = new BlobContainerClient("UseDevelopmentStorage=true","pixel-arts");
            //makes sure container exists
            if (!containerClient.Exists())
            {
                await containerClient.CreateAsync();
                await containerClient.SetAccessPolicyAsync(PublicAccessType.Blob);
            }




            //Add BLOB to container.
            string newfileName = Guid.NewGuid().ToString() + Path.GetExtension(Pixel.FileName);
            BlobClient blobClient = containerClient.GetBlobClient(newfileName);
            await blobClient.UploadAsync(Pixel.OpenReadStream());
            return newfileName;
        }
    }
}
