using System;
using System.Diagnostics.SymbolStore;
using System.Text.Json;

public class BankTransferConfig
{
	public string lang { get; set; }
	public transfer transfer { get; set; }
	public List<string> method { get; set; }

	public confirmation confirmation { get; set; } 

    public BankTransferConfig() { }

    public BankTransferConfig(string lang, transfer transfer, List<string> method, confirmation confirmation)
    {
        this.lang = lang;
        this.transfer = transfer;
        this.method = method;
        this.confirmation = confirmation;
    }
}

public class transfer
{
	public int threshold { get; set;}
	public int low_fee { get; set; }
	public int high_fee { get; set;}

	public transfer() { }

	public transfer(int threshold, int low_fee, int high_fee)
    {
        this.threshold = threshold;
        this.low_fee = low_fee;
        this.high_fee = high_fee;
    }	
}

public class confirmation
{
	public string en { get; set; }

	public string id { get; set; }

	public confirmation() { }

	public confirmation(string en, string id)
    {
        this.en = en;
        this.id = id;
    }
}

class UIConfig
{
    public BankTransferConfig config;
    public const string fileLocation = "D:\\TELKOM\\SEMESTER 4\\KONSTRUKSI PERANGKAT LUNAK\\jurnal8_1302213043\\jurnal8_1302213043\\jurnal8_1302213043\\";
    public const string filePath = fileLocation + "bank_transfer_config.json";

    public UIConfig()
    {
        try
        {
            ReadConfigFile();
        }
        catch (Exception)
        {
            setDefault();
            writeNewConfigFile();
        }
    }

    private BankTransferConfig ReadConfigFile()
    {
        string configJSONData = File.ReadAllText(filePath);
        config = JsonSerializer.Deserialize<BankTransferConfig>(configJSONData);
        return config;
    }

    private void setDefault()
    {

        transfer transfer = new transfer(25000000,6500,15000);
        List<string> methods = new List<string> { "RTO (real-time)","SKN","RTGS","BI FAST"};
        confirmation confirmation = new confirmation("yes","no");

        config = new BankTransferConfig("en", transfer, methods, confirmation);
    }

    private void writeNewConfigFile()
    {
        JsonSerializerOptions options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(config, options);
        File.WriteAllText(filePath, jsonString);
    }
}

