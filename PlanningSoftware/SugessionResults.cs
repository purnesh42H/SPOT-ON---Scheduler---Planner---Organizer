using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient; //Namespace for mysql server.
using MySql.Data.Entity;
using System.IO;

namespace PlanningSoftware
{
    public partial class SugessionResults : Form
    {
        public static int Qty;
        public static DateTime custDate, enqDate, Form1_No;
        public static string Form1_CC, Form1_Item, Form1_Priority, Form1_SP, Form1_Group_Type,Form1_Tot,Form1_Range;
        public static string Form1_RawYes, Form1_RawPartl, Form1_RawNo, Form1_MulVisited, Form1_SingleVisited;
        public static string single;
        public static string multiple;
        public static bool MacDetailVisit;
        //Defining global variable to retrieve values from RawNo form
        public static int no_yes_quant;
        public static string no_yes_jnctn;
        public static int no_yes_wquant;
        public static int no_yes_balquant;
        public static string no_yes_arrival;
        public static int no_purch;
        public static int no_wip;
        public static int no_bal;

        //Defining global variable to retrieve values from RawYes form
        public static int yes_purch_quant;
        public static int yes_wip_quant;
        public static string yes_jnctn;
        public static int purch;
        public static int wip;


        //Defining global variable to retrieve values from Singlemachine form
        public static int wpb;
        public static int wps;
        public static int uspol;
        string MySql_ConnectionString;
        float[] NoOfDays;
        int[] AvgPrdn;
        int[][] Process_Details;
        int[][] Process_Details_Start;
        
        /*
            These are the variables that holds the suggestion results
         */
        string[] groups;
        double WP_B = 0, WP_S = 0, US_P = 0, WE_R = 0, V_DI = 0, DF = 0, PD = 0;
        double[] WPB, WPS, USP, WER, VDI, PKD, DISP;
        int qty, WPB_Slot, WER_Slot, WPS_Slot, USP_Slot, VDI_Slot, DF_Slot, PD_Slot;
        DateTime[] OrdEndWork;
        DateTime[] OrdStartWork;
        int[] Backlog_Days;
        int[] Ord_Days;
        int[] Group_Backlog;
        int Total_Suggestions;

        private void Load_Suggesstions()
        {
            PnlSugstn1.Visible = false;
            PnlSugstn2.Visible = false;
            PnlSugstn1.BackColor = Color.ForestGreen;
            PnlSugstn2.BackColor = Color.ForestGreen;

            if (RdBtnSngGrp.Checked == true) //If Single Group is selected
            {
                LblHeading.Text = "Single Group - Qty " + TxtBxQty.Text + " | Required on " + DTPCust.Value.ToLongDateString();
                groups = new string[2] { "RKT 2", "RKT 3" }; //List of Single Groups

                OrdEndWork = new DateTime[3];
                OrdStartWork = new DateTime[3];
                Backlog_Days = new int[3];
                Ord_Days = new int[3];
                Group_Backlog = new int[3];
                Process_Details = new int[2][];
                Process_Details_Start = new int[2][];
            }
            else if (RdBtnMulGrp.Checked == true) //If Multiple Group is selected
            {
                LblHeading.Text = "Multiple Group - Qty " + TxtBxQty.Text + " | Required on " + DTPCust.Value.ToLongDateString();
                groups = new string[1] { "Rkt 2 & 3" }; //List of Multiple Groups

                OrdEndWork = new DateTime[2];
                OrdStartWork = new DateTime[2];
                Backlog_Days = new int[2];
                Ord_Days = new int[2];
                Group_Backlog = new int[2];
                Process_Details = new int[1][];
                Process_Details_Start = new int[1][];
            }

            //Ticking the Groups in CheckListBox. These Groups are displayed
            for (int List_Index = 0; List_Index < ChkLstBxGrp.Items.Count; List_Index++)
            {
                for (int Grp_Index = 0; Grp_Index < groups.Length; Grp_Index++)
                {
                    if (groups[Grp_Index] == ChkLstBxGrp.Items[List_Index])
                        ChkLstBxGrp.SetItemChecked(List_Index, true);
                }
            }

            string query;
            int j = 0, k = 0, i = 0, H;
            Total_Suggestions = 0;
            DateTime today = DateTime.Now;
            DateTime StartWork;
            int[] hour = new int[3];
            for (i = 0; i < groups.Length; i++)
            {
                k = 0;
                j = 0;
                if (RdBtnSngGrp.Checked == true)
                    query = "SELECT WO, (WO/Avg_Prod) AS Days FROM backlogmaster.summtable natural join (SELECT sum(Bal_Acc) as WO, Group_Name FROM backlogmaster.wotable where group_name = '" + groups[i] + "' and Status = 'Undelivered') AS B";
                else
                    query = "SELECT WO, (WO/sum(distinct Avg_Prod)) AS Days FROM backlogmaster.summtable natural join (SELECT sum(Bal_Acc) as WO, Groups FROM backlogmaster.wotable where Groups = '" + groups[i] + "' and Status = 'Undelivered') AS B";

                GetNoOfDays(i, query, 0);

                //The decimal part of the number is the difference between itself and its integer part.
                hour[i] = (int)Math.Ceiling((NoOfDays[i]) * 9); //Multiply the decimal part with number of working hours to map the decimal to hour.                
                Backlog_Days[i] = (int)Math.Ceiling(NoOfDays[i]);
                if (Form1_RawNo == "1")
                {
                    NoOfDays[i] += Convert.ToInt32((Form1_No - today).TotalDays);
                }
                OrdStartWork[i] = today.AddDays(NoOfDays[i]);
                initial(i);
                H = shed_algo(i);
                int tot_hour = H;
                int days = tot_hour / 9;
                int hours = tot_hour % 9;
                if (hours == 0)
                    OrdEndWork[i] = OrdStartWork[i].AddDays(days);
                else
                    OrdEndWork[i] = OrdStartWork[i].AddDays(days + 1);
                Ord_Days[i] = Convert.ToInt32((OrdEndWork[i] - OrdStartWork[i]).TotalDays);
            }

            Total_Suggestions = i;
            Sort_By_End_Date();
            Print_Suggestions();
        }

        private int shed_algo(int Group_Index)
        {
            int H = 0, WPB_i = 1, WPS_i = 1, USP_i = 1, WER_i = 1, PD_i = 1, VDI_i = 1, DF_i = 1;
            double WPB_tot = 0, WPS_tot = 0, USP_tot = 0, WER_tot = 0, PD_tot = 0, VDI_tot = 0, DF_tot = 0;
            double WPB_tray_init = 0, WPS_tray_init = 0, USP_tray_init = 0, WER_tray_init = 0, PD_tray_init = 0, VDI_tray_init = 0, DF_tray_init = 0;
            double WPB_tray_resd = 0, WPS_tray_resd = 0, USP_tray_resd = 0, WER_tray_resd = 0, PD_tray_resd = 0, VDI_tray_resd = 0, DF_tray_resd = 0;
            double WPB_tray = 0, WPS_tray = 0, USP_tray = 0, WER_tray = 0, PD_tray = 0, VDI_tray = 0, DF_tray = 0;
            int WPS_flg1 = 0, WPS_flg2 = 0, USP_flg1 = 0, USP_flg2 = 0, WER_flg1 = 0, WER_flg2 = 0, PD_flg1 = 0, PD_flg2 = 0, VDI_flg1 = 0, VDI_flg2 = 0, DF_flg1 = 0, DF_flg2 = 0;
            double WPS_prev = 0, USP_prev = 0, WER_prev = 0, PD_prev = 0, VDI_prev = 0, DF_prev = 0;

            bool WP_B_Flag = false;
            bool WP_B_Slot_Flag = false, WP_S_Slot_Flag = false, US_P_Slot_Flag = false, WE_R_Slot_Flag = false, V_DI_Slot_Flag = false, PD_Slot_Flag = false, DF_Slot_Flag = false;
            bool WP_B_Slot_Flag_Start = false, WP_S_Slot_Flag_Start = false, US_P_Slot_Flag_Start = false, WE_R_Slot_Flag_Start = false, V_DI_Slot_Flag_Start = false, PD_Slot_Flag_Start = false, DF_Slot_Flag_Start = false;
            int Slot_Flag_Index = 0, Slot_Flag_Start_Index = 0;
            StreamWriter sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\Trace of " + groups[Group_Index] + ".htm");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><body>");

