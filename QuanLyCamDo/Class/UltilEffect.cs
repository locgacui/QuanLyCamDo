using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using DevExpress.XtraSplashScreen;
using QuanLyCamDo.Form;

namespace QuanLyCamDo.Class
{
    public static class UltilEffect
    {
        public static void f_Show_WaitForm()
        {
            if (SplashScreenManager.Default == null)
            {
                SplashScreenManager.ShowForm(typeof(WaitForm1));
            }
        }

        public static void f_Close_WaitForm()
        {
            if (SplashScreenManager.Default != null)
            {
                SplashScreenManager.CloseForm();
            }
        }
    }
}


