using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;
using System.Data;
using System.IO;
using DTO;
using DAO;

namespace BUS
{
    public class AutomailBUS
    {
        // khai báo các biến sử dụng
        private static string AutomailFile = "AutomailData.csv";
        private static string AutomailPath = @"\\Fppdhkg73\SHAREDISK\Oracle - All SO\Thailand & Vietnam SO\"; 
        // private static string AutomailPath = @"C:\\Backups\"; // tmp
        // private static string AutomailPath = @"\\147.121.59.246\AutomailFolder\"; // tmp

        // Lấy thông tin folder đang chạy chương trình, lưu file nguồn (AutomailFile) vào đây
        private static string FolderStartUp = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);

        private static AutoloadDAO Auto = new AutoloadDAO();
        private static VnsoDAO Vnso = new VnsoDAO();
        private static VnsoTotalDAO Vnso_total = new VnsoTotalDAO();

        private static VnsoTmpDAO Vnso_tmp = new VnsoTmpDAO();

        // read all data
        public DataTable ReadAll()
        {
            return Vnso.ReadAll();
        }

        // read all data
        public int checkEmpty()
        {
            return Vnso_tmp.checkEmpty();
        }

        // read all data
        public DataTable ReadAutoloadItem()
        {
            return Auto.ReadItem();
        }

        // add data
        public int AddVnsoTmp()
        {
            var result = 0;

            Console.Write("Automail Start: "); // 1

            //get data to tmp table
            if (this.getAutomailData())
            {
                Console.Write("Get File success ..."); // 2
                result = Vnso_tmp.Add(AutomailFile);
            } else
            {
                Console.Write("Get File Fail ..."); // 2
            }

            return result;
        }

        // add data
        public int AddVnso()
        {
            //Console.Write("Updating VNSO_TOTAL... ");
            var result = 0;
            result = Vnso.Add(AutomailFile);

            return result;
        }

        // add data
        public int AddVnsoTotal()
        {
            //Console.Write("Updating VNSO_TOTAL... ");
            var result = 0;
            result = Vnso_total.Add(AutomailFile);

            return result;
        }

        // Add data (Autoload table)
        public bool AddAutoload(string STATUS )
        {
            bool Result = false;
            try
            {
                // Get data for Autoload
                AutoloadDTO Autoload = getAutoloadData(STATUS);
                // Add data to Autoload table
                Result = Auto.Add(Autoload);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception of type " + ex.GetType() );
            }
                
            return Result;
        }

        public string getZipName()
        {
            var LogData = "";
            try
            {
                // lay file zip mới nhất
                DirectoryInfo directory = new DirectoryInfo(AutomailPath);
                var zipPath = (from zfile in directory.EnumerateFiles("VN_*.zip") orderby zfile.LastWriteTime descending select zfile).First();
                // lay file zip mới nhất
                LogData = zipPath.Name.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception of type " + ex.GetType());
            }
            

            return LogData;
        }

        // Get destination Automail Data, true if success else fale
        public bool getAutomailData()
        {
            string FileName = "";

            try
            {
                FolderStartUp = FolderStartUp.Replace("file:\\", "");
                DirectoryInfo directoryPath = new DirectoryInfo(FolderStartUp);

                FastZip fastZip = new FastZip();

                // Xóa file .csv trước khi lấy file zip mới và giải nén
                foreach (var file in directoryPath.EnumerateFiles("*.csv"))
                    File.Delete(file.FullName);
                
                // Xóa file Automail data nếu đã tồn tại
                if (File.Exists(AutomailFile)) File.Delete(AutomailFile);

                // lay file zip mới nhất
                DirectoryInfo directory = new DirectoryInfo(AutomailPath);
                var zipPath = (from zfile in directory.EnumerateFiles("VN_*.zip") orderby zfile.LastWriteTime descending select zfile).First();
                
                // giai nen
                fastZip.ExtractZip(zipPath.FullName.ToString(), FolderStartUp, null);
                
                // Gộp tất cả các file lại thành 1 file lưu vào file Automail (AutomailFile)
                foreach (var zfile in directoryPath.EnumerateFiles("VN_*.csv"))
                {
                    FileName = zfile.FullName;
                    if (!this.GetSourceFile(FileName)) return false;
                }

                return true;
            }
            catch
            {
                return false;
            }

        }

        // Get full source file: join from Automail files
        public bool GetSourceFile(string SourceFile)
        {
            try
            {
                // Mở file đích muốn ghi dữ liệu
                using (StreamWriter writer = new StreamWriter(AutomailFile, true))
                // Đọc file nguồn (File) để ghi dữ liệu vào file đích (AutomailFile)
                using (var reader = new StreamReader(SourceFile))
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split('\t');
                        {
                            string NewLine = "";
                            foreach (string f in values)
                            {
                                NewLine = NewLine + f.Replace("\\", "\\\\") + "\t";
                            }
                            writer.WriteLine(NewLine);
                        }
                    }

                    //close file
                    writer.Close();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    
        // get data for Autoload
        public AutoloadDTO getAutoloadData(string STATUS)
        {
            AutoloadDTO Autoload = new AutoloadDTO();
            try
            {
                string DateYMD = DateTime.Now.ToString("yyyy-MM-dd");
                string TimeHH = DateTime.Now.ToString("HH:mm");
                //// lay file zip mới nhất (tên file)
                var LogData = this.getZipName();
                if ( (STATUS == "ERR_01") || (STATUS == "ERR_03") )
                {
                    LogData = "";
                }
                string DataFunc = "AUTOMAIL";

                int Empty =  Vnso_tmp.checkEmpty();

                // set AutoloadDTO
                Autoload = new AutoloadDTO(0, DateYMD, TimeHH, STATUS, LogData, DataFunc, Convert.ToString(Empty) );

            }
            catch (Exception ex)
            {
                Console.WriteLine("An exception of type " + ex.GetType());
            }

            // return
            return Autoload;


        }


}
        

    
}