            Process_Details[Group_Index] = new int[7];
            Process_Details_Start[Group_Index] = new int[7];

            Process_Details_Start[Group_Index][Slot_Flag_Start_Index++] = H;

            while (PKD[PD_Slot] != 0)
            {
                H++;
                sb.AppendLine("<h3>At H = " + H.ToString() + ",</h3><br>");
                if (H != 1)
                {
                    if (DF_i > 1)
                    {
                        if (DISP[DF_i - 1] == 0)
                        {
                            if (PKD[PD_Slot] != 0)
                            {
                                if (PKD[PD_i] < DF_tray)
                                {
                                    if (PD_flg1 == 0)
                                    {
                                        PD_tot += PKD[PD_i];
                                        //PD_tray += PKD[PD_i] + PD_tray_resd;
                                        PD_tray_resd = 0;
                                    }
                                    else if (PD_flg2 == 1)
                                    {
                                        PD_tot += PD_prev;
                                        PD_tray += PD_prev + PD_tray_resd;
                                        PD_tray_resd = 0;
                                        PD_flg2 = 0;
                                    }
                                    //DF_tray -= PKD[PD_i];
                                    //PKD[PD_i++] = 0;
                                    DF_tray_init = DF_tray;
                                    while ((DF_tray_init - DF_tray) != PD && DF_tray != 0 && PD_i <= PD_Slot)
                                    {
                                        if (DF_tray < PKD[PD_i])
                                        {
                                            PKD[PD_i] -= DF_tray;
                                            if (PKD[PD_i] == 0)
                                                PD_tray += DF_tray;
                                            else
                                                PD_tray_resd = DF_tray;
                                            DF_tray = 0;
                                        }
                                        else if (DF_tray > PKD[PD_i])
                                        {
                                            DF_tray -= PKD[PD_i];
                                            DF_tray_resd = DF_tray;
                                            PD_tray += PKD[PD_i] + PD_tray_resd;
                                            PD_tray_resd = 0;
                                            PKD[PD_i++] = 0;
                                        }
                                        else
                                        {
                                            DF_tray = 0;
                                            PKD[PD_i++] = 0;
                                        }
                                    }
                                }
                                else if (PKD[PD_i] > DF_tray)
                                {
                                    if (PD_flg1 == 0)
                                    {
                                        PD_prev = PKD[PD_i];
                                        PD_flg1 = 1;
                                        PD_flg2 = 1;
                                    }
                                    if (DF_tray == 0 && DISP[DF_Slot] == 0)
                                    {
                                        DF_tray = PD;
                                        while (PKD[PD_i] < DF_tray && PD_i < PD_Slot)
                                        {
                                            DF_tray -= PKD[PD_i];
                                            PKD[PD_i++] = 0;
                                        }
                                        if (PKD[PD_i] > DF_tray)
                                            PKD[PD_i] -= DF_tray;
                                        else
                                            PKD[PD_i++] = 0;
                                    }
                                    else
                                        PKD[PD_i] -= DF_tray;
                                    DF_tray = 0;
                                }
                                else if (PKD[PD_i] == DF_tray)
                                {
                                    if (PD_flg2 == 0)
                                    {
                                        PD_tot += PD_prev;
                                        PD_tray = PD_prev + PD_tray_resd;
                                        PD_flg2 = 0;
                                    }
                                    else
                                        PD_tray = PKD[PD_i] + PD_tray_resd;
                                    PD_tray_resd = 0;
                                    PD_tot += PKD[PD_i];
                                    DF_tray = 0;
                                    PKD[PD_i++] = 0;
                                }
                            }
                        }
                    }
                    if (VDI_i > 1)
                    {
                        if (VDI[VDI_i - 1] == 0)
                        {
                            if (DISP[DF_Slot] != 0)
                            {
                                if (DISP[DF_i] < VDI_tray)
                                {
                                    if (DF_flg1 == 0)
                                    {
                                        DF_tot += DISP[DF_i];
                                        //DF_tray += DISP[DF_i] + DF_tray_resd;
                                        DF_tray_resd = 0;
                                    }
                                    else if (DF_flg2 == 1)
                                    {
                                        DF_tot += DF_prev;
                                        DF_tray += DF_prev + DF_tray_resd;
                                        DF_tray_resd = 0;
                                        DF_flg2 = 0;
                                    }
                                    //VDI_tray -= DISP[DF_i];
                                    //DISP[DF_i++] = 0;
                                    VDI_tray_init = VDI_tray;
                                    while ((VDI_tray_init - VDI_tray) != DF && VDI_tray != 0 && DF_i <= DF_Slot)
                                    {
                                        if (VDI_tray < DISP[DF_i])
                                        {
                                            DISP[DF_i] -= VDI_tray;
                                            if (DISP[DF_i] == 0)
                                                DF_tray += VDI_tray;
                                            else
                                                DF_tray_resd = VDI_tray;
                                            VDI_tray = 0;
                                        }
                                        else if (VDI_tray > DISP[DF_i])
                                        {
                                            VDI_tray -= DISP[DF_i];
                                            VDI_tray_resd = VDI_tray;
                                            DF_tray += DISP[DF_i] + DF_tray_resd;
                                            DF_tray_resd = 0;
                                            DISP[DF_i++] = 0;
                                        }
                                        else
                                        {
                                            VDI_tray = 0;
                                            DF_tray += DISP[DF_i] + DF_tray_resd;
                                            DF_tray_resd = 0;
                                            DISP[DF_i++] = 0;
                                        }
                                    }
                                }
                                else if (DISP[DF_i] > VDI_tray)
                                {
                                    if (DF_flg1 == 0)
                                    {
                                        DF_prev = DISP[DF_i];
                                        DF_flg1 = 1;
                                        DF_flg2 = 1;
                                    }
                                    if (VDI_tray == 0 && VDI[VDI_Slot] == 0)
                                    {
                                        VDI_tray = DF;
                                        while (DISP[DF_i] < VDI_tray && DF_i < DF_Slot)
                                        {
                                            VDI_tray -= DISP[DF_i];
                                            DISP[DF_i++] = 0;
                                        }
                                        if (DISP[DF_i] > VDI_tray)
                                            DISP[DF_i] -= VDI_tray;
                                        else
                                            DISP[DF_i++] = 0;
                                    }
                                    else
                                        DISP[DF_i] -= VDI_tray;
                                    VDI_tray = 0;
                                }
                                else if (DISP[DF_i] == VDI_tray)
                                {
                                    if (DF_flg2 == 1)
                                    {
                                        DF_tot += DF_prev;
                                        DF_tray = DF_prev + DF_tray_resd;
                                        DF_flg2 = 0;
                                    }
                                    else
                                        DF_tray = DISP[DF_i] + DF_tray_resd;
                                    DF_tray_resd = 0;
                                    DF_tot += DISP[DF_i];
                                    VDI_tray = 0;
                                    DISP[DF_i++] = 0;
                                }
                            }
                        }
                    }
                    if (WER_i > 1)
                    {
                        if (WER[WER_i - 1] == 0)
                        {
                            if (VDI[VDI_Slot] != 0)
                            {
                                if (VDI[VDI_i] < WER_tray)
                                {
                                    if (VDI_flg1 == 0)
                                    {
                                        VDI_tot += VDI[VDI_i];
                                        //VDI_tray += VDI[VDI_i] + VDI_tray_resd;
                                        VDI_tray_resd = 0;
                                    }
                                    else if (VDI_flg2 == 1)
                                    {
                                        VDI_tot += VDI_prev;
                                        VDI_tray += VDI_prev + VDI_tray_resd;
                                        VDI_tray_resd = 0;
                                        VDI_flg2 = 0;
                                    }
                                    //WER_tray -= VDI[VDI_i];
                                    //VDI[VDI_i++] = 0;
                                    WER_tray_init = WER_tray;
                                    while (WER_tray != 0 && (WER_tray_init - WER_tray) != V_DI && VDI_i <= VDI_Slot)
                                    {
                                        if (WER_tray < VDI[VDI_i])
                                        {
                                            VDI[VDI_i] -= WER_tray;
                                            if (VDI[VDI_i] == 0)
                                                VDI_tray += WER_tray;
                                            else
                                                VDI_tray_resd = WER_tray;
                                            WER_tray = 0;
                                        }
                                        else if (WER_tray > VDI[VDI_i])
                                        {
                                            WER_tray -= VDI[VDI_i];
                                            WER_tray_resd = WER_tray;
                                            VDI_tray += VDI[VDI_i] + VDI_tray_resd;
                                            VDI_tray_resd = 0;
                                            VDI[VDI_i++] = 0;
                                        }
                                        else
                                        {
                                            WER_tray = 0;
                                            VDI_tray += VDI[VDI_i] + VDI_tray_resd;
                                            VDI_tray_resd = 0;
                                            VDI[VDI_i++] = 0;
                                        }
                                    }
                                }
                                else if (VDI[VDI_i] > WER_tray)
                                {
                                    if (VDI_flg1 == 0)
                                    {
                                        VDI_prev = VDI[VDI_i];
                                        VDI_flg1 = 1;
                                        VDI_flg2 = 1;
                                    }
                                    if (WER_tray == 0 && WER[WER_Slot] == 0)
                                    {
                                        WER_tray = V_DI;
                                        while (VDI[VDI_i] < WER_tray && VDI_i < VDI_Slot)
                                        {
                                            WER_tray -= VDI[VDI_i];
                                            VDI[VDI_i++] = 0;
                                        }
                                        if (VDI[VDI_i] > WER_tray)
                                            VDI[VDI_i] -= WER_tray;
                                        else
                                            VDI[VDI_i++] = 0;
                                    }
                                    else
                                        VDI[VDI_i] -= WER_tray;
                                    WER_tray = 0;
                                }
                                else if (VDI[VDI_i] == WER_tray)
                                {
                                    if (VDI_flg2 == 1)
                                    {
                                        VDI_tot += VDI_prev;
                                        VDI_tray = VDI_tray_resd + VDI_prev;
                                        VDI_flg2 = 0;
                                    }
                                    else
                                        VDI_tray = VDI[VDI_i] + VDI_tray_resd;
                                    VDI_tray_resd = 0;
                                    VDI_tot += VDI[VDI_i];
                                    WER_tray = 0;
                                    VDI[VDI_i++] = 0;
                                }
                            }
                        }
                    }
                    if (USP_i > 1)
                    {
                        if (USP[USP_i - 1] == 0)
                        {
                            if (WER[WER_Slot] != 0)
                            {
                                if (WER[WER_i] < USP_tray)
                                {
                                    if (WER_flg1 == 0)
                                    {
                                        WER_tot += WER[WER_i];
                                        //WER_tray += WER[WER_i] + WER_tray_resd;
                                        WER_tray_resd = 0;
                                    }
                                    else if (WER_flg2 == 1)
                                    {
                                        WER_tot += WER_prev;
                                        WER_tray += WER_prev + WER_tray_resd;
                                        WER_tray_resd = 0;
                                        WER_flg2 = 0;
                                    }
                                    //USP_tray -= WER[WER_i];
                                    //WER[WER_i++] = 0;
                                    USP_tray_init = USP_tray;
                                    while (USP_tray != 0 && (USP_tray_init - USP_tray) != WE_R && WER_i <= WER_Slot)
                                    {
                                        if (USP_tray < WER[WER_i])
                                        {
                                            WER[WER_i] -= USP_tray;
                                            if (WER[WER_i] == 0)
                                                WER_tray += USP_tray;
                                            else
                                                WER_tray_resd = USP_tray;
                                            USP_tray = 0;
                                        }
                                        else if (USP_tray > WER[WER_i])
                                        {
                                            USP_tray -= WER[WER_i];
                                            USP_tray_resd = USP_tray;
                                            WER_tray += WER[WER_i] + WER_tray_resd;
                                            WER_tray_resd = 0;
                                            WER[WER_i++] = 0;
                                        }
                                        else
                                        {
                                            USP_tray = 0;
                                            WER_tray += WER[WER_i] + WER_tray_resd;
                                            WER_tray_resd = 0;
                                            WER[WER_i++] = 0;
                                        }
                                    }
                                }
                                else if (WER[WER_i] > USP_tray)
                                {
                                    if (WER_flg1 == 0)
                                    {
                                        WER_prev = WER[WER_i];
                                        WER_flg1 = 1;
                                        WER_flg2 = 1;
                                    }
                                    if (USP_tray == 0 && USP[USP_Slot] == 0)
                                    {
                                        USP_tray = WE_R;
                                        while (WER[WER_i] < USP_tray && WER_i < WER_Slot)
                                        {
                                            USP_tray -= WER[WER_i];
                                            WER[WER_i++] = 0;
                                        }
                                        if (WER[WER_i] > USP_tray)
                                            WER[WER_i] -= USP_tray;
                                        else
                                            WER[WER_i++] = 0;
                                    }
                                    else
                                        WER[WER_i] -= USP_tray;
                                    USP_tray = 0;
                                }
                                else if (WER[WER_i] == USP_tray)
                                {
                                    //if (WER_flg2 == 1)
                                    //{
                                    //    WER_tot += WER_prev;
                                    //    WER_tray += WER_prev;
                                    //    USP_tray -= WER[WER_i];
                                    //    WER[WER_i++] = 0;
                                    //    WER_flg2 = 0;
                                    //}
                                    //else
                                    if (WER_flg2 == 1)
                                    {
                                        WER_tot += WER_prev;
                                        WER_tray = WER_prev + WER_tray_resd;
                                        WER_flg2 = 0;
                                    }
                                    else
                                        WER_tray = WER[WER_i] + WER_tray_resd;
                                    WER_tray_resd = 0;
                                    WER_tot += WER[WER_i];
                                    USP_tray = 0;
                                    WER[WER_i++] = 0;
                                }
                            }
                        }
                    }
                    if (WPS_i > 1)
                    {
                        if (WPS[WPS_i - 1] == 0)
                        {
                            if (USP[USP_Slot] != 0)
                            {
                                if (USP[USP_i] < WPS_tray)
                                {
                                    if (USP_flg1 == 0)
                                    {
                                        USP_tot += USP[USP_i];
                                        //USP_tray += USP[USP_i] + USP_tray_resd;
                                        USP_tray_resd = 0;
                                    }
                                    else if (USP_flg2 == 1)
                                    {
                                        USP_tot += USP_prev;
                                        USP_tray += USP_prev + USP_tray_resd;
                                        USP_tray_resd = 0;
                                        USP_flg2 = 0;
                                    }
                                    //WPS_tray -= USP[USP_i];
                                    //USP[USP_i++] = 0;
                                    WPS_tray_init = WPS_tray;
                                    if (WPS_tray != 0 && (WPS_tray_init - WPS_tray) != US_P && USP_i <= USP_Slot)
                                    {
                                        if (WPS_tray < USP[USP_i])
                                        {
                                            USP[USP_i] -= WPS_tray;
                                            if (USP[USP_i] == 0)
                                                USP_tray += WPS_tray;
                                            else
                                                USP_tray_resd = WPS_tray;
                                            WPS_tray = 0;
                                        }
                                        else if (WPS_tray > USP[USP_i])
                                        {
                                            WPS_tray -= USP[USP_i];
                                            WPS_tray_resd = WPS_tray;
                                            USP_tray += USP[USP_i] + USP_tray_resd;
                                            USP_tray_resd = 0;
                                            USP[USP_i++] = 0;
                                        }
                                        else
                                        {
                                            WPS_tray = 0;
                                            USP_tray += USP[USP_i] = USP_tray_resd;
                                            USP_tray_resd = 0;
                                            USP[USP_i++] = 0;
                                        }
                                    }
                                }
                                else if (USP[USP_i] > WPS_tray)
                                {
                                    if (USP_flg1 == 0)
                                    {
                                        USP_prev = USP[USP_i];
                                        USP_flg1 = 1;
                                        USP_flg2 = 1;
                                    }
                                    if (WPS_tray == 0 && WPS[WPS_Slot] == 0)
                                    {
                                        WPS_tray = US_P;
                                        while (USP[USP_i] < WPS_tray && USP_i < USP_Slot)
                                        {
                                            WPS_tray -= USP[USP_i];
                                            USP[USP_i++] = 0;
                                        }
                                        if (USP[USP_i] > WPS_tray)
                                            USP[USP_i] -= WPS_tray;
                                        else
                                            USP[USP_i++] = 0;
                                    }
                                    else
                                        USP[USP_i] -= WPS_tray;
                                    WPS_tray = 0;
                                }
                                else if (USP[USP_i] == WPS_tray)
                                {
                                    if (USP_flg2 == 1)
                                    {
                                        USP_tot += USP_prev;
                                        USP_tray = USP_prev + USP_tray_resd;
                                        USP_flg2 = 0;
                                    }
                                    else
                                        USP_tray = USP[USP_i] + USP_tray_resd;
                                    USP_tray_resd = 0;
                                    USP_tot += USP[USP_i];
                                    WPS_tray = 0;
                                    USP[USP_i++] = 0;
                                }
                            }
                        }
                    }
                    if (WPB_i > 1)
                    {
                        if (WPB[WPB_i - 1] == 0)
                        {
                            if (WPS[WPS_Slot] != 0)
                            {
                                if (WPS[WPS_i] < WPB_tray)
                                {
                                    if (WPS_flg1 == 0)
                                    {
                                        WPS_tot += WPS[WPS_i];
                                        //WPS_tray += WPS[WPS_i] + WPS_tray_resd;
                                        WPS_tray_resd = 0;
                                    }
                                    else if (WPS_flg2 == 1)
                                    {
                                        WPS_tot += WPS_prev;
                                        WPS_tray += WPS_prev + WPS_tray_resd;
                                        WPS_tray_resd = 0;
                                        WPS_flg2 = 0;
                                    }
                                    //WPB_tray -= WPS[WPS_i];
                                    //WPS[WPS_i++] = 0;
                                    WPB_tray_init = WPB_tray;
                                    if (WPB_tray != 0 && (WPB_tray_init - WPB_tray) != WP_S && WPS_i <= WPS_Slot)
                                    {
                                        if (WPB_tray < WPS[WPS_i])
                                        {
                                            WPS[WPS_i] -= WPB_tray;
                                            WPS_tray += WPB_tray + WPS_tray_resd;
                                            WPS_tray_resd = 0;
                                            WPB_tray = 0;
                                        }
                                        else if (WPB_tray > WPS[WPS_i])
                                        {
                                            WPB_tray -= WPS[WPS_i];
                                            WPB_tray_resd = WPB_tray;
                                            WPS_tray += WPS[WPS_i] + WPS_tray_resd;
                                            WPS_tray_resd = 0;
                                            WPS[WPS_i++] = 0;
                                        }
                                        else
                                        {
                                            WPB_tray = 0;
                                            WPS_tray += WPS[WPS_i] + WPS_tray_resd;
                                            WPS_tray_resd = 0;
                                            WPS[WPS_i++] = 0;
                                        }
                                    }
                                }
                                else if (WPS[WPS_i] > WPB_tray)
                                {
                                    if (WPS_flg1 == 0)
                                    {
                                        WPS_prev = WPS[WPS_i];
                                        WPS_flg1 = 1;
                                        WPS_flg2 = 1;
                                    }
                                    if (WPB_tray == 0 && WPB[WPB_Slot] == 0)
                                    {
                                        WPB_tray = WP_S;
                                        while (WPS[WPS_i] < WPB_tray && WPS_i < WPS_Slot)
                                        {
                                            WPB_tray -= WPS[WPS_i];
                                            WPS[WPS_i++] = 0;
                                        }
                                        if (WPS[WPS_i] > WPB_tray)
                                            WPS[WPS_i] -= WPB_tray;
                                        else
                                        {
                                            WPS_tray = WPS[WPS_i];
                                            WPS[WPS_i++] = 0;
                                        }
                                    }
                                    else
                                        WPS[WPS_i] -= WPB_tray;
                                    WPB_tray = 0;
                                }
                                else if (WPS[WPS_i] == WPB_tray)
                                {
                                    if (WPS_flg2 == 1)
                                    {
                                        WPS_tot += WPS_prev;
                                        WPS_tray = WPS_prev + WPS_tray_resd;
                                        WPS_flg2 = 0;
                                    }
                                    else
                                        WPS_tray = WPS[WPS_i] + WPS_tray_resd;
                                    WPS_tray_resd = 0;
                                    WPS_tot += WPS[WPS_i];
                                    WPB_tray = 0;
                                    WPS[WPS_i++] = 0;
                                }
                            }
                        }
                    }
                }
                if (WPB[WPB_Slot] != 0)
                {
                    WPB_tot += WPB[WPB_i];
                    WPB_tray += WPB[WPB_i];
                    WPB[WPB_i++] = 0;
                }
                if (WPB[1] == 0 && WPB_i == 1)
                {
                    if (WP_B_Flag == false)
                    {
                        WPB_i = 2;
                        WP_B_Flag = true;
                    }
                }

                //End Time
                if (WP_B_Slot_Flag == false && WPB[WPB_Slot] == 0)
                {
                    WP_B_Slot_Flag = true;
                    Process_Details[Group_Index][Slot_Flag_Index++] = H;
                }
                if (WP_S_Slot_Flag == false && WPS[WPS_Slot] == 0)
                {
                    WP_S_Slot_Flag = true;
                    Process_Details[Group_Index][Slot_Flag_Index++] = H;
                }
                if (US_P_Slot_Flag == false && USP[USP_Slot] == 0)
                {
                    US_P_Slot_Flag = true;
                    Process_Details[Group_Index][Slot_Flag_Index++] = H;
                }
                if (WE_R_Slot_Flag == false && WER[WER_Slot] == 0)
                {
                    WE_R_Slot_Flag = true;
                    Process_Details[Group_Index][Slot_Flag_Index++] = H;
                }
                if (V_DI_Slot_Flag == false && VDI[VDI_Slot] == 0)
                {
                    V_DI_Slot_Flag = true;
                    Process_Details[Group_Index][Slot_Flag_Index++] = H;
                }
                if (PD_Slot_Flag == false && PKD[PD_Slot] == 0)
                {
                    PD_Slot_Flag = true;
                    Process_Details[Group_Index][Slot_Flag_Index++] = H;
                }

                //Start Time
                if (WP_B_Slot_Flag_Start == false && WPB[1] == 0)
                {
                    WP_B_Slot_Flag_Start = true;
                    Process_Details_Start[Group_Index][Slot_Flag_Start_Index++] = H;
                }
                if (WP_S_Slot_Flag_Start == false && WPS[1] == 0)
                {
                    WP_S_Slot_Flag_Start = true;
                    Process_Details_Start[Group_Index][Slot_Flag_Start_Index++] = H;
                }
                if (US_P_Slot_Flag_Start == false && USP[1] == 0)
                {
                    US_P_Slot_Flag_Start = true;
                    Process_Details_Start[Group_Index][Slot_Flag_Start_Index++] = H;
                }
                if (WE_R_Slot_Flag_Start == false && WER[1] == 0)
                {
                    WE_R_Slot_Flag_Start = true;
                    Process_Details_Start[Group_Index][Slot_Flag_Start_Index++] = H;
                }
                if (V_DI_Slot_Flag_Start == false && VDI[1] == 0)
                {
                    V_DI_Slot_Flag_Start = true;
                    Process_Details_Start[Group_Index][Slot_Flag_Start_Index++] = H;
                }
                if (PD_Slot_Flag_Start == false && PKD[1] == 0)
                {
                    PD_Slot_Flag_Start = true;
                    Process_Details_Start[Group_Index][Slot_Flag_Start_Index++] = H;
                }
                sb.AppendLine("<p>WP_B = {");
                for (int i = 1; i <= WPB_Slot; i++)
                    sb.AppendLine(WPB[i].ToString() + ",");
                sb.AppendLine("}</p>");
                sb.AppendLine("<p>WP_S = {");
                for (int i = 1; i <= WPS_Slot; i++)
                    sb.AppendLine(WPS[i].ToString() + ",");
                sb.AppendLine("}</p>");
                sb.AppendLine("<p>USP_P = {");
                for (int i = 1; i <= USP_Slot; i++)
                    sb.AppendLine(USP[i].ToString() + ",");
                sb.AppendLine("}</p>");
                sb.AppendLine("<p>WE_R = {");
                for (int i = 1; i <= WER_Slot; i++)
                    sb.AppendLine(WER[i].ToString() + ",");
                sb.AppendLine("}</p>");
                sb.AppendLine("<p>V_DI = {");
                for (int i = 1; i <= VDI_Slot; i++)
                    sb.AppendLine(VDI[i].ToString() + ",");
                sb.AppendLine("}</p>");
                sb.AppendLine("<p>PD = {");
                for (int i = 1; i <= DF_Slot; i++)
                    sb.AppendLine(DISP[i].ToString() + ",");
                sb.AppendLine("}</p>");
                sb.AppendLine("<p>DF = {");
                for (int i = 1; i <= PD_Slot; i++)
                    sb.AppendLine(PKD[i].ToString() + ",");
                sb.AppendLine("}</p><br>");
                //MessageBox.Show(sb.ToString());
            }
            //MessageBox.Show(sb.ToString());
            Process_Details[Group_Index][Slot_Flag_Index++] = H;
            sb.AppendLine("</body></html>");
            sw.Write(sb.ToString());
            sw.Close();
            return H;
        }

