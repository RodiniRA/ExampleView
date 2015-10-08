using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.ObjectModel;
using AmTrustExample.Models;
using System.Windows.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using AmTrustExample.Command;
using AmTrustExample.UserControls;
using AmTrustExample.Extensions;
using System.Data;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro;

namespace AmTrustExample.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region "Privates"

        private ObservableCollection<RibbonButton> _testButtons = null;
        private ObservableCollection<RibbonButton> _testQuickAccessButtons = null;

        //HOME
        private ObservableCollection<Button> _policySystemButtons = null;
        private ObservableCollection<Button> _reportingSystemButtons = null;
        private ObservableCollection<Button> _accountingSystemButtons = null;
        private ObservableCollection<Button> _miscButtons = null;
        private ObservableCollection<Button> _daybookButtons = null;
        private ObservableCollection<Button> _specialtyRiskButtons = null;
        private ObservableCollection<Button> _medicalMalpracticeButtons = null;
        private ObservableCollection<Button> _ccpButtons = null;
        private ObservableCollection<Button> _processingFileButtons = null;

        //UNDERWRITING
        private ObservableCollection<Button> _underwritingButtons = null;

        //AUDIT
        private ObservableCollection<Button> _auditButtons = null;

        //PROCESSING
        private ObservableCollection<Button> _processingButtons = null;

        public List<AccentColorMenuData> AccentColors { get; set; }
        public List<AppThemeMenuData> AppThemes { get; set; }
        private string _testHeader = "I am a test header. HIIII!!!! I want to be longer, so here are some more words. wheeeee!";

        private DataTable _dt = null;
        private DataRowView _selectedItem = null;

        private ICommand _windowLoaded;

        private ICommand _showMessageTest;
        private ICommand _changeNaviWidth;

        #endregion

        #region "Properties"

        public ObservableCollection<RibbonButton> TestButtons
        {
            get
            {
                if (_testButtons == null)
                {
                    _testButtons = new ObservableCollection<RibbonButton>();
                    for (int i = 0; i < 3; i++)
                    {
                        var b = new RibbonButton();
                        b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                        b.ToolTip = "Testing RibbonButton UserControl";

                        b.ContextMenu = new ContextMenu();
                        var mItem = new MenuItem();
                        mItem.Header = "Add to Quick Access Bar";
                        mItem.Click += (s, e) => MoveToQuickAccessBar(b, e);
                        b.ContextMenu.Items.Add(mItem);
                        _testButtons.Add(b);
                        b.Click += (s, e) => MessageBox.Show("You done clicked me");
                    }
                }
                return _testButtons;
            }
        }

        public ObservableCollection<RibbonButton> TestQuickAccessButtons
        {
            get
            {
                if (_testQuickAccessButtons == null)
                {
                    _testQuickAccessButtons = new ObservableCollection<RibbonButton>();
                    for (int i = 0; i < 3; i++)
                    {
                        var b = new RibbonButton();
                        b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                        b.ToolTip = "Testing RibbonButton UserControl";

                        b.ContextMenu = new ContextMenu();
                        var mItem = new MenuItem();
                        mItem.Header = "Remove from Quick Access Bar";
                        mItem.Click += (s, e) => RemoveFromQuickAccessBar(b, e);
                        b.ContextMenu.Items.Add(mItem);

                        _testQuickAccessButtons.Add(b);
                    }
                }
                return _testQuickAccessButtons;
            }
        }

        public string TestHeader
        {
            get { return _testHeader; }
            set { _testHeader = value; }
        }

        #region "ICommands"
        public ICommand WindowLoaded
        {
            get { return _windowLoaded; }
            set
            {
                _windowLoaded = value;
                OnPropertyChanged("WindowLoaded");
            }
        }

        public ICommand ShowMessageTest
        {
            get { return _showMessageTest; }
            set
            {
                _showMessageTest = value;
                OnPropertyChanged("ShowMessageTest");
            }
        }

        public ICommand ChangeNaviWidth
        {
            get { return _changeNaviWidth; }
            set
            {
                _changeNaviWidth = value;
                OnPropertyChanged("ChangeNaviWidth");
            }
        }
        #endregion

        #region "HOME"
        public ObservableCollection<Button> PolicySystemButtons
        {
            get
            {
                if (_policySystemButtons == null)
                {
                    _policySystemButtons = new ObservableCollection<Button>();

                    var b = new Button();
                    b.Name = "btnWC";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Workers Comp", ButtonGroup.PolicySystems.GetDescription(), "Opens Workers Comp System", "/AmTrustExample;component/Images/testImage.jpg");
                    b.Command = ShowMessageTest;
                    _policySystemButtons.Add(b);
                    b = new Button();
                    b.Name = "btnCPP";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("CPP", ButtonGroup.PolicySystems.GetDescription(), "Opens CPP System", "/AmTrustExample;component/Images/testImage.jpg");
                    _policySystemButtons.Add(b);
                    b = new Button();
                    b.Name = "btnSystemX";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("System X", ButtonGroup.PolicySystems.GetDescription(), "Opens GMAC System", "/AmTrustExample;component/Images/testImage.jpg");
                    _policySystemButtons.Add(b);
                    b = new Button();
                    b.Name = "btnClaims";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Claims", ButtonGroup.PolicySystems.GetDescription(), "Takes you to the claims ana menus", "/AmTrustExample;component/Images/testImage.jpg");
                    _policySystemButtons.Add(b);
                    b = new Button();
                    b.Name = "btnDL";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Disability Liability", ButtonGroup.PolicySystems.GetDescription(), "Opens the Disability Liability System", "/AmTrustExample;component/Images/testImage.jpg");
                    _policySystemButtons.Add(b);
                }
                return _policySystemButtons;
            }
        }

        public ObservableCollection<Button> ReportingSystemButtons
        {
            get
            {
                if (_reportingSystemButtons == null)
                {
                    _reportingSystemButtons = new ObservableCollection<Button>();

                    var b = new Button();
                    b.Name = "btnANAReporting";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("ANA Reporting", ButtonGroup.ReportingSystems.GetDescription(), "Go to your personal ANA Reporting Dashboard.", "/AmTrustExample;component/Images/testImage.jpg");
                    _reportingSystemButtons.Add(b);
                    b = new Button();
                    b.Name = "btnOldDataSVCS";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("DataSVCS", ButtonGroup.ReportingSystems.GetDescription(), "Takes you to Data Services Reporting.", "/AmTrustExample;component/Images/testImage.jpg");
                    _reportingSystemButtons.Add(b);
                    b = new Button();
                    b.Name = "btnDataSVCS";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("DataSVCS 2", ButtonGroup.ReportingSystems.GetDescription(), "Takes you to Data Services Reporting.", "/AmTrustExample;component/Images/testImage.jpg");
                    _reportingSystemButtons.Add(b);
                    b = new Button();
                    b.Name = "btnSSRSReports";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Reporting Services", ButtonGroup.ReportingSystems.GetDescription(), "Takes you to Reporting Services.", "/AmTrustExample;component/Images/testImage.jpg");
                    _reportingSystemButtons.Add(b);
                }
                return _reportingSystemButtons;
            }
        }

        public ObservableCollection<Button> AccountingSystemButtons
        {
            get
            {
                if (_accountingSystemButtons == null)
                {
                    _accountingSystemButtons = new ObservableCollection<Button>();

                    var b = new Button();
                    b.Name = "btnAccounting";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Accounting", ButtonGroup.AccountingSystems.GetDescription(), "Accounting System", "/AmTrustExample;component/Images/testImage.jpg");
                    _accountingSystemButtons.Add(b);
                    b = new Button();
                    b.Name = "btnCollections";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Collections", ButtonGroup.AccountingSystems.GetDescription(), "Collections System", "/AmTrustExample;component/Images/testImage.jpg");
                    _accountingSystemButtons.Add(b);
                    b = new Button();
                    b.Name = "btnMSAPayments";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("MSA/PAYO", ButtonGroup.AccountingSystems.GetDescription(), "MSA Payment Transaction History", "/AmTrustExample;component/Images/testImage.jpg");
                    _accountingSystemButtons.Add(b);
                    b = new Button();
                    b.Name = "btnEFTSubmissions";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("EFT Submissions", ButtonGroup.AccountingSystems.GetDescription(), "EFT Submissions", "/AmTrustExample;component/Images/testImage.jpg");
                    _accountingSystemButtons.Add(b);
                    b = new Button();
                    b.Name = "btnDLPaymentDetails";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("DL Payment Details", ButtonGroup.AccountingSystems.GetDescription(), "DL Payment Details", "/AmTrustExample;component/Images/testImage.jpg");
                    _accountingSystemButtons.Add(b);
                }
                return _accountingSystemButtons;
            }
        }

        public ObservableCollection<Button> MiscButtons
        {
            get
            {
                if (_miscButtons == null)
                {
                    _miscButtons = new ObservableCollection<Button>();

                    var dropDownButton = new AmTrustExample.UserControls.DropDownButton();
                    dropDownButton.DropDownContextMenu = new ContextMenu();
                    dropDownButton.Name = "btnQuery";
                    dropDownButton.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    dropDownButton.ToolTip = CreateDetailTooltip("Query", ButtonGroup.Misc.GetDescription(), "Provides document and agent information.", "/AmTrustExample;component/Images/testImage.jpg");
                    _miscButtons.Add(dropDownButton);
                    //add the drop-down items here
                    var mi = new MenuItem();
                    mi.Name = "btnQueryAgentInfo";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Agent Info";
                    mi.ToolTip = CreateDetailTooltip("Agent Info", ButtonGroup.Misc.GetDescription(), "OBTAIN AGENT INFORMATION.  ALSO, CHANGE WEB LOGON INFO.", "/AmTrustExample;component/Images/testImage.jpg");
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnQueryDocumentInfo";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Document Info";
                    mi.ToolTip = CreateDetailTooltip("Document Info", ButtonGroup.Misc.GetDescription(), "DISPLAYS ALL SETUP INFORMATION ASSOCIATED WITH DOCUMENT", "/AmTrustExample;component/Images/testImage.jpg");
                    dropDownButton.DropDownContextMenu.Items.Add(mi);

                    var b = new Button();
                    b.Name = "btnANAProducers";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Producers", ButtonGroup.Misc.GetDescription(), "Opens ANA Producers system.", "/AmTrustExample;component/Images/testImage.jpg");
                    _miscButtons.Add(b);
                    b = new Button();
                    b.Name = "btnKnowledgebase";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Knowledgebase", ButtonGroup.Misc.GetDescription(), "A general Knowledge base for AmTrust.", "/AmTrustExample;component/Images/testImage.jpg");
                    _miscButtons.Add(b);
                    b = new Button();
                    b.Name = "btnPrintStatus";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Print Status", ButtonGroup.Misc.GetDescription(), "View Print Status", "/AmTrustExample;component/Images/testImage.jpg");
                    _miscButtons.Add(b);
                    b = new Button();
                    b.Name = "btnDMVResubmit";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("DMV Resubmit", ButtonGroup.Misc.GetDescription(), "Opens DMV Resubmit", "/AmTrustExample;component/Images/testImage.jpg");
                    _miscButtons.Add(b);
                    b = new Button();
                    b.Name = "btnOwnCloud";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("ownCloud", ButtonGroup.Misc.GetDescription(), "Opens OwnCloud", "/AmTrustExample;component/Images/testImage.jpg");
                    _miscButtons.Add(b);
                }
                return _miscButtons;
            }
        }

        public ObservableCollection<Button> DaybookButtons
        {
            get
            {
                if (_daybookButtons == null)
                {
                    _daybookButtons = new ObservableCollection<Button>();

                    var b = new Button();
                    b.Name = "btnDayBook";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("E&S Daybook", ButtonGroup.Daybook.GetDescription(), "Opens E&S Daybook", "/AmTrustExample;component/Images/testImage.jpg");
                    _daybookButtons.Add(b);
                    b = new Button();
                    b.Name = "btnMorningBook";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("UW Daybook", ButtonGroup.Daybook.GetDescription(), "Opens UW Daybook", "/AmTrustExample;component/Images/testImage.jpg");
                    _daybookButtons.Add(b);
                    b = new Button();
                    b.Name = "btnInsideSalesDaybook";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Sales Daybook", ButtonGroup.Daybook.GetDescription(), "Navigates you to the Inside Sales DayBook web page.", "/AmTrustExample;component/Images/testImage.jpg");
                    _daybookButtons.Add(b);
                }
                return _daybookButtons;
            }
        }

        public ObservableCollection<Button> SpecialtyRiskButtons
        {
            get
            {
                if (_specialtyRiskButtons == null)
                {
                    _specialtyRiskButtons = new ObservableCollection<Button>();

                    var b = new Button();
                    b.Name = "btnSR";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("SRMS", ButtonGroup.SpecialtyRisk.GetDescription(), "Opens Dealer Quote Setup", "/AmTrustExample;component/Images/testImage.jpg");
                    _specialtyRiskButtons.Add(b);
                    b = new Button();
                    b.Name = "btnSREurope";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("SRMS Europe", ButtonGroup.SpecialtyRisk.GetDescription(), "Opens RAF Setup", "/AmTrustExample;component/Images/testImage.jpg");
                    _specialtyRiskButtons.Add(b);
                    b = new Button();
                    b.Name = "btnSREDIBreakdown";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("EDI Breakdown", ButtonGroup.SpecialtyRisk.GetDescription(), "Takes the user to the EDI Breakdown website.", "/AmTrustExample;component/Images/testImage.jpg");
                    _specialtyRiskButtons.Add(b);
                    b = new Button();
                    b.Name = "btnSRClaimsDublin";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Dublin Claims", ButtonGroup.SpecialtyRisk.GetDescription(), "Opens Dublin Claims", "/AmTrustExample;component/Images/testImage.jpg");
                    _specialtyRiskButtons.Add(b);
                    b = new Button();
                    b.Name = "btnSRRAFClaims";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("RAF Claims", ButtonGroup.SpecialtyRisk.GetDescription(), "Opens RAF Claims", "/AmTrustExample;component/Images/testImage.jpg");
                    _specialtyRiskButtons.Add(b);
                    b = new Button();
                    b.Name = "btnSRAELRAF";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("AEL RAF", ButtonGroup.SpecialtyRisk.GetDescription(), "AEL RAF", "/AmTrustExample;component/Images/testImage.jpg");
                    _specialtyRiskButtons.Add(b);
                    b = new Button();
                    b.Name = "btnSRAdminInfo";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Admin Tool", ButtonGroup.SpecialtyRisk.GetDescription(), "Admin Tool", "/AmTrustExample;component/Images/testImage.jpg");
                    _specialtyRiskButtons.Add(b);
                }
                return _specialtyRiskButtons;
            }
        }

        public ObservableCollection<Button> MedicalMalpracticeButtons
        {
            get
            {
                if (_medicalMalpracticeButtons == null)
                {
                    _medicalMalpracticeButtons = new ObservableCollection<Button>();

                    var b = new Button();
                    b.Name = "btnNewClaimSetup";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("New Claim Setup", ButtonGroup.MedicalMalpractice.GetDescription(), "Opens New Claim Setup", "/AmTrustExample;component/Images/testImage.jpg");
                    _medicalMalpracticeButtons.Add(b);
                    b = new Button();
                    b.Name = "btnMedMal";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("MedMal Policy", ButtonGroup.MedicalMalpractice.GetDescription(), "Opens the Medical Malpractice", "/AmTrustExample;component/Images/testImage.jpg");
                    _medicalMalpracticeButtons.Add(b);
                    b = new Button();
                    b.Name = "btnManagerModule";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Manager Module", ButtonGroup.MedicalMalpractice.GetDescription(), "Link to the Manager Module site.", "/AmTrustExample;component/Images/testImage.jpg");
                    _medicalMalpracticeButtons.Add(b);
                    b = new Button();
                    b.Name = "btnInvoicing";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("PlayBook", ButtonGroup.MedicalMalpractice.GetDescription(), "Opens the PlayBook", "/AmTrustExample;component/Images/testImage.jpg");
                    _medicalMalpracticeButtons.Add(b);
                    b = new Button();
                    b.Name = "btnSRAccounting";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("SR Accounting", ButtonGroup.MedicalMalpractice.GetDescription(), "Opens SR Accounting", "/AmTrustExample;component/Images/testImage.jpg");
                    _medicalMalpracticeButtons.Add(b);
                    b = new Button();
                    b.Name = "btnCashAllocation";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Cash Allocation", ButtonGroup.MedicalMalpractice.GetDescription(), "Opens Cash Allocation", "/AmTrustExample;component/Images/testImage.jpg");
                    _medicalMalpracticeButtons.Add(b);
                    b = new Button();
                    b.Name = "btnRemittAllocation";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Remittance Allocation", ButtonGroup.MedicalMalpractice.GetDescription(), "Opens Remittance Allocation", "/AmTrustExample;component/Images/testImage.jpg");
                    _medicalMalpracticeButtons.Add(b);
                    b = new Button();
                    b.Name = "btnBrokerAccounts";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Broker Accounts", ButtonGroup.MedicalMalpractice.GetDescription(), "Opens Broker Accounts", "/AmTrustExample;component/Images/testImage.jpg");
                    _medicalMalpracticeButtons.Add(b);
                    b = new Button();
                    b.Name = "btnActuarialTables";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Actuarial Tables", ButtonGroup.MedicalMalpractice.GetDescription(), "Opens Actuarial Tables", "/AmTrustExample;component/Images/testImage.jpg");
                    _medicalMalpracticeButtons.Add(b);
                    b = new Button();
                    b.Name = "btnMedMalDaybook";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("MedMal Daybook", ButtonGroup.MedicalMalpractice.GetDescription(), "Opens the MedMal Daybook", "/AmTrustExample;component/Images/testImage.jpg");
                    _medicalMalpracticeButtons.Add(b);
                }
                return _medicalMalpracticeButtons;
            }
        }

        public ObservableCollection<Button> CcpButtons
        {
            get
            {
                if (_ccpButtons == null)
                {
                    _ccpButtons = new ObservableCollection<Button>();

                    var b = new Button();
                    b.Name = "btnCCPVSCClaims";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("CCP Claims", ButtonGroup.CCP.GetDescription(), "Opens CCP Claims", "/AmTrustExample;component/Images/testImage.jpg");
                    _ccpButtons.Add(b);
                    b = new Button();
                    b.Name = "btnCCPVSCPolicy";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("CCP Policy", ButtonGroup.CCP.GetDescription(), "Opens CCP Policy", "/AmTrustExample;component/Images/testImage.jpg");
                    _ccpButtons.Add(b);
                    b = new Button();
                    b.Name = "btnCCPVSCAdmin";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("CCP Admin", ButtonGroup.CCP.GetDescription(), "Opens CCP Admin", "/AmTrustExample;component/Images/testImage.jpg");
                    _ccpButtons.Add(b);
                }
                return _ccpButtons;
            }
        }

        public ObservableCollection<Button> ProcessingFileButtons
        {
            get
            {
                if (_processingFileButtons == null)
                {
                    _processingFileButtons = new ObservableCollection<Button>();

                    var b = new Button();
                    b.Name = "btnProcess";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Process", ButtonGroup.ProcessingAFile.GetDescription(), "Process", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingFileButtons.Add(b);

                    var dropDownButton = new AmTrustExample.UserControls.DropDownButton();
                    dropDownButton.DropDownContextMenu = new ContextMenu();
                    dropDownButton.Name = "btnSetUp";
                    dropDownButton.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    dropDownButton.ToolTip = CreateDetailTooltip("SetUp", ButtonGroup.ProcessingAFile.GetDescription(), "Multiple tools for file setup and indexing.", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingFileButtons.Add(dropDownButton);
                    //add the drop-down items here
                    var mi = new MenuItem();
                    mi.Name = "btnSetUpWCUnderwritingDocument";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "WC Underwriting Document";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpWCAuditDocument";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "WC Audit Document";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpWCPolicyChange";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "WC Policy Change";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpCPPUnderwritingDocument";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "CPP Underwriting Document";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpCPPAuditDocument";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "CPP Audit Document";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpCPPPolicyChange";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "CPP Policy Change";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpAgentDocument";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Agent Document";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpChangeAgent";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Change Agent";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpCreateNewMasterAccount";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Create New Master Account";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpWCIndexPLDocument";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Index PL Document";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpIndexClaimDocument";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Index Claim Document";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpIndexMedDocument";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Index MedMal Document";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpProducerReIndex";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Producer Re-Index";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpIndexSREBDXDocument";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Index SRE BDX Document";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnSetUpIndexDLDocument";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Index DL Document";
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                }
                return _processingFileButtons;
            }
        }
        #endregion

        #region "UNDERWRITING"
        public ObservableCollection<Button> UnderwritingButtons
        {
            get
            {
                if (_underwritingButtons == null)
                {
                    _underwritingButtons = new ObservableCollection<Button>();

                    var dropDownButton = new AmTrustExample.UserControls.DropDownButton();
                    dropDownButton.DropDownContextMenu = new ContextMenu();
                    dropDownButton.Name = "btnUWResponses";
                    dropDownButton.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    dropDownButton.ToolTip = CreateDetailTooltip("UW Responses", ButtonGroup.Underwriting.GetDescription(), "", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(dropDownButton);
                    //add the drop-down items here
                    var mi = new MenuItem();
                    mi.Name = "btnUnderwritingQuote";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Quote";
                    mi.ToolTip = CreateDetailTooltip("Quote", ButtonGroup.Underwriting.GetDescription(), "UNDERWRITE THE ACCOUNT", "/AmTrustExample;component/Images/testImage.jpg");
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnUnderwritingDecline";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Decline";
                    mi.ToolTip = CreateDetailTooltip("Decline", ButtonGroup.Underwriting.GetDescription(), "SEND A DECLINATION LETTER", "/AmTrustExample;component/Images/testImage.jpg");
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnUnderwritingADDInto";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Additional Information";
                    mi.ToolTip = CreateDetailTooltip("Additional Information", ButtonGroup.Underwriting.GetDescription(), "REQUEST ADDITIOAL INFORMATION", "/AmTrustExample;component/Images/testImage.jpg");
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnUnderwritingBindPending";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Bind Pending";
                    mi.ToolTip = CreateDetailTooltip("Bind Pending", ButtonGroup.Underwriting.GetDescription(), "", "/AmTrustExample;component/Images/testImage.jpg");
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnUnderwritingGeneral";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "General";
                    mi.ToolTip = CreateDetailTooltip("General", ButtonGroup.Underwriting.GetDescription(), "GENERAL RESPONSE TO AGENT", "/AmTrustExample;component/Images/testImage.jpg");
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnUnderwritingNonRenew";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Non Renew";
                    mi.ToolTip = CreateDetailTooltip("Non Renew", ButtonGroup.Underwriting.GetDescription(), "BIND THE VISIBLE UNDERWRITING FILE. ONLY AIIS RENEWALS", "/AmTrustExample;component/Images/testImage.jpg");
                    dropDownButton.DropDownContextMenu.Items.Add(mi);

                    var b = new Button();
                    b.Name = "btnUnderwritingAttachandOpen";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Attach and Open", ButtonGroup.Underwriting.GetDescription(), "FIND THE UNDERWRITING DOC, ATTACH AND OPEN. ONLY WORKS FOR DOCS INDEXED AS ADDITIONAL INFO.", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingUnderwrite";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Underwrite", ButtonGroup.Underwriting.GetDescription(), "UNDERWRITE THE ACCOUNT", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingUWLater";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("UW Later", ButtonGroup.Underwriting.GetDescription(), "SEND DOCUMENT TO UNDERWRITE LATER FOLDER", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingLossSurveyStatus";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Loss Survey Status", ButtonGroup.Underwriting.GetDescription(), "VIEW CURRENT STATUS OF ALL LOSS CONTROL SURVEYS REQUESTED", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingRate";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Rate", ButtonGroup.Underwriting.GetDescription(), "RATE", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingLossRun";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Loss Run", ButtonGroup.Underwriting.GetDescription(), "GENERATE A LOSS RUN FOR THE CURRENT DOC!", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingViewQuote";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("View Quote", ButtonGroup.Underwriting.GetDescription(), "VIEW QUOTE", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingSendReferral";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Send Referral", ButtonGroup.Underwriting.GetDescription(), "SEND REFERRAL", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingLossPick";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Loss Pick", ButtonGroup.Underwriting.GetDescription(), "CREATE, VIEW AND EDIT A LOSS PICK FOR THE CURRENT ACCOUNT", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingMovePolicyToChangeReview";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Move Policy To Change Review", ButtonGroup.Underwriting.GetDescription(), "Moves Current Viewable document To the Policy Change Review Bin", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingDividend";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Dividend", ButtonGroup.Underwriting.GetDescription(), "Approve/Disapprove a Dividend", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingRenew";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Renew", ButtonGroup.Underwriting.GetDescription(), "Renew this Renewal, and send to Clearinghouse", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingRenewalCheckout";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Renewal Checkout", ButtonGroup.Underwriting.GetDescription(), "Move the Renewal Document to your Inbox", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingAIISBind";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("AIIS Bind", ButtonGroup.Underwriting.GetDescription(), "BIND THE VISIBLE UNDERWRITING FILE. ONLY AIIS RENEWALS", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnUnderwritingQuoteNotTaken";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Quote Not Taken", ButtonGroup.Underwriting.GetDescription(), "QUOTE NOT TAKEN", "/AmTrustExample;component/Images/testImage.jpg");
                    _underwritingButtons.Add(b);
                }
                return _underwritingButtons;
            }
        }
        #endregion

        #region "AUDIT"
        public ObservableCollection<Button> AuditButtons
        {
            get
            {
                if (_auditButtons == null)
                {
                    _auditButtons = new ObservableCollection<Button>();

                    var dropDownButton = new AmTrustExample.UserControls.DropDownButton();
                    dropDownButton.DropDownContextMenu = new ContextMenu();
                    dropDownButton.Name = "btnAuditLetters";
                    dropDownButton.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    dropDownButton.ToolTip = CreateDetailTooltip("Letters", ButtonGroup.Audit.GetDescription(), "", "/AmTrustExample;component/Images/testImage.jpg");
                    _auditButtons.Add(dropDownButton);
                    //add the drop-down items here
                    var mi = new MenuItem();
                    mi.Name = "btnAuditBCTLetter";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "BCT Letter";
                    mi.ToolTip = CreateDetailTooltip("BCT Letter", ButtonGroup.Underwriting.GetDescription(), "", "/AmTrustExample;component/Images/testImage.jpg");
                    dropDownButton.DropDownContextMenu.Items.Add(mi);

                    var b = new Button();
                    b.Name = "btnAuditAddressIssue";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Address Issue", ButtonGroup.Audit.GetDescription(), "Address Issue", "/AmTrustExample;component/Images/testImage.jpg");
                    _auditButtons.Add(b);
                    b = new Button();
                    b.Name = "btnAuditSingle";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Single", ButtonGroup.Audit.GetDescription(), "Takes you to the claims ana menus", "/AmTrustExample;component/Images/testImage.jpg");
                    _auditButtons.Add(b);
                    b = new Button();
                    b.Name = "btnAuditReturn";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Return", ButtonGroup.Audit.GetDescription(), "VOLUNTARY AUDIT RETURN LETTER", "/AmTrustExample;component/Images/testImage.jpg");
                    _auditButtons.Add(b);
                    b = new Button();
                    b.Name = "btnAuditIndexAPA";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("IndexAPA", ButtonGroup.Audit.GetDescription(), "CHANGES THE FILE TYPE OF THE ACTIVE DOC TO APA.", "/AmTrustExample;component/Images/testImage.jpg");
                    _auditButtons.Add(b);
                    b = new Button();
                    b.Name = "btnAuditRequestPhysicalAudit";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Request Physical Audit", ButtonGroup.Audit.GetDescription(), "REQUEST A PREMIUM AUDIT ON THIS POLICY.", "/AmTrustExample;component/Images/testImage.jpg");
                    _auditButtons.Add(b);
                    b = new Button();
                    b.Name = "btnAuditExclusions";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Exclusions", ButtonGroup.Audit.GetDescription(), "Exclusions", "/AmTrustExample;component/Images/testImage.jpg");
                    _auditButtons.Add(b);
                    b = new Button();
                    b.Name = "btnAuditConCreditFL";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Con Credit FL", ButtonGroup.Audit.GetDescription(), "Con Credit FL", "/AmTrustExample;component/Images/testImage.jpg");
                    _auditButtons.Add(b);
                    b = new Button();
                    b.Name = "btnAuditPANJ";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("PANJ", ButtonGroup.Audit.GetDescription(), "PANJ", "/AmTrustExample;component/Images/testImage.jpg");
                    _auditButtons.Add(b);
                    b = new Button();
                    b.Name = "btnAuditDisputeDenial";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Dispute Denial", ButtonGroup.Audit.GetDescription(), "Dispute Denial", "/AmTrustExample;component/Images/testImage.jpg");
                    _auditButtons.Add(b);
                    b = new Button();
                    b.Name = "btnAuditPremiumAudit";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Premium Audit", ButtonGroup.Audit.GetDescription(), "FINAL PREMIUM AUDITS", "/AmTrustExample;component/Images/testImage.jpg");
                    _auditButtons.Add(b);
                }
                return _auditButtons;
            }
        }
        #endregion

        #region "Processing"
        public ObservableCollection<Button> ProcessingButtons
        {
            get
            {
                if (_processingButtons == null)
                {
                    _processingButtons = new ObservableCollection<Button>();

                    var dropDownButton = new AmTrustExample.UserControls.DropDownButton();
                    dropDownButton.DropDownContextMenu = new ContextMenu();
                    dropDownButton.Name = "btnProcessingLetters";
                    dropDownButton.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    dropDownButton.ToolTip = CreateDetailTooltip("Letters", ButtonGroup.Processing.GetDescription(), "Letters", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(dropDownButton);
                    //add the drop-down items here
                    var mi = new MenuItem();
                    mi.Name = "btnProcessingReturnMail";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "Return Mail";
                    mi.ToolTip = CreateDetailTooltip("Return Mail", ButtonGroup.Processing.GetDescription(), "Return Mail", "/AmTrustExample;component/Images/testImage.jpg");
                    dropDownButton.DropDownContextMenu.Items.Add(mi);
                    mi = new MenuItem();
                    mi.Name = "btnProcessingBCTLetter";
                    mi.Icon = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    mi.Header = "BCT Letter";
                    mi.ToolTip = CreateDetailTooltip("BCT Letter", ButtonGroup.Processing.GetDescription(), "BCT Letter", "/AmTrustExample;component/Images/testImage.jpg");
                    dropDownButton.DropDownContextMenu.Items.Add(mi);

                    var b = new Button();
                    b.Name = "btnProcessingReinstate";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Reinstate", ButtonGroup.Processing.GetDescription(), "REINSTATEMENTS", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnProcessingIssue";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Issue", ButtonGroup.Processing.GetDescription(), "SEND AN ACCOUNT TO BE ISSUED", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnProcessingNonPremiumEndorsement";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Non Premium Endorsement", ButtonGroup.Processing.GetDescription(), "NON PREMIUM ENDORSEMENT", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnProcessingPremiumEndorsement";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Premium Endorsement", ButtonGroup.Processing.GetDescription(), "PREMIUM BEARING ENDORSEMENT", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnProcessingCancel";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Cancel", ButtonGroup.Processing.GetDescription(), "CANCEL", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnProcessingBureauCrit";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Bureau Crit", ButtonGroup.Processing.GetDescription(), "BUREAU CRIT", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnProcessingPEOIssuance";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("PEO Issuance", ButtonGroup.Processing.GetDescription(), "Sends files to PEO Issuance processing folder.", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnProcessingFirstCardinal";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("First Cardinal", ButtonGroup.Processing.GetDescription(), "First Cardinal", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnProcessingNonRenew";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Non Renew", ButtonGroup.Processing.GetDescription(), "NON-RENEWALS", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnProcessingEmod";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Emod", ButtonGroup.Processing.GetDescription(), "Emod", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnProcessingEmodManager";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Emod Manager", ButtonGroup.Processing.GetDescription(), "Emod Manager", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                    b = new Button();
                    b.Name = "btnProcessingRenewalIssuance";
                    b.Content = new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
                    b.ToolTip = CreateDetailTooltip("Renewal Issuance", ButtonGroup.Processing.GetDescription(), "Renewal Issuance", "/AmTrustExample;component/Images/testImage.jpg");
                    _processingButtons.Add(b);
                }
                return _processingButtons;
            }
        }
        #endregion

        public DataTable Dt
        {
            get
            {
                if (_dt == null)
                {
                    _dt = new DataTable();

                    _dt.Columns.Add(new DataColumn("Animal", typeof(String)));
                    _dt.Columns.Add(new DataColumn("Food", typeof(String)));
                    _dt.Columns.Add(new DataColumn("Color", typeof(String)));
                    _dt.Columns.Add(new DataColumn("Shape", typeof(String)));
                    _dt.Columns.Add(new DataColumn("TV Show", typeof(String)));
                    _dt.Columns.Add(new DataColumn("Beverage", typeof(String)));

                    for (int i = 0; i < 5; i++)
                    {
                        _dt.Rows.Add("Cat", "Sandwich", "Red", "Square", "Bones", "Soda");
                        _dt.Rows.Add("Dog", "Pancakes", "Orange", "Circle", "Law & Order", "Iced Tea");
                        _dt.Rows.Add("Mouse", "Turkey", "Yellow", "Triangle", "Monk", "Water");
                        _dt.Rows.Add("Bear", "Spaghetti", "Green", "Rectangle", "The League", "Milkshake");
                        _dt.Rows.Add("Squirel", "Lasagna", "Blue", "Pentagon", "X-Files", "Lemonade");
                        _dt.Rows.Add("Fox", "Roast Pork", "Indigo", "Rhombus", "American Dad", "Milk");
                        _dt.Rows.Add("Narwhal", "Cookies", "Violet", "Octogon", "Whose Line is it Anyway", "Coffee");
                    }
                }
                return _dt;
            }
        }

        public DataRowView SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
            }
        }

        #endregion

        #region "Enums"
        private enum ButtonGroup
        {
            [Description("Policy Systems")]
            PolicySystems = 0,
            [Description("Reporting Systems")]
            ReportingSystems,
            [Description("Accounting Systems")]
            AccountingSystems,
            [Description("Misc")]
            Misc,
            [Description("Daybook")]
            Daybook,
            [Description("Specialty Risk")]
            SpecialtyRisk,
            [Description("Medical Malpractice")]
            MedicalMalpractice,
            [Description("CCP")]
            CCP,
            [Description("Processing a file")]
            ProcessingAFile,
            [Description("Underwriting")]
            Underwriting,
            [Description("Audit")]
            Audit,
            [Description("Processing")]
            Processing
        }
        #endregion

        #region "Constructor"
        public MainViewModel()
        {
            WindowLoaded = new ActionCommand(e => OnWindowLoaded());
            ShowMessageTest = new ActionCommand(e => ShowMessage());

            LoadCustomAccents();

            LoadCustomThemes();
            this.AppThemes = ThemeManager.AppThemes.Select(a => new AppThemeMenuData() { Name = a.Name, BorderColorBrush = a.Resources["BlackColorBrush"] as Brush, ColorBrush = a.Resources["WhiteColorBrush"] as Brush }).ToList();
        }

        private void LoadCustomAccents()
        {
            //Hacky way to ensure that our custom accents are used, and not the default MahApp ones
            var amTrustColors = new[] {
                    "Blue ", "Dark ", "Emerald ", "Crimson ", "GummiBear ", "Orange ", "Amber ", "Brown ", "Cyan ", "Green ", "Indigo ", "Lime ", "Magenta ", "Mauve ", "Olive ", "Pink ",
                    "Purple ", "Red ", "Sienna ", "Steel ", "Taupe ", "Teal ", "Violet ", "Yellow "
                };
            this.AccentColors = new List<AccentColorMenuData>();

            foreach (var color in amTrustColors)
            {
                var amTrustResourceAddress = (new Uri(string.Format("pack://application:,,,/AmTrustExample;component/Styles/Accents/{0}.xaml", color)));
                ThemeManager.AddAccent(color, amTrustResourceAddress);
                var accent = ThemeManager.GetAccent(color);
                this.AccentColors.Add(new AccentColorMenuData { Name = color, ColorBrush = accent.Resources["AccentColorBrush"] as Brush });
            }

        }

        private void LoadCustomThemes()
        {
            var amTrustThemes = new[] { "BaseRed", "BaseBlue", "BasePink" };

            foreach (var color in amTrustThemes)
            {
                var resourceAddress = (new Uri(string.Format("pack://application:,,,/AmTrustExample;component/Styles/Accents/{0}.xaml", color)));
                ThemeManager.AddAppTheme(color, resourceAddress);
            }
        }
        #endregion

        #region "Events"
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region "Methods"
        private void OnWindowLoaded()
        {
            //Will always start off blue until user's accent/theme is loaded in login
            // get the theme from the current application
            var theme = ThemeManager.DetectAppStyle(Application.Current);

            // Default accent
            ThemeManager.ChangeAppStyle(Application.Current,
                                    ThemeManager.GetAccent("Blue "),
                                    ThemeManager.DetectAppStyle().Item1);


            OnLogin();
        }

        private async void OnLogin()
        {
            var metroWindow = (Application.Current.MainWindow as MetroWindow);
            metroWindow.MetroDialogOptions.ColorScheme = MetroDialogColorScheme.Accented;
            LoginDialogData result = await metroWindow.ShowLoginAsync("Authentication", "Enter your credentials", new LoginDialogSettings { ColorScheme = MetroDialogColorScheme.Inverted, PasswordWatermark = "Password", UsernameWatermark = "UserName" });

            if (result == null)
            {
                //User pressed cancel
                //Except there is no cancel in this case
            }
        }

        private async void ShowMessage()
        {
            var metroWindow = (Application.Current.MainWindow as MetroWindow);
            // This demo runs on .Net 4.0, but we're using the Microsoft.Bcl.Async package so we have async/await support
            // The package is only used by the demo and not a dependency of the library!
            var mySettings = new MetroDialogSettings()
            {
                ColorScheme = metroWindow.MetroDialogOptions.ColorScheme
            };

            MessageDialogResult result = await metroWindow.ShowMessageAsync("Wokers Comp", "You clicked the Workers Comp button!",
                MessageDialogStyle.AffirmativeAndNegative, mySettings);
        }

        private Grid CreateDetailTooltip(string header, string ribbonGroupName, string text, string uri = "")
        {
            Grid tooltipGrid = new Grid();
            ColumnDefinition gridCol1 = new ColumnDefinition();
            ColumnDefinition gridCol2 = new ColumnDefinition();
            tooltipGrid.ColumnDefinitions.Add(gridCol1);
            tooltipGrid.ColumnDefinitions.Add(gridCol2);

            RowDefinition gridRow1 = new RowDefinition();
            RowDefinition gridRow2 = new RowDefinition();
            RowDefinition gridRow3 = new RowDefinition();
            RowDefinition gridRow4 = new RowDefinition();
            tooltipGrid.RowDefinitions.Add(gridRow1);
            tooltipGrid.RowDefinitions.Add(gridRow2);
            tooltipGrid.RowDefinitions.Add(gridRow3);
            tooltipGrid.RowDefinitions.Add(gridRow4);

            var headerTextBlock = new TextBlock();
            headerTextBlock.Text = header;
            headerTextBlock.FontWeight = FontWeights.Bold;
            headerTextBlock.Margin = new Thickness(3);
            headerTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
            Grid.SetRow(headerTextBlock, 0);
            Grid.SetColumn(headerTextBlock, 1);
            tooltipGrid.Children.Add(headerTextBlock);

            var ribbonGroupNameTextBlock = new TextBlock();
            ribbonGroupNameTextBlock.Text = ribbonGroupName;
            ribbonGroupNameTextBlock.Margin = new Thickness(3);
            ribbonGroupNameTextBlock.HorizontalAlignment = HorizontalAlignment.Left;
            ribbonGroupNameTextBlock.FontSize = 10;
            ribbonGroupNameTextBlock.FontWeight = FontWeights.SemiBold;
            Grid.SetRow(ribbonGroupNameTextBlock, 1);
            Grid.SetColumn(ribbonGroupNameTextBlock, 1);
            tooltipGrid.Children.Add(ribbonGroupNameTextBlock);

            var contentTextBlock = new TextBlock();
            contentTextBlock.Text = text;
            contentTextBlock.Margin = new Thickness(3);
            Grid.SetRow(contentTextBlock, 3);
            Grid.SetColumn(contentTextBlock, 1);
            tooltipGrid.Children.Add(contentTextBlock);

            var seperator = new Separator();
            seperator.Margin = new Thickness(3);
            Grid.SetRow(seperator, 2);
            Grid.SetColumn(seperator, 1);
            tooltipGrid.Children.Add(seperator);

            if (uri != "")
            {
                var image = new Image { Source = new BitmapImage(new Uri(uri, UriKind.Relative)) };
                image.Margin = new Thickness(3);
                Grid.SetRow(image, 0);
                Grid.SetColumn(image, 0);
                Grid.SetRowSpan(image, 4);
                tooltipGrid.Children.Add(image);
            }

            return tooltipGrid;
        }

        private void RemoveFromQuickAccessBar(object sender, RoutedEventArgs e)
        {
            var rb = (RibbonButton)sender;
            _testQuickAccessButtons.Remove(rb);
            rb.ContextMenu = new ContextMenu();
            var mItem = new MenuItem();
            mItem.Header = "Add to Quick Access Bar";
            mItem.Click += (s, f) => MoveToQuickAccessBar(rb, f);
            rb.ContextMenu.Items.Add(mItem);
        }

        private void MoveToQuickAccessBar(object sender, RoutedEventArgs e)
        {
            var rb = (RibbonButton)sender;
            var rb2 = CopyButton(rb);
            //var rb2 = rb.Clone();
            _testQuickAccessButtons.Add(rb2);
            rb2.ContextMenu = new ContextMenu();
            var mItem = new MenuItem();
            mItem.Header = "Remove from Quick Access Bar";
            mItem.Click += (s, f) => RemoveFromQuickAccessBar(rb2, f);
            rb2.ContextMenu.Items.Add(mItem);
        }

        private RibbonButton CopyButton(RibbonButton b)
        {
            var newB = new RibbonButton();

            newB.Content = b.Content;//new Image { Source = new BitmapImage(new Uri("/AmTrustExample;component/Images/testImage.jpg", UriKind.Relative)) };
            newB.ToolTip = b.ToolTip;

            foreach (CommandBinding binding in b.CommandBindings)
            {
                newB.CommandBindings.Add(binding);
            }
            //newB.Click += b.Click;
            return newB;
        }
        #endregion
    }

    public class AccentColorMenuData
    {
        public string Name { get; set; }
        public Brush BorderColorBrush { get; set; }
        public Brush ColorBrush { get; set; }

        private ICommand changeAccentCommand;
        private ICommand showLoginDialogCommand;

        public ICommand ChangeAccentCommand
        {
            get { return this.changeAccentCommand ?? (changeAccentCommand = new ActionCommand(e => DoChangeTheme())); }
        }

        protected virtual void DoChangeTheme()
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var accent = ThemeManager.GetAccent(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, accent, theme.Item1);
        }
    }

    public class AppThemeMenuData : AccentColorMenuData
    {
        protected override void DoChangeTheme()
        {
            var theme = ThemeManager.DetectAppStyle(Application.Current);
            var appTheme = ThemeManager.GetAppTheme(this.Name);
            ThemeManager.ChangeAppStyle(Application.Current, theme.Item2, appTheme);
        }
    }

    #region "ActionCommand Class"
    public class ActionCommand : ICommand
    {
        private readonly Action<string> _codeToExecute;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _codeToExecute(null);
        }

        public event EventHandler CanExecuteChanged;

        public ActionCommand(Action<string> codeToExecute)
        {
            _codeToExecute = codeToExecute;
        }
    }
    #endregion

}
