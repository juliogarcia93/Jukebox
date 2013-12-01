using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System.Collections.Specialized;
using System.Configuration;

// Add using statements to access AWS SDK for .NET services. 
// Both the Service and its Model namespace need to be added 
// in order to gain access to a service. For example, to access
// the EC2 service, add:
// using Amazon.EC2;
// using Amazon.EC2.Model;

namespace Amazon
{
    public class AmazonWebServices
    {

        public static void Main(string[] args)
        {
            IAmazonS3 s3Client = AWSClientFactory.CreateAmazonS3Client();

            Console.Read();
        }

        public void Upload(HttpPostedFileBase file)
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            IAmazonS3 s3Client = AWSClientFactory.CreateAmazonS3Client();
            string accessKeyID = appSettings["AWSAccessKey"];
            string secretAccessKey = appSettings["AWSSecretKey"];
            TransferUtility utility = new TransferUtility(accessKeyID, secretAccessKey);
            string MusicDirectory = HttpContext.Current.Server.MapPath("~/Music/") + file.FileName;
            file.SaveAs(MusicDirectory);
            utility.Upload(MusicDirectory, "jukeboxmusic");
        }
    }
}