        private void initial(int Group_Index)
        {
            int WP_B_qty, WP_S_qty, US_P_qty, WE_R_qty, V_DI_qty, DF_qty, PD_qty;
            double rem;
            MySqlConnection MySqlConnectionObject = new MySqlConnection(); //Object to connect to mysql database.
            MySqlCommand MySqlCommandObject = new MySqlCommand(); //Object for mysql commands
            //try
            //{
            MySqlConnectionObject.ConnectionString = MySql_ConnectionString; //Assigning connection string
            MySqlConnectionObject.Open(); //Opening the connection to the database
            MySqlCommandObject.Connection = MySqlConnectionObject; //Giving the connection to the command object.                                     
            MySqlDataReader TempReaderObject;

            MySqlCommandObject.CommandText = "SELECT * FROM spot_on.junctionwiseoutputph where Blank_Type = '" + NextBack.TxtBx[0][1][2].ToString() + "' and Size_Range = '" + NextBack.TxtBx[0][1][3].ToString() + "'";
            TempReaderObject = MySqlCommandObject.ExecuteReader();
            int i = 0, j = 0;
            while (TempReaderObject.Read())
            {
                WP_B = TempReaderObject.GetFloat("WP_Bending");
                WP_S = TempReaderObject.GetFloat("WP_Straight");
                US_P = TempReaderObject.GetFloat("US_Polishing");
                WE_R = TempReaderObject.GetFloat("WE_Rework");
                V_DI = TempReaderObject.GetFloat("VD_Inspection");
                DF = TempReaderObject.GetFloat("Disp_Finish");
                PD = TempReaderObject.GetFloat("Disp_Packing");
            }
            if (RdBtnMulGrp.Checked)
            {
                TempReaderObject.Close(); //Close the Reader
                MySqlCommandObject.CommandText = "Select sum(WP_B_Machines), sum(WP_S_Machines), sum(US_Pol_Machines) from spot_on.machinedetails where Group_Involved = '" + groups[Group_Index] + "' group by Group_Involved";
                TempReaderObject = MySqlCommandObject.ExecuteReader();
                TempReaderObject.Read();
                WP_B = 2 * WP_B * TempReaderObject.GetInt32("sum(WP_B_Machines)");
                WP_S = 2 * WP_S * TempReaderObject.GetInt32("sum(WP_S_Machines)");
                US_P = 2 * US_P * TempReaderObject.GetInt32("sum(US_Pol_Machines)");
                WE_R = 2 * WE_R;
                V_DI = 2 * V_DI;
                DF = 2 * DF;
                PD = 2 * PD;
            }
            else
            {
                TempReaderObject.Close(); //Close the Reader
                MySqlCommandObject.CommandText = "Select sum(WP_B_Machines), sum(WP_S_Machines), sum(US_Pol_Machines) from spot_on.machinedetails where Group_Name = '" + groups[Group_Index] + "' group by Group_Name";
                TempReaderObject = MySqlCommandObject.ExecuteReader();
                TempReaderObject.Read();
                WP_B = WP_B * TempReaderObject.GetInt32("sum(WP_B_Machines)");
                WP_S = WP_S * TempReaderObject.GetInt32("sum(WP_S_Machines)");
                US_P = US_P * TempReaderObject.GetInt32("sum(US_Pol_Machines)");
            }
            TempReaderObject.Close(); //Close the Reader
            MySqlConnectionObject.Close(); //Close the connection to the database.

            qty = Convert.ToInt32(TxtBxQty.Text);
            DF_qty = qty;
            PD_qty = qty;
            V_DI_qty = qty;
            WE_R_qty = qty;
            US_P_qty = qty;
            WP_S_qty = qty;
            WP_B_qty = qty;

            if (Convert.ToInt32(yes_wip_quant) != 0)
            {
                switch (yes_jnctn)
                {
                    case "WP Bending":
                        WP_B_qty = qty - yes_wip_quant;
                        break;
                    case "WP Straight":
                        WP_S_qty = qty - yes_wip_quant;
                        WP_B_qty = qty - yes_wip_quant;
                        break;
                    case "US Polish":
                        US_P_qty = qty - yes_wip_quant;
                        WP_S_qty = qty - yes_wip_quant;
                        WP_B_qty = qty - yes_wip_quant;
                        break;
                    case "WE Rework":
                        WE_R_qty = qty - yes_wip_quant;
                        US_P_qty = qty - yes_wip_quant;
                        WP_S_qty = qty - yes_wip_quant;
                        WP_B_qty = qty - yes_wip_quant;
                        break;
                    case "VD Inspection":
                        V_DI_qty = qty - yes_wip_quant;
                        WE_R_qty = qty - yes_wip_quant;
                        US_P_qty = qty - yes_wip_quant;
                        WP_S_qty = qty - yes_wip_quant;
                        WP_B_qty = qty - yes_wip_quant;
                        break;
                    case "Disp Finish":
                        PD_qty = qty - yes_wip_quant;
                        V_DI_qty = qty - yes_wip_quant;
                        WE_R_qty = qty - yes_wip_quant;
                        US_P_qty = qty - yes_wip_quant;
                        WP_S_qty = qty - yes_wip_quant;
                        WP_B_qty = qty - yes_wip_quant;
                        break;
                    case "Disp Packing":
                        DF_qty = qty - yes_wip_quant;
                        PD_qty = qty - yes_wip_quant;
                        V_DI_qty = qty - yes_wip_quant;
                        WE_R_qty = qty - yes_wip_quant;
                        US_P_qty = qty - yes_wip_quant;
                        WP_S_qty = qty - yes_wip_quant;
                        WP_B_qty = qty - yes_wip_quant;
                        break;
                }
            }

            //Calculate the initial Array for WPB;
            if (WP_B == 0)
            {
                WPB = new double[2];
                WPB_Slot = 1;
                WPB[1] = 0.0;
            }
            else if (WP_B_qty >= WP_B)
            {
                rem = WP_B_qty % WP_B;
                WPB_Slot = (int)((WP_B_qty - (rem)) / WP_B);
                for (i = 1; i <= WPB_Slot; i++)
                {
                    if (i == 1)
                    {
                        if (rem == 0)
                            WPB = new double[WPB_Slot + 1];
                        else
                            WPB = new double[WPB_Slot + 2];
                    }
                    WPB[i] = WP_B;
                }
                if (rem != 0)
                {
                    WPB[i] = rem;
                    WPB_Slot += 1;
                }
            }
            else
            {
                WPB = new double[2];
                WPB_Slot = 1;
                WPB[1] = WP_B_qty;
            }
            //End of Calculation for WPB initial array
            //Calculate the initial Array for WPS;
            if (WP_S_qty >= WP_S)
            {
                rem = WP_S_qty % WP_S;
                WPS_Slot = (int)((WP_S_qty - (rem)) / WP_S);
                for (i = 1; i <= WPS_Slot; i++)
                {
                    if (i == 1)
                    {
                        if (rem == 0)
                            WPS = new double[WPS_Slot + 1];
                        else
                            WPS = new double[WPS_Slot + 2];
                    }
                    WPS[i] = WP_S;
                }
                if (rem != 0)
                {
                    WPS[i] = rem;
                    WPS_Slot += 1;
                }
            }
            else
            {
                WPS = new double[2];
                WPS_Slot = 1;
                WPS[1] = WP_S_qty;
            }
            //End of Calculation for WPS initial array
            //Calculate the initial Array for USP;
            if (US_P_qty >= US_P)
            {
                rem = US_P_qty % US_P;
                USP_Slot = (int)((US_P_qty - (rem)) / US_P);
                for (i = 1; i <= USP_Slot; i++)
                {
                    if (i == 1)
                    {
                        if (rem == 0)
                            USP = new double[USP_Slot + 1];
                        else
                            USP = new double[USP_Slot + 2];
                    }
                    USP[i] = US_P;
                }
                if (rem != 0)
                {
                    USP[i] = rem;
                    USP_Slot += 1;
                }
            }
            else
            {
                USP = new double[2];
                USP_Slot = 1;
                USP[1] = US_P_qty;
            }
            //End of Calculation for USP initial array
            //Calculate the initial Array for WER; 
            if (WE_R_qty >= WE_R)
            {
                rem = WE_R_qty % WE_R;
                WER_Slot = (int)((WE_R_qty - (rem)) / WE_R);
                for (i = 1; i <= WER_Slot; i++)
                {
                    if (i == 1)
                    {
                        if (rem == 0)
                            WER = new double[WER_Slot + 1];
                        else
                            WER = new double[WER_Slot + 2];
                    }
                    WER[i] = WE_R;
                }
                if (rem != 0)
                {
                    WER[i] = rem;
                    WER_Slot += 1;
                }
            }
            else
            {
                WER = new double[2];
                WER_Slot = 1;
                WER[1] = WE_R_qty;
            }
            //End of Calculation for WER initial array
            //Calculate the initial Array for VDI;
            if (V_DI_qty >= V_DI)
            {
                rem = V_DI_qty % V_DI;
                VDI_Slot = (int)((V_DI_qty - (rem)) / V_DI);
                for (i = 1; i <= VDI_Slot; i++)
                {
                    if (i == 1)
                    {
                        if (rem == 0)
                            VDI = new double[VDI_Slot + 1];
                        else
                            VDI = new double[VDI_Slot + 2];
                    }
                    VDI[i] = V_DI;
                }
                if (rem != 0)
                {
                    VDI[i] = rem;
                    VDI_Slot += 1;
                }
            }
            else
            {
                VDI = new double[2];
                VDI_Slot = 1;
                VDI[1] = V_DI_qty;
            }

            //End of Calculation for VDI initial array
            //Calculate the initial Array for PKD;

            if (PD_qty >= PD)
            {
                rem = PD_qty % PD;
                PD_Slot = (int)((PD_qty - (rem)) / PD);
                for (i = 1; i <= PD_Slot; i++)
                {
                    if (i == 1)
                    {
                        if (rem == 0)
                            PKD = new double[PD_Slot + 1];
                        else
                            PKD = new double[PD_Slot + 2];
                    }
                    PKD[i] = PD;
                }
                if (rem != 0)
                {
                    PKD[i] = rem;
                    PD_Slot += 1;
                }
            }
            else
            {
                PKD = new double[2];
                PD_Slot = 1;
                PKD[1] = PD_qty;
            }
            //End of Calculation for PKD initial array
            //Calculate the initial Array for DISP;

            if (DF_qty >= DF)
            {
                rem = DF_qty % DF;
                DF_Slot = (int)((DF_qty - (rem)) / DF);
                for (i = 1; i <= DF_Slot; i++)
                {
                    if (i == 1)
                    {
                        if (rem == 0)
                            DISP = new double[DF_Slot + 1];
                        else
                            DISP = new double[DF_Slot + 2];
                    }
                    DISP[i] = DF;
                }
                if (rem != 0)
                {
                    DISP[i] = rem;
                    DF_Slot += 1;
                }
            }
            else
            {
                DISP = new double[2];
                DF_Slot = 1;
                DISP[1] = DF_qty;
            }
            //End of Calculation for DISP initial array                            
        }

