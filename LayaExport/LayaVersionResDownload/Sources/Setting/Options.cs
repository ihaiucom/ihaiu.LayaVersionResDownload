using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using CommandLine;

public class Options
{
    // 运行完，是否自动关闭cmd
    [Option("autoEnd", Required = false, Default = true)]
    public bool autoEnd { get; set; }

    // 命令
    [Option("cmd", Required = false, Default = "mergejs")]
    public string cmd { get; set; }

    // 启动参数设置 配置路径
    [Option("optionSetting", Required = false, Default = "./LayaVersionResDownload_Setting.json")]
    public string optionSetting { get; set; }

    // 输出路径
    [Option("outDir", Required = false, Default = "../LayaGameOut")]
    public string outDir { get; set; }

    // version路径
    [Option("versionPath", Required = false, Default = "./layagame_version.json")]
    public string versionPath { get; set; }

    // 资源根路径
    [Option("httpRoot", Required = false, Default = "https://g48.gsf.netease.com/cdn_res_md03jf7h573wh3djkkmj/")]
    public string httpRoot { get; set; }




    public void Save(string path = null)
    {
        if (string.IsNullOrEmpty(path))
            path = "./LayaVersionResDownload_Setting.json";

        string json = JsonHelper.ToJsonType(this);
        File.WriteAllText(path, json);
    }

    public static Options Load(string path = null)
    {
        if (string.IsNullOrEmpty(path))
            path = "./LayaVersionResDownload_Setting.json";

        string json = File.ReadAllText(path);
        Options options = JsonHelper.FromJson<Options>(json);
        return options;
    }
}


public class OptionsMinConfig
{
    public string[] paths;
    public string savePath;


}