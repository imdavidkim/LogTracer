using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Configuration;
using System.Threading;
using log4net;
using log4net.Config;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace Tracer
{
    public class MMFMapping
    {

        public string mmfName = string.Empty;
        public MemoryMappedFile mmfFile;
        public string mmfSrcPath = string.Empty;

        public MMFMapping(string name, MemoryMappedFile mmf, string path)
        {

            this.mmfName = name;
            this.mmfFile = mmf;
            this.mmfSrcPath = path;
        }

    }
    public partial class ChildForm : Form
    {
        public static PropertyForm _prop;
        private string TargetType = "";
        private string TargetPath = "";
        private string TargetName = "";
        private bool IsFirst = true;
        private FileStream fs;
        //private StreamReader sr;
        private FileSystemWatcher watcher;
        private List<string[]> cached;
        //20180719
        private List<long[]> FileLineMap;
        private MemoryMappedFile mmf;
        //private MemoryMappedViewAccessor mmva;
        private MemoryMappedViewStream mmvs;
        private MMFMapping mmfm;
        private int currIndex;
        private int totalCount = 0;
        private static int fileCount = 0;
        private static int patternCount = 0;
        public MessengerHelper m;
        public SMSHelper sh;
        ILog logger;
        private bool mmfUpdateFlag = false;
        private System.Windows.Forms.Timer FileUpdateTimer = new System.Windows.Forms.Timer();
        //private event EventHandler FileUpdatedEventHandler;
        private delegate void InvokedListViewUpdate(int i);
        protected override void OnClosing(CancelEventArgs e)
        {
            listView1.Dispose();
            cached = null;
            fs.Dispose();
            watcher.Changed -= new FileSystemEventHandler(Changed);
            watcher.Dispose();
            mmvs.Dispose();
            mmf.Dispose();
            mmfm = null;
            FileUpdateTimer.Stop();
            FileUpdateTimer.Tick -= this._timer_Tick;
            FileUpdateTimer.Dispose();
            GC.Collect();
            base.OnClosing(e);
        }
        public ChildForm(string targetType, string[] targetInfo, PropertyForm prop)
        {
            try
            {
                XmlConfigurator.Configure(new System.IO.FileInfo("App.config"));
                InitializeComponent();
                logger = LogManager.GetLogger("LogTracer");
                _prop = prop;
                TargetType = targetType;
                TargetPath = targetInfo[0];
                TargetName = targetInfo[1];
                this.Text = TargetName;
                listView1.LabelWrap = true;
                listView1.MultiSelect = false;
                listView1.VirtualMode = true;
                listView1.View = View.Details;
                listView1.Columns.Add("Log");
                listView1.Columns[0].Width = Width - 20 - SystemInformation.VerticalScrollBarWidth;
                listView1.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
                //listView1.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(listView1_ItemSelectionChanged);
                //listView1.VirtualItemsSelectionRangeChanged += new ListViewVirtualItemsSelectionRangeChangedEventHandler(listView1_VirtualItemsSelectionRangeChanged);
                //listView1.RetrieveVirtualItem += new RetrieveVirtualItemEventHandler(listView1_RetrieveVirtualItem);
                //listView1.CacheVirtualItems += new CacheVirtualItemsEventHandler(listView1_CacheVirtualItems);
                //listView1.SearchForVirtualItem += new SearchForVirtualItemEventHandler(listView1_SearchForVirtualItem);
                if (cached == null)
                {
                    cached = new List<string[]>();
                }
                //cached = new List<string[]>();
                if (IsFirst)
                {
                    logger.Info(string.Format("Start file monitoring {0}", Path.Combine(TargetPath, TargetName)));
                    totalCount = 0;
                    LogProjecter2(TargetPath, TargetName);
                    FileWatching();

                }
                var appSetting = ConfigurationManager.AppSettings;

                //m = new MessengerHelper(appSetting.Get("MessengerServer"));
                m = new MessengerHelper("http://172.23.1.61:12591");
                sh = new SMSHelper(appSetting.Get("SMSServer"));
                this.Show();
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
                logger.Error("ChildForm - Error발생!!!");
            }

        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            //Console.WriteLine("_timer_Tick test");
            FileUpdate(this.mmfm);
            //if (!mmfUpdateFlag) MMFUpdate();
        }

        public void ListViewUpdate(int totalIndex)
        {
            try
            {
                //logger.Info("ListViewUpdate Called!!!");
                if (listView1.InvokeRequired)
                {
                    InvokedListViewUpdate invoked = new InvokedListViewUpdate(ListViewUpdate);
                    listView1.Invoke(invoked, totalIndex);
                }
                else
                {
                    currIndex = totalIndex - 1;
                    listView1.VirtualListSize = totalIndex;
                    listView1.EnsureVisible(currIndex);
                    listView1.Columns[0].Width = Width - 20 - SystemInformation.VerticalScrollBarWidth;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
                logger.Error("ListViewUpdate - Error발생!!!");
            }


        }
        void FileUpdate(MMFMapping mmfm)
        {
            if (mmfm == null)
            {
                Random rndm = new Random();
                string tmpName = string.Format("MMFile{0}", rndm.Next(100000));
                string tmpPath = Path.Combine(TargetPath, TargetName);
                mmfm = new MMFMapping(tmpName, mmf, tmpPath);
            }
            File.SetLastWriteTime(mmfm.mmfSrcPath, DateTime.Now);
        }

        void MMFUpdate()
        {
            try
            {
                while (mmfUpdateFlag)
                {
                    Thread.Sleep(100);
                }
                mmfUpdateFlag = true;
                mmvs.Dispose();
                mmf.Dispose();
                fs.Dispose();
                //fs.Flush();
                //mmvs.Flush();
                fs = new FileStream(mmfm.mmfSrcPath, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);
                try
                {
                    if (!fs.CanRead || !fs.CanSeek)
                    {
                        logger.Info(string.Format("FileStreamName : {0} Cannot read!!!", mmfm.mmfSrcPath));
                        logger.Info(string.Format("fs.CanRead : {0} fs.CanSeek : {1}", fs.CanRead.ToString(), fs.CanSeek.ToString()));
                    }
                    mmf = MemoryMappedFile.CreateFromFile(fs, mmfm.mmfName, 0, MemoryMappedFileAccess.Read, null, HandleInheritability.None, false);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    logger.Warn("ArgumentOutOfRangeException 발생", ex);
                    mmf = MemoryMappedFile.CreateFromFile(fs, mmfm.mmfName, fs.Length + 1024, MemoryMappedFileAccess.ReadWrite, null, HandleInheritability.None, false);
                }

                //mmf = MemoryMappedFile.CreateOrOpen()
                mmvs = mmf.CreateViewStream(0, 0, MemoryMappedFileAccess.Read);
                mmfm.mmfFile = mmf;
                mmfUpdateFlag = false;
            }
            catch (Exception ex)
            {
                logger.Error(string.Format("FileName : {0} SourceFileSize : {1}", mmfm.mmfSrcPath, fs.Length.ToString()), ex);
                logger.Error(ex.StackTrace, ex);
                logger.Error("MMFUpdate - Error발생!!!");
            }
        }
        private void LogProjecter2(string FilePath, string FileName)
        {
            try
            {
                fileCount += 1;
                if (FileLineMap == null) FileLineMap = new List<long[]>();
                Random rndm = new Random();
                //string tmpName = string.Format("MMFile{0}", fileCount);
                string tmpName = string.Format("MMFile{0}", rndm.Next(100000));
                string tmpPath = Path.Combine(FilePath, FileName);

                fs = new FileStream(tmpPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                try
                {
                    mmf = MemoryMappedFile.CreateFromFile(fs, tmpName, 0, MemoryMappedFileAccess.Read, null, HandleInheritability.None, true);
                }
                catch (IOException)
                {
                    mmf = MemoryMappedFile.OpenExisting(tmpName);
                }

                mmfm = new MMFMapping(tmpName, mmf, tmpPath);
                mmvs = mmf.CreateViewStream(0, 0, MemoryMappedFileAccess.Read);

                StreamReader localSR = new StreamReader(mmvs);
                long start = 0;
                long end = 0;
                byte[] buf = null;
                localSR.BaseStream.Position = 0;
                while (!localSR.EndOfStream)
                {
                    localSR.DiscardBufferedData();
                    localSR.BaseStream.Position = start;
                    string str = localSR.ReadLine();
                    if (str != null)
                    {
                        end = start + Encoding.Default.GetByteCount(str);
                        if (end == localSR.BaseStream.Length)
                        {
                            break;
                        }
                        FileLineMap.Add(new[] { start, end - start });
                        buf = new byte[end - start];
                        mmvs.Seek(start, SeekOrigin.Begin);

                        mmvs.Read(buf, 0, (int)(end - start));
                        string tt = Encoding.Default.GetString(buf);
                        start = end + "\r\n".Length;
                        totalCount += 1;
                    }

                }
                localSR = null;
                ListViewUpdate(totalCount);
                FileUpdateTimer.Tick += _timer_Tick;
                FileUpdateTimer.Interval = 1000;
                FileUpdateTimer.Start();
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
                logger.Error("LogProjecter2 - Error발생!!!");
            }

        }

        string getStringFromMMVSWithPosition(long[] posInfo)
        {
            try
            {
                string retStr = string.Empty;
                byte[] buf = new byte[posInfo[1]];
                if (mmvs.CanSeek)
                {
                    while (mmfUpdateFlag)
                    {
                        Thread.Sleep(100);
                    }
                    mmfUpdateFlag = true;
                    mmvs.Seek(posInfo[0], SeekOrigin.Begin);
                    mmvs.Read(buf, 0, (int)(posInfo[1]));
                    mmfUpdateFlag = false;
                    retStr = Encoding.Default.GetString(buf);
                }
                return retStr;
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
                logger.Error("getStringFromMMVSWithPosition - Error발생!!!");
                return "";
            }
        }

        string getStringFromFileWithLineNo(string fileName, int lineNo)
        {
            return File.ReadLines(fileName).Skip(lineNo).Take(1).First();
        }

        void listView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            try
            {
                if (myCache != null && e.ItemIndex >= firstItem && e.ItemIndex < firstItem + myCache.Length)
                {
                    e.Item = myCache[e.ItemIndex - firstItem];
                }
                else
                {
                    string line = getStringFromMMVSWithPosition(FileLineMap[e.ItemIndex]);
                    //if (!line.Equals(string.Empty))
                    //{
                    e.Item = new ListViewItem(line);
                    foreach (var j in _prop.FilteringList)
                    {
                        if (line.ToUpper().Contains(j.pattern.ToUpper()))
                        {
                            e.Item.BackColor = j.bgcolor;
                            e.Item.ForeColor = j.fgcolor;
                        }
                    }
                    //}
                }

                listView1.Update();
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                logger.Error(string.Format("RetrieveVirtualItem - ItemIndex:{0}", e.ItemIndex));
                //Console.WriteLine(e.ToString());
                //Console.WriteLine(string.Format("RetrieveVirtualItem - ItemIndex:{0}", e.ItemIndex));
            }
        }


        void listView1_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e)
        {
            try
            {
                if (totalCount > listView1.VirtualListSize)
                    listView1.VirtualListSize = totalCount;
                if (e.StartIndex == 0 && totalCount >= e.EndIndex)
                {
                    listView1.EnsureVisible(currIndex);
                    IsFirst = false;
                }
                int length = e.EndIndex - e.StartIndex + 1;
                firstItem = e.StartIndex;

                if (myCache != null)
                {
                    if (e.StartIndex >= firstItem && e.EndIndex < firstItem + myCache.Length)
                    {
                        return;
                    }
                    else
                    {
                        myCache = new ListViewItem[length];
                        for (int i = 0; i < length; i++)
                        {
                            string line = getStringFromMMVSWithPosition(FileLineMap[i + e.StartIndex]);
                            if (!line.Equals(string.Empty))
                            {
                                myCache[i] = new ListViewItem(line);
                                foreach (var j in _prop.FilteringList)
                                {
                                    if (line.ToUpper().Contains(j.pattern.ToUpper()))
                                    {
                                        myCache[i].BackColor = j.bgcolor;
                                        myCache[i].ForeColor = j.fgcolor;
                                    }
                                }
                            }
                        }
                    }
                }
                listView1.Update();
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
                logger.Error("CacheVirtualItems - Error발생!!!");
                //Console.WriteLine("CacheVirtualItems - Error발생!!!");
                //Console.WriteLine(e.ToString());
            }
        }

        void listView1_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e)
        {
            double x = 0;
            if (double.TryParse(e.Text, out x))
            {
                x = System.Math.Sqrt(x);
                x = System.Math.Round(x);
                e.Index = (int)x;
            }
        }

        void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Console.WriteLine("listView1_ItemSelectionChanged Occured {0} {1} {2} {3}", e.ItemIndex, e.Item.SubItems[0], e.Item.SubItems[1], e.Item.SubItems[2]);
            listView1.Update();
        }

        void listView1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void FileWatching()
        {
            try
            {
                watcher = new FileSystemWatcher();
                watcher.Path = TargetPath;
                watcher.Filter = TargetName;
                //watcher.NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.Size;
                watcher.NotifyFilter = NotifyFilters.Size;
                watcher.EnableRaisingEvents = true;
                //watcher.InternalBufferSize = 4096;
                watcher.Changed += new FileSystemEventHandler(Changed);
                adjustColumnSize();
            }
            catch (Exception e)
            {
                logger.Error(e.StackTrace, e);
                logger.Error("FileWatching - Error발생!!!");
            }



        }
        private void Changed(object source, FileSystemEventArgs e)
        {
            try
            {
                while (mmfUpdateFlag)
                {
                    Thread.Sleep(100);
                }
                MMFUpdate();
                //while (mmfUpdateFlag)
                //{
                //    Thread.Sleep(100);
                //}
                ListViewItem lvi = new ListViewItem();
                mmvs.Flush();
                StreamReader localSR = new StreamReader(mmvs);

                var posInfo = FileLineMap.Last();
                long start = posInfo[0] + posInfo[1] + "\r\n".Length;
                long end = 0;
                while (!localSR.EndOfStream)
                {
                    localSR.DiscardBufferedData();
                    localSR.BaseStream.Position = start;
                    string strLine = localSR.ReadLine();
                    if (strLine == null)
                    {
                        break;
                    }
                    end = start + Encoding.Default.GetByteCount(strLine);
                    if (end >= localSR.BaseStream.Length)
                    {
                        if (end > localSR.BaseStream.Length) logger.Info(string.Format("end({0}) > ({1})localSR.BaseStream.Length", end, localSR.BaseStream.Length));
                        MMFUpdate();
                        break;
                    }
                    FileLineMap.Add(new[] { start, end - start });
                    var buf = new byte[end - start];
                    mmvs.Seek(start, SeekOrigin.Begin);
                    mmvs.Read(buf, 0, (int)(end - start));
                    string tmp = Encoding.Default.GetString(buf);
                    PatternDetect(tmp);
                    start = end + "\r\n".Length;
                    totalCount += 1;
                }
                ListViewUpdate(totalCount);
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
                logger.Error("FileSystemWatcher Changed Error발생");
                m.SendMessage("3303409", "Error발생-Changed", TargetPath + "\\" + TargetName);
                //MessageBox.Show(e.ToString());
            }

        }

        private void PatternDetect(string str)
        {
            try
            {
                foreach (var i in _prop.FilteringList)
                {
                    if (i.alert == true && str.ToUpper().Contains(i.pattern.ToUpper()))
                    {
                        i.count += 1;
                        patternCount += 1;
                        if (i.count % 10 == 0 && i.count > 0)
                        {
                            //m.SendMessage("3303409,", string.Format("{0} pattern found in {1}", i.pattern, TargetName), string.Format("마지막 알림 이후에 현재 {0} 패턴이 {1} 에 위치한\n{2} 파일에서 {3}번 발생하였고 Alert 모니터링 되는 패턴은 총 {4}번 발생하였습니다.", i.pattern, TargetPath, TargetName, i.count.ToString(), patternCount.ToString()));
                            m.SendMessage(GetTargetString("Messenger"), string.Format("{0} pattern found in {1}", i.pattern, TargetName), string.Format("마지막 알림 이후에 현재 {0} 패턴이 {1} 에 위치한\n{2} 파일에서 {3}번 발생하였고 Alert 모니터링 되는 패턴은 총 {4}번 발생하였습니다.", i.pattern, TargetPath, TargetName, i.count.ToString(), patternCount.ToString()));
                            if (int.Parse(DateTime.Now.ToString("HHmmss")) > 190000 || int.Parse(DateTime.Now.ToString("HHmmss")) < 60000) sh.SendMessage(GetTargetList("SMS"), string.Format("{0} pattern found in {1}", i.pattern, TargetName));
                            i.count = 0;
                            patternCount = 0;
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
                logger.Error("PatternDetect Error발생");
                m.SendMessage("3303409", "Error발생-PatternDetect", str + "\n" + TargetPath + "\\" + TargetName);
                //MessageBox.Show("MessengerHelper");
            }

        }

        private string GetTargetString(string type)
        {
            string retStr = "";
            try
            {

                foreach (var i in _prop.ContactList)
                {
                    if (retStr == "") retStr = (type == "Messenger") ? i.id : i.cellphone;
                    else retStr += "," + ((type == "Messenger") ? i.id : i.cellphone);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
                logger.Error("PatternDetect Error발생");
            }
            return retStr;
        }

        private List<string> GetTargetList(string type)
        {
            List<string> retList = new List<string>();
            try
            {

                foreach (var i in _prop.ContactList)
                {
                    if (type == "Messenger") retList.Add(i.id);
                    else retList.Add(i.cellphone);
                }

            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace, ex);
                logger.Error("PatternDetect Error발생");
            }
            return retList;
        }

        private void adjustColumnSize()
        {
            listView1.Columns[0].Width = Width - 20 - SystemInformation.VerticalScrollBarWidth;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Console.WriteLine("listView1_SelectedIndexChanged Occured");
        }

        private void listView1_Resize(object sender, EventArgs e)
        {
        }
    }
}