        private void Swap(int swap_index)
        {
            DateTime Temp_Date = OrdEndWork[swap_index];
            OrdEndWork[swap_index] = OrdEndWork[swap_index + 1];
            OrdEndWork[swap_index + 1] = Temp_Date;

            Temp_Date = OrdStartWork[swap_index];
            OrdStartWork[swap_index] = OrdStartWork[swap_index + 1];
            OrdStartWork[swap_index + 1] = Temp_Date;

            int Temp = Group_Backlog[swap_index];
            Group_Backlog[swap_index] = Group_Backlog[swap_index + 1];
            Group_Backlog[swap_index + 1] = Temp;

            Temp = Backlog_Days[swap_index];
            Backlog_Days[swap_index] = Backlog_Days[swap_index + 1];
            Backlog_Days[swap_index + 1] = Temp;

            Temp = Ord_Days[swap_index];
            Ord_Days[swap_index] = Ord_Days[swap_index + 1];
            Ord_Days[swap_index + 1] = Temp;

            string Temp_String = groups[swap_index];
            groups[swap_index] = groups[swap_index + 1];
            groups[swap_index + 1] = Temp_String;
        }

        private void Change_Panel_Color(int index)
        {
            switch (index)
            {
                case 0:
                    PnlSugstn1.BackColor = Color.Red;
                    break;  

                case 1:
                    PnlSugstn2.BackColor = Color.Red;
                    break;
            }
        }

