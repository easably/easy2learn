using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
//using DirectShowLib;
//using DirectShowLib.DES;

//using Microsoft.WindowsAPICodePack.Shell;

namespace f
{
    public class mp4info
    {
        // http://stackoverflow.com/questions/1256841/c-sharp-get-video-file-duration-from-metadata

        //public static Dictionary<string, string> GetDetails(this FileInfo fi)
        //{
        //    Dictionary<string, string> ret = new Dictionary<string, string>();
        //    Shell shl = new ShellClass();
        //    Folder folder = shl.NameSpace(fi.DirectoryName);
        //    FolderItem item = folder.ParseName(fi.Name);

        //    for (int i = 0; i < 150; i++)
        //    {
        //        string dtlDesc = folder.GetDetailsOf(null, i);
        //        string dtlVal = folder.GetDetailsOf(item, i);

        //        if (dtlVal == null || dtlVal == "")
        //            continue;

        //        ret.Add(dtlDesc, dtlVal);
        //    }
        //    return ret;
        //}

        /// <summary>
        /// Gets the length of the video.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        //static public bool GetVideoLength(string fileName, out double length)
        //{
        //    DirectShowLib.FilterGraph graphFilter = new DirectShowLib.FilterGraph();
        //    DirectShowLib.IGraphBuilder graphBuilder;
        //    DirectShowLib.IMediaPosition mediaPos;
        //    length = 0.0;

        //    try
        //    {
        //        graphBuilder = (DirectShowLib.IGraphBuilder)graphFilter;
        //        graphBuilder.RenderFile(fileName, null);
        //        mediaPos = (DirectShowLib.IMediaPosition)graphBuilder;
        //        mediaPos.get_Duration(out length);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        mediaPos = null;
        //        graphBuilder = null;
        //        graphFilter = null;
        //    }
        //}


        //http://www.codeproject.com/Articles/43208/How-to-get-the-length-duration-of-a-media-File-in

        // For the older systems, I guess we are limited to using the old MCI (Media Control Interface) API:
        [DllImport("winmm.dll")]
        public static extern int mciSendString(string lpstrCommand, StringBuilder lpstrReturnString, int uReturnLength, int hwndCallback);
        [DllImport("winmm.dll")]
        private static extern int mciGetErrorString(int l1, StringBuilder s1, int l2);

        public static int FindLength_mciSend(string file)
        {
            try
            {
                string cmd = "open " + file + " alias voice1";
                StringBuilder mssg = new StringBuilder(255);
                int h = mciSendString(cmd, null, 0, 0);
                int i = mciSendString("set voice1 time format ms", null, 0, 0);
                int j = mciSendString("status voice1 length", mssg, mssg.Capacity, 0);
                int resMls = 0;
                int.TryParse(mssg.ToString(), out resMls);
                return resMls;
            }
            catch
            {
                return -1;
            }
        }

        //public static int FindLength(string file)
        //{
        //    ShellFile so = ShellFile.FromFilePath(file);
        //    double nanoseconds;
        //    double.TryParse(so.Properties.System.Media.Duration.Value.ToString(),
        //    out nanoseconds);
        //    Console.WriteLine("NanaoSeconds: {0}", nanoseconds);
        //    if (nanoseconds > 0)
        //    {
        //        double seconds = Convert100NanosecondsToMilliseconds(nanoseconds) / 1000;
        //        Console.WriteLine(seconds.ToString());
        //    }
        //}

        //public static double Convert100NanosecondsToMilliseconds(double nanoseconds)
        //{
        //    // One million nanoseconds in 1 millisecond, 
        //    // but we are passing in 100ns units...
        //    return nanoseconds * 0.0001;
        //}

        // -----------------------

        // http://www.codeproject.com/Questions/387013/how-to-get-the-information-of-an-mp-file-h-st
        //public static string GetDuration(string fileName)
        //{
        //    var mediaDet = (IMediaDet)new MediaDet();
        //    DsError.ThrowExceptionForHR(mediaDet.put_Filename(fileName));

        //    // find the video stream in the file
        //    int index;
        //    var type = Guid.Empty;
        //    for (index = 0; index < 1000 && type != MediaType.Video; index++)
        //    {
        //        mediaDet.put_CurrentStream(index);
        //        mediaDet.get_StreamType(out type);
        //    }

        //    // retrieve some measurements from the video
        //    double frameRate;
        //    mediaDet.get_FrameRate(out frameRate);

        //    var mediaType = new AMMediaType();
        //    mediaDet.get_StreamMediaType(mediaType);
        //    var videoInfo = (VideoInfoHeader)Marshal.PtrToStructure(mediaType.formatPtr, typeof(VideoInfoHeader));
        //    DsUtils.FreeAMMediaType(mediaType);
        //    var width = videoInfo.BmiHeader.Width;
        //    var height = videoInfo.BmiHeader.Height;

        //    double mediaLength;
        //    mediaDet.get_StreamLength(out mediaLength);
        //    //var frameCount = (int)(frameRate * mediaLength);
        //    //var duration = frameCount / frameRate;

        //    return mediaLength.ToString();
        //}
    }
}
