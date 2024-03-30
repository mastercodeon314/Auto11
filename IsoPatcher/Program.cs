using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        string filePath = args.Length > 0 ? args[0] : null;
        int toggle = args.Length > 1 ? int.Parse(args[1]) : 2; // Default: Do nothing

        filePath = @"C:\WindowsISOs\26090.1-24H2-NoWaterMark\26090.1.240322-1257.GE_RELEASE_CLIENTPRO_OEMRET_X64FRE_EN-US.Unpatched.ISO";
        toggle = 1;
        bool isPatched = IsTPMPatched(filePath);
        Console.WriteLine($"TPM requirements patched: {isPatched}");
        Console.WriteLine();

        if (string.IsNullOrEmpty(filePath))
        {
            Console.WriteLine("No input ISO, ESD, or WIM file provided.");
            return;
        }

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File does not exist.");
            return;
        }

        if (!FilePatchTPM(filePath, toggle))
        {
            Console.WriteLine("Failed to patch TPM requirements.");
        }
        else
        {
            Console.WriteLine("TPM requirements patched successfully.");
        }

        isPatched = IsTPMPatched(filePath);
        Console.WriteLine($"TPM requirements patched: {isPatched}");

        Console.ReadLine();
    }

    static bool FilePatchTPM(string isoFilePath, int toggle)
    {
        const int blockSize = 1048576;
        const int bufferSize = 2097152;

        string typeC = "<INSTALLATIONTYPE>Client";
        string typeS = "<INSTALLATIONTYPE>Server";

        try
        {
            using (FileStream fileStream = new FileStream(isoFilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                byte[] buffer = new byte[bufferSize];
                int bytesRead = fileStream.Read(buffer, 0, bufferSize);
                if (bytesRead != bufferSize)
                {
                    // File is smaller than buffer, adjust buffer size if needed
                }

                string content = Encoding.GetEncoding(28591).GetString(buffer);
                bool isPatched = content.Contains(typeC) || content.Contains(typeS);

                if ((toggle == 0 && isPatched) || (toggle == 1 && !isPatched))
                {
                    ulong blockCount = (ulong)(new FileInfo(isoFilePath).Length / bufferSize) - 1;
                    ulong begin = 0;
                    ulong final = 0;

                    for (ulong i = 1; i <= blockCount; i++)
                    {
                        long position = fileStream.Position;
                        if (position >= blockSize)
                        {
                            position = fileStream.Seek(-blockSize, SeekOrigin.Current);
                        }
                        else
                        {
                            fileStream.Seek(0, SeekOrigin.Begin);
                        }

                        bytesRead = fileStream.Read(buffer, 0, bufferSize);
                        if (bytesRead != bufferSize)
                        {
                            Console.WriteLine($"Invalid block {bytesRead}");
                            break;
                        }

                        content = Encoding.GetEncoding(28591).GetString(buffer);
                        int lastIndex = content.LastIndexOf("</INSTALLATIONTYPE>", StringComparison.Ordinal);
                        if (lastIndex >= 0)
                        {
                            fileStream.Seek((lastIndex - blockSize), SeekOrigin.Current);
                            for (int j = 1; j <= blockSize; j++)
                            {
                                fileStream.Seek(-2, SeekOrigin.Current);
                                if (fileStream.ReadByte() == 0xfe)
                                {
                                    begin = (ulong)fileStream.Position;
                                    break;
                                }
                            }
                            ulong limit = (ulong)fileStream.Length - begin;
                            ulong x = limit < blockSize ? limit : (ulong)blockSize;
                            buffer = new byte[x];
                            int bytesReadInner = fileStream.Read(buffer, 0, (int)x);
                            content = Encoding.GetEncoding(28591).GetString(buffer);
                            int index = content.IndexOf("</WIM>", StringComparison.Ordinal);
                            if (index >= 0)
                            {
                                fileStream.Seek((index + 12 - (long)x), SeekOrigin.Current);
                                final = (ulong)fileStream.Position;
                                break;
                            }
                        }
                        else
                        {
                            position = fileStream.Seek(-blockSize, SeekOrigin.Current);
                        }
                    }

                    if (begin > 0 && final > begin)
                    {
                        ulong x = final - begin;
                        fileStream.Seek(-((long)x), SeekOrigin.Current);
                        buffer = new byte[x];
                        int bytesReadFinal = fileStream.Read(buffer, 0, (int)x);
                        if ((ulong)bytesReadFinal != x)
                        {
                            Console.WriteLine("TPM patch failed");
                            return false;
                        }
                        content = Encoding.GetEncoding(28591).GetString(buffer);
                        int src = content.IndexOf(typeC, StringComparison.Ordinal) >= 0 ? 0 : 1;
                        string old, newStr;
                        if (src == 0 && toggle != 0)
                        {
                            old = typeC;
                            newStr = typeS;
                        }
                        else if (src == 1 && toggle != 1)
                        {
                            old = typeS;
                            newStr = typeC;
                        }
                        else
                        {
                            Console.WriteLine($"\n:) {isoFilePath} already has TPM patch {toggle}");
                            return true;
                        }
                        content = content.Replace(old, newStr);
                        buffer = Encoding.GetEncoding(28591).GetBytes(content);
                        fileStream.Seek(-((long)x), SeekOrigin.Current);
                        fileStream.Write(buffer, 0, (int)x);
                        if (src == 1)
                        {
                            Console.WriteLine("\n :D TPM patch removed");
                            return false;
                        }
                        else
                        {
                            Console.WriteLine("\n :D TPM patch added");
                            return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n ;( TPM patch failed");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("\n No action required.");
                    return false;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n ERROR! {isoFilePath} read-only or in use ...\n");
            Console.WriteLine(ex.Message);
            return false;
        }
    }

    static string ToChars(string input)
    {
        return Encoding.GetEncoding(28591).GetString(Encoding.Unicode.GetBytes(input));
    }

    static bool IsTPMPatched(string filePath)
    {
        try
        {
            const string typeC = "<INSTALLATIONTYPE>Client";
            const string typeS = "<INSTALLATIONTYPE>Server";
            string cli = ToChars(typeC);
            string srv = ToChars(typeS);


            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                Console.WriteLine($"{filePath}\nSearching {fs.Length} bytes, please wait ...\n");

                byte[] buffer = new byte[4096*2]; // Buffer size
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string content = Encoding.GetEncoding(28591).GetString(buffer, 0, bytesRead);

                    if (content.Contains(cli))
                    {
                        Console.WriteLine(content);

                        fs.Close();
                        fs.Dispose();
                        return false;
                    }
                    else if (content.Contains(srv))
                    {
                        Console.WriteLine(content);

                        fs.Close();
                        fs.Dispose();
                        return true;
                    }
                }

                fs.Close();
                fs.Dispose();
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nError: {ex.Message}");
            return false;
        }
    }
}