        private void Print_Suggestions()
        {
            if (Total_Suggestions >= 0)
            {
                PnlSugstn1.Visible = true;
                LblGrp1.Text = groups[0];
                LblTotBckLg1.Text = Group_Backlog[0].ToString();
                LblDsReqFrBckLg1.Text = Backlog_Days[0].ToString();
                LblOrdStrAt1.Text = OrdStartWork[0].ToString("dd-MM-yyyy");
                LblDsReqFrOrd1.Text = Ord_Days[0].ToString();
                LblOrdEndAt1.Text = OrdEndWork[0].ToString("dd-MM-yyyy");
            }
            if (Total_Suggestions > 1)
            {
                PnlSugstn2.Visible = true;
               LblGrp2.Text = groups[1];
               LblTotBckLg2.Text = Group_Backlog[1].ToString();
               LblDsReqFrBckLg2.Text = Backlog_Days[1].ToString();
               LblOrdStrAt2.Text = OrdStartWork[1].ToString("dd-MM-yyyy");            
               LblDsReqFrOrd2.Text = Ord_Days[1].ToString();
               LblOrdEndAt2.Text = OrdEndWork[1].ToString("dd-MM-yyyy");
            }
        }

        private void Sort_By_End_Date()
        {
            for (int Date_Index = 0; Date_Index < Total_Suggestions; Date_Index++)
            {
                if (DateTime.Compare(OrdEndWork[Date_Index + 1], OrdEndWork[Date_Index]) < 0)
                {
                    if (Date_Index < Total_Suggestions - 1)
                        Swap(Date_Index);
                }

                if (DateTime.Compare(OrdEndWork[Date_Index], DTPCust.Value) > 0)
                {
                    Change_Panel_Color(Date_Index);
                }
            }
        }

