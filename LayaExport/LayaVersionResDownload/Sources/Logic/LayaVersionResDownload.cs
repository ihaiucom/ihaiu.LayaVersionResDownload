using Ihaius;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

class LayaVersionResDownload
{
    public string httpRoot;
    public string versionPath;
    public string outDir;
    List<DownloadFile> downloadFileList = new List<DownloadFile>();
    int count = 0;
    int completeNum = 0;

    public void Start(string httpRoot, string versionPath, string outDir)
    {

        string json = File.ReadAllText(versionPath);
        JObject jo = (JObject) JsonConvert.DeserializeObject(json);
        IEnumerable<JProperty> properties = jo.Properties();
        count = jo.Count;
        foreach (JProperty item in properties)
        {
            string url = httpRoot +"/"+item.Value.ToString();
            string localPath = outDir +"/" + item.Name.ToString();

            if (Path.GetExtension(localPath) != ".js")
            {
                completeNum++;
                continue;
            }

            DownloadUtil.CheckDir(localPath);
            new HttpDldFile().Download(url, localPath);


            Console.WriteLine(url);

            //DownloadFile downloadFile = new DownloadFile(url, localPath);
            //downloadFile.completeCallback = OnFileComplete;
            //downloadFileList.Add(downloadFile);
            //downloadFile.Load();

            //break;
        }

        Console.WriteLine("完成");
        Console.Read();

        //while (true)
        //{
        //    if (completeNum >= count)
        //        break;
        //    Thread.Sleep(1000);
        //}

    }


    public void OnFileComplete(DownloadFile file)
    {
        completeNum++;
        Console.WriteLine(String.Format("{0}/{1}  {2}"), completeNum , count, file.url);
    }
}