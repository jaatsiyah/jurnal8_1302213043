using System.Reflection;
using System.Security.Cryptography.X509Certificates;

class Program
{
    public static void Main(string[] args)
    {
        BankTransferConfig config = new BankTransferConfig();
        UIConfig uiConfig = new UIConfig();

        if(uiConfig.config.lang == "en")
        {
            Console.WriteLine("Please insert the amount of money to transfer");

        }else if(uiConfig.config.lang == "id")
        {
            Console.WriteLine("Masukkan jumlah uang yang akan di-transfer");
        }

        int amount = int.Parse(Console.ReadLine());

        int fee;
        if(amount <= uiConfig.config.transfer.threshold)
        {
            fee = uiConfig.config.transfer.low_fee;
        }else
        {
            fee = uiConfig.config.transfer.high_fee;
        }

        if (uiConfig.config.lang == "en")
        {
            Console.WriteLine("Transfer fee = " + fee + "Total amount = " + (amount + fee));
                

        }
        else if (uiConfig.config.lang == "id")
        {
            Console.WriteLine("Biaya transfer = " + fee + "Total biaya = " + (amount + fee));
        }

        if (uiConfig.config.lang == "en")
        {
            Console.WriteLine("Select transfer method : ");

        }
        else if (uiConfig.config.lang == "id")
        {
            Console.WriteLine("Pilih metode transfer : ");
        }

        for(int i = 0; i < uiConfig.config.method.Count; i++)
        {
            Console.WriteLine((i + 1) + "." + uiConfig.config.method[i]);
        }

        if (uiConfig.config.lang == "en")
        {
            Console.WriteLine("Please type " + uiConfig.config.confirmation.en + " to confirm the transaction :");

        }
        else if (uiConfig.config.lang == "id")
        {
            Console.WriteLine("Ketik " + uiConfig.config.confirmation.id + " untuk mengkonfirmasi transaksi :");
        }

        string confirm = Console.ReadLine();

        if (uiConfig.config.lang == "en")
        {
            if (confirm == uiConfig.config.confirmation.en)
            {
                Console.WriteLine("The transfer is completed");
            } else if (confirm != uiConfig.config.confirmation.en)
            {
                Console.WriteLine("Transfer is cancelled");
            }

        }
        else if (uiConfig.config.lang == "id")
        {
            if(confirm == uiConfig.config.confirmation.id)
            {
                Console.WriteLine("Proses transfer berhasil");
            } else if (confirm != uiConfig.config.confirmation.id)
            {
                Console.WriteLine("Transfer dibatalkan");
            }
        }

        
    }
}