        private void Sort_By_Order_Days()
        {
            for (int Ord_Days_Index = 0; Ord_Days_Index < Total_Suggestions; Ord_Days_Index++)
            {
                if (Ord_Days[Ord_Days_Index + 1] < Ord_Days[Ord_Days_Index])
                {
                    if (Ord_Days_Index < Total_Suggestions - 1)
                        Swap(Ord_Days_Index);
                }

                if (DateTime.Compare(OrdEndWork[Ord_Days_Index], DTPCust.Value) > 0)
                {
                    Change_Panel_Color(Ord_Days_Index);
                }
            }
        }

        private void Sort_By_Start_Date()
        {
            for (int Date_Index = 0; Date_Index < Total_Suggestions; Date_Index++)
            {
                if (DateTime.Compare(OrdStartWork[Date_Index + 1], OrdStartWork[Date_Index]) < 0)
                {
                    if (Date_Index < Total_Suggestions - 1)
                        Swap(Date_Index);
                }

                if (DateTime.Compare(OrdEndWork[Date_Index], DTPCust.Value) > 0)
                {
                    Change_Panel_Color(Date_Index);
                }
            }
        }

        private void Sort_By_Backlog_Days()
        {
            for (int Backlog_Days_Index = 0; Backlog_Days_Index < Total_Suggestions; Backlog_Days_Index++)
            {
                if (Backlog_Days[Backlog_Days_Index + 1] < Backlog_Days[Backlog_Days_Index])
                {
                    if (Backlog_Days_Index < Total_Suggestions - 1)
                        Swap(Backlog_Days_Index);
                }

                if (DateTime.Compare(OrdEndWork[Backlog_Days_Index], DTPCust.Value) > 0)
                {
                    Change_Panel_Color(Backlog_Days_Index);
                }
            }
        }

