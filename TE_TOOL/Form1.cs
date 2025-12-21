using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TE_TOOL;
using TE_TOOL.Models;
using TE_TOOL.Presenters;
using TE_TOOL.Services;
using TE_TOOL.ShowDialogForm;
using TE_TOOL.Views;
using TE_TOOL.Views._01_tab_loc_log;
using TE_TOOL.Views._02_tab_thu_thap_log;
using TE_TOOL.Views._03_tab_copy_ftu;

namespace hocWF
{


    public partial class Form1 : Form
    {
        private object selectedFilePath1;
        private object selectedFilePath2;

        private DateTime lastEditTime1 = DateTime.MinValue;
        private DateTime lastEditTime2 = DateTime.MinValue;
        private const int UNDO_GROUP_DELAY = 1000;

        private bool isSyncingScroll = false;
        private bool isSyncScroll = false;

        private string currentJsonFilePath = "";
        private Stack<string> undoStack1 = new Stack<string>();
        private Stack<string> undoStack2 = new Stack<string>();

        private bool isUndoing = false;
        private bool isHighlighting = false;

        private System.Windows.Forms.Timer debounceTimer1;
        private System.Windows.Forms.Timer debounceTimer2;
        private const int DEBOUNCE_DELAY = 1000;




        public string LocalDownLoadLogPath = "";
        public string MacFilePath = "";
        private string WinscpFilePath = "";

        private List<string> list_path_remote_or_local = new List<string>();

        // Tab Views
        private LocLogView locLogView;
        private LogCollectorView logCollectorView;
        private LocLogPresenter _locLogPresenter;
        private CopyFtuUserControl _copyFtuUserControl;
        private CopyFtuPresenter _copyFtuPresenter;

        // Add this field to the Form1 class
        private ILocLogView view;
        private IDialogOldFtuView _dialogOldFtuView;
        private ICopyFtuServices _copyFtuServices;



        public Form1()

        {
            InitializeComponent();
            InitializeTabViews();




            debounceTimer1 = new System.Windows.Forms.Timer();
            debounceTimer1.Interval = DEBOUNCE_DELAY;

            debounceTimer2 = new System.Windows.Forms.Timer();
            debounceTimer2.Interval = DEBOUNCE_DELAY;

            undoStack1.Push("");
            undoStack2.Push("");


            InitializeMVP();

        }

        private void InitializeMVP()
        {
            _dialogOldFtuView = new DialogOldFtuView();
            var service = new LocLogService();
            _locLogPresenter = new LocLogPresenter(view, service);
            _copyFtuServices = new CopyFtuServices();
            _copyFtuPresenter = new CopyFtuPresenter(_copyFtuUserControl, _dialogOldFtuView, _copyFtuServices);

        }

        private void InitializeTabViews()
        {

            locLogView = new LocLogView();
            {
                Dock = DockStyle.Fill;
            }
            ;
            tabPage3.Controls.Clear();
            tabPage3.Controls.Add(locLogView);

            view = locLogView;

            logCollectorView = new LogCollectorView();
            {
                Dock = DockStyle.Fill;
            }
            ;
            tabPage4.Controls.Clear();
            tabPage4.Controls.Add(logCollectorView);

            _copyFtuUserControl = new CopyFtuUserControl();
            {
                Dock = DockStyle.Fill;
            }
            ;
            tabPage2.Controls.Clear();
            tabPage2.Controls.Add(_copyFtuUserControl);

        }

































    }
}

