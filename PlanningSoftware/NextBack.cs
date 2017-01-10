using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlanningSoftware
{
    //Author : Preethi
    class NextBack
    {
        public static string[][][] TxtBx;
        int Flg, State, n;
               
        public static int TxtChngd = 0;        
        //Constructor
        public NextBack(int Tot_GrpBxs)
        {
            TxtBx = new string[Tot_GrpBxs][][];
            Flg = 0;
        }

        public void Init(int index)
        {
            //Initilizing the array
            TxtBx[index] = new string[100][];
        }
        
        public void Next(int index, Object[] text, int total, int Sno, out Object[] txt)
        {
            txt = new Object[10];            
            int temp_Sno = Sno + 1; //Next S.No
            n = text.Count(s => s != null);            
            if (Flg != 1) //If Back Button Is Not Pressed.
            {                
                if (temp_Sno <= total) //Checking if the next value is less than total.
                {
                    TxtBx[index][Sno] = new string[n];
                    //Store in array for later use.
                    for(int i = 2; i < n; i++)
                        TxtBx[index][Sno][i] = text[i].ToString();                  

                    //Assign the next value to the textbox.
                    txt[1] = temp_Sno.ToString();

                    //Clear Textboxes.
                    for (int i = 2; i < n; i++)
                        txt[i] = "";
                    
                }
                else //If Next Value exceeds total.
                {
                    MessageBox.Show("You have reached the end of the record!", "End Of Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Order_Entry_or_Exit.errorquit = 1;
                    return; //Exit function.
                }
            }
            else //If Back Button is pressed.
            {
                /*Checking if the next value is less than the point where Back was pressed. 
                Done to print all the values upto that point when Next is pressed*/
                if (temp_Sno <= State)
                {
                    //Resave in the array in case any value is changed.
                    for (int i = 2; i < n; i++)
                        TxtBx[index][Sno][i] = text[i].ToString();

                    //Assigning the values to textboxes.
                    txt[1] = temp_Sno.ToString();
                    for (int i = 2; i < n; i++)
                        txt[i] = TxtBx[index][temp_Sno][i];
                }

                /*Making Flg 0 again so that user can continue to enter values normally. 
                Gives opportunity for Back to be pressed further on as well.*/
                if (temp_Sno == State)
                    Flg = 0;
            }
        }

        public void Back(int index, Object[] text, int Sno, int tot_changed, out Object[] txt)
        {
            txt = new Object[10];
            n = text.Count(s => s != null);
            int flg = 0;
            //If tot_changed = 1, then it implies that back is being called from TextChanged property of a Total textbox.
            if (tot_changed == 1)
            {
                TxtChngd = 1; //We make this 1 to prevent TextChanged property to fire up again in the Total Textbox as we are going to change the text in the total textbox.
                txt[0] = Sno.ToString();
                TxtChngd = 0; //Since the text is changed in the Total 
                txt[1] = Sno.ToString();
                for (int i = 2; i < n; i++)
                    txt[i] = TxtBx[index][Sno][i];
            }
            else
            {
                /*Checking If Back Button is pressed for the first time.
                Done to get the State. I want to preserve the values entered by the User. In order to preserve, State is needed.*/
                if (Flg != 1)
                {
                    Flg = 1; //Indicating Back Button is pressed.

                    /*If the textboxes are filled and then Back button is pressed, the current S.No becomes State.
                     Else, the previous S.No becomes State.*/
                    for (int i = 2; i < n; i++)
                    {
                        if (text[i].ToString() != "")
                        {
                            flg = 1; //keeping a flag to check if any textbox is empty. If it is 0, then the array wont be intialized.
                            State = Sno;
                        }
                        else
                        {
                            flg = 0;
                            State = Sno - 1;
                        }
                    }
                    int begflg = 0;
                    if (flg == 1)
                    {
                        if (text[0].ToString() == "1")                        
                            begflg = 1;                                                    
                        else
                            TxtBx[index][State] = new string[n];
                    }

                    //If the textboxes are filled and then Back button is pressed, save them into arrays for later use.
                    if (begflg == 0)
                    {
                        for (int i = 2; i < n; i++)
                        {
                            if (text[i].ToString() != "")
                                TxtBx[index][State][i] = text[i].ToString();
                        }
                    }
                }   
                           
                //Previous S.No
                int temp_TWDSno = Sno - 1;
                if (temp_TWDSno == 0)
                {
                    MessageBox.Show("You have reached the beginning of the record!", "Beginning Of Record", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Order_Entry_or_Exit.errorquit = 1;
                    //Flg = 0;
                    return; //Exit Function
                }                
                //Assign values to the textbox.
                txt[1] = temp_TWDSno.ToString();
               
                for (int i = 2; i < n; i++)
                    txt[i] = TxtBx[index][temp_TWDSno][i];
            }
        }

        public void done(int index, int TxtBxNo, Object[] text)
        {
            if (text[0].ToString() == "0")
                return;
            else if (text[0].ToString() == "1")
            {
                n = text.Count(s => s != null);
                Init(index);
            }
            TxtBx[index][Convert.ToInt32(text[0].ToString())] = new string[n];
            for (int i = 2; i < n; i++)
                TxtBx[index][Convert.ToInt32(text[0].ToString())][i] = text[i].ToString();            
        }
    }
   }

