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
using TE_TOOL.Views._04_tab_get_cc_data;
using TE_TOOL.Views._05_tab_search_model_name;

namespace hocWF
{


    public partial class Form1 : Form
    {


        public string LocalDownLoadLogPath = "";
        public string MacFilePath = "";


        // Tab Views
        private LocLogView locLogView;
        private LogCollectorView logCollectorView;
        private GetAllTypeDataInLogUserControl getAllTypeDataInLogUserControl;



        private ViewSearchModelName viewSearchModelName;
        private LocLogPresenter _locLogPresenter;
        private CopyFtuUserControl _copyFtuUserControl;
        private CopyFtuPresenter _copyFtuPresenter;
        private GetDataByRegexPresenter _getDataByRegexPresenter;
        private SearchingToolPresenter _searchPresenter;


        // Add this field to the Form1 class
        private ILocLogView view;
        private IDialogOldFtuView _dialogOldFtuView;
        private ICopyFtuServices _copyFtuServices;
        private ISearchingService _searchingService;



        public Form1()

        {
            InitializeComponent();
            InitializeTabViews();
            setIcon();
            InitializeMVP();

        }

        private void setIcon()
        {
            try
            {
                this.Icon = new Icon("Resources\\exe.ico");
            }
            catch (Exception)
            {

                Debug.WriteLine("Icon not found");
            }
        }

        private void InitializeMVP()
        {
            _dialogOldFtuView = new DialogOldFtuView();
            var service = new LocLogService();
            _locLogPresenter = new LocLogPresenter(view, service);
            _copyFtuServices = new CopyFtuServices();
            _copyFtuPresenter = new CopyFtuPresenter(_copyFtuUserControl, _dialogOldFtuView, _copyFtuServices);
            _getDataByRegexPresenter = new GetDataByRegexPresenter(getAllTypeDataInLogUserControl, new GetAllTypeDataInLogService());

            _searchingService = new SearchingService();
            _searchPresenter = new SearchingToolPresenter(viewSearchModelName, _searchingService);
            _searchPresenter.LoadAllProducts();

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

            //tabpage5
            getAllTypeDataInLogUserControl = new GetAllTypeDataInLogUserControl();
            {
                Dock = DockStyle.Fill;
            }
            tabPage5.Controls.Clear();
            tabPage5.Controls.Add(getAllTypeDataInLogUserControl);

            //tabpage search model name
            viewSearchModelName = new ViewSearchModelName();
            {
                Dock = DockStyle.Fill;
            }
            tabPageSearch.Controls.Clear();
            tabPageSearch.Controls.Add(viewSearchModelName);

        }

    }
}

