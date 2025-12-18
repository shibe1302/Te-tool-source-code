using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

public class IniFile
{
    public string FilePath { get; }

    #region WinAPI
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    private static extern long WritePrivateProfileString(
        string section,
        string key,
        string value,
        string filePath);

    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    private static extern int GetPrivateProfileString(
        string section,
        string key,
        string defaultValue,
        StringBuilder retVal,
        int size,
        string filePath);
    #endregion

    public IniFile(string filePath)
    {
        FilePath = filePath;
    }

    public void EnsureFile()
    {
        var dir = Path.GetDirectoryName(FilePath);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        if (!File.Exists(FilePath))
        {
            using (File.Create(FilePath)) { }
        }
    }

    public void Write(string section, string key, string value)
    {
        EnsureFile();
        WritePrivateProfileString(section, key, value, FilePath);
    }

    public string Read(string section, string key, string defaultValue = "")
    {
        EnsureFile();

        var sb = new StringBuilder(1024);
        GetPrivateProfileString(
            section,
            key,
            defaultValue,
            sb,
            sb.Capacity,
            FilePath);

        return sb.ToString();
    }
}


public class Tab3Ini
{
    private const string SECTION = "DATA_TEMP";
    private readonly IniFile _ini;

    public Tab3Ini(string basePath)
    {
        var path = Path.Combine(basePath, "tab3.ini");
        _ini = new IniFile(path);

        InitializeIfNotExists();
    }

    private void InitializeIfNotExists()
    {
        if (!File.Exists(_ini.FilePath))
        {
            // Ghi từng key → WinAPI sẽ tự tạo section
            _ini.Write(SECTION, "item", "");
            _ini.Write(SECTION, "reoder", "");
            _ini.Write(SECTION, "select", "");
        }
    }

    public string Item
    {
        get => _ini.Read(SECTION, "item");
        set => _ini.Write(SECTION, "item", value);
    }

    public string Reoder
    {
        get => _ini.Read(SECTION, "reoder");
        set => _ini.Write(SECTION, "reoder", value);
    }

    public string Select
    {
        get => _ini.Read(SECTION, "select");
        set => _ini.Write(SECTION, "select", value);
    }
}

