using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_Trainer_Menu.librpc
{
    class MemoryScanner
    {
       
            // Token: 0x06000055 RID: 85 RVA: 0x00006B9C File Offset: 0x00004D9C
            public static SCAN_TYPE StringToType(string str)
            {
            SCAN_TYPE result = SCAN_TYPE.BYTE;
                string a = str.ToUpper();
                if (!(a == "BYTE"))
                {
                    if (!(a == "SHORT"))
                    {
                        if (!(a == "INTEGER"))
                        {
                            if (!(a == "LONG"))
                            {
                                if (!(a == "FLOAT"))
                                {
                                    if (a == "DOUBLE")
                                    {
                                        result = SCAN_TYPE.DOUBLE;
                                    }
                                }
                                else
                                {
                                    result = SCAN_TYPE.FLOAT;
                                }
                            }
                            else
                            {
                                result = SCAN_TYPE.LONG;
                            }
                        }
                        else
                        {
                            result = SCAN_TYPE.INTEGER;
                        }
                    }
                    else
                    {
                        result = SCAN_TYPE.SHORT;
                    }
                }
                else
                {
                    result = SCAN_TYPE.BYTE;
                }
                return result;
            }

            // Token: 0x06000056 RID: 86 RVA: 0x00006C1C File Offset: 0x00004E1C
            public static string TypeToString(SCAN_TYPE type)
            {
                string result = "";
                switch (type)
                {
                    case SCAN_TYPE.BYTE:
                        result = "BYTE";
                        break;
                    case SCAN_TYPE.SHORT:
                        result = "SHORT";
                        break;
                    case SCAN_TYPE.INTEGER:
                        result = "INTEGER";
                        break;
                    case SCAN_TYPE.LONG:
                        result = "LONG";
                        break;
                    case SCAN_TYPE.FLOAT:
                        result = "FLOAT";
                        break;
                    case SCAN_TYPE.DOUBLE:
                        result = "DOUBLE";
                        break;
                }
                return result;
            }

            // Token: 0x06000057 RID: 87 RVA: 0x00006C7E File Offset: 0x00004E7E
            public static uint GetTypeLength(SCAN_TYPE type)
            {
                switch (type)
                {
                    case SCAN_TYPE.BYTE:
                        return 1u;
                    case SCAN_TYPE.SHORT:
                        return 2u;
                    case SCAN_TYPE.INTEGER:
                        return 4u;
                    case SCAN_TYPE.LONG:
                        return 8u;
                    case SCAN_TYPE.FLOAT:
                        return 4u;
                    case SCAN_TYPE.DOUBLE:
                        return 8u;
                    default:
                        return 0u;
                }
            }

            // Token: 0x06000058 RID: 88 RVA: 0x00006CAD File Offset: 0x00004EAD
            public static uint GetTypeLength(string type)
            {
                return GetTypeLength(StringToType(type));
            }

            // Token: 0x06000059 RID: 89 RVA: 0x00006CBA File Offset: 0x00004EBA
            public static bool CompareEqual(byte[] v1, byte[] v2, SCAN_TYPE type)
            {
                return v1.SequenceEqual(v2);
            }

            // Token: 0x0600005A RID: 90 RVA: 0x00006CBA File Offset: 0x00004EBA
            public static bool CompareLessThan(byte[] v1, byte[] v2, SCAN_TYPE type)
            {
                return v1.SequenceEqual(v2);
            }

            // Token: 0x0600005B RID: 91 RVA: 0x00006CBA File Offset: 0x00004EBA
            public static bool CompareGreaterThan(byte[] v1, byte[] v2, SCAN_TYPE type)
            {
                return v1.SequenceEqual(v2);
            }

            // Token: 0x0600005C RID: 92 RVA: 0x00006CC4 File Offset: 0x00004EC4
            public static Dictionary<ulong, byte[]> ScanMemory(ulong address, byte[] data, SCAN_TYPE type, byte[] value, CompareFunction cfunc)
            {
                uint typeLength = GetTypeLength(type);
                Dictionary<ulong, byte[]> dictionary = new Dictionary<ulong, byte[]>();
                for (uint num = 0u; num < (uint)(data.Length - (int)typeLength); num += 1u)
                {
                    byte[] array = new byte[typeLength];
                    Array.Copy(data, (long)((ulong)num), array, 0L, (long)((ulong)typeLength));
             //   cfunc = CompareEqual;
                    if (cfunc(array, value, type))
                    {
                        dictionary.Add(address + (ulong)num, value);
                    }
                }
                return dictionary;
            }

        private static int ByteSearch(byte[] searchIn, byte[] searchBytes, int start = 0)
        {
            int found = -1;
            bool matched = false;
            //only look at this if we have a populated search array and search bytes with a sensible start
            if (searchIn.Length > 0 && searchBytes.Length > 0 && start <= (searchIn.Length - searchBytes.Length) && searchIn.Length >= searchBytes.Length)
            {
                //iterate through the array to be searched
                for (int i = start; i <= searchIn.Length - searchBytes.Length; i++)
                {
                    //if the start bytes match we will start comparing all other bytes
                    if (searchIn[i] == searchBytes[0])
                    {
                        if (searchIn.Length > 1)
                        {
                            //multiple bytes to be searched we have to compare byte by byte
                            matched = true;
                            for (int y = 1; y <= searchBytes.Length - 1; y++)
                            {
                                if (searchIn[i + y] != searchBytes[y])
                                {
                                    matched = false;
                                    break;
                                }
                            }
                            //everything matched up
                            if (matched)
                            {
                                found = i;
                                break;
                            }

                        }
                        else
                        {
                            //search byte is only one bit nothing else to do
                            found = i;
                            break; //stop the loop
                        }

                    }
                }

            }
            return found;
        }

        // Token: 0x0200001F RID: 31
        public enum SCAN_TYPE
            {
                // Token: 0x040000E7 RID: 231
                BYTE,
                // Token: 0x040000E8 RID: 232
                SHORT,
                // Token: 0x040000E9 RID: 233
                INTEGER,
                // Token: 0x040000EA RID: 234
                LONG,
                // Token: 0x040000EB RID: 235
                FLOAT,
                // Token: 0x040000EC RID: 236
                DOUBLE
            }

            // Token: 0x02000020 RID: 32
            // (Invoke) Token: 0x06000093 RID: 147
            public delegate bool CompareFunction(byte[] v1, byte[] v2, SCAN_TYPE type);
        }

    }

