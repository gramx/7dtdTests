using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7dtdTests {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("7 Days to die tests project");

            // Testing
            using (FileStream streamPrep = new FileStream(@"G:\temp\7dtd\defaultPrefab\gas_station1.tts", FileMode.Open)) {
                // Read bytes for header
                byte[] header1 = new byte[1];
                streamPrep.Read(header1, 0, header1.Length);
                string header1Display = string.Join(" ", header1.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
                Console.WriteLine("Header 1 [" + Convert.ToString(header1[0]) + "]: " + header1Display);
                byte[] header2 = new byte[1];
                streamPrep.Read(header2, 0, header2.Length);
                string header2Display = string.Join(" ", header2.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
                Console.WriteLine("Header 2 [" + Convert.ToString(header2[0]) + "]: " + header2Display);
                byte[] header3 = new byte[1];
                streamPrep.Read(header3, 0, header3.Length);
                string header3Display = string.Join(" ", header3.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
                Console.WriteLine("Header 3 [" + Convert.ToString(header3[0]) + "]: " + header3Display);
                byte[] header4 = new byte[1];
                streamPrep.Read(header4, 0, header4.Length);
                string header4Display = string.Join(" ", header4.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
                Console.WriteLine("Header 4 [" + Convert.ToString(header4[0]) + "]: " + header4Display);
                // Read bytes for version
                byte[] versionInfo1 = new byte[1];
                streamPrep.Read(versionInfo1, 0, versionInfo1.Length);
                string versionInfo1Display = string.Join(" ", versionInfo1.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
                Console.WriteLine("Version Info 1 [" + Convert.ToString(versionInfo1[0]) + "]: " + versionInfo1Display);
                byte[] versionInfo2 = new byte[1];
                streamPrep.Read(versionInfo2, 0, versionInfo2.Length);
                string versionInfo2Display = string.Join(" ", versionInfo2.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
                Console.WriteLine("Version Info 2 [" + Convert.ToString(versionInfo2[0]) + "]: " + versionInfo2Display);
                byte[] versionInfo3 = new byte[1];
                streamPrep.Read(versionInfo3, 0, versionInfo3.Length);
                string versionInfo3Display = string.Join(" ", versionInfo3.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
                Console.WriteLine("Version Info 3 [" + Convert.ToString(versionInfo3[0]) + "]: " + versionInfo3Display);
                byte[] versionInfo4 = new byte[1];
                streamPrep.Read(versionInfo4, 0, versionInfo4.Length);
                string hversionInfo4Display = string.Join(" ", versionInfo4.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
                Console.WriteLine("Version Info 4 [" + Convert.ToString(versionInfo4[0]) + "]: " + hversionInfo4Display);
                streamPrep.Close();
            }

            // Using FileStream directly with a buffer
            using (FileStream stream = new FileStream(@"G:\temp\7dtd\defaultPrefab\gas_station1.tts", FileMode.Open)) {
                // Read bytes for header
                byte[] header = new byte[4];
                stream.Read(header, 0, header.Length);
                string headerDisplay = string.Join(" ", header.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
                Console.WriteLine("Header [" + BitConverter.ToUInt32(header, 0).ToString() + "]: " + headerDisplay);
                // Read bytes for version
                byte[] versionInfo = new byte[4];
                stream.Read(versionInfo, 0, versionInfo.Length);
                string versionInfoDisplay = string.Join(" ", versionInfo.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));
                Console.WriteLine("Version Info [" + BitConverter.ToUInt32(versionInfo, 0).ToString() + "]: " + versionInfoDisplay);
                byte[] buffer = new byte[2];
                int count;
                // Read from the IO stream fewer times.
                while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
                    for (int i = 0; i < count; i++)
                        Console.WriteLine(" c[" + count.ToString() + "] " + Convert.ToUInt16(buffer[i]).ToString());
            }

            Console.WriteLine(" ");
            Console.WriteLine("End");
        }
    }
}