        private void Sort_By_Backlog()
        {
            for (int Group_Backlog_Index = 0; Group_Backlog_Index < Total_Suggestions; Group_Backlog_Index++)
            {
                if (Group_Backlog[Group_Backlog_Index + 1] < Group_Backlog[Group_Backlog_Index])
                {
                    if (Group_Backlog_Index < Total_Suggestions - 1)
                        Swap(Group_Backlog_Index);
                }

                if (DateTime.Compare(OrdEndWork[Group_Backlog_Index], DTPCust.Value) > 0)
                {
                    Change_Panel_Color(Group_Backlog_Index);
                }
            }
        }

        private void GetNoOfDays(int index, string query, int Flg)
        {
            MySqlConnection MySqlConnectionObject = new MySqlConnection(); //Object to connect to mysql database.
            MySqlCommand MySqlCommandObject = new MySqlCommand(); //Object for mysql commands
            try
            {
                MySqlConnectionObject.ConnectionString = MySql_ConnectionString; //Assigning connection string
                MySqlConnectionObject.Open(); //Opening the connection to the database
                MySqlCommandObject.Connection = MySqlConnectionObject; //Giving the connection to the command object.                                     
                MySqlDataReader TempReaderObject;
                MySqlCommandObject.CommandText = query;
                TempReaderObject = MySqlCommandObject.ExecuteReader();
                int i = 0, j = 0;
                
                if (Flg == 1)
                {
                    TempReaderObject.Read();
                    while (i < TempReaderObject.FieldCount)
                    {
                        NoOfDays[j++] = Convert.ToInt32(TempReaderObject[i++].ToString());
                    }
                    TempReaderObject.Close();
                }
                else
                {
                    if (TempReaderObject.Read())
                    {
                        NoOfDays[index] = TempReaderObject.GetFloat("Days");
                        Group_Backlog[index] = TempReaderObject.GetInt32("WO");
                    }
                    else
                    {
                        NoOfDays[index] = 0;
                    }
                }
                
                MySqlConnectionObject.Close(); //Close the connection to the database.
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public SugessionResults()
        {
            InitializeComponent();
            MySql_ConnectionString = "datasource=localhost;port=3306;username=root;password=root";
            NoOfDays = new float[20];
            AvgPrdn = new int[20];
        }

        private void SugessionResults_Load(object sender, EventArgs e)
        {
            ChkLstBxGrp.Items.Clear();
            if (Form1_Group_Type == "Single" || single == "yes")
            {
                RdBtnSngGrp.Checked = true;
                ChkLstBxGrp.Items.Add("Rkt 2 & 3");
            }
            else 
            {
                RdBtnMulGrp.Checked = true;
                ChkLstBxGrp.Items.Add("RKT 2");
                ChkLstBxGrp.Items.Add("RKT 3");
            }
            TxtBxQty.Text = Qty.ToString();
            DTPCust.Text = custDate.ToString();
            Load_Suggesstions();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Load_Suggesstions();
        }

        private void LnkLblOrdEndsAt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PnlSugstn1.BackColor = Color.ForestGreen;
            PnlSugstn2.BackColor = Color.ForestGreen;

            Sort_By_End_Date();
        }

        private void LnkLblDsReqFrOrd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PnlSugstn1.BackColor = Color.ForestGreen;
            PnlSugstn2.BackColor = Color.ForestGreen;

            Sort_By_Order_Days();
        }

        private void LnkLblOrdStrtAt_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PnlSugstn1.BackColor = Color.ForestGreen;
            PnlSugstn2.BackColor = Color.ForestGreen;

