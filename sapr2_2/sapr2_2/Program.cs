using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace sapr2_2
{
    class Program
    {
        static int count_state(string[,] matr)
        {
            int sum = 0;
            for (int i = 1; i < 19; i++)
            {
                if (matr[i, 0] != null&&matr[i,0]!="_")
                    sum++;

            }
            return sum;
        }
        static bool Compare(List<string> str,string[,] matr,int A,int  B)
        {
           
            bool flag = false;
            for(int i=1;i<3;i++)
            {
               // flag = false;
                for (int j = 0; j < str.Count; j++)
                {
                    
                    if (matr[A, i] != "_" && matr[B, i] != "_")
                    {
                        if (str[j].Contains(matr[A, i]) && str[j].Contains(matr[B, i]))
                        {
                            flag = true;
                            break;
                        }
                        else return false;
                        
                    }
                    if(matr[A, i] == "_" && matr[B, i] == "_")
                    {
                        break;
                    }
                    if ((matr[A, i] != "_" && matr[B, i] == "_")||(matr[A, i] == "_" && matr[B, i] != "_"))
                    {
                        return false;
                    }

                }
                        
                         
            }
            return flag;

            
        }
        static void Main(string[] args)
        {

            string[,] matr = new string[20, 20];
            matr[0, 0] = "st"; matr[0, 1] = "0"; matr[0,2] = "1"; matr[0, 3] = "e"; matr[0, 4] = "st";
            // matr[1, 0] = "A"; matr[1, 1] = "B"; matr[1, 2] = "C"; matr[1, 3] = "_"; matr[1, 4] = "0";
            //   matr[2, 0] = "B"; matr[2, 1] = "B"; matr[2, 2] = "_"; matr[2, 3] = "_"; matr[2, 4] = "0";
            //   matr[3, 0] = "C"; matr[3, 1] = "_"; matr[3, 2] = "D"; matr[3, 3] = "_"; matr[3, 4] = "0";
            //   matr[4, 0] = "D"; matr[4, 1] = "D"; matr[4, 2] = "_"; matr[4, 3] = "E"; matr[4, 4] = "0";
            //  matr[5, 0] = "E"; matr[5, 1] = "_"; matr[5, 2] = "E"; matr[5, 3] = "F"; matr[5, 4] = "0";
            //   matr[6, 0] = "F"; matr[6, 1] = "G"; matr[6, 2] = "_"; matr[6, 3] = "_"; matr[6, 4] = "0";
            //   matr[7, 0] = "G"; matr[7, 1] = "_"; matr[7, 2] = "_"; matr[7, 3] = "_"; matr[7, 4] = "1";
            StreamReader f = new StreamReader(@"C:\Users\Вадим\Desktop\NKA.txt");
            string lin;
            int x=0, y=0;
            while((lin=f.ReadLine())!=null)
            {
                matr[x, y] = lin;

                if (y == 4) { y = -1; x++; }
                y++;
            }
            /*
            Console.WriteLine("Input NFA");

            
            Console.WriteLine("Input count of states");
            int nmb = int.Parse(Console.ReadLine());
            Console.WriteLine("Input NFA");
            for (int i=1;i<= nmb;i++)
            {
                Console.WriteLine("input "+i.ToString()+"station");
                for(int j=0;j<5;j++)
                {
                    matr[i, j] = Console.ReadLine();
                }
            }
            */


            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j <= 7; j++)
                {
                    if (matr[i, j] == null)
                        matr[i, j] = "_";
                }

            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(matr[i, j].ToString() + "   ");
                }
                Console.WriteLine();
            }
            //step1
            

            //step2
            for(int i=1;i<count_state(matr); i++)
            {
                if(matr[i,3]!="_")
                {
                    if(matr[i,3]!="")
                    {
                        int n = matr[i, 3][0] - 'A'+1;
                        if (matr[n, 4] != "1")
                        {
                            for (int j = 1; j < 4; j++)
                                if (matr[n, j] != "_")
                                {
                                    if (matr[i, j] == "_")
                                        matr[i, j] = matr[i, j].Substring(1);
                                    if (!matr[i, j].Contains(matr[n, j]))
                                        matr[i, j] += matr[n, j];
                                }
                        }
                        else
                        {
                            matr[i, 4] = "1";
                            matr[i, 3] = "_";
                        }


                           
                    }
                    if (matr[i, 3].Length != 1)
                    {
                        matr[i, 3] = matr[i, 3].Substring(1);
                        i--;
                    }
                    else
                        matr[i, 3] = "_";
                }
            }
            
            for(int i=1;i<count_state (matr);i++)
            {
                for (int j = 1; j <4; j++)
                {
                    if(matr[i,j].Length>1)
                    {
                        char newstation = (char)('A'+count_state(matr));
                        matr[newstation-'A'+1, 0] = newstation.ToString();
                        string s = matr[i, j];
                        matr[i, j] = newstation.ToString();
                       // if (s.Contains(matr[i, 0])) matr[i, 6] = "0";
                        while(s!="")
                        {
                          for(int k=1;k<=4;k++)
                            {
                                if(matr[s[0]-'A'+1,k]!="_")
                                {
                                    if (matr[newstation - 'A' + 1, k] == "_"|| matr[newstation - 'A' + 1, k]=="0")
                                        matr[newstation - 'A' + 1, k] = string.Empty;
                                    matr[newstation - 'A'+1, k] += matr[s[0] - 'A' + 1, k];
                                }
                            }
                            s =s.Substring(1); 
                        }
                        
                    }
                }

            }










            string step3="A";
            int line = 1;
            int nstr = 1;
            while (line != 0)
            {
                for (int i = 1; i < 4; i++)
                {

                    if (matr[line, i] != "_")
                    {
                        if (!step3.Contains(matr[line, i]))
                            step3 += matr[line, i];

                    }
                }
                matr[line, 5] = "1";
                if (step3.Length != nstr)
                    line = step3[nstr++] - 'A' + 1;
                else
                    line = 0;
            }
            for (int i = 0; i < 20; i++)
            {
                // if(matr[i,5]=="1"&&matr[i,6]=="1")
                for (int j = 0; j < 6; j++)
                {
                    Console.Write(matr[i, j].ToString() + "   ");
                }
                Console.WriteLine();
            }


            //step4
            List<string> m = new List<string>();
            m.Add(string.Empty);
            m.Add(string.Empty);
            for (int i = 1; i <= count_state(matr); i++)
            {
                if (matr[i, 4] != "1" && matr[i, 5] == "1")
                    m[0] += matr[i, 0];
                if(matr[i,4]=="1"&&matr[i,5]=="1")
                    m[1] += matr[i, 0];
            }

            for(int i=0;i<m.Count;i++)
            {
                for(int j=0;j<m[i].Length-1;j++)
                {
                    
                        if (!Compare(m, matr, m[i][m[i].Length-1] - 'A' + 1, m[i][j] - 'A' + 1))
                        {
                            m.Add(m[i][j].ToString());
                            m[i] = m[i].Remove(j, 1);
                            j--;

                        }


                    
                }
            }

            for(int i=0;i<m.Count;i++)
            {

                if(matr[ m[i][0]-'A'+1,6]!="0")
                matr[m[i][0] - 'A' + 1, 6] = "1";
            }
           
            for(int i=1;i<=count_state(matr);i++)
            {
                bool flag=false;

                for(int j=1;j<4;j++)
                {
                    if (matr[i, j] != "_" && matr[i, j] != matr[i, 0]) flag = true;
                }
                if (flag) matr[i, 7] = "1";
            }


            for(int i=1;i<=count_state(matr);i++)
            {
                if (matr[i, 7] != "1" && matr[i, 4] != "1")
                {
                    for(int j=1;j<=count_state(matr);j++)
                    {
                        for(int k=0;k<3;k++)
                        {
                            if(matr[i,0]==matr[j,k])
                            {
                                matr[j, k] = "_";
                            }  
                        }
                    }
                }
                    
            }

            for (int i = 0; i < 20; i++)
            {
                if(matr[i,5]=="1"&&matr[i,6]=="1"&&(matr[i,7]=="1"||matr[i,4]=="1"))
                for (int j = 0; j <=7; j++)
                {
                    Console.Write(matr[i, j].ToString() + "   ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }
    }
}
