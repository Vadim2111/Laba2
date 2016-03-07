using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sapr2._1
{
    class Program
    {
        /* static int Count_Station=1;
         static char newstation = (char)('A'-3);
         static string str;
         static string[,] matr = new string[size, 4];
         //
         static int finish ;
         static void Func(int tek, int right, string str)
         {
             if (str == "")
                 return ;
             if (str != "")
             {
                 if (str[0] == '0' || str[0] == '1')
                 {
                     newstation = (char)('A'-2 + right+1);
                     matr[right, 0] = newstation.ToString();
                     matr[tek, str[0] - '0' + 1] += matr[right, 0];
                     Count_Station++;
                     str = str.Substring(1);
                     Func(right, right+1, str);
                     return;
                 }
             }

             if (str != "")
             {
                 if (str[0] == '|')
                 {
                     str = str.Substring(1);                 

                     Func(tek-1, right-1, str);
                     return;
                 }
             }
             if(str!=null)
             {
                 if(str[0]=='+')
                 {
                     for(int i=1;i<4;i++)
                     {
                         if (matr[tek-1, i] != null)
                             matr[tek, i] = matr[tek, 0];                        
                     }
                     newstation = (char)('A'-2 + right+1);
                     matr[right, 0] = newstation.ToString();
                     matr[tek, 3] = matr[right, 0];
                     Count_Station++;
                     str = str.Substring(1);
                     Func(tek+1, right+1, str);
                     return;
                 }
             }

             if (str != null)
             {
                 if (str[0] == '*')
                 {
                     for (int i = 1; i < 4; i++)
                     {
                         if (matr[tek-1, i] != null)
                         {
                             matr[tek-1, i] = null;
                             matr[tek, i] = matr[tek, 0];
                         }
                     }
                     matr[tek-1, 3] = matr[tek, 0];
                     newstation = (char)('A'-2 + right + 1);
                     matr[right, 0] = newstation.ToString();
                     matr[tek, 3] = matr[right, 0];
                     Count_Station++;
                     str = str.Substring(1);
                     Func(right, right+1, str);
                     return;
                 }
             }
             if(str!=null)
             {
                 if(str[0]=='(')
                 {
                     int balance = 1;
                     bool flag = true;
                     int con = 0;
                     for(int i=1;i<str.Length&&flag;i++)
                     {
                         if (str[i] == '(') balance++;
                         if (str[i] == ')') balance--;
                         if (balance == 0)
                         {
                             flag = false;
                             con = i;
                         }

                     }
                     Func(tek, right, str.Substring(1, con - 1));
                     str=str.Substring(con+1);
                     Func(Count_Station-1, Count_Station, str);
                     return;
                 }
             }

         }
         static int count_state()
         {
             int sum=0;
             for(int i=1;i<19;i++)
             {
                 if (matr[i, 0] != null)
                     sum++;

             }
             return sum;       
         }

         /*static void Func2_0(int tek,int con,int pred,string str)
         {
             if (str == "") return;
             if(str!="")
             {
                 if(str[0]=='1'||str[0]=='0')
                 {
                     newstation = (char)('A'-1 + count_state());
                     matr[count_state() + 1, 0] = newstation.ToString();
                     matr[tek, str[0] - '0' + 1] += matr[count_state(), 0];                    
                     str = str.Substring(1);
                     if (con == tek)
                         Func2_0(count_state(), count_state(), count_state() - 1, str);
                     else
                         Func2_0(count_state(), con, count_state() - 1, str);
                     return;

                 }
                 if(str[0]=='|')
                 {
                     str = str.Substring(1);
                     if (pred - 1 > 0)
                         Func2_0(pred, pred - 1, str);
                     else
                         Func2_0(pred, 1, str);

                     return;
                 }
                 if(str[0]=='+')
                 {
                     for (int i = 1; i < 4; i++)
                     {
                         if (matr[pred, i] != null&&matr[pred,i]==matr[tek,0])
                             matr[count_state(), i] = matr[pred+1, 0];
                     }
                     newstation = (char)('A'-1 + count_state());
                     matr[count_state()+1, 0] = newstation.ToString();
                     matr[count_state()-1, 3] += matr[count_state(), 0];                    
                     str = str.Substring(1);
                     Func2_0(count_state(), pred, str);
                     return;
                 }
             }
         }
         static void Func3_0(int tek,int start, string str)
         {
             if(str.Length!=1&&str!="")
             {
                 if(term.Contains(str[0])&&term.Contains(str[1]))
                 {
                     newstation = (char)('A' - 1 + count_state());
                     matr[count_state() + 1, 0] = newstation.ToString();
                     matr[tek, str[0] - '0' + 1] += matr[count_state(), 0];
                     str = str.Substring(1);
                     Func3_0(count_state(), start, str);
                     return;
                 }
                 if(term.Contains(str[0])&&str[1]=='+')
                 {
                     newstation = (char)('A' - 1 + count_state());
                     matr[count_state() + 1, 0] = newstation.ToString();
                     matr[tek, str[0] - '0' + 1] = matr[count_state(), 0];
                     matr[tek + 1, str[0] - '0' + 1] = matr[tek + 1, 0];
                     str = str.Substring(2);
                     str = "2" + str;
                     Func3_0(count_state(), start, str);
                     return;

                 }
                 if(term.Contains(str[0]) && str[1] == '|')
                 {
                     newstation = (char)('A' - 1 + count_state());
                     matr[count_state() + 1, 0] = newstation.ToString();
                     matr[tek, str[0] - '0' + 1] += matr[count_state(), 0];
                     str = str.Substring(2);
                     finish = tek + 1;
                     Func3_0(start, start,str);
                     return;

                 }
                 if(term.Contains(str[0]) & str[1]=='(')
                 {
                     newstation = (char)('A' - 1 + count_state());
                     matr[count_state() + 1, 0] = newstation.ToString();
                     matr[tek, str[0] - '0' + 1] = matr[count_state(), 0];
                     str = str.Substring(1);
                     int balance = 1;
                     bool flag = true;
                     int con = 0;
                     for (int i = 1; i < str.Length && flag; i++)
                     {
                         if (str[i] == '(') balance++;
                         if (str[i] == ')') balance--;
                         if (balance == 0)
                         {
                             flag = false;
                             con = i;
                         }

                     }
                     Func3_0(tek+1, tek+1, str.Substring(1, con - 1));
                     str = str.Substring(con+1);
                     int n = finish;
                     finish = 0;                    
                     Func3_0(count_state(),count_state()-1,  str);


                     return;
                 }
             }
             if (str != "")
             {
                 if (term.Contains(str[0]))
                 {
                     if (finish == 0)
                     {
                         newstation = (char)('A' - 1 + count_state());
                         matr[count_state() + 1, 0] = newstation.ToString();
                         matr[tek, str[0] - '0' + 1] += matr[count_state(), 0];
                         str = str.Substring(1);
                         //Func3_0(count_state(), count_state() - 1, finish, str);
                     }
                     else
                     {
                         matr[tek, str[0] - '0' + 1] += matr[finish, 0];
                         str = str.Substring(1);
                        // Func3_0(finish, finish, finish, str);
                     }

                     return;
                 }
             }
         }*/
        static string term = "012";
        static char nstation;
        static int cur = 1;
        static int start = 1;
        static int finish = 1;
        static int size = 20;
        static bool Inbracets(string str,int n)
        {
            int balance = 0;
            if (n > 0)
            {
                for (int i = 0; i < n; i++)
                {
                    if (str[i] == '(') balance++;
                    if (str[i] == ')') balance--;
                }
                return balance > 0;
            }
            else return false;
        }

        static int Find_end(string str, int n)
        {
            int balance = 0;
            if (n >= 0)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == '(') balance++;
                    if (str[i] == ')') balance--;
                    if (balance == 0) return i;
                }

            }
            return -1;
        }
        static void Func(string str,ref string[,] nka)
        {
            for (int i = 0; i < str.Length; i++)
            {
                
                if (str.Length == 1 && term.Contains(str[i]))
                {
                    if (finish != 1)
                        nka[Count_Stations(nka), finish] += str;
                    else
                    {
                        nstation = (char)('A' + 1 + Count_Stations(nka));
                        nka[Count_Stations(nka) + 1, 0] = nstation.ToString();
                        nka[0, Count_Stations(nka)] = nstation.ToString();
                        nka[cur, Count_Stations(nka)] += str;                       
                        cur = Count_Stations(nka);

                    }
                        
                }
                if (str[i] == '(')
                {
                    int k = Find_end(str, i);
                    if (str.Length - k > 2)
                    {
                        nstation = (char)('A' + 1 + Count_Stations(nka));
                        nka[Count_Stations(nka) + 1, 0] = nstation.ToString();
                        nka[0, Count_Stations(nka)] = nstation.ToString();
                        nka[cur, Count_Stations(nka)] += str.Substring(0, i);
                        str = str.Substring(2);
                        i = -1;
                        cur = Count_Stations(nka);
                        continue;
                    }
                    else
                    {
                        nka[cur, finish] += str;
                    }
                }
                if (str[i] == '&' && !Inbracets(str, i))
                {
                    nstation = (char)('A' +1+ Count_Stations(nka));
                    nka[Count_Stations(nka) + 1, 0] = nstation.ToString();
                    nka[0, Count_Stations(nka)] = nstation.ToString();                    
                    nka[cur, Count_Stations(nka)] += str.Substring(0, i);
                    str = str.Substring(2);
                    i =-1;
                    cur = Count_Stations(nka);
                    continue;
                    
                }
                
                
            }
                    
        }

        static int Count_Stations(string[,] str)
        {
            int count = 0;
            for(int i=0;i<size;i++)
            {
                if (str[i, 0] != null) count++;
            }
            return count;
        }
        static bool IsComplete(string[,] nka)
        {
            
            for(int i=0;i<size;i++)
            {
                for(int j=0; j<size;j++)
                {
                    if(nka[i,j]!=null)
                    if (nka[i, j].Length > 1) return false;
                }
            }
            return true;
        }
        static void FirstFunc(ref string[,] nka,string str)
        {
            bool flag = true;
            start = cur;
            for (int i = 0; i < str.Length; i++)
            {
                cur = start;
                if (str[i] == '|' && !Inbracets(str, i))
                {

                    Func(str.Substring(0, i), ref nka);
                    str = str.Substring(i + 1);
                    if (flag)
                    {
                        finish = cur;
                        flag = false;
                    }
                    i = -1;
                }
            }
            cur = start;
            Func(str, ref nka);

        }

        static void SecondFunc(ref string[,] nka, string str)
        {
            for(int i=0;i<str.Length;i++)
            {

            }
        }
        static void DrawGraf(ref string [,] nka)
        {
            bool flag= true;
            while(flag)
            {
                for(int i=0;i<size;i++)
                {
                    for(int j=0;j<size;j++)
                    {
                        if(nka[i,j]!=null)
                        {
                            if(nka[i,j].Length>1)
                            {
                                cur = i;
                                start = i;
                                finish = j;
                                Func(nka[i, j].Substring(1, nka[i, j].Length - 2), ref nka);
                                nka[i, j] = null;
                            }
                        }
                        
                    }
                }
                flag = !IsComplete(nka);
            }

        }
        static void Main(string[] args)
        {
            string[,] nka = new string[size, size];
            nka[1, 0] = "A";
            nka[0, 1] = "A";

            string str = "0&1&0|1&1&0|(1&0)";        
            
           
            int start=1;

            FirstFunc(ref nka, str);

            DrawGraf(ref nka);
           // cur = 1;
            //start = 1;
            //finish = 4;
           // FirstFunc(ref nka, nka[1, 4].Substring(1, nka[1, 4].Length - 2));
           // Func(nka[1, 4].Substring(1, nka[1, 4].Length - 2),ref nka);
            //nka[1, 4] = null;



            for (int i=0;i<size;i++)
            {
                for(int j=0;j<10;j++)
                {
                    if(nka[i,j]!=null)
                    Console.Write(nka[i, j].ToString() + "   | ");
                    else
                        Console.Write("     |");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }


            

        
       

    }
}
    
 

        