            Sort_By_Start_Date();
        }

        private void LnkLblDsReqBckLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PnlSugstn1.BackColor = Color.ForestGreen;
            PnlSugstn2.BackColor = Color.ForestGreen;
            Sort_By_Backlog_Days();
        }

        private void LnkLblTotBckLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PnlSugstn1.BackColor = Color.ForestGreen;
            PnlSugstn2.BackColor = Color.ForestGreen;

            Sort_By_Backlog();
        }

        private void RdBtnSngGrp_CheckedChanged(object sender, EventArgs e)
        {
            ChkLstBxGrp.Items.Clear();
            if (RdBtnSngGrp.Checked == true)
            {
                ChkLstBxGrp.Items.Add("RKT 2");
                ChkLstBxGrp.Items.Add("RKT 3");
            }
        }

        private void RdBtnMulGrp_CheckedChanged(object sender, EventArgs e)
        {
            ChkLstBxGrp.Items.Clear();
            if (RdBtnMulGrp.Checked == true)
            {
                ChkLstBxGrp.Items.Add("Rkt 2 & 3");
            }
        }

        private void BtnBook1_Click(object sender, EventArgs e)
        {
            custDate = DTPCust.Value;
            Qty = Convert.ToInt32(TxtBxQty.Text);
            Order or = new Order();
            Order.Booked_Group = groups[0];
            or.Order_Entry_Flag = true;
            if (SugessionResults.purch == 1)
            {
                
                Order.purch = 1;
            }
            if (SugessionResults.wip == 1)
            {
                Order.wip = 1;
            }

            if (SugessionResults.no_purch == 1)
            {
                Order.no_purch = 1;
            }
            if (SugessionResults.no_wip == 1)
            {
                Order.no_wip = 1;
            }
            if (SugessionResults.no_bal == 1)
            {
                Order.no_bal = 1;
            }

            if (SugessionResults.Form1_RawYes == "1")
            {
                Order.RawYes = "1";
            }
            else 
            {
                Order.RawYes = "0";
            }
            if (SugessionResults.Form1_RawPartl == "1")
            {
                Order.RawPartl = "1";
            }
            if (SugessionResults.Form1_MulVisited == "1")
            {
                Order.MulVisitedReturn = "1";
            }
            if (SugessionResults.MacDetailVisit== true)
            {
                Order.MachDetailReturn= true;
            }
            if (SugessionResults.Form1_SingleVisited == "1")
            {
                Order.SingleVisitedReturn = "1";
            }
            if (SugessionResults.Form1_RawNo== "1")
            {
                Order.RawNoDetail = "1";
            }
              
            if (RdBtnSngGrp.Checked == true)
                Form1_Group_Type = "Single";
            else
                Form1_Group_Type = "Multiple";
            or.Show();
        }

        private void BtnBook2_Click(object sender, EventArgs e)
        {
            custDate = DTPCust.Value;
            Qty = Convert.ToInt32(TxtBxQty.Text);
            Order or = new Order();
            Order.Booked_Group = groups[1];
            or.Order_Entry_Flag = true;
            if (SugessionResults.purch == 1)
            {

                Order.purch = 1;
            }
            if (SugessionResults.wip == 1)
            {
                Order.wip = 1;
            }

            if (SugessionResults.no_purch == 1)
            {
                Order.no_purch = 1;
            }
            if (SugessionResults.no_wip == 1)
            {
                Order.no_wip = 1;
            }
            if (SugessionResults.no_bal == 1)
            {
                Order.no_bal = 1;
            }

            if (SugessionResults.Form1_RawYes == "1")
            {
                Order.RawYes = "1";
            }
            else
            {
                Order.RawYes = "0";
            }
            if (SugessionResults.Form1_RawPartl == "1")
            {
                Order.RawPartl = "1";
            }
            if (SugessionResults.Form1_MulVisited == "1")
            {
                Order.MulVisitedReturn = "1";
            }
            if (SugessionResults.MacDetailVisit == true)
            {
                Order.MachDetailReturn = true;
            }
            if (SugessionResults.Form1_SingleVisited == "1")
            {
                Order.SingleVisitedReturn = "1";
            }
            if (SugessionResults.Form1_RawNo == "1")
            {
                Order.RawNoDetail = "1";
            }
            
            
            if (RdBtnSngGrp.Checked == true)
                Form1_Group_Type = "Single";
            else
                Form1_Group_Type = "Multiple";
            or.Close();
            or.Show();
        }

        private void ChkSmrtSearch_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSmrtSearch.Checked)
            {
                if (PnlSugstn1.BackColor == Color.Red)
                {
                    PnlSugstn1.Visible = false;
                }
                if (PnlSugstn2.BackColor == Color.Red)
                {
                    PnlSugstn2.Visible = false;
                }
            }
            else
            {
                if (RdBtnSngGrp.Checked)
                {
                    PnlSugstn1.Visible = true;
                    PnlSugstn2.Visible = true;
                }
                else
                {
                    PnlSugstn1.Visible = true;
                }
            }
        }

        private void BtnMngOrder_Click(object sender, EventArgs e)
        {
            Manage m = new Manage();
            m.Show();
        }

        private void BtnMngOrdr_Click(object sender, EventArgs e)
        {
            Alter_Order ao = new Alter_Order();
            ao.Show();
        }

        private void LnkLblFlDtl1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StringBuilder P_Detail_Sb = new StringBuilder();
            P_Detail_Sb.AppendLine("<html><body><h1>Process Details</h2>");
            P_Detail_Sb.AppendLine("<br><table border = '1'>");
            P_Detail_Sb.AppendLine("<tr><th>Process</th><th>Start Hour</th><th>End Hour</th></tr>");
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    P_Detail_Sb.AppendLine("<tr><td>WP Bending</td><td>" + Process_Details_Start[0][i] + "</td><td>" + Process_Details[0][i] + "</td></tr>");
                }
                else if (i == 1)
                {
                    P_Detail_Sb.AppendLine("<tr><td>WP Straight</td><td>" + Process_Details_Start[0][i] + "</td><td>" + Process_Details[0][i] + "</td></tr>");
                }
                if (i == 2)
                {
                    P_Detail_Sb.AppendLine("<tr><td>USPolishing</td><td>" + Process_Details_Start[0][i] + "</td><td>" + Process_Details[0][i] + "</td></tr>");
                }
                if (i == 3)
                {
                    P_Detail_Sb.AppendLine("<tr><td>WE Rework</td><td>" + Process_Details_Start[0][i] + "</td><td>" + Process_Details[0][i] + "</td></tr>");
                }
                if (i == 4)
                {
                    P_Detail_Sb.AppendLine("<tr><td>VD Inspection</td><td>" + Process_Details_Start[0][i] + "</td><td>" + Process_Details[0][i] + "</td></tr>");
                }
                if (i == 5)
                {
                    P_Detail_Sb.AppendLine("<tr><td>Packaging Dispatch</td><td>" + Process_Details_Start[0][i] + "</td><td>" + Process_Details[0][i] + "</td></tr>");
                }
                if (i == 6)
                {
                    P_Detail_Sb.AppendLine("<tr><td>Dispatch Finish</td><td>" + Process_Details_Start[0][i] + "</td><td>" + Process_Details[0][i] + "</td></tr>");
                }
            }
            P_Detail_Sb.AppendLine("/<table></body></html>");
            Viewer v = new Viewer();
            Viewer.Sugession_Str = P_Detail_Sb.ToString();
            v.Show();
        }

        private void LnkLblFlDtl2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StringBuilder P_Detail_Sb = new StringBuilder();
            P_Detail_Sb.AppendLine("<html><body><h1>Process Details</h2>");
            P_Detail_Sb.AppendLine("<br><table border = '1'>");
            P_Detail_Sb.AppendLine("<tr><th>Process</th><th>Start Hour</th><th>End Hour</th></tr>");
            for (int i = 0; i < 7; i++)
            {
                if (i == 0)
                {
                    P_Detail_Sb.AppendLine("<tr><td>WP Bending</td><td>" + Process_Details_Start[1][i] + "</td><td>" + Process_Details[1][i] + "</td></tr>");
                }
                else if (i == 1)
                {
                    P_Detail_Sb.AppendLine("<tr><td>WP Straight</td><td>" + Process_Details_Start[1][i] + "</td><td>" + Process_Details[1][i] + "</td></tr>");
                }
                if (i == 2)
                {
                    P_Detail_Sb.AppendLine("<tr><td>USPolishing</td><td>" + Process_Details_Start[1][i] + "</td><td>" + Process_Details[1][i] + "</td></tr>");
                }
                if (i == 3)
                {
                    P_Detail_Sb.AppendLine("<tr><td>WE Rework</td><td>" + Process_Details_Start[1][i] + "</td><td>" + Process_Details[1][i] + "</td></tr>");
                }
                if (i == 4)
                {
                    P_Detail_Sb.AppendLine("<tr><td>VD Inspection</td><td>" + Process_Details_Start[1][i] + "</td><td>" + Process_Details[1][i] + "</td></tr>");
                }
                if (i == 5)
                {
                    P_Detail_Sb.AppendLine("<tr><td>Packaging Dispatch</td><td>" + Process_Details_Start[1][i] + "</td><td>" + Process_Details[1][i] + "</td></tr>");
                }
                if (i == 6)
                {
                    P_Detail_Sb.AppendLine("<tr><td>Dispatch Finish</td><td>" + Process_Details_Start[1][i] + "</td><td>" + Process_Details[1][i] + "</td></tr>");
                }
            }
            P_Detail_Sb.AppendLine("/<table></body></html>");
            Viewer v = new Viewer();
            Viewer.Sugession_Str = P_Detail_Sb.ToString();
            v.Show();
        }
    }
}